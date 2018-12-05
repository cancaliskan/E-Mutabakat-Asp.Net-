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
    public partial class FirmaKaldir : System.Web.UI.Page
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
                        Response.Redirect("yetkinizYok.aspx", false);
                    else
                        firmaYukle();
                }
            }

        }

        protected void firmaYukle()
        {
            uyari_Lbl.Text = "";
            string strFirmCodeQuery = "SELECT FIRM_CODE FROM TBL_FIRMS where ACTIVE='True' order by FIRM_CODE";
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

        protected void firmaKapat_btn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string strUpdateQuery = "UPDATE TBL_FIRMS SET ACTIVE=@ACTIVE WHERE FIRM_CODE=@FIRM_CODE";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.Text);
                sqlProvider.addParameter("@ACTIVE", false);

                sqlProvider.nonQueryMethod(strUpdateQuery, false);
                FIRM_CODE.Items.Clear();
                firmaYukle();
                uyari_Lbl.ForeColor = Color.Green;
                uyari_Lbl.Text = "Firma Başarıyla Kapatıldı !";
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen firma seçin !";
            }
        }

        protected void FIRM_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = "";
        }
    }
}