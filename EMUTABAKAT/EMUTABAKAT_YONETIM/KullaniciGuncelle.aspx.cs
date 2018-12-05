using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMutabakats_yonetim
{
    public partial class KullaniciGuncelle : System.Web.UI.Page
    {
        DorukProvider.clsSqlProvider sqlProvider = new DorukProvider.clsSqlProvider(System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
        }

        protected void load()
        {
            int ADMINID;
            if (Session["UserName"] != null)
            {
                string strAdminIDQuery = "SELECT ADMINID FROM TBL_USERS WHERE USERNAME=@USERNAME ";
                sqlProvider.ClearParameter();
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
            if (!SADECE_ACTIVE_FIRM.Checked)
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
            SADECE_ACTIVE_FIRM.Visible = false;
            string strFirmCodeQuery = "select TBL_FIRMS.FIRM_CODE from TBL_USERS,TBL_FIRMS where TBL_USERS.USERNAME=@USERNAME and TBL_FIRMS.ID=TBL_USERS.FIRMID";
            sqlProvider.ClearParameter();
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
        protected void kullaniciGuncelle_btn_Click(object sender, EventArgs e)
        {
            #region eğerki parolada değişiklik yapılmadıysa var olan parolayı alacak
            string password_default=null;
            string strGetData = "SELECT PASSWORD FROM TBL_USERS where USERNAME=@USERNAME";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@USERNAME", USERNAME.SelectedItem.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strGetData, false);
            if (dt.Rows.Count > 0)
            {
                password_default = dt.Rows[0]["PASSWORD"].ToString();
            }
            #endregion

            sqlProvider.ClearParameter();
            if (Page.IsValid)
            {
                string strUpdateQuery = "UPDATE TBL_USERS SET NAME=@NAME, SURNAME=@SURNAME, CONTACTEMAIL=@CONTACTEMAIL, PASSWORD=@PASSWORD, ADMINID=@ADMINID, ACTIVE=@ACTIVE WHERE USERNAME=@USERNAME";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@USERNAME", USERNAME.SelectedItem.Text);
                sqlProvider.addParameter("@NAME", NAME.Text);
                sqlProvider.addParameter("@SURNAME", SURNAME.Text);
                sqlProvider.addParameter("@CONTACTEMAIL", CONTACTEMAIL.Text);
                if (PASSWORD.Text != "")
                    sqlProvider.addParameter("@PASSWORD", DorukProvider.clsSifrele.Encrypt(PASSWORD.Text, true).ToString());
                else
                    sqlProvider.addParameter("@PASSWORD", password_default.ToString());
                if (ADMINID.SelectedIndex == 1)
                    sqlProvider.addParameter("@ADMINID", Convert.ToInt32("1"));
                else
                    sqlProvider.addParameter("@ADMINID", Convert.ToInt32("0"));
                if (ACTIVE.Checked)
                    sqlProvider.addParameter("@ACTIVE", true);
                else
                    sqlProvider.addParameter("@ACTIVE", false);

                sqlProvider.nonQueryMethod(strUpdateQuery, false);
                alanlariTemizle();
                uyari_Lbl.ForeColor = Color.Green;
                uyari_Lbl.Text = "Kullanıcı Başarıyla Güncellendi !";
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurun !";
            }

        }
        protected void FIRM_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = string.Empty;
            ADMINID.Enabled = false;
            ADMINID.SelectedIndex = 0;
            NAME.Text = string.Empty;
            SURNAME.Text = string.Empty;
            CONTACTEMAIL.Text = string.Empty;
            PASSWORD.Text = string.Empty;
            ACTIVE.Checked = false;
            getUserName();
        }

        protected void USERNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillBlank();
        }

        protected void getUserName()
        {
            USERNAME.Enabled = true;
            SADECE_ACTIVE_USER.Enabled = true;
            string strUserNameQuery;
            if (!SADECE_ACTIVE_USER.Checked)
            {
                strUserNameQuery = "SELECT TBL_USERS.USERNAME FROM TBL_USERS,TBL_FIRMS where TBL_USERS.FIRMID=TBL_FIRMS.ID and TBL_FIRMS.FIRM_CODE=@FIRM_CODE order by TBL_USERS.USERNAME";
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.ToString());
            }
            else
            {
                strUserNameQuery = "SELECT TBL_USERS.USERNAME FROM TBL_USERS,TBL_FIRMS where TBL_USERS.FIRMID=TBL_FIRMS.ID and TBL_FIRMS.FIRM_CODE=@FIRM_CODE and TBL_USERS.ACTIVE='True' order by TBL_USERS.USERNAME";
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.ToString());
            }
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strUserNameQuery, false);
            USERNAME.Items.Clear();
            USERNAME.Items.Add("-- Seçin --");
            foreach (DataRow r in dt.Rows)
            {
                USERNAME.Items.Add(r["USERNAME"].ToString());
            }
        }

        protected void fillBlank()
        {
            ADMINID.Enabled = true;
            string strGetData = "SELECT ADMINID,NAME,SURNAME,CONTACTEMAIL,PASSWORD,ACTIVE from TBL_USERS where USERNAME=@USERNAME";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@USERNAME", USERNAME.SelectedItem.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strGetData, false);
            if (dt.Rows.Count > 0)
            {
                if ((int)dt.Rows[0]["ADMINID"] == 1)
                    ADMINID.SelectedIndex = 1;
                else if ((int)dt.Rows[0]["ADMINID"] == 0)
                    ADMINID.SelectedIndex = 2;

                NAME.Text = dt.Rows[0]["NAME"].ToString();
                SURNAME.Text = dt.Rows[0]["SURNAME"].ToString();
                CONTACTEMAIL.Text = dt.Rows[0]["CONTACTEMAIL"].ToString();
                PASSWORD.Text = dt.Rows[0]["PASSWORD"].ToString();
                if (dt.Rows[0]["ACTIVE"].ToString() == "True")
                    ACTIVE.Checked = true;
                else if (dt.Rows[0]["ACTIVE"].ToString() == "False")
                    ACTIVE.Checked = false;
            }
        }


        protected void alanlariTemizle()
        {
            uyari_Lbl.Text = string.Empty;
            FIRM_CODE.Items.Clear();
            USERNAME.Items.Clear();
            USERNAME.Items.Add("-- Seçin --");
            USERNAME.Enabled = false;
            ADMINID.SelectedIndex = 0;
            NAME.Text = string.Empty;
            SURNAME.Text = string.Empty;
            CONTACTEMAIL.Text = string.Empty;
            PASSWORD.Text = string.Empty;
            ACTIVE.Checked = false;
            SADECE_ACTIVE_USER.Checked = true;
            SADECE_ACTIVE_FIRM.Checked = true;
            USERNAME.Enabled = false;
            ADMINID.Enabled = false;
            load();
        }
        protected void SADECE_ACTIVE_FIRM_CheckedChanged(object sender, EventArgs e)
        {
            if (SADECE_ACTIVE_FIRM.Checked)
            {
                alanlariTemizle();
                SADECE_ACTIVE_FIRM.Checked = true;
                FIRM_CODE.Items.Clear();
                load();
            }
            else
            {
                alanlariTemizle();
                SADECE_ACTIVE_FIRM.Checked = false;
                FIRM_CODE.Items.Clear();
                load();
            }
        }

        protected void temizle_btn_Click(object sender, EventArgs e)
        {
            alanlariTemizle();
        }

        protected void SADECE_ACTIVE_USER_CheckedChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = string.Empty;
            ADMINID.Enabled = false;
            ADMINID.SelectedIndex = 0;
            NAME.Text = string.Empty;
            SURNAME.Text = string.Empty;
            CONTACTEMAIL.Text = string.Empty;
            PASSWORD.Text = string.Empty;
            ACTIVE.Checked = false;
            getUserName();
        }

    }
}