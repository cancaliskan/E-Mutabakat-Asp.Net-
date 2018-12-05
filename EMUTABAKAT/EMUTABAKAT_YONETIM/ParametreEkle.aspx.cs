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
    public partial class ParametreEkle : System.Web.UI.Page
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
            System.Data.DataTable dt = new DataTable();
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
            PARAMNAME.Text = string.Empty;
            PARAMVAL.Text = string.Empty;
            SADECE_ACTIVE_FIRM.Checked = true;
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

        protected void paramEkle()
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

                string strInsertQuery = "INSERT INTO TBL_PARAM (FIRMID,PARAMNAME,PARAMVAL,ACTIVE) VALUES (@FIRMID,@PARAMNAME,@PARAMVAL,@ACTIVE)";
                sqlProvider.ClearParameter();
                DataTable dt = new DataTable();

                if (dt.Rows.Count == 0)
                {
                    sqlProvider.addParameter("@FIRMID", firmID);
                    sqlProvider.addParameter("@PARAMNAME", PARAMNAME.Text);
                    sqlProvider.addParameter("@PARAMVAL", PARAMVAL.Text);
                    sqlProvider.addParameter("@ACTIVE", true);
                    sqlProvider.nonQueryMethod(strInsertQuery, false);
                    alanlariTemizle();
                    uyari_Lbl.ForeColor = Color.Green;
                    uyari_Lbl.Text = "Parametre Başarıyla Eklendi !";
                }
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurunuz !";
            }
        }

        protected void paramEkle_btn_Click(object sender, EventArgs e)
        {

            if (parametreVarMı())
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Parametre sistemde mevcut !";
            }
            else
                paramEkle();
        }
        protected bool parametreVarMı()
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

            string strCheckQuery = "SELECT PARAMNAME FROM TBL_PARAM WHERE PARAMNAME = @PARAMNAME and FIRMID = @FIRMID";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@PARAMNAME", PARAMNAME.Text);
            sqlProvider.addParameter("@FIRMID", firmID);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strCheckQuery, false);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}