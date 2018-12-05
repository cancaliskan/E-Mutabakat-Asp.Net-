using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.DirectoryServices.AccountManagement;
using DorukProvider;






namespace eMutabakats_yonetim
{
    public partial class eMutabakat_MASTER : System.Web.UI.MasterPage
    {
        //clsSqlProvider sqlProvider;
        DorukProvider.clsSqlProvider sqlProvider = new DorukProvider.clsSqlProvider(System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["UserID"] != null)
            {
                load();
                checkPosition();
            }
            else
            {
                Response.Redirect("login.aspx");

            }

        }

        private void checkPosition()
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
                    if(ADMINID != 2)
                    {
                        yeniFirmaOlustur.Visible = false;
                        firmaKapat.Visible = false;
                    }
                }
            }
        }
        private void load()
        {

            if (!IsPostBack)
            {
                //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ConnectionString;
                //sqlProvider = new clsSqlProvider(constr);
                string imgQuery = "select [FIRM_IMAGE2], [FIRM_NAME] from [EMUTABAKAT].[dbo].[TBL_FIRMS] WHERE ID = @ID";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@ID", 1);
                Session["dtFirmInfo"] = sqlProvider.dataTableReader(imgQuery, false);

             
            }

        /*    byte[] image = (byte[])((DataTable)Session["dtFirmInfo"]).Rows[0][0];
            imgFirmLogo.ContentBytes = image;
            imgFirmLogo.Width = 25;
            imgFirmLogo.Height = 25;
            imgFirmLogo_2.ContentBytes = image;// imgFirmLogo.ContentBytes;
            imgFirmLogo_3.ContentBytes = image;// imgFirmLogo.ContentBytes;

            lblFirmName.Text = ((DataTable)Session["dtFirmInfo"]).Rows[0][1].ToString();
            lblFirmName_2.Text = lblFirmName.Text;
            lblFirmName_3.Text = lblFirmName.Text;
            lblFirmInfo.Text = lblFirmName.Text;
            */
          
        }

        //protected void addItemToMenuFromDateTable(DataTable Dt)
        //{
        //    foreach (DataRow dr in Dt.Rows)
        //    {
        //        addItemToMenu(dr["Class"].ToString(), dr["PageLink"].ToString(), dr["PageName"].ToString());
        //    }
        //}

        //protected void addItemToMenu(string Class, string Address, string viewText)
        //{
        //    HtmlGenericControl li = new HtmlGenericControl("li");
        //    li.Attributes.Add("class", "eborder-top");
        //    drpDownMenu.Controls.Add(li);


        //    HtmlGenericControl anchor = new HtmlGenericControl("a");
        //    anchor.Attributes.Add("href", Address);
        //    HtmlGenericControl img = new HtmlGenericControl("i");
        //    img.Attributes.Add("class", "eborder-top icon_mail_alt icon-PivotTable-l");
        //    anchor.Controls.Add(img);
        //    anchor.InnerText = viewText;
        //    li.Controls.Add(anchor);
        
        //}

 

    }
}