namespace PackageControl
{
    partial class Designation
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
            this.btnBack = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnRoof = new System.Windows.Forms.Button();
            this.btnGable = new System.Windows.Forms.Button();
            this.btnCeiling = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 31);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 22);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "<&0";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.btnWall);
            this.panel3.Controls.Add(this.btnRoof);
            this.panel3.Controls.Add(this.btnGable);
            this.panel3.Controls.Add(this.btnCeiling);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 282);
            // 
            // btnWall
            // 
            this.btnWall.Location = new System.Drawing.Point(30, 120);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(187, 24);
            this.btnWall.TabIndex = 4;
            this.btnWall.Text = "Wall&4";
            this.btnWall.Click += new System.EventHandler(this.btnWall_Click);
            // 
            // btnRoof
            // 
            this.btnRoof.Location = new System.Drawing.Point(30, 90);
            this.btnRoof.Name = "btnRoof";
            this.btnRoof.Size = new System.Drawing.Size(187, 24);
            this.btnRoof.TabIndex = 3;
            this.btnRoof.Text = "Roof&3";
            this.btnRoof.Click += new System.EventHandler(this.btnRoof_Click);
            // 
            // btnGable
            // 
            this.btnGable.Location = new System.Drawing.Point(30, 60);
            this.btnGable.Name = "btnGable";
            this.btnGable.Size = new System.Drawing.Size(187, 24);
            this.btnGable.TabIndex = 2;
            this.btnGable.Text = "Gable Wall&2";
            this.btnGable.Click += new System.EventHandler(this.btnGable_Click);
            // 
            // btnCeiling
            // 
            this.btnCeiling.Location = new System.Drawing.Point(30, 30);
            this.btnCeiling.Name = "btnCeiling";
            this.btnCeiling.Size = new System.Drawing.Size(187, 24);
            this.btnCeiling.TabIndex = 1;
            this.btnCeiling.Text = "Ceiling&1";
            this.btnCeiling.Click += new System.EventHandler(this.btnCeiling_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.Text = "Designation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 38);
            // 
            // Designation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Designation";
            this.Text = "Designation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Designation_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCeiling;
        private System.Windows.Forms.Button btnRoof;
        private System.Windows.Forms.Button btnGable;
        private System.Windows.Forms.Button btnWall;
    }
}