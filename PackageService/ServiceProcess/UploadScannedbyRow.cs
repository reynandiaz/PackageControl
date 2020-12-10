using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace PackageService.ServiceProcess
{
    public class UploadScannedbyRow
    {
        public static void TransmitScannedData(UploadScannedTableRow row,SqlTransaction transaction,SqlConnection connection)
        {
            try
            {
                string strDesignation = "";
                switch (Convert.ToInt32(row.Designation))
                {
                    case 1:
                        strDesignation = "PanelStickerScanned_Ceiling";
                        break;
                    case 2:
                        strDesignation = "PanelStickerScanned_Gable";
                        break;
                    case 3:
                        strDesignation = "PanelStickerScanned_Roof";
                        break;
                    case 4:
                        strDesignation = "PanelStickerScanned_Wall";
                        break;
                }

                string strCheck = "Select count(PanelNumber) as MaxPanel from " + strDesignation +
                    " where CDNo = '" + row.ConstructionCode + "' and " +
                    "PanelNumber = '" + row.PanelNo + "'";

                string strInsert = "INSERT INTO dbo." + strDesignation + " " +
                                "	( " +
                                "	CDNo, " +
                                "	PanelNumber, " +
                                "	RequestNo, " +
                                "	PalletGroup, " +
                                "	UploadedFlg, " +
                                "	UploadDate, " +
                                "	ShukkaDate, " +
                                "	CreatedDate, " +
                                "	DeletedDate, " +
                                "	UpdatedDate, " +
                                "	UpdatedBy " +
                                "	) " +
                                "VALUES  " +
                                "	( " +
                                "	'" + row.ConstructionCode + "', " +
                                "	'" + row.PanelNo + "', " +
                                "	'" + row.Request + "', " +
                                "	'" + row.PalletGroup + "', " +
                                "	1, " +
                                "	getdate(), " +
                                "	null, " +
                                "	getdate(), " +
                                "	null, " +
                                "	getdate(), " +
                                "	'" + row.UpdatedBy + "' " +
                                "	) ";



                var cmdCheck = new SqlCommand(strCheck, connection, transaction);

                var cntCheck = cmdCheck.ExecuteScalar();
                if (Convert.ToInt32(cntCheck) == 0)
                {
                    var cmdInsert = new SqlCommand(strInsert, connection, transaction);
                    cmdInsert.ExecuteNonQuery();
                    row.StatusFlg = 1;
                }
                else
                {
                    row.StatusFlg = 2;
                }
            }
            catch (Exception exc)
            {
                row.ErrMsg = exc.ToString();
                row.StatusFlg = 3;
            }
        }
    }
    public class UploadScannedTableRow
    {
        public UploadScannedTableRow()
        {
        }
        public UploadScannedTableRow(DataRow row)
        {
            this.ConstructionCode = row["ConstructionCode"].ToString();
            this.Request = row["Request"].ToString();
            this.HouseCode = row["HouseCode"].ToString();
            this.PanelNo = row["PanelNo"].ToString();
            this.ScannedFlg = Convert.ToInt32(row["ScannedFlg"]);
            this.StatusFlg = Convert.ToInt32(row["StatusFlg"]);
            this.Designation = Convert.ToInt32(row["Designation"]);
            this.UpdatedBy = row["UpdatedBy"].ToString();
            this.PalletGroup = row["PalletGroup"].ToString();
        }
        //creates the field
        public string ConstructionCode { get; set; }
        public string Request { get; set; }
        public string HouseCode { get; set; }
        public string PanelNo { get; set; }
        public int ScannedFlg { get; set; }
        public int StatusFlg { get; set; }
        public int Designation { get; set; }
        public string UpdatedBy { get; set; }
        public string PalletGroup { get; set; }

        public string ErrMsg { get; set; }
    }
}
