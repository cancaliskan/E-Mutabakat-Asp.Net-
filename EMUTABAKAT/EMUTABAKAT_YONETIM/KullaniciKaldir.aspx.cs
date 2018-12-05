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
    public partial class KullaniciKaldir : System.Web.UI.Page
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

        protected void alanlariTemizle()
        {
            uyari_Lbl.Text = string.Empty;
            FIRM_CODE.Items.Clear();
            USERNAME.Items.Clear();
            USERNAME.Items.Add("-- Seçin --");
            USERNAME.Enabled = false;
            SADECE_ACTIVE_FIRM.Checked = true;
            USERNAME.Enabled = false;
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

        protected void getUserName()
        {
            USERNAME.Enabled = true;
            string strUserNameQuery;

            strUserNameQuery = "SELECT TBL_USERS.USERNAME FROM TBL_USERS,TBL_FIRMS where TBL_USERS.FIRMID=TBL_FIRMS.ID and TBL_FIRMS.FIRM_CODE=@FIRM_CODE and TBL_USERS.ACTIVE='True' order by TBL_USERS.USERNAME";
            sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.ToString());

            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strUserNameQuery, false);
            USERNAME.Items.Clear();
            USERNAME.Items.Add("-- Seçin --");
            foreach (DataRow r in dt.Rows)
            {
                USERNAME.Items.Add(r["USERNAME"].ToString());
            }
        }

        protected void FIRM_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = string.Empty;
            getUserName();
        }

        protected void kullaniciKapat_btn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string strUpdateQuery = "UPDATE TBL_USERS SET ACTIVE=@ACTIVE WHERE USERNAME=@USERNAME";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@USERNAME", USERNAME.SelectedItem.Text);

                sqlProvider.addParameter("@ACTIVE", false);

                sqlProvider.nonQueryMethod(strUpdateQuery, false);
                alanlariTemizle();
                uyari_Lbl.ForeColor = Color.Green;
                uyari_Lbl.Text = "Kullanıcı Başarıyla Kaldırıldı !";
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurun !";
            }
        }
    }
}