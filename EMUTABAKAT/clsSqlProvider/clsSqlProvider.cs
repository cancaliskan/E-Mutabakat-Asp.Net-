using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;


namespace DorukProvider
{
    public class clsSqlProvider
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        protected string sqlConString;
        SqlTransaction myTransaction ; 
        private bool p;

        public clsSqlProvider(string sqlConString)
        {
            this.sqlConString = sqlConString;
            baglan();
        }

        protected void baglan()
        {
            try
            {
                conn = new SqlConnection(this.sqlConString); 
                cmd = new SqlCommand();
                cmd.CommandTimeout = 90000;
                cmd.Connection = conn;
            }
            catch { }
            finally { }
        }

        protected void baglanti_kontrol()
        {
            conn.Open();
            conn.Close();
        }


        public void ClearParameter()
        { cmd.Parameters.Clear(); }

        public void addParameter(string parameterName, object value)
        { cmd.Parameters.AddWithValue(parameterName, value); }

        public DataTable dataTableReader(string query, bool IsProcedure)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = query;

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                if (IsProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                else
                    cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                string hat = ex.ToString();
                return null;
            }
            finally
            { if (conn.State == ConnectionState.Open) conn.Close(); }
            return dt;
        }
        /// <summary>
        /// Komut dosyası çalıştırmak için kullanılır
        /// </summary>
        /// <param name="sorgu"></param>
        /// <param name="IsProcedure"></param>
        /// <returns> hata oluşursa 0, başarılı çalışırsa 1 döndürür </returns>
        public int  nonQueryMethod(string sorgu, bool IsProcedure)
        {
            string kayit = "0";
              
            try
            {

                
                if (IsProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                else
                    cmd.CommandType = CommandType.Text;
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.Connection = conn;
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
                cmd.CommandText = sorgu;
                kayit = cmd.ExecuteNonQuery().ToString();
               
                myTransaction.Commit();
                
            }
            catch (Exception ex)
            {
                string hata = ex.ToString();
                myTransaction.Rollback();
                kayit = "0";
            }
            finally
            {

                if (conn.State == ConnectionState.Open) conn.Close();
            }

            return Convert.ToInt32(kayit);
        }

        public string formatiBoz(string value)
        {
            /* ============== Virgül ve noktalaratılıyor =============  */
            string[] deger = value.Split(',', '.');
            string deger1 = "";
            foreach (string str in deger)
            {
                deger1 += str;
            }

            /* ========= Kuruşlar kısmı çıkartılıyor ================*/
            string lira = deger1.Substring(0, deger1.Length - 2);
            string kurus = deger1.Substring(lira.Length, 2);
            if (Convert.ToInt32(kurus) > 0) lira = string.Format(lira, "0:#.###") + "," + kurus;
            else lira = string.Format(lira, "#.###") + "," + "00";
            return lira;
        } 

        /// <summary>
        /// tek değer döndürür
        /// </summary>
        /// <param name="sorgu"></param>
        /// <param name="IsProcedure"></param>
        /// <returns></returns>
        public object scalarMethod(string sorgu, bool IsProcedure)
        {
            cmd.CommandText = sorgu;
            if (IsProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            else
                cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed) conn.Open();
            object kayit = cmd.ExecuteScalar();
            if (conn.State == ConnectionState.Open) conn.Close();
            return kayit;
        }
    }
}
