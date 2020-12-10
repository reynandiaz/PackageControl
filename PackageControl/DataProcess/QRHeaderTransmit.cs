using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace PackageControl.DataProcess
{
    public class QRHeaderTransmit
    {
        public static List<PackageService.UploadScannedTableRow> RetrieveForService()
        {
            List<ScannedGroupTableRow> localRows;

            localRows = QRHeaderTransmit.RetrieveHeaderDataForTransmit();

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

        public static List<ScannedGroupTableRow> RetrieveHeaderDataForTransmit()
        {
            string query = "Select * from Details " +
                           "where ConstructionCode = '" + GlobalVariables.ConstructionCode + "'  " +
                           " and HouseCode ='" + GlobalVariables.HouseCode + "' " +
                           "and Request = '" + GlobalVariables.Request +"' " +
                           "and Designation= "+ GlobalVariables.Designation +" and ScannedFlg=1";


            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(query, Properties.Resources.ConnectionSDF))
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
    }
}
