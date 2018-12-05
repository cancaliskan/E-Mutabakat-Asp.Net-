﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMutabakats_yonetim
{
    public partial class ParametreGuncelle : System.Web.UI.Page
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
            PARAMNAME.Items.Clear();
            PARAMNAME.Items.Add("-- Seçin --");
            PARAMVAL.Text = string.Empty;
            SADECE_ACTIVE_FIRM.Checked = true;
            SADECE_ACTIVE_PARAM.Checked = true;
            ACTIVE.Checked = false;
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

        protected void FIRM_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyari_Lbl.Text = string.Empty;
            PARAMVAL.Text = string.Empty;
            ACTIVE.Checked = false;
            getParamName();
        }

        protected void getParamName()
        {
            PARAMNAME.Enabled = true;
            SADECE_ACTIVE_PARAM.Enabled = true;
            string strParamNameQuery;
            if (!SADECE_ACTIVE_PARAM.Checked)
                strParamNameQuery = "select TBL_PARAM.PARAMNAME from TBL_FIRMS,TBL_PARAM where TBL_FIRMS.ID=TBL_PARAM.FIRMID and TBL_FIRMS.FIRM_CODE=@FIRM_CODE";
            else
                strParamNameQuery = "select TBL_PARAM.PARAMNAME from TBL_FIRMS,TBL_PARAM where TBL_FIRMS.ID=TBL_PARAM.FIRMID and TBL_PARAM.ACTIVE='True' and  TBL_FIRMS.FIRM_CODE=@FIRM_CODE";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@FIRM_CODE", FIRM_CODE.SelectedItem.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strParamNameQuery, false);
            PARAMNAME.Items.Clear();
            PARAMNAME.Items.Add("-- Seçin --");
            foreach (DataRow r in dt.Rows)
            {
                PARAMNAME.Items.Add(r["PARAMNAME"].ToString());
            }

        }

        protected void SADECE_ACTIVE_PARAM_CheckedChanged(object sender, EventArgs e)
        {
            if (SADECE_ACTIVE_PARAM.Checked)
            {
                PARAMVAL.Text = string.Empty;
                ACTIVE.Checked = false;
                SADECE_ACTIVE_PARAM.Checked = true;
                PARAMNAME.Items.Clear();
                getParamName();
            }
            else
            {
                PARAMVAL.Text = string.Empty;
                ACTIVE.Checked = false;
                SADECE_ACTIVE_PARAM.Checked = false;
                PARAMNAME.Items.Clear();
                getParamName();
            }
        }

        protected void PARAMNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strGetQuery = "select PARAMVAL,ACTIVE from TBL_PARAM where PARAMNAME=@PARAMNAME";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@PARAMNAME", PARAMNAME.SelectedItem.Text);
            DataTable dt = new DataTable();
            dt = sqlProvider.dataTableReader(strGetQuery, false);
            if (dt.Rows.Count > 0)
            {
                PARAMVAL.Text = dt.Rows[0]["PARAMVAL"].ToString();
                ACTIVE.Checked = (bool)dt.Rows[0]["ACTIVE"];
            }
        }

        protected void paramGuncelle_btn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string strUpdateQuery = "UPDATE TBL_PARAM SET PARAMVAL=@PARAMVAL, ACTIVE=@ACTIVE WHERE PARAMNAME=@PARAMNAME";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@PARAMNAME", PARAMNAME.SelectedItem.Text);
                sqlProvider.addParameter("@PARAMVAL", PARAMVAL.Text);
                sqlProvider.addParameter("@ACTIVE", ACTIVE.Checked);
                

                sqlProvider.nonQueryMethod(strUpdateQuery, false);
                alanlariTemizle();
                uyari_Lbl.ForeColor = Color.Green;
                uyari_Lbl.Text = "Parametre Başarıyla Güncellendi !";
            }
            else
            {
                uyari_Lbl.ForeColor = Color.Red;
                uyari_Lbl.Text = "Lütfen tüm alanları doldurun !";
            }
        }

        protected void temizle_btn_Click(object sender, EventArgs e)
        {
            alanlariTemizle();
        }
    }
}