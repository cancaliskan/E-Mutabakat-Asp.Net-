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
    public partial class eMutabakat_Cari_MASTER : System.Web.UI.MasterPage
    {
        clsSqlProvider sqlProvider;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ConnectionString;
                sqlProvider = new clsSqlProvider(constr);
                string imgQuery = "select [FIRM_IMAGE2] from [EMUTABAKAT].[dbo].[TBL_FIRMS] WHERE ID = @ID";
                string firmaNameQuery = "select [FIRM_NAME] from [EMUTABAKAT].[dbo].[TBL_FIRMS] WHERE ID = @ID";
                sqlProvider.ClearParameter();
                sqlProvider.addParameter("@ID", 1);
                imgFirmLogo.ContentBytes = (byte[]) sqlProvider.scalarMethod(imgQuery,false) ;
                imgFirmLogo.Width = 25;
                imgFirmLogo.Height = 25;
                imgFirmLogo_2.ContentBytes = imgFirmLogo.ContentBytes;
                lblFirmName.Text = sqlProvider.scalarMethod(firmaNameQuery, false).ToString();
                lblFirmName_2.Text = lblFirmName.Text;
            }
            
          

            if (HttpContext.Current.Session["UserName"] == null)
            {
                Session["UserName"] = Request.QueryString["UserName"];
            }

            if (HttpContext.Current.Session["UserName"] == null)
            {

                // Response.Redirect("../login.aspx");

            }
            else
            {

           
            
            }




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