using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using PackageControl.DataProcess;

namespace PackageControl
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Check client app version.
                this.checkVersion();

                // Check client local database version.
                DataProcess.Initialization.Initialize();

            }
            catch (Exception exc) // catch (System.Net.WebException exc)
            {
                MessageBox.Show(exc.ToString());
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void checkVersion()
        {
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            this.lblVer.Text = "ver. " + assemblyName.Version.ToString(3);
            Version requiredVersion;

            using (var service = new PackageService.Service1())
            {
                string ver = service.GetRequiredClientVersion();

                service.Url = Utilities.MyUtilities.ServicePath;
                if (String.IsNullOrEmpty(ver))
                    throw new SystemException("Failed to get the required client version.");
                else
                    requiredVersion = new Version(ver);
            }
            if (assemblyName.Version.CompareTo(requiredVersion) < 0)
            {
                MessageBox.Show(String.Format(
                    "Update your client app.\r\nYour version: {0}\r\nRequired version: {1}\r\n\r\n" +
                    "After update, start the app manually.",
                    assemblyName.Version.ToString(3), requiredVersion));
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(Utilities.MyUtilities.ServerCabPath, null);
                this.Close();
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtLogin.Text.Length == 10)
                {
                    try
                    {
                        LoginProcess.CheckLogin(txtLogin.Text);
                        if (GlobalVariables.Designation == 0 || chkDesig.Checked)
                        {
                            Form desig = new Designation();
                            desig.ShowDialog();
                        }
                        if (GlobalVariables.Designation != 0)
                        {
                            Form Menu = new Menu();
                            Menu.ShowDialog();
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                    txtLogin.Text = "";
                    txtLogin.Focus();
                    chkDesig.Checked = false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "")
            {
                try
                {
                    LoginProcess.CheckLogin(txtLogin.Text);
                    if (GlobalVariables.Designation == 0 || chkDesig.Checked)
                    {
                        Form desig = new Designation();
                        desig.ShowDialog();
                    }
                    if (GlobalVariables.Designation != 0)
                    {
                        Form Menu = new Menu();
                        Menu.ShowDialog();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
                txtLogin.Text = "";
                txtLogin.Focus();
                chkDesig.Checked = false;
            }
        }
    }
}