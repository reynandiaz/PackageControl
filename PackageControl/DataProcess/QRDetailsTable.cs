using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace PackageControl.DataProcess
{
    public class QRDetailsTable
    {
        public static List<ScannedGroupTableRow> RetrieveGroupData(string PalletGroup)
        {
            string query = "Select *,'" + PalletGroup + "' as PalletGroup  from ScanGroup ";

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
    public class ScannedGroupTableRow
    {

        public ScannedGroupTableRow()
        {
        }

        public ScannedGroupTableRow(DataRow row)
        {
            this.ConstructionCode = row["ConstructionCode"].ToString();
            this.Request = row["Request"].ToString();
            this.HouseCode = row["HouseCode"].ToString();
            this.PanelNo = row["PanelNo"].ToString();
            this.ScannedFlg = Convert.ToInt32(row["ScannedFlg"]);
            this.StatusFlg = Convert.ToInt32(row["StatusFlg"]);
            this.Designation = Convert.ToInt32(row["Designation"]);
            this.UpdatedBy = GlobalVariables.EmployeeCode;
            this.PalletGroup = row["PalletGroup"].ToString();

        }
        //creates the field
        public string ConstructionCode { get; set; }
        public string Request { get; set; }
        public string HouseCode { get; set;}
        public string PanelNo { get; set; }
        public int ScannedFlg { get; set; }
        public int StatusFlg { get; set; }
        public int Designation { get; set; }
        public string UpdatedBy { get; set; }
        public string PalletGroup { get; set; }
    }
}
