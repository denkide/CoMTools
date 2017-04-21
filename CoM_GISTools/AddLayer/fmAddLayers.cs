using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting;
using ESRI.ArcGIS;
using System.IO;
using ESRI.ArcGIS.Framework;
using CoM_GISTools.Utility;

namespace CoM_GISTools.AddLayer
{
    public delegate void CloseDelegate();
    public delegate void CloseApp();

    public partial class fmAddLayers : Form
    {
        public RestartEditorApp restartApp;

        private Control m_CurrentControl;
        private ToolStripButton m_CurrentClickedButton = null;
        private IApplication m_pApp;

        public ESRI.ArcGIS.Framework.IApplication App
        {
            get { return this.m_pApp; }
            set { this.m_pApp = value; }
        }

        public fmAddLayers()
        {
            InitializeComponent();
        }

        private void fmAddLayers_Load(object sender, EventArgs e)
        {
            if (!SConst.EnableEditorControl)
            {
                tsbEditor.Visible = false;
            }

            string sStartUpTab = CMedToolsSubs.readRegKey(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\City of Medford", "AddLayersTab");   //SOFTWARE\\City of Medford

            Control ctl = returnNewControl(sStartUpTab);
            m_CurrentControl = ctl;

            ToolStripButton tsb = setToolStripButton(sStartUpTab);
            m_CurrentClickedButton = tsb;
            doButtonChange(tsb);
        }

        private void fmAddLayers_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sTag = m_CurrentControl.Tag.ToString();
            try
            {
                CMedToolsSubs.writeRegKey(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\City of Medford", "AddLayersTab", sTag);
            }
            catch
            {
                // just move on  ... don't throw an error 
            }

            //this.Hide();
            if (SConst.m_pCheckedLayers != null)
                SConst.m_pCheckedLayers.Clear();
            this.Dispose();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (SConst.m_pCheckedLayers != null)
            {
                if (SConst.m_pCheckedLayers.Count > 0)
                {
                    using (CSpatialSubs oSpatialSubs = new CSpatialSubs())
                    {
                        oSpatialSubs.addLayers(this.App, SConst.LayerLocation);
                    }
                }
            }
            if (SConst.m_pCheckedLayers != null)
                SConst.m_pCheckedLayers.Clear();

            this.Cursor = Cursors.Default;
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private ToolStripButton setToolStripButton(string sTag)
        {
            switch (sTag.ToUpper())
            {
                case "CoM_GISTools.ADDLAYER.UCBOUNDARIES":
                    return tsbBoundaries;
                case "CoM_GISTools.ADDLAYER.UCCENSUS":
                    return tsbCensus;
                case "CoM_GISTools.ADDLAYER.UCEMERGENCY":
                    return tsbEmergency;
                case "CoM_GISTools.ADDLAYER.UCENVIRONMENT":
                    return tsbEnvironment;
                case "CoM_GISTools.ADDLAYER.UCINFRASTRUCTURE":
                    return tsbInfrastructure;
                case "CoM_GISTools.ADDLAYER.UCPHOTO":
                    return tsbPhoto;
                case "CoM_GISTools.ADDLAYER.UCSERVICEDISTRICTS":
                    return tsbServiceDistricts;
                case "CoM_GISTools.ADDLAYER.UCSOILSTOPO":
                    return tsbSoils;
                case "CoM_GISTools.ADDLAYER.UCSTRUCTURES":
                    return tsbStructures;
                case "CoM_GISTools.ADDLAYER.UCTAXLOTS":
                    return tsbTaxlots;
                case "CoM_GISTools.ADDLAYER.UCTRANSPORTATION":
                    return tsbTransportation;
                case "CoM_GISTools.ADDLAYER.UCWATER":
                    return tsbWater;
                case "CoM_GISTools.ADDLAYER.UCZONING":
                    return tsbZoning;
                case "CoM_GISTools.ADDLAYER.UCUTILITY":
                    return tsbUtility;
                case "CoM_GISTools.ADDLAYER.UCEDITOR":
                    return tsbEditor;
                case "CoM_GISTools.ADDLAYER.UCMAPSERVICES":
                    return tspMapServices;
                default:
                    return tsbBoundaries;
            }
        }


        private Control returnNewControl(string pCurrentButtonTag)
        {
            Control pRetVal;

            switch (pCurrentButtonTag.ToUpper())
            {
                case "CoM_GISTools.ADDLAYER.UCBOUNDARIES":
                    ucBoundary BoundariesPanel = new ucBoundary();

                    BoundariesPanel.Tag = pCurrentButtonTag;
                    BoundariesPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)BoundariesPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCCENSUS":
                    ucCensus CensusPanel = new ucCensus();
                    CensusPanel.Tag = pCurrentButtonTag;
                    CensusPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)CensusPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCEMERGENCY":
                    ucEmergency EmergencyPanel = new ucEmergency();
                    EmergencyPanel.Tag = pCurrentButtonTag;
                    EmergencyPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)EmergencyPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCENVIRONMENT":
                    ucEnvironment EnvironmentPanel = new ucEnvironment();
                    EnvironmentPanel.Tag = pCurrentButtonTag;
                    EnvironmentPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)EnvironmentPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCINFRASTRUCTURE":
                    ucInfrastructure InfrastructPanel = new ucInfrastructure();
                    InfrastructPanel.Tag = pCurrentButtonTag;
                    InfrastructPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)InfrastructPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCPHOTO":
                    ucPhoto PhotoPanel = new ucPhoto();
                    PhotoPanel.Tag = pCurrentButtonTag;
                    PhotoPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)PhotoPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCSERVICEDISTRICTS":
                    ucServiceDistricts ServiceDistrictsPanel = new ucServiceDistricts();
                    ServiceDistrictsPanel.Tag = pCurrentButtonTag;
                    ServiceDistrictsPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)ServiceDistrictsPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCSOILSTOPO":
                    ucSoilsTopo SoilsTopoPanel = new ucSoilsTopo();
                    SoilsTopoPanel.Tag = pCurrentButtonTag;
                    SoilsTopoPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)SoilsTopoPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCSTRUCTURES":
                    ucStructures StructuresPanel = new ucStructures();
                    StructuresPanel.Tag = pCurrentButtonTag;
                    StructuresPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)StructuresPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCTAXLOTS":
                    ucTaxlots TaxlotsPanel = new ucTaxlots();
                    TaxlotsPanel.Tag = pCurrentButtonTag;
                    TaxlotsPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)TaxlotsPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCTRANSPORTATION":
                    ucTransportation TransportationPanel = new ucTransportation();
                    TransportationPanel.Tag = pCurrentButtonTag;
                    TransportationPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)TransportationPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCWATER":
                    ucWater WaterPanel = new ucWater();
                    WaterPanel.Tag = pCurrentButtonTag;
                    WaterPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)WaterPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCZONING":
                    ucZoning ZoningPanel = new ucZoning();
                    ZoningPanel.Tag = pCurrentButtonTag;
                    ZoningPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)ZoningPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCUTILITY":
                    ucUtility UtilityPanel = new ucUtility();
                    UtilityPanel.Tag = pCurrentButtonTag;
                    UtilityPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)UtilityPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCEDITOR":
                    ucEditor EditorPanel = new ucEditor();

                    EditorPanel.Tag = pCurrentButtonTag;
                    EditorPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)EditorPanel;
                    break;
                case "CoM_GISTools.ADDLAYER.UCMAPSERVICES":
                    ucMapService MapServicePanel = new ucMapService();

                    MapServicePanel.Tag = pCurrentButtonTag;
                    MapServicePanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)MapServicePanel;
                    break;
                default:
                    //ucBoundaries defaultPanel = new ucBoundaries();
                    ucBoundary defaultPanel = new ucBoundary();

                    defaultPanel.Tag = pCurrentButtonTag;
                    defaultPanel.Dock = DockStyle.Fill;

                    pRetVal = (Control)defaultPanel;
                    break;
            }

            return pRetVal;
        }


        private void resetCheckboxes()
        {

        }

        private void closeForm()
        {
            this.Dispose();
            if (SConst.m_pCheckedLayers != null)
                SConst.m_pCheckedLayers.Clear();
        }

        private void closeApp()
        {
            restartApp();

        }

        private void fmAddLayers_Paint(object sender, PaintEventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count < 1)
                MessageBox.Show("Error: Panel could not be found.");
        }

        private void tsbBoundaries_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("only click please");
        }

        private void buttonClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem tsItem = (ToolStripItem)sender;
                doButtonChange((ToolStripButton)tsItem);
            }
            catch (Exception ex)
            {
                //string s = ex.Message;
                //s += " ---- that was it";
            }
        }

        private void doButtonChange(ToolStripButton tsbutton)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // clear it out first
                splitContainer1.Panel2.Controls.Clear();

                Control p_NewControl;
                string p_ControlName = tsbutton.Tag.ToString();

                clearCurrentCheckButton();
                setCurrentButton(tsbutton);

                if (p_ControlName != m_CurrentControl.Name.ToString())
                {
                    p_NewControl = splitContainer1.Panel2.Controls[p_ControlName];
                    if (p_NewControl == null)
                    {
                        p_NewControl = returnNewControl(m_CurrentClickedButton.Tag.ToString());
                        p_NewControl.Name = p_ControlName;
                        p_NewControl.Dock = DockStyle.Fill;
                        splitContainer1.Panel2.Controls.Add(p_NewControl);

                        if (tsbutton.Text.ToUpper() == "EDITORS")
                        {
                            if (SConst.EnableEditorControl)
                            {
                                loadEditForm(p_NewControl);
                            }
                        }
                    }

                    //m_CurrentControl.Visible = false;
                    p_NewControl.Visible = true;
                    m_CurrentControl = p_NewControl;
                }
                Cursor.Current = Cursors.Default;
                splitContainer1.Panel2.Refresh();
            }
            catch (Exception ex)
            {
                //string s = ex.Message;
                //s += " WEEEEE";
            }
        }

        private void loadEditForm(Control ctl)
        {
            ucEditor ucEdit = (ucEditor)ctl;
            ucEdit.App = this.App;

            ucEdit.CloseForm = new CloseDelegate(this.closeForm);
            ucEdit.CloseViewerApp = new CloseApp(this.closeApp);
            ucEdit.loadForm();
        }

        private void setCurrentButton(ToolStripButton tsb)
        {
            // set this new button to be the current button
            m_CurrentClickedButton = tsb;
            m_CurrentClickedButton.Select();
            m_CurrentClickedButton.Checked = true;
            m_CurrentClickedButton.CheckState = CheckState.Checked;
            return;
        }

        private void clearCurrentCheckButton()
        {
            // get rid of the current check
            m_CurrentClickedButton.Checked = false;
            return;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            //  this is a fix for a toolstip problem we were having with 
            //  double clicks at a particular frequency.
            //
            //  djr: 10/29/2007

            if (splitContainer1.Panel2.Controls.Count < 1)
            {
                splitContainer1.Panel2.Controls.Add(this.m_CurrentControl);
                m_CurrentClickedButton.Checked = true;
            }
        }

        private void checkEditor(ToolStripButton tsb)
        {
            if (tsb.Text.ToUpper() == "EDITORS")
            {
                Control p_NewControl = returnNewControl(tsb.Tag.ToString());
                ucEditor ucEdit = (ucEditor)p_NewControl;
                ucEdit.App = this.App;

                ucEdit.CloseForm = new CloseDelegate(this.closeForm);
                ucEdit.CloseViewerApp = new CloseApp(this.closeApp);
                ucEdit.loadForm();
            }
        }


    }
}