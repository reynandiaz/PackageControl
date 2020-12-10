using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PackageControl.DataProcess;

namespace PackageControl
{
    public partial class Designation : Form
    {
        public Designation()
        {
            InitializeComponent();
        }

        private void btnCeiling_Click(object sender, EventArgs e)
        {
            LoginProcess.UpdateDesignation(1);
            this.Close();   
        }

        private void btnGable_Click(object sender, EventArgs e)
        {
            LoginProcess.UpdateDesignation(2);
            this.Close();
        }

        private void btnRoof_Click(object sender, EventArgs e)
        {
            LoginProcess.UpdateDesignation(3);
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Designation_Load(object sender, EventArgs e)
        {
            btnCeiling.Focus();
        }

        private void btnWall_Click(object sender, EventArgs e)
        {
            LoginProcess.UpdateDesignation(4);
            this.Close();
        }


    }
}