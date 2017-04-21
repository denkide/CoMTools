namespace CoM_GISTools.DataFrame
{
    partial class fmAddDataFrame
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
            this.gpbDept = new System.Windows.Forms.GroupBox();
            this.chkPubWorks = new System.Windows.Forms.CheckBox();
            this.chkPolice = new System.Windows.Forms.CheckBox();
            this.chkPlan = new System.Windows.Forms.CheckBox();
            this.chkFire = new System.Windows.Forms.CheckBox();
            this.chkEconomDev = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpbDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDept
            // 
            this.gpbDept.Controls.Add(this.chkPubWorks);
            this.gpbDept.Controls.Add(this.chkPolice);
            this.gpbDept.Controls.Add(this.chkPlan);
            this.gpbDept.Controls.Add(this.chkFire);
            this.gpbDept.Controls.Add(this.chkEconomDev);
            this.gpbDept.Location = new System.Drawing.Point(12, 12);
            this.gpbDept.Name = "gpbDept";
            this.gpbDept.Size = new System.Drawing.Size(211, 224);
            this.gpbDept.TabIndex = 0;
            this.gpbDept.TabStop = false;
            this.gpbDept.Text = "Select a Department";
            // 
            // chkPubWorks
            // 
            this.chkPubWorks.AutoSize = true;
            this.chkPubWorks.Location = new System.Drawing.Point(23, 188);
            this.chkPubWorks.Name = "chkPubWorks";
            this.chkPubWorks.Size = new System.Drawing.Size(89, 17);
            this.chkPubWorks.TabIndex = 5;
            this.chkPubWorks.Text = "Public Works";
            this.chkPubWorks.UseVisualStyleBackColor = true;
            // 
            // chkPolice
            // 
            this.chkPolice.AutoSize = true;
            this.chkPolice.Location = new System.Drawing.Point(23, 148);
            this.chkPolice.Name = "chkPolice";
            this.chkPolice.Size = new System.Drawing.Size(55, 17);
            this.chkPolice.TabIndex = 4;
            this.chkPolice.Text = "Police";
            this.chkPolice.UseVisualStyleBackColor = true;
            // 
            // chkPlan
            // 
            this.chkPlan.AutoSize = true;
            this.chkPlan.Location = new System.Drawing.Point(23, 108);
            this.chkPlan.Name = "chkPlan";
            this.chkPlan.Size = new System.Drawing.Size(67, 17);
            this.chkPlan.TabIndex = 3;
            this.chkPlan.Text = "Planning";
            this.chkPlan.UseVisualStyleBackColor = true;
            // 
            // chkFire
            // 
            this.chkFire.AutoSize = true;
            this.chkFire.Location = new System.Drawing.Point(23, 68);
            this.chkFire.Name = "chkFire";
            this.chkFire.Size = new System.Drawing.Size(43, 17);
            this.chkFire.TabIndex = 2;
            this.chkFire.Text = "Fire";
            this.chkFire.UseVisualStyleBackColor = true;
            // 
            // chkEconomDev
            // 
            this.chkEconomDev.AutoSize = true;
            this.chkEconomDev.Location = new System.Drawing.Point(23, 28);
            this.chkEconomDev.Name = "chkEconomDev";
            this.chkEconomDev.Size = new System.Drawing.Size(139, 17);
            this.chkEconomDev.TabIndex = 1;
            this.chkEconomDev.Text = "Economic Development";
            this.chkEconomDev.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(27, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(128, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmAddDataFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 286);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbDept);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(244, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(244, 320);
            this.Name = "fmAddDataFrame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add Data Frame";
            this.gpbDept.ResumeLayout(false);
            this.gpbDept.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDept;
        private System.Windows.Forms.CheckBox chkPubWorks;
        private System.Windows.Forms.CheckBox chkPolice;
        private System.Windows.Forms.CheckBox chkPlan;
        private System.Windows.Forms.CheckBox chkFire;
        private System.Windows.Forms.CheckBox chkEconomDev;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}