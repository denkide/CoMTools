using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using CoM_GISTools.Utility;
////using MedfordToolsDAL;
using System.Data;

namespace CoM_GISTools.DataFrame
{
    public partial class fmAddDataFrame : Form
    {
        #region " M O D U L E   L E V E L  V A R I A B L E S "

        private IApplication m_pApp;
        private string[] m_commonLayers; // = { "City_Limits_Outline", "Urban_Growth_Boundary", "Building_Footprints_Fill", "Driveways", "Water_Lines_by_Size", "Aerial_Photo_Color_2007", "Shaded_Relief_Gray", "Bear_Creek_Greenway", "Parks", "Public_Facilities", "Schools_by_Grade_Levels", "Tax_Lot_Outlines", "Public_Lands_by_Agency", "Site_Address", "Tax_Lots_Medford", "Medford_Easements", "All_Streets", "Medford_Alleys", "Bike_Routes", "Parking_Lots", "Railroads", "Streams_And_Irrigation_Ditches", "Rivers", "Lakes_and_Ponds" };
        //private Dictionary<string, string> m_dctCommonLayers;
        private Collection<string> m_EconOnLayers;
        private Collection<string> m_FireOnLayers;
        private Collection<string> m_PlanOnLayers;
        private Collection<string> m_PoliceOnLayers;
        private Collection<string> m_PWOnLayers;

        #endregion

        #region " P R O P E R T I E S "

        public ESRI.ArcGIS.Framework.IApplication App
        {
            get { return this.m_pApp; }
            set { this.m_pApp = value; }
        }

        #endregion

        #region "C O N S T R U C T O R "

        public fmAddDataFrame()
        {
            InitializeComponent();

            Dictionary<string, string> dctCommon = SConst.CommonLayers;
            this.m_commonLayers = new string[dctCommon.Keys.Count];
            dctCommon.Values.CopyTo(this.m_commonLayers, 0);

            //CConst.CommonLayers.Values.CopyTo(this.m_commonLayers, 0);

            this.m_EconOnLayers = this.getOnLayers("@type='EconDev' and @state='ON'");      // this.getEconOnLayers();
            this.m_FireOnLayers = this.getOnLayers("@type='Fire' and @state='ON'");         //this.getFireOnLayers();
            this.m_PlanOnLayers = this.getOnLayers("@type='Planning' and @state='ON'");     //this.getPlanOnLayers();
            this.m_PWOnLayers = this.getOnLayers("@type='PublicWorks' and @state='ON'");    //this.getPWOnLayers();
            this.m_PoliceOnLayers = this.getOnLayers("@type='Police' and @state='ON'");    //this.getPoliceOnLayers(); 
        }

        #endregion

        #region "P R I V A T E   F U N C T I O N S"

        private IMapFrame MakeMapFrame(IEnvelope pEnv,IMap pMap) 
        {
            IMapFrame pRetVal = new MapFrame() as IMapFrame;
            pRetVal.Map = pMap;
    
            IElement pElement = (IElement)pRetVal;
            pElement.Geometry = pEnv;
            return pRetVal;
        }

        private void createDataFrame(string sMapName)
        {
            try
            {
                IMxDocument pMxDoc = (IMxDocument)this.App.Document;
                IMap pMap = new MapClass();
                pMap.Name = sMapName;

                //Dictionary<string, string> dctMapLayers = 

                Dictionary<string, string> dctMapLayers = new Dictionary<string, string>();
                switch (sMapName.ToUpper())
                {
                    case "ECONOMIC DEVELOPMENT":
                        dctMapLayers = SConst.EconDevLayers;
                        this.loadLayers(ref pMap, dctMapLayers, this.m_EconOnLayers);
                        break;
                    case "FIRE":
                        dctMapLayers = SConst.FireLayers;
                        this.loadLayers(ref pMap, dctMapLayers, this.m_FireOnLayers);
                        break;
                    case "PLANNING":
                        dctMapLayers = SConst.PlanningLayers;
                        this.loadLayers(ref pMap, dctMapLayers, this.m_PlanOnLayers);
                        break;
                    case "POLICE":
                        dctMapLayers = SConst.PoliceLayers;
                        this.loadLayers(ref pMap, dctMapLayers, this.m_PoliceOnLayers);
                        break;
                    case "PUBLIC WORKS":
                        dctMapLayers = SConst.PublicWorksLayers;
                        this.loadLayers(ref pMap, dctMapLayers, this.m_PWOnLayers);
                        break;
                    default:
                        return;
                }         
                        
                //addMapLayers(ref pMap, sMapName);
                IEnvelope pEnv = new EnvelopeClass();
                pEnv.PutCoords(1, 1, 5, 4); // page units

                pMxDoc.Maps.Add(pMap);

                IMapFrame pMapFrame = this.MakeMapFrame(pEnv, pMap);
                pMapFrame.Map.MapUnits = esriUnits.esriFeet;

                IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
                pGC.AddElement((IElement)pMapFrame, 0);
                pMxDoc.CurrentContentsView.Refresh(null);

                pMxDoc.UpdateContents();
                Application.DoEvents();

                // activate the frame and zoom to the extent of the UGB
                for (int i = 0; i < pMxDoc.Maps.Count;i++ )
                {
                    IMap map = pMxDoc.Maps.get_Item(i);
                    if (map.Name == sMapName)
                    {
                        pMxDoc.ActiveView = (IActiveView)map;

                        //Set the query filter. use the arguements passed into the function
                        ESRI.ArcGIS.Geodatabase.IQueryFilter pQueryFilter = new ESRI.ArcGIS.Geodatabase.QueryFilterClass();
                        pQueryFilter.WhereClause = "CITY = 'Medford'";

                        using (CSpatialSubs oSpatialSubs = new CSpatialSubs())
                        {
                            oSpatialSubs.selectFeatures(pQueryFilter, this.App, (IFeatureLayer)oSpatialSubs.returnFeatureLayer(pMap, "MEDSDE.DBO.Urban_Growth_Boundary"), true);
                        }
                        pMxDoc.FocusMap.ClearSelection();
                    }
                }
                pMxDoc.UpdateContents();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                s += ex.InnerException.Message;
                s += " ";
            }
        }

        private void loadLayers(ref IMap pMap, Dictionary<string,string> dctLayers,Collection<string> colOnLayers)
        {
            Collection<string> colMissingLayers = new Collection<string>();
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            try
            {
                foreach (KeyValuePair<string, string> pair in dctLayers)
                {
                    if (CMedToolsSubs.layerExists(dctLayers[pair.Key].ToString(), SConst.LayerLocation))
                        pMap.AddLayer(oSpatialSubs.returnLayer(dctLayers[pair.Key].ToString(), SConst.LayerLocation));
                    else
                        colMissingLayers.Add(pair.Key);
                }

                for (int i = 0; i < pMap.LayerCount; i++)
                {
                    ILayer pLayer = pMap.get_Layer(i);
                    if (!colMissingLayers.Contains(pLayer.Name))
                    {
                        if (!colOnLayers.Contains(pLayer.Name))
                            pLayer.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oSpatialSubs.Dispose();
            }
        }

        #endregion

        #region " C O L L E C T I O N   L O A D E R S"

        private Collection<string> getOnLayers(string sFilter)
        {
            Dictionary<string, string> dct = CMedToolsSubs.returnConfigNode("Layer", sFilter, SConst.LayerSettingsLocation);
            Collection<string> onLayers = new Collection<string>();

            foreach (KeyValuePair<string, string> pair in dct)
            {
                onLayers.Add(pair.Key);
            }
            return onLayers;
        }

        #endregion

        #region " C U S T O M    E V E N T   F U N C T I O N S"

        private void loadPubWorksLayers()
        {
            createDataFrame("Public Works");
        }

        private void loadPoliceLayers()
        {
            createDataFrame("Police");
        }

        private void loadPlanningLayers()
        {
            createDataFrame("Planning");
        }

        private void loadFireLayers()
        {
            createDataFrame("Fire");
        }

        private void loadEconomDevLayers()
        {
            createDataFrame("Economic Development");
        }

        private void loadCodeEnfLayers()
        {
            createDataFrame("Code Enforcement");
        }

        #endregion

        #region "E V E N T S"

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IMaps pMaps = (IMaps)pMxDoc.Maps;

            try
            {
                if (this.chkEconomDev.Checked == true)
                    loadEconomDevLayers();

                if (this.chkFire.Checked == true)
                    loadFireLayers();

                if (this.chkPlan.Checked == true)
                    loadPlanningLayers();

                if (this.chkPolice.Checked == true)
                    loadPoliceLayers();

                if (this.chkPubWorks.Checked == true)
                    loadPubWorksLayers();

                pMxDoc.UpdateContents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the data frame you selected.\r\n\r\n" + ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Dispose();
            }
        }

        #endregion
    }
}