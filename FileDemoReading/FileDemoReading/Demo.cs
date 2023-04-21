using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDemoReading
{
     class Demo
    {
      

            SqlConnection con;

            string sqlconn;
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            public void connection()
            {
                sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
                con = new SqlConnection(sqlconn);
            }
            public void Button1_Click()
            {
                //Creating object of datatable  
                DataTable tblcsv = new DataTable();
                //creating columns  
                tblcsv.Columns.Add("city");
                tblcsv.Columns.Add("City_ascii");
                tblcsv.Columns.Add("lat");
                tblcsv.Columns.Add("lng");
                tblcsv.Columns.Add("country");
                tblcsv.Columns.Add("iso2");
                tblcsv.Columns.Add("iso3");
                tblcsv.Columns.Add("admin_name");
                tblcsv.Columns.Add("capital");
                tblcsv.Columns.Add("population");
                tblcsv.Columns.Add("id");
                //getting full file path of Uploaded file  
                string CSVFilePath = Path.GetFullPath(@"worldcities.csv");
                //Reading All text  
                string ReadCSV = File.ReadAllText(CSVFilePath);
                //spliting row after new line  
                foreach (string csvRow in ReadCSV.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        //Adding each row into datatable  
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                            count++;
                        }
                    }
                }
                //Calling insert Functions  
                InsertCSVRecords(tblcsv);
            }
            //Function to Insert Records  
            public void InsertCSVRecords(DataTable csvdt)
            {

                connection();
                //creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                //assigning Destination table name    
                objbulk.DestinationTableName = "Employee";
                //Mapping Table column    

                objbulk.ColumnMappings.Add("City", "City");
                objbulk.ColumnMappings.Add("City_ascii", "City_ascii");
                objbulk.ColumnMappings.Add("lat", "lat");
                objbulk.ColumnMappings.Add("lng", "lng");
                objbulk.ColumnMappings.Add("country", "country");
                objbulk.ColumnMappings.Add("iso2", "iso2");
                objbulk.ColumnMappings.Add("iso3", "iso3");
                objbulk.ColumnMappings.Add("admin_name", "admin_name");
                objbulk.ColumnMappings.Add("capital", "capital");
                objbulk.ColumnMappings.Add("population", "population");
                objbulk.ColumnMappings.Add("id", "id");

                //inserting Datatable Records to DataBase    
                con.Open();
                objbulk.WriteToServer(csvdt);
                con.Close();
            }
        }
    }

