namespace CoM_GISTools.AddLayer
{
    partial class ucMapService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkMapService_ESRI_PopChange2009_2014 = new System.Windows.Forms.CheckBox();
            this.chkMapService_ESRI_PopChange2000_2009 = new System.Windows.Forms.CheckBox();
            this.chkMapService_ESRI_WorldImagery = new System.Windows.Forms.CheckBox();
            this.chkMapService_ESRI_TopographicMaps = new System.Windows.Forms.CheckBox();
            this.chkMapService_ESRI_BingMaps = new System.Windows.Forms.CheckBox();
            this.lblInfrastruct_Built = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.chkMapService_ESRI_PopChange2009_2014);
            this.panel1.Controls.Add(this.chkMapService_ESRI_PopChange2000_2009);
            this.panel1.Controls.Add(this.chkMapService_ESRI_WorldImagery);
            this.panel1.Controls.Add(this.chkMapService_ESRI_TopographicMaps);
            this.panel1.Controls.Add(this.chkMapService_ESRI_BingMaps);
            this.panel1.Controls.Add(this.lblInfrastruct_Built);
            this.panel1.Location = new System.Drawing.Point(13, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 547);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkMapService_ESRI_PopChange2009_2014
            // 
            this.chkMapService_ESRI_PopChange2009_2014.AutoSize = true;
            this.chkMapService_ESRI_PopChange2009_2014.Location = new System.Drawing.Point(46, 59);
            this.chkMapService_ESRI_PopChange2009_2014.Name = "chkMapService_ESRI_PopChange2009_2014";
            this.chkMapService_ESRI_PopChange2009_2014.Size = new System.Drawing.Size(176, 17);
            this.chkMapService_ESRI_PopChange2009_2014.TabIndex = 19;
            this.chkMapService_ESRI_PopChange2009_2014.Tag = "Demographics_USA_Projected_Population_Change";
            this.chkMapService_ESRI_PopChange2009_2014.Text = "2009 - 2014 Population Change";
            this.chkMapService_ESRI_PopChange2009_2014.UseVisualStyleBackColor = true;
            this.chkMapService_ESRI_PopChange2009_2014.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkMapService_ESRI_PopChange2000_2009
            // 
            this.chkMapService_ESRI_PopChange2000_2009.AutoSize = true;
            this.chkMapService_ESRI_PopChange2000_2009.Location = new System.Drawing.Point(46, 82);
            this.chkMapService_ESRI_PopChange2000_2009.Name = "chkMapService_ESRI_PopChange2000_2009";
            this.chkMapService_ESRI_PopChange2000_2009.Size = new System.Drawing.Size(176, 17);
            this.chkMapService_ESRI_PopChange2000_2009.TabIndex = 18;
            this.chkMapService_ESRI_PopChange2000_2009.Tag = "Demographics_USA_Recent_Population_Change";
            this.chkMapService_ESRI_PopChange2000_2009.Text = "2000 - 2009 Population Change";
            this.chkMapService_ESRI_PopChange2000_2009.UseVisualStyleBackColor = true;
            this.chkMapService_ESRI_PopChange2000_2009.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkMapService_ESRI_WorldImagery
            // 
            this.chkMapService_ESRI_WorldImagery.AutoSize = true;
            this.chkMapService_ESRI_WorldImagery.Location = new System.Drawing.Point(46, 105);
            this.chkMapService_ESRI_WorldImagery.Name = "chkMapService_ESRI_WorldImagery";
            this.chkMapService_ESRI_WorldImagery.Size = new System.Drawing.Size(94, 17);
            this.chkMapService_ESRI_WorldImagery.TabIndex = 16;
            this.chkMapService_ESRI_WorldImagery.Tag = "ESRI_Imagery_World_2D";
            this.chkMapService_ESRI_WorldImagery.Text = "World Imagery";
            this.chkMapService_ESRI_WorldImagery.UseVisualStyleBackColor = true;
            this.chkMapService_ESRI_WorldImagery.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkMapService_ESRI_TopographicMaps
            // 
            this.chkMapService_ESRI_TopographicMaps.AutoSize = true;
            this.chkMapService_ESRI_TopographicMaps.Location = new System.Drawing.Point(46, 128);
            this.chkMapService_ESRI_TopographicMaps.Name = "chkMapService_ESRI_TopographicMaps";
            this.chkMapService_ESRI_TopographicMaps.Size = new System.Drawing.Size(142, 17);
            this.chkMapService_ESRI_TopographicMaps.TabIndex = 14;
            this.chkMapService_ESRI_TopographicMaps.Tag = "USA_Topo_Maps";
            this.chkMapService_ESRI_TopographicMaps.Text = "USGS Topograhic Maps";
            this.chkMapService_ESRI_TopographicMaps.UseVisualStyleBackColor = true;
            this.chkMapService_ESRI_TopographicMaps.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkMapService_ESRI_BingMaps
            // 
            this.chkMapService_ESRI_BingMaps.AutoSize = true;
            this.chkMapService_ESRI_BingMaps.Location = new System.Drawing.Point(46, 36);
            this.chkMapService_ESRI_BingMaps.Name = "chkMapService_ESRI_BingMaps";
            this.chkMapService_ESRI_BingMaps.Size = new System.Drawing.Size(76, 17);
            this.chkMapService_ESRI_BingMaps.TabIndex = 7;
            this.chkMapService_ESRI_BingMaps.Tag = "Bing_Maps";
            this.chkMapService_ESRI_BingMaps.Text = "Bing Maps";
            this.chkMapService_ESRI_BingMaps.UseVisualStyleBackColor = true;
            this.chkMapService_ESRI_BingMaps.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblInfrastruct_Built
            // 
            this.lblInfrastruct_Built.AutoSize = true;
            this.lblInfrastruct_Built.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfrastruct_Built.Location = new System.Drawing.Point(14, 17);
            this.lblInfrastruct_Built.Name = "lblInfrastruct_Built";
            this.lblInfrastruct_Built.Size = new System.Drawing.Size(142, 16);
            this.lblInfrastruct_Built.TabIndex = 0;
            this.lblInfrastruct_Built.Text = "ESRI Map Services";
            // 
            // ucMapService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucMapService";
            this.Size = new System.Drawing.Size(573, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkMapService_ESRI_PopChange2009_2014;
        private System.Windows.Forms.CheckBox chkMapService_ESRI_PopChange2000_2009;
        private System.Windows.Forms.CheckBox chkMapService_ESRI_WorldImagery;
        private System.Windows.Forms.CheckBox chkMapService_ESRI_TopographicMaps;
        private System.Windows.Forms.CheckBox chkMapService_ESRI_BingMaps;
        private System.Windows.Forms.Label lblInfrastruct_Built;
    }
}
