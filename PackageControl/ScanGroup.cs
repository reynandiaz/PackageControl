using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PackageControl.DataProcess;
using System.Data.SqlServerCe;
using PackageControl.Utilities;

namespace PackageControl
{
    public partial class ScanGroup : Form
    {

        private ScannedGroupDetailsFormRow groupdetailsEntity = new ScannedGroupDetailsFormRow();

        public ScanGroup()
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
            dtStyle.MappingName = "ScannedGroupTable";

            DataTable dt = this.groupdetailsEntity.ScannedGroupTable;
            for (int i = 0; i < this.groupdetailsEntity.ScannedGroupTable.Columns.Count; i++)
            {

                DataProcess.ColumnStyle myStyle = new DataProcess.ColumnStyle(i);

                myStyle.MappingName = this.groupdetailsEntity.ScannedGroupTable.Columns[i].ColumnName;

                if (this.groupdetailsEntity.ScannedGroupTable.Columns[i].ColumnName == "PanelNo")
                {

                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "PanelNo";
                    myStyle.MappingName = "PanelNo";
                    myStyle.Width = 130;
                }
                if (this.groupdetailsEntity.ScannedGroupTable.Columns[i].ColumnName == "ScannedFlg")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "ScannedFlg";
                    myStyle.MappingName = "ScannedFlg";
                    myStyle.Width = 0;
                }
                if (this.groupdetailsEntity.ScannedGroupTable.Columns[i].ColumnName == "StatusFlg")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Status";
                    myStyle.MappingName = "StatusFlg";
                    myStyle.Width =0;
                }
                dtStyle.GridColumnStyles.Add(myStyle);
                
            }
            dg.TableStyles.Add(dtStyle);
        }

        public void myStyle_isEven(object sender, DataGridEnableEventArgs    e)
        {
            try
            {
                if ((int)dataGrid1[e.Row, 2] == 0 && (int)dataGrid1[e.Row, 1] == 0)
                {
                    e.MeetsCriteria = 0;
                }
                else if ((int)dataGrid1[e.Row, 2] == 0 && (int)dataGrid1[e.Row, 1] == 1)
                {
                    e.MeetsCriteria = 1;
                }
                else if ((int)dataGrid1[e.Row, 2] ==1 && (int)dataGrid1[e.Row, 1] == 1)
                {
                    e.MeetsCriteria = 2; 
                }
                else if ((int)dataGrid1[e.Row, 2] == 2)
                {
                    e.MeetsCriteria = 3;
                }
                else if ((int)dataGrid1[e.Row, 2] == 3)
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


        private void ScanGroup_Load(object sender, EventArgs e)
        {
            lblConstructionCode.Text = GlobalVariables.ConstructionCode;
            lblHouse.Text = GlobalVariables.HouseCode;
            lblRequest.Text = GlobalVariables.Request;
            chkDirect.Checked = true;
            dataGrid1.DataSource = this.groupdetailsEntity.ScannedGroupTable;
            txtQR.Text = "";
            txtQR.Focus();
        }


        private void txtQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                try
                {
                    string[] QRDetails = txtQR.Text.Split(',');
                    if (QRDetails[0] == "4") 
                    {
                        if (QRDetails[1] == GlobalVariables.ConstructionCode && QRDetails[2] == GlobalVariables.HouseCode && QRDetails[3] == GlobalVariables.Request)
                        {
                            //truncate and insert group qr details
                            QRDetailsProcess.ValidateGroupQR(QRDetails);
                            txtGroup.Text = QRDetails[4].ToString();

                            //Update scanned panels 
                            QRDetailsProcess.UpdateGroupScanned(QRDetails);
                            RefreshTable();
                        }
                    }
                    else if (QRDetails[0] == "2" && txtGroup.Text!="")
                    {
                        if (QRDetails[1] == GlobalVariables.ConstructionCode && QRDetails[2] == GlobalVariables.HouseCode && QRDetails[3] == GlobalVariables.Request)
                        {
                            bool blSendData = QRDetailsProcess.ValidateStickerQR(QRDetails, txtGroup.Text);

                            //TRANSMIT SINGLE DATA OF DIRECT IS CHECKED
                            if (blSendData==true && chkDirect.Checked)
                            {
                                List<ScannedGroupTableRow> rows = QRDetailsTransmit.RetrieveSingleData(QRDetails);
                                TransmitScannedData(rows,"singledata");
                            }
                            RefreshTable();
                        }
                    }
                }
                finally
                {
                    txtQR.Text="";
                    txtQR.Focus();
                }

            }
        }
        private void RefreshTable()
        {
            List<ScannedGroupTableRow> rows = QRDetailsTable.RetrieveGroupData(txtGroup.Text);
            this.groupdetailsEntity.ScannedGroupTable.Clear();
            this.groupdetailsEntity.SetGroupBarcodes(rows);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            List<ScannedGroupTableRow> rows = QRDetailsTransmit.RetrieveGroupDataForTransmit(lblConstructionCode.Text,lblRequest.Text,lblHouse.Text);
            TransmitScannedData(rows, "groupdata");
            RefreshTable();
            MessageBox.Show("Data Sent!");
        }

        private void TransmitScannedData(List<ScannedGroupTableRow> rows,string strTransmitType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<PackageService.UploadScannedTableRow> scannedBarcodes;
                scannedBarcodes = QRDetailsTransmit.RetrieveForService(rows);


                List<PackageService.UploadScannedTableRow> batchBarcodes = new List<PackageService.UploadScannedTableRow>();

                PackageService.UploadScannedResult serviceResult;

                var service = new PackageService.Service1();
                
                    if (strTransmitType == "singledata")
                    {
                        serviceResult = service.UploadScannedData(scannedBarcodes.ToArray());
                        //STATUS
                        //1=success
                        //2=already scanned
                        //3=failed
                        DataProcess.QRDetailsTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                        if (serviceResult.ServerStatus > 0)
                        {
                            MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                        }
                    }
                    else if (strTransmitType == "groupdata")
                    {
                        int maxRows = Convert.ToInt32(Properties.Resources.MaxRows_InOneBatch);
                        int j = 1;
                        int maxBatches = (int)Math.Ceiling((double)scannedBarcodes.Count / maxRows);
                        while (scannedBarcodes.Count > 0 && j <= maxBatches)
                        {
                            int i = 0;
                            batchBarcodes.Clear();
                            while (scannedBarcodes.Count > 0 && i < maxRows)
                            {
                                var scannedrow = scannedBarcodes.First();
                                batchBarcodes.Add(scannedrow);

                                scannedBarcodes.Remove(scannedrow);
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


    }

    //class declaration
    public class ScannedGroupDetailsFormRow
    {
        public DataTable ScannedGroupTable { get; set; }

        public ScannedGroupDetailsFormRow()
        {
            this.ScannedGroupTable = new DataTable("ScannedGroupTable");

            this.ScannedGroupTable.Columns.Add("PanelNo", typeof(string));
            this.ScannedGroupTable.Columns.Add("ScannedFlg", typeof(int));
            this.ScannedGroupTable.Columns.Add("StatusFlg", typeof(int));
            this.ScannedGroupTable.PrimaryKey = new[] { this.ScannedGroupTable.Columns["PanelNo"] };
        }

        public void SetGroupBarcodes(List<ScannedGroupTableRow> barcodes)
        {
            this.ScannedGroupTable.Clear();
            foreach (var barcode in barcodes)
            {
                this.ScannedGroupTable.Rows.Add(
                    barcode.PanelNo,
                    barcode.ScannedFlg,
                    barcode.StatusFlg
                );
            }
        }

    }
}