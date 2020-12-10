using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;


namespace PackageControl.DataProcess
{
    public class Initialization
    {
        public static void Initialize()
        { 


#if DEBUG
        if (File.Exists(Properties.Resources.DatabaseFileName))
            {
                File.Delete(Properties.Resources.DatabaseFileName);
                CreateDatabase();
            }
            else
            {
                CreateDatabase();
            }
#else
            if (!File.Exists(Properties.Resources.DatabaseFileName))
            { CreateDatabase(); }
#endif

        }

        private static void CreateDatabase()
        {
            var engine = new SqlCeEngine(Properties.Resources.ConnectionSDF);
            engine.CreateDatabase();


            CreateLoginTable();
            CreateQRDetails();
            CreateScanGroup();

            
        }

        private static void CreateLoginTable()
        {
            string query = "Create Table UserLogin " +
                "( " +
                "EmployeeCode nvarchar(10) not null, " +
                "Designation INT, " +
                "Primary key (EmployeeCode)  " +
                ") ";
            Config.ExecuteCmd(query);

        }
        private static void CreateQRDetails()
        {

            string  query = "Create Table Details( "+ 
                                " ConstructionCode    nvarchar(20) not null"+ 
                                " ,HouseCode  nvarchar(5) not null"+ 
                                " ,Request  nvarchar(20) not null"+ 
                                " ,PanelNo  nvarchar(50) not null"+ 
                                " ,PalletGroup  nvarchar(10)"+
                                " ,ScannedFlg  numeric(1)"+ 
                                " ,StatusFlg  numeric(1)"+ 
                                " ,Designation numeric(1)"+
                                " ,CONSTRAINT PK_Control PRIMARY KEY ("+
                                "     ConstructionCode,HouseCode,Request,PanelNo,Designation)" +
                                " )";

            Config.ExecuteCmd(query);
        }
        private static void CreateScanGroup()
        {
            string query = "Create Table ScanGroup( " +
                                " ConstructionCode    nvarchar(20) not null " +
                                "  ,HouseCode  nvarchar(5) not null " +
                                "  ,Request  nvarchar(20) not null " +
                                "  ,PanelNo  nvarchar(50) not null " +
                                "  ,ScannedFlg  numeric(1)" + 
                                "  ,StatusFlg  numeric(1) " +
                                "  ,Designation  numeric(1) " +
                                "  ,CONSTRAINT PK_Control PRIMARY KEY  " +
                                "      (ConstructionCode,HouseCode,Request,PanelNo,Designation) " +
                                "  )";

            Config.ExecuteCmd(query);
        }
    }
}
