using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.DirectoryServices;
using System.Collections;
using ESRI.ArcGIS.Geodatabase;
using CoM_GISTools.Utility;
//using MedfordToolsDAL;

namespace CoM_GISTools.AddLayer
{
    public partial class ucEditor : UserControl
    {
        public CloseDelegate CloseForm;
        public CloseApp CloseViewerApp;

        protected ESRI.ArcGIS.Framework.IApplication m_pApp;
        protected string _path;

        public ESRI.ArcGIS.Framework.IApplication App
        {
            get { return this.m_pApp; }
            set { this.m_pApp = value; }
        }

        public ucEditor()
        {
            InitializeComponent();

            this.label1.Text = WindowsIdentity.GetCurrent().Name;
            this.lblCurrentLicense.Text = returnCurrentLicense();

            // get a handle to the form.App hook
            //fmAddLayers oForm = new fmAddLayers();

            lbEditabelLayers.Enabled = true;
            btnEdit.Enabled = true;
            lbEditabelLayers.Items.Clear();//this.m_pApp = oForm.App;
        }

        public void loadForm()
        {
            //string sName = System.Environment.UserName; // WindowsIdentity.GetCurrent().Name;
            //ArrayList userLayers = null;

            ////MessageBox.Show(CMedToolsSubs.getObjectProperty(sName, "givenName") + " --- " + CMedToolsSubs.getObjectProperty(sName, "SN"));

            //if (SConst.GotDBConn)
            //    using (CData oData = new CData(SConst.GISConnString.ToString()))
            //    {
            //        userLayers = oData.getUserLayers(CMedToolsSubs.getObjectProperty(sName, "givenName"), CMedToolsSubs.getObjectProperty(sName, "SN"));
            //    }
        
            //if (userLayers != null)
            //{
            //    lbEditabelLayers.Enabled = true;
            //    btnEdit.Enabled = true;

            //    foreach (string item in userLayers)
            //    {
            //        lbEditabelLayers.Items.Add(item.ToString());
            //    }
            //}
            //else
            //{
            //    lbEditabelLayers.Items.Add("No layers are available for editing");
            //    lbEditabelLayers.Enabled = false;
            //    btnEdit.Enabled = false;
            //}
        }

        public static bool isAllowedDatasetFC(string sLayer)
        {
            bool bRetVal = false;
            ESRI.ArcGIS.Geodatabase.IWorkspace pWorkSpace;
            using (CSpatialSubs oSpatialSubs = new CSpatialSubs())
            {
                pWorkSpace = oSpatialSubs.returnEditableSDEWorkspace();
            }

            if (pWorkSpace != null)
            {
                // get the feature classes from each dataset
                IEnumDataset enumFeatureDatasets = pWorkSpace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                enumFeatureDatasets.Reset();

                IFeatureDataset featureDataset = (IFeatureDataset)enumFeatureDatasets.Next();

                while (featureDataset != null)
                {
                    ISQLPrivilege oDSPriv = (ISQLPrivilege)featureDataset.FullName;
                    int iDSPriv = oDSPriv.SQLPrivileges;

                    if (iDSPriv > 1)
                    {
                        IFeatureClassContainer fcContainer = (IFeatureClassContainer)featureDataset;
                        IEnumFeatureClass enumFeatureClasses = fcContainer.Classes;
                        enumFeatureClasses.Reset();
                        IFeatureClass fc = (IFeatureClass)enumFeatureClasses.Next();
                        while (fc != null)
                        {
                            if (sLayer == fc.AliasName.ToString())
                            {
                                bRetVal = true;
                                break;
                            }

                            fc = (IFeatureClass)enumFeatureClasses.Next();
                        }
                    }
                    featureDataset = (IFeatureDataset)enumFeatureDatasets.Next();
                }
            }
            return bRetVal;
        }

        public static bool isAllowedStandaloneFC(string sLayer)
        {
            bool bRetVal = false;
            ESRI.ArcGIS.Geodatabase.IWorkspace pWorkSpace;

            using (CSpatialSubs oSpatialSubs = new CSpatialSubs())
            {
                pWorkSpace = oSpatialSubs.returnEditableSDEWorkspace();
            }

            if (pWorkSpace != null)
            {
                IEnumDataset enumFC = pWorkSpace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                enumFC.Reset();

                IFeatureClass fc = (IFeatureClass)enumFC.Next();

                while (fc != null)
                {
                    IDataset ds = fc as IDataset;
                    ISQLPrivilege oFCPriv = (ISQLPrivilege)ds.FullName;

                    int iFCPriv = oFCPriv.SQLPrivileges;

                    if (iFCPriv > 1)
                    {
                        if (sLayer == fc.AliasName.ToString())
                        {
                            bRetVal = true;
                            break;
                        }

                        fc = (IFeatureClass)enumFC.Next();
                    }
                }
            }
            return bRetVal;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            if (oSpatialSubs.returnCurrentProductCode() == ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcView)
            {
                string sMsg = "This action requires that you use at least an ArcEditor license\r\n\r\n";
                sMsg += "Click 'YES' below to have the application restart for you (you will NOT be prompted to save)\r\n";
                sMsg += "or\r\nclick 'No' below to restart later and then checkout an Editor license from the Desktop Administrator";
                sMsg += "\r\n\r\nDo you want to restart the application?";

                if (MessageBox.Show(sMsg, "Editor License Required", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //if (CMedToolsSubs.isProductAvailable(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcEditor) == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                    //{
                        //// shut down the app and restart
                        CMedToolsSubs.ResetAsEditor = true;
                        CloseForm();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("There is no Editor license available at the moment.", "License problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                }
            }
            else
            {

                Cursor = Cursors.WaitCursor;
                try
                {
                    ///
                    /// rev. 12/13/2007
                    /// by: David Renz
                    /// changed to just use the selected featureclass
                    ///
                    oSpatialSubs.addFeatureLayerToMap(this.App, lbEditabelLayers.SelectedItem.ToString(), true);

                    // add the layers to ArcMap
                    //foreach (object obj in lbEditabelLayers.Items)
                    //{
                    //    CMedToolsSubs.addFeatureLayerToMap(this.App, obj.ToString(), true);
                    //}
                    CloseForm();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("An error occurred while loading the layers into the application.\r\n\r\nPlease check with the GIS administrator to ensure that you have edit priviledges on the selected layers.");
                    this.lblEditMsg.Text = ex.Message.ToString(); //"An error occurred while starting an editing session.\r\n\r\nPlease check with the GIS administrator to ensure\r\nthat you have edit priviledges on the selected layers.";
                    //this.lblEditMsg.Text += "\r\n\r\n" + ex.Message;
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    oSpatialSubs.Dispose();
                }
            }
        }

        private bool editorCheckedOut()
        {
            bool bRetVal = false;
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            
            ESRI.ArcGIS.esriSystem.esriLicenseProductCode productCode = oSpatialSubs.returnCurrentProductCode();
            

            if (productCode == ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcEditor)
            {
                bRetVal = true;
            }
            else
            {
                //if (CMedToolsSubs.isProductAvailable(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcEditor) == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                //{
                    ESRI.ArcGIS.esriSystem.esriLicenseStatus status = oSpatialSubs.checkOutLicenses(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcEditor);
                    if ((status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) || (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized))
                        bRetVal = true;
                    
                //}
            }
            oSpatialSubs.Dispose();
            return bRetVal;
        }
        
        private string returnCurrentLicense()
        {
            string sRetVal = "";
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            switch (oSpatialSubs.returnCurrentProductCode())
            {
                case ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcView:
                    sRetVal = "ArcView";
                    break;
                case ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcEditor:
                    sRetVal = "ArcEditor";
                    break;
                case ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeArcInfo:
                    sRetVal = "ArcInfo";
                    break;
                default:
                    sRetVal = "unspecified";
                    break;
            }
            oSpatialSubs.Dispose();
            return sRetVal;
        }
    }
}

//private ArrayList getUserLayers(string sFirstName, string sLastName)
//{
//    ArrayList userLayers = new ArrayList();
//    SqlConnection oConn = new SqlConnection(CConst.GISConnString.ToString());
//    SqlDataReader reader;
//    try
//    {
//        oConn.Open();

//        string commandString = "SELECT FCName FROM vw_FCEditors WHERE FirstName = '" + sFirstName + "' AND LastName = '" + sLastName + "'";

//        SqlCommand cmd = new SqlCommand(commandString,oConn);
//        reader = cmd.ExecuteReader();

//        while (reader.Read())
//        {
//            userLayers.Add(reader["FCName"].ToString());
//        }

//    }
//    catch (Exception ex)
//    {
//        throw new Exception(ex.Message);
//    }
//    finally
//    {
//        oConn.Close();
//    }

//    return userLayers;

//}



//textBox1.Text += "Display Name: " + CMedToolsSubs.getObjectProperty("djrenz", "displayName") + "\r\n";  //GetObjectProperty("djrenz", "displayName");
//textBox1.Text += "Mail: " + CMedToolsSubs.getObjectProperty("djrenz", "mail") + "\r\n";
//textBox1.Text += "Proxy Addr: " + CMedToolsSubs.getObjectProperty("djrenz", "proxyAddresses") + "\r\n";
//textBox1.Text += "Common Name: " + CMedToolsSubs.getObjectProperty("djrenz", "CN") + "\r\n";
//textBox1.Text += "Description: " + CMedToolsSubs.getObjectProperty("djrenz", "description") + "\r\n";
//textBox1.Text += "Given Name: " + CMedToolsSubs.getObjectProperty("djrenz", "givenName") + "\r\n";
//textBox1.Text += "SurName: " + CMedToolsSubs.getObjectProperty("djrenz", "SN") + "\r\n";
//textBox1.Text += "Target Address: " + CMedToolsSubs.getObjectProperty("djrenz", "targetAddress") + "\r\n";  