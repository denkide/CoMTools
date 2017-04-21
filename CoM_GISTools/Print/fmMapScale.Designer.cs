namespace CoM_GISTools.Print
{
    partial class fmMapScale
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
            this.cboNewMapScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeMapScale = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboNewMapScale
            // 
            this.cboNewMapScale.FormattingEnabled = true;
            this.cboNewMapScale.Location = new System.Drawing.Point(76, 52);
            this.cboNewMapScale.Name = "cboNewMapScale";
            this.cboNewMapScale.Size = new System.Drawing.Size(224, 21);
            this.cboNewMapScale.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select or enter a new map scale:";
            // 
            // btnChangeMapScale
            // 
            this.btnChangeMapScale.Location = new System.Drawing.Point(133, 94);
            this.btnChangeMapScale.Name = "btnChangeMapScale";
            this.btnChangeMapScale.Size = new System.Drawing.Size(111, 23);
            this.btnChangeMapScale.TabIndex = 2;
            this.btnChangeMapScale.Text = "Change Map Scale";
            this.btnChangeMapScale.UseVisualStyleBackColor = true;
            this.btnChangeMapScale.Click += new System.EventHandler(this.btnChangeMapScale_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmMapScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 135);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangeMapScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNewMapScale);
            this.Name = "fmMapScale";
            this.Text = "fmMapScale";
            this.Load += new System.EventHandler(this.fmMapScale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNewMapScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeMapScale;
        private System.Windows.Forms.Button btnCancel;
    }
}