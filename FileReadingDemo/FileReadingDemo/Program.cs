
using CsvHelper;
using Grpc.Core;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FileReadingDemo
{ 
class Program
{
        static void Main(String[] args)
        {

            var demo=new Program();
            demo.Button1_Click();
            //    string fpath = @"worldcities.csv";
            //using var streamReader = File.OpenText(fpath);
            //using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.CurrentCulture);
            //var users = csvReader.GetRecords<Cities>().ToList();
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine(user);

            //    }


        }
             void Button1_Click()
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
                    if (!string.IsNullOrEmpty(csvRow) )
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

        MySqlConnection con;

        string sqlconn;
        private object strFile;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void connection()
        {
            sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
            con = new MySqlConnection(sqlconn);
        }



        void InsertCSVRecords(DataTable csvdt)
            {

                connection();
            con.Open();
            //creating object of SqlBulkCopy    
            MySqlBulkLoader objbulk = new MySqlBulkLoader(con);
            objbulk.FileName = Server.MapPath(strFile);
            //assigning Destination table name    
            objbulk.TableName= "cities";
            //Mapping Table column    
             
                


                //inserting Datatable Records to DataBase    
               
            objbulk.Load();
            try
            {
                File.Delete(Server.MapPath(strFile));
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            con.Close();
            }
        
    }
}