using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace eMutabakat
{

    public class unitTurnoverPriceCalculations
    {

        //public void fillUnitSqlDataAdapter(string UnitSqlSource, List<HtmlInputCheckBox> LISTE, RadGrid RadGridExportDomestic, RadGrid RadGridExportVSDomestic, List<Charts> Charts)
        //{
        //    // Within the code body set your variable    
        //    string strCon = ConfigurationManager.ConnectionStrings["IFRSConnection"].ConnectionString;


        //    StringBuilder sb = new StringBuilder();

        //    foreach (HtmlInputCheckBox listItem in LISTE)
        //    {
        //        if (listItem.Checked)
        //        {
        //            sb.Append("'" + listItem.Value + "',");
        //        }
        //    }

        //    string deger = sb.ToString();

        //    if (!string.IsNullOrEmpty(deger))
        //    {
        //        deger = deger.Substring(0, deger.Length - 1);

        //        string sorgu = string.Format(UnitSqlSource, deger);
        //        SqlConnection con = new SqlConnection(strCon);
        //        SqlCommand com = new SqlCommand(sorgu, con);

        //        DataTable tbl = new DataTable();
        //        con.Open();
        //        SqlDataAdapter adp = new SqlDataAdapter(com);
        //        adp.Fill(tbl);


        //        con.Close();
        //        solveUnitDataTable(tbl, RadGridExportVSDomestic, Charts, RadGridExportDomestic);



        //    }
        //    else
        //    {



        //    }

        //}
        //private void solveUnitDataTable(DataTable table, RadGrid RadGridExportVSDomestic, List<Charts> Charts, RadGrid RadGridExportDomestic)
        //{
        //    var querya = from order in table.AsEnumerable()
        //                 select order;


        //    //var queryVS = (from p in querya
        //    //               group p by p.Field<string>("QUERY_GROUP") into g
        //    //               select new
        //    //               {
        //    //                   QUERY_GROUP = g.Key,
        //    //                   VSUNITLY = g.Sum(p => p.Field<double>("UNITSCURRYEAR")) / g.Sum(p => p.Field<double>("UNITSLASTYEAR")) - 1,
        //    //                   VSUNITBP = g.Sum(p => p.Field<double>("UNITSCURRYEAR")) / g.Sum(p => p.Field<double>("UNITSCURRYEARBP")) - 1,
        //    //                   VSTURNOVELY = g.Sum(p => p.Field<double>("TURNOVERCURRYEAR")) / g.Sum(p => p.Field<double>("TURNOVERLASTYEAR")) - 1,
        //    //                   VSTURNOVEBP = g.Sum(p => p.Field<double>("TURNOVERCURRYEAR")) / g.Sum(p => p.Field<double>("TURNOVERCURRYEARBP")) - 1,
        //    //                   VSUNITPRICELY = g.Sum(p => p.Field<double>("UNITPRICECURRYEAR")) / g.Sum(p => p.Field<double>("UNITPRICELASTYEAR")) - 1,
        //    //                   VSUNITPRICEBP = g.Sum(p => p.Field<double>("UNITPRICECURRYEAR")) / g.Sum(p => p.Field<double>("UNITPRICECURRYEARBP")) - 1
        //    //               });


        //    //RadGridExportVSDomestic.DataSource = queryVS;
        //    //RadGridExportVSDomestic.DataBind();



        //    var queryTotal = (from p in querya
        //                      group p by p.GetType() into g
        //                      select new
        //                      {
        //                          TOTAL = "TOTAL",
        //                          UNITSLASTYEAR = g.Sum(p => p.Field<double>("UNITSLASTYEAR")),
        //                          UNITSCURRYEAR = g.Sum(p => p.Field<double>("UNITSCURRYEAR")),
        //                          UNITSCURRYEARBP = g.Sum(p => p.Field<double>("UNITSCURRYEARBP")),
        //                          TURNOVERLASTYEAR = g.Sum(p => p.Field<double>("TURNOVERLASTYEAR")),
        //                          TURNOVERCURRYEAR = g.Sum(p => p.Field<double>("TURNOVERCURRYEAR")),
        //                          TURNOVERCURRYEARBP = g.Sum(p => p.Field<double>("TURNOVERCURRYEARBP")),
        //                          //UNITPRICELASTYEAR = g.Sum(p => p.Field<double>("UNITPRICELASTYEAR")),
        //                          //UNITPRICECURRYEAR = g.Sum(p => p.Field<double>("UNITPRICECURRYEAR")),
        //                          //UNITPRICECURRYEARBP = g.Sum(p => p.Field<double>("UNITPRICECURRYEARBP"))

        //                      });
        //    //string deger = null;

        //    //foreach (var order in queryTotal)
        //    //{
        //    //    deger = string.Format("{0},{1},{2} / {3},{4},{5}",
        //    //         order.UNITSLASTYEAR, order.UNITSCURRYEAR, order.UNITSCURRYEARBP, order.TURNOVERLASTYEAR, order.TURNOVERCURRYEAR, order.TURNOVERCURRYEARBP);
        //    //}


        //    DataRow total = table.NewRow();

        //    foreach (var order in queryTotal)
        //    {
        //        total["QUERY_GROUP"] = order.TOTAL;
        //        total["UNITSLASTYEAR"] = order.UNITSLASTYEAR;
        //        total["UNITSCURRYEAR"] = order.UNITSCURRYEAR;
        //        total["UNITSCURRYEARBP"] = order.UNITSCURRYEARBP;
        //        total["TURNOVERLASTYEAR"] = order.TURNOVERLASTYEAR;
        //        total["TURNOVERCURRYEAR"] = order.TURNOVERCURRYEAR;
        //        total["TURNOVERCURRYEARBP"] = order.TURNOVERCURRYEARBP;

        //        total["UNITPRICELASTYEAR"] = 1000 * order.TURNOVERLASTYEAR / (order.UNITSLASTYEAR);
        //        total["UNITPRICECURRYEAR"] = 1000 * order.TURNOVERCURRYEAR / (order.UNITSCURRYEAR);
        //        total["UNITPRICECURRYEARBP"] = 1000 * order.TURNOVERCURRYEARBP / (order.UNITSCURRYEARBP);

        //    }
        //    table.Rows.Add(total);
        //    RadGridExportDomestic.DataSource = table;


        //    var queryT = from order in table.AsEnumerable()
        //                 select order;

        //    var queryVS = (from p in queryT
        //                   group p by p.Field<string>("QUERY_GROUP") into g
        //                   select new
        //                   {
        //                       QUERY_GROUP = g.Key,
        //                       VSUNITLY =           g.Sum(p => p.Field<double>("UNITSCURRYEAR"))        / g.Sum(p => p.Field<double>("UNITSLASTYEAR"))      - 1,
        //                       VSUNITBP =           g.Sum(p => p.Field<double>("UNITSCURRYEAR"))        / g.Sum(p => p.Field<double>("UNITSCURRYEARBP"))    - 1,
        //                       VSTURNOVELY =        g.Sum(p => p.Field<double>("TURNOVERCURRYEAR"))     / g.Sum(p => p.Field<double>("TURNOVERLASTYEAR"))   - 1,
        //                       VSTURNOVEBP =        g.Sum(p => p.Field<double>("TURNOVERCURRYEAR"))     / g.Sum(p => p.Field<double>("TURNOVERCURRYEARBP")) - 1,
        //                       VSUNITPRICELY =      g.Sum(p => p.Field<double>("UNITPRICECURRYEAR"))    / g.Sum(p => p.Field<double>("UNITPRICELASTYEAR"))  - 1,
        //                       VSUNITPRICEBP =      g.Sum(p => p.Field<double>("UNITPRICECURRYEAR"))    / g.Sum(p => p.Field<double>("UNITPRICECURRYEARBP"))- 1
        //                   });


        //    RadGridExportVSDomestic.DataSource = queryVS;
        //    RadGridExportVSDomestic.DataBind();




        //    //RadGridExportDomesticTotal.DataSource = queryTotal;
        //    //RadGridExportDomesticTotal.DataBind();


        //    double[,] export = new double[2, 6];
        //    foreach (var order in querya)
        //    {
        //        if (order.Field<string>("QUERY_GROUP") == "export")
        //        {
        //            export[0, 0] = order.Field<double>("UNITSLASTYEAR");
        //            export[0, 1] = order.Field<double>("UNITSCURRYEAR");
        //            export[0, 2] = order.Field<double>("UNITSCURRYEARBP");
        //            export[0, 3] = order.Field<double>("TURNOVERLASTYEAR");
        //            export[0, 4] = order.Field<double>("TURNOVERCURRYEAR");
        //            export[0, 5] = order.Field<double>("TURNOVERCURRYEARBP");
        //        }
        //        else if (order.Field<string>("QUERY_GROUP") == "domestic")
        //        {
        //            export[1, 0] = order.Field<double>("UNITSLASTYEAR");
        //            export[1, 1] = order.Field<double>("UNITSCURRYEAR");
        //            export[1, 2] = order.Field<double>("UNITSCURRYEARBP");
        //            export[1, 3] = order.Field<double>("TURNOVERLASTYEAR");
        //            export[1, 4] = order.Field<double>("TURNOVERCURRYEAR");
        //            export[1, 5] = order.Field<double>("TURNOVERCURRYEARBP");

        //        }


        //        //exportDomesticGraficsUpdate(RadHtmlUnit2014, export[0, 0], export[1, 0]);
        //        //exportDomesticGraficsUpdate(RadHtmlUnit2015, export[0, 1], export[1, 1]);
        //        //exportDomesticGraficsUpdate(RadHtmlUnit2015PB, export[0, 2], export[1, 2]);
        //        //exportDomesticGraficsUpdate(RadHtmlTurnOver2014, export[0, 3], export[1, 3]);
        //        //exportDomesticGraficsUpdate(RadHtmlTurnOver2015, export[0, 4], export[1, 4]);
        //        //exportDomesticGraficsUpdate(RadHtmlTurnOver2015PB, export[0, 5], export[1, 5]);


        //        exportDomesticGraficsUpdate(Charts[0], export[0, 0], export[1, 0]);
        //        exportDomesticGraficsUpdate(Charts[1], export[0, 1], export[1, 1]);
        //        exportDomesticGraficsUpdate(Charts[2], export[0, 2], export[1, 2]);
        //        exportDomesticGraficsUpdate(Charts[3], export[0, 3], export[1, 3]);
        //        exportDomesticGraficsUpdate(Charts[4], export[0, 4], export[1, 4]);
        //        exportDomesticGraficsUpdate(Charts[5], export[0, 5], export[1, 5]);

        //    }
        //}
        //private void exportDomesticGraficsUpdate(Charts chart, double Export, double Domestic)
        //{

        //    double ex = Export / (Export + Domestic);
        //    List<Trade> browsers = new List<Trade>();
        //    browsers.Add(new Trade("EXPORT", ex, true, "#ff2d55"));
        //    browsers.Add(new Trade("DOMESTIC", 1 - ex, false, "#ffcc00"));
        //    chart.RadHtmlCahrts.ChartTitle.Text = string.Format(" {2} Ex : {0:0} Dom : {1:0} ", ex * 100, (1 - ex) * 100, chart.Name);

        //    chart.RadHtmlCahrts.DataSource = browsers;
        //    chart.RadHtmlCahrts.DataBind();

        //}


    }
}
