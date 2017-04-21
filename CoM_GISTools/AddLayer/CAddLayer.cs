using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using CoM_GISTools.Utility;
////using MedfordToolsDAL;
using System.Data;

namespace CoM_GISTools.AddLayer
{
    public delegate void RestartEditorApp();

    [Guid("591a9aab-eba0-40df-b491-ea69c7984e54")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CoM_GISTools.AddLayer.CAddLayer")]
    public class CAddLayer : ESRI.ArcGIS.SystemUI.ICommand
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
            MxCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IntPtr m_hBitmap;
        private System.Drawing.Bitmap m_bitmap;
        private IApplication m_pApplication;
        private IMxDocument m_pMxDoc;
        private IMap m_pMap;
        private IExtensionConfig m_pExtension;


        #region "ICommand Implementations"
        public int Bitmap
        {
            get
            {
            //    // TODO: Add CAddLayer.Bitmap getter implementation
            //return default(int);
            //    string bitmapResourceName = "CAddLayer.bmp"; //GetType().Name + ".bmp";
            //    this.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                return m_hBitmap.ToInt32();
            }
        }

        public string Caption
        {
            get
            {
                // TODO: Add CAddLayer.Caption getter implementation
                return "Add " + SConst.OrganizationName + " GIS Layers"; //default(string);
            }
        }

        public string Category
        {
            get
            {
                // TODO: Add CAddLayer.Category getter implementation
                return SConst.OrganizationName + " GIS Tools";  //default(string);
            }
        }

        public bool Checked
        {
            get
            {
                // TODO: Add CAddLayer.Checked getter implementation
                return default(bool);
            }
        }

        public bool Enabled
        {
            get
            {
                return true;
                //if (CMedToolsSubs.ResetAsEditor)
                //{
                //    this.m_pApplication.Shutdown();
                //    return true;
                //}
                //else
                //{
                //    if (m_pExtension == null)
                //    {
                //        return false;
                //    }

                //    IExtensionConfig ipExtensionConfig = (IExtensionConfig)m_pExtension;
                //    esriExtensionState extState = ipExtensionConfig.State;

                //    if ((extState == ESRI.ArcGIS.esriSystem.esriExtensionState.esriESEnabled))
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //// TODO: Add CAddLayer.Enabled getter implementation
                ////return default(bool);
            }
        }

        public int HelpContextID
        {
            get
            {
                // TODO: Add CAddLayer.HelpContextID getter implementation
                return 0; //default(int);
            }
        }

        public string HelpFile
        {
            get
            {
                // TODO: Add CAddLayer.HelpFile getter implementation
                return default(string);
            }
        }

        public string Message
        {
            get
            {
                // TODO: Add CAddLayer.Message getter implementation
                return SConst.OrganizationName + " GIS Tools: Add Layers";  //default(string);
            }
        }

        public string Name
        {
            get
            {
                // TODO: Add CAddLayer.Name getter implementation
                return SConst.OrganizationName + " AddLayers";  //default(string);
            }
        }

        public void OnClick()
        {
            // TODO: Add CAddLayer.OnClick implementation
            //MessageBox.Show("Weee");

            fmAddLayers oAddLayers = new fmAddLayers();
            oAddLayers.App = this.m_pApplication;
            //oAddLayers.restartApp = new RestartEditorApp(this.restartApp);
            oAddLayers.ShowDialog(new WindowWrapper((System.IntPtr)m_pApplication.hWnd)); 
        }

        public void OnCreate(object hook)
        {
            // TODO: Add CAddLayer.OnCreate implementation
            m_pApplication = hook as IApplication;
            m_pMxDoc = (IMxDocument)m_pApplication.Document;
            m_pMap = (IMap)m_pMxDoc.FocusMap;

            UID pUID = new UIDClass();
            pUID.Value = "CoM_GISTools.CExtension";
            m_pExtension = (IExtensionConfig)m_pApplication.FindExtensionByCLSID(pUID);

            //// testing
            //if (m_pExtension.State == esriExtensionState.esriESEnabled)
            //    MessageBox.Show("CAddLayer::Enabled");
            //else if (m_pExtension.State == esriExtensionState.esriESDisabled)
            //    MessageBox.Show("CAddLayer::Disabled");
            //else
            //    MessageBox.Show("CAddLayer::Unavailable");

            m_bitmap = new System.Drawing.Bitmap(GetType().Assembly.GetManifestResourceStream("CoM_GISTools.Images.addLayer.bmp"));    //("CoM_GISTools.AddLayer.CAddLayer.bmp"));
            if (m_bitmap != null)
            {
                m_bitmap.MakeTransparent(m_bitmap.GetPixel(1, 1));
                m_hBitmap = m_bitmap.GetHbitmap();
            }
        }

        public string Tooltip
        {
            get
            {
                // TODO: Add CAddLayer.Tooltip getter implementation
                return "Add Layers";
            }
        }

        //private void restartApp()
        //{
        //    m_pExtension = null;

        //    IDocumentDirty2 pDocDirty;
        //    pDocDirty = (IDocumentDirty2)m_pMxDoc;
        //    pDocDirty.SetClean();
        //    m_pApplication.Shutdown();
        //    Marshal.ReleaseComObject((object)m_pApplication);
        //    m_pApplication = null;
        //}

        #endregion

    }
}
