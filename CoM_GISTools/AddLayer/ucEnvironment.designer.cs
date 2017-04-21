namespace CoM_GISTools.AddLayer
{
    partial class ucEnvironment
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
            System.Windows.Forms.CheckBox chkEnv_Other_PrecipContours;
            this.chkEnv_Contour_2Foot = new System.Windows.Forms.CheckBox();
            this.lblEnv_ContourLines = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEnv_Contour_10Foot_Countywide = new System.Windows.Forms.CheckBox();
            this.lblEnv_Vegetation = new System.Windows.Forms.Label();
            this.chkBound_StateBound_ORSenateDist = new System.Windows.Forms.CheckBox();
            this.chkEnv_Other_OpenSpaceType = new System.Windows.Forms.CheckBox();
            this.lblEnv_Other = new System.Windows.Forms.Label();
            this.chkEnv_Habitat_VernalPoolByCode = new System.Windows.Forms.CheckBox();
            this.chkEnv_Habitat_VernalPoolByHabitat = new System.Windows.Forms.CheckBox();
            this.chkEnv_Habitat_WildlifeHabitat = new System.Windows.Forms.CheckBox();
            this.chkEnv_Veg_Orchards = new System.Windows.Forms.CheckBox();
            this.chkEnv_Veg_Vineyards = new System.Windows.Forms.CheckBox();
            this.chkEnv_Habitat_ODFWUnits = new System.Windows.Forms.CheckBox();
            this.lblEnv_Habitat = new System.Windows.Forms.Label();
            this.chkEnv_Contour_40Foot = new System.Windows.Forms.CheckBox();
            this.chkEnv_Contour_10Foot = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnv_Parks_MaintenanceZones = new System.Windows.Forms.CheckBox();
            this.chkEnv_Parks_ParkLawns = new System.Windows.Forms.CheckBox();
            this.chkEnv_Parks_PlanterStrips = new System.Windows.Forms.CheckBox();
            chkEnv_Other_PrecipContours = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnv_Other_PrecipContours
            // 
            chkEnv_Other_PrecipContours.AutoSize = true;
            chkEnv_Other_PrecipContours.Location = new System.Drawing.Point(317, 217);
            chkEnv_Other_PrecipContours.Name = "chkEnv_Other_PrecipContours";
            chkEnv_Other_PrecipContours.Size = new System.Drawing.Size(129, 17);
            chkEnv_Other_PrecipContours.TabIndex = 31;
            chkEnv_Other_PrecipContours.Tag = "Precipitation_Contours";
            chkEnv_Other_PrecipContours.Text = "Precipitation Contours";
            chkEnv_Other_PrecipContours.UseVisualStyleBackColor = true;
            chkEnv_Other_PrecipContours.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Contour_2Foot
            // 
            this.chkEnv_Contour_2Foot.AutoSize = true;
            this.chkEnv_Contour_2Foot.Location = new System.Drawing.Point(46, 36);
            this.chkEnv_Contour_2Foot.Name = "chkEnv_Contour_2Foot";
            this.chkEnv_Contour_2Foot.Size = new System.Drawing.Size(351, 17);
            this.chkEnv_Contour_2Foot.TabIndex = 1;
            this.chkEnv_Contour_2Foot.Tag = "2_Foot_Contours";
            this.chkEnv_Contour_2Foot.Text = "2 foot contour intervals     - minimum scale 1 inch = 500 feet (1:6,000)";
            this.chkEnv_Contour_2Foot.UseVisualStyleBackColor = true;
            this.chkEnv_Contour_2Foot.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblEnv_ContourLines
            // 
            this.lblEnv_ContourLines.AutoSize = true;
            this.lblEnv_ContourLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnv_ContourLines.Location = new System.Drawing.Point(14, 17);
            this.lblEnv_ContourLines.Name = "lblEnv_ContourLines";
            this.lblEnv_ContourLines.Size = new System.Drawing.Size(102, 16);
            this.lblEnv_ContourLines.TabIndex = 0;
            this.lblEnv_ContourLines.Text = "Contour Lines";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.chkEnv_Parks_PlanterStrips);
            this.panel1.Controls.Add(this.chkEnv_Parks_ParkLawns);
            this.panel1.Controls.Add(this.chkEnv_Parks_MaintenanceZones);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkEnv_Contour_10Foot_Countywide);
            this.panel1.Controls.Add(this.lblEnv_Vegetation);
            this.panel1.Controls.Add(this.chkBound_StateBound_ORSenateDist);
            this.panel1.Controls.Add(this.chkEnv_Other_OpenSpaceType);
            this.panel1.Controls.Add(chkEnv_Other_PrecipContours);
            this.panel1.Controls.Add(this.lblEnv_Other);
            this.panel1.Controls.Add(this.chkEnv_Habitat_VernalPoolByCode);
            this.panel1.Controls.Add(this.chkEnv_Habitat_VernalPoolByHabitat);
            this.panel1.Controls.Add(this.chkEnv_Habitat_WildlifeHabitat);
            this.panel1.Controls.Add(this.chkEnv_Veg_Orchards);
            this.panel1.Controls.Add(this.chkEnv_Veg_Vineyards);
            this.panel1.Controls.Add(this.chkEnv_Habitat_ODFWUnits);
            this.panel1.Controls.Add(this.lblEnv_Habitat);
            this.panel1.Controls.Add(this.chkEnv_Contour_40Foot);
            this.panel1.Controls.Add(this.chkEnv_Contour_10Foot);
            this.panel1.Controls.Add(this.chkEnv_Contour_2Foot);
            this.panel1.Controls.Add(this.lblEnv_ContourLines);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 547);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkEnv_Contour_10Foot_Countywide
            // 
            this.chkEnv_Contour_10Foot_Countywide.AutoSize = true;
            this.chkEnv_Contour_10Foot_Countywide.Location = new System.Drawing.Point(46, 82);
            this.chkEnv_Contour_10Foot_Countywide.Name = "chkEnv_Contour_10Foot_Countywide";
            this.chkEnv_Contour_10Foot_Countywide.Size = new System.Drawing.Size(210, 17);
            this.chkEnv_Contour_10Foot_Countywide.TabIndex = 37;
            this.chkEnv_Contour_10Foot_Countywide.Tag = "10_Foot_Contours_County_Wide";
            this.chkEnv_Contour_10Foot_Countywide.Text = "10 foot contour intervals  -  Countywide";
            this.chkEnv_Contour_10Foot_Countywide.UseVisualStyleBackColor = true;
            this.chkEnv_Contour_10Foot_Countywide.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblEnv_Vegetation
            // 
            this.lblEnv_Vegetation.AutoSize = true;
            this.lblEnv_Vegetation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnv_Vegetation.Location = new System.Drawing.Point(14, 301);
            this.lblEnv_Vegetation.Name = "lblEnv_Vegetation";
            this.lblEnv_Vegetation.Size = new System.Drawing.Size(83, 16);
            this.lblEnv_Vegetation.TabIndex = 36;
            this.lblEnv_Vegetation.Text = "Vegetation";
            // 
            // chkBound_StateBound_ORSenateDist
            // 
            this.chkBound_StateBound_ORSenateDist.AutoSize = true;
            this.chkBound_StateBound_ORSenateDist.Location = new System.Drawing.Point(317, 171);
            this.chkBound_StateBound_ORSenateDist.Name = "chkBound_StateBound_ORSenateDist";
            this.chkBound_StateBound_ORSenateDist.Size = new System.Drawing.Size(128, 17);
            this.chkBound_StateBound_ORSenateDist.TabIndex = 33;
            this.chkBound_StateBound_ORSenateDist.Tag = "Landslides_DOGAMI";
            this.chkBound_StateBound_ORSenateDist.Text = "Landslides (DOGAMI)";
            this.chkBound_StateBound_ORSenateDist.UseVisualStyleBackColor = true;
            this.chkBound_StateBound_ORSenateDist.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Other_OpenSpaceType
            // 
            this.chkEnv_Other_OpenSpaceType.AutoSize = true;
            this.chkEnv_Other_OpenSpaceType.Location = new System.Drawing.Point(317, 194);
            this.chkEnv_Other_OpenSpaceType.Name = "chkEnv_Other_OpenSpaceType";
            this.chkEnv_Other_OpenSpaceType.Size = new System.Drawing.Size(128, 17);
            this.chkEnv_Other_OpenSpaceType.TabIndex = 32;
            this.chkEnv_Other_OpenSpaceType.Tag = "Open_Space_by_Type";
            this.chkEnv_Other_OpenSpaceType.Text = "Open Space By Type";
            this.chkEnv_Other_OpenSpaceType.UseVisualStyleBackColor = true;
            this.chkEnv_Other_OpenSpaceType.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblEnv_Other
            // 
            this.lblEnv_Other.AutoSize = true;
            this.lblEnv_Other.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnv_Other.Location = new System.Drawing.Point(284, 152);
            this.lblEnv_Other.Name = "lblEnv_Other";
            this.lblEnv_Other.Size = new System.Drawing.Size(45, 16);
            this.lblEnv_Other.TabIndex = 28;
            this.lblEnv_Other.Text = "Other";
            // 
            // chkEnv_Habitat_VernalPoolByCode
            // 
            this.chkEnv_Habitat_VernalPoolByCode.AutoSize = true;
            this.chkEnv_Habitat_VernalPoolByCode.Location = new System.Drawing.Point(46, 217);
            this.chkEnv_Habitat_VernalPoolByCode.Name = "chkEnv_Habitat_VernalPoolByCode";
            this.chkEnv_Habitat_VernalPoolByCode.Size = new System.Drawing.Size(192, 17);
            this.chkEnv_Habitat_VernalPoolByCode.TabIndex = 19;
            this.chkEnv_Habitat_VernalPoolByCode.Tag = "Vernal_Pools_by_Conservation_Code";
            this.chkEnv_Habitat_VernalPoolByCode.Text = "Vernal Pools by Conservation Code";
            this.chkEnv_Habitat_VernalPoolByCode.UseVisualStyleBackColor = true;
            this.chkEnv_Habitat_VernalPoolByCode.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Habitat_VernalPoolByHabitat
            // 
            this.chkEnv_Habitat_VernalPoolByHabitat.AutoSize = true;
            this.chkEnv_Habitat_VernalPoolByHabitat.Location = new System.Drawing.Point(46, 240);
            this.chkEnv_Habitat_VernalPoolByHabitat.Name = "chkEnv_Habitat_VernalPoolByHabitat";
            this.chkEnv_Habitat_VernalPoolByHabitat.Size = new System.Drawing.Size(170, 17);
            this.chkEnv_Habitat_VernalPoolByHabitat.TabIndex = 18;
            this.chkEnv_Habitat_VernalPoolByHabitat.Tag = "Vernal_Pools_by_Critical_Habitat";
            this.chkEnv_Habitat_VernalPoolByHabitat.Text = "Vernal Pools by Critical Habitat";
            this.chkEnv_Habitat_VernalPoolByHabitat.UseVisualStyleBackColor = true;
            this.chkEnv_Habitat_VernalPoolByHabitat.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Habitat_WildlifeHabitat
            // 
            this.chkEnv_Habitat_WildlifeHabitat.AutoSize = true;
            this.chkEnv_Habitat_WildlifeHabitat.Location = new System.Drawing.Point(46, 171);
            this.chkEnv_Habitat_WildlifeHabitat.Name = "chkEnv_Habitat_WildlifeHabitat";
            this.chkEnv_Habitat_WildlifeHabitat.Size = new System.Drawing.Size(157, 17);
            this.chkEnv_Habitat_WildlifeHabitat.TabIndex = 17;
            this.chkEnv_Habitat_WildlifeHabitat.Tag = "Deer_and_Elk_Winter_Range";
            this.chkEnv_Habitat_WildlifeHabitat.Text = "Deer and Elk Winter Range";
            this.chkEnv_Habitat_WildlifeHabitat.UseVisualStyleBackColor = true;
            this.chkEnv_Habitat_WildlifeHabitat.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Veg_Orchards
            // 
            this.chkEnv_Veg_Orchards.AutoSize = true;
            this.chkEnv_Veg_Orchards.Location = new System.Drawing.Point(46, 320);
            this.chkEnv_Veg_Orchards.Name = "chkEnv_Veg_Orchards";
            this.chkEnv_Veg_Orchards.Size = new System.Drawing.Size(69, 17);
            this.chkEnv_Veg_Orchards.TabIndex = 16;
            this.chkEnv_Veg_Orchards.Tag = "Orchards";
            this.chkEnv_Veg_Orchards.Text = "Orchards";
            this.chkEnv_Veg_Orchards.UseVisualStyleBackColor = true;
            this.chkEnv_Veg_Orchards.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Veg_Vineyards
            // 
            this.chkEnv_Veg_Vineyards.AutoSize = true;
            this.chkEnv_Veg_Vineyards.Location = new System.Drawing.Point(46, 343);
            this.chkEnv_Veg_Vineyards.Name = "chkEnv_Veg_Vineyards";
            this.chkEnv_Veg_Vineyards.Size = new System.Drawing.Size(72, 17);
            this.chkEnv_Veg_Vineyards.TabIndex = 14;
            this.chkEnv_Veg_Vineyards.Tag = "Vineyards";
            this.chkEnv_Veg_Vineyards.Text = "Vineyards";
            this.chkEnv_Veg_Vineyards.UseVisualStyleBackColor = true;
            this.chkEnv_Veg_Vineyards.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Habitat_ODFWUnits
            // 
            this.chkEnv_Habitat_ODFWUnits.AutoSize = true;
            this.chkEnv_Habitat_ODFWUnits.Location = new System.Drawing.Point(46, 194);
            this.chkEnv_Habitat_ODFWUnits.Name = "chkEnv_Habitat_ODFWUnits";
            this.chkEnv_Habitat_ODFWUnits.Size = new System.Drawing.Size(188, 17);
            this.chkEnv_Habitat_ODFWUnits.TabIndex = 7;
            this.chkEnv_Habitat_ODFWUnits.Tag = "ODFW_Wildlife_Mgmt_Units";
            this.chkEnv_Habitat_ODFWUnits.Text = "ODFW Wildlife Management Units";
            this.chkEnv_Habitat_ODFWUnits.UseVisualStyleBackColor = true;
            this.chkEnv_Habitat_ODFWUnits.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblEnv_Habitat
            // 
            this.lblEnv_Habitat.AutoSize = true;
            this.lblEnv_Habitat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnv_Habitat.Location = new System.Drawing.Point(14, 152);
            this.lblEnv_Habitat.Name = "lblEnv_Habitat";
            this.lblEnv_Habitat.Size = new System.Drawing.Size(58, 16);
            this.lblEnv_Habitat.TabIndex = 6;
            this.lblEnv_Habitat.Text = "Habitat";
            // 
            // chkEnv_Contour_40Foot
            // 
            this.chkEnv_Contour_40Foot.AutoSize = true;
            this.chkEnv_Contour_40Foot.Location = new System.Drawing.Point(46, 105);
            this.chkEnv_Contour_40Foot.Name = "chkEnv_Contour_40Foot";
            this.chkEnv_Contour_40Foot.Size = new System.Drawing.Size(363, 17);
            this.chkEnv_Contour_40Foot.TabIndex = 3;
            this.chkEnv_Contour_40Foot.Tag = "40_Foot_Contours";
            this.chkEnv_Contour_40Foot.Text = "40 foot contour intervals   - minimum scale 1 inch = 4000 feet (1:48,000)";
            this.chkEnv_Contour_40Foot.UseVisualStyleBackColor = true;
            this.chkEnv_Contour_40Foot.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkEnv_Contour_10Foot
            // 
            this.chkEnv_Contour_10Foot.AutoSize = true;
            this.chkEnv_Contour_10Foot.Location = new System.Drawing.Point(46, 59);
            this.chkEnv_Contour_10Foot.Name = "chkEnv_Contour_10Foot";
            this.chkEnv_Contour_10Foot.Size = new System.Drawing.Size(363, 17);
            this.chkEnv_Contour_10Foot.TabIndex = 2;
            this.chkEnv_Contour_10Foot.Tag = "10_Foot_Contours";
            this.chkEnv_Contour_10Foot.Text = "10 foot contour intervals   - minimum scale 1 inch = 1000 feet (1:12,000)";
            this.chkEnv_Contour_10Foot.UseVisualStyleBackColor = true;
            this.chkEnv_Contour_10Foot.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Parks";
            // 
            // chkEnv_Parks_MaintenanceZones
            // 
            this.chkEnv_Parks_MaintenanceZones.AutoSize = true;
            this.chkEnv_Parks_MaintenanceZones.Location = new System.Drawing.Point(317, 320);
            this.chkEnv_Parks_MaintenanceZones.Name = "chkEnv_Parks_MaintenanceZones";
            this.chkEnv_Parks_MaintenanceZones.Size = new System.Drawing.Size(121, 17);
            this.chkEnv_Parks_MaintenanceZones.TabIndex = 39;
            this.chkEnv_Parks_MaintenanceZones.Tag = "Maintenance_Zones";
            this.chkEnv_Parks_MaintenanceZones.Text = "Maintenance Zones";
            this.chkEnv_Parks_MaintenanceZones.UseVisualStyleBackColor = true;
            // 
            // chkEnv_Parks_ParkLawns
            // 
            this.chkEnv_Parks_ParkLawns.AutoSize = true;
            this.chkEnv_Parks_ParkLawns.Location = new System.Drawing.Point(317, 343);
            this.chkEnv_Parks_ParkLawns.Name = "chkEnv_Parks_ParkLawns";
            this.chkEnv_Parks_ParkLawns.Size = new System.Drawing.Size(82, 17);
            this.chkEnv_Parks_ParkLawns.TabIndex = 40;
            this.chkEnv_Parks_ParkLawns.Tag = "Park_Lawns";
            this.chkEnv_Parks_ParkLawns.Text = "Park Lawns";
            this.chkEnv_Parks_ParkLawns.UseVisualStyleBackColor = true;
            // 
            // chkEnv_Parks_PlanterStrips
            // 
            this.chkEnv_Parks_PlanterStrips.AutoSize = true;
            this.chkEnv_Parks_PlanterStrips.Location = new System.Drawing.Point(317, 366);
            this.chkEnv_Parks_PlanterStrips.Name = "chkEnv_Parks_PlanterStrips";
            this.chkEnv_Parks_PlanterStrips.Size = new System.Drawing.Size(88, 17);
            this.chkEnv_Parks_PlanterStrips.TabIndex = 41;
            this.chkEnv_Parks_PlanterStrips.Tag = "Planter_Strips";
            this.chkEnv_Parks_PlanterStrips.Text = "Planter Strips";
            this.chkEnv_Parks_PlanterStrips.UseVisualStyleBackColor = true;
            // 
            // ucEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucEnvironment";
            this.Size = new System.Drawing.Size(573, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnv_Contour_2Foot;
        private System.Windows.Forms.Label lblEnv_ContourLines;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBound_StateBound_ORSenateDist;
        private System.Windows.Forms.CheckBox chkEnv_Other_OpenSpaceType;
        private System.Windows.Forms.Label lblEnv_Other;
        private System.Windows.Forms.CheckBox chkEnv_Habitat_VernalPoolByCode;
        private System.Windows.Forms.CheckBox chkEnv_Habitat_VernalPoolByHabitat;
        private System.Windows.Forms.CheckBox chkEnv_Habitat_WildlifeHabitat;
        private System.Windows.Forms.CheckBox chkEnv_Veg_Orchards;
        private System.Windows.Forms.CheckBox chkEnv_Veg_Vineyards;
        private System.Windows.Forms.CheckBox chkEnv_Habitat_ODFWUnits;
        private System.Windows.Forms.Label lblEnv_Habitat;
        private System.Windows.Forms.CheckBox chkEnv_Contour_40Foot;
        private System.Windows.Forms.CheckBox chkEnv_Contour_10Foot;
        private System.Windows.Forms.Label lblEnv_Vegetation;
        private System.Windows.Forms.CheckBox chkEnv_Contour_10Foot_Countywide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnv_Parks_PlanterStrips;
        private System.Windows.Forms.CheckBox chkEnv_Parks_ParkLawns;
        private System.Windows.Forms.CheckBox chkEnv_Parks_MaintenanceZones;

    }
}
