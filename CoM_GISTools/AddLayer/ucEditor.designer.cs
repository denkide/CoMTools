namespace CoM_GISTools.AddLayer
{
    partial class ucEditor
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
            this.lblCurrentLicense = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEditMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblEditor_Editor = new System.Windows.Forms.Label();
            this.lbEditabelLayers = new System.Windows.Forms.ListBox();
            this.lblUtilities_Utilities = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblCurrentLicense);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblEditMsg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.lblEditor_Editor);
            this.panel1.Controls.Add(this.lbEditabelLayers);
            this.panel1.Controls.Add(this.lblUtilities_Utilities);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 547);
            this.panel1.TabIndex = 4;
            // 
            // lblCurrentLicense
            // 
            this.lblCurrentLicense.AutoSize = true;
            this.lblCurrentLicense.Location = new System.Drawing.Point(242, 77);
            this.lblCurrentLicense.Name = "lblCurrentLicense";
            this.lblCurrentLicense.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentLicense.TabIndex = 8;
            this.lblCurrentLicense.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Your current license is:";
            // 
            // lblEditMsg
            // 
            this.lblEditMsg.AutoSize = true;
            this.lblEditMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditMsg.ForeColor = System.Drawing.Color.Red;
            this.lblEditMsg.Location = new System.Drawing.Point(43, 320);
            this.lblEditMsg.Name = "lblEditMsg";
            this.lblEditMsg.Size = new System.Drawing.Size(0, 15);
            this.lblEditMsg.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "You are currently logged in as:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(403, 258);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Start Editing";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblEditor_Editor
            // 
            this.lblEditor_Editor.AutoSize = true;
            this.lblEditor_Editor.Location = new System.Drawing.Point(43, 115);
            this.lblEditor_Editor.Name = "lblEditor_Editor";
            this.lblEditor_Editor.Size = new System.Drawing.Size(223, 13);
            this.lblEditor_Editor.TabIndex = 2;
            this.lblEditor_Editor.Text = "You are authorized to edit the following layers:";
            // 
            // lbEditabelLayers
            // 
            this.lbEditabelLayers.FormattingEnabled = true;
            this.lbEditabelLayers.Location = new System.Drawing.Point(46, 131);
            this.lbEditabelLayers.Name = "lbEditabelLayers";
            this.lbEditabelLayers.Size = new System.Drawing.Size(432, 121);
            this.lbEditabelLayers.TabIndex = 1;
            // 
            // lblUtilities_Utilities
            // 
            this.lblUtilities_Utilities.AutoSize = true;
            this.lblUtilities_Utilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilities_Utilities.Location = new System.Drawing.Point(14, 17);
            this.lblUtilities_Utilities.Name = "lblUtilities_Utilities";
            this.lblUtilities_Utilities.Size = new System.Drawing.Size(100, 16);
            this.lblUtilities_Utilities.TabIndex = 0;
            this.lblUtilities_Utilities.Text = "Editor Layers";
            // 
            // ucEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucEditor";
            this.Size = new System.Drawing.Size(573, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUtilities_Utilities;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblEditor_Editor;
        private System.Windows.Forms.ListBox lbEditabelLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEditMsg;
        private System.Windows.Forms.Label lblCurrentLicense;
        private System.Windows.Forms.Label label3;
    }
}
