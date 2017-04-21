namespace CoM_GISTools.AddLayer
{
    partial class ucSoilsTopo
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
            System.Windows.Forms.CheckBox chkSoilsTopo_Soils_SoilsIrrig;
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSoilsTopo_Soils_SoilsBySlope = new System.Windows.Forms.CheckBox();
            this.chkSoilsTopo_Soils_SoilsNonIrrig = new System.Windows.Forms.CheckBox();
            this.lblSoilsTopo_Soils = new System.Windows.Forms.Label();
            this.chkSoilsTopo_Contour_40Ft = new System.Windows.Forms.CheckBox();
            this.chkSoilsTopo_Contour_10Ft = new System.Windows.Forms.CheckBox();
            this.chkSoilsTopo_Soils_Soils = new System.Windows.Forms.CheckBox();
            this.chkSoilsTopo_Contour_2Ft = new System.Windows.Forms.CheckBox();
            this.lblSoilsTopo_Contours = new System.Windows.Forms.Label();
            this.chkSoilsTopo_Contour_10Ft_CountyWide = new System.Windows.Forms.CheckBox();
            chkSoilsTopo_Soils_SoilsIrrig = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSoilsTopo_Soils_SoilsIrrig
            // 
            chkSoilsTopo_Soils_SoilsIrrig.AutoSize = true;
            chkSoilsTopo_Soils_SoilsIrrig.Location = new System.Drawing.Point(46, 59);
            chkSoilsTopo_Soils_SoilsIrrig.Name = "chkSoilsTopo_Soils_SoilsIrrig";
            chkSoilsTopo_Soils_SoilsIrrig.Size = new System.Drawing.Size(131, 17);
            chkSoilsTopo_Soils_SoilsIrrig.TabIndex = 15;
            chkSoilsTopo_Soils_SoilsIrrig.Tag = "Soils_by_Irrigated_Class";
            chkSoilsTopo_Soils_SoilsIrrig.Text = "Soils by Irrigated Class";
            chkSoilsTopo_Soils_SoilsIrrig.UseVisualStyleBackColor = true;
            chkSoilsTopo_Soils_SoilsIrrig.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.chkSoilsTopo_Contour_10Ft_CountyWide);
            this.panel1.Controls.Add(this.chkSoilsTopo_Soils_SoilsBySlope);
            this.panel1.Controls.Add(this.chkSoilsTopo_Soils_SoilsNonIrrig);
            this.panel1.Controls.Add(this.lblSoilsTopo_Soils);
            this.panel1.Controls.Add(this.chkSoilsTopo_Contour_40Ft);
            this.panel1.Controls.Add(this.chkSoilsTopo_Contour_10Ft);
            this.panel1.Controls.Add(this.chkSoilsTopo_Soils_Soils);
            this.panel1.Controls.Add(chkSoilsTopo_Soils_SoilsIrrig);
            this.panel1.Controls.Add(this.chkSoilsTopo_Contour_2Ft);
            this.panel1.Controls.Add(this.lblSoilsTopo_Contours);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 547);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkSoilsTopo_Soils_SoilsBySlope
            // 
            this.chkSoilsTopo_Soils_SoilsBySlope.AutoSize = true;
            this.chkSoilsTopo_Soils_SoilsBySlope.Location = new System.Drawing.Point(46, 105);
            this.chkSoilsTopo_Soils_SoilsBySlope.Name = "chkSoilsTopo_Soils_SoilsBySlope";
            this.chkSoilsTopo_Soils_SoilsBySlope.Size = new System.Drawing.Size(92, 17);
            this.chkSoilsTopo_Soils_SoilsBySlope.TabIndex = 39;
            this.chkSoilsTopo_Soils_SoilsBySlope.Tag = "Soils_by_Slope";
            this.chkSoilsTopo_Soils_SoilsBySlope.Text = "Soils by Slope";
            this.chkSoilsTopo_Soils_SoilsBySlope.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Soils_SoilsBySlope.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSoilsTopo_Soils_SoilsNonIrrig
            // 
            this.chkSoilsTopo_Soils_SoilsNonIrrig.AutoSize = true;
            this.chkSoilsTopo_Soils_SoilsNonIrrig.Location = new System.Drawing.Point(46, 82);
            this.chkSoilsTopo_Soils_SoilsNonIrrig.Name = "chkSoilsTopo_Soils_SoilsNonIrrig";
            this.chkSoilsTopo_Soils_SoilsNonIrrig.Size = new System.Drawing.Size(150, 17);
            this.chkSoilsTopo_Soils_SoilsNonIrrig.TabIndex = 38;
            this.chkSoilsTopo_Soils_SoilsNonIrrig.Tag = "Soils_by_Nonirrigated_Class";
            this.chkSoilsTopo_Soils_SoilsNonIrrig.Text = "Soils by Nonirrigated Class";
            this.chkSoilsTopo_Soils_SoilsNonIrrig.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Soils_SoilsNonIrrig.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblSoilsTopo_Soils
            // 
            this.lblSoilsTopo_Soils.AutoSize = true;
            this.lblSoilsTopo_Soils.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoilsTopo_Soils.Location = new System.Drawing.Point(14, 17);
            this.lblSoilsTopo_Soils.Name = "lblSoilsTopo_Soils";
            this.lblSoilsTopo_Soils.Size = new System.Drawing.Size(135, 16);
            this.lblSoilsTopo_Soils.TabIndex = 28;
            this.lblSoilsTopo_Soils.Text = "Soils Information   ";
            // 
            // chkSoilsTopo_Contour_40Ft
            // 
            this.chkSoilsTopo_Contour_40Ft.AutoSize = true;
            this.chkSoilsTopo_Contour_40Ft.Location = new System.Drawing.Point(46, 267);
            this.chkSoilsTopo_Contour_40Ft.Name = "chkSoilsTopo_Contour_40Ft";
            this.chkSoilsTopo_Contour_40Ft.Size = new System.Drawing.Size(363, 17);
            this.chkSoilsTopo_Contour_40Ft.TabIndex = 19;
            this.chkSoilsTopo_Contour_40Ft.Tag = "40_Foot_Contours";
            this.chkSoilsTopo_Contour_40Ft.Text = "40 foot contour intervals - minimum scale: 1 inch = 4,000 feet (1:48,000)";
            this.chkSoilsTopo_Contour_40Ft.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Contour_40Ft.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSoilsTopo_Contour_10Ft
            // 
            this.chkSoilsTopo_Contour_10Ft.AutoSize = true;
            this.chkSoilsTopo_Contour_10Ft.Location = new System.Drawing.Point(46, 221);
            this.chkSoilsTopo_Contour_10Ft.Name = "chkSoilsTopo_Contour_10Ft";
            this.chkSoilsTopo_Contour_10Ft.Size = new System.Drawing.Size(363, 17);
            this.chkSoilsTopo_Contour_10Ft.TabIndex = 18;
            this.chkSoilsTopo_Contour_10Ft.Tag = "10_Foot_Contours";
            this.chkSoilsTopo_Contour_10Ft.Text = "10 foot contour intervals - minimum scale: 1 inch = 1,000 feet (1:12,000)";
            this.chkSoilsTopo_Contour_10Ft.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Contour_10Ft.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSoilsTopo_Soils_Soils
            // 
            this.chkSoilsTopo_Soils_Soils.AutoSize = true;
            this.chkSoilsTopo_Soils_Soils.Location = new System.Drawing.Point(46, 36);
            this.chkSoilsTopo_Soils_Soils.Name = "chkSoilsTopo_Soils_Soils";
            this.chkSoilsTopo_Soils_Soils.Size = new System.Drawing.Size(48, 17);
            this.chkSoilsTopo_Soils_Soils.TabIndex = 16;
            this.chkSoilsTopo_Soils_Soils.Tag = "Soils";
            this.chkSoilsTopo_Soils_Soils.Text = "Soils";
            this.chkSoilsTopo_Soils_Soils.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Soils_Soils.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSoilsTopo_Contour_2Ft
            // 
            this.chkSoilsTopo_Contour_2Ft.AutoSize = true;
            this.chkSoilsTopo_Contour_2Ft.Location = new System.Drawing.Point(46, 198);
            this.chkSoilsTopo_Contour_2Ft.Name = "chkSoilsTopo_Contour_2Ft";
            this.chkSoilsTopo_Contour_2Ft.Size = new System.Drawing.Size(348, 17);
            this.chkSoilsTopo_Contour_2Ft.TabIndex = 7;
            this.chkSoilsTopo_Contour_2Ft.Tag = "2_Foot_Contours";
            this.chkSoilsTopo_Contour_2Ft.Text = "2 foot contour intervals  -  minimum scale: 1 inch = 500 feet (1:6,000)";
            this.chkSoilsTopo_Contour_2Ft.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Contour_2Ft.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblSoilsTopo_Contours
            // 
            this.lblSoilsTopo_Contours.AutoSize = true;
            this.lblSoilsTopo_Contours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoilsTopo_Contours.Location = new System.Drawing.Point(14, 179);
            this.lblSoilsTopo_Contours.Name = "lblSoilsTopo_Contours";
            this.lblSoilsTopo_Contours.Size = new System.Drawing.Size(102, 16);
            this.lblSoilsTopo_Contours.TabIndex = 0;
            this.lblSoilsTopo_Contours.Text = "Contour Lines";
            // 
            // chkSoilsTopo_Contour_10Ft_CountyWide
            // 
            this.chkSoilsTopo_Contour_10Ft_CountyWide.AutoSize = true;
            this.chkSoilsTopo_Contour_10Ft_CountyWide.Location = new System.Drawing.Point(46, 244);
            this.chkSoilsTopo_Contour_10Ft_CountyWide.Name = "chkSoilsTopo_Contour_10Ft_CountyWide";
            this.chkSoilsTopo_Contour_10Ft_CountyWide.Size = new System.Drawing.Size(204, 17);
            this.chkSoilsTopo_Contour_10Ft_CountyWide.TabIndex = 40;
            this.chkSoilsTopo_Contour_10Ft_CountyWide.Tag = "10_Foot_Contours_County_Wide";
            this.chkSoilsTopo_Contour_10Ft_CountyWide.Text = "10 foot contour intervals - Countywide";
            this.chkSoilsTopo_Contour_10Ft_CountyWide.UseVisualStyleBackColor = true;
            this.chkSoilsTopo_Contour_10Ft_CountyWide.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ucSoilsTopo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucSoilsTopo";
            this.Size = new System.Drawing.Size(573, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Soils_SoilsBySlope;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Soils_SoilsNonIrrig;
        private System.Windows.Forms.Label lblSoilsTopo_Soils;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Contour_40Ft;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Contour_10Ft;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Soils_Soils;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Contour_2Ft;
        private System.Windows.Forms.Label lblSoilsTopo_Contours;
        private System.Windows.Forms.CheckBox chkSoilsTopo_Contour_10Ft_CountyWide;
    }
}
