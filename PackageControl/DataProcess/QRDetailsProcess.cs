using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace PackageControl.DataProcess
{
    public class QRDetailsProcess
    {
        public static void ValidateGroupQR(string[] QRDetails)
        {
            string strTruncate = "Delete from  ScanGroup";
            Config.ExecuteCmd(strTruncate);

            for (var x=1; x <= Convert.ToInt32(QRDetails[5]); x++)
            {
                string strInsert = "Insert into ScanGroup " +
                    "values ( " +
                    "'" + QRDetails[1] + "', " +
                    "'" + QRDetails[2] + "', " +
                    "'" + QRDetails[3] + "', " +
                    "'" + QRDetails[x + 5] + "', " +
                    "0, " +
                    "0, " +
                    GlobalVariables.Designation + ") ";

                Config.ExecuteCmd(strInsert);
            }
        }

        public static bool ValidateStickerQR(string[] QRDetails,string strPalletGroup)
        {

            bool blSendData = false;

            string strCheck = "Select count(PanelNo) from ScanGroup "+
                              "where ConstructionCode = '"+ QRDetails[1] +"' "+
                              "and HouseCode = '"+ QRDetails[2] +"' "+
                              "and Request = '" + QRDetails[3] + "' " +
                              "and PanelNo = '" + QRDetails[4] + "' " +
                              "and Designation  = "+ GlobalVariables.Designation;

            string strUpdateScanGroup = "Update ScanGroup " +
                               "set ScannedFlg=1 " +
                              "where ConstructionCode = '" + QRDetails[1] + "' " +
                              "and HouseCode = '" + QRDetails[2] + "' " +
                              "and Request = '" + QRDetails[3] + "' " +
                              "and PanelNo = '" + QRDetails[4] + "' " +
                              "and Designation  = " + GlobalVariables.Designation;

            string strUpdateDetails = "Update Details "+
                                      "set ScannedFlg=1,PalletGroup='" + strPalletGroup + "' " +
                                      "where ConstructionCode = '" + QRDetails[1] + "' " +
                                      "and HouseCode = '" + QRDetails[2] + "' " +
                                      "and Request = '" + QRDetails[3] + "' " +
                                      "and PanelNo = '" + QRDetails[4] + "' " +
                                      "and Designation  = " + GlobalVariables.Designation;
          
            int cntCheck = Config.ExecuteIntScalar(strCheck);
            if (cntCheck != 0)
            {
                Config.ExecuteCmd(strUpdateScanGroup);
                Config.ExecuteCmd(strUpdateDetails);
                blSendData = true;
            }
            return blSendData;
        }

        public static void UpdateGroupScanned(string[] QRDetails)
        {
            string strSelect = "Select * from Details " +
                "where ConstructionCode = '" + QRDetails[1] + "' " +
                "AND HouseCode = '" + QRDetails[2] + "' AND Request = '" + QRDetails[3] + "' " +
                "AND PanelNo in (Select PanelNo from ScanGroup ) and Designation="+ GlobalVariables.Designation;

            DataTable dtable = Config.RetreiveData(strSelect);

            foreach(DataRow row in dtable.Rows)
            {
                string strPanel = "Update ScanGroup " +
                                  "set StatusFlg=" + row["StatusFlg"] + ",ScannedFlg =" + row["ScannedFlg"] + " " +
                                  "where PanelNo='" + row["PanelNo"].ToString() + "' " +
                                  "and ConstructionCode = '"+ row["ConstructionCode"].ToString() +"' "+
                                  "and Request='" + row["Request"].ToString() + "' and HouseCode = '" + row["HouseCode"].ToString() + "' " +
                                  "and Designation = " + Convert.ToInt32(row["Designation"]);
                Config.ExecuteCmd(strPanel);
            }
        }

    }
}
