using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMutabakats_yonetim
{
    public partial class upload_image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = null;
            try
            {
                FileUpload img = (FileUpload)imgUpload;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = imgUpload.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }
                // Insert the employee name and image into db
                string conn = ConfigurationManager.ConnectionStrings["drkEmutabakat"].ConnectionString;
                connection = new SqlConnection(conn);

                connection.Open();
                string sql = "UPDATE [TBL_FIRMS] SET FIRM_IMAGE = @eimg WHERE ID = 1";
                SqlCommand cmd = new SqlCommand(sql, connection);
               
                cmd.Parameters.AddWithValue("@eimg", imgByte);

                cmd.ExecuteNonQuery();
               
              
            }
            catch
            {
              string a = "There was an error";
            }
            finally
            {
                connection.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            try
            {
                FileUpload img = (FileUpload)imgUpload2;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = imgUpload2.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }
                // Insert the employee name and image into db
                string conn = ConfigurationManager.ConnectionStrings["drkEmutabakat"].ConnectionString;
                connection = new SqlConnection(conn);

                connection.Open();
                string sql = "UPDATE [TBL_FIRMS] SET FIRM_IMAGE2 = @eimg WHERE ID = 1";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@eimg", imgByte);

                cmd.ExecuteNonQuery();


            }
            catch
            {
                string a = "There was an error";
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            try
            {
                FileUpload img = (FileUpload)imgUpload3;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = imgUpload3.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }
                // Insert the employee name and image into db
                string conn = ConfigurationManager.ConnectionStrings["drkEmutabakat"].ConnectionString;
                connection = new SqlConnection(conn);

                connection.Open();
                string sql = "UPDATE [TBL_FIRMS] SET FIRM_IMAGE_MUHUR = @eimg WHERE ID = 1";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@eimg", imgByte);

                cmd.ExecuteNonQuery();


            }
            catch
            {
                string a = "There was an error";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}