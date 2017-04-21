namespace CoM_GISTools.AddLayer
{
    partial class fmAddLayers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddLayers));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlValidator = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBoundaries = new System.Windows.Forms.ToolStripButton();
            this.tsbCensus = new System.Windows.Forms.ToolStripButton();
            this.tsbEmergency = new System.Windows.Forms.ToolStripButton();
            this.tsbEnvironment = new System.Windows.Forms.ToolStripButton();
            this.tsbInfrastructure = new System.Windows.Forms.ToolStripButton();
            this.tspMapServices = new System.Windows.Forms.ToolStripButton();
            this.tsbPhoto = new System.Windows.Forms.ToolStripButton();
            this.tsbServiceDistricts = new System.Windows.Forms.ToolStripButton();
            this.tsbSoils = new System.Windows.Forms.ToolStripButton();
            this.tsbStructures = new System.Windows.Forms.ToolStripButton();
            this.tsbTaxlots = new System.Windows.Forms.ToolStripButton();
            this.tsbTransportation = new System.Windows.Forms.ToolStripButton();
            this.tsbUtility = new System.Windows.Forms.ToolStripButton();
            this.tsbWater = new System.Windows.Forms.ToolStripButton();
            this.tsbZoning = new System.Windows.Forms.ToolStripButton();
            this.tsbEditor = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.MaximumSize = new System.Drawing.Size(754, 600);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(754, 600);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.pnlValidator);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(754, 600);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlValidator
            // 
            this.pnlValidator.Location = new System.Drawing.Point(13, 497);
            this.pnlValidator.Name = "pnlValidator";
            this.pnlValidator.Size = new System.Drawing.Size(47, 18);
            this.pnlValidator.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBoundaries,
            this.tsbCensus,
            this.tsbEmergency,
            this.tsbEnvironment,
            this.tsbInfrastructure,
            this.tspMapServices,
            this.tsbPhoto,
            this.tsbServiceDistricts,
            this.tsbSoils,
            this.tsbStructures,
            this.tsbTaxlots,
            this.tsbTransportation,
            this.tsbUtility,
            this.tsbWater,
            this.tsbZoning,
            this.tsbEditor});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(151, 366);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBoundaries
            // 
            this.tsbBoundaries.AutoSize = false;
            this.tsbBoundaries.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbBoundaries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBoundaries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBoundaries.Name = "tsbBoundaries";
            this.tsbBoundaries.Padding = new System.Windows.Forms.Padding(3);
            this.tsbBoundaries.Size = new System.Drawing.Size(150, 20);
            this.tsbBoundaries.Tag = "CoM_GISTools.AddLayer.ucBoundaries";
            this.tsbBoundaries.Text = "Boundaries";
            this.tsbBoundaries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbBoundaries.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbCensus
            // 
            this.tsbCensus.AutoSize = false;
            this.tsbCensus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCensus.Image = ((System.Drawing.Image)(resources.GetObject("tsbCensus.Image")));
            this.tsbCensus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCensus.Name = "tsbCensus";
            this.tsbCensus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tsbCensus.Padding = new System.Windows.Forms.Padding(3);
            this.tsbCensus.Size = new System.Drawing.Size(150, 20);
            this.tsbCensus.Tag = "CoM_GISTools.AddLayer.ucCensus";
            this.tsbCensus.Text = "Business / Census";
            this.tsbCensus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCensus.ToolTipText = "Business / Census";
            this.tsbCensus.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbEmergency
            // 
            this.tsbEmergency.AutoSize = false;
            this.tsbEmergency.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEmergency.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmergency.Image")));
            this.tsbEmergency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmergency.Name = "tsbEmergency";
            this.tsbEmergency.Padding = new System.Windows.Forms.Padding(3);
            this.tsbEmergency.Size = new System.Drawing.Size(150, 20);
            this.tsbEmergency.Tag = "CoM_GISTools.AddLayer.ucEmergency";
            this.tsbEmergency.Text = "Emergency";
            this.tsbEmergency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbEmergency.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbEnvironment
            // 
            this.tsbEnvironment.AutoSize = false;
            this.tsbEnvironment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEnvironment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnvironment.Name = "tsbEnvironment";
            this.tsbEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tsbEnvironment.Size = new System.Drawing.Size(150, 20);
            this.tsbEnvironment.Tag = "CoM_GISTools.AddLayer.ucEnvironment";
            this.tsbEnvironment.Text = "Environment";
            this.tsbEnvironment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbEnvironment.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbInfrastructure
            // 
            this.tsbInfrastructure.AutoSize = false;
            this.tsbInfrastructure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbInfrastructure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfrastructure.Name = "tsbInfrastructure";
            this.tsbInfrastructure.Padding = new System.Windows.Forms.Padding(3);
            this.tsbInfrastructure.Size = new System.Drawing.Size(150, 20);
            this.tsbInfrastructure.Tag = "CoM_GISTools.AddLayer.ucInfrastructure";
            this.tsbInfrastructure.Text = "Infrastructure";
            this.tsbInfrastructure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbInfrastructure.Click += new System.EventHandler(this.buttonClick);
            // 
            // tspMapServices
            // 
            this.tspMapServices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspMapServices.Image = ((System.Drawing.Image)(resources.GetObject("tspMapServices.Image")));
            this.tspMapServices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspMapServices.Name = "tspMapServices";
            this.tspMapServices.Size = new System.Drawing.Size(81, 18);
            this.tspMapServices.Tag = "CoM_GISTools.AddLayer.ucMapServices";
            this.tspMapServices.Text = "Map Services";
            this.tspMapServices.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbPhoto
            // 
            this.tsbPhoto.AutoSize = false;
            this.tsbPhoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPhoto.Image = ((System.Drawing.Image)(resources.GetObject("tsbPhoto.Image")));
            this.tsbPhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPhoto.Name = "tsbPhoto";
            this.tsbPhoto.Padding = new System.Windows.Forms.Padding(3);
            this.tsbPhoto.Size = new System.Drawing.Size(150, 20);
            this.tsbPhoto.Tag = "CoM_GISTools.AddLayer.ucPhoto";
            this.tsbPhoto.Text = "Photos / Relief";
            this.tsbPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbPhoto.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbServiceDistricts
            // 
            this.tsbServiceDistricts.AutoSize = false;
            this.tsbServiceDistricts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbServiceDistricts.Image = ((System.Drawing.Image)(resources.GetObject("tsbServiceDistricts.Image")));
            this.tsbServiceDistricts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServiceDistricts.Name = "tsbServiceDistricts";
            this.tsbServiceDistricts.Padding = new System.Windows.Forms.Padding(3);
            this.tsbServiceDistricts.Size = new System.Drawing.Size(150, 20);
            this.tsbServiceDistricts.Tag = "CoM_GISTools.AddLayer.ucServiceDistricts";
            this.tsbServiceDistricts.Text = "Service Districts";
            this.tsbServiceDistricts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbServiceDistricts.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbSoils
            // 
            this.tsbSoils.AutoSize = false;
            this.tsbSoils.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSoils.Image = ((System.Drawing.Image)(resources.GetObject("tsbSoils.Image")));
            this.tsbSoils.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSoils.Name = "tsbSoils";
            this.tsbSoils.Padding = new System.Windows.Forms.Padding(3);
            this.tsbSoils.Size = new System.Drawing.Size(150, 20);
            this.tsbSoils.Tag = "CoM_GISTools.AddLayer.ucSoilsTopo";
            this.tsbSoils.Text = "Soils / Topography";
            this.tsbSoils.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbSoils.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbStructures
            // 
            this.tsbStructures.AutoSize = false;
            this.tsbStructures.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbStructures.Image = ((System.Drawing.Image)(resources.GetObject("tsbStructures.Image")));
            this.tsbStructures.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStructures.Name = "tsbStructures";
            this.tsbStructures.Padding = new System.Windows.Forms.Padding(3);
            this.tsbStructures.Size = new System.Drawing.Size(150, 20);
            this.tsbStructures.Tag = "CoM_GISTools.AddLayer.ucStructures";
            this.tsbStructures.Text = "Structures";
            this.tsbStructures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbStructures.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbTaxlots
            // 
            this.tsbTaxlots.AutoSize = false;
            this.tsbTaxlots.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaxlots.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaxlots.Image")));
            this.tsbTaxlots.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaxlots.Name = "tsbTaxlots";
            this.tsbTaxlots.Padding = new System.Windows.Forms.Padding(3);
            this.tsbTaxlots.Size = new System.Drawing.Size(150, 20);
            this.tsbTaxlots.Tag = "CoM_GISTools.AddLayer.ucTaxlots";
            this.tsbTaxlots.Text = "Taxlots / Control";
            this.tsbTaxlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTaxlots.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbTransportation
            // 
            this.tsbTransportation.AutoSize = false;
            this.tsbTransportation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTransportation.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransportation.Image")));
            this.tsbTransportation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransportation.Name = "tsbTransportation";
            this.tsbTransportation.Padding = new System.Windows.Forms.Padding(3);
            this.tsbTransportation.Size = new System.Drawing.Size(150, 20);
            this.tsbTransportation.Tag = "CoM_GISTools.AddLayer.ucTransportation";
            this.tsbTransportation.Text = "Transportation";
            this.tsbTransportation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTransportation.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbUtility
            // 
            this.tsbUtility.AutoSize = false;
            this.tsbUtility.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUtility.Image = ((System.Drawing.Image)(resources.GetObject("tsbUtility.Image")));
            this.tsbUtility.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUtility.Name = "tsbUtility";
            this.tsbUtility.Padding = new System.Windows.Forms.Padding(3);
            this.tsbUtility.Size = new System.Drawing.Size(150, 20);
            this.tsbUtility.Tag = "CoM_GISTools.AddLayer.ucUtility";
            this.tsbUtility.Text = "Utilities";
            this.tsbUtility.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbUtility.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbWater
            // 
            this.tsbWater.AutoSize = false;
            this.tsbWater.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbWater.Image = ((System.Drawing.Image)(resources.GetObject("tsbWater.Image")));
            this.tsbWater.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWater.Name = "tsbWater";
            this.tsbWater.Padding = new System.Windows.Forms.Padding(3);
            this.tsbWater.Size = new System.Drawing.Size(150, 20);
            this.tsbWater.Tag = "CoM_GISTools.AddLayer.ucWater";
            this.tsbWater.Text = "Water Related";
            this.tsbWater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbWater.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbZoning
            // 
            this.tsbZoning.AutoSize = false;
            this.tsbZoning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbZoning.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoning.Image")));
            this.tsbZoning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoning.Name = "tsbZoning";
            this.tsbZoning.Padding = new System.Windows.Forms.Padding(3);
            this.tsbZoning.Size = new System.Drawing.Size(150, 20);
            this.tsbZoning.Tag = "CoM_GISTools.AddLayer.ucZoning";
            this.tsbZoning.Text = "Zoning";
            this.tsbZoning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbZoning.Click += new System.EventHandler(this.buttonClick);
            // 
            // tsbEditor
            // 
            this.tsbEditor.AutoSize = false;
            this.tsbEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditor.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditor.Image")));
            this.tsbEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditor.Name = "tsbEditor";
            this.tsbEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tsbEditor.Size = new System.Drawing.Size(150, 20);
            this.tsbEditor.Tag = "CoM_GISTools.AddLayer.ucEditor";
            this.tsbEditor.Text = "Editors";
            this.tsbEditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbEditor.Click += new System.EventHandler(this.buttonClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(593, 606);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(447, 606);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(124, 40);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // fmAddLayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(746, 653);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnDone);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(762, 691);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(762, 691);
            this.Name = "fmAddLayers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmAddLayers_FormClosed);
            this.Load += new System.EventHandler(this.fmAddLayers_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.fmAddLayers_Paint);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tsbBoundaries;
        private System.Windows.Forms.ToolStripButton tsbCensus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbEmergency;
        private System.Windows.Forms.ToolStripButton tsbEnvironment;
        private System.Windows.Forms.ToolStripButton tsbInfrastructure;
        private System.Windows.Forms.ToolStripButton tsbPhoto;
        private System.Windows.Forms.ToolStripButton tsbSoils;
        private System.Windows.Forms.ToolStripButton tsbStructures;
        private System.Windows.Forms.ToolStripButton tsbTaxlots;
        private System.Windows.Forms.ToolStripButton tsbWater;
        private System.Windows.Forms.ToolStripButton tsbZoning;
        private System.Windows.Forms.ToolStripButton tsbEditor;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel pnlValidator;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripButton tsbServiceDistricts;
        private System.Windows.Forms.ToolStripButton tsbTransportation;
        private System.Windows.Forms.ToolStripButton tsbUtility;
        private System.Windows.Forms.ToolStripButton tspMapServices;





    }
}