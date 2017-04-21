using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoM_GISTools.Print
{
    public partial class fmMapScale : Form
    {
        private double m_dblMapScale;
        public double MapScale
        {
            get { return m_dblMapScale; }
            set { this.m_dblMapScale = value; }
        }
 
        public fmMapScale()
        {
            InitializeComponent();
        }


        private void loadMapScale()
        {
            try
            {
                foreach (KeyValuePair<string, string> kvpair in SPrintConst.MapScale)
                {
                    this.cboNewMapScale.Items.Add(Double.Parse(kvpair.Value).ToString("0,0"));
                }
                //this.cboNewMapScale.Items.Add(Math.Round(this.MapScale).ToString("0,0"));
                this.cboNewMapScale.SelectedIndex = this.cboNewMapScale.Items.Count - 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnChangeMapScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboNewMapScale.Text.ToString().Length > 0)
                    this.MapScale = Double.Parse(this.cboNewMapScale.Text.ToString());
            }
            catch
            {
                this.MapScale = 0;
            }
            finally
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmMapScale_Load(object sender, EventArgs e)
        {
            this.loadMapScale();
        }

    }
}