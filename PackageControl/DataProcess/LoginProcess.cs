using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace PackageControl.DataProcess
{
    public class LoginProcess
    {
        public static void CheckLogin(string prEmployeeCode)
        {
            string EmployeeCode;

            EmployeeCode = prEmployeeCode.Length == 10 ? EvaluateEmployeeID(prEmployeeCode) : prEmployeeCode;

            string strCheckUser = "Select count(EmployeeCode) from UserLogin " +
                                  "Where EmployeeCode='" + EmployeeCode + "' ";

            string strInsertUser = "Insert Into UserLogin " +
                                   "values('" + EmployeeCode + "',0)";

            string strGetDesig = "Select * from UserLogin " +
                        "where EmployeeCode = '" + EmployeeCode + "' ";


            int cntCheck = Config.ExecuteIntScalar(strCheckUser);
            if (cntCheck == 0)
            {
                //INSERT
                Config.ExecuteCmd(strInsertUser);
                GlobalVariables.EmployeeCode = EmployeeCode;
                GlobalVariables.Designation=0;
            }
            else
            {
                DataTable dtable = new DataTable();
                dtable = Config.RetreiveData(strGetDesig);
                foreach (DataRow row in dtable.Rows)
                {
                    GlobalVariables.EmployeeCode = row["EmployeeCode"].ToString();
                    GlobalVariables.Designation = row["Designation"].ToString() == "" ? 0 : Convert.ToInt32(row["Designation"]);
                }
            }
        }


        private static string EvaluateEmployeeID(string EmployeeID)
        {
            string GetCompanyEmployeeID = "";
            string ValidatedID;
            char validateEmployeeID;

            EmployeeID = EmployeeID.Substring(0, EmployeeID.Length - 1);

            validateEmployeeID = Convert.ToChar(EmployeeID.Substring(2, 1));
            try
            {
                //HR
                if (validateEmployeeID == 'R' || validateEmployeeID == '3')
                {
                    GetCompanyEmployeeID = EmployeeID.Substring(4, 5);
                }
                //PV
                else if (validateEmployeeID == 'P' || validateEmployeeID == '0')
                {
                    GetCompanyEmployeeID = '0' + EmployeeID.Substring(4, 6);
                }
                //SCAD
                else if (validateEmployeeID == 'S' || validateEmployeeID == '1')
                {
                    GetCompanyEmployeeID = '1' + EmployeeID.Substring(4, 6);
                }
                //HTI
                else if (validateEmployeeID == 'H' || validateEmployeeID == '2')
                {
                    GetCompanyEmployeeID = '2' + EmployeeID.Substring(3, 6);
                }
                //WKN
                else if (validateEmployeeID == 'W' || validateEmployeeID == '4')
                {
                    GetCompanyEmployeeID = '4' + EmployeeID.Substring(4, 6);
                }
            }
            finally
            {
                ValidatedID = GetCompanyEmployeeID.ToString();
            }
            return ValidatedID;
        }

        public static void UpdateDesignation(int Desig)
        {

            string strUpdate = "Update UserLogin " +
                               "set Designation = " + Desig + " " +
                               "Where EmployeeCode = '"+GlobalVariables.EmployeeCode+"' ";

            Config.ExecuteCmd(strUpdate);

            GlobalVariables.Designation = Desig;
        }

    }
}
