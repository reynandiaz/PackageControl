using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace PackageControl.DataProcess
{
    public class QRHeaderTable
    {
        public static List<ScannedGroupTableRow> RetrieveHeaderData()
        {
            string query = "Select * from Details " +
                           "where ConstructionCode ='"+ GlobalVariables.ConstructionCode +"'  " +
                           " and HouseCode = '"+ GlobalVariables.HouseCode +"' " +
                           "and Request = '" +GlobalVariables.Request+ "' "+
                           "and Designation= "+GlobalVariables.Designation;

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
