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

namespace eMutabakats_yonetim
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

           protected void addItemToMenuFromDateTable(DataTable Dt)
        {

            foreach (DataRow dr in Dt.Rows)
            {

                addItemToMenu(dr["Class"].ToString(), dr["PageLink"].ToString(), dr["PageName"].ToString());

            }


        }

        protected void addItemToMenu(string Class, string Address, string viewText)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "eborder-top");
            drpDownMenu.Controls.Add(li);


            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", Address);


            HtmlGenericControl img = new HtmlGenericControl("i");
            img.Attributes.Add("class", "eborder-top icon_mail_alt icon-PivotTable-l");
            
            anchor.Controls.Add(img);
           
            anchor.InnerText = viewText;

            
           
            li.Controls.Add(anchor);
        
        }

        

      




    }
}

