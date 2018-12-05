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
    public partial class KullaniciEkle : System.Web.UI.Page
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
                    if (ADMINID == 1)
                        firmaAdminEkle();
                    else if (ADMINID == 2)
                        anaAdminEkle();
                    else
                        Response.Redirect("yetkinizYok.aspx", false);

                }
            }
        }

        protected void anaAdminEkle()
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

        protected void firmaAdminEkle()
        {
            sqlProvider.ClearParameter();
            SADECE_ACTIVE.Visible = false;
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

        protected void alanlariTemizle()
        {
            SADECE_ACTIVE.Checked = true;
            FIRM_CODE.SelectedIndex = 0;
            USERNAME.Text = "";
            NAME.Text = "";
            SURNAME.Text = "";
            CONTACTEMAIL.Text = "";
            PASSWORD.Text = "";
            ADMINID.SelectedIndex = 0;
            uyari_Lbl.Text = "";
        }

        protected void SADECE_ACTIVE_CheckedChanged(object sender, EventArgs e)
        {
            if (SADECE_ACTIVE.Checked)
            {
                alanlariTemizle();
                FIRM_CODE.Items.Clear();
                SADECE_ACTIVE.Checked = true;
                anaAdminEkle();
            }
            else
            {
                alanlariTemizle();
                FIRM_CODE.Items.Clear();
                SADECE_ACTIVE.Checked = false;
                anaAdminEkle();
            }
        }

        protected void temizle_btn_Click(object sender, EventArgs e)
        {            
            alanlariTemizle();
        }

        protected bool kullaniciVarMı()
        {
            #region firmaID çekiyoruz
            int firmID=-1;
            string strSelectQuery="select TBL_FIRMS.ID from TBL_FIRMS where TBL_FIRMS.FIRM_CODE=@FIRM_CODE";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.ToString());
            DataTable dt2 = new DataTable();
            dt2 = sqlProvider.dataTableReader(strSelectQuery, false);
            if (dt2.Rows.Count > 0)
            {
                firmID = Convert.ToInt32(dt2.Rows[0][0]);
            }
            #endregion

            string strCheckQuery = "SELECT USERNAME FROM TBL_USERS WHERE USERNAME = @USERNAME and FIRMID = @FIRMID";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@USERNAME", USERNAME.Text);
            sqlProvider.addParameter("@FIRMID", firmID);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strCheckQuery, false);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        protected void kullaniciEkle()
        {
            int firmID=-1;
            if (Page.IsValid)
            {
                string strSelectQuery="select TBL_FIRMS.ID from TBL_FIRMS where TBL_FIRMS.FIRM_CODE=@FIRM_CODE";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.ToString());
                DataTable dt2 = new DataTable();
                dt2 = sqlProvider.dataTableReader(strSelectQuery, false);
                if (dt2.Rows.Count > 0)
                {
                    firmID = Convert.ToInt32(dt2.Rows[0][0]);
                }

                string strInsertQuery = "INSERT INTO TBL_USERS (USERNAME,NAME,SURNAME,CONTACTEMAIL,PASSWORD,FIRMID,ADMINID,ACTIVE) VALUES (@USERNAME,@NAME,@SURNAME,@CONTACTEMAIL,@PASSWORD,@FIRMID,@ADMINID,@ACTIVE)";
                sqlProvider.ClearParameter();
                DataTable dt = new DataTable();

                if (dt.Rows.Count == 0)
                {
                    sqlProvider.addParameter("@USERNAME", USERNAME.Text);
                    sqlProvider.addParameter("@NAME", NAME.Text);
                    sqlProvider.addParameter("@SURNAME", SURNAME.Text);
                    sqlProvider.addParameter("@CONTACTEMAIL", CONTACTEMAIL.Text);
                    string password = DorukProvider.clsSifrele.Encrypt(PASSWORD.Text, true);
                    sqlProvider.addParameter("@PASSWORD", password.ToString());
                    sqlProvider.addParameter("@FIRMID", firmID);
                    sqlProvider.addParameter("@ACTIVE", true);
                    if (ADMINID.SelectedItem.Equals("Yönetici"))
                        sqlProvider.addParameter("@ADMINID", 1);
                    else
                        sqlProvider.addParameter("@ADMINID", 0);
                    sqlProvider.nonQueryMethod(strInsertQuery, false);
                    alanlariTemizle();
                    uyari_Lbl.ForeColor = Color.Green;
                    uyari_Lbl.Text = "Kullanıcı Başarıyla Eklendi !";
                }
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurunuz !";
            }
        }

        protected void kullaniciEkle_btn_Click(object sender, EventArgs e)
        {
            if (kullaniciVarMı())
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Kullanıcı Adı sistemde mevcut !";
            }
            else
                kullaniciEkle();
        }
    }
}