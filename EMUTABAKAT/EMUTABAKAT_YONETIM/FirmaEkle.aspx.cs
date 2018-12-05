using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMutabakats_yonetim
{
    public partial class FirmaEkle : System.Web.UI.Page
    {
        DorukProvider.clsSqlProvider sqlProvider = new DorukProvider.clsSqlProvider(System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            int ADMINID;
            if (Session["UserName"] != null)
            {
                string strAdminIDQuery = "SELECT ADMINID FROM TBL_USERS WHERE USERNAME=@USERNAME ";
                sqlProvider.addParameter("@USERNAME", Session["UserName"].ToString());
                DataTable dt = new DataTable();
                dt = sqlProvider.dataTableReader(strAdminIDQuery, false);
                if (dt.Rows.Count > 0)
                {
                    ADMINID = Convert.ToInt32(dt.Rows[0][0]);
                    if (ADMINID != 2)
                    {
                        Response.Redirect("yetkinizYok.aspx", false);
                    }
                }
            }
        }

        protected void temizle_btn_Click(object sender, EventArgs e)
        {
            alanlariTemizle();
        }

        protected void firmaEkle_btn_Click(object sender, EventArgs e)
        {
            if (firmaVarMi())
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Firma veritabanında mevcut !";
            }
            else
                firmaEkleme();
        }


        protected void alanlariTemizle()
        {
            FIRM_NAME.Text = string.Empty;
            FIRM_CODE.Text = string.Empty;
            FIRM_IMAGE.Dispose();
            FIRM_IMAGE2.Dispose();
            CARI_REP_PAGE.Text = string.Empty;
            BA_BS_REP_PAGE.Text = string.Empty;
            SMTP_SERVER.Text = string.Empty;
            SENDER_EMAIL.Text = string.Empty;
            SENDER_EMAIL_TEXT.Text = string.Empty;
            EMAIL_USER.Text = string.Empty;
            EMAIL_PASSWORD.Text = string.Empty;
            EMAIL_PORT.Text = string.Empty;
            WEB_LINK.Text = string.Empty;
            SSL.Text = string.Empty;
            FIRMVD.Text = string.Empty;
            ANNOUNCEMENT_CODE.Text = string.Empty;
            FIRM_IMAGE_MUHUR.Dispose();
            FAX_NO.Text = string.Empty;
            ACTCODE.Text = string.Empty;
            SSL.Checked = false;
            uyari_Lbl.Text = "";
        }

        protected void firmaEkleme()
        {
            if (Page.IsValid)
                //FIRM_IMAGE.PostedFile.ContentLength != 0 && FIRM_IMAGE2.PostedFile.ContentLength != 0 && FIRM_IMAGE_MUHUR.PostedFile.ContentLength != 0 &&
                //string.IsNullOrWhiteSpace(FIRM_NAME.Text) && FIRM_CODE.Text != "" && CARI_REP_PAGE.Text != "" && BA_BS_REP_PAGE.Text != "" && SMTP_SERVER.Text != "" && SENDER_EMAIL.Text != "" &&
                //SENDER_EMAIL_TEXT.Text != "" && EMAIL_USER.Text != "" && EMAIL_PASSWORD.Text != "" && EMAIL_PORT.Text != "" &&
                //WEB_LINK.Text != "" && FIRMVD.Text != "" && ANNOUNCEMENT_CODE.Text != "" && FAX_NO.Text != "" && ACTCODE.Text != "" && MAIL_WAIT_TIME.Text != ""
            {
                int length;
                byte [] pic;
                string strInsertQuery = "INSERT INTO TBL_FIRMS (FIRM_NAME, FIRM_CODE, FIRM_IMAGE, FIRM_IMAGE2, CARI_REP_PAGE, BA_BS_REP_PAGE, SMTP_SERVER, SENDER_EMAIL, SENDER_EMAIL_TEXT, EMAIL_USER, EMAIL_PASSWORD, EMAIL_PORT, WEB_LINK, SSL, FIRMVD, ANNOUNCEMENT_CODE, FIRM_IMAGE_MUHUR, FAX_NO, ACTCODE,ACTIVE,MAIL_WAIT_TIME) VALUES (@FIRM_NAME, @FIRM_CODE, @FIRM_IMAGE, @FIRM_IMAGE2, @CARI_REP_PAGE, @BA_BS_REP_PAGE, @SMTP_SERVER, @SENDER_EMAIL, @SENDER_EMAIL_TEXT, @EMAIL_USER, @EMAIL_PASSWORD, @EMAIL_PORT, @WEB_LINK, @SSL, @FIRMVD, @ANNOUNCEMENT_CODE, @FIRM_IMAGE_MUHUR, @FAX_NO, @ACTCODE, @ACTIVE,@MAIL_WAIT_TIME)";

                sqlProvider.ClearParameter();
                DataTable dt = new DataTable();

                if (dt.Rows.Count == 0)
                {


                    sqlProvider.addParameter("@FIRM_NAME", FIRM_NAME.Text);
                    sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.Text);

                    length = FIRM_IMAGE.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE", pic);


                    length = FIRM_IMAGE2.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE2.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE2", pic);

                    length = FIRM_IMAGE_MUHUR.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE_MUHUR.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE_MUHUR", pic);



                    sqlProvider.addParameter("@CARI_REP_PAGE", CARI_REP_PAGE.Text);
                    sqlProvider.addParameter("@BA_BS_REP_PAGE", BA_BS_REP_PAGE.Text);
                    sqlProvider.addParameter("@SMTP_SERVER", SMTP_SERVER.Text);
                    sqlProvider.addParameter("@SENDER_EMAIL", SENDER_EMAIL.Text);
                    sqlProvider.addParameter("@SENDER_EMAIL_TEXT", SENDER_EMAIL_TEXT.Text);
                    sqlProvider.addParameter("@EMAIL_USER", EMAIL_USER.Text);
                    sqlProvider.addParameter("@EMAIL_PASSWORD", EMAIL_PASSWORD.Text);
                    sqlProvider.addParameter("@EMAIL_PORT", EMAIL_PORT.Text);
                    sqlProvider.addParameter("@WEB_LINK", WEB_LINK.Text);

                    sqlProvider.addParameter("@SSL", SSL.Checked);

                    sqlProvider.addParameter("@FIRMVD", FIRMVD.Text);
                    sqlProvider.addParameter("@ANNOUNCEMENT_CODE", ANNOUNCEMENT_CODE.Text);

                    sqlProvider.addParameter("@FAX_NO", FAX_NO.Text);
                    sqlProvider.addParameter("@MAIL_WAIT_TIME", MAIL_WAIT_TIME.Text);
                    sqlProvider.addParameter("@ACTCODE", ACTCODE.Text);
                    sqlProvider.addParameter("@ACTIVE", true);
                    sqlProvider.nonQueryMethod(strInsertQuery, false);
                    alanlariTemizle();
                    uyari_Lbl.ForeColor = Color.Green;
                    uyari_Lbl.Text = "Firma Başarıyla Eklendi !";
                }
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurun.!!";
            }
        }


        protected bool firmaVarMi()
        {
            string strCheckQuery = "SELECT * FROM TBL_FIRMS WHERE FIRM_CODE = @FIRM_CODE";
            sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strCheckQuery, false);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }

}