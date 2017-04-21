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
    public class CPortraitLayout : CPageLayout
    {

        #region Constructor -- use base

        public CPortraitLayout(ESRI.ArcGIS.Framework.IApplication pApp, List<string> lstLegendLayers, Double dblMapScale, string sMapSize, string sTitle, string sSubTitle, string sOrientation, string sPrinterName):
        base(pApp, lstLegendLayers, dblMapScale, sMapSize, sTitle, sSubTitle, sOrientation, sPrinterName)
        {
            // let the base class handle this
        }

        public void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Base function calls 


        public override void addLogo()
        {
            base.addLogo();
        }

        public override void addNeatline()
        {
            base.addNeatline();
        }

        public override void addNorthArrow()
        {
            base.addNorthArrow();
        }

        public override void addRecyclingInfo()
        {
            base.addRecyclingInfo();
        }

        public override void adjustMapFrame()
        {
            base.adjustMapFrame();
        }

        public override void createLayout()
        {
            base.createLayout();
        }

        public override void deleteMapSurrounds()
        {
            base.deleteMapSurrounds();
        }

        public override void refreshLayout()
        {
            base.refreshLayout();
        }

        public override void addScaleBar()
        {
            //double dblMapScale = setNewMapScale();
            base.addScaleBar();
        }
        public override void addLegend()
        {
            //double dblXMin = SPrintConst.MapFrame_XMin * base.XFactor;  //SPrintConst.Legend_XMin * base.XFactor;
            //double dblYMin = SPrintConst.MapFrame_YMin * base.YFactor;  //SPrintConst.Legend_YMin * base.YFactor;

            base.addLegend();
        }

        public override void unselectAllGraphics()
        {
            base.unselectAllGraphics();
        }

#endregion


        #region Override base function calls

        public override void setConstants()
        {
            try
            {
                Dictionary<string, string> dctPortraitSettings = CMedToolsSubs.returnSettingsNodes(SConst.PrintSettingsLocation, "//PortraitPrintSetting");

                SPrintConst.Neatline_XMin = Double.Parse(dctPortraitSettings["Portrait_NeatLineXMin"].ToString());
                SPrintConst.Neatline_XMax = Double.Parse(dctPortraitSettings["Portrait_NeatLineXMax"].ToString());
                SPrintConst.Neatline_YMin = Double.Parse(dctPortraitSettings["Portrait_NeatLineYMin"].ToString());
                SPrintConst.Neatline_YMax = Double.Parse(dctPortraitSettings["Portrait_NeatLineYMax"].ToString());
                SPrintConst.MapFrame_XMin = Double.Parse(dctPortraitSettings["Portrait_MapFrameXMin"].ToString());
                SPrintConst.MapFrame_XMax = Double.Parse(dctPortraitSettings["Portrait_MapFrameXMax"].ToString());
                SPrintConst.MapFrame_YMin = Double.Parse(dctPortraitSettings["Portrait_MapFrameYMin"].ToString());
                SPrintConst.MapFrame_YMax = Double.Parse(dctPortraitSettings["Portrait_MapFrameYMax"].ToString());
                SPrintConst.Logo_Offset = Double.Parse(dctPortraitSettings["Portrait_LogoOffset"].ToString());
                SPrintConst.MapScaleText_Offset = Double.Parse(dctPortraitSettings["Portrait_MapscaleTextOffset"].ToString());
                SPrintConst.NameDate_Offset = Double.Parse(dctPortraitSettings["Portrait_NameDateOffset"].ToString());
                SPrintConst.Title_XOffset = Double.Parse(dctPortraitSettings["Portrait_TitleXOffset"].ToString());
                SPrintConst.Legend_YMax = Double.Parse(dctPortraitSettings["Portrait_LegendYMax"].ToString());
                SPrintConst.MaxLengendHeight = Double.Parse(dctPortraitSettings["Portrait_MaxLegendHeight"].ToString());
                SPrintConst.RightOfTitleLine_X = Double.Parse(dctPortraitSettings["Portrait_RightOfTitleLineX"].ToString());
                SPrintConst.LeftLine_X = Double.Parse(dctPortraitSettings["Portrait_LeftLineX"].ToString());
                SPrintConst.CenterLine_Y = Double.Parse(dctPortraitSettings["Portrait_CenterLineY"].ToString());
                SPrintConst.Scalebar_XMax = Double.Parse(dctPortraitSettings["Portrait_ScalebarXMax"].ToString());
                SPrintConst.Scalebar_XMin = Double.Parse(dctPortraitSettings["Portrait_ScalebarXMin"].ToString());
                SPrintConst.Scalebar_YMax = Double.Parse(dctPortraitSettings["Portrait_ScalebarYMax"].ToString());
                SPrintConst.Scalebar_YMin = Double.Parse(dctPortraitSettings["Portrait_ScalebarYMin"].ToString());
                SPrintConst.MapscaleText_XMin = Double.Parse(dctPortraitSettings["Portrait_MapscaleText_XMin"].ToString());
                SPrintConst.MapscaleText_XMax = Double.Parse(dctPortraitSettings["Portrait_MapscaleText_XMax"].ToString());
                SPrintConst.MapscaleText_YMin = Double.Parse(dctPortraitSettings["Portrait_MapscaleText_YMin"].ToString());
                SPrintConst.MedfordRectangle_YMin = Double.Parse(dctPortraitSettings["Portrait_MedfordRectangle_YMin"].ToString());
                SPrintConst.MedfordText_XMin = Double.Parse(dctPortraitSettings["Portrait_MedfordText_XMin"].ToString());
                SPrintConst.MedfordText_XMax = Double.Parse(dctPortraitSettings["Portrait_MedfordText_XMax"].ToString());
                SPrintConst.MedfordText_YMin = Double.Parse(dctPortraitSettings["Portrait_MedfordText_YMin"].ToString());
                SPrintConst.MedfordText_YMax = Double.Parse(dctPortraitSettings["Portrait_MedfordText_YMax"].ToString());
                SPrintConst.MedGISText_XMax = Double.Parse(dctPortraitSettings["Portrait_MedGISText_XMax"].ToString());
                SPrintConst.MedGISText_XMin = Double.Parse(dctPortraitSettings["Portrait_MedGISText_XMin"].ToString());
                SPrintConst.MedGISText_YMax = Double.Parse(dctPortraitSettings["Portrait_MedGISText_YMax"].ToString());
                SPrintConst.MedGISText_YMin = Double.Parse(dctPortraitSettings["Portrait_MedGISText_YMin"].ToString());
                SPrintConst.Disclaimer_XMin = Double.Parse(dctPortraitSettings["Portrait_Disclaimer_XMin"].ToString());
                SPrintConst.Disclaimer_XMax = Double.Parse(dctPortraitSettings["Portrait_Disclaimer_XMax"].ToString());
                SPrintConst.Disclaimer_YMin = Double.Parse(dctPortraitSettings["Portrait_Disclaimer_YMin"].ToString());
                SPrintConst.Disclaimer_YMax = Double.Parse(dctPortraitSettings["Portrait_Disclaimer_YMax"].ToString());
                SPrintConst.Recycle_YMin = Double.Parse(dctPortraitSettings["Portrait_Recycle_YMin"].ToString());
                SPrintConst.Recycle_HeightWidth = Double.Parse(dctPortraitSettings["Portrait_Recycle_HeightWidth"].ToString());
                SPrintConst.Recycle_ImagePath = dctPortraitSettings["Portrait_Recycle_ImagePath"].ToString();
                SPrintConst.Logo_Image = dctPortraitSettings["Portrait_Logo_Image"].ToString();
                SPrintConst.Logo_XMin = Double.Parse(dctPortraitSettings["Portrait_Logo_XMin"].ToString());
                SPrintConst.Logo_YMin = Double.Parse(dctPortraitSettings["Portrait_Logo_YMin"].ToString());
                SPrintConst.Logo_Height = Double.Parse(dctPortraitSettings["Portrait_Logo_Height"].ToString());
                SPrintConst.Logo_Width = Double.Parse(dctPortraitSettings["Portrait_Logo_Width"].ToString());
                SPrintConst.NorthArrow_Character = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_Character"].ToString());
                SPrintConst.NorthArrow_Height = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_Height"].ToString());
                SPrintConst.NorthArrow_Size = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_Size"].ToString());
                SPrintConst.NorthArrow_Width = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_Width"].ToString());
                SPrintConst.NorthArrow_XMax = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_XMax"].ToString());
                SPrintConst.NorthArrow_XMin = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_XMin"].ToString());
                SPrintConst.NorthArrow_YMax = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_YMax"].ToString());
                SPrintConst.NorthArrow_YMin = Double.Parse(dctPortraitSettings["Portrait_NorthArrow_YMin"].ToString());
                SPrintConst.Title_XMax = Double.Parse(dctPortraitSettings["Portrait_Title_XMax"].ToString());
                SPrintConst.Title_YMax = Double.Parse(dctPortraitSettings["Portrait_Title_YMax"].ToString());
                SPrintConst.Title_XMin = Double.Parse(dctPortraitSettings["Portrait_Title_XMin"].ToString());
                SPrintConst.Title_YMin = Double.Parse(dctPortraitSettings["Portrait_Title_YMin"].ToString());
                SPrintConst.Subtitle_XMax = Double.Parse(dctPortraitSettings["Portrait_Subtitle_XMax"].ToString());
                SPrintConst.Subtitle_YMax = Double.Parse(dctPortraitSettings["Portrait_Subtitle_YMax"].ToString());
                SPrintConst.Subtitle_XMin = Double.Parse(dctPortraitSettings["Portrait_Subtitle_XMin"].ToString());
                SPrintConst.Subtitle_YMin = Double.Parse(dctPortraitSettings["Portrait_Subtitle_YMin"].ToString());
                SPrintConst.Legend_Height = Double.Parse(dctPortraitSettings["Portrait_Legend_Height"].ToString());
                SPrintConst.Legend_Width = Double.Parse(dctPortraitSettings["Portrait_Legend_Width"].ToString());
                SPrintConst.Legend_XMin = Double.Parse(dctPortraitSettings["Portrait_Legend_XMin"].ToString());
                SPrintConst.Legend_YMin = Double.Parse(dctPortraitSettings["Portrait_Legend_YMin"].ToString());
                SPrintConst.Name_XMax = Double.Parse(dctPortraitSettings["Portrait_NameXMax"].ToString());
                SPrintConst.Name_XMin = Double.Parse(dctPortraitSettings["Portrait_NameXMin"].ToString());
                SPrintConst.Name_YMax = Double.Parse(dctPortraitSettings["Portrait_NameYMax"].ToString());
                SPrintConst.Name_YMin = Double.Parse(dctPortraitSettings["Portrait_NameYMin"].ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:setConstants()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public override void addUserName()
        {
            base.addUserName();
        }

        public override void doPrintSetup(IPageLayout2 pPageLayout)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();

            //short shPageForm = 0;  // see ms-help://ESRI.EDNv9.2/esricarto/html/esriPageFormID.htm for IPrinter::FormID constants
            int iPageFormID = 0;   // see http://msdn.microsoft.com/en-us/library/ms776398(VS.85).aspx for IPaper::FormID constants
            //double dblPageWidth = 0;
            //double dblPageHeight = 0;

            IMxApplication pMxApp = (IMxApplication)this.App;
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;

            IPrinter pPrinter = pMxApp.Printer;
            IPaper pPaper = pPrinter.Paper;

            try
            {
                pMxDoc.PageLayout.Page.Orientation = 1;
                pPaper.Orientation = 1;

                switch (this.MapSize)
                {
                    case "34 x 44":
                        //shPageForm = 5; // esriPageFormID.esriPageFormE;

                        base.XFactor = 4;
                        base.YFactor = 4;

                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "34 x 44");
                        else 
                            iPageFormID = 26;

                        break;
                    case "17 x 22":
                        //shPageForm = 3; // esriPageFormID.esriPageFormC;

                        base.XFactor = 2;
                        base.YFactor = 2;

                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "17 x 22");
                        else
                            iPageFormID = 24;

                        break;
                    case "11 x 17":
                        //shPageForm = 2; // esriPageFormID.esriPageFormTabloid;

                        base.XFactor = 1.3;  //1.2941
                        base.YFactor = 1.5455;  //1.5455

                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "11 x 17");
                        else
                            iPageFormID = 17;

                        break;
                    case "8.5 x 11":
                        //shPageForm = 0; // esriPageFormID.esriPageFormLetter;

                        base.XFactor = 1;
                        base.YFactor = 1;

                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "8.5 x 11 ");
                        else
                            iPageFormID = 1;
                        break;
                }

                pPaper.PrinterName = base.PrinterName;
                pPaper.FormID = (short)iPageFormID;

                double dblWidth = 0;
                double dblHeight = 0;
                pPaper.QueryPaperSize(out dblWidth, out dblHeight);

                pMxDoc.PageLayout.Page.PutCustomSize(dblWidth, dblHeight);
                pMxDoc.PageLayout.Page.FormID = (esriPageFormID)Enum.Parse(typeof(esriPageFormID), iPageFormID.ToString());
                

                pMxDoc.ActiveView.PrinterChanged(pPrinter);







                //////----------------------------------------------------------------------------
                //////Set the layout page size and orientation.
                //////----------------------------------------------------------------------------
                //pPage = pMxDoc.PageLayout.Page;
                //pPage.Orientation = 1;
                //pPage.FormID = (esriPageFormID)Enum.Parse(typeof(esriPageFormID), iPageFormID.ToString());

                ////----------------------------------------------------------------------------
                ////Set the printer paper size and orientation.
                ////----------------------------------------------------------------------------
                //pPrinter = pMxApp.Printer;
                //pPrinter.Paper.PrinterName = base.PrinterName;
                //pPrinter.Paper.FormID = shPageForm;
                //pPrinter.Paper.Orientation = 1;

                ////----------------------------------------------------------------------------
                //// deal with the paper
                ////----------------------------------------------------------------------------
                //pPaper = pMxApp.Paper;
                //pPaper.Orientation = 1;
                //pPaper.FormID = (short)iPageFormID;
                //pPaper.PrinterName = base.PrinterName;

          
                //pMxDoc.ActiveView.PrinterChanged(pPrinter);

                ////////----------------------------------------------------------------------------
                ////////Set the layout page size and orientation.
                ////////----------------------------------------------------------------------------
                ////pPage = pMxDoc.PageLayout.Page;
                ////pPage.Orientation = 1;
                ////pPage.FormID = esriPageFormID.esriPageFormCUSTOM;
                ////pPage.PutCustomSize(dblPageWidth + .1, dblPageHeight + .1);
                ////pPage.PrinterChanged(pPrinter);

                ////double dblWidth = 0; double dblHeight = 0;
                ////pPaper.QueryPaperSize(out dblWidth, out dblHeight);

                ////pPage.PutCustomSize(dblWidth, dblHeight);   //(dblWidth, dblHeight);
                ////pPage.FormID = esriPageFormID.esriPageFormCUSTOM;
                ////pPage.PrinterChanged(pPrinter);

                ////pPage.PutCustomSize(dblWidth, dblHeight);
                ////pPage.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

                //pMxApp.Printer = pPrinter;
                ////pMxDoc.PageLayout = (IPageLayout)pPage;
                //pMxDoc.PageLayout.Page.PutCustomSize(dblPageWidth - 1.8, dblPageHeight - 1.8);
                //pMxDoc.PageLayout.Page.FormID = esriPageFormID.esriPageFormSameAsPrinter;
                //pMxDoc.ActiveView.PrinterChanged(pPrinter);

                //pActiveView = (IActiveView)pMxDoc.ActiveView;
                //pActiveView.Refresh();

                //pMxApp.Printer.Paper.PrinterName = base.PrinterName;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:doPrintSetup()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pMxDoc = null;
                pPrinter = null;
                pPaper = null;
                oSpatialSubs.Dispose();
            }
        }

        public override void addSeperatorLine()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            ISimpleLineSymbol pLineSym = null;

            try
            {
                pLineSym = (ISimpleLineSymbol)oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (2 * base.XFactor), esriSimpleLineStyle.esriSLSSolid);
                oSpatialSubs.addLineToGraphicsContainer(pGC, pLineSym,
                                                        (SPrintConst.Neatline_XMin * base.XFactor),
                                                        (SPrintConst.Neatline_XMax * base.XFactor),
                                                        (SPrintConst.Neatline_YMin * base.YFactor),
                                                        (SPrintConst.Neatline_YMin * base.YFactor));
                addRightOfTitleLine();
                addLeftLine();
                addCenterLine();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addSeperatorLine()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
                pLineSym = null;
            }

        }

        /// <summary>
        /// Add the mapscale text to the Graphic Container. Places this text under the scale bar.
        /// </summary>
        /// <param name="sMapScale"></param>
        public override void addMapScaleText(string sMapScale)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            IMapSurroundFrame pMSFrame = null;
            IEnvelope pEnv = null;
            ITextSymbol pTextSym = null;
            ITextElement pTextElem = null;

            try
            {
                //Locate the scalebar in the graphics container because we
                //want to put the mapscale right under it.
                //A scalebar is contained within a MapSurroundFrame.
                pGC.Reset();
                IElement pElem = pGC.Next();
                while (pElem != null)
                {
                    if (pElem is IMapSurroundFrame)
                    {
                        pMSFrame = (IMapSurroundFrame)pElem;
                        if (pMSFrame.Object is IScaleBar)
                            break;  // we got the scalebar
                    }
                    pElem = pGC.Next();
                }

                pEnv = new EnvelopeClass();
                //get the envelope of the scalebar
                pElem.QueryBounds(pMxDoc.ActiveView.ScreenDisplay, pEnv);

                double xMin = SPrintConst.MapscaleText_XMin * base.XFactor;
                double xMax = SPrintConst.MapscaleText_XMax * base.XFactor;
                double yMax = pEnv.YMin - 0.02;  //this is the min y value of the scalebar envelope - .02
                double yMin = SPrintConst.MapscaleText_YMin * base.YFactor;

                //Set pMapscaleText symbol to the textsymbol
                pTextSym = oSpatialSubs.createTextSymbol(0, 0, 0, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTextSym, xMin, xMax, yMin, yMax, sMapScale);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addMapScaleText()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose(); 
                pMxDoc = null;
                pGC = null;
                pMSFrame = null;
                pEnv = null;
                pTextSym = null;
                pTextElem = null;
            }
        }

        /// <summary>
        ///     Adds a black rectangle in the lower right corner area just below the mapframe. The white
        ///     text CITY OF MEDFORD is added on top of this rectangle.
        /// </summary>
        public override void addMedfordRectangle()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ILineSymbol pLineSym = oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), base.XFactor, esriSimpleLineStyle.esriSLSSolid);
                ISimpleFillSymbol pFillSymbol = (ISimpleFillSymbol)oSpatialSubs.createSimpleFillSymbol(oSpatialSubs.createRGB(0, 0, 0), pLineSym, esriSimpleFillStyle.esriSFSSolid);

                oSpatialSubs.addRectangleToGraphicsContainer(pGC,
                                                            (IFillSymbol)pFillSymbol,
                                                            (SPrintConst.LeftLine_X * base.XFactor),
                                                            (SPrintConst.Neatline_XMax * base.XFactor),
                                                            (SPrintConst.MedfordRectangle_YMin * base.YFactor),
                                                            (SPrintConst.MapFrame_YMin * base.YFactor));
                pLineSym = null;
                pFillSymbol = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addMedfordRectangle()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }

        /// <summary>
        ///     Add the MEDFORD text as an ITextElement to the map layout. Place the text on top
        ///     off the black rectangle that was placed in the lower right hand corner between
        ///     the mapframe and the neatline.
        /// </summary>
        public override void addMedfordText()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ITextSymbol pTextSym = oSpatialSubs.createTextSymbol(255, 255, 255, (9 * base.YFactor), esriTextHorizontalAlignment.esriTHACenter, esriTextVerticalAlignment.esriTVACenter, "Arial");
                string sText = "CITY OF MEDFORD";
                ITextElement pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC,
                                                                                    pTextSym,
                                                                                    (base.XFactor * SPrintConst.MedfordText_XMin),
                                                                                    (base.XFactor * SPrintConst.MedfordText_XMax),
                                                                                    (base.YFactor * SPrintConst.MedfordText_YMin),
                                                                                    (base.YFactor * SPrintConst.MedfordText_YMax),
                                                                                    sText);
                pTextSym = null;
                pTextElem = null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addMedfordText()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }


        public override void addDisclaimer()
        {
            base.addDisclaimer((base.XFactor* SPrintConst.Disclaimer_XMin),
                               (base.XFactor * SPrintConst.Disclaimer_XMax),
                               (base.YFactor * SPrintConst.Disclaimer_YMin),
                               (base.YFactor * SPrintConst.Disclaimer_YMax));
        }

        public override void addDateName()
        {
            base.addDateName(0,
                             (base.XFactor * SPrintConst.Neatline_XMax),
                             (base.YFactor * SPrintConst.NameDate_Offset),
                             (base.YFactor * (SPrintConst.Neatline_YMin - SPrintConst.NameDate_Offset)));
        }

        public override void addTitles(string sTitle, string sSubTitle)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                // count line breaks in sTitle
                int iTitleLineBreaks = sTitle.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1;

                double dblXMin = 0; double dblXMax = 0; double dblYMin = 0; double dblYMax = 0;

                // do the title stuff
                dblXMin = SPrintConst.Title_XMin * base.XFactor;
                dblXMax = SPrintConst.Title_XMax * base.XFactor;
                dblYMin = SPrintConst.Title_YMin * base.YFactor;
                dblYMax = SPrintConst.Title_YMax * base.YFactor;

                if (sTitle.Length > 0)
                {
                    //if (iTitleLineBreaks > 0)
                    //    dblYMin += (.45 * base.YFactor);

                    ITextSymbol pTitleTextSym = oSpatialSubs.createTextSymbol(0, 0, 0, 16 * base.XFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                    ITextElement pTitleTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTitleTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sTitle);

                    //move the title right where we want it
                    oSpatialSubs.moveElementToXMinYmin(pTitleTextElem as IElement, dblXMin, dblYMin);

                    pTitleTextSym = null;
                    pTitleTextElem = null;
                }

                // do the subtitle stuff
                dblXMin = SPrintConst.Subtitle_XMin * base.XFactor;
                dblXMax = SPrintConst.Subtitle_XMax * base.XFactor;
                dblYMin = SPrintConst.Subtitle_YMin * base.YFactor;
                dblYMax = SPrintConst.Subtitle_YMax * base.YFactor;

                if (sSubTitle.Length > 0)
                {
                    if (iTitleLineBreaks > 0)
                        dblYMin -= (.35 * base.YFactor);

                    ITextSymbol pSubTitleTextSym = oSpatialSubs.createTextSymbol(108, 108, 108, 9 * base.XFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                    ITextElement pSubTitleTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pSubTitleTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sSubTitle);

                    //move the title right where we want it
                    oSpatialSubs.moveElementToXMinYmin(pSubTitleTextElem as IElement, dblXMin, dblYMin);

                    pSubTitleTextSym = null;
                    pSubTitleTextElem = null;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addTitles()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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


        private void addRightOfTitleLine()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            ISimpleLineSymbol pLineSym = null;

            try
            {
                pLineSym = (ISimpleLineSymbol)oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (.5 * base.XFactor), esriSimpleLineStyle.esriSLSSolid);
                oSpatialSubs.addLineToGraphicsContainer(pGC,
                                                        pLineSym,
                                                        (SPrintConst.RightOfTitleLine_X * base.XFactor),
                                                        (SPrintConst.RightOfTitleLine_X * base.XFactor),
                                                        (SPrintConst.Neatline_YMin * base.YFactor),
                                                        (SPrintConst.MapFrame_YMin * base.YFactor));
                pLineSym = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addRightofTitle()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }

        }

        private void addLeftLine()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            ISimpleLineSymbol pLineSymbol = null;
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                pLineSymbol = (ISimpleLineSymbol)oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (1 * base.XFactor), esriSimpleLineStyle.esriSLSSolid);
                oSpatialSubs.addLineToGraphicsContainer(pGC,
                                                       pLineSymbol,
                                                       (SPrintConst.LeftLine_X * base.XFactor),
                                                       (SPrintConst.LeftLine_X * base.XFactor),
                                                       (SPrintConst.Neatline_YMin * base.YFactor),
                                                       (SPrintConst.MapFrame_YMin * base.YFactor));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addLeftLine()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pLineSymbol = null;
                pMxDoc = null;
                pGC = null;
            }

        }

        private void addCenterLine()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            ISimpleLineSymbol pLineSym = null;
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                pLineSym = (ISimpleLineSymbol)oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (1 * base.XFactor), esriSimpleLineStyle.esriSLSSolid);
                oSpatialSubs.addLineToGraphicsContainer(pGC,
                                                        pLineSym,
                                                        SPrintConst.LeftLine_X * base.XFactor,
                                                        SPrintConst.Neatline_XMax * base.XFactor,
                                                        SPrintConst.CenterLine_Y * base.YFactor,
                                                        SPrintConst.CenterLine_Y * base.YFactor);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CPortraitLayout:addCenterLine()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pLineSym = null;
                pMxDoc = null;
                pGC = null;
            }

        }


        #endregion
    }
}
