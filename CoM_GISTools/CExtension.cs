using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ArcMapUI;

using CoM_GISTools.Utility;

namespace CoM_GISTools
{
    [Guid("4308e819-01b7-4b93-a25f-f26227cf8af5")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CoM_GISTools.CExtension")]
    public class CExtension : IExtension, IExtensionConfig
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxExtension.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxExtension.Unregister(regKey);

        }

        #endregion
        #endregion
        
        private IApplication m_pApplication;
        private esriExtensionState m_pExtState;

        // Event member variables
        private IDocumentEvents_Event m_docEvents;

        #region IExtension Members

        /// <summary>
        /// Name of extension. Do not exceed 31 characters
        /// </summary>
        public string Name
        {
            get
            {
                //TODO: Modify string to uniquely identify extension
                return SConst.OrganizationName + " GIS Tools";     //default(string);
            }
        }

        public void Shutdown()
        {
            //TODO: Clean up resources

            m_pApplication = null;
        }

        public void Startup(ref object initializationData)
        {
            try
            {
                if (CMedToolsSubs.ensureSettingsFile())
                {
                    //CMedToolsSubs.returnSettingValue("Task_User_Pwd", SConst.DataSettingsLocation).ToString();

                    m_pApplication = initializationData as IApplication;


                    Dictionary<string, string> dctMapLayers = new Dictionary<string, string>();
                    dctMapLayers = SConst.PlanningLayers;

                    //if (CMedToolsSubs.canConnect(SConst.LXConnString))
                    //    SConst.GotDBConn = true;
                    //else
                    //    SConst.GotDBConn = false;

                    // --------------------------
                    //  4-16-2008
                    //  DJR
                    //      -- added so that we can listen for OnSaveEdits editor event
                    //      -- begin changes
                    // --------------------------
                    UID editorUID = new UID();
                    editorUID.Value = "esriEditor.Editor";
                    if (m_pApplication == null)
                        return;


                    setConstVals();

                    // --------------------------
                    //      end changes
                    // --------------------------

                    //m_pExtState = esriExtensionState.esriESEnabled;
                    this.State = esriExtensionState.esriESEnabled;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(SConst.OrganizationName + " GIS Error: settings not found");
                    this.State = esriExtensionState.esriESDisabled;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "STARTUP ERROR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        #endregion

        #region IExtensionConfig Members

        public string Description
        {
            get
            {
                //TODO: Replace description (use \r\n for line break)

                return SConst.OrganizationName + " GIS Tools (always enabled)";
            }
        }

        /// <summary>
        /// Friendly name shown in the Extension dialog
        /// </summary>
        public string ProductName
        {
            get
            {
                return SConst.OrganizationName + " GIS Tools (always enabled)";
            }
        }

        public esriExtensionState State
        {
            get
            {
                return esriExtensionState.esriESEnabled; // m_pExtState;
            }
            set
            {
                m_pExtState = esriExtensionState.esriESEnabled;

            }
        }

        #endregion

        /// <summary>
        /// Determine extension state 
        /// </summary>
        /// <param name="requestEnable">true if to enable; false to disable</param>
        private esriExtensionState StateCheck(bool requestEnable)
        {
            //TODO: Replace with advanced extension state checking if needed
            //Turn on or off extension directly
            if (requestEnable)
                return esriExtensionState.esriESEnabled;
            else
                return esriExtensionState.esriESDisabled;
        }

        // Wiring
        private void SetUpDocumentEvent(IDocument myDocument)
        {
            m_docEvents = myDocument as IDocumentEvents_Event;
            m_docEvents.OpenDocument += new IDocumentEvents_OpenDocumentEventHandler(OnOpenDocument);

            //Optional, new and close document events
            m_docEvents.NewDocument += new IDocumentEvents_NewDocumentEventHandler(OnNewDocument);
            m_docEvents.CloseDocument += new IDocumentEvents_CloseDocumentEventHandler(OnCloseDocument);
        }

        void OnOpenDocument()
        {

        }

        void OnCloseDocument()
        {

        }

        void OnNewDocument()
        {
            this.dockToolBar(m_pApplication);
        }

        public void dockToolBar(IApplication pApp)
        {
            IMxDocument pMxDoc = (IMxDocument)pApp.Document;

            ICommandBars pCmdBars;
            ICommandBars pMainMenu;

            ICommandBar pToolsBar;
            ICommandBar pMainBar;

            UID pUID = new UIDClass();
            UID pUID2 = new UIDClass();

            pUID2.Value = "esriArcMapUI.MxMenuBar";
            pMainMenu = m_pApplication.Document.CommandBars;
            pMainBar = (ICommandBar)pMainMenu.Find(pUID2, false, false);

            pUID.Value = "CoM_GISTools.CToolbar";
            pCmdBars = m_pApplication.Document.CommandBars;
            pToolsBar = (ICommandBar)pCmdBars.Find(pUID, false, false);

            //m_bToolBarEnabled = True
            pMainBar.Dock(esriDockFlags.esriDockTop, null);
            pToolsBar.Dock(esriDockFlags.esriDockBottom, pMainBar);

        }

        private void setConstVals()
        {
            // set the location for the default layer location
            SConst.LayerLocation = CMedToolsSubs.returnSettingValue("Default_Layer_Location", SConst.DataSettingsLocation);

            //// set the flag that allows for City of Medford Specific content
            //SConst.EnableMedfordContent = Convert.ToBoolean(CMedToolsSubs.returnSettingValue("Enable_MedfordContent", SConst.DataSettingsLocation).ToString());

            //// set the flag that allows for City of Medford Specific content
            //SConst.EnableEditorControl = Convert.ToBoolean(CMedToolsSubs.returnSettingValue("Enable_EditorControl", SConst.DataSettingsLocation).ToString());

            // set the organization name
            SConst.OrganizationName = CMedToolsSubs.returnSettingValue("Organization_Name", SConst.DataSettingsLocation).ToString();
        }
    }
}