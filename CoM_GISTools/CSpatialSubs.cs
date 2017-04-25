using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Catalog;
using System.Reflection;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Display;
using CoM_GISTools.Utility;
////using MedfordToolsDAL;
using System.Data;

namespace CoM_GISTools
{
    public class CSpatialSubs : IDisposable
    {

        #region " M O D U L E   L E V E L   V A R I A B L E S "

        private bool m_bDisposed = false;

        #endregion


        #region " C O N S T R U C T O R S"

        public CSpatialSubs()
        {

        }

        #endregion


        #region " D E S T R U C T O R S "

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposeManagedResources)
        {
            if (!this.m_bDisposed)
            {
                if (disposeManagedResources)
                {
                    m_bDisposed = true;
                }
            }
        }

        #endregion


        /// <summary>
        ///     Name: 
        ///         returnEditableSDEWorkspace
        /// 
        ///     Description: 
        ///         This function returns an SDE Workspace.
        ///         It uses the MEDSDE-1\Prod instance for edits
        /// </summary>
        /// <returns>ESRI.ArcGIS.Geodatabase.IWorkspace</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ESRI.ArcGIS.Geodatabase.IWorkspace returnEditableSDEWorkspace()
        {
            try
            {
                string s = CMedToolsSubs.returnSettingValue("Editable_Server", SConst.DataSettingsLocation);

                ESRI.ArcGIS.esriSystem.IPropertySet pPropSet = new ESRI.ArcGIS.esriSystem.PropertySetClass();

                pPropSet.SetProperty("SERVER", CMedToolsSubs.returnSettingValue("Editable_Server", SConst.DataSettingsLocation));
                pPropSet.SetProperty("INSTANCE", CMedToolsSubs.returnSettingValue("Editable_Instance", SConst.DataSettingsLocation));
                pPropSet.SetProperty("DATABASE", CMedToolsSubs.returnSettingValue("Editable_Database", SConst.DataSettingsLocation));
                pPropSet.SetProperty("VERSION", CMedToolsSubs.returnSettingValue("Editable_Version", SConst.DataSettingsLocation));
                pPropSet.SetProperty("AUTHENTICATION_MODE", CMedToolsSubs.returnSettingValue("Editable_AuthMode", SConst.DataSettingsLocation));

                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
                return workspaceFactory.Open(pPropSet, 0);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        ///     Name: 
        ///         returnReadableSDEWorkspace
        /// 
        ///     Description: 
        ///         This function returns an SDE Workspace.
        ///         It uses the MEDSDE-1\Pub instance for reads
        /// </summary>
        /// <returns>ESRI.ArcGIS.Geodatabase.IWorkspace</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ESRI.ArcGIS.Geodatabase.IWorkspace returnReadableSDEWorkspace()
        {
            try
            {
                ESRI.ArcGIS.esriSystem.IPropertySet pPropSet = new ESRI.ArcGIS.esriSystem.PropertySetClass();

                pPropSet.SetProperty("SERVER", CMedToolsSubs.returnSettingValue("Readable_Server", SConst.DataSettingsLocation));
                pPropSet.SetProperty("INSTANCE", CMedToolsSubs.returnSettingValue("Readable_Instance", SConst.DataSettingsLocation));
                pPropSet.SetProperty("DATABASE", CMedToolsSubs.returnSettingValue("Readable_Database", SConst.DataSettingsLocation));
                pPropSet.SetProperty("VERSION", CMedToolsSubs.returnSettingValue("Readable_Version", SConst.DataSettingsLocation));
                pPropSet.SetProperty("AUTHENTICATION_MODE", CMedToolsSubs.returnSettingValue("Readable_AuthMode", SConst.DataSettingsLocation));

                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
                return workspaceFactory.Open(pPropSet, 0);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        ///     Name:
        ///         returnFLayerByName
        /// 
        ///     Description:
        ///         Returns a Feature Layer from the read or write database
        ///         This function searches all FeatureDatasets and FeatureClasses for 
        ///         the sFCName that is passed in, then return that Featrure Layer
        /// </summary>
        /// <param name="sFCName">The feature class name, based on the 3 part name (ie: "MEDSDE.DBO.TAXLOTS")</param>
        /// <param name="forEditing">Determines which DB to open a connection to</param>
        /// <returns>IFeatureLayer</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public IFeatureLayer returnFLayerByName(string sFCName, bool forEditing)
        {
            IFeatureLayer pRetLayer = new FeatureLayerClass();
            ESRI.ArcGIS.Geodatabase.IWorkspace pWorkSpace;

            if (forEditing == true)
                pWorkSpace = returnEditableSDEWorkspace();
            else
                pWorkSpace = returnReadableSDEWorkspace();

            if (pWorkSpace != null)
            {
                //pFeatWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)pWorkSpace;

                // get the feature classes from each dataset
                IEnumDataset enumFeatureDatasets = pWorkSpace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                enumFeatureDatasets.Reset();

                IFeatureDataset featureDataset = (IFeatureDataset)enumFeatureDatasets.Next();

                while (featureDataset != null)
                {
                    IFeatureClassContainer fcContainer = (IFeatureClassContainer)featureDataset;
                    IEnumFeatureClass enumFeatureClasses = fcContainer.Classes;

                    enumFeatureClasses.Reset();
                    IFeatureClass fc = (IFeatureClass)enumFeatureClasses.Next();
                    while (fc != null)
                    {
                        if (sFCName == fc.AliasName.ToString())
                        {
                            pRetLayer.FeatureClass = fc;
                            pRetLayer.Name = fc.AliasName;
                            break;
                        }

                        fc = (IFeatureClass)enumFeatureClasses.Next();
                    }

                    featureDataset = (IFeatureDataset)enumFeatureDatasets.Next();
                }

                IEnumDataset enumFC = pWorkSpace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                enumFC.Reset();

                IFeatureClass FC2 = (IFeatureClass)enumFC.Next();

                while (FC2 != null)
                {
                    if (sFCName == FC2.AliasName.ToString())
                    {
                        pRetLayer.FeatureClass = FC2;
                        pRetLayer.Name = FC2.AliasName;
                        break;
                    }

                    FC2 = (IFeatureClass)enumFC.Next();
                }
            }

            return pRetLayer;
        }


        /// <summary>
        ///     Name:
        ///         addFeatureLayerToMap
        /// 
        ///     Description:
        ///         Adds a feature layer to the map based on an FCName.
        ///         If bStartEditSession is true, an edit session is started.
        /// </summary>
        /// <param name="pApp">The application hook, used to get to the map document</param>
        /// <param name="sFCName">The feature class to add</param>
        /// <param name="bStartEditSession">Start edit session?</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void addFeatureLayerToMap(ESRI.ArcGIS.Framework.IApplication pApp, string sFCName, bool bStartEditSession)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            ESRI.ArcGIS.Carto.IMap pMap;
            IFeatureLayer fLayer;

            try
            {
                pMap = pMXDoc.FocusMap;

                if (bStartEditSession)
                    fLayer = returnFLayerByName(sFCName, true);
                else
                    fLayer = returnFLayerByName(sFCName, false);

                pMap.AddLayer(fLayer);
                pMXDoc.UpdateContents();
                pMXDoc.ActiveView.Refresh();

                //////fLayer = pMXDoc.SelectedLayer;
                if (bStartEditSession)
                    startEditSession(fLayer, pApp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                pMXDoc = null;
                pMap = null;
                fLayer = null;
            }
        }


        /// <summary>
        ///     Name:
        ///         startEditSession
        /// 
        ///     Description:
        ///         Starts an edit session on the feature layer that is passed in.
        /// </summary>
        /// <param name="fLayer">The feature layer to start the edit session on</param>
        /// <param name="pApp">The application hook, used to get to the map document</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void startEditSession(IFeatureLayer fLayer, ESRI.ArcGIS.Framework.IApplication pApp)
        {
            //ESRI.ArcGIS.ArcMapUI.IMxDocument pMxDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            //UID pID = new UIDClass();

            //ESRI.ArcGIS.Editor.IEditor pEditor;
            //ESRI.ArcGIS.Editor.IEditLayers pEditLayers;

            //try
            //{
            //    // first see if the toolbar is visible
            //    UID pEditorID = new UIDClass();
            //    pEditorID.Value = "{605F0528-1B64-4862-93B1-484A2C534EA3}"; // "esriEditor.EditorToolBar";
            //    ICommandBar pCmdBar = (ICommandBar)pApp.Document.CommandBars.Find(pEditorID, true, false);
            //    if (!pCmdBar.IsVisible())
            //        pCmdBar.Dock(esriDockFlags.esriDockFloat, null);

            //    pID.Value = "esriEditor.Editor";
            //    pEditor = (ESRI.ArcGIS.Editor.IEditor)pApp.FindExtensionByCLSID(pID);

            //    pEditLayers = (ESRI.ArcGIS.Editor.IEditLayers)pEditor;

            //    //IFeatureLayer pFeatureLayer = pMxDoc.FocusMap.get_Layer(0) as IFeatureLayer;
            //    IDataset pDataset = (IDataset)fLayer.FeatureClass;

            //    if (pEditor.EditState == ESRI.ArcGIS.Editor.esriEditState.esriStateNotEditing)
            //    {
            //        pEditor.StartEditing(pDataset.Workspace);
            //        pEditLayers.SetCurrentLayer(fLayer, 0);
            //    }

            //    pDataset = null;

            //}
            //catch (Exception ex)
            //{
            //    string err = "An error occurred while starting an editing session.\r\n\r\nPlease check with the GIS administrator to ensure\r\nthat you have edit priviledges on the selected layers.";
            //    err += "\r\n\r\n" + ex.Message;
            //    throw new Exception(err);
            //}
            //finally
            //{
            //    pEditor = null;
            //    pEditLayers = null;
            //    pMxDoc = null;
            //}
        }



        /// <summary>
        ///     Name:
        ///         selectLayerByName
        /// 
        ///     Description:
        ///         Makes the layer that is passed in the selectable layer.
        /// </summary>
        /// <param name="sLayerName">The layer in the Contents View to make selectable</param>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void selectLayerByName(string sLayerName, ESRI.ArcGIS.Framework.IApplication pApp)
        {
            if (sLayerName == null)
                return;

            if (pApp == null)
                return;

            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            IMap pMap = (IMap)pMXDoc.FocusMap;
            ESRI.ArcGIS.ArcMapUI.IContentsView pContView = (ESRI.ArcGIS.ArcMapUI.IContentsView)pMXDoc.CurrentContentsView;

            try
            {
                for (int iLayerIdx = 0; iLayerIdx < pMap.LayerCount; iLayerIdx++)
                {
                    if (pMap.get_Layer(iLayerIdx).Name.ToUpper() == sLayerName.ToUpper())
                    {
                        pContView.ContextItem = pMap.get_Layer(iLayerIdx);
                        pMap.get_Layer(iLayerIdx).Visible = true;
                        pMXDoc.ActiveView.Refresh();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                pMXDoc = null;
                pMap = null;
                pContView = null;
            }
        }




        /// <summary>
        ///     Name:
        ///         doesMapLayerExist
        /// 
        ///     Description:
        ///         This checks the map to see if the layer exists in the map.
        /// </summary>
        /// <param name="sLayerName">The layer to check</param>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <returns>bool</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public bool doesMapLayerExist(string sLayerName, ESRI.ArcGIS.Framework.IApplication pApp)
        {

            if (sLayerName == null)
                return false;

            if (pApp == null)
                return false;

            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            IMap pMap = (IMap)pMXDoc.FocusMap;
            try
            {
                if (pMap.LayerCount > 0)
                {
                    IEnumLayer pEnum = pMap.get_Layers(null, false);
                    ILayer pLayer = pEnum.Next();

                    do
                    {
                        IFeatureLayer pFLayer;
                        if (pLayer is IGroupLayer)
                        {
                            ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                            for (int a = 0; a < pCompositeLayer.Count - 1; a++)
                            {
                                pFLayer = (IFeatureLayer)pCompositeLayer.get_Layer(a);
                                IDataset pDs = (IDataset)pFLayer.FeatureClass;
                                if (pDs.BrowseName.ToUpper() == sLayerName.ToUpper())
                                {
                                    //bRetVal = true;
                                    return true;
                                }
                            }
                        }
                        else if (pLayer is IFeatureLayer)
                        {
                            pFLayer = (IFeatureLayer)pLayer;
                            IDataset pDs = (IDataset)pFLayer.FeatureClass;
                            if (pDs.BrowseName.ToUpper() == sLayerName.ToUpper())
                            {
                                //bRetVal = true;
                                return true;
                            }
                        }
                        pLayer = pEnum.Next();
                    }
                    while (pLayer != null);

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string sErr = ex.Message;
                sErr += " ----- bummer";
            }
            finally
            {
                pMXDoc = null;
                pMap = null;
                //pContView = null;
            }
            return false;

        }


        /// <summary>
        ///     Name:
        ///         returnCurrentProductCode
        /// 
        ///     Description:
        ///         Returns the esri product code that is currently in use by the user
        /// </summary>
        /// <returns>ESRI.ArcGIS.esriSystem.esriLicenseProductCode</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ESRI.ArcGIS.esriSystem.esriLicenseProductCode returnCurrentProductCode()
        {
            IAoInitialize pInit = new AoInitializeClass();
            return pInit.InitializedProduct();
        }


        /// <summary>
        ///     Name:
        ///         isProductAvailable
        /// 
        ///     Description:
        ///         Checks to see if a product license is available
        /// </summary>
        /// <param name="productCode">The desired ESRI product</param>
        /// <returns>ESRI.ArcGIS.esriSystem.esriLicenseStatus</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ESRI.ArcGIS.esriSystem.esriLicenseStatus isProductAvailable(ESRI.ArcGIS.esriSystem.esriLicenseProductCode esriProduct)
        {
            ESRI.ArcGIS.esriSystem.esriLicenseStatus elsRetVal;
            IAoInitialize pInit = new AoInitializeClass();

            elsRetVal = pInit.IsProductCodeAvailable(esriProduct);
            return elsRetVal;
        }


        /// <summary>
        ///     Name:
        ///         checkOutLicenses
        /// 
        ///     Description:
        ///         You need to update the registry (check out writeEditor()) to actually check out the license
        ///         This will only tell you what the status is
        /// </summary>
        /// <param name="productCode">The desired ESRI product</param>
        /// <returns>ESRI.ArcGIS.esriSystem.esriLicenseStatus</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ESRI.ArcGIS.esriSystem.esriLicenseStatus checkOutLicenses(ESRI.ArcGIS.esriSystem.esriLicenseProductCode productCode)
        {

            ESRI.ArcGIS.esriSystem.esriLicenseStatus licenseStatus;

            if (isProductAvailable(productCode) == esriLicenseStatus.esriLicenseAvailable)
            {
                IAoInitialize pInit = new AoInitializeClass();
                licenseStatus = pInit.Initialize(productCode);
            }
            else
            {
                licenseStatus = esriLicenseStatus.esriLicenseNotLicensed;
            }
            return licenseStatus;
        }


        /// <summary>
        ///     Name:
        ///         searchTaxlots
        /// 
        ///     Description:
        ///         Searches the Tax Lot database based on the search criteria passed in as
        ///         arguements. If no records are found, Null is returned to the caller. If only one
        ///         record is found, an IFeature is rerturned to the caller. If more than one record
        ///         is found, an IFeatureCursor is returned.
        ///         
        ///         This function is pretty complicated ... so, heavily commented
        /// </summary>
        /// <param name="sWhereClause">The where clause for the Queryfilter</param>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <returns>object (either an IFeature or and IFeatureCursor or null)</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public object searchTaxlots(string sWhereClause, IApplication pApp)
        {
            try
            {
                int iCount;

                //We have to use an ITableSort to ensure that multiple records are loaded into the
                //featurecursor in a sorted order
                ITableSort pTableSort;
                pTableSort = new ESRI.ArcGIS.Geodatabase.TableSort();

                //Set the query filter. use the arguements passed into the function
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = sWhereClause;

                //Get a reference to the active ArcMap document
                ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;

                //'Get a reference to the active ArcMap map within the document
                IMap pMap = pMXDoc.FocusMap;

                // In this case, this routine should always return a layer. The command button
                // which calls this function is only enabled if the taxlots layer is in the
                // current map
                IFeatureLayer pTaxlotLayer = (IFeatureLayer)returnFeatureLayer(pMap, SConst.Taxlots);

                if (pTaxlotLayer == null)
                {
                    // try again
                    pTaxlotLayer = (IFeatureLayer)returnFeatureLayer(pMap, SConst.Taxlots);
                }

                if (pTaxlotLayer == null)  //still nothing?
                {

                    // should never get here because the taxlot search tool wouldnt have been
                    // enabled without the feature class being on the map. But just in case.....
                    string msg = "The taxlots feature class could not be found.\r\n\r\n";
                    msg += "The search could not be completed. Make sure the taxlots feature class is part of the map.";

                    System.Windows.Forms.MessageBox.Show(msg, "No Search Results", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }

                //    'get a count of the number of records in the Tax Lot data that match the search criteria
                iCount = pTaxlotLayer.FeatureClass.FeatureCount(pQueryFilter);

                if (iCount == 0)
                {
                    //no records matched
                    return null;
                }
                else if (iCount == 1)
                {
                    //1 record matched; return a single IFeature
                    selectFeatures(pQueryFilter, pApp, pTaxlotLayer, true);
                    return returnSingleFeature(pTaxlotLayer.FeatureClass, pQueryFilter);
                }
                else
                {
                    selectFeatures(pQueryFilter, pApp, pTaxlotLayer, true);

                    //more than one record matched. build the table that will hold the sorted results.
                    pTableSort.Fields = "FEEOWNER";
                    pTableSort.set_Ascending("FEEOWNER", true);
                    pTableSort.set_CaseSensitive("FEEOWNER", false);
                    pTableSort.QueryFilter = pQueryFilter;
                    pTableSort.Table = (ITable)pTaxlotLayer.FeatureClass;

                    //sort the result set
                    pTableSort.Sort(null);

                    //return all the rows as an IFeatureCursor
                    return pTableSort.Rows;
                }
            }
            catch (Exception ex)
            {
                //string s = ex.Message;
                //s += " --- that was it";
            }
            return null;
        }


        /// <summary>
        ///     Name:
        ///         returnFeatureLayer
        /// 
        ///     Description:
        ///         Returns a Feature Layer from the map
        ///         This function searches layers and group layers for a layer of the input name.
        ///         If a layer name of the input name is not found, the function then
        ///         begins to search data sources for the name.
        ///         
        /// </summary>
        /// <param name="pMap">The current map</param>
        /// <param name="sName">The layer name</param>
        /// <returns>ILayer</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ILayer returnFeatureLayer(IMap pMap, string sName)
        {
            IFeatureLayer pFeatLyr;
            IDataset pDataset;
            ICompositeLayer pCLayer;
            string s = "";
            s = "Test";
            s = "This is a checkpoint1";
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name.ToUpper() == sName.ToUpper())
                {
                    return pMap.get_Layer(i);
                }
                else if (pMap.get_Layer(i) is IGroupLayer)
                {
                    //Check all the layers that maybe within a grouplayer
                    pCLayer = (ICompositeLayer)pMap.get_Layer(i);

                    for (int j = 0; j < pCLayer.Count; j++)
                    {
                        if (pCLayer.get_Layer(j).Name.ToUpper() == sName.ToUpper())
                        {
                            return pCLayer.get_Layer(j);
                        }
                    }
                }
            }

            s = "This is a checkpoint2";

            try
            {
                //couldnt find a layer name which matched, now look at feature class names
                //for a match
                for (int k = 0; k < pMap.LayerCount; k++)
                {
                    if (pMap.get_Layer(k) is IFeatureLayer)
                    {
                        pFeatLyr = (IFeatureLayer)pMap.get_Layer(k);
                        pDataset = (IDataset)pFeatLyr.FeatureClass;
                        if (pDataset != null && pDataset.Name.ToUpper() == sName.ToUpper())
                        {
                            return pFeatLyr;
                        }
                    }
                    else if (pMap.get_Layer(k) is IGroupLayer)
                    {
                        //Check all the layers that maybe within a grouplayer
                        pCLayer = (ICompositeLayer)pMap.get_Layer(k);
                        for (int n = 0; n < pCLayer.Count; n++)
                        {
                            if (pCLayer.get_Layer(n) is IFeatureLayer)
                            {
                                pFeatLyr = (IFeatureLayer)pCLayer.get_Layer(n);
                                pDataset = (IDataset)pFeatLyr.FeatureClass;
                                if (pDataset != null && pDataset.Name.ToUpper() == sName.ToUpper())
                                {
                                    return pFeatLyr;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                s = "The error is: " + ex.Message;
            }


            s = "This is a checkpoint3";


            //the only way to get here is if the layer could not be found. Return Nothing
            return null;
        }


        /// <summary>
        ///     Name:
        ///         returnFeatureLayer
        /// 
        ///     Description:
        ///         Function returns a single IFeature from the featureclass passed as an arguement. The
        ///         featureclass is filtered according to the queryfilter passed as an arguement. 
        ///         
        /// </summary>
        /// <param name="pFeatClass">The feature class to search</param>
        /// <param name="IQueryFilter">The queryfilter to search with</param>
        /// <returns>IFeature</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public IFeature returnSingleFeature(IFeatureClass pFeatClass, IQueryFilter pQueryFilter)
        {
            IFeatureCursor pFeatCur = pFeatClass.Search(pQueryFilter, false);
            return pFeatCur.NextFeature();
        }


        /// <summary>
        ///     Name:
        ///         selectFeatures
        /// 
        ///     Description:
        ///         Selects features of a given feature layer with a given queryfilter.
        ///         If bZoom, the map document will also zoom to the extent of all selected features
        ///         
        /// </summary>
        /// <param name="pQueryFilter">The queryfilter to search with</param>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <param name="pLayer">The layer upon which to select the features</param>
        /// <param name="bZoom">Boolean flag to indicate whether the map extent should be zoom to that of all selected features</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void selectFeatures(IQueryFilter pQueryFilter, IApplication pApp, IFeatureLayer pLayer, bool bZoom)
        {
            try
            {
                // first clear existing selection
                //CMedToolsSubs.clearAllSelected(pApp);

                ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;

                //// select all the features
                ISelectionSet pSelSet;

                IFeatureSelection pFeatSel = (IFeatureSelection)pLayer;
                pFeatSel.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                pFeatSel.SelectionChanged();

                pSelSet = pFeatSel.SelectionSet;

                pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

                if (bZoom)
                {
                    zoomToSelected(pApp);

                    //IEnumGeometry pEnumGeom;
                    //IEnumGeometryBind pEnumGeomBind;

                    //pEnumGeom = new EnumFeatureGeometry();
                    //pEnumGeomBind = (IEnumGeometryBind)pEnumGeom;
                    //pEnumGeomBind.BindGeometrySource(null, pSelSet);

                    //IGeometryFactory pGeomFactory = new GeometryEnvironment() as IGeometryFactory;

                    //IGeometry pGeom = pGeomFactory.CreateGeometryFromEnumerator(pEnumGeom);

                    //pMXDoc.ActiveView.Extent = pGeom.Envelope;
                    //pMXDoc.ActiveView.Refresh();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                s += "\r\n\r\n" + ex.InnerException.Message;
                s += "\r\n\r\nthat was that";

                return;
            }
        }

        /// <summary>
        ///     Name:
        ///         clearAllSelected
        /// 
        ///     Description:
        ///         Deselects all features in the map.
        ///         
        /// </summary>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void clearAllSelected(IApplication pApp)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMxDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            pMxDoc.FocusMap.ClearSelection();
            pMxDoc.ActiveView.Refresh();
        }

        /// <summary>
        ///     Name:
        ///         addLayers
        /// 
        ///     Description:
        ///         Adds layer files to the map
        ///         
        /// </summary>
        /// <param name="pApp">The application hook, used to get to the map document</param>
        /// <param name="layerLocation">The folder where the layer files are found</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void addSingleLayerToMap(ESRI.ArcGIS.Framework.IApplication pApp, string layerLocation, string sLayerName)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            ESRI.ArcGIS.Carto.IMap pMap = pMXDoc.FocusMap;

            try
            {
                ESRI.ArcGIS.Catalog.IGxLayer pGxLayer = new ESRI.ArcGIS.Catalog.GxLayer();
                ESRI.ArcGIS.Catalog.IGxFile pFile = (ESRI.ArcGIS.Catalog.IGxFile)pGxLayer;

                pFile.Path = layerLocation + sLayerName + ".lyr";

                if (!(pGxLayer.Layer == null))
                {
                    ESRI.ArcGIS.Carto.ILayer pLayer = (ESRI.ArcGIS.Carto.ILayer)pGxLayer.Layer;
                    pMap.AddLayer(pLayer);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                pMXDoc = null;
                pMap = null;
            }
        }

        /// <summary>
        ///     Name:
        ///         zoomToSelected
        /// 
        ///     Description:
        ///         Zooms to the extent of the selected features in the map
        ///         
        /// </summary>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void zoomToSelected(IApplication pApp)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;

            UID pUID = new UID();
            ICommandItem pCmdItem;

            pUID.Value = "esriArcMapUI.ZoomToSelectedCommand";
            pCmdItem = pApp.Document.CommandBars.Find(pUID, false, false);
            pCmdItem.Execute();

            pMXDoc.ActiveView.Refresh();
        }



        /// <summary>
        ///     Name:
        ///         returnValueFromSingleSelection
        /// 
        ///     Description:
        ///         Returns the attribute value of the selected record / column in a layer
        ///         
        /// </summary>
        /// <param name="sColumnName">The attribute column to get the value from</param>
        /// <param name="pApp">The application hook, used to get to\ the map document</param>
        /// <param name="sLayerName">The layer to get the attribute from</param>
        /// <returns>string</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public string returnValueFromSingleSelection(string sColumnName, IApplication pApp, string sLayerName)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMxDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            IMap pMap = (IMap)pMxDoc.FocusMap;
            IFeatureLayer pLayer;
            using (CSpatialSubs oSpatialSubs = new CSpatialSubs())
            {
                pLayer = (IFeatureLayer)oSpatialSubs.returnFeatureLayer(pMap, sLayerName);
            }

            ICursor pCurs;

            IFeatureSelection pFSel = (IFeatureSelection)pLayer;
            pFSel.SelectionSet.Search(null, true, out pCurs);

            IFeatureCursor pFCurs = (IFeatureCursor)pCurs;
            IFeature pFeat = pFCurs.NextFeature();

            return pFeat.get_Value(pFeat.Fields.FindField(sColumnName)).ToString();
        }


        /// <summary>
        ///     Name:
        ///         addLayers
        /// 
        ///     Description:
        ///         Adds layer files to the map
        ///         
        /// </summary>
        /// <param name="pApp">The application hook, used to get to the map document</param>
        /// <param name="layerLocation">The folder where the layer files are found</param>
        /// <returns></returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public void addLayers(ESRI.ArcGIS.Framework.IApplication pApp, string layerLocation)
        {
            ESRI.ArcGIS.ArcMapUI.IMxDocument pMXDoc = (ESRI.ArcGIS.ArcMapUI.IMxDocument)pApp.Document;
            ESRI.ArcGIS.Carto.IMap pMap = pMXDoc.FocusMap;

            try
            {
                foreach (string layer in SConst.SelectedLayers)
                {
                    ESRI.ArcGIS.Catalog.IGxLayer pGxLayer = new ESRI.ArcGIS.Catalog.GxLayer();
                    ESRI.ArcGIS.Catalog.IGxFile pFile = (ESRI.ArcGIS.Catalog.IGxFile)pGxLayer;

                    pFile.Path = layerLocation + layer + ".lyr";

                    if (!(pGxLayer.Layer == null))
                    {
                        ESRI.ArcGIS.Carto.ILayer pLayer = (ESRI.ArcGIS.Carto.ILayer)pGxLayer.Layer;
                        pMap.AddLayer(pLayer);
                    }
                }
                pMXDoc.UpdateContents();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                pMXDoc = null;
                pMap = null;
                SConst.SelectedLayers.Clear();
            }
        }


        /// <summary>
        ///     Name:
        ///         returnLayer
        /// 
        ///     Description:
        ///         Returns a handle to the layer in the map based on a layer file location
        ///         
        /// </summary>
        /// <param name="sLayer">The layer file to look for</param>
        /// <param name="sLayerLocation">The folder where the layer files are found</param>
        /// <returns>ILayer</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        /// 
        public ILayer returnLayer(string sLayer, string sLayerLocation)
        {
            ESRI.ArcGIS.Catalog.IGxLayer pGxLayer = new ESRI.ArcGIS.Catalog.GxLayer();
            ESRI.ArcGIS.Catalog.IGxFile pFile = (ESRI.ArcGIS.Catalog.IGxFile)pGxLayer;

            pFile.Path = sLayerLocation + sLayer;

            if (!(pGxLayer.Layer == null))
            {
                ESRI.ArcGIS.Carto.ILayer pLayer = (ESRI.ArcGIS.Carto.ILayer)pGxLayer.Layer;
                return pLayer;
            }
            else
                return null;
        }


        /// <summary>
        ///     Name:
        ///         getLayerEnvelope
        /// 
        ///     Description:
        ///         Returns an envelope of the features that satisfy
        //          whatever definition has been set for the layer
        //          projected into pSR
        ///         
        /// </summary>
        /// <param name="pDTab"></param>
        /// <param name="pSR"></param>
        /// <returns>ILayer</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        ///     DR  10/18/2007:     This is currently not used  
        ///     
        ///
        public IEnvelope getLayerEnvelope(IDisplayTable pDTab, ISpatialReference pSR)
        {

            IFeatureCursor pFCur = (IFeatureCursor)pDTab.SearchDisplayTable(null, false);
            IEnvelope pEnv = new EnvelopeClass();
            IFeature pFeat = pFCur.NextFeature();

            while (pFeat != null)
            {
                IGeometry pGeom = (IGeometry)pFeat.ShapeCopy;
                pGeom.Project(pSR);
                if (pEnv == null)
                {
                    pEnv = pGeom.Envelope;
                }
                else
                    pEnv.Union(pGeom.Envelope);
                pFeat = pFCur.NextFeature();
            }
            return pEnv;
        }


        /// <summary>
        ///     Name:
        ///         isAllowedFC
        /// 
        ///     Description:
        ///         This function goes through all feature classes and feature datasets/feature classes to
        ///         view the permissions for a given layer.
        /// 
        ///         Enumeration esriSQLPrivilege SQL Privileges 
        ///             1 - esriSelectPrivilege  - Select
        ///             2 - esriUpdatePrivilege  - Update
        ///             4 - esriInsertPrivilege  - Insert
        ///             8 - esriDeletePrivilege  - Delete
        ///         
        /// </summary>
        /// <param name="sLayer">The layer to look for the permissions for</param>
        /// <returns>bool</returns>
        /// -----------------------------------------------------------------
        /// notes/rev:
        ///     
        public bool isAllowedFC(string sLayer)
        {
            bool bRetVal = false;

            ESRI.ArcGIS.Geodatabase.IWorkspace pWorkSpace = returnEditableSDEWorkspace();

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

                IEnumDataset enumFC = pWorkSpace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                enumFC.Reset();

                IFeatureClass FC2 = (IFeatureClass)enumFC.Next();

                while (FC2 != null)
                {
                    IDataset ds = FC2 as IDataset;
                    ISQLPrivilege oFCPriv = (ISQLPrivilege)ds.FullName;

                    int iFCPriv = oFCPriv.SQLPrivileges;

                    if (iFCPriv > 1)
                    {
                        if (sLayer == FC2.AliasName.ToString())
                        {
                            bRetVal = true;
                            break;
                        }

                        FC2 = (IFeatureClass)enumFC.Next();
                    }
                }
            }
            return bRetVal;
        }


        // --------------------------
        //  DJR
        //      -- added so that we can update all prod and publication databases.
        //      -- the thinking here is that only the MEDSDE-1\MEDGISPROD SDE instance
        //          is edited, so therefore, this function will update the remaining 3 instances
        // --------------------------
        public void updateAllSDEDatabases(IFeatureClass pFC)
        {
            bool bSkip;
            string sDB = "";
            string sMsg = "";

            object name;
            object val;

            IWorkspace pFCWksp = returnWorkspace(pFC);
            pFCWksp.ConnectionProperties.GetAllProperties(out name, out val);

            IWorkspaceFactory pWkspcFac;
            IPropertySet pProps;
            IFeatureWorkspace pFWkspc;
            IFeatureClass pNewFC;

            object[] vals = val as object[];

            for (int i = 0; i <= 3; i++)
            {
                bSkip = true;
                //
                // first create the properties for the connection / workspace
                //
                pProps = new PropertySetClass();

                switch (i)
                {
                    case 0:
                        if (vals[0].ToString() + "\\" + vals[1].ToString() != "<fill in your info here>")
                        {
                            pProps.SetProperty("SERVER", "<fill in your info here>");
                            pProps.SetProperty("INSTANCE", "<fill in your info here>");
                            sDB = "<fill in your info here>";
                            bSkip = false;
                        }
                        break;
                    case 1:
                        if (vals[0].ToString() + "\\" + vals[1].ToString() != "<fill in your info here>")
                        {
                            pProps.SetProperty("SERVER", "<fill in your info here>");
                            pProps.SetProperty("INSTANCE", "<fill in your info here>");
                            sDB = "<fill in your info here>";
                            bSkip = false;
                        }
                        break;
                    case 2:
                        if (vals[0].ToString() + "\\" + vals[1].ToString() != "<fill in your info here>")
                        {
                            pProps.SetProperty("SERVER", "<fill in your info here>");
                            pProps.SetProperty("INSTANCE", "<fill in your info here>");
                            sDB = "<fill in your info here>";
                            bSkip = false;
                        }
                        break;
                    case 3:
                        if (vals[0].ToString() + "\\" + vals[1].ToString() != "<fill in your info here>")
                        {
                            //pProps.SetProperty("SERVER", "<fill in your info here>");
                            //pProps.SetProperty("INSTANCE", "<fill in your info here>");
                            //sDB = "<fill in your info here>";
                            //bSkip = false;
                        }
                        bSkip = true;
                        break;
                }

                if (!bSkip)
                {
                    pProps.SetProperty("DATABASE", CMedToolsSubs.returnSettingValue("Editable_Database", SConst.DataSettingsLocation).ToString());
                    pProps.SetProperty("USER", CMedToolsSubs.returnSettingValue("Task_User", SConst.DataSettingsLocation).ToString());
                    pProps.SetProperty("PASSWORD", CMedToolsSubs.returnSettingValue("Task_User_Pwd", SConst.DataSettingsLocation).ToString());
                    pProps.SetProperty("VERSION", CMedToolsSubs.returnSettingValue("Editable_Version", SConst.DataSettingsLocation).ToString());

                    pWkspcFac = new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
                    try
                    {
                        pFWkspc = pWkspcFac.Open(pProps, 0) as IFeatureWorkspace;
                        pNewFC = pFWkspc.OpenFeatureClass(pFC.AliasName.ToString());

                        deleteAllFeatures(pNewFC, pProps, pFWkspc);
                        insertIntoFC(pNewFC, pFC);
                        sMsg += "\r\n" + sDB + " was updated successfully.\r\n";
                    }
                    catch (Exception ex)
                    {
                        sMsg += "\r\nErrors occurred with " + sDB + ":\r\n" + ex.Message + ".\r\n";
                    }
                }
            }
            System.Windows.Forms.MessageBox.Show(sMsg);

        }


        // --------------------------
        //  DJR
        //      -- added so that we can update all prod and publication databases.
        // --------------------------
        public void deleteAllFeatures(IFeatureClass pNewFC, IPropertySet pProps, IFeatureWorkspace pFWkspc)
        {
            ITable pTbl;
            IWorkspaceEdit pWkspcEdit;

            try
            {
                pWkspcEdit = (IWorkspaceEdit)pFWkspc;
                pWkspcEdit.StartEditing(false);
                pWkspcEdit.StartEditOperation();

                IQueryFilter pQF = new QueryFilterClass();
                pQF = null;
                pTbl = pNewFC as ITable;
                if (pTbl.RowCount(null) > 0)
                    pTbl.DeleteSearchedRows(pQF);

                pWkspcEdit.StopEditOperation();
                pWkspcEdit.StopEditing(true);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors occurred: " + ex.Message, "Errors Occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pTbl = null;
                pWkspcEdit = null;
            }
        }


        // --------------------------
        //  DJR
        //      -- added so that we can update all prod and publication databases.
        // --------------------------
        public IWorkspace returnWorkspace(IFeatureClass featureClass)
        {
            IDataset dataset = featureClass as IDataset;
            IWorkspace workspace = dataset.Workspace;
            return workspace;
        }


        // --------------------------
        //  DJR
        //      -- added so that we can update all prod and publication databases.
        // --------------------------
        public void insertIntoFC(IFeatureClass pTargetFC, IFeatureClass pSourceFC)
        {
            IFeatureCursor pSourceCursor = pSourceFC.Search(null, false);
            IFeature pOldFeature = pSourceCursor.NextFeature();
            IWorkspace pWorkspace = returnWorkspace(pTargetFC);
            IWorkspaceEdit pWorkspaceEdit = (IWorkspaceEdit)pWorkspace;

            try
            {
                pWorkspaceEdit.StartEditing(false);
                pWorkspaceEdit.StartEditOperation();
                int iNewField = 0;

                while (pOldFeature != null)
                {
                    try
                    {
                        // copy a feature.
                        IFeature pNewFeature = pTargetFC.CreateFeature();
                        pNewFeature.Shape = pOldFeature.ShapeCopy;
                        for (int l = 0; l < pNewFeature.Fields.FieldCount - 1; l++)
                        {
                            IField pOldField = pOldFeature.Fields.get_Field(l);
                            iNewField = pNewFeature.Fields.FindFieldByAliasName(pOldField.AliasName);
                            if (iNewField > 0)
                            {
                                if (pNewFeature.Fields.get_Field(iNewField).Type != esriFieldType.esriFieldTypeGeometry && pNewFeature.Fields.get_Field(iNewField).Type != esriFieldType.esriFieldTypeOID && pNewFeature.Fields.get_Field(iNewField).Type != esriFieldType.esriFieldTypeBlob && pNewFeature.Fields.get_Field(iNewField).Editable)
                                {
                                    pNewFeature.set_Value(iNewField, pOldFeature.get_Value(l));
                                    iNewField = 0;
                                }
                            }
                        }
                        pNewFeature.Store(); //  ' or use the InsertCursor method
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        s += " -----";
                    }

                    pOldFeature = pSourceCursor.NextFeature();
                }
                pWorkspaceEdit.StopEditOperation();
                pWorkspaceEdit.StopEditing(true);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                pSourceCursor = null;
                pOldFeature = null;
                pWorkspace = null;
                pWorkspaceEdit = null;
            }
        }

        public bool validSave(string sFirstName, string sLastName, IFeatureClass pFC)
        {
            bool bRetVal = false;
            //using (CData oData = new CData(SConst.GISConnString))
            //{
            //    if (oData.isGISDept(sFirstName, sLastName))
            //        bRetVal = true;
            //    else
            //    {
            //        // check to see if the edit is trying to go against the SDE db
            //        // if this is an SDE DB, check to see if layer/user combo is acceptable
            //        // else ... they can edit whatever
            //        IWorkspace pWkspc = returnWorkspace(pFC);
            //        if (pWkspc.Type == esriWorkspaceType.esriRemoteDatabaseWorkspace)
            //            bRetVal = oData.isValidUserLayerCombination(sFirstName, sLastName, pFC.AliasName);
            //        else
            //            return true;
            //    }
            //}

            return bRetVal;
        }

        /// <summary>
        ///    Returns a LineSymbol of color pColor, width of intWidth, and style of intLineStyle.
        ///    LineStyle can be solid, dashed, etc. based on ArcObject linestyle enumerations.
        /// </summary>
        /// <param name="pColor"></param>
        /// <param name="dblWidth"></param>
        /// <param name="pLineStyle"></param>
        /// <returns></returns>
        /// <info>
        ///</info>
        public ILineSymbol createSimpleLineSymbol(IColor pColor, double dblWidth, esriSimpleLineStyle pLineStyle)
        {
            ISimpleLineSymbol pSym = new SimpleLineSymbolClass();
            pSym.Width = dblWidth;
            pSym.Style = pLineStyle;
            pSym.Color = pColor;

            return pSym;
        }

        /// <summary>
        /// creates a new IRGBColor object from a given input
        /// </summary>
        /// <param name="pRed">the red value</param>
        /// <param name="pGreen">the green value</param>
        /// <param name="pBlue">the blue value</param>
        /// <returns></returns>
        /// <info>
        ///</info> 
        public IColor createRGB(int pRed, int pGreen, int pBlue)
        {
            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = pRed;
            pRGB.Green = pGreen;
            pRGB.Blue = pBlue;
            pRGB.UseWindowsDithering = true;

            return pRGB;
        }

        /// <summary>
        ///    function returns an IFillSymbol object. Input arguements are color of fillsymbol, a
        ///     linesymbol that is used as the outline of the fillsymbol, and the style of the fill
        ///     symbol, i.e. hollow, solid, hatched, etc
        /// </summary>
        /// <param name="pColor"></param>
        /// <param name="pLineSymbol"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public IFillSymbol createSimpleFillSymbol(IColor pColor, ILineSymbol pLineSymbol, esriSimpleFillStyle pStyle)
        {
            ISimpleFillSymbol pSym = new SimpleFillSymbolClass();
            pSym.Color = pColor;
            if (pLineSymbol != null)
                pSym.Outline = pLineSymbol;
            pSym.Style = pStyle;

            return pSym;
        }

        /// <summary>
        ///     creates a new line on the graphics container
        /// </summary>
        /// <param name="pGC"></param>
        /// <param name="pLineSymbol"></param>
        /// <param name="dblXMin"></param>
        /// <param name="dblXMax"></param>
        /// <param name="dblYMin"></param>
        /// <param name="dblYMax"></param>
        public void addLineToGraphicsContainer(IGraphicsContainer pGC, ISimpleLineSymbol pLineSymbol, double dblXMin, double dblXMax, double dblYMin, double dblYMax)
        {
            IElement pElement = null;
            ILineElement pLineElement = new LineElementClass();
            pLineElement.Symbol = pLineSymbol;

            // Create a new line. To do that, need toPoint and fromPoint. So,
            // create two new points. Then create the line from those points.
            // Set the new line's geometry = the lineElement's geometry.
            IPolyline pPolyline = new PolylineClass();
            IPoint pToPoint = new PointClass();
            IPoint pFromPoint = new PointClass();

            pToPoint.PutCoords(dblXMin, dblYMin);
            pFromPoint.PutCoords(dblXMax, dblYMax);
            pPolyline.FromPoint = pFromPoint;
            pPolyline.ToPoint = pToPoint;

            //Set the element's geometry
            if (pPolyline != null)
            {
                pElement = pLineElement as IElement;
                pElement.Geometry = pPolyline;
            }

            //Add the line element to the graphics container
            pGC.AddElement(pElement, 0);
        }


        /// <summary>
        ///     'Returns an ITextSymbol with a color of lngR,lngG,lngB and font size dblFontSize.
        ///     'The text symbol is the symbology of a text element.
        ///     '-intHorTextAlignment is the horizontal alignment that will be applied to text
        ///     '   that contains multiple lines. There are four options: esriTHALeft(0), esriTHACenter(1),
        ///     '   esriTHARight(2), and  esriTHAFull(3). The default option is esriTHALeft.
        ///     '-intvertTextAlignment is the enumeration that defines how text is vertically aligned.
        ///     '   There are four options: esriTVATop(0), esriTVACenter(1), esriTVABaseline(2),
        ///     '   and esriTVABottom(3). esriTVABaseline is the default VerticalAlignment.
        /// </summary>
        /// <param name="lngR"></param>
        /// <param name="lngG"></param>
        /// <param name="lngB"></param>
        /// <param name="dblFontSize"></param>
        /// <param name="intHorizontalTextAlignment"></param>
        /// <param name="intVerticalTextAlignment"></param>
        /// <param name="sFontName"></param>
        /// <returns></returns>
        public ITextSymbol createTextSymbol(long lngR, long lngG, long lngB, double dblFontSize, esriTextHorizontalAlignment esriHorizontalTextAlignment, esriTextVerticalAlignment esriVerticalTextAlignment, string sFontName)
        {
            ITextSymbol pTextSym = new TextSymbolClass();

            try
            {
                stdole.IFontDisp pFontDisp = (stdole.IFontDisp)new stdole.StdFontClass();
                pFontDisp.Name = sFontName;
                pFontDisp.Size = Decimal.Parse(dblFontSize.ToString());
                pTextSym.Font = pFontDisp;
                pTextSym.Size = dblFontSize;

                //Set the Color pTextSymbol
                pTextSym.Color = createRGB(Int32.Parse(lngR.ToString()), Int32.Parse(lngG.ToString()), Int32.Parse(lngB.ToString()));

                //Set the text alignment
                pTextSym.HorizontalAlignment = esriHorizontalTextAlignment;
                pTextSym.VerticalAlignment = esriVerticalTextAlignment;
            }
            catch
            {

            }
            return pTextSym;
        }



        /// <summary>
        ///     Add a textelement to the graphicsContainer of a map. 
        ///     Returns the element that was created and added
        /// </summary>
        /// <param name="pGC"></param>
        /// <param name="pTextSym"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="sText"></param>
        /// <returns></returns>
        public ITextElement addTextToGraphicsContainer(IGraphicsContainer pGC, ITextSymbol pTextSym, double xMin, double xMax, double yMin, double yMax, string sText)
        {
            ITextElement pTextElem = new TextElementClass();
            try
            {
                pTextElem.Symbol = pTextSym;
                pTextElem.Text = sText;

                IElement pElement = (IElement)pTextElem;
                IEnvelope pEnv = new EnvelopeClass();
                pEnv.XMin = xMin;
                pEnv.XMax = xMax;
                pEnv.YMin = yMin;
                pEnv.YMax = yMax;

                pElement.Geometry = (IGeometry)pEnv;
                pGC.AddElement((IElement)pTextElem, 0);
            }
            catch { return null; }

            return pTextElem;
        }


        //public void addRectangleToGraphicsContainer(IGraphicsContainer pGC, IFillSymbol pFillSymbol, double xMin, double xMax, double yMin, double yMax)
        //{
        //    //set the rectangle = to iElement so you can control the envelope of the rectangle
        //    IRectangleElement pRect = new RectangleElementClass();
        //    IElement pElement = (IElement)pRect;
        //    IEnvelope pEnvelope = new EnvelopeClass();

        //    //Set the Rectangles envelope
        //    pEnvelope.XMin = xMin;
        //    pEnvelope.XMax = xMax;
        //    pEnvelope.YMin = yMin;
        //    pEnvelope.YMax = yMax;

        //    pElement.Geometry = pEnvelope;

        //    //Set the Rectangles symbology
        //    IFillShapeElement pRectSym = (IFillShapeElement)pRect;

        //    //Set it all into the element and add to graphic container
        //    pRectSym.Symbol = pFillSymbol;
        //    pGC.AddElement(pRect, 0);

        //}

        public void addRectangleToGraphicsContainer(IGraphicsContainer pGC, IFillSymbol pFillSym, double dblXMin, double dblXMax, double dblYMin, double dblYMax)
        {
            IRectangleElement pRect = new RectangleElementClass();

            //set the rectangle = to iElement so you can control the envelope of the rectangle
            IElement pElement = (IElement)pRect;
            IFillShapeElement pRectSym = null;

            //Set the Rectangles envelope
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = dblXMin;
            pEnv.XMax = dblXMax;
            pEnv.YMin = dblYMin;
            pEnv.YMax = dblYMax;

            pElement.Geometry = (IGeometry)pEnv;

            //Set the Rectangles symbology
            pRectSym = (IFillShapeElement)pRect;

            //Set it all into the element and add to graphic container
            pRectSym.Symbol = pFillSym;
            pGC.AddElement((IElement)pRect, 0);

        }

        /// <summary>
        /// add a bitmap image to the graphicsContainer of a map.
        /// </summary>
        /// <param name="pGC"></param>
        /// <param name="sImagePath"></param>
        /// <param name="dblXMin"></param>
        /// <param name="dblYMin"></param>
        /// <param name="dblHeight"></param>
        /// <param name="dblWidth"></param>
        public void addBitmapToGraphicsContainer(IGraphicsContainer pGC, string sImagePath, double dblXMin, double dblYMin, double dblHeight, double dblWidth)
        {
            if (!System.IO.File.Exists(sImagePath))
            {
                System.Windows.Forms.MessageBox.Show("Could not locate " + sImagePath + ".\r\nThe image will not be added to the map.", "Image not found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            IElement pElem = new BmpPictureElementClass();
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = dblXMin;
            pEnv.YMin = dblYMin;
            pEnv.Width = dblWidth;
            pEnv.Height = dblHeight;

            pElem.Geometry = pEnv as IGeometry;

            IPictureElement pPict = (IPictureElement)pElem;
            pPict.ImportPictureFromFile(sImagePath);

            pGC.AddElement(pPict as IElement, 0);


        }

        /// <summary>
        ///     Move the element to xmin,ymin based on the element's Xmin Ymin values.
        ///     To move the element, need to QI from the legend to an ITransform2D object.
        /// </summary>
        /// <param name="pElem"></param>
        /// <param name="dblXMin"></param>
        /// <param name="dblYMin"></param>
        public void moveElementToXMinYmin(IElement pElem, double dblXMin, double dblYMin)
        {
            ITransform2D pTransform2D = (ITransform2D)pElem;

            double elemXmin = pElem.Geometry.Envelope.XMin;
            double elemYmin = pElem.Geometry.Envelope.YMin;
            double deltaY = dblYMin - elemYmin;
            double deltaX = dblXMin - elemXmin;

            pTransform2D.Move(deltaX, deltaY);
        }

        public string returnMXDName(IApplication pApp)
        {
            string sRetVal = "";

            ITemplates pTemplates = pApp.Templates;
            try
            {
                int iTemplateCount = pTemplates.Count;

                sRetVal = pTemplates.get_Item(iTemplateCount - 1);
                if (sRetVal.Substring(sRetVal.Length - 4) != ".mxd")
                    sRetVal = "Untitled.mxd";
            }
            catch (Exception ex)
            {
                string sErr = ex.Message;
                sErr += " --- weee";
            }
            return sRetVal;
        }


        public bool displayLayerInLegend(string sLayerName, List<string> lstLegendLayers)
        {
            bool bRetVal = false;
            if (lstLegendLayers.Contains(sLayerName))
                bRetVal = true;
            return bRetVal;
        }

        /// <summary>
        ///     Rescale the element because it exceeds the size limits available for it.
        ///     Must QI the element to an ITransform2D object.
        /// </summary>
        /// <param name="sLayerName"></param>
        /// <param name="lbSelectedLayers"></param>
        /// <returns></returns>
        public void rescaleElement(IElement pElem, double dblMaxWidth, double dblMaxHeight)
        {
            ITransform2D pTransform2D = (ITransform2D)pElem;
            IEnvelope pEnv = pElem.Geometry.Envelope;

            //  Determine which axis must be scaled back the most by seeing which extent (height or width)
            //  more greatly exceeds their limit. Typically it should be the height.
            double dblWCur = pEnv.Width;
            double dblHCur = pEnv.Height;

            double dblWRatio = dblMaxWidth / dblWCur;
            double dblHRatio = dblMaxHeight / dblHCur;

            double dblScale = 0;
            if (dblWRatio < dblHRatio)
                dblScale = dblWRatio;
            else
                dblScale = dblHRatio;

            // Use that axis to rescale the legend. Use the lower left point as the anchor point.
            pTransform2D.Scale(pEnv.LowerLeft, dblScale, dblScale);
        }


        /// <summary>
        ///     Move the legend element up to the bottom line of the subtitle (a const value).
        ///     Legends are drawn from the lower left corner up. We have to get
        ///     the yMax value of the legend element, then move it up to where we really
        ///     want the legend to be. Center the legend between MapFrame line and neatline
        ///     To move the Legend element, need to QI from the legend to an ITrnsform2D object.
        /// </summary>
        /// <param name="pLegend"></param>
        public void moveLegend(IElement pElement, double xFactor, double yFactor, double LegendYMax, double NeatLineXMax)
        {
            ITransform2D pTransform2D = (ITransform2D)pElement;
            double dblYMax = pElement.Geometry.Envelope.YMax;
            double dblXMax = pElement.Geometry.Envelope.XMax;

            double dblDeltaY = (LegendYMax * yFactor) - dblYMax;
            double dblDeltaX = ((NeatLineXMax * xFactor) - dblXMax) / 2;

            pTransform2D.Move(dblDeltaX, dblDeltaY);

            //pTransform2D.Scale(pElement.Geometry.Envelope.LowerLeft, xFactor * 2, yFactor * 2);

        }

        public void moveElementToXY(IElement pElement, double YLoc, double XLoc)
        {
            ITransform2D pTransform2D = (ITransform2D)pElement;
            pTransform2D.Move(XLoc, YLoc);

        }

        public void refreshLegend(IElement pElement, IActiveView pAV, bool bRedraw)
        {
            IMapSurroundFrame pMSF = (IMapSurroundFrame)pElement;
            ILegend pLegend = (ILegend)pMSF.MapSurround;
            IEnvelope pNewEnv = new EnvelopeClass();

            pElement = (IElement)pMSF;

            IMapSurround pMS = pMSF.MapSurround;
            pMS.Refresh();

            pLegend.QueryBounds(pAV.ScreenDisplay, pElement.Geometry.Envelope, pNewEnv);

            //Assign the boundary to the map surround frame
            if (bRedraw)
            {
                pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
                pElement.Draw(pAV.ScreenDisplay, null);
            }

            pElement.Geometry = pNewEnv;

            bool bFit = true;

            pMS.FitToBounds(pAV.ScreenDisplay, pElement.Geometry.Envelope, out bFit);
            pMS.Refresh();
            if (bRedraw)
            {
                pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
            }
        }

        public esriPageFormID getPaperSize(string sMapSize)
        {
            //IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            //IMxApplication pMxApp = (IMxApplication)this.App;
            //IPageLayout pLayout = (IPageLayout)pMxDoc.PageLayout;
            //IPage pPage = pLayout.Page;

            esriPageFormID oRetVal = esriPageFormID.esriPageFormLetter;

            try
            {
                // set the paper size
                // ms-help://ESRI.EDNv9.2/esricarto/html/esriPageFormID.htm
                switch (sMapSize)
                {
                    case "34 x 44":
                        //pMxApp.Printer.Paper.FormID = 5; // (short)esriPageFormID.esriPageFormE;
                        //pPage.FormID = esriPageFormID.esriPageFormCUSTOM;
                        //pPage.Units = ESRI.ArcGIS.esriSystem.esriUnits.esriInches;
                        //pPage.PutCustomSize(34, 44);
                        oRetVal = esriPageFormID.esriPageFormE;
                        break;
                    case "17 x 22":
                        //pMxApp.Printer.Paper.FormID = 3; // (short)esriPageFormID.esriPageFormC;
                        oRetVal = esriPageFormID.esriPageFormC;
                        break;
                    case "11 x 17":
                        //pMxApp.Printer.Paper.FormID = 2; // (short)esriPageFormID.esriPageFormTabloid;
                        oRetVal = esriPageFormID.esriPageFormTabloid;
                        break;
                    case "8.5 x 11":
                        //pMxApp.Printer.Paper.FormID = 0; // (short)esriPageFormID.esriPageFormLetter;
                        oRetVal = esriPageFormID.esriPageFormLetter;
                        break;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: " + ex.Message);
            }
            return oRetVal;
        }

        public string GetUserFullNameDs(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("LDAP://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        public int getPaperFormID(ESRI.ArcGIS.Output.IPaper pPaper, string sPaperSize)
        {
            IEnumNamedID pEnumType = pPaper.Forms;
            pEnumType.Reset();

            string sFormName = "";

            int iFormID = 0;
            iFormID = pEnumType.Next(out sFormName);

            while (iFormID != 0)
            {
                if (sPaperSize == "34 x 44")
                {
                    if (sFormName.Contains("Oversize: ANSI E"))
                        break;
                }
                else if (sPaperSize == "17 x 22")
                {
                    if (sFormName.Contains("Oversize: ANSI C"))
                        break;
                }
                else if (sPaperSize == "11 x 17")
                {
                    if (sFormName.Contains("Oversize: ANSI B"))
                        break;
                }
                else if (sPaperSize == "8.5 x 11")
                {
                    if (sFormName.Contains("Oversize: ANSI A"))
                        break;
                }
                iFormID = pEnumType.Next(out sFormName);
            }

            return iFormID;
        }

    }
}
