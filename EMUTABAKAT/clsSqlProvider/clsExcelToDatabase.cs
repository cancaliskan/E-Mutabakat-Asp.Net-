using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
 

namespace DorukProvider
{
    public class clsExcelToDatabase
    {

        protected string _result = null;
        protected string _strConnection = null;
        protected string _strSqlTableName = null;
        protected DataTable _excel_headers; 
        //protected List<string> _listTableColumnNames = new List<string>();
        protected int _userID;
        protected int _TYPE_ID;

        private DateTime _aggrementDate;
            
        public DateTime agrementDate
        {
            get { return _aggrementDate; }
    
        }

        private int _insertResultSuccess  ;

        public int insertResultSuccess
        {
            get { return _insertResultSuccess; }
           
        }


        private int _insertResultFail;

        public int insertResultFail
        {
            get { return _insertResultFail; }
 
        }
        
        

        protected int i;

        public string result { get { return _result; } }
        public string strConnection { get { return _strConnection; } }
        public string sqlTableName { get { return _strSqlTableName; } }
        public string sheetName { get; set; }

        public DataTable excel_headers { get { return _excel_headers; } }
        //public List<string> listTableColumnNames { get { return _listTableColumnNames; } }
        public int userID { get { return _userID; } }
        public int TYPE_ID { get { return _TYPE_ID; } }

        public clsExcelToDatabase(HttpPostedFile file, string strConnection, string strSqlTableName, int userId, int TYPE_ID, DateTime aggDate, DataTable dtDbExcel_headers , string SheetName)
        {



                _strConnection = strConnection;
                _strSqlTableName = strSqlTableName;
                _excel_headers = dtDbExcel_headers;
                //_listTableColumnNames = listTableColumnNames;
                _userID = userId;
                _TYPE_ID = TYPE_ID;
                _aggrementDate = aggDate;
                this.sheetName = SheetName;



                if (ImportExcelXLS(file, true).Tables[0].Rows.Count > 0)
                {
                    if (ExportExcelToDB(ImportExcelXLS(file, true).Tables[0]) == 0)
                    {
                        _result = "Excel aktarımı başarıyla tamamlandı!";
                    }
                    else
                    {
                        _result = "Excel Aktarımı tamamlanamadı!" +  this.i.ToString()  + "_inci satırda hata var!";
                    }
                }
                else
                {
                    _result = "Excelde aktarılacak bilgi bulunmamaktadır!";
                }
            }

        
        public DataSet ImportExcelXLS(HttpPostedFile file, bool hasHeaders)
        {
            string fileName = Path.GetTempFileName();
            file.SaveAs(fileName);
            return ImportExcelXLS(fileName, hasHeaders);
        }

        public DataSet ImportExcelXLS(string FileName, bool hasHeaders)
        {
            //  string HDR = hasHeaders ? "Yes" : "No";

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=Yes \";";
            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow row in dt.Rows)
                {

                    if (!row["TABLE_NAME"].ToString().Contains("FilterDatabase") && (row["TABLE_NAME"].ToString().Trim() == this.sheetName + "$"))
                    {
                        string sheet = row["TABLE_NAME"].ToString();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                        cmd.CommandType = CommandType.Text;

                        DataTable outputTable = new DataTable(sheet);


                        
                        new OleDbDataAdapter(cmd).Fill(outputTable);
                        output.Tables.Add(outputTable);


                        if(output.Tables[0].Columns.Count + 3  != this.excel_headers.Rows.Count)
                        {
                        
                            throw new Exception ("liste kolon sayısı ile excel örtüşmüyor");
                        
                        }

                    }

                }
            }

            
            

            return output;
        }


        public int ExportExcelToDB(DataTable dt)
        {
            int result = 0;
            clsSqlProvider sp = new clsSqlProvider(this.strConnection);
            try
            {
                this.i = 0;

                //string query = "DELETE FROM " + this.sqlTableName + " WHERE USERID = @USERID AND AGGREMENT_DATE = @AGGREMENT_DATE";
                //sp.addParameter("@USERID", this.userID);
                //sp.addParameter("@AGGREMENT_DATE", this.agrementDate);
                //sp.nonQueryMethod(query, false);


                System.Data.DataTable dt1 = new System.Data.DataTable();

            


                

                StringBuilder sb_Columns = new StringBuilder("INSERT INTO ");
                sb_Columns.AppendLine(this._strSqlTableName);
                sb_Columns.AppendLine("(");

                foreach (DataRow rw in this.excel_headers.Rows)
                {
                    sb_Columns.AppendLine(rw["DB"].ToString());
                    sb_Columns.Append(",");
                    
                }
                sb_Columns = sb_Columns.Remove(sb_Columns.Length - 1, 1);
                sb_Columns.AppendLine(") VALUES (");
                foreach (DataRow rw in excel_headers.Rows)
                {
                        sb_Columns.Append("@");
                        sb_Columns.AppendLine(rw["DB"].ToString());
                        sb_Columns.Append(",");
                }


                sb_Columns = sb_Columns.Remove(sb_Columns.Length - 1, 1);

                sb_Columns.AppendLine(")");


                string col_Name = "";
                string excelColName = "";

                foreach (DataRow dr in dt.Rows)
                {
                    
                    sp.ClearParameter();
                    foreach (DataRow rw in excel_headers.Rows)
                    {
                        col_Name = rw["DB"].ToString();
                        excelColName = rw["EXCEL"].ToString();
                        if (col_Name == "USERID")
                        {
                            sp.addParameter("@" + col_Name, this.userID); 
                        }
                        else if (col_Name == "TYPE_ID")
                        {
                            sp.addParameter("@" + col_Name, this.TYPE_ID);
                        }
                        else if (col_Name == "AGGREMENT_DATE")
                        {
                            sp.addParameter("@" + col_Name, this.agrementDate);
                        }
                        else
                        {
                            sp.addParameter("@" + col_Name, dr[excelColName].ToString());
                        }
                    }


                    int insertResult = sp.nonQueryMethod(sb_Columns.ToString(), false);

                    if (insertResult==0)
                    {
                        _insertResultSuccess++;
                    }
                    else
                    {
                        _insertResultFail++;
                    }


                }


            }
            catch
            {
                //string query = "TRUNCATE TABLE " + this.sqlTableName;
                //System.Data.DataTable dt1 = new System.Data.DataTable();
                //sp.ClearParameter();
                //sp.nonQueryMethod(query, false);
                //return this.i;
            }

            return result; 
        }


       

    }
}
