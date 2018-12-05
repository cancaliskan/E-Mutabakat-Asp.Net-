using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMutabakats_yonetim
{
    public partial class FirmaGuncelle : System.Web.UI.Page
    {
        string EMAIL_PASSWORD_default;
        byte[] imageData=null;
        byte[] imageData2=null;
        byte[] imageData3=null;
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
                    if (ADMINID == 1)
                        firmaAdminGuncelle();
                    else if (ADMINID == 2)
                        anaAdminGuncelle();
                    else
                        Response.Redirect("yetkinizYok.aspx", false);

                }
            }

        }
        protected void anaAdminGuncelle()
        {
            string strAnaAdminQuery;
            if (!SADECE_ACTIVE.Checked)
                strAnaAdminQuery = "SELECT FIRM_CODE FROM TBL_FIRMS order by FIRM_CODE";
            else
                strAnaAdminQuery = "SELECT FIRM_CODE FROM TBL_FIRMS where ACTIVE='True' order by FIRM_CODE";
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strAnaAdminQuery, false);
            if (FIRM_CODE.Items.Count == 0 || FIRM_CODE.Items.Count == 1)
            {
                FIRM_CODE.Items.Clear();
                FIRM_CODE.Items.Add("-- Seçin --");
                foreach (DataRow r in dt.Rows)
                {
                    FIRM_CODE.Items.Add(r["FIRM_CODE"].ToString());
                }
            }


        }
        protected void firmaAdminGuncelle()
        {
            sqlProvider.ClearParameter();
            SADECE_ACTIVE.Visible = false;
            ACTIVE_row.Visible = false;
            ACTCODE_row.Visible = false;
            WEB_LINK.Enabled = false;
            string strFirmCodeQuery = "select TBL_FIRMS.FIRM_CODE from TBL_USERS,TBL_FIRMS where TBL_USERS.USERNAME=@USERNAME and TBL_FIRMS.ID=TBL_USERS.FIRMID";
            sqlProvider.addParameter("@USERNAME", Session["UserName"].ToString());
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strFirmCodeQuery, false);
            if (FIRM_CODE.Items.Count == 0 || FIRM_CODE.Items.Count == 1)
            {
                FIRM_CODE.Items.Clear();
                FIRM_CODE.Items.Add("-- Seçin --");
                foreach (DataRow r in dt.Rows)
                {
                    FIRM_CODE.Items.Add(r["FIRM_CODE"].ToString());
                }
            }

        }

        protected void temizle_btn_Click(object sender, EventArgs e)
        {
            alanlariTemizle();
        }


        protected void FIRM_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = "";
            if (FIRM_CODE.SelectedItem.Text != "-- Seçin --")
            {
                string strGetData = "SELECT FIRM_NAME, FIRM_IMAGE, FIRM_IMAGE2, CARI_REP_PAGE, BA_BS_REP_PAGE, SMTP_SERVER, SENDER_EMAIL, SENDER_EMAIL_TEXT, EMAIL_USER, EMAIL_PASSWORD, EMAIL_PORT, WEB_LINK, SSL, FIRMVD, ANNOUNCEMENT_CODE, FIRM_IMAGE_MUHUR, FAX_NO, ACTCODE, ACTIVE,MAIL_WAIT_TIME FROM TBL_FIRMS where FIRM_CODE=@FIRM_CODE";
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.Text);
                DataTable dt = new DataTable();
                dt = sqlProvider.dataTableReader(strGetData, false);
                if (dt.Rows.Count > 0)
                {
                    imageData = (byte[])dt.Rows[0]["FIRM_IMAGE"];
                    string img=Convert.ToBase64String(imageData,0,imageData.Length);
                    FIRM_IMAGE_img.ImageUrl = "data:image/png;base64," + img;


                    imageData2 = (byte[])dt.Rows[0]["FIRM_IMAGE2"];
                    string img2=Convert.ToBase64String(imageData2,0,imageData2.Length);
                    FIRM_IMAGE2_img.ImageUrl = "data:image/png;base64," + img2;

                    imageData3 = (byte[])dt.Rows[0]["FIRM_IMAGE_MUHUR"];
                    string img3=Convert.ToBase64String(imageData3,0,imageData3.Length);
                    FIRM_IMAGE_MUHUR_img.ImageUrl = "data:image/png;base64," + img3;

                    FIRM_NAME.Text = dt.Rows[0]["FIRM_NAME"].ToString();
                    CARI_REP_PAGE.Text = dt.Rows[0]["CARI_REP_PAGE"].ToString();
                    BA_BS_REP_PAGE.Text = dt.Rows[0]["BA_BS_REP_PAGE"].ToString();
                    SMTP_SERVER.Text = dt.Rows[0]["SMTP_SERVER"].ToString();
                    SENDER_EMAIL.Text = dt.Rows[0]["SENDER_EMAIL"].ToString();
                    SENDER_EMAIL_TEXT.Text = dt.Rows[0]["SENDER_EMAIL_TEXT"].ToString();
                    EMAIL_USER.Text = dt.Rows[0]["EMAIL_USER"].ToString();
                    EMAIL_PASSWORD.Text = dt.Rows[0]["EMAIL_PASSWORD"].ToString();
                    EMAIL_PORT.Text = dt.Rows[0]["EMAIL_PORT"].ToString();
                    WEB_LINK.Text = dt.Rows[0]["WEB_LINK"].ToString();
                    if (dt.Rows[0]["SSL"].ToString() == "True")
                        SSL.Checked = true;
                    else
                        SSL.Checked = false;
                    FIRMVD.Text = dt.Rows[0]["FIRMVD"].ToString();
                    ANNOUNCEMENT_CODE.Text = dt.Rows[0]["ANNOUNCEMENT_CODE"].ToString();
                    FAX_NO.Text = dt.Rows[0]["FAX_NO"].ToString();
                    ACTCODE.Text = dt.Rows[0]["ACTCODE"].ToString();
                    MAIL_WAIT_TIME.Text = dt.Rows[0]["MAIL_WAIT_TIME"].ToString();
                    if (dt.Rows[0]["ACTIVE"].ToString() == "True")
                        ACTIVE.Checked = true;
                    else
                        ACTIVE.Checked = false;
                }
            }
            else
                alanlariTemizle();
        }

        protected void alanlariTemizle()
        {
            SADECE_ACTIVE.Checked = true;
            FIRM_CODE.SelectedIndex = 0;
            FIRM_NAME.Text = string.Empty;
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
            ACTIVE.Checked = false;
            MAIL_WAIT_TIME.Text = string.Empty;
            uyari_Lbl.Text = "";
            FIRM_IMAGE2_img.ImageUrl = "";
            FIRM_IMAGE_img.ImageUrl = "";
            FIRM_IMAGE_MUHUR_img.ImageUrl = "";
        }

        protected void firmaGuncelle_btn_Click(object sender, EventArgs e)
        {
            firmaGuncelle();
        }
        protected void firmaGuncelle()
        {
            int length;
            byte [] pic;
            #region eğer ki resimlerde bir değişiklik yapmadıysa var olan resimlerle güncelleyecek

            string strGetData = "SELECT FIRM_IMAGE, FIRM_IMAGE2, FIRM_IMAGE_MUHUR,EMAIL_PASSWORD FROM TBL_FIRMS where FIRM_CODE=@FIRM_CODE";
            sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strGetData, false);
            if (dt.Rows.Count > 0)
            {
                imageData = (byte[])dt.Rows[0]["FIRM_IMAGE"];
                string img=Convert.ToBase64String(imageData,0,imageData.Length);
                FIRM_IMAGE_img.ImageUrl = "data:image/png;base64," + img;


                imageData2 = (byte[])dt.Rows[0]["FIRM_IMAGE2"];
                string img2=Convert.ToBase64String(imageData2,0,imageData2.Length);
                FIRM_IMAGE2_img.ImageUrl = "data:image/png;base64," + img2;

                imageData3 = (byte[])dt.Rows[0]["FIRM_IMAGE_MUHUR"];
                string img3=Convert.ToBase64String(imageData3,0,imageData3.Length);
                FIRM_IMAGE_MUHUR_img.ImageUrl = "data:image/png;base64," + img3;

                EMAIL_PASSWORD_default = dt.Rows[0]["EMAIL_PASSWORD"].ToString();
            }
            #endregion
            if (Page.IsValid)
                //FIRM_NAME.Text != "" && FIRM_CODE.Text != "" && CARI_REP_PAGE.Text != "" && BA_BS_REP_PAGE.Text != "" && SMTP_SERVER.Text != "" && SENDER_EMAIL.Text != "" &&
                //SENDER_EMAIL_TEXT.Text != "" && EMAIL_USER.Text != "" && EMAIL_PORT.Text != "" &&
                //WEB_LINK.Text != "" && FIRMVD.Text != "" && ANNOUNCEMENT_CODE.Text != "" && FAX_NO.Text != "" && ACTCODE.Text != "" && MAIL_WAIT_TIME.Text != ""
            {
                sqlProvider.ClearParameter();
                string strUpdateQuery = "UPDATE TBL_FIRMS SET FIRM_NAME=@FIRM_NAME, FIRM_IMAGE=@FIRM_IMAGE, FIRM_IMAGE2=@FIRM_IMAGE2, CARI_REP_PAGE=@CARI_REP_PAGE, BA_BS_REP_PAGE=@BA_BS_REP_PAGE, SMTP_SERVER=@SMTP_SERVER, SENDER_EMAIL=@SENDER_EMAIL, SENDER_EMAIL_TEXT=@SENDER_EMAIL_TEXT, EMAIL_USER=@EMAIL_USER, EMAIL_PASSWORD=@EMAIL_PASSWORD, EMAIL_PORT=@EMAIL_PORT, WEB_LINK=@WEB_LINK, SSL=@SSL, FIRMVD=@FIRMVD, ANNOUNCEMENT_CODE=@ANNOUNCEMENT_CODE, FIRM_IMAGE_MUHUR=@FIRM_IMAGE_MUHUR, FAX_NO=@FAX_NO, ACTCODE=@ACTCODE, ACTIVE=@ACTIVE, MAIL_WAIT_TIME=@MAIL_WAIT_TIME WHERE FIRM_CODE=@FIRM_CODE";
                sqlProvider.ClearParameter();


                sqlProvider.addParameter("@FIRM_NAME", FIRM_NAME.Text);
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.Text);

                if (FIRM_IMAGE.PostedFile.ContentLength != 0)
                {
                    length = FIRM_IMAGE.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE", pic);
                }
                else
                    sqlProvider.addParameter("@FIRM_IMAGE", imageData);

                if (FIRM_IMAGE2.PostedFile.ContentLength != 0)
                {
                    length = FIRM_IMAGE2.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE2.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE2", pic);
                }
                else
                    sqlProvider.addParameter("@FIRM_IMAGE2", imageData2);

                if (FIRM_IMAGE_MUHUR.PostedFile.ContentLength != 0)
                {
                    length = FIRM_IMAGE_MUHUR.PostedFile.ContentLength;
                    pic = new byte[length];
                    FIRM_IMAGE_MUHUR.PostedFile.InputStream.Read(pic, 0, length);
                    sqlProvider.addParameter("@FIRM_IMAGE_MUHUR", pic);
                }
                else
                    sqlProvider.addParameter("@FIRM_IMAGE_MUHUR", imageData3);

                sqlProvider.addParameter("@CARI_REP_PAGE", CARI_REP_PAGE.Text);
                sqlProvider.addParameter("@BA_BS_REP_PAGE", BA_BS_REP_PAGE.Text);
                sqlProvider.addParameter("@SMTP_SERVER", SMTP_SERVER.Text);
                sqlProvider.addParameter("@SENDER_EMAIL", SENDER_EMAIL.Text);
                sqlProvider.addParameter("@SENDER_EMAIL_TEXT", SENDER_EMAIL_TEXT.Text);
                sqlProvider.addParameter("@EMAIL_USER", EMAIL_USER.Text);

                if (EMAIL_PASSWORD.Text != "")
                    sqlProvider.addParameter("@EMAIL_PASSWORD", EMAIL_PASSWORD.Text);
                else
                    sqlProvider.addParameter("@EMAIL_PASSWORD", EMAIL_PASSWORD_default.ToString());

                sqlProvider.addParameter("@EMAIL_PORT", Convert.ToInt32(EMAIL_PORT.Text));
                sqlProvider.addParameter("@WEB_LINK", WEB_LINK.Text);

                sqlProvider.addParameter("@SSL", SSL.Checked);

                sqlProvider.addParameter("@FIRMVD", FIRMVD.Text);
                sqlProvider.addParameter("@ANNOUNCEMENT_CODE", ANNOUNCEMENT_CODE.Text);

                sqlProvider.addParameter("@FAX_NO", FAX_NO.Text);
                sqlProvider.addParameter("@ACTCODE", ACTCODE.Text);
                sqlProvider.addParameter("@ACTIVE", ACTIVE.Checked);
                sqlProvider.addParameter("@MAIL_WAIT_TIME", Convert.ToInt32(MAIL_WAIT_TIME.Text));

                sqlProvider.nonQueryMethod(strUpdateQuery, false);
                alanlariTemizle();
                uyari_Lbl.ForeColor = Color.Green;
                uyari_Lbl.Text = "Firma Başarıyla Güncellendi !";
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurun.!!";
            }
        }

        protected void SADECE_ACTIVE_CheckedChanged(object sender, EventArgs e)
        {
            if (SADECE_ACTIVE.Checked)
            {
                alanlariTemizle();
                FIRM_CODE.Items.Clear();
                SADECE_ACTIVE.Checked = true;
                anaAdminGuncelle();
            }
            else
            {
                alanlariTemizle();
                FIRM_CODE.Items.Clear();
                SADECE_ACTIVE.Checked = false;
                anaAdminGuncelle();
            }
        }

    }
}