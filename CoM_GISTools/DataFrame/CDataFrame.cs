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

namespace CoM_GISTools.DataFrame
{
    [Guid("57d29ed1-9d79-469b-8c72-6e06300f7359")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CoM_GISTools.DataFrame.CDataFrame")]
    public class CDataFrame : ESRI.ArcGIS.SystemUI.ICommand
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
                // TODO: Add CDataFrame.Bitmap getter implementation
                return m_hBitmap.ToInt32();
            }
        }

        public string Caption
        {
            get
            {
                // TODO: Add CDataFrame.Caption getter implementation
                return "Add data frame"; // default(string);
            }
        }

        public string Category
        {
            get
            {
                // TODO: Add CDataFrame.Category getter implementation
                return SConst.OrganizationName + " GIS Tools";  //default(string);
            }
        }

        public bool Checked
        {
            get
            {
                // TODO: Add CDataFrame.Checked getter implementation
                return default(bool);
            }
        }

        public bool Enabled
        {
            get
            {
                return true;

                //if (m_pExtension == null)
                //{
                //    return false;
                //}

                //IExtensionConfig ipExtensionConfig = (IExtensionConfig)m_pExtension;
                //esriExtensionState extState = ipExtensionConfig.State;

                //if ((extState == ESRI.ArcGIS.esriSystem.esriExtensionState.esriESEnabled))
                //{

                //    return true;

                //}
                //else
                //{

                //    return false;
                //}
            }
        }

        public int HelpContextID
        {
            get
            {
                // TODO: Add CDataFrame.HelpContextID getter implementation
                return 0;  //default(int);
            }
        }

        public string HelpFile
        {
            get
            {
                // TODO: Add CDataFrame.HelpFile getter implementation
                return default(string);
            }
        }

        public string Message
        {
            get
            {
                // TODO: Add CDataFrame.Message getter implementation
                return SConst.OrganizationName + " GIS Tools: Add Data Frame";  //default(string);
            }
        }

        public string Name
        {
            get
            {
                // TODO: Add CDataFrame.Name getter implementation
                return SConst.OrganizationName + " GIS Tools: Add Data Frame";  //default(string);
            }
        }

        public void OnClick()
        {
            // TODO: Add CDataFrame.OnClick implementation
            fmAddDataFrame oAddDataFrame = new fmAddDataFrame();
            oAddDataFrame.App = this.m_pApplication;
            oAddDataFrame.ShowDialog(new WindowWrapper((System.IntPtr)m_pApplication.hWnd));
        }

        public void OnCreate(object hook)
        {
            // TODO: Add CDataFrame.OnCreate implementation
            m_pApplication = hook as IApplication;
            m_pMxDoc = (IMxDocument)m_pApplication.Document;
            m_pMap = (IMap)m_pMxDoc.FocusMap;

            UID pUID = new UIDClass();
            pUID.Value = "CoM_GISTools.CExtension";
            m_pExtension = (IExtensionConfig)m_pApplication.FindExtensionByCLSID(pUID);

            m_bitmap = new System.Drawing.Bitmap(GetType().Assembly.GetManifestResourceStream("CoM_GISTools.Images.dataFrame.bmp")); //  CoM_GISTools.DataFrame.CDataFrame.bmp"));
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
                // TODO: Add CDataFrame.Tooltip getter implementation
                return "Load a data frame";
            }
        }
        #endregion

    }
}
