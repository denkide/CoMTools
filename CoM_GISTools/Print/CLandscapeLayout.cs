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
    public class CLandscapeLayout : CPageLayout
    {

        #region Constructor -- use base

        public CLandscapeLayout(ESRI.ArcGIS.Framework.IApplication pApp, List<string> lstLegendLayers, Double dblMapScale, string sMapSize, string sTitle, string sSubTitle, string sOrientation, string sPrinterName):
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

        public override void addScaleBar()
        {
            base.addScaleBar();
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

        public override void addLegend()
        {
            ////double dblXMin = (SPrintConst.MapFrame_XMax + SPrintConst.Title_XOffset) * base.XFactor;   // SPrintConst.Neatline_XMax
            ////double dblYMin = SPrintConst.Legend_YMin * base.YFactor;   //SPrintConst.Legend_YMax

            //double dblXMin = SPrintConst.MapFrame_XMin * base.XFactor;  //SPrintConst.Legend_XMin * base.XFactor;
            //double dblYMin = SPrintConst.MapFrame_YMin * base.XFactor;  //SPrintConst.Legend_YMin * base.YFactor;

            base.addLegend();
        }

        public override void unselectAllGraphics()
        {
            base.unselectAllGraphics();
        }


        public override void addLogo()
        {
            base.addLogo();
        }

        #endregion


        #region Override base function calls

        public override void setConstants()
        {
            try
            {
                Dictionary<string, string> dctLandscapeSettings = CMedToolsSubs.returnSettingsNodes(SConst.PrintSettingsLocation, "//LandscapePrintSetting");

                SPrintConst.Neatline_XMin = Double.Parse(dctLandscapeSettings["Landscape_NeatLineXMin"].ToString());
                SPrintConst.Neatline_XMax = Double.Parse(dctLandscapeSettings["Landscape_NeatLineXMax"].ToString());
                SPrintConst.Neatline_YMin = Double.Parse(dctLandscapeSettings["Landscape_NeatLineYMin"].ToString());
                SPrintConst.Neatline_YMax = Double.Parse(dctLandscapeSettings["Landscape_NeatLineYMax"].ToString());
                SPrintConst.MapFrame_XMin = Double.Parse(dctLandscapeSettings["Landscape_MapFrameXMin"].ToString());
                SPrintConst.MapFrame_XMax = Double.Parse(dctLandscapeSettings["Landscape_MapFrameXMax"].ToString());
                SPrintConst.MapFrame_YMin = Double.Parse(dctLandscapeSettings["Landscape_MapFrameYMin"].ToString());
                SPrintConst.MapFrame_YMax = Double.Parse(dctLandscapeSettings["Landscape_MapFrameYMax"].ToString());
                SPrintConst.Logo_Offset = Double.Parse(dctLandscapeSettings["Landscape_LogoOffset"].ToString());
                SPrintConst.MapScaleText_Offset = Double.Parse(dctLandscapeSettings["Landscape_MapscaleTextOffset"].ToString());
                SPrintConst.NameDate_Offset = Double.Parse(dctLandscapeSettings["Landscape_NameDateOffset"].ToString());
                SPrintConst.Title_XOffset = Double.Parse(dctLandscapeSettings["Landscape_TitleXOffset"].ToString());
                SPrintConst.Legend_YMax = Double.Parse(dctLandscapeSettings["Landscape_LegendYMax"].ToString());
                SPrintConst.MaxLengendHeight = Double.Parse(dctLandscapeSettings["Landscape_MaxLegendHeight"].ToString());
                SPrintConst.RightOfTitleLine_X = 1;
                SPrintConst.LeftLine_X = 1;
                SPrintConst.CenterLine_Y = Double.Parse(dctLandscapeSettings["Landscape_CenterLineY"].ToString()); ;
                SPrintConst.Scalebar_XMax = Double.Parse(dctLandscapeSettings["Landscape_ScalebarXMax"].ToString());
                SPrintConst.Scalebar_XMin = Double.Parse(dctLandscapeSettings["Landscape_ScalebarXMin"].ToString());
                SPrintConst.Scalebar_YMax = Double.Parse(dctLandscapeSettings["Landscape_ScalebarYMax"].ToString());
                SPrintConst.Scalebar_YMin = Double.Parse(dctLandscapeSettings["Landscape_ScalebarYMin"].ToString());
                SPrintConst.MapscaleText_XMin = Double.Parse(dctLandscapeSettings["Landscape_MapscaleText_XMin"].ToString());
                SPrintConst.MapscaleText_XMax = Double.Parse(dctLandscapeSettings["Landscape_MapscaleText_XMax"].ToString());
                SPrintConst.MapscaleText_YMin = Double.Parse(dctLandscapeSettings["Landscape_MapscaleText_YMin"].ToString());
                SPrintConst.MedfordRectangle_YMin = Double.Parse(dctLandscapeSettings["Landscape_MedfordRectangle_YMin"].ToString());
                SPrintConst.MedfordText_XMin = Double.Parse(dctLandscapeSettings["Landscape_MedfordText_XMin"].ToString());
                SPrintConst.MedfordText_XMax = Double.Parse(dctLandscapeSettings["Landscape_MedfordText_XMax"].ToString());
                SPrintConst.MedfordText_YMin = Double.Parse(dctLandscapeSettings["Landscape_MedfordText_YMin"].ToString());
                SPrintConst.MedfordText_YMax = Double.Parse(dctLandscapeSettings["Landscape_MedfordText_YMax"].ToString());
                SPrintConst.MedGISText_XMax = Double.Parse(dctLandscapeSettings["Landscape_MedGISText_XMax"].ToString());
                SPrintConst.MedGISText_XMin = Double.Parse(dctLandscapeSettings["Landscape_MedGISText_XMin"].ToString());
                SPrintConst.MedGISText_YMax = Double.Parse(dctLandscapeSettings["Landscape_MedGISText_YMax"].ToString());
                SPrintConst.MedGISText_YMin = Double.Parse(dctLandscapeSettings["Landscape_MedGISText_YMin"].ToString());
                SPrintConst.Disclaimer_XMin = Double.Parse(dctLandscapeSettings["Landscape_Disclaimer_XMin"].ToString());
                SPrintConst.Disclaimer_XMax = Double.Parse(dctLandscapeSettings["Landscape_Disclaimer_XMax"].ToString());
                SPrintConst.Disclaimer_YMin = Double.Parse(dctLandscapeSettings["Landscape_Disclaimer_YMin"].ToString());
                SPrintConst.Disclaimer_YMax = Double.Parse(dctLandscapeSettings["Landscape_Disclaimer_YMax"].ToString());
                SPrintConst.Recycle_YMin = Double.Parse(dctLandscapeSettings["Landscape_Recycle_YMin"].ToString());
                SPrintConst.Recycle_HeightWidth = Double.Parse(dctLandscapeSettings["Landscape_Recycle_HeightWidth"].ToString());
                SPrintConst.Recycle_ImagePath = dctLandscapeSettings["Landscape_Recycle_ImagePath"].ToString();
                SPrintConst.Logo_Image = dctLandscapeSettings["Landscape_Logo_Image"].ToString();
                SPrintConst.Logo_XMin = Double.Parse(dctLandscapeSettings["Landscape_Logo_XMin"].ToString());
                SPrintConst.Logo_YMin = Double.Parse(dctLandscapeSettings["Landscape_Logo_YMin"].ToString());
                SPrintConst.Logo_Height = Double.Parse(dctLandscapeSettings["Landscape_Logo_Height"].ToString());
                SPrintConst.Logo_Width = Double.Parse(dctLandscapeSettings["Landscape_Logo_Width"].ToString());
                SPrintConst.NorthArrow_Character = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_Character"].ToString());
                SPrintConst.NorthArrow_Height = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_Height"].ToString());
                SPrintConst.NorthArrow_Size = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_Size"].ToString());
                SPrintConst.NorthArrow_Width = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_Width"].ToString());
                SPrintConst.NorthArrow_XMax = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_XMax"].ToString());
                SPrintConst.NorthArrow_XMin = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_XMin"].ToString());
                SPrintConst.NorthArrow_YMax = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_YMax"].ToString());
                SPrintConst.NorthArrow_YMin = Double.Parse(dctLandscapeSettings["Landscape_NorthArrow_YMin"].ToString());
                SPrintConst.Title_XMax = Double.Parse(dctLandscapeSettings["Landscape_Title_XMax"].ToString());
                SPrintConst.Title_YMax = Double.Parse(dctLandscapeSettings["Landscape_Title_YMax"].ToString());
                SPrintConst.Title_XMin = Double.Parse(dctLandscapeSettings["Landscape_Title_XMin"].ToString());
                SPrintConst.Title_YMin = Double.Parse(dctLandscapeSettings["Landscape_Title_YMin"].ToString());
                SPrintConst.Subtitle_XMax = Double.Parse(dctLandscapeSettings["Landscape_Subtitle_XMax"].ToString());
                SPrintConst.Subtitle_YMax = Double.Parse(dctLandscapeSettings["Landscape_Subtitle_YMax"].ToString());
                SPrintConst.Subtitle_XMin = Double.Parse(dctLandscapeSettings["Landscape_Subtitle_XMin"].ToString());
                SPrintConst.Subtitle_YMin = Double.Parse(dctLandscapeSettings["Landscape_Subtitle_YMin"].ToString());
                SPrintConst.Legend_Height = Double.Parse(dctLandscapeSettings["Landscape_Legend_Height"].ToString());
                SPrintConst.Legend_Width = Double.Parse(dctLandscapeSettings["Landscape_Legend_Width"].ToString());
                SPrintConst.Legend_XMin = Double.Parse(dctLandscapeSettings["Landscape_Legend_XMin"].ToString());
                SPrintConst.Legend_YMin = Double.Parse(dctLandscapeSettings["Landscape_Legend_YMin"].ToString());
                SPrintConst.Name_XMax = Double.Parse(dctLandscapeSettings["Landscape_NameXMax"].ToString());
                SPrintConst.Name_XMin = Double.Parse(dctLandscapeSettings["Landscape_NameXMin"].ToString());
                SPrintConst.Name_YMax = Double.Parse(dctLandscapeSettings["Landscape_NameYMax"].ToString());
                SPrintConst.Name_YMin = Double.Parse(dctLandscapeSettings["Landscape_NameYMin"].ToString());

                dctLandscapeSettings = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:setConstants()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public override void doPrintSetup(IPageLayout2 pPageLayout)
        {
            //IMxApplication pMxApp = (IMxApplication)this.App;
            //IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            //ESRI.ArcGIS.esriSystem.IEnumNamedID pEnumNamedID = (ESRI.ArcGIS.esriSystem.IEnumNamedID)pMxApp.Printer.Paper.Forms;
            
            //IPrinter pPrinter = null;
            //IPaper pPaper = null;
            //IPage pPage = null;
            //IActiveView pActiveView = null;

            //short shPageForm = 0;  // see ms-help://ESRI.EDNv9.2/esricarto/html/esriPaperFormID.htm for IPrinter::FormID constants

            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxApplication pMxApp = (IMxApplication)this.App;
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            esriPageFormID pFormID = esriPageFormID.esriPageFormLetter;

            IPrinter pPrinter = pMxApp.Printer;
            IPaper pPaper = pPrinter.Paper;

            int iPageFormID = 0;   // see http://msdn.microsoft.com/en-us/library/ms776398(VS.85).aspx for IPaper::FormID constants

            try
            {
                pMxDoc.PageLayout.Page.Orientation = 2;
                pPaper.Orientation = 2;

                switch (base.MapSize)
                {
                    case "34 x 44": //34 x 44
                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "34 x 44");
                        else
                            iPageFormID = 26;
                        pFormID = esriPageFormID.esriPageFormE;
                        base.XFactor = 4;
                        base.YFactor = 4;
                        break;
                    case "17 x 22": // 17 x 22
                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "17 x 22");
                        else
                            iPageFormID = 24;
                        pFormID = esriPageFormID.esriPageFormD;
                        base.XFactor = 2;
                        base.YFactor = 2;
                        break;
                    case "11 x 17": // 11 x 22
                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "11 x 17");
                        else
                            iPageFormID = 17;
                        pFormID = esriPageFormID.esriPageFormLegal;
                        base.XFactor = 1.5455;   //1.5455;
                        base.YFactor = 1.2941;   //1.2941;
                        break;
                    case "8.5 x 11": // 8.5 x 11
                        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
                            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "8.5 x 11");
                        else
                            iPageFormID = 1;
                        pFormID = esriPageFormID.esriPageFormLetter;
                        base.XFactor = 1;
                        base.YFactor = 1;
                        break;
                }

                pPaper.PrinterName = base.PrinterName;
                pPaper.FormID = (short)iPageFormID;
                
                double dblWidth = 0;
                double dblHeight = 0;
                pPaper.QueryPaperSize(out dblWidth, out dblHeight);

                pMxDoc.PageLayout.Page.PutCustomSize(dblWidth, dblHeight);
                //pMxDoc.PageLayout.Page.FormID = (esriPageFormID)Enum.Parse(typeof(esriPageFormID), iPageFormID.ToString());

                pMxDoc.PageLayout.Page.FormID = pFormID;
                
                IPage pPage = pMxDoc.PageLayout.Page;
                pPage.Orientation = 2;
                pPage.FormID = esriPageFormID.esriPageFormSameAsPrinter;

                pMxDoc.ActiveView.PrinterChanged(pPrinter);
                pMxDoc.ActiveView.Refresh();


                ////----------------------------------------------------------------------------
                ////Set the printer paper size and orientation.
                ////----------------------------------------------------------------------------
                //pPrinter = pMxApp.Printer;
                //pPrinter.Paper.PrinterName = base.PrinterName;
                //pPrinter.Paper.FormID = shPageForm;
                //pPrinter.Paper.Orientation = 2;

                //pPaper = pMxApp.Paper;
                //pPaper.Orientation = 2;
                //pPaper.FormID = (short)iPaperFormID;

                //pPaper.PrinterName = base.PrinterName;

                //pMxDoc.ActiveView.PrinterChanged(pPrinter);

                ////----------------------------------------------------------------------------
                ////Set the layout page size and orientation.
                ////----------------------------------------------------------------------------
                //pPage = pMxDoc.PageLayout.Page;
                //pPage.Orientation = 1;

                //double dblWidth = 0; double dblHeight = 0;
                //pPaper.QueryPaperSize(out dblWidth, out dblHeight);

                //pPage.PutCustomSize(dblWidth, dblHeight);

                ////pPage.FormID = esriPaperFormID.esriPageFormSameAsPrinter; // (esriPaperFormID)Enum.Parse(typeof(esriPaperFormID), shPageForm.ToString());
                ////pPage.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;

                //pPage.PrinterChanged(pPrinter);

                //pMxApp.Printer = pPrinter;
                ////pMxDoc.PageLayout = (IPageLayout)pPage.;

                //pActiveView = (IActiveView)pMxDoc.ActiveView;
                //pActiveView.Refresh();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:doPrintSetup()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                pMxDoc = null;
                pPrinter = null;
                pPaper = null;
            }


        }

        public override void addSeperatorLine()
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;

            try
            {
                ISimpleLineSymbol pLineSymbol = (ISimpleLineSymbol)oSpatialSubs.createSimpleLineSymbol(oSpatialSubs.createRGB(0, 0, 0), (this.XFactor * 2), esriSimpleLineStyle.esriSLSSolid);
                //oSpatialSubs.addLineToGraphicsContainer(pGC, pLineSymbol, (SPrintConst.MapFrame_XMax * this.XFactor), (SPrintConst.MapFrame_XMax * this.XFactor), (SPrintConst.MapFrame_YMin * this.YFactor), (SPrintConst.MapFrame_YMax * this.YFactor));
                oSpatialSubs.addLineToGraphicsContainer(pGC, pLineSymbol, (SPrintConst.MapFrame_XMax * this.XFactor), (SPrintConst.MapFrame_XMax * this.XFactor), (SPrintConst.Neatline_YMin * this.YFactor), (SPrintConst.Neatline_YMax * this.YFactor));

                addCenterLine();
                addBottomLine();

                pLineSymbol = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:addSeperatorLine()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;

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

                if (pElem != null)
                {
                    pEnv = new EnvelopeClass();
                    //get the envelope of the scalebar
                    pElem.QueryBounds(pMxDoc.ActiveView.ScreenDisplay, pEnv);

                    double xMin = base.XFactor * SPrintConst.MapFrame_XMax;
                    double xMax = base.XFactor * SPrintConst.Neatline_XMax;
                    double yMax = pEnv.YMin - 0.02;  //this is the min y value of the scalebar envelope - .02
                    double yMin = yMax - (SPrintConst.MapScaleText_Offset * base.YFactor);

                    //Set pMapscaleText symbol to the textsymbol
                    pTextSym = oSpatialSubs.createTextSymbol(0, 0, 0, 7 * this.YFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                    pTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTextSym, xMin, xMax, yMin, yMax, sMapScale);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:addMapScale()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                                                            (base.XFactor * SPrintConst.MapFrame_XMax),
                                                            (base.XFactor * SPrintConst.Neatline_XMax),
                                                            (base.YFactor * (SPrintConst.Neatline_YMax - SPrintConst.Logo_Offset)),
                                                            (base.YFactor * SPrintConst.Neatline_YMax));
                pLineSym = null;
                pFillSymbol = null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:addMedfordRectangle()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;
            }
        }

        /// <summary>
        ///     Add the SMARTMAP text as an ITextElement to the map layout. Place the text on top
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
                                                                                  ((base.XFactor * 1.19) * SPrintConst.MapFrame_XMax),
                                                                                  (base.XFactor * SPrintConst.MapFrame_XMax),
                                                                                  (base.YFactor * (SPrintConst.Neatline_YMax - SPrintConst.Logo_Offset)),
                                                                                  (base.YFactor * SPrintConst.Neatline_YMax),
                                                                                  sText);
                pTextSym = null;
                pTextElem = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:addMedfordText()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
            //base.addDisclaimer((base.XFactor * SPrintConst.MapFrame_XMax),
            //                   (base.XFactor * SPrintConst.Neatline_XMax),
            //                   (base.YFactor * SPrintConst.Neatline_YMin),
            //                   (base.YFactor * SPrintConst.Neatline_YMin + 0.63) * base.YFactor);
            base.addDisclaimer((base.XFactor * SPrintConst.Disclaimer_XMin),
                   (base.XFactor * SPrintConst.Disclaimer_XMax),
                   (base.YFactor * SPrintConst.Disclaimer_YMin),
                   (base.YFactor * SPrintConst.Disclaimer_YMax));
        }

        public override void addDateName()
        {
            base.addDateName(0,
                             (base.XFactor * SPrintConst.Neatline_XMax),
                             0.01,
                             (base.YFactor * (SPrintConst.Neatline_YMin - SPrintConst.NameDate_Offset)));
        }

        public override void addTitles(string sTitle, string sSubTitle)
        {
            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxDocument pMxDoc = (IMxDocument)base.App.Document;
            IGraphicsContainer pGC = (IGraphicsContainer)pMxDoc.PageLayout;
            
            ITextSymbol pTitleTextSym = null;
            ITextElement pTitleTextElem = null;
            ITextSymbol pSubTitleTextSym = null;
            ITextElement pSubTitleTextElem = null;

            try
            {
                // count line breaks in sTitle
                int iTitleLineBreaks = sTitle.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1;

                double dblXMin = 0; double dblXMax = 0; double dblYMin = 0; double dblYMax = 0;

                // do the title stuff
                dblXMin = SPrintConst.Title_XMin * base.XFactor; //(SPrintConst.MapFrame_XMax + SPrintConst.Title_XOffset) * base.XFactor;
                dblXMax = SPrintConst.Title_XMax * base.XFactor; //(SPrintConst.Neatline_XMax * base.XFactor);
                //dblYMin = (SPrintConst.Subtitle_YMax + SPrintConst.Title_XOffset) * base.YFactor;
                dblYMin = SPrintConst.Title_YMin * base.YFactor; //(SPrintConst.Title_YMin * base.YFactor);
                dblYMax = SPrintConst.Title_YMax * base.YFactor; //SPrintConst.Title_YMax * base.YFactor;

                if (sTitle.Length > 0)
                {
                    pTitleTextSym = oSpatialSubs.createTextSymbol(0, 0, 0, 16 * base.XFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                    pTitleTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pTitleTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sTitle);

                    //move the title right where we want it
                    oSpatialSubs.moveElementToXMinYmin(pTitleTextElem as IElement, dblXMin, dblYMax);
                }

                // do the subtitle stuff
                dblXMin = SPrintConst.Subtitle_XMin * base.XFactor;     //(SPrintConst.MapFrame_XMax + SPrintConst.Title_XOffset) * base.XFactor;
                dblXMax = SPrintConst.Subtitle_XMax * base.XFactor;     //(SPrintConst.Neatline_XMax * base.XFactor);
                //dblYMin = (SPrintConst.Legend_YMax + SPrintConst.Title_XOffset) * base.YFactor;
                dblYMin = SPrintConst.Subtitle_YMin * base.YFactor;     //(SPrintConst.Title_YMin - .20) * base.YFactor;
                dblYMax = SPrintConst.Subtitle_YMax * base.YFactor;     //SPrintConst.Subtitle_YMax * base.YFactor;

                if (sSubTitle.Length > 0)
                {
                    if (iTitleLineBreaks > 0)
                        dblYMin -= (.39 * base.YFactor);

                    pSubTitleTextSym = oSpatialSubs.createTextSymbol(108, 108, 108, 9 * base.XFactor, esriTextHorizontalAlignment.esriTHALeft, esriTextVerticalAlignment.esriTVATop, "Arial");
                    pSubTitleTextElem = oSpatialSubs.addTextToGraphicsContainer(pGC, pSubTitleTextSym, dblXMin, dblXMax, dblYMin, dblYMax, sSubTitle);

                    //move the title right where we want it
                    oSpatialSubs.moveElementToXMinYmin(pSubTitleTextElem as IElement, dblXMin, dblYMin);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errors: CLandscapeLayout:addTitles()\r\n" + ex.Message, "Errors occurred", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSpatialSubs.Dispose();
                pMxDoc = null;
                pGC = null;

                pTitleTextSym = null;
                pTitleTextElem = null;
                pSubTitleTextSym = null;
                pSubTitleTextElem = null;
            }
        }

        public override void addUserName()
        {
            base.addUserName();
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
                                                        SPrintConst.MapFrame_XMax * base.XFactor,
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

        private void addBottomLine()
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
                                                        SPrintConst.MapFrame_XMax * base.XFactor,
                                                        SPrintConst.Neatline_XMax * base.XFactor,
                                                        (SPrintConst.Name_YMin - .02)  * base.YFactor,
                                                        (SPrintConst.Name_YMin - .02) * base.YFactor);

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
