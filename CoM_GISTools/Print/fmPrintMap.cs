using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using System.Collections;
using System.Drawing.Printing;
using ESRI.ArcGIS;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ArcMap;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;

namespace CoM_GISTools.Print
{
    public partial class fmPrintMap : Form
    {
        private IApplication m_pApp;
        private Double m_dblMapScale;
        private bool m_bShowPrintDialog;

        public ESRI.ArcGIS.Framework.IApplication App
        {
            get { return this.m_pApp; }
            set { this.m_pApp = value; }
        }

        public fmPrintMap()
        {
            InitializeComponent();
            m_dblMapScale = 0;
            m_bShowPrintDialog = false;
        }

        private void fmPrintMap_Load(object sender, EventArgs e)
        {
            if (!checkLayers())
                this.Dispose();

            resetForm();
            //loadMapSize();
            loadOrientation();
            loadMapScale();
            loadMapLayers();
            loadPrinters();

            this.txtTitle.Focus();
        }

        private void loadPrinters()
        {
            System.Drawing.Printing.PrintDocument prtdoc = new System.Drawing.Printing.PrintDocument();
            //string sDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String sPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters) 
            {
                cboPrinters.Items.Add(sPrinter);
                //if (sPrinter == sDefaultPrinter)
                //{
                //    cboPrinters.SelectedIndex = cboPrinters.Items.IndexOf(sPrinter);
                //}
            }
        }

        private void loadMapSize()
        {
            try
            {
                for (int i = 0; i < SPrintConst.MapSize.Count; i++)
                {
                    if (printerPageAreCompatible(this.cboPrinters.SelectedItem.ToString(), SPrintConst.MapSize[i].ToString()))
                    {
                        this.cboMapSize.Items.Add(SPrintConst.MapSize[i].ToString());
                    }
                }
                if (this.cboMapSize.Items.Count > 0)
                {
                    this.cboMapSize.SelectedIndex = this.cboMapSize.Items.Count - 1;
                    this.cboMapSize.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void loadOrientation()
        {
            try 
            {
                string[] Orientation = Enum.GetNames(typeof(SPrintConst.Orientation));
                for (int i = 0; i < Orientation.Length; i++)
                {
                    this.cboOrientation.Items.Add(Orientation[i].ToString());
                }
                this.cboOrientation.SelectedIndex = this.cboOrientation.Items.Count - 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void loadMapScale()
        {
            try 
            {
                this.cboMapScale.Items.Clear();

                foreach (KeyValuePair<string, string> kvpair in SPrintConst.MapScale)
                {
                    double dblTemp = Math.Round(Double.Parse(kvpair.Value));
                    //string s = String.Format("{0:0,0}", kvpair.Value);
                    string s = dblTemp.ToString("0,0");
                    this.cboMapScale.Items.Add(s);
                }

                IMxDocument pMxDoc = (IMxDocument)this.m_pApp.Document;
                IMap pMap = (IMap)pMxDoc.ActiveView.FocusMap;

                //this.cboMapScale.Items.Add(Math.Round(pMap.MapScale).ToString());
                //double dblCurrentScale = Math.Round(pMap.MapScale)
                this.cboMapScale.Items.Add(Math.Round(pMap.MapScale).ToString("0,0"));
                this.cboMapScale.SelectedIndex = this.cboMapScale.Items.Count-1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void loadMapLayers()
        {
            IMxDocument pMxDoc = (IMxDocument)this.m_pApp.Document;
            IMap pMap = (IMap)pMxDoc.ActiveView.FocusMap;
            IEnumLayer pEnumLayers = pMap.get_Layers(null, false);

            try
            {
                ILayer pLayer = pEnumLayers.Next();
                while (pLayer != null)
                {
                    if (pLayer.Visible)
                    {
                        this.lbMapLayers.Items.Add(pLayer.Name);
                    }
                    pLayer = pEnumLayers.Next();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                pMxDoc = null;
                pMap = null;
                pEnumLayers = null;
            }
        }

        private bool checkLayers()
        {
            IMxDocument pMxDoc = (IMxDocument)this.m_pApp.Document;
            IMap pMap = (IMap)pMxDoc.ActiveView.FocusMap;

            try
            {
                if (pMap.LayerCount < 1)
                {
                    MessageBox.Show("There are no layers in this map.", "Print Map: No Layers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                pMxDoc = null;
                pMap = null;
            }
        }

        private void resetForm()
        {
            this.txtSubTitle.Text = "";
            this.txtTitle.Text = "";
            this.lbLegendLayers.Items.Clear();
            this.lblErrMapScale.Visible = false;
            this.lblErrMapSize.Visible = false;
            this.lblErrOrientation.Visible = false;
            this.lblErrSubTitle.Visible = false;
            this.lblErrTitle.Visible = false;
        }

        private bool validateUserSelections()
        {
            bool bRetVal = true;

            if (bRetVal)
            {
                // check the map scale
                try { Double.Parse(this.cboMapScale.Text); }
                catch
                {
                    this.lblErrMapScale.Visible = true;
                    this.cboMapScale.BackColor = Color.Red;
                    MessageBox.Show("Map scale must be numeric.", "Map Scale Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bRetVal = false;
                }
            }

            if (bRetVal)
            {
                int iTitleLineBreaks = this.txtTitle.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1;
                if (iTitleLineBreaks > 1)
                {
                    System.Windows.Forms.MessageBox.Show("Title can only have 2 lines.", "Title Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bRetVal = false;
                }   
            }

            if (bRetVal)
            {
                int iSubTitleLineBreaks = this.txtSubTitle.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1;
                if (iSubTitleLineBreaks > 1)
                {
                    System.Windows.Forms.MessageBox.Show("Sub Title can only have 2 lines.", "Sub Title Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bRetVal = false;
                }
            }

            if (bRetVal)
            {
                string[] aTitle = Regex.Split(this.txtTitle.Text,"\r\n");
                for (int i = 0; i < aTitle.Length; i++)
                {
                    if (aTitle[i].ToString().Length > 20)
                    {
                        System.Windows.Forms.MessageBox.Show("Title lines cannot be longer than 20 characters.", "Title Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bRetVal = false;
                        break;
                    }
                }
            }

            if (bRetVal)
            {
                string[] aSubTitle = Regex.Split(this.txtSubTitle.Text, "\r\n");
                for (int i = 0; i < aSubTitle.Length; i++)
                {
                    if (aSubTitle[i].ToString().Length > 25)
                    {
                        System.Windows.Forms.MessageBox.Show("Sub Title lines cannot be longer than 20 characters.", "Sub Title Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bRetVal = false;
                        break;
                    }
                }
            }

            if (bRetVal)
            {
                if (this.cboPrinters.SelectedItem == null)
                {
                    System.Windows.Forms.MessageBox.Show("Please select a printer from the printer list.", "Printer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bRetVal = false;
                }

            }

            //if (bRetVal)
            //{
            //    if (! printerPageAreCompatible(this.cboPrinters.SelectedItem.ToString(), this.cboMapSize.SelectedItem.ToString()))
            //    {
            //        System.Windows.Forms.MessageBox.Show("The selected printer does not support the selected map size.", "Printer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        bRetVal = false;

            //    }
            //}

            return bRetVal;
        }

        private List<string> getLegendLayers()
        {
            List<string> lstLegendLayers = new List<string>();
            for (int i = 0; i < this.lbLegendLayers.Items.Count; i++)
            {
                lstLegendLayers.Add(this.lbLegendLayers.Items[i].ToString());
            }

            if (lstLegendLayers.Count > 0)
                return lstLegendLayers;
            else
                return null;
        }

        private void btnAddAllLayers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lbMapLayers.Items.Count; i++)
            {
                this.lbLegendLayers.Items.Add(this.lbMapLayers.Items[i].ToString());
            }
            this.lbMapLayers.Items.Clear();
        }

        private void btnRemoveAllLayers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lbLegendLayers.Items.Count; i++)
            {
                this.lbMapLayers.Items.Add(this.lbLegendLayers.Items[i].ToString());
            }
            this.lbLegendLayers.Items.Clear();
        }

        private void btnAddSelectedLayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbMapLayers.SelectedItem.ToString().Length > 0)
                {
                    // add the layers in the legend layers
                    foreach (System.Object itm in lbMapLayers.SelectedItems)
                    {
                        this.lbLegendLayers.Items.Add(itm.ToString());
                    }

                    // remove the layers in the map layers
                    foreach (System.Object itm in lbLegendLayers.Items)
                    {
                        if (this.lbMapLayers.Items.Contains(itm.ToString()))
                            this.lbMapLayers.Items.Remove(itm.ToString());
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnRemoveSelectedLayer_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.lbLegendLayers.SelectedItem.ToString().Length > 0)
                //{
                //    this.lbMapLayers.Items.Add(this.lbLegendLayers.SelectedItem.ToString());
                //    this.lbLegendLayers.Items.RemoveAt(this.lbLegendLayers.SelectedIndex);
                //}

                foreach (System.Object itm in lbLegendLayers.SelectedItems)
                {
                    this.lbMapLayers.Items.Add(itm.ToString());
                }

                // remove the layers in the map layers
                foreach (System.Object itm in lbMapLayers.Items)
                {
                    if (this.lbLegendLayers.Items.Contains(itm.ToString()))
                        this.lbLegendLayers.Items.Remove(itm.ToString());
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (validateUserSelections())
            {
                //setLayoutConstants(this.cboOrientation.SelectedItem.ToString());

                m_bShowPrintDialog = true;

                List<string> lstLegendLayers = getLegendLayers();

                if (this.cboOrientation.SelectedItem.ToString().ToUpper() == "LANDSCAPE")
                {
                    try
                    {
                        CLandscapeLayout oLandscapeLayout = new CLandscapeLayout(this.App, lstLegendLayers,
                                                                        Math.Round(Double.Parse(this.cboMapScale.Text.ToString())),
                                                                        this.cboMapSize.SelectedItem.ToString(),
                                                                        this.txtTitle.Text,
                                                                        this.txtSubTitle.Text,
                                                                        this.cboOrientation.SelectedItem.ToString(),
                                                                        this.cboPrinters.SelectedItem.ToString());
                        try
                        {
                            oLandscapeLayout.setConstants();
                            oLandscapeLayout.deleteMapSurrounds();
                            oLandscapeLayout.adjustMapFrame();
                            //loadMapScale();
                            oLandscapeLayout.addNeatline();
                            oLandscapeLayout.addSeperatorLine();
                            oLandscapeLayout.addScaleBar();
                            oLandscapeLayout.addMedfordRectangle();
                            oLandscapeLayout.addMedfordText();
                            //oLandscapeLayout.addMedGISText((oLandscapeLayout.XFactor * SPrintConst.MapFrame_XMax),
                            //                                (oLandscapeLayout.XFactor * SPrintConst.Neatline_XMax),
                            //                                (oLandscapeLayout.YFactor * (SPrintConst.Neatline_YMax - SPrintConst.MedGISText_YMax)),
                            //                                (oLandscapeLayout.YFactor * (SPrintConst.Neatline_YMax - SPrintConst.MedGISText_YMin)));
                            oLandscapeLayout.addMedGISText((oLandscapeLayout.XFactor * SPrintConst.MapFrame_XMax),
                                                            (oLandscapeLayout.XFactor * SPrintConst.Neatline_XMax),
                                                            (oLandscapeLayout.YFactor * SPrintConst.MedGISText_YMin),
                                                            (oLandscapeLayout.YFactor * SPrintConst.MedGISText_YMax));

                            oLandscapeLayout.addDisclaimer();
                            oLandscapeLayout.addRecyclingInfo();
                            oLandscapeLayout.addDateName();
                            oLandscapeLayout.addLogo();
                            oLandscapeLayout.addNorthArrow();
                            oLandscapeLayout.addTitles(this.txtTitle.Text, this.txtSubTitle.Text);
                            oLandscapeLayout.addLegend();
                            oLandscapeLayout.addUserName();
                            //oLandscapeLayout.adjustPaperSize();
                            oLandscapeLayout.unselectAllGraphics();

                        }
                        catch
                        {

                        }
                        finally
                        {
                            oLandscapeLayout.refreshLayout();
                            oLandscapeLayout.Dispose();
                        }

                        //175:     pLayoutBuilder.addLegend
                        //176:     pLayoutBuilder.unselectAllGraphicElements
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }

                }
                else if (this.cboOrientation.SelectedItem.ToString().ToUpper() == "PORTRAIT")
                {
                    try
                    {
                        CPortraitLayout oPortratitLayout = new CPortraitLayout(this.App, lstLegendLayers,
                                                                            Math.Round(Double.Parse(this.cboMapScale.Text.ToString())),
                                                                            this.cboMapSize.SelectedItem.ToString(),
                                                                            this.txtTitle.Text,
                                                                            this.txtSubTitle.Text,
                                                                            this.cboOrientation.SelectedItem.ToString(),
                                                                            this.cboPrinters.SelectedItem.ToString());
                        try
                        {
                            oPortratitLayout.setConstants();
                            oPortratitLayout.deleteMapSurrounds();
                            oPortratitLayout.adjustMapFrame();
                            //loadMapScale();
                            oPortratitLayout.addNeatline();
                            oPortratitLayout.addSeperatorLine();
                            oPortratitLayout.addScaleBar();
                            oPortratitLayout.addMedfordRectangle();
                            oPortratitLayout.addMedfordText();
                            oPortratitLayout.addMedGISText((oPortratitLayout.XFactor * SPrintConst.MedGISText_XMin),
                                                            (oPortratitLayout.XFactor * SPrintConst.MedGISText_XMax),
                                                            (oPortratitLayout.YFactor * SPrintConst.MedGISText_YMin),
                                                            (oPortratitLayout.YFactor * SPrintConst.MedGISText_YMax));
                            oPortratitLayout.addDisclaimer();
                            oPortratitLayout.addRecyclingInfo();
                            oPortratitLayout.addDateName();
                            oPortratitLayout.addLogo();
                            oPortratitLayout.addNorthArrow();
                            oPortratitLayout.addTitles(this.txtTitle.Text, this.txtSubTitle.Text);
                            oPortratitLayout.addLegend();
                            oPortratitLayout.addUserName();
                            //oPortratitLayout.adjustPaperSize();
                            oPortratitLayout.unselectAllGraphics();

                        }
                        catch
                        {

                        }
                        finally
                        {
                            oPortratitLayout.refreshLayout();
                            oPortratitLayout.Dispose();
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bShowPrintDialog = false;
            this.Dispose();
        }

        private void radLandscape_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radPortrait_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cboOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void showPageSettingDialog(string sPrinterName)
        {
            //// create and show... 
            //PrintDialog dialog = new PrintDialog();
            //dialog.ShowDialog();

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IPageLayout pPageLayout = (IPageLayout)pMxDoc.PageLayout;
            IPage pPage = (IPage) pPageLayout.Page;

            //IMxApplication pMxApp = (IMxApplication)this.App;
            //pMxApp.Paper.PrinterName = sPrinterName;

            ESRI.ArcGIS.OutputUI.IPageSetupDialog pPageSetup = new ESRI.ArcGIS.OutputUI.PageSetupDialogClass();
            bool bSetup = pPageSetup.DoModal(0, pPage);

        }

        private void showPrintDialog(string sPrinterName)
        {

            //System.Windows.Forms.MessageBox.Show("OOPS!!!! Keith , I found a bug here  at the last minute.Go to File --> Print to print. Sorry.", "OOPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //// create and show... 

            IMxDocument pMxDoc = (IMxDocument)this.App.Document;
            IPage pPage = (IPage)pMxDoc.PageLayout.Page;

            CSpatialSubs oSpatialSubs = new CSpatialSubs();
            IMxApplication pMxApp = (IMxApplication)this.App;

            ESRI.ArcGIS.Output.IPrinter pPrinter = pMxApp.Printer;
            ESRI.ArcGIS.Output.IPaper pPaper = pPrinter.Paper;

            int iPageFormID = 0;   // see http://msdn.microsoft.com/en-us/library/ms776398(VS.85).aspx for IPaper::FormID constants

            pMxDoc.PageLayout.Page.Orientation = 2;
            pPaper.Orientation = 2;

            ESRI.ArcGIS.OutputUI.IPrintDialog dialog = new ESRI.ArcGIS.OutputUI.PrintDialogClass();
            dialog.PageLayout = pMxDoc.PageLayout;
            dialog.Printer = pMxApp.Printer;
            dialog.DoModal(0, pPage);
           


            //dialog.Printer.Paper.PrinterName = sPrinterName;
            //dialog.Printer.Paper.FormID = (short)iPageFormID;
            //dialog.DoModal(0,pPage);


            //switch (this.cboMapSize.SelectedItem.ToString())
            //{
            //    case "34 x 44": //34 x 44
            //        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
            //            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "34 x 44");
            //        else
            //            iPageFormID = 26;
            //        break;
            //    case "17 x 22": // 17 x 22
            //        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
            //            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "17 x 22");
            //        else
            //            iPageFormID = 24;
            //        break;
            //    case "11 x 17": // 11 x 22
            //        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
            //            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "11 x 17");
            //        else
            //            iPageFormID = 17;
            //        break;
            //    case "8.5 x 11": // 8.5 x 11
            //        if (pPrinter.DriverName.ToUpper().Contains("DESIGNJET"))
            //            iPageFormID = oSpatialSubs.getPaperFormID(pPaper, "8.5 x 11");
            //        else
            //            iPageFormID = 1;
            //        break;
            //}
        
        }


        private void fmPrintMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bShowPrintDialog)
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrinterSettings.PrinterName = cboPrinters.SelectedItem.ToString();

                System.Drawing.Printing.PaperSize pkSize = new System.Drawing.Printing.PaperSize();

                //bool bPaperSizeAllowed = false;
                //string sPaperSizes = "";

                //for (int i = 0; i < pd.PrinterSettings.PaperSizes.Count; i++)
                //{
                //    //System.Windows.Forms.MessageBox.Show(pd.PrinterSettings.PaperSizes[i].PaperName.ToString());
                //    if (pd.PrinterSettings.PaperSizes[i].PaperName.Contains(this.cboMapSize.SelectedItem.ToString()))
                //    {
                //        bPaperSizeAllowed = true;
                //        //break;
                        
                //    }
                //}
                
                if (System.Windows.Forms.MessageBox.Show("Would you like to print this map now?", "Medford Print Map", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    object missing = Type.Missing;
                    //if (bPaperSizeAllowed)
                    showPrintDialog(cboPrinters.SelectedItem.ToString()); //this.App.ShowDialog((int)esriMxDlgIDs.esriMxDlgPrintSetup, ref missing);    //
                    //else
                    //    this.App.ShowDialog((int)esriMxDlgIDs.esriMxDlgPageSetup,ref missing);    //showPageSettingDialog(cboPrinters.SelectedItem.ToString());
                }
                //System.Windows.Forms.MessageBox.Show(sPaperSizes);

            }
        }


        private bool printerPageAreCompatible(string sPrinterName, string sMapSize)
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrinterSettings.PrinterName = sPrinterName;

            //System.Drawing.Printing.PaperSize pkSize = new System.Drawing.Printing.PaperSize();
            //pkSize = (System.Drawing.Printing.PaperSize)pd.PrinterSettings.PaperSizes;

            int iPaperHeight = 0;
            int iPaperWidth = 0;
            bool bPaperSizeAllowed = false;

            for (int i = 0; i < pd.PrinterSettings.PaperSizes.Count; i++)
            {
                if (pd.PrinterSettings.PaperSizes[i].PaperName.Contains(sMapSize))
                {
                    bPaperSizeAllowed = true;
                    break;
                }
            }

            return bPaperSizeAllowed;
        }

        private void cboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iMaxPaperHeight = 0;
            int iMaxPaperWidth = 0;

            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            System.Drawing.Printing.PaperSize pkSize = new System.Drawing.Printing.PaperSize();

            this.cboMapSize.Items.Clear();
            this.cboMapSize.Enabled = false;

            pd.PrinterSettings.PrinterName = this.cboPrinters.SelectedItem.ToString();
                
            foreach(PaperSize psize in pd.PrinterSettings.PaperSizes)
            {
                if (psize.Width > iMaxPaperWidth) iMaxPaperWidth = psize.Width;
                if (psize.Height > iMaxPaperHeight) iMaxPaperHeight = psize.Height;
            }

            if ((iMaxPaperWidth * .01) > 8.5)
            {
                if ((iMaxPaperWidth * .01) > 11.69)
                {
                    if ((iMaxPaperWidth * .01) > 17)
                    {
                        this.cboMapSize.Items.Add("8.5 x 11");
                        this.cboMapSize.Items.Add("11 x 17");
                        this.cboMapSize.Items.Add("17 x 22");
                        this.cboMapSize.Items.Add("34 x 44");
                    }
                    else
                    {
                        this.cboMapSize.Items.Add("8.5 x 11");
                        this.cboMapSize.Items.Add("11 x 17");
                        this.cboMapSize.Items.Add("17 x 22");
                    }
                }
                else
                {
                    this.cboMapSize.Items.Add("8.5 x 11");
                    this.cboMapSize.Items.Add("11 x 17");
                }
            }
            else
            {
                this.cboMapSize.Items.Add("8.5 x 11");
            }

            this.cboMapSize.Enabled = true;
            this.cboMapSize.SelectedIndex = 0; // this.cboMapSize.Items.Count - 1;
        }

        private void lbMapLayers_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbMapLayers.SelectedItem != null)
            {
                if (this.lbMapLayers.SelectedItem.ToString().Length != 0)
                {
                    this.lbLegendLayers.Items.Add(this.lbMapLayers.SelectedItem.ToString());
                    this.lbMapLayers.Items.Remove(this.lbMapLayers.SelectedItem.ToString());
                }
            }
        }

        private void lbLegendLayers_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbLegendLayers.SelectedItem != null)
            {
                if (this.lbLegendLayers.SelectedItem.ToString().Length != 0)
                {
                    this.lbMapLayers.Items.Add(this.lbLegendLayers.SelectedItem.ToString());
                    this.lbLegendLayers.Items.Remove(this.lbLegendLayers.SelectedItem.ToString());
                }
            }
        }
    }
}