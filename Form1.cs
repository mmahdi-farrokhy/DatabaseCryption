using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace ProMap_DataBase_Crypter
{
    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            string text = comboBox1.Text.ToUpper();
            DataTable dtEcus = new DataTable();

            switch (text)
            {
                case "ECUS SPECIFICATION":
                    dtEcus = DatabaseConnection.showOnGridView(new ECUsSpecification());
                    dataGridView1.DataSource = dtEcus;
                    comboBox_Cols_Name.Items.Clear();
                    comboBox_Cols_Name.Items.Add("crc address");
                    comboBox_Cols_Name.Items.Add("type1 remap type");
                    comboBox_Cols_Name.Items.Add("type2 remap type");
                    comboBox_Cols_Name.Items.Add("bin file name");
                    break;

                case "ADVANCE REMAP":
                    dtEcus = DatabaseConnection.showOnGridView(new AdvanceRemap());                                      
                    dataGridView1.DataSource = dtEcus;
                    comboBox_Cols_Name.Items.Clear();
                    comboBox_Cols_Name.Items.Add("rows count");
                    comboBox_Cols_Name.Items.Add("table name");
                    comboBox_Cols_Name.Items.Add("x name");
                    comboBox_Cols_Name.Items.Add("y name");
                    comboBox_Cols_Name.Items.Add("x min");
                    comboBox_Cols_Name.Items.Add("x max");
                    comboBox_Cols_Name.Items.Add("y min");
                    comboBox_Cols_Name.Items.Add("y max");
                    comboBox_Cols_Name.Items.Add("address end");
                    comboBox_Cols_Name.Items.Add("address start");
                    comboBox_Cols_Name.Items.Add("cols count");
                    comboBox_Cols_Name.Items.Add("data size");
                    break;

                default:
                    comboBox_Cols_Name.Items.Clear();
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1_TextUpdate(sender, e);
        }

        private void checkBox_Rows_All_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rows_All.Checked)
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_SelectedRow.Enabled = false;
                checkBox_Rows_Advance.Checked = false;
                checkBox_Rows_Advance.Enabled = false;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }

            else
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_SelectedRow.Enabled = true;
                checkBox_Rows_Advance.Checked = false;
                checkBox_Rows_Advance.Enabled = true;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }
        }

        private void checkBox_Rows_SelectedRow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rows_SelectedRow.Checked)
            {
                checkBox_Rows_All.Checked = false;
                checkBox_Rows_All.Enabled = false;
                checkBox_Rows_Advance.Checked = false;
                checkBox_Rows_Advance.Enabled = false;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }

            else
            {
                checkBox_Rows_All.Checked = false;
                checkBox_Rows_All.Enabled = true;
                checkBox_Rows_Advance.Checked = false;
                checkBox_Rows_Advance.Enabled = true;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }

        }

        private void checkBox_Rows_Advance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rows_Advance.Checked)
            {
                checkBox_Rows_All.Checked = false;
                checkBox_Rows_All.Enabled = false;
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_SelectedRow.Enabled = false;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = true;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = true;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }

            else
            {
                checkBox_Rows_All.Checked = false;
                checkBox_Rows_All.Enabled = true;
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_SelectedRow.Enabled = true;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                checkBox_Rows_Advance_One.Checked = false;            
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }

        }

        private void checkBox_Rows_Advance_Area_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rows_Advance_Area.Checked)
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = false;
                textBox_Rows_Area_start.Enabled = true;
                textBox_Rows_Area_end.Enabled = true;
                textBox_Rows_RowNumber.Enabled = false;
            }

            else
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_Advance_One.Checked = false;
                checkBox_Rows_Advance_One.Enabled = true;
                textBox_Rows_Area_start.Enabled = false;
                textBox_Rows_Area_end.Enabled = false;
                textBox_Rows_RowNumber.Enabled = false;
            }
        }

        private void checkBox_Rows_Advance_One_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rows_Advance_One.Checked)
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = false;
                textBox_Rows_RowNumber.Enabled = true;
            }

            else
            {
                checkBox_Rows_SelectedRow.Checked = false;
                checkBox_Rows_Advance_Area.Checked = false;
                checkBox_Rows_Advance_Area.Enabled = true;
                textBox_Rows_RowNumber.Enabled = false;
            }
        }

        private void checkBox_Cols_All_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cols_All.Checked)
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_SelectedCol.Enabled = false;
                checkBox_Cols_Advance.Checked = false;
                checkBox_Cols_Advance.Enabled = false;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = false;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = false;
                textBox_Cols_Area_start.Enabled = false;
                textBox_Cols_Area_end.Enabled = false;
                comboBox_Cols_Name.Enabled = false;
            }

            else
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_SelectedCol.Enabled = true;
                checkBox_Cols_Advance.Checked = false;
                checkBox_Cols_Advance.Enabled = true;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = false;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = false;
                textBox_Cols_Area_start.Enabled = false;
                textBox_Cols_Area_end.Enabled = false;
                comboBox_Cols_Name.Enabled = false;
            }

        }

        private void checkBox_Cols_SelectedCol_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cols_SelectedCol.Checked)
            {
                checkBox_Cols_All.Checked = false;
                checkBox_Cols_All.Enabled = false;
                checkBox_Cols_Advance.Checked = false;
                checkBox_Cols_Advance.Enabled = false;
            }

            else
            {
                checkBox_Cols_All.Checked = false;
                checkBox_Cols_All.Enabled = true;
                checkBox_Cols_Advance.Checked = false;
                checkBox_Cols_Advance.Enabled = true;
            }
        }

        private void checkBox_Cols_Advance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cols_Advance.Checked)
            {
                checkBox_Cols_All.Checked = false;
                checkBox_Cols_All.Enabled = false;
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_SelectedCol.Enabled = false;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = true;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = true;
                textBox_Cols_Area_start.Enabled = false;
                textBox_Cols_Area_end.Enabled = false;
                comboBox_Cols_Name.Enabled = false;
            }

            else
            {
                checkBox_Cols_All.Checked = false;
                checkBox_Cols_All.Enabled = true;
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_SelectedCol.Enabled = true;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = false;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = false;
                textBox_Cols_Area_start.Enabled = false;
                textBox_Cols_Area_end.Enabled = false;
                comboBox_Cols_Name.Enabled = false;
            }

        }

        private void checkBox_Cols_Advance_Area_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cols_Advance_Area.Checked)
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = false;
                textBox_Cols_Area_start.Enabled = true;
                textBox_Cols_Area_end.Enabled = true;
                comboBox_Cols_Name.Enabled = false;
            }

            else
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_Advance_ColName.Checked = false;
                checkBox_Cols_Advance_ColName.Enabled = true;
                textBox_Cols_Area_start.Enabled = false;
                textBox_Cols_Area_end.Enabled = false;
                comboBox_Cols_Name.Enabled = false;
            }

        }

        private void checkBox_Cols_Advance_ColName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Cols_Advance_ColName.Checked)
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = false;
                comboBox_Cols_Name.Enabled = true;
            }

            else
            {
                checkBox_Cols_SelectedCol.Checked = false;
                checkBox_Cols_Advance_Area.Checked = false;
                checkBox_Cols_Advance_Area.Enabled = true;
                comboBox_Cols_Name.Enabled = false;
            }

        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToUpper() == "ECUS SPECIFICATION")
            {
                //// all rows
                if (checkBox_Rows_All.Checked && checkBox_Cols_All.Checked)
                {
                    int numOfEcus = DatabaseConnection.countInTable("ECUsSpecification");
                    int lastId = DatabaseConnection.lastId("ECUsSpecification");
                    int firstId = 0;
                    
                    if (numOfEcus != 0)
                    {
                        numOfEcus = lastId;

                        for (int i = 1; i <= numOfEcus; i++)
                        {
                            string binAdd = "";
                            string crc = "";
                            string type = "";

                            ECUsSpecification tempSP = new ECUsSpecification();
                            ECUsSpecification SP = DatabaseConnection.firstOrDefault(ref tempSP, i);
                            firstId = SP.ID;

                            if (firstId == 0)
                            {
                                continue;
                            }

                            if (SP.BinFileName != null && SP.BinFileName.Trim() != "" && (SP.binCryption == null || SP.binCryption == "0"))
                            {
                                binAdd = SP.BinFileName;

                                if (binAdd.ToUpper() == "NULL")
                                {
                                    binAdd = "";
                                }

                                binAdd = encrypt(binAdd, SP.ID);
                                SP.BinFileName = binAdd.Trim();
                                SP.binCryption = "1";
                            }

                            if (SP.CRC_Address != null && SP.CRC_Address.Trim() != "" && (SP.crcCryption == null || SP.crcCryption == "0"))
                            {
                                crc = SP.CRC_Address;

                                if (crc.ToUpper() == "NULL")
                                {
                                    crc = "";
                                }

                                crc = encrypt(crc, SP.ID);
                                SP.CRC_Address = crc.Trim();
                                SP.crcCryption = "1";
                            }

                            if (SP.Type1_AddressRemap != null && SP.Type1_AddressRemap.Trim() != "" && (SP.type1Cryption == null || SP.type1Cryption == "0"))
                            {
                                type = SP.Type1_AddressRemap;

                                if (type.ToUpper() == "NULL")
                                {
                                    type = "";
                                }

                                type = encrypt(type, SP.ID);
                                SP.Type1_AddressRemap = type.Trim();
                                SP.type1Cryption = "1";
                            }

                            ECUsSpecification newValue = new ECUsSpecification();
                            newValue = SP;
                            DatabaseConnection.updateTable(newValue);
                        }
                    }
                }
            }

            else if (comboBox1.Text.ToUpper() == "ADVANCE REMAP")
            {
                if (checkBox_Rows_All.Checked && checkBox_Cols_All.Checked)
                {
                    int numOfECUs = DatabaseConnection.countInTable("AdvanceRemap");
                    int lastId = DatabaseConnection.lastId("AdvanceRemap");
                    int firstId = 0;
                    
                    if (numOfECUs != 0)
                    {
                        numOfECUs = lastId;
                        for (int i = 1; i <= numOfECUs; i++)
                        {
                            AdvanceRemap tempAR = new AdvanceRemap();
                            AdvanceRemap AR = DatabaseConnection.firstOrDefault(ref tempAR, i);
                            firstId = AR.ID;
                                                        
                            string addressEnd = "";
                            string addressStart = "";
                            string colsCount = "";
                            string rowsCount = "";
                            string dataSize = "";
                            string tableName = "";
                            string xName = "";
                            string yName = "";

                            if (numOfECUs != 0)
                            {
                                AdvanceRemap tempP = new AdvanceRemap();
                                AdvanceRemap p = DatabaseConnection.firstOrDefault(ref tempP, i);
                                                                
                                if (p.Address_End != null && p.Address_End.Trim() != "" && (p.Address_End_Cryption == null || p.Address_End_Cryption == "0"))
                                {
                                    addressEnd = p.Address_End;

                                    if (addressEnd.ToUpper() == "NULL")
                                    {
                                        addressEnd = "";
                                    }
                                    addressEnd = encrypt(addressEnd, p.ID);
                                    p.Address_End = "0";
                                    p.Address_End_Cryption = addressEnd.Trim();
                                }

                                if (p.Address_Start != null && p.Address_Start.Trim() != "" && (p.Address_Start_Cryption == null || p.Address_Start_Cryption == "0"))
                                {
                                    addressStart = p.Address_Start;

                                    if (addressStart.ToUpper() == "NULL")
                                    {
                                        addressStart = "";
                                    }
                                    addressStart = encrypt(addressStart, p.ID);
                                    p.Address_Start = "0";
                                    p.Address_Start_Cryption = addressStart.Trim();
                                }

                                if (p.ColsCount.ToString() != null && p.ColsCount.ToString().Trim() != "" && (p.ColsCount_Cryption == null || p.ColsCount_Cryption == "0"))
                                {
                                    colsCount = p.ColsCount.ToString();

                                    if (colsCount.ToUpper() == "NULL")
                                    {
                                        colsCount = "";
                                    }
                                    colsCount = encrypt(colsCount, p.ID);
                                    p.ColsCount = "0";
                                    p.ColsCount_Cryption = colsCount.Trim();
                                }

                                if (p.RowsCount.ToString() != null && p.RowsCount.ToString().Trim() != "" && (p.RowsCount_Cryption == null || p.RowsCount_Cryption == "0"))
                                {
                                    rowsCount = p.RowsCount.ToString();

                                    if (rowsCount.ToUpper() == "NULL")
                                    {
                                        rowsCount = "";
                                    }
                                    rowsCount = encrypt(rowsCount, p.ID);
                                    p.RowsCount = "0";
                                    p.RowsCount_Cryption = rowsCount.Trim();
                                }

                                if (p.DataSize.ToString() != null && p.DataSize.ToString().Trim() != "" && (p.DataSize_Cryption == null || p.DataSize_Cryption == "0"))
                                {
                                    dataSize = p.DataSize.ToString();

                                    if (dataSize.ToUpper() == "NULL")
                                    {
                                        dataSize = "";
                                    }
                                    dataSize = encrypt(dataSize, p.ID);
                                    p.DataSize = "0";
                                    p.DataSize_Cryption = dataSize.Trim();
                                }

                                if (p.TableName != null && p.TableName.Trim() != "" && (p.TableName_Cryption == null || p.TableName_Cryption == "0"))
                                {
                                    tableName = p.TableName;

                                    if (tableName.ToUpper() == "NULL")
                                    {
                                        tableName = "";
                                    }

                                    tableName = encrypt(tableName, p.ID);
                                    p.TableName = "0";
                                    p.TableName_Cryption = tableName.Trim();
                                }

                                if (p.X_Name != null && p.X_Name.Trim() != "" && (p.X_Name_Cryption == null || p.X_Name_Cryption == "0"))
                                {
                                    xName = p.X_Name;

                                    if (xName.ToUpper() == "NULL")
                                    {
                                        xName = "";
                                    }

                                    xName = encrypt(xName, p.ID);
                                    p.X_Name = "0";
                                    p.X_Name_Cryption = xName.Trim();
                                }

                                if (p.Y_Name != null && p.Y_Name.Trim() != "" && (p.Y_Name_Cryption == null || p.Y_Name_Cryption == "0"))
                                {
                                    yName = p.Y_Name;

                                    if (yName.ToUpper() == "NULL")
                                    {
                                        yName = "";
                                    }

                                    yName = encrypt(yName, p.ID);
                                    p.Y_Name = "0";
                                    p.Y_Name_Cryption = yName.Trim();
                                }
                                AdvanceRemap newValue = p;                                
                                DatabaseConnection.updateTable(newValue);                                
                            }
                        }
                    }
                }            
            }
             comboBox1_TextUpdate(sender, e);
        }

        private void button_Decrypt_Click(object sender, EventArgs e)
        {
            //// all rows
            if (comboBox1.Text.ToUpper() == "ECUS SPECIFICATION")
            {
                if (checkBox_Rows_All.Checked && checkBox_Cols_All.Checked)
                {
                    int numOfECUs = DatabaseConnection.countInTable("ECUsSpecification");
                    int lastId = DatabaseConnection.lastId("ECUsSpecification");
                    int firstId = 0;
                    
                    if (numOfECUs != 0)
                    {
                        numOfECUs = lastId;
                        for (int i = 1; i <= numOfECUs; i++)
                        {                            
                            string binAdd = "";
                            string crc = "";
                            string type = "";

                            ECUsSpecification tempSP = new ECUsSpecification();
                            ECUsSpecification SP = DatabaseConnection.firstOrDefault(ref tempSP, i);
                            firstId = SP.ID;

                            numOfECUs = DatabaseConnection.countInTable("ECUsSpecification");
                            lastId = DatabaseConnection.lastId("ECUsSpecification");
                            if (numOfECUs != 0)
                            {
                                ECUsSpecification tempP = new ECUsSpecification();
                                ECUsSpecification p = DatabaseConnection.firstOrDefault(ref tempP, i);

                                if (SP.BinFileName != null && SP.BinFileName.Trim() != "" && SP.binCryption != null && SP.binCryption == "1")
                                {
                                    binAdd = SP.BinFileName;
                                    binAdd = decrypt(binAdd, p.ID);
                                    p.BinFileName = binAdd.Trim();
                                    p.binCryption = "0";
                                }

                                if (SP.CRC_Address != null && SP.CRC_Address.Trim() != "" && SP.crcCryption != null && SP.crcCryption == "1")
                                {
                                    crc = SP.CRC_Address;
                                    crc = decrypt(crc, p.ID);
                                    p.CRC_Address = crc.Trim();
                                    p.crcCryption = "0";
                                }

                                if (SP.Type1_AddressRemap != null && SP.Type1_AddressRemap.Trim() != "" && SP.type1Cryption != null && SP.type1Cryption == "1")
                                {
                                    type = SP.Type1_AddressRemap;
                                    type = decrypt(type, p.ID);
                                    p.Type1_AddressRemap = type.Trim();
                                    p.type1Cryption = "0";
                                }

                                ECUsSpecification newValue = p;                                
                                DatabaseConnection.updateTable(newValue);
                            }
                        }
                    }
                    MessageBox.Show("database decrypted!");
                }
                comboBox1_TextUpdate(sender, e);

            }

            if (comboBox1.Text.ToUpper() == "ADVANCE REMAP")
            {
                if (checkBox_Rows_All.Checked && checkBox_Cols_All.Checked)
                {
                    int numOfECUs = DatabaseConnection.countInTable("AdvanceRemap");
                    int lastId = DatabaseConnection.lastId("AdvanceRemap");
                    int firstId = 0;
                                        
                    if (numOfECUs != 0)
                    {
                        numOfECUs = lastId;

                        for (int i = 1; i <= numOfECUs; i++)
                        {
                            AdvanceRemap tempAR = new AdvanceRemap();
                            AdvanceRemap AR = DatabaseConnection.firstOrDefault(ref tempAR, i);
                            firstId = AR.ID;
                            
                            string addressEnd = "";
                            string addressStart = "";
                            string colsCount = "";
                            string rowsCount = "";
                            string dataSize = "";
                            string tableName = "";
                            string xName = "";
                            string yName = "";

                            if (numOfECUs != 0)
                            {
                                AdvanceRemap tempP = new AdvanceRemap();
                                AdvanceRemap p = DatabaseConnection.firstOrDefault(ref tempP, i);

                                if (AR.Address_End != null && AR.Address_End.Trim() == "0" && AR.Address_End_Cryption != null && AR.Address_End_Cryption != "0")
                                {
                                    addressEnd = AR.Address_End_Cryption;
                                    addressEnd = decrypt(addressEnd, p.ID);
                                    p.Address_End = addressEnd.Trim();
                                    p.Address_End_Cryption = "0";
                                }

                                if (AR.Address_Start != null && AR.Address_Start.Trim() == "0" && AR.Address_Start_Cryption != null && AR.Address_Start_Cryption != "0")
                                {
                                    addressStart = AR.Address_Start_Cryption;
                                    addressStart = decrypt(addressStart, p.ID);
                                    p.Address_Start = addressStart.Trim();
                                    p.Address_Start_Cryption = "0";
                                }

                                if (AR.ColsCount.ToString() != null && AR.ColsCount.ToString().Trim() == "0" && AR.ColsCount_Cryption != null && AR.ColsCount_Cryption != "0")
                                {
                                    colsCount = AR.ColsCount_Cryption;
                                    colsCount = decrypt(colsCount, p.ID);
                                    p.ColsCount = colsCount;
                                    p.ColsCount_Cryption = "0";
                                }

                                if (AR.RowsCount.ToString() != null && AR.RowsCount.ToString().Trim() == "0" && AR.RowsCount_Cryption != null && AR.RowsCount_Cryption != "0")
                                {
                                    rowsCount = AR.RowsCount_Cryption;
                                    rowsCount = decrypt(rowsCount, p.ID);
                                    p.RowsCount = rowsCount;
                                    p.RowsCount_Cryption = "0";
                                }

                                if (AR.DataSize.ToString() != null && AR.DataSize.ToString().Trim() == "0" && AR.DataSize_Cryption != null && AR.DataSize_Cryption != "0")
                                {
                                    dataSize = AR.DataSize_Cryption;
                                    dataSize = decrypt(dataSize, p.ID);
                                    p.DataSize = dataSize;
                                    p.DataSize_Cryption = "0";
                                }

                                if (AR.TableName != null && AR.TableName.Trim() == "0" && AR.TableName_Cryption != null && AR.TableName_Cryption != "0")
                                {
                                    tableName = AR.TableName_Cryption;
                                    tableName = decrypt(tableName, p.ID);
                                    p.TableName = tableName.Trim();
                                    p.TableName_Cryption = "0";
                                }

                                if (AR.X_Name != null && AR.X_Name.Trim() == "0" && AR.X_Name_Cryption != null && AR.X_Name_Cryption != "0")
                                {
                                    xName = AR.X_Name_Cryption;
                                    p.X_Name = xName.Trim();
                                    p.X_Name_Cryption = "0";
                                }

                                if (AR.Y_Name != null && AR.Y_Name.Trim() == "0" && AR.Y_Name_Cryption != null && AR.Y_Name_Cryption != "0")
                                {
                                    yName = AR.Y_Name_Cryption;
                                    yName = decrypt(yName, p.ID);
                                    p.Y_Name = yName.Trim();
                                    p.Y_Name_Cryption = "0";
                                }

                                AdvanceRemap New_Value = AR;                                
                                DatabaseConnection.updateTable(AR);
                            }
                        }
                    }
                    MessageBox.Show("database decrypted!");
                }
                comboBox1_TextUpdate(sender, e);
            }
        }

        public string encrypt(string clearText, int id)
        {
            string EncryptionKey = "publicKey" + id.ToString();
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string decrypt(string cipherText, int id)
        {
            string m = cipherText;
            string EncryptionKey = "publicKey" + id.ToString();
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                return m;
            }

            return cipherText;
        }

    }
}