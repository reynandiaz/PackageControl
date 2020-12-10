using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace PackageControl.DataProcess
{
    public class QRHeaderProcess
    {
        public static void ValidateQRHeader(string[] QRHeader)
        {

            string strDetailsExist = "Select count(ConstructionCode) from Details " +
                                        "where ConstructionCode = '" + QRHeader[1] + "' " +
                                        "and HouseCode = '" + QRHeader[2] + "' " +
                                        "and Request = '" + QRHeader[3] + "' and Designation = "+ GlobalVariables.Designation;
           

            int chkCnt = Config.ExecuteIntScalar(strDetailsExist);
            if (chkCnt == 0)
            {
                for (int x = 1; x <= Convert.ToInt32(QRHeader[4]); x++)
                {
                    string strInsertDetails = "Insert Into Details " +
                          "values( " +
                          "'" + QRHeader[1] + "', " +
                          "'" + QRHeader[2] + "', " +
                          "'" + QRHeader[3] + "', " +
                          "'" + QRHeader[x + 4] +"', " +
                          "'-', " +
                          "0, " +
                          "0, " +
                          GlobalVariables.Designation+") ";

                    Config.ExecuteCmd(strInsertDetails);
                
                }
                GlobalVariables.ConstructionCode = QRHeader[1];
                GlobalVariables.HouseCode = QRHeader[2];
                GlobalVariables.Request = QRHeader[3];
            }
            else
            {
                GlobalVariables.ConstructionCode = QRHeader[1];
                GlobalVariables.HouseCode = QRHeader[2];
                GlobalVariables.Request = QRHeader[3];

            }
        }

        public static void DeleteTransmittedDate()
        {
            string strDelete = "Delete from Details " +
                               "where ConstructionCode = '" + GlobalVariables.ConstructionCode + "' " +
                               "and Request = '" + GlobalVariables.Request + "' " +
                               "and HouseCode = '" + GlobalVariables.HouseCode + "' " +
                               "and Designation = "+ GlobalVariables.Designation +" " +
                               "and StatusFlg =2 ";
            Cursor.Current = Cursors.WaitCursor;
            Config.ExecuteCmd(strDelete);
            Cursor.Current = Cursors.Default;

        }
    }
}
