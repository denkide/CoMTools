namespace CoM_GISTools.Print
{
    partial class fmPrintMap
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
            this.components = new System.ComponentModel.Container();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblErrSubTitle = new System.Windows.Forms.Label();
            this.lblErrTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cboOrientation = new System.Windows.Forms.ComboBox();
            this.cboMapScale = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblErrOrientation = new System.Windows.Forms.Label();
            this.lblErrMapScale = new System.Windows.Forms.Label();
            this.lblErrMapSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMapSize = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSelectedLayer = new System.Windows.Forms.Button();
            this.btnAddSelectedLayer = new System.Windows.Forms.Button();
            this.btnRemoveAllLayers = new System.Windows.Forms.Button();
            this.btnAddAllLayers = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbLegendLayers = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMapLayers = new System.Windows.Forms.ListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.AcceptsReturn = true;
            this.txtSubTitle.Location = new System.Drawing.Point(63, 87);
            this.txtSubTitle.Multiline = true;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(173, 40);
            this.txtSubTitle.TabIndex = 1;
            this.txtSubTitle.Text = "txtSubTitle";
            this.toolTip1.SetToolTip(this.txtSubTitle, "Enter the subtitle.\r\nThis can be 2 lines for landscape and 1 for portrait.\r\nThis " +
                    "is an optional field.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Subtitle";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(63, 19);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(173, 43);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "txtTitle";
            this.toolTip1.SetToolTip(this.txtTitle, "Enter the title here.\r\nMax is 2 lines for landscape and 1 for portrait.\r\nThis is " +
                    "an optional field.");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblErrSubTitle);
            this.groupBox1.Controls.Add(this.lblErrTitle);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSubTitle);
            this.groupBox1.Location = new System.Drawing.Point(23, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 152);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Titles";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "* Max characters per line is 25 - 2 lines max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "* Max characters per line is 20 - 2 lines max";
            // 
            // lblErrSubTitle
            // 
            this.lblErrSubTitle.AutoSize = true;
            this.lblErrSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrSubTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrSubTitle.Location = new System.Drawing.Point(242, 90);
            this.lblErrSubTitle.Name = "lblErrSubTitle";
            this.lblErrSubTitle.Size = new System.Drawing.Size(14, 16);
            this.lblErrSubTitle.TabIndex = 99;
            this.lblErrSubTitle.Text = "*";
            // 
            // lblErrTitle
            // 
            this.lblErrTitle.AutoSize = true;
            this.lblErrTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrTitle.Location = new System.Drawing.Point(242, 22);
            this.lblErrTitle.Name = "lblErrTitle";
            this.lblErrTitle.Size = new System.Drawing.Size(14, 16);
            this.lblErrTitle.TabIndex = 99;
            this.lblErrTitle.Text = "*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPrinters);
            this.groupBox2.Controls.Add(this.lblPrinter);
            this.groupBox2.Controls.Add(this.cboOrientation);
            this.groupBox2.Controls.Add(this.cboMapScale);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblErrOrientation);
            this.groupBox2.Controls.Add(this.lblErrMapScale);
            this.groupBox2.Controls.Add(this.lblErrMapSize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboMapSize);
            this.groupBox2.Location = new System.Drawing.Point(316, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 152);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map Layout";
            // 
            // cboPrinters
            // 
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(81, 16);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(138, 21);
            this.cboPrinters.TabIndex = 2;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(16, 24);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(40, 13);
            this.lblPrinter.TabIndex = 99;
            this.lblPrinter.Text = "Printer:";
            // 
            // cboOrientation
            // 
            this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrientation.FormattingEnabled = true;
            this.cboOrientation.Location = new System.Drawing.Point(82, 85);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(137, 21);
            this.cboOrientation.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cboOrientation, "Select a map orientation.\r\nThis is a required field.");
            this.cboOrientation.SelectedIndexChanged += new System.EventHandler(this.cboOrientation_SelectedIndexChanged);
            // 
            // cboMapScale
            // 
            this.cboMapScale.FormattingEnabled = true;
            this.cboMapScale.Location = new System.Drawing.Point(96, 117);
            this.cboMapScale.Name = "cboMapScale";
            this.cboMapScale.Size = new System.Drawing.Size(123, 21);
            this.cboMapScale.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboMapScale, "Select a map scale or enter your own.\r\nThis is a required field.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "1 : ";
            // 
            // lblErrOrientation
            // 
            this.lblErrOrientation.AutoSize = true;
            this.lblErrOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrOrientation.ForeColor = System.Drawing.Color.Red;
            this.lblErrOrientation.Location = new System.Drawing.Point(225, 88);
            this.lblErrOrientation.Name = "lblErrOrientation";
            this.lblErrOrientation.Size = new System.Drawing.Size(14, 16);
            this.lblErrOrientation.TabIndex = 99;
            this.lblErrOrientation.Text = "*";
            // 
            // lblErrMapScale
            // 
            this.lblErrMapScale.AutoSize = true;
            this.lblErrMapScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrMapScale.ForeColor = System.Drawing.Color.Red;
            this.lblErrMapScale.Location = new System.Drawing.Point(225, 118);
            this.lblErrMapScale.Name = "lblErrMapScale";
            this.lblErrMapScale.Size = new System.Drawing.Size(14, 16);
            this.lblErrMapScale.TabIndex = 99;
            this.lblErrMapScale.Text = "*";
            // 
            // lblErrMapSize
            // 
            this.lblErrMapSize.AutoSize = true;
            this.lblErrMapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrMapSize.ForeColor = System.Drawing.Color.Red;
            this.lblErrMapSize.Location = new System.Drawing.Point(225, 55);
            this.lblErrMapSize.Name = "lblErrMapSize";
            this.lblErrMapSize.Size = new System.Drawing.Size(14, 16);
            this.lblErrMapSize.TabIndex = 99;
            this.lblErrMapSize.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Orientation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Map Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Map Size";
            // 
            // cboMapSize
            // 
            this.cboMapSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapSize.Enabled = false;
            this.cboMapSize.FormattingEnabled = true;
            this.cboMapSize.Location = new System.Drawing.Point(82, 52);
            this.cboMapSize.Name = "cboMapSize";
            this.cboMapSize.Size = new System.Drawing.Size(137, 21);
            this.cboMapSize.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cboMapSize, "Select a map size.\r\nThis is a required field.");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveSelectedLayer);
            this.groupBox3.Controls.Add(this.btnAddSelectedLayer);
            this.groupBox3.Controls.Add(this.btnRemoveAllLayers);
            this.groupBox3.Controls.Add(this.btnAddAllLayers);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lbLegendLayers);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lbMapLayers);
            this.groupBox3.Location = new System.Drawing.Point(24, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 190);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Layers";
            // 
            // btnRemoveSelectedLayer
            // 
            this.btnRemoveSelectedLayer.Location = new System.Drawing.Point(241, 80);
            this.btnRemoveSelectedLayer.Name = "btnRemoveSelectedLayer";
            this.btnRemoveSelectedLayer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSelectedLayer.TabIndex = 7;
            this.btnRemoveSelectedLayer.Text = "<";
            this.btnRemoveSelectedLayer.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedLayer.Click += new System.EventHandler(this.btnRemoveSelectedLayer_Click);
            // 
            // btnAddSelectedLayer
            // 
            this.btnAddSelectedLayer.Location = new System.Drawing.Point(241, 51);
            this.btnAddSelectedLayer.Name = "btnAddSelectedLayer";
            this.btnAddSelectedLayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddSelectedLayer.TabIndex = 6;
            this.btnAddSelectedLayer.Text = ">";
            this.btnAddSelectedLayer.UseVisualStyleBackColor = true;
            this.btnAddSelectedLayer.Click += new System.EventHandler(this.btnAddSelectedLayer_Click);
            // 
            // btnRemoveAllLayers
            // 
            this.btnRemoveAllLayers.Location = new System.Drawing.Point(241, 143);
            this.btnRemoveAllLayers.Name = "btnRemoveAllLayers";
            this.btnRemoveAllLayers.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllLayers.TabIndex = 9;
            this.btnRemoveAllLayers.Text = "<<";
            this.btnRemoveAllLayers.UseVisualStyleBackColor = true;
            this.btnRemoveAllLayers.Click += new System.EventHandler(this.btnRemoveAllLayers_Click);
            // 
            // btnAddAllLayers
            // 
            this.btnAddAllLayers.Location = new System.Drawing.Point(241, 114);
            this.btnAddAllLayers.Name = "btnAddAllLayers";
            this.btnAddAllLayers.Size = new System.Drawing.Size(75, 23);
            this.btnAddAllLayers.TabIndex = 8;
            this.btnAddAllLayers.Text = ">>";
            this.btnAddAllLayers.UseVisualStyleBackColor = true;
            this.btnAddAllLayers.Click += new System.EventHandler(this.btnAddAllLayers_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Layers in Legend";
            // 
            // lbLegendLayers
            // 
            this.lbLegendLayers.FormattingEnabled = true;
            this.lbLegendLayers.Location = new System.Drawing.Point(322, 38);
            this.lbLegendLayers.Name = "lbLegendLayers";
            this.lbLegendLayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbLegendLayers.Size = new System.Drawing.Size(209, 134);
            this.lbLegendLayers.TabIndex = 99;
            this.lbLegendLayers.TabStop = false;
            this.toolTip1.SetToolTip(this.lbLegendLayers, "These are the layers that will be in your legend.");
            this.lbLegendLayers.DoubleClick += new System.EventHandler(this.lbLegendLayers_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Layers in Map";
            // 
            // lbMapLayers
            // 
            this.lbMapLayers.FormattingEnabled = true;
            this.lbMapLayers.Location = new System.Drawing.Point(26, 41);
            this.lbMapLayers.Name = "lbMapLayers";
            this.lbMapLayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMapLayers.Size = new System.Drawing.Size(209, 134);
            this.lbMapLayers.TabIndex = 99;
            this.lbMapLayers.TabStop = false;
            this.toolTip1.SetToolTip(this.lbMapLayers, "These are the layers currently in your map.");
            this.lbMapLayers.DoubleClick += new System.EventHandler(this.lbMapLayers_DoubleClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(437, 374);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(131, 40);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 500;
            // 
            // fmPrintMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 426);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(598, 460);
            this.MinimumSize = new System.Drawing.Size(598, 460);
            this.Name = "fmPrintMap";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Print Map";
            this.Load += new System.EventHandler(this.fmPrintMap_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmPrintMap_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblErrTitle;
        private System.Windows.Forms.Label lblErrSubTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMapScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbLegendLayers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbMapLayers;
        private System.Windows.Forms.Button btnRemoveSelectedLayer;
        private System.Windows.Forms.Button btnAddSelectedLayer;
        private System.Windows.Forms.Button btnRemoveAllLayers;
        private System.Windows.Forms.Button btnAddAllLayers;
        private System.Windows.Forms.Label lblErrMapScale;
        private System.Windows.Forms.Label lblErrMapSize;
        private System.Windows.Forms.Label lblErrOrientation;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboOrientation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboMapSize;
        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;

    }
}