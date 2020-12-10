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
    public partial class ScanHeader : Form
    {
        private ScannedTableFormRow bindingEntity = new ScannedTableFormRow();

        public ScanHeader()
        {
            InitializeComponent();
            try
            {
                addGridStyle(dataGrid1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem!!" + ex.ToString());
            }
        }
        private void addGridStyle(DataGrid dg)
        {

            DataGridTableStyle dtStyle = new DataGridTableStyle();
            dtStyle.MappingName = "ScannedTable";

            DataTable dt = this.bindingEntity.ScannedTable;
            for (int i = 0; i < this.bindingEntity.ScannedTable.Columns.Count; i++)
            {

                DataProcess.ColumnStyle myStyle = new DataProcess.ColumnStyle(i);

                myStyle.MappingName = this.bindingEntity.ScannedTable.Columns[i].ColumnName;

                if (this.bindingEntity.ScannedTable.Columns[i].ColumnName == "PanelNo")
                {

                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "PanelNo";
                    myStyle.MappingName = "PanelNo";
                    myStyle.Width = 150;
                }

                if (this.bindingEntity.ScannedTable.Columns[i].ColumnName == "PalletGroup")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Group";
                    myStyle.MappingName = "PalletGroup";
                    myStyle.Width = 50;
                }

                if (this.bindingEntity.ScannedTable.Columns[i].ColumnName == "ScannedFlg")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "ScannedFlg";
                    myStyle.MappingName = "ScannedFlg";
                    myStyle.Width = 0;
                }
                if (this.bindingEntity.ScannedTable.Columns[i].ColumnName == "StatusFlg")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "StatusFlg";
                    myStyle.MappingName = "StatusFlg";
                    myStyle.Width = 0;
                }
                dtStyle.GridColumnStyles.Add(myStyle);

            }
            dg.TableStyles.Add(dtStyle);
        }

        public void myStyle_isEven(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                if ((int)dataGrid1[e.Row, 3] == 0 && (int)dataGrid1[e.Row, 2] == 0)
                {
                    e.MeetsCriteria = 0;
                }
                else if ((int)dataGrid1[e.Row, 3] == 0 && (int)dataGrid1[e.Row, 2] == 1)
                {
                    e.MeetsCriteria = 1;
                }
                else if ((int)dataGrid1[e.Row, 3] == 1 && (int)dataGrid1[e.Row, 2] == 1)
                {
                    e.MeetsCriteria = 2;
                }
                else if ((int)dataGrid1[e.Row, 3] == 2)
                {
                    e.MeetsCriteria = 3;
                }
                else if ((int)dataGrid1[e.Row, 3] == 3)
                {
                    e.MeetsCriteria = 4;
                }
                else
                {
                    e.MeetsCriteria = 5;
                }

            }
            catch (Exception ex)
            {
                e.MeetsCriteria = 4;
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshTable()
        {
            List<ScannedGroupTableRow> rows = QRHeaderTable.RetrieveHeaderData();
            this.bindingEntity.ScannedTable.Clear();
            this.bindingEntity.SetBarcodes(rows);
        } 

        private void ScanHeader_Load(object sender, EventArgs e)
        {

            txtQR.Text = "";
            txtQR.Focus();
            dataGrid1.DataSource = this.bindingEntity.ScannedTable;
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            try
            {
                TransmitAllData();
                RefreshTable();
                MessageBox.Show("Data Sent!");
            }
            catch(Exception exc)
            { MessageBox.Show(exc.ToString()); }
            
        }

        private void txtHeader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                string[] QRHeader = txtQR.Text.Split(',');
                if (QRHeader[0] == "1")
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        QRHeaderProcess.ValidateQRHeader(QRHeader);
                        lblConstructionCode.Text = GlobalVariables.ConstructionCode;
                        lblHouse.Text = GlobalVariables.HouseCode;
                        lblRequest.Text = GlobalVariables.Request;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                        RefreshTable();
                    }
                }
                txtQR.Text = "";
                txtQR.Focus();
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.ConstructionCode != "")
            {
                Form group = new ScanGroup();
                group.ShowDialog();
                RefreshTable();
                txtQR.Focus();
            }
        }

        private void lblLegend_ParentChanged(object sender, EventArgs e)
        {
            Form legends = new Legends();
            legends.ShowDialog();
        }

        private void TransmitAllData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.bindingEntity.ScannedTable.Rows.Count == 0)
                    return;
                int maxRows = Convert.ToInt32(Properties.Resources.MaxRows_InOneBatch);

                List<PackageService.UploadScannedTableRow> scannedBarcodes;
                scannedBarcodes = QRHeaderTransmit.RetrieveForService();

                List<PackageService.UploadScannedTableRow> batchBarcodes = new List<PackageService.UploadScannedTableRow>();
                PackageService.UploadScannedResult serviceResult;

                using (var service = new PackageService.Service1())
                {
                    service.Url = Utilities.MyUtilities.ServicePath;
                    int j = 1;
                    int maxBatches = (int)Math.Ceiling((double)scannedBarcodes.Count / maxRows);
                    while (scannedBarcodes.Count > 0 && j <= maxBatches)
                    {
                        int i = 0;
                        batchBarcodes.Clear();
                        while (scannedBarcodes.Count > 0 && i < maxRows)
                        {
                            var row = scannedBarcodes.First();
                            batchBarcodes.Add(row);

                            scannedBarcodes.Remove(row);
                            i++;
                        }

                        serviceResult = service.UploadScannedData(batchBarcodes.ToArray());

                        QRDetailsTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                        if (serviceResult.ServerStatus > 0)
                        {
                            MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                        }

                        j++;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnLegends_Click(object sender, EventArgs e)
        {
            Form legends = new Legends();
            legends.ShowDialog();
            txtQR.Focus();
        }

        private void ScanHeader_Closing(object sender, CancelEventArgs e)
        {
            if (GlobalVariables.ConstructionCode != "")
            {
                QRHeaderProcess.DeleteTransmittedDate();
            }
            GlobalVariables.ConstructionCode = "";
            GlobalVariables.HouseCode = "";
            GlobalVariables.Request = "";
        }

    }

    public class ScannedTableFormRow
    {
        public ScannedTableFormRow()
        {
            this.ScannedTable = new DataTable("ScannedTable");

            this.ScannedTable.Columns.Add("PanelNo", typeof(string));
            this.ScannedTable.Columns.Add("PalletGroup", typeof(string));
            this.ScannedTable.Columns.Add("ScannedFlg", typeof(int));
            this.ScannedTable.Columns.Add("StatusFlg", typeof(int));
            this.ScannedTable.PrimaryKey = new[] { this.ScannedTable.Columns["PanelNo"] };

        }

        public void SetBarcodes(List<ScannedGroupTableRow> barcodes)
        {
            this.ScannedTable.Clear();
            foreach (var barcode in barcodes)
            {
                this.ScannedTable.Rows.Add(
                    barcode.PanelNo,
                    barcode.PalletGroup,
                    barcode.ScannedFlg,
                    barcode.StatusFlg
                );

            }
        }
        public DataTable ScannedTable { get; set; }

    }
}