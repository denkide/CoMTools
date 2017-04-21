using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ArcMap;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using CoM_GISTools.Utility;
////using MedfordToolsDAL;
using System.Data;

namespace CoM_GISTools.Print
{
    public class CPageLayout
    {

        #region Module level variables 

        ESRI.ArcGIS.Framework.IApplication m_pApp;
        double m_dblMapScale;
        string m_sMapSize;
        string m_sTitle;
        string m_sSubTitle;
        List<string> m_lstLegendLayers;
        string m_sOrientation;
        double m_dblXFactor;
        double m_dblYFactor;
        string m_sPrinterName;
        private bool m_bDisposed = false;

        #endregion


        #region Properties

        public double XFactor
        {
            get { return m_dblXFactor; }
            set { m_dblXFactor = value; }
        }

        public double YFactor
        {
            get { return m_dblYFactor; }
            set { m_dblYFactor = value; }
        }

        public ESRI.ArcGIS.Framework.IApplication App
        {
            get { return m_pApp; }
            set { m_pApp = value; }
        }

        public double MapScale
        {
            get { return m_dblMapScale; }
            set { m_dblMapScale = value; }
        }

        public string MapSize
        {
            get { return m_sMapSize; }
            set { m_sMapSize = value; }
        }

        public string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; }
        }

        public string SubTitle
        {
            get { return m_sSubTitle; }
            set { m_sSubTitle = value; }
        }

        public string Orientation
        {
            get { return m_sOrientation; }
            set { this.m_sOrientation = value; }
        }

        public List<string> LegendLayers
        {
            get { return m_lstLegendLayers; }
            set { m_lstLegendLayers = value; }
        }

        public string PrinterName
        {
            get { return m_sPrinterName; }
            set { m_sPrinterName = value; }
        }


        #endregion


        #region Constructor / Destructor 

        public CPageLayout(ESRI.ArcGIS.Framework.IApplication pApp, List<string> lstLegendLayers, Double dblMapScale, string sMapSize, string sTitle, string sSubTitle, string sOrientation, string sPrinterName)
        {
            this.App = pApp;
            this.LegendLayers = lstLegendLayers;
            this.MapScale = dblMapScale;
            this.MapSize = sMapSize;
            this.Title = sTitle;
            this.SubTitle = sSubTitle;
            this.Orientation = sOrientation;
            this.PrinterName = sPrinterName;

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            
            ///---------
            //IPageLayout pPageLayout = (IPageLayout)pMxDoc.PageLayout;
            //IActiveView pActiveView = (IActiveView)pPageLayout;
            //pActiveView.FocusMap.MapScale = dblMapScale;

            // set the active view to the layout view
            pMxDoc.ActiveView = (IActiveView)pMxDoc.PageLayout;
           
            //createLayout();

        }

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
                    this.App = null;
                }
            }
        }

        #endregion


        #region Functions that were overridden in inherited classes    

        public virtual void addTitles(string sTitle, string sSubTitle)
        {
            // use the overridden layout functions in the child classes
        }

        public virtual void addSeperatorLine()
        {
            // use the overridden layout functions in the child classes
        }

        //public virtual void doPrintSetup()
        //{
        //    // use the overridden layout functions in the child classes   
        //}
        public virtual void doPrintSetup(IPageLayout2 pPageLayout)
        {
            // use the overridden layout functions in the child classes   
        }

        /// <summary>
        /// Add the mapscale text to the Graphic Container. Places this text under the scale bar.
        /// </summary>
        /// <param name="sMapScale"></param>
        public virtual void addMapScaleText(string sMapScale)
        {

        }

        /// <summary>
        ///     Add the Date and the file name to the lower right hand corner of the map.
        /// </summary>
        public virtual void addDateName()
        {

        }

        public virtual void setConstants()
        {

        }

        /// <summary>
        ///     Adds a black rectangle in the lower right corner area just below the mapframe. The white
        ///     text CITY OF MEDFORD is added on top of this rectangle.
        /// </summary>
        public virtual void addMedfordRectangle()
        {

        }

        /// <summary>
        ///     Adds the Jackson County Disclaimer text as an ITextElement to the GraphicsContainer
        ///     of the pagelayout. The text is placed in the lower right hand corner between
        ///     the mapframe and the neatline.
        /// </summary>
        public virtual void addDisclaimer()
        {

        }

        /// <summary>
        ///     Add the SMARTMAP text as an ITextElement to the map layout. Place the text on top
        ///     off the black rectangle that was placed in the lower right hand corner between
        ///     the mapframe and the neatline.
        /// </summary>
        public virtual void addMedfordText()
        {

        }


        #endregion


        #region Public functions

        public virtual void createLayout()
        {
            //IMxDocument pDoc = (IMxDocument)this.App.Document;


            //// get a reference to the page layout object
            //IPageLayout2 pPageLayout = (IPageLayout2)pDoc.PageLayout;
            //if (this.Orientation == SPrintConst.Orientation.Landscape.ToString())
            //{
            //    doPrintSetup(pPageLayout);
            //}
            //else if (this.Orientation == SPrintConst.Orientation.Portrait.ToString())
            //{
            //    doPrintSetup(pPageLayout);
            //}
        }

        public virtual void setPrinter(string sPrinterName)
        {
            //IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            //IMxApplication pMxApp = (IMxApplication)this.App;
            //ESRI.ArcGIS.esriSystem.IClone pClone = (ESRI.ArcGIS.esriSystem.IClone)pMxApp.Printer;

            //IPrinter pPrinter = (IPrinter)pClone.Clone();
            //pPrinter.Paper.PrinterName = sPrinterName;

            //IPaper pPaper = pPrinter.Paper;
            //pPaper.FormID = (short)getPaperSize();

            //pMxDoc.ActiveView.PrinterChanged(pPrinter);

            //IPage pPage = pMxDoc.PageLayout.Page;
            //pPage.FormID = getPaperSize();

            //pPage.PrinterChanged(pPrinter);
            
            ////IMxApplication pMxApp = (IMxApplication)this.App;
            ////IPaper pPaper = pMxApp.Paper;

        }


        public virtual void adjustMapFrame()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IPageLayout pPageLayout = (IPageLayout)pMxDoc.PageLayout;
            IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)pPageLayout;

            //if (!typeof(pMxDoc.ActiveView) is IPageLayout)
            //{
            //    pMxDoc.ActiveView = (IActiveView)pMxDoc.PageLayout;
            //}

            //IActiveView pActiveView = (IActiveView)pMxDoc.ActiveView;
            IActiveView pActiveView = (IActiveView)pPageLayout;

            IEnvelope pEnvelope = null;
            IMapFrame pMapFrame = null;
            IMap pMap = (IMap)pMxDoc.FocusMap;
            
            doPrintSetup((IPageLayout2 )pPageLayout);

            //doPrintSetup();

            // change scale
            //if (this.MapScale != pMap.MapScale)
            //    pActiveView.FocusMap.MapScale = this.MapScale;

                //pMap.MapScale = this.MapScale;

            pMxDoc.ActiveView.Refresh();

            try
            {
                pGraphicsContainer.Reset();
                IElement pElement = pGraphicsContainer.Next();

                while (pElement != null)
                {
                    if (pElement is IMapFrame)
                    {
                        pEnvelope = new EnvelopeClass();
                        pEnvelope.XMin = this.XFactor * SPrintConst.Neatline_XMin; //SPrintConst.MapFrame_XMin; // c_dblMapFrame_XMin;
                        pEnvelope.XMax = this.XFactor * SPrintConst.MapFrame_XMax; // c_dblMapFrame_XMax;
                        pEnvelope.YMin = this.YFactor * SPrintConst.MapFrame_YMin; // c_dblMapFrame__YMin;
                        pEnvelope.YMax = this.YFactor * SPrintConst.MapFrame_YMax; // c_dblMapFrame__YMax;

                        pElement.Geometry = pEnvelope;
                        pMapFrame = (IMapFrame)pElement;

                        // change scale
                        //pMapFrame.ExtentType = esriExtentTypeEnum.esriExtentScale;
                        //pMapFrame.MapScale = this.MapScale;
                        
                    }
                    pElement = pGraphicsContainer.Next();
                }
                pActiveView = (IActiveView)pMxDoc.FocusMap;
                pActiveView.Refresh();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:adjustMapFrame()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pMxDoc = null;
                pPageLayout = null;
                pGraphicsContainer = null;
                pActiveView = null;
                pEnvelope = null;
                pMapFrame = null;
            }
        }

        public virtual void refreshLayout()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            pMxDoc.ActiveView.Refresh();
        }

        /// <summary>
        ///  Add a NeatLine as a hollow rectangle to the map. Dimensions of the neatline are determined by
        ///  constants set in General Declaration area and a multiplication factor
        ///  determined by the size of the map.
        /// </summary>
        public virtual void addNeatline()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IGraphicsContainer pGraphicsContatiner = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ILineSymbol pLineSymbol = oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (2 * this.XFactor), esriSimpleLineStyle.esriSLSSolid);
                ISimpleFillSymbol pFillSymbol = (ISimpleFillSymbol)oSpatialSubs.createSimpleFillSymbol(oSpatialSubs.createRGB(0, 0, 0), pLineSymbol, esriSimpleFillStyle.esriSFSHollow);

                oSpatialSubs.addRectangleToGraphicsContainer(pGraphicsContatiner,
                                                                pFillSymbol,
                                                                (this.XFactor * SPrintConst.Neatline_XMin),
                                                                (this.XFactor * SPrintConst.Neatline_XMax),
                                                                (this.YFactor * SPrintConst.Neatline_YMin),
                                                                (this.YFactor * SPrintConst.Neatline_YMax));

                pLineSymbol = null;
                pFillSymbol = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addNeatline()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGraphicsContatiner = null;
            }
        }

        public virtual void deleteMapSurrounds()
        {
            IMapSurroundFrame pMapSurroundFrame = null;
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IPageLayout pPageLayout = (IPageLayout)pMxDoc.PageLayout;
            IActiveView pActiveView = (IActiveView)pMxDoc.ActiveView;
            IGraphicsContainer pGraphContainer = (IGraphicsContainer)pPageLayout;

            try
            {
                pGraphContainer.Reset();

                // cannot use DeleteAllElements since that will also delete the map
                //pGraphContainer.DeleteAllElements();

                IElement pElement = pGraphContainer.Next();
                IElementCollection pElementCollection = new ElementCollectionClass();

                int iLinkedFeatureID = 0;

                // add all the elements to a graphic elements collection
                while (pElement != null)
                {
                    if (pElement is IMapSurround)
                    {
                        pMapSurroundFrame = (IMapSurroundFrame)pElement;
                    }
                    else if (pElement is IMapSurroundFrame)
                    {
                        pElementCollection.Add(pElement, iLinkedFeatureID);
                    }
                    else if (pElement is IRectangleElement || pElement is ITextElement || pElement is ILineElement || pElement is IPictureElement || pElement is IScaleBar)
                    {
                        pElementCollection.Add(pElement, iLinkedFeatureID);
                    }
                    pElement = pGraphContainer.Next();
                }

                // delete the elements in the collection
                for (int i = 0; i < pElementCollection.Count; i++)
                {
                    pElementCollection.QueryItem(i, out pElement, out iLinkedFeatureID);
                    pGraphContainer.DeleteElement(pElement);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:deleteMapSurrounds()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pMapSurroundFrame = null;
                pMxDoc = null;
                pPageLayout = null;
                pActiveView = null;
                pGraphContainer = null;
            }
        }


        public virtual void addScaleBar()
        {
            //string sMapScale = this.MapScale.ToString();

            string sMapScale = setNewMapScale();
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            
            IMapFrame pMapFrame = null;
            IScaleBar pScaleBar = null;
            IScaleLine pScaleLine = null;
            IMapSurround pMS = null;
            IMapSurroundFrame pMSFrame = null;
            IEnvelope pEnv = null;

            try
            {
                pGC.Reset();

                IElement pElem = pGC.Next();
                while (pElem != null)
                {
                    pMapFrame = null;
                    if (pElem is IMapFrame)
                    {
                        pMapFrame = (IMapFrame)pElem;
                        if (pMapFrame.Map == pMxDoc.FocusMap) break;
                    }
                    pElem = (IElement)pGC.Next();
                }

                // create the scalebar object
                pScaleBar = new ScaleLineClass(); // DoubleAlternatingScaleBarClass();
                pScaleBar.BarColor = oSpatialSubs.createRGB(108, 108, 108);
                pScaleBar.BarHeight = 6 * this.YFactor;
                pScaleBar.Divisions = 4;
                pScaleBar.DivisionsBeforeZero = 0;
                pScaleBar.Map = pMapFrame.Map;
                pScaleBar.Units = ESRI.ArcGIS.esriSystem.esriUnits.esriMiles;
                pScaleBar.Subdivisions = 4;
                pScaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisions;
                pScaleBar.LabelPosition = esriVertPosEnum.esriAbove;
                pScaleBar.LabelSymbol = oSpatialSubs.createTextSymbol(108, 108, 108, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                pScaleBar.LabelGap = 4 * this.YFactor;
                pScaleBar.UnitLabelSymbol = oSpatialSubs.createTextSymbol(108, 108, 108, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                pScaleBar.UnitLabelGap = 7 * this.YFactor;
                pScaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarBelow;
                pScaleBar.Refresh();

                /*
                pScaleBar.Map = pMapFrame.Map;
                pScaleBar.Units = ESRI.ArcGIS.esriSystem.esriUnits.esriMiles;
                pScaleBar.Subdivisions = 3;
                pScaleBar.DivisionsBeforeZero = 0;
                pScaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisions;
                pScaleBar.LabelPosition = esriVertPosEnum.esriAbove;
                pScaleBar.LabelSymbol = oSpatialSubs.createTextSymbol(108, 108, 108, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                pScaleBar.LabelGap = 4 * this.YFactor;
                pScaleBar.UnitLabelSymbol = oSpatialSubs.createTextSymbol(108, 108, 108, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                pScaleBar.UnitLabelGap = 7 * this.YFactor;
                pScaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarBelow;
                pScaleBar.Refresh();
                 */
                pMS = (IMapSurround)pScaleBar;

                //Create surround frame for scalebar, then place the scalebar into the frame
                pMSFrame = new MapSurroundFrameClass();
                pMSFrame.MapFrame = pMapFrame;
                pMSFrame.MapSurround = pMS;

                //Set the map surround frame size and position
                pEnv = new EnvelopeClass();
                pEnv.XMin = SPrintConst.Scalebar_XMin * this.XFactor;
                pEnv.XMax = SPrintConst.Scalebar_XMax * this.XFactor;
                pEnv.YMin = SPrintConst.Scalebar_YMin * this.YFactor;
                pEnv.YMax = SPrintConst.Scalebar_YMax * this.YFactor;

                pElem = (IElement)pMSFrame;
                pElem.Geometry = (IGeometry)pEnv;

                //Add to graphics container
                pGC.AddElement((IElement)pMSFrame, 0);

                //manually force the scalebar to fit within desired bounds; get actual size of it
                IEnvelope pScalebarEnv = pElem.Geometry.Envelope;

                //Determine which axis must be scaled back the most
                double dblCurrentWidth = pScalebarEnv.Width;
                double dblCurrentHeight = pScalebarEnv.Height;

                double dblNewWidth = (SPrintConst.Scalebar_XMax * this.XFactor) - (SPrintConst.Scalebar_XMin * this.XFactor);
                double dblNewHeight = (SPrintConst.Scalebar_YMax * this.YFactor) - (SPrintConst.Scalebar_YMin * this.YFactor);

                double dblWidthRatio = dblNewWidth / dblCurrentWidth;
                double dblHeightRatio = dblNewHeight / dblCurrentHeight;

                double dblScale = 0;
                if (dblWidthRatio < dblHeightRatio)
                    dblScale = dblWidthRatio;
                else
                    dblScale = dblHeightRatio;

                //Use the center point of the scalebar to resize it
                ITransform2D pTrans2D = (ITransform2D)pElem;
                IArea pArea = (IArea)pElem.Geometry;
                IPoint pPoint = pArea.Centroid;

                pTrans2D.Scale(pPoint, dblScale, dblScale);

                //now that the scale bar is in place, add the mapscale text just beneath it
                //addMapScaleText(sMapScale);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addScaleBar()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
                pMapFrame = null;
                pScaleBar = null;
                pScaleLine = null;
                pMS = null;
                pMSFrame = null;
                pEnv = null;
            }
        }


  
        /// <summary>
        ///     Add the Medford GIS text to the page layout. The text is added as an ITextElement.
        ///     The text is placed beneath the "City of Medford" logo between the Mapframe and the Neatline.
        /// </summary>
        public void addMedGISText(double dblXMin, double dblXMax, double dblYMin,double dblYMax)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try 
            {    
                ITextSymbol pTextSym = (ITextSymbol)oSpatialSubs.createTextSymbol(108, 108, 108, (5 * this.XFactor), esriTextHorizontalAlignment.esriTHACenter, esriTextVerticalAlignment.esriTVATop, "Arial");
                string sText = "GEOGRAPHIC INFORMATION SYSTEMS";

                ITextElement pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sText);

                pTextSym = null;
                pTextElem = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addMedGISText()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally 
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }



        /// <summary>
        ///     Adds the Jackson County Disclaimer text as an ITextElement to the GraphicsContainer
        ///     of the pagelayout. The text is placed in the lower right hand corner between
        ///     the mapframe and the neatline.
        /// </summary>
        public virtual void addDisclaimer(double dblXMin, double dblXMax, double dblYMin, double dblYMax)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ITextSymbol pTextSym = oSpatialSubs.createTextSymbol(124, 124, 124, (2.9 * this.XFactor), esriTextHorizontalAlignment.esriTHACenter, esriTextVerticalAlignment.esriTVACenter, "Arial");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("The Geographic Information Systems (GIS) data made available on this map");
                sb.AppendLine("are developed and maintained by the City of Medford and Jackson County.");
                sb.AppendLine("GIS data is not the official representation of any of the information ");
                sb.AppendLine("included. The maps and data are made available to the public solely for");
                sb.AppendLine("informational purposes.");
                sb.AppendLine("");
                sb.AppendLine("THERE MAY BE ERRORS IN THE MAPS OR DATA. THE MAPS OR DATA MAY BE ");
                sb.AppendLine("OUTDATED, INACCURATE, AND MAY OMIT IMPORTANT INFORMATION. THE ");
                sb.AppendLine("ENTIRE RISK AS TO THE QUALITY OR PERFORMANCE IS WITH THE BUYER OR");
                sb.AppendLine("USER AND IF INFORMATION IS DEFECTIVE, THE BUYER OR USER ASSUMES");
                sb.AppendLine("THE ENTIRE COST OF ANY NECESSARY CORRECTIONS OR SERVICING.");
                sb.AppendLine("");
                sb.AppendLine("NO GUARANTEE OR WARRANTY IS EXPRESSED OR IMPLIED IN TERMS");
                sb.AppendLine("OF DATA ACCURACY OR LEGITIMACY.");

                ITextElement pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC,
                                                                                pTextSym,
                                                                                dblXMin, dblXMax, dblYMin, dblYMax, sb.ToString());

                pTextSym = null;
                pTextElem = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addDisclaimer()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }

        }


        /// <summary>
        ///     Add the Recycling image and text to the lower left hand corner of the map.
        ///     to locate the image and text, use the constants defined below
        /// </summary>
        public virtual void addRecyclingInfo()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            ITextSymbol pTextSym = null;
            ITextElement pTextElem = null;

            try
            {
                pTextSym = (ITextSymbol)oSpatialSubs.createTextSymbol(0, 0, 0, (5 * this.YFactor), esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVACenter, "Arial");

                double dblWidth = 0; double dblHeight = 0; double dblXMin = 0; double dblXMax = 0; double dblYMin = 0; double dblYMax = 0;

                //get the recycling symbol if it exists and add it to the map's grpahics container
                if (File.Exists(SPrintConst.Recycle_ImagePath))
                {
                    dblXMin = this.XFactor * SPrintConst.Neatline_XMin;
                    dblYMin = this.YFactor * SPrintConst.Recycle_YMin;
                    dblWidth = this.XFactor * SPrintConst.Recycle_HeightWidth;
                    dblHeight = this.YFactor * SPrintConst.Recycle_HeightWidth;

                    oSpatialSubs.addBitmapToGraphicsContainer(pGC, SPrintConst.Recycle_ImagePath, dblXMin, dblYMin, dblHeight, dblWidth);

                    //now that we have added the image, adjust the X value for the recycling text
                    dblXMin = (this.XFactor * SPrintConst.Neatline_XMin) + dblWidth;
                }
                else
                {
                    dblXMin = (this.XFactor * SPrintConst.Neatline_XMin);
                }

                dblXMax = (2 * this.XFactor) + dblWidth;   //1.878
                dblYMin = 0.232 * this.YFactor;
                dblYMax = this.YFactor * (SPrintConst.Neatline_YMin - SPrintConst.NameDate_Offset);

                string sText = "Please recycle with colored office grade paper";

                pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sText);
                oSpatialSubs.moveElementToXMinYmin(pTextElem as IElement, dblXMin, dblYMin);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addRecyclingInfo()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
                pTextSym = null;
                pTextElem = null;
            }
        }



        /// <summary>
        ///     Add the Jackson County GIS logo as a BmpPictureElement to the map.
        ///     Location of logo is determined from constants set below. Uses a function
        ///     to add the bitmap defined in the utilities class CLayoutUtils
        /// </summary>
        public virtual void addLogo()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                oSpatialSubs.addBitmapToGraphicsContainer(pGC,
                                                          SPrintConst.Logo_Image,
                                                          SPrintConst.Logo_XMin * this.XFactor,
                                                          SPrintConst.Logo_YMin * this.YFactor,
                                                          SPrintConst.Logo_Height * this.YFactor,
                                                          SPrintConst.Logo_Width * this.XFactor);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addLogo()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }

        /// <summary>
        ///     adds North Arrow to active map, but its not easy.
        ///     First you need to set north arrow symbology. You do that by creating a
        ///     MarkerNorthArrow. Second, you need to set the North Arrow as a MapSurround.
        ///     Third, set the envelope of the MapSurroundFrame which holds the MapSurround.
        ///     Finally add the MapSurround to the map.
    
        ///     MapSurrounds are held in a MapSurroundFrame
        ///     MapSurroundFrames are related to MapFrames
        ///     MapFrames hold Maps
        /// </summary>
        public virtual void addNorthArrow()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            IMapFrame pMapFrame = null;
            IMapSurroundFrame pMSFrame = null;
            IMarkerNorthArrow pMarkerNorthArrow = null;
            ICharacterMarkerSymbol pCharacterMarkerSymbol = null;
            INorthArrow pNorthArrow = null;
            IMapSurround pMS = null;
            IEnvelope pEnv = null;

            try
            {
                // set the MarkerNorthArrow symbology through an ICharacterMarkerSymbol
                pMarkerNorthArrow = new MarkerNorthArrowClass();
                pCharacterMarkerSymbol = (ICharacterMarkerSymbol)pMarkerNorthArrow.MarkerSymbol; // clone the symbol
                pCharacterMarkerSymbol.CharacterIndex = Int32.Parse(SPrintConst.NorthArrow_Character.ToString());  // set the symbol
                pCharacterMarkerSymbol.Size = SPrintConst.NorthArrow_Size * this.YFactor;
                pCharacterMarkerSymbol.Color = oSpatialSubs.createRGB(124, 124, 124);
                pMarkerNorthArrow.MarkerSymbol = pCharacterMarkerSymbol;  // set it back.

                // set the NorthArrow = the MarkerNorthArrow and then make the NorthArrow a MapSurround
                pNorthArrow = (INorthArrow)pMarkerNorthArrow;  // QI
                pNorthArrow.Map = pMxDoc.FocusMap;
                pMS = (IMapSurround)pNorthArrow;

                // get the mapframe of the current map
                pGC.Reset();
                IElement pElement = pGC.Next();
                while (pElement != null)
                {
                    if (pElement is IMapFrame)
                    {
                        pMapFrame = (IMapFrame)pElement;
                        break;
                    }
                    pElement = pGC.Next();
                }

                // Create surround frame for North Arrow
                pMSFrame = new MapSurroundFrameClass();
                pMSFrame.MapFrame = pMapFrame;
                pMSFrame.MapSurround = pMS;

                // Set the map surround frame size and position
                pEnv = new EnvelopeClass();
                pEnv.XMax = this.XFactor * SPrintConst.Neatline_XMax;
                pEnv.YMax = this.YFactor * SPrintConst.NorthArrow_YMax;
                pEnv.XMin = this.XFactor * SPrintConst.NorthArrow_XMin;
                pEnv.YMin = this.YFactor * SPrintConst.NorthArrow_YMin;
                pEnv.Height = this.YFactor * SPrintConst.NorthArrow_Height;
                pEnv.Width = this.XFactor * SPrintConst.NorthArrow_Width;
                pElement = (IElement)pMSFrame;
                pElement.Geometry = (IGeometry)pEnv;

                // add it to the graphics container
                pGC.AddElement(pMSFrame as IElement, 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addNorthArrow()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
                pMapFrame = null;
                pMSFrame = null;
                pMarkerNorthArrow = null;
                pCharacterMarkerSymbol = null;
                pNorthArrow = null;
                pMS = null;
                pEnv = null;
            }
        }

        /// <summary>
        ///     Add the Date and the file name to the lower right hand corner of the map.
        /// </summary>
        public virtual void addDateName(double dblXMin, double dblXMax, double dblYMin, double dblYMax)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ITextSymbol pTextSym = oSpatialSubs.createTextSymbol(0, 0, 0,
                                                                    (5 * this.YFactor),
                                                                    esriTextHorizontalAlignment.esriTHARight,
                                                                    esriTextVerticalAlignment.esriTVABottom,
                                                                    "Arial");
                DateTime dt = DateTime.Now;
                string sText = "Plot Date: " + dt.ToString("d") + "; " + oSpatialSubs.returnMXDName(this.App);
                ITextElement pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC,
                                                                                 pTextSym,
                                                                                 dblXMin, dblXMax, dblYMin, dblYMax,
                                                                                 sText);
                oSpatialSubs.moveElementToXMinYmin(pTextElem as IElement,
                                                    dblXMax,
                                                    0.232 * this.YFactor); //this.YFactor * (SPrintConst.Neatline_YMin - SPrintConst.NameDate_Offset)); //dblYMax - (.09 * this.YFactor));

                pTextSym = null;
                pTextElem = null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addDateName()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }

        ///// <summary>
        /////     Add a Legend to the map. Dimensions of the Legend are determined by
        /////     constants set in here and a multiplication factor
        /////     determined by the size of the map.
        /////     After adding the Legend, routine verifies that the legend will fit into the
        /////     alotted space. If the legend is too big, the legend will be resized.
        ///// </summary>
        public virtual void addLegend()
        {
            if (this.LegendLayers.Count < 1) return;

            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = null;

            try
            {
                double xMin = 0; double xMax = 0; double yMin = 0; double yMax = 0;

                xMin = SPrintConst.Legend_XMin * this.XFactor;              // 8.8;
                yMin = SPrintConst.Legend_YMin * this.YFactor;              //SPrintConst.Scalebar_YMax * this.YFactor;  // 2.7; //'4.7
                xMax = xMin + (SPrintConst.Legend_Width * this.XFactor);    //(7 * this.XFactor);  // 10.7;
                yMax = yMin + (SPrintConst.Legend_Height * this.YFactor);   // +(SPrintConst.Legend_Height * this.YFactor);   //(5 * this.YFactor); // 8.2;

                pGC = (IGraphicsContainer)pMxDoc.PageLayout;
                pGC.Reset();

                IElement pElement = pGC.Next();

                // Create initial envelope for legend
                IEnvelope pEnv = new EnvelopeClass();
                pEnv.PutCoords(xMin, yMin, xMax, yMax);

                // Create a map surround for the focus map and a new legend for it
                IMapSurroundFrame pMapSurroundFrame = null;
                IMapFrame pMapFrame = null;
                pMapFrame = (IMapFrame)pGC.FindFrame(pMxDoc.FocusMap);

                IMapSurround pMapSurround = new LegendClass_2(); // LegendClassClass Legend
                pMapSurround.Map = (IMap)pMapFrame.Map;

                ILegend pLegend = (ILegend)pMapSurround;
                ILegendItem pLegendItem = null;

                pLegend.Format.ShowTitle = false;
                pMapSurround.Refresh();

                // remove unneeded layers
                for (int i = 0; i < pLegend.ItemCount; i++)
                {
                    pLegendItem = pLegend.get_Item(i);

                    // check to see if the layer should be visible in the map's legend
                    // if it is not in the list remove it.
                    if (!this.LegendLayers.Contains(pLegendItem.Layer.Name))
                    {
                        pLegend.RemoveItem(i);
                        i = 0;  // note: set i back to 0 .. the layers get renumbered when one is removed.
                    }
                }

                //Create the frame container and set the size
                pMapSurroundFrame = new MapSurroundFrameClass();
                pMapSurroundFrame.MapFrame = (IMapFrame)pMapFrame;
                pMapSurroundFrame.MapSurround = (IMapSurround)pMapSurround;
                pMapSurroundFrame.DraftMode = false;

                // Set the geometry of the element
                IGeometry pGeometry = new PolygonClass();
                pElement = (IElement)pMapSurroundFrame;

                pGeometry = (IGeometry)pEnv;
                pElement.Geometry = pGeometry;
                IElementProperties pElementProps = (IElementProperties)pElement;
                pElementProps.Name = ""; //Legend

                // Add it to the layout
                pGC.AddElement(pElement, 0);
                pMapSurround.DelayEvents(false);                

                // now pretty the legend up.
                // add the background
                ISymbolBackground pSymBg = new SymbolBackgroundClass();
                //pSymBg.FillSymbol = oSpatialSubs.createSimpleFillSymbol(oSpatialSubs.createRGB(255, 255, 228) as IColor,
                //                                                        oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0) as IColor, 1, ESRI.ArcGIS.Display.esriSimpleLineStyle.esriSLSSolid) as ILineSymbol,
                //                                                        esriSimpleFillStyle.esriSFSSolid);

                if (this.Orientation.ToString() == SPrintConst.Orientation.Landscape.ToString())
                {
                    pSymBg.FillSymbol = oSpatialSubs.createSimpleFillSymbol(oSpatialSubs.createRGB(255, 255, 255) as IColor,
                                                                            oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(255, 255, 255) as IColor, 3, ESRI.ArcGIS.Display.esriSimpleLineStyle.esriSLSSolid) as ILineSymbol,
                                                                            esriSimpleFillStyle.esriSFSSolid);
                }
                else
                {
                    pSymBg.FillSymbol = oSpatialSubs.createSimpleFillSymbol(oSpatialSubs.createRGB(238, 238, 238) as IColor,
                                                                            oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(238, 238, 238) as IColor, 3, ESRI.ArcGIS.Display.esriSimpleLineStyle.esriSLSSolid) as ILineSymbol,
                                                                            esriSimpleFillStyle.esriSFSSolid);
                }
                pMapSurroundFrame.Background = (IBackground)pSymBg;

                //for improved aesthetics of the legend.
                // each Legend item (map layer) will have font size 11.
                // each Class within a Legend Item group will have font size 10.
                ILegendInfo pLegendInfo = null;
                IGeoFeatureLayer pGFL = null;

                //for each item (map layer) in the legend, set the fontsize = 11
                // Work our way backwards in the for loop because we may be removing
                // items from the legend which would screw up our indexing count if
                // we were going from smallest count to largest count.
                for (int iCount = 0; iCount < pLegend.ItemCount; iCount++)
                {
                    pLegendItem = pLegend.get_Item(iCount);
                    // if its a feature layer, edit the legend fonts. Otherwise, accept
                    //  the default fonts for the legend.
                    if (pLegendItem.Layer is IFeatureLayer)
                    {
                        pGFL = (IGeoFeatureLayer)pLegendItem.Layer;
                        pLegendInfo = (ILegendInfo)pGFL.Renderer;

                        //Get the class count for each group
                        for (int iGroup = 0; iGroup < pLegendInfo.LegendGroupCount; iGroup++)
                        {
                            // for each class in a legend group, set fontsize = 10
                            pLegend.get_Item(iCount).LayerNameSymbol = oSpatialSubs.createTextSymbol(166, 166, 166, 11 * this.YFactor, 0, 0, "Arial");
                            pLegend.get_Item(iCount).ShowLayerName = true;
                            pLegend.get_Item(iCount).LegendClassFormat.LabelSymbol = oSpatialSubs.createTextSymbol(166, 166, 166, 10 * this.YFactor, 0, 0, "Times New Roman");
                            pLegend.get_Item(iCount).HeadingSymbol = oSpatialSubs.createTextSymbol(166, 166, 166, 10 * this.YFactor, 0, 0, "Times New Roman");
                        }
                    }
                }

                //legend has expanded beyond desired bounds; get actual size of it
                IEnvelope pLegEnv = pElement.Geometry.Envelope;

                //Determine which axis must be scaled back the most
                double wCur = 0;
                double hCur = 0;
                wCur = pLegEnv.Width;
                hCur = pLegEnv.Height;

                double wNew = 0;
                double hNew = 0;
                wNew = xMax - xMin;
                hNew = yMax - yMin;

                double wRatio = 0;
                double hRatio = 0;
                wRatio = wNew / wCur;
                hRatio = hNew / hCur;

                double dblScale = 0;
                if (wRatio < hRatio)
                    dblScale = wRatio;
                else
                    dblScale = hRatio;

                double pLegTop = 0;
                pLegTop = yMax;

                //Use that axis to rescale the legend
                ITransform2D pTrans2D = (ITransform2D)pElement;

                pTrans2D.Scale(pElement.Geometry.Envelope.LowerLeft, wRatio, hRatio);
                //pTrans2D.Move( 0, pLegTop - pElement.Geometry.Envelope.YMax);
                
                pGC.UpdateElement(pElement);
                pMxDoc.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addLegend()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }


        public virtual void unselectAllGraphics()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainerSelect pGCS = (IGraphicsContainerSelect)pMxDoc.PageLayout;
            pGCS.UnselectAllElements();

        }

        public virtual void addUserName()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ITextSymbol pTextSym = oSpatialSubs.createTextSymbol(124, 124, 124,
                                    (5 * this.YFactor),
                                    esriTextHorizontalAlignment.esriTHARight,
                                    esriTextVerticalAlignment.esriTVABottom,
                                    "Arial");

                string sText = "Map made by " + CMedToolsSubs.getObjectProperty(System.Windows.Forms.SystemInformation.UserName, "givenName") + " " + CMedToolsSubs.getObjectProperty(System.Windows.Forms.SystemInformation.UserName, "SN");

                ITextElement pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC,
                                         pTextSym,
                                         (SPrintConst.Name_XMin * this.XFactor), (SPrintConst.Name_XMax) * this.XFactor, (SPrintConst.Name_YMin) * this.YFactor, (SPrintConst.Name_YMax) * this.YFactor,
                                         sText);

                pTextSym = null;
                pTextElem = null;
                //oSpatialSubs.moveElementToXMinYmin(pTextElem as IElement,
                //            SPrintConst.Name_XMin,
                //            SPrintConst.Name_YMin); //this.YFactor * (SPrintConst.Neatline_YMin - SPrintConst.NameDate_Offset)); //dblYMax - (.09 * this.YFactor));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:addDateName()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }

        }

        #endregion


        #region Private functions

        private string setNewMapScale()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IMap pMap = (IMap)pMxDoc.FocusMap;
            
            double dblMapScale = this.MapScale;
            //double dblCurrentMapScale = 0;
            string sCurrentScaleMsg = "";
            double dblNewMapScale = 0;
            double dblCurrentScale = 0;

            try
            {
                dblCurrentScale = Math.Round(dblMapScale);
                if (System.Windows.Forms.MessageBox.Show("The current map scale is " + dblCurrentScale.ToString("0,0") + "\r\nDo you want to reset the map scale?", "Change Map Scale", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    dblMapScale = displayMapScaleOptions();
                    if (dblMapScale > 0)
                    {
                        // change scale            
                        pMap.MapScale = Math.Round(dblMapScale);
                        pMxDoc.ActiveView.Refresh();

                        this.MapScale = pMap.MapScale;
                    }

                    if (dblMapScale < SPrintConst.InchesPerMile)
                    {
                        dblCurrentScale = Math.Round(Math.Round(dblMapScale / 12, 0));
                        sCurrentScaleMsg = "1\" = " + dblCurrentScale.ToString("0,0") + " feet";
                    }
                    else
                    {
                        dblCurrentScale = Math.Round(dblMapScale / SPrintConst.InchesPerMile, 1);
                        if (dblCurrentScale == 1)
                            sCurrentScaleMsg = "1\" = " + dblCurrentScale.ToString("0,0") + " mile";
                        else
                            sCurrentScaleMsg = "1\" = " + dblCurrentScale.ToString("0,0") + " miles";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:setNewMapScale()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pMxDoc = null;
                pMap = null;
            }
            return sCurrentScaleMsg;
        }

        private double displayMapScaleOptions()
        {
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IMap pMap = (IMap)pMxDoc.FocusMap;

            fmMapScale oMapScale = new fmMapScale();
            try
            {
                // change scale
                // oMapScale.MapScale = pMap.MapScale;
                oMapScale.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPageLayout:displayMapScaleOptions()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oMapScale.Dispose();
                pMxDoc = null;
                pMap = null;
            }

            return oMapScale.MapScale;
        }


        private void centerElement(IElement pElem, double dblWidth)
        {
            IEnvelope pEnv = pElem.Geometry.Envelope;

            double dblHalfWidth = pEnv.Width / 2;
            double dblX = (dblWidth / 2) - dblHalfWidth;

            try
            {

                if (dblX > 0)
                {
                    ITransform2D pTrans2D = (ITransform2D)pElem;
                    pTrans2D.Move(dblX, 0);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                pEnv = null;
            }
        }

        #endregion
    }
}
