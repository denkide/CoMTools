namespace CoM_GISTools.AddLayer
{
    partial class ucStructures
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
            this.chkStruct_Struct_AboveGroundTanks = new System.Windows.Forms.CheckBox();
            this.chkStruct_Struct_Fences = new System.Windows.Forms.CheckBox();
            this.chkStruct_Struct_MobileHomeParks = new System.Windows.Forms.CheckBox();
            this.lblStructures_Structures = new System.Windows.Forms.Label();
            this.chkStruct_Struct_Apt = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.chkStruct_Struct_AboveGroundTanks);
            this.panel1.Controls.Add(this.chkStruct_Struct_Fences);
            this.panel1.Controls.Add(this.chkStruct_Struct_MobileHomeParks);
            this.panel1.Controls.Add(this.lblStructures_Structures);
            this.panel1.Controls.Add(this.chkStruct_Struct_Apt);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 547);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkStruct_Struct_AboveGroundTanks
            // 
            this.chkStruct_Struct_AboveGroundTanks.AutoSize = true;
            this.chkStruct_Struct_AboveGroundTanks.Location = new System.Drawing.Point(46, 105);
            this.chkStruct_Struct_AboveGroundTanks.Name = "chkStruct_Struct_AboveGroundTanks";
            this.chkStruct_Struct_AboveGroundTanks.Size = new System.Drawing.Size(128, 17);
            this.chkStruct_Struct_AboveGroundTanks.TabIndex = 52;
            this.chkStruct_Struct_AboveGroundTanks.Tag = "Above_Ground_Tanks";
            this.chkStruct_Struct_AboveGroundTanks.Text = "Above Ground Tanks";
            this.chkStruct_Struct_AboveGroundTanks.UseVisualStyleBackColor = true;
            this.chkStruct_Struct_AboveGroundTanks.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkStruct_Struct_Fences
            // 
            this.chkStruct_Struct_Fences.AutoSize = true;
            this.chkStruct_Struct_Fences.Location = new System.Drawing.Point(46, 82);
            this.chkStruct_Struct_Fences.Name = "chkStruct_Struct_Fences";
            this.chkStruct_Struct_Fences.Size = new System.Drawing.Size(111, 17);
            this.chkStruct_Struct_Fences.TabIndex = 51;
            this.chkStruct_Struct_Fences.Tag = "Fences_and_Walls";
            this.chkStruct_Struct_Fences.Text = "Fences and Walls";
            this.chkStruct_Struct_Fences.UseVisualStyleBackColor = true;
            this.chkStruct_Struct_Fences.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkStruct_Struct_MobileHomeParks
            // 
            this.chkStruct_Struct_MobileHomeParks.AutoSize = true;
            this.chkStruct_Struct_MobileHomeParks.Location = new System.Drawing.Point(46, 59);
            this.chkStruct_Struct_MobileHomeParks.Name = "chkStruct_Struct_MobileHomeParks";
            this.chkStruct_Struct_MobileHomeParks.Size = new System.Drawing.Size(118, 17);
            this.chkStruct_Struct_MobileHomeParks.TabIndex = 38;
            this.chkStruct_Struct_MobileHomeParks.Tag = "Mobile_Home_Parks";
            this.chkStruct_Struct_MobileHomeParks.Text = "Mobile Home Parks";
            this.chkStruct_Struct_MobileHomeParks.UseVisualStyleBackColor = true;
            this.chkStruct_Struct_MobileHomeParks.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblStructures_Structures
            // 
            this.lblStructures_Structures.AutoSize = true;
            this.lblStructures_Structures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructures_Structures.Location = new System.Drawing.Point(14, 17);
            this.lblStructures_Structures.Name = "lblStructures_Structures";
            this.lblStructures_Structures.Size = new System.Drawing.Size(77, 16);
            this.lblStructures_Structures.TabIndex = 28;
            this.lblStructures_Structures.Text = "Structures";
            // 
            // chkStruct_Struct_Apt
            // 
            this.chkStruct_Struct_Apt.AutoSize = true;
            this.chkStruct_Struct_Apt.Location = new System.Drawing.Point(46, 36);
            this.chkStruct_Struct_Apt.Name = "chkStruct_Struct_Apt";
            this.chkStruct_Struct_Apt.Size = new System.Drawing.Size(128, 17);
            this.chkStruct_Struct_Apt.TabIndex = 16;
            this.chkStruct_Struct_Apt.Tag = "Apartments";
            this.chkStruct_Struct_Apt.Text = "Apartment Complexes";
            this.chkStruct_Struct_Apt.UseVisualStyleBackColor = true;
            this.chkStruct_Struct_Apt.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ucStructures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucStructures";
            this.Size = new System.Drawing.Size(573, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkStruct_Struct_Fences;
        private System.Windows.Forms.CheckBox chkStruct_Struct_MobileHomeParks;
        private System.Windows.Forms.Label lblStructures_Structures;
        private System.Windows.Forms.CheckBox chkStruct_Struct_Apt;
        private System.Windows.Forms.CheckBox chkStruct_Struct_AboveGroundTanks;
    }
}
