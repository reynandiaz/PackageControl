namespace PackageControl
{
    partial class ScanGroup
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLegends = new System.Windows.Forms.Button();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDirect = new System.Windows.Forms.CheckBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblHouse = new System.Windows.Forms.Label();
            this.lblConstructionCode = new System.Windows.Forms.Label();
            this.txtQR = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnLegends);
            this.panel2.Controls.Add(this.btnTransmit);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 31);
            // 
            // btnLegends
            // 
            this.btnLegends.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLegends.Location = new System.Drawing.Point(85, 4);
            this.btnLegends.Name = "btnLegends";
            this.btnLegends.Size = new System.Drawing.Size(68, 22);
            this.btnLegends.TabIndex = 3;
            this.btnLegends.Text = "Legends";
            this.btnLegends.Click += new System.EventHandler(this.btnLegends_Click);
            // 
            // btnTransmit
            // 
            this.btnTransmit.Location = new System.Drawing.Point(159, 4);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(78, 22);
            this.btnTransmit.TabIndex = 2;
            this.btnTransmit.Text = "Transmit&9";
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 22);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<&0";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.txtGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkDirect);
            this.panel1.Controls.Add(this.lblRequest);
            this.panel1.Controls.Add(this.lblHouse);
            this.panel1.Controls.Add(this.lblConstructionCode);
            this.panel1.Controls.Add(this.txtQR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 94);
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGroup.Location = new System.Drawing.Point(107, 68);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(46, 21);
            this.txtGroup.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(57, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.Text = "Group:";
            // 
            // chkDirect
            // 
            this.chkDirect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkDirect.Location = new System.Drawing.Point(118, 45);
            this.chkDirect.Name = "chkDirect";
            this.chkDirect.Size = new System.Drawing.Size(66, 20);
            this.chkDirect.TabIndex = 7;
            this.chkDirect.Text = "Direct&3";
            // 
            // lblRequest
            // 
            this.lblRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRequest.Location = new System.Drawing.Point(118, 26);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(100, 20);
            this.lblRequest.Text = "Request";
            // 
            // lblHouse
            // 
            this.lblHouse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHouse.Location = new System.Drawing.Point(3, 46);
            this.lblHouse.Name = "lblHouse";
            this.lblHouse.Size = new System.Drawing.Size(109, 19);
            this.lblHouse.Text = "HouseCode";
            // 
            // lblConstructionCode
            // 
            this.lblConstructionCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConstructionCode.Location = new System.Drawing.Point(3, 27);
            this.lblConstructionCode.Name = "lblConstructionCode";
            this.lblConstructionCode.Size = new System.Drawing.Size(109, 19);
            this.lblConstructionCode.Text = "ConstructionCode";
            // 
            // txtQR
            // 
            this.txtQR.Location = new System.Drawing.Point(3, 3);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(234, 21);
            this.txtQR.TabIndex = 0;
            this.txtQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQR_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 195);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGrid1.Size = new System.Drawing.Size(240, 195);
            this.dataGrid1.TabIndex = 8;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.MappingName = "Barcodes2";
            // 
            // ScanGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ScanGroup";
            this.Text = "ScanGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanGroup_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTransmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkDirect;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblHouse;
        private System.Windows.Forms.Label lblConstructionCode;
        private System.Windows.Forms.TextBox txtQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button btnLegends;
    }
}