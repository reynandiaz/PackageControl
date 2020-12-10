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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblEmployeeCode.Text = GlobalVariables.EmployeeCode;
            if (GlobalVariables.Designation == 1)
            {
                lblDesig.Text = "Ceiling";
            }
            else if (GlobalVariables.Designation == 2)
            {
                lblDesig.Text = "Gable Wall";
            }
            else if (GlobalVariables.Designation == 3)
            {
                lblDesig.Text = "Roof";
            }
            else if (GlobalVariables.Designation == 4)
            {
                lblDesig.Text = "Wall";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Form header = new ScanHeader();
            header.Show();
        }

    }
}