using System;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ProMap_DataBase_Crypter
{
    class DatabaseConnection
    {
        private static String connStr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
        private static String query = "";

        // firstOrDefault()
        public static ECUsSpecification firstOrDefault(ref ECUsSpecification es, int DefaultID)
        {
            ECUsSpecification Record = new ECUsSpecification();
            query = "SELECT * FROM ECUsSpecification WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }
        public static AdvanceRemap firstOrDefault(ref AdvanceRemap ar, int defaultID)
        {
            query = "SELECT * FROM AdvanceRemap WHERE ID = " + defaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ar.ID = int.Parse(reader["ID"].ToString());
                        ar.Type = reader["Type"].ToString();
                        ar.TableName = reader["TableName"].ToString();
                        ar.RowsCount = reader["RowsCount"].ToString();
                        ar.ColsCount = reader["ColsCount"].ToString();
                        ar.X_Name = reader["X_Name"].ToString();
                        ar.Y_Name = reader["Y_Name"].ToString();
                        ar.X_Min = reader["X_Min"].ToString();
                        ar.X_Max = reader["X_Max"].ToString();
                        ar.Y_Min = reader["Y_Min"].ToString();
                        ar.Y_Max = reader["Y_Max"].ToString();
                        ar.Address_Start = reader["Address_Start"].ToString();
                        ar.Address_End = reader["Address_End"].ToString();
                        ar.DataSize = reader["DataSize"].ToString();
                        ar.Type_Cryption = reader["Type_Cryption"].ToString();
                        ar.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        ar.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        ar.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        ar.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        ar.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        ar.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        ar.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        ar.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ar;
        }

        // Count The Number Of Records In A Table
        public static int countInTable(String tbName)
        {
            int numOfRecs = 0;
            query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName;

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    numOfRecs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return numOfRecs;
        }

        // Find The Last Record's ID From A Table
        public static int lastId(String tbName)
        {
            int lastId = 0;
            query = "SELECT MAX(ID) AS LastECU FROM " + tbName + ";";

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    lastId = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return lastId;
        }

        // Update A Table Row
        public static bool updateTable(ECUsSpecification newValue)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connStr);
            query = "UPDATE ECUsSpecification SET " +
                    "Manufacturer ='" + newValue.Manufacturer +
                    "' ,DeviceName ='" + newValue.DeviceName +
                    "' ,Type ='" + newValue.Type +
                    "' ,BootRef ='" + newValue.BootRef +
                    "' ,SoftRef ='" + newValue.SoftRef +
                    "' ,Calibration ='" + newValue.Calibration +
                    "' ,BinFileName ='" + newValue.BinFileName +
                    "' ,BaudRate ='" + newValue.BaudRate +
                    "' ,CRC_Address ='" + newValue.CRC_Address +
                    "' ,ConnectionID =" + newValue.ConnectionID +
                    " ,Type1_AddressRemap ='" + newValue.Type1_AddressRemap +
                    "' ,Type2_TableRemap ='" + newValue.Type2_TableRemap +
                    "' ,ProductNumber ='" + newValue.ProductNumber +
                    "' ,HardwareCode ='" + newValue.HardwareCode +
                    "' ,Comment ='" + newValue.Comment +
                    "' ,UserID =" + newValue.UserID +
                    " ,type1Cryption ='" + newValue.type1Cryption +
                    "' ,binCryption = '" + newValue.binCryption +
                    "' ,crcCryption = '" + newValue.crcCryption +
                    "' WHERE ID = " + newValue.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isUpdated;
        }
        public static bool updateTable(AdvanceRemap New_Value)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connStr);
            query = "UPDATE AdvanceRemap SET " +
                "Type ='" + New_Value.Type +
                "' ,TableName ='" + New_Value.TableName +
                "' ,RowsCount =" + New_Value.RowsCount +
                " ,ColsCount =" + New_Value.ColsCount +
                " ,X_Name ='" + New_Value.X_Name +
                "' ,Y_Name ='" + New_Value.Y_Name +
                "' ,X_Min =" + New_Value.X_Min +
                " ,X_Max =" + New_Value.X_Max +
                " ,Y_Min =" + New_Value.Y_Min +
                " ,Y_Max =" + New_Value.Y_Max +
                " ,Address_Start ='" + New_Value.Address_Start +
                "' ,Address_End ='" + New_Value.Address_End +
                "' ,DataSize =" + New_Value.DataSize +
                " ,Type_Cryption ='" + New_Value.Type_Cryption +
                "' ,TableName_Cryption ='" + New_Value.TableName_Cryption +
                "' ,RowsCount_Cryption ='" + New_Value.RowsCount_Cryption +
                "' ,ColsCount_Cryption ='" + New_Value.ColsCount_Cryption +
                "' ,X_Name_Cryption ='" + New_Value.X_Name_Cryption +
                "' ,Y_Name_Cryption = '" + New_Value.Y_Name_Cryption +
                "' ,Address_Start_Cryption = '" + New_Value.Address_Start_Cryption +
                "' ,Address_End_Cryption = '" + New_Value.Address_End_Cryption +
                "' ,DataSize_Cryption = '" + New_Value.DataSize_Cryption +
                "' WHERE ID = " + New_Value.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;                
                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }
            return isUpdated;
        }

        // Show Database Data On The Data Grid View
        public static DataTable showOnGridView(ECUsSpecification es)
        {
            query = "SELECT * FROM ECUsSpecification;";
            DataTable dtEcus = new DataTable();

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    dtEcus.Load(reader);
                    con.Close();
                }
            }
            return dtEcus;
        }
        public static DataTable showOnGridView(AdvanceRemap es)
        {
            query = "SELECT * FROM AdvanceRemap;";
            DataTable dtEcus = new DataTable();

            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    dtEcus.Load(reader);
                    con.Close();
                }
            }
            return dtEcus;
        }
    }
}
