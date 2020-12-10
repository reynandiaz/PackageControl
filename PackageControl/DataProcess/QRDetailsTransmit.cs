using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PackageControl.DataProcess
{
    public class QRDetailsTransmit
    {
        public static void UpdateLocalWithTransmittedData(PackageService.UploadScannedTableRow[] rows)
        {
            foreach (PackageService.UploadScannedTableRow row in rows)
            {
                string strUpdateDetails = "Update Details " +
                                   "set StatusFlg =" + Convert.ToInt32(row.StatusFlg) + ", ScannedFlg=" +Convert.ToInt32(row.ScannedFlg) +
                                   " where ConstructionCode ='" + row.ConstructionCode + "' " +
                                   "and Request = '" + row.Request.ToString() + "' " +
                                   "and PanelNo ='" + row.PanelNo.ToString() + "'" +
                                   "and Designation = " + Convert.ToInt32(row.Designation);
                Config.ExecuteCmd(strUpdateDetails);

                string strUpdateGroup = "Update ScanGroup " +
                                   "set StatusFlg = " + Convert.ToInt32(row.StatusFlg) + " " +
                                   "where ConstructionCode ='" + row.ConstructionCode + "' " +
                                   "and Request = '" + row.Request.ToString() + "' " +
                                   "and PanelNo = '" + row.PanelNo + "' " +
                                   "and Designation =" + Convert.ToInt32(row.Designation);
                Config.ExecuteCmd(strUpdateGroup);
            }
        }

        public static List<ScannedGroupTableRow> RetrieveSingleData(string[] QRDetails)
        {

            string Query = "SELECT * FROM Details " +
                            "where ConstructionCode = '" + QRDetails[1].ToString() + "' " +
                            "and Request = '" + QRDetails[3].ToString() + "' " +
                            "AND PanelNo='" + QRDetails[4].ToString() + "'";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(Query, Properties.Resources.ConnectionSDF))
            {
                adapter.Fill(table);
            }
            var result = new List<ScannedGroupTableRow>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ScannedGroupTableRow(row));
            }
            return result;
        }


        public static List<ScannedGroupTableRow> RetrieveGroupDataForTransmit(string  ConstructionCode,string Request,string HouseCode)
        {
            string Query = "SELECT * FROM Details " +
                            " where ConstructionCode = '" + ConstructionCode + "' " +
                            "and Request = '" + Request + "' and HouseCode ='" + HouseCode +"' "+
                            "AND PanelNo in (Select PanelNo from ScanGroup where ScannedFlg=1 and StatusFlg<>2)";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(Query, Properties.Resources.ConnectionSDF))
            {
                adapter.Fill(table);
            }
            var result = new List<ScannedGroupTableRow>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ScannedGroupTableRow(row));
            }
            return result;
        }


        public static List<PackageService.UploadScannedTableRow> RetrieveForService(List<ScannedGroupTableRow> localRows)
        {
            var serviceRows = new List<PackageService.UploadScannedTableRow>();

            foreach (ScannedGroupTableRow localRow in localRows)
            {
                var serviceRow = new PackageService.UploadScannedTableRow();

                serviceRow.ConstructionCode = localRow.ConstructionCode;
                serviceRow.Request = localRow.Request;
                serviceRow.HouseCode = localRow.HouseCode;
                serviceRow.PanelNo = localRow.PanelNo;
                serviceRow.StatusFlg = localRow.StatusFlg;
                serviceRow.Designation = localRow.Designation;
                serviceRow.UpdatedBy = localRow.UpdatedBy;
                serviceRow.PalletGroup = localRow.PalletGroup;
                serviceRow.ScannedFlg = localRow.ScannedFlg;

                serviceRows.Add(serviceRow);
            }
            return serviceRows;
        }

    }
}
