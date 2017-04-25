using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Principal;
using System.DirectoryServices;

namespace CoM_GISTools.Utility
{
    public struct SConst
    {
        #region "P U B L I C   V A R I A B L E S"

        public static List<string> m_pCheckedLayers;

        #endregion

        #region "P R I V A T E   V A R I A B L E S"

        private static string m_sLayerLocation;
        private static string m_sDataSettingsLocation;
        private static string m_sLayerSettingsLocation;
        private static string m_sPrintSettingsLocation;
        private static string m_sOrgName;
        private static bool m_EnableMedfordContent;
        private static bool m_EnableEditorControl;
        private static bool m_bGotDBConn;

        #endregion


        #region " P U B L I C    P R O P E R T I E S"

        public static bool GotDBConn
        {
            get
            {
                return m_bGotDBConn;
            }
            set
            {
                m_bGotDBConn = value;
            }
        }

        // Changed
        //          --- changed the way settings files are split up
        //              the single file was a little cumbersome
        public static string DataSettingsLocation
        {
            get
            {
                return m_sDataSettingsLocation;
            }
            set
            {
                m_sDataSettingsLocation = value;
            }
        }

        // Changed
        //          --- changed the way settings files are split up
        //              the single file was a little cumbersome
        public static string LayerSettingsLocation
        {
            get
            {
                return m_sLayerSettingsLocation;
            }
            set
            {
                m_sLayerSettingsLocation = value;
            }
        }

        // Changed
        //          --- changed the way settings files are split up
        //              the single file was a little cumbersome
        public static string PrintSettingsLocation
        {
            get
            {
                return m_sPrintSettingsLocation;
            }
            set
            {
                m_sPrintSettingsLocation = value;
            }
        }


        public static string OrganizationName
        {
            get
            {
                return m_sOrgName;
            }
            set
            {
                m_sOrgName = value;
            }
        }

        public static bool EnableEditorControl
        {
            get
            {
                return m_EnableEditorControl;
            }
            set
            {
                m_EnableEditorControl = value;
            }
        }

        public static bool EnableMedfordContent
        {
            get
            {
                return m_EnableMedfordContent;
            }
            set
            {
                m_EnableMedfordContent = value;
            }
        }

        /// <summary>
        ///     Name:
        ///         GISConnString
        /// 
        ///     Description:
        ///         This is the connection string for the editing spatial database
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static string GISConnString
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("GISConnString", DataSettingsLocation);
            }
        }


        /// <summary>
        ///     Name:
        ///         LXConnString
        /// 
        ///     Description:
        ///         This is the connection string for the production version of the LXDatabase
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        ///
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static string LXConnString
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("LXConnString", DataSettingsLocation);
            }
        }



        /// <summary>
        ///     Name:
        ///         SDEConnString
        /// 
        ///     Description:
        ///         This is the connection string for the production version of the SDE Database
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        ///
        ///  DJR
        ///      -- added so that we can query sde database attributes
        /// -----------------------------------------------------------------
        public static string SDEConnString
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("MEDSDE_1_PROD_GIS", DataSettingsLocation);
            }
        }


        /// <summary>
        ///     Name:
        ///         Taxlots
        /// 
        ///     Description:
        ///         This is the 3 part name for the taxlots shapefile
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static string Taxlots
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("Taxlots_FullName", DataSettingsLocation); //"MEDSDE.DBO.TAXLOTS";
            }
        }

        /// <summary>
        ///     Name:
        ///         TaxlotLayerName
        /// 
        ///     Description:
        ///         This is the layer name for the taxlots
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        ///
        ///  DJR
        ///      -- changed to read from Settings.xml file  (so that we can support laptops)
        /// -----------------------------------------------------------------
        public static string TaxlotLayerName
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("Taxlots_LayerName", DataSettingsLocation); //"Tax_Lots_Outlines";
            }
        }


        /// <summary>
        ///     Name:
        ///         LayerLocation
        /// 
        ///     Description:
        ///         This is the location of the layer files 
        ///         It is set in CExtension at startup
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public static string LayerLocation
        {
            get
            {
                return m_sLayerLocation;
            }
            set
            {
                m_sLayerLocation = value;
            }
        }


        /// <summary>
        ///     Name:
        ///         PlanningLayers
        /// 
        ///     Description:
        ///         This is the collection of Planning Layers
        ///         It is used for the AddDataFrame tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static Dictionary<string, string> PlanningLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='Planning'", LayerSettingsLocation);  
            }
        }

        /// <summary>
        ///     Name:
        ///         EconDevLayers
        /// 
        ///     Description:
        ///         This is the collection of Economic Development Layers
        ///         It is used for the AddDataFrame tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static Dictionary<string, string> EconDevLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='EconDev'", LayerSettingsLocation); 
            }
        }


        /// <summary>
        ///     Name:
        ///         FireLayers
        /// 
        ///     Description:
        ///         This is the collection of Fire Layers
        ///         It is used for the AddDataFrame tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static Dictionary<string, string> FireLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='Fire'", LayerSettingsLocation); 
            }
        }


        /// <summary>
        ///     Name:
        ///         PoliceLayers
        /// 
        ///     Description:
        ///         This is the collection of Police Layers
        ///         It is used for the AddDataFrame tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static Dictionary<string, string> PoliceLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='Police'", LayerSettingsLocation); 
            }
        }


        /// <summary>
        ///     Name:
        ///         PublicWorksLayers
        /// 
        ///     Description:
        ///         This is the collection of Public Works Layers
        ///         It is used for the AddDataFrame tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static Dictionary<string, string> PublicWorksLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='PublicWorks'", LayerSettingsLocation);  
            }
        }

        /// <summary>
        ///     Name:
        ///         DataFrameTaxlots
        /// 
        ///     Description:
        ///         This is the 3 part name for the taxlots shapefile
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        ///  DJR
        ///      -- changed to read from Settings.xml file
        /// -----------------------------------------------------------------
        public static string DataFrameTaxlots
        {
            get
            {
                return CMedToolsSubs.returnSettingValue("Taxlots_FullName", DataSettingsLocation);  //"MEDSDE.DBO.Tax_Lots";
            }
        }


        public static Dictionary<string, string> CommonLayers
        {
            get
            {
                return CMedToolsSubs.returnConfigNode("Layer", "@type='Common'", LayerSettingsLocation);  
            }
        }


        /// <summary>
        ///     Name:
        ///         SelectedLayers
        /// 
        ///     Description:
        ///         This is the property that returns the list of 
        ///         selected layers from the AddLayers tool
        /// </summary>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public static List<string> SelectedLayers
        {
            get { return m_pCheckedLayers; }
        }

        #endregion


        /// <summary>
        ///     Name:
        ///         addLayerToList
        /// 
        ///     Description:
        ///         Adds layers to the m_pCheckedLayers variable
        /// </summary>
        /// <param name="sNewLayer">The layer tag</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public static void addLayerToList(string sNewLayer)
        {
            if (m_pCheckedLayers == null)
                m_pCheckedLayers = new List<string>();

            if (!m_pCheckedLayers.Contains(sNewLayer))
                m_pCheckedLayers.Add(sNewLayer);
        }


        /// <summary>
        ///     Name:
        ///         removeLayerFromList
        /// 
        ///     Description:
        ///         Removes layers from the m_pCheckedLayers variable
        /// </summary>
        /// <param name="sNewLayer">The layer tag</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public static void removeLayerFromList(string sRemoveLayer)
        {
            if (m_pCheckedLayers == null)
                m_pCheckedLayers = new List<string>();

            if (m_pCheckedLayers.Contains(sRemoveLayer))
                m_pCheckedLayers.Remove(sRemoveLayer);
        }

        public static bool LayerExists(string layer)
        {
            if (File.Exists(LayerLocation + layer + ".lyr"))
                return true;
            else
                return false;
        }
    }
}
