using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;
using System.Data;
using System.Web.SessionState;
using System.Text;
using DorukProvider;

namespace eMutabakats_yonetim
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            int firmID = -1;
            string path = null;
            try
            {
                string strLoginQuery = "select TBL_USERS.USERNAME,TBL_USERS.ID,TBL_USERS.FIRMID,TBL_USERS.ADMINID,TBL_FIRMS.ACTIVE from TBL_USERS,TBL_FIRMS where TBL_USERS.PASSWORD = @PASSWORD and TBL_USERS.USERNAME=@USERNAME and TBL_FIRMS.ID=TBL_USERS.FIRMID";
                DorukProvider.clsSqlProvider sqlProvider = new DorukProvider.clsSqlProvider(System.Configuration.ConfigurationManager.ConnectionStrings["drkEmutabakat"].ToString());
                sqlProvider.addParameter("@USERNAME", UserName.Text);
                string password = DorukProvider.clsSifrele.Encrypt(Password.Text, true);
                sqlProvider.addParameter("@PASSWORD", password);
                DataTable dt = new DataTable();
                dt = sqlProvider.dataTableReader(strLoginQuery, false);
                if (dt.Rows.Count > 0)
                {
                    Session["UserName"] = dt.Rows[0][0].ToString();
                    Session["UserID"] = dt.Rows[0][1].ToString();
                    Session["adminID"] = dt.Rows[0]["ADMINID"].ToString();
                    firmID = Convert.ToInt32(dt.Rows[0]["FIRMID"]);

                    int adminID=(int) dt.Rows[0]["ADMINID"];
                    bool active = (bool) dt.Rows[0]["ACTIVE"];
                    #region parametrelerin session'a aktarımı

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT PARAMNAME,PARAMVAL FROM [dbo].[TBL_PARAM] WHERE FIRMID IN ");
                    sb.AppendLine(" (SELECT FIRMID FROM[dbo].[TBL_USERS] WHERE ID = @USERID)");
                    DataTable dtParam = new DataTable();
                    sqlProvider.ClearParameter();
                    sqlProvider.addParameter("@USERID", dt.Rows[0][1].ToString());



                    dtParam = sqlProvider.dataTableReader(sb.ToString(), false);

                    foreach (DataRow dtRw in dtParam.Rows)
                    {
                        Session[dtRw["PARAMNAME"].ToString()] = dtRw["PARAMVAL"].ToString();
                    }

                    #endregion
                    //if (adminmID.Equals("2"))
                    //    Response.Redirect("yonetim.aspx", false);
                    //else
                    //    Response.Redirect("yonetim_Kullanici.aspx", false);
                    if (active && (adminID == 1 || adminID == 2))
                        Response.Redirect("yonetim.aspx", false);
                    else if (active && (adminID == 0))
                        throw new Exception("Giriş yetkiniz bulunmamakta !");
                    else
                        throw new Exception("Kayıtlı olduğunuz firma aktif değil !");

                    #region activation Kontrol
                    //string sqlStr = "select  FIRM_CODE , ACTCODE from TBL_FIRMS WHERE ID = @FIRM_ID";
                    //DataTable dtAct = new DataTable();
                    //sqlProvider.ClearParameter();
                    //sqlProvider.addParameter("@FIRM_ID", firmID);
                    //dtAct = sqlProvider.dataTableReader(sqlStr, false);
                    //string enct_Code = dtAct.Rows[0]["ACTCODE"].ToString();
                    //string strFirmCode = dtAct.Rows[0]["FIRM_CODE"].ToString();
                    //string _dect_Code = clsSifrele.Decrypt(enct_Code, true);
                    //string[] dect_Code = _dect_Code.Split(';');

                    //string dect_firmCode = dect_Code[0];
                    //string dect_act_date = dect_Code[1];



                    //if (dect_firmCode == strFirmCode)
                    //{
                    //    DateTime date_dect_act_date = new DateTime();

                    //    date_dect_act_date = Convert.ToDateTime(dect_act_date);
                    //    if (DateTime.Now.Date <= date_dect_act_date)
                    //    {
                    //        Response.Redirect("yonetim.aspx", false);
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("Aktivasyon süreniz dolmuştur. Lütfen sistem yöneticiniz ile iletişime geçiniz");

                    //    }

                    //}
                    //else
                    //{

                    //    throw new Exception("Kullanılan Aktivasyon koduna ait firma kodu sistemde tanımlı olan firma kodu ile uyumlu değil");

                    //}

                    #endregion

                }
                else
                {

                    throw new Exception("Kullanıcı Adı veya Parolası Hatalı");

                }

            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                return;
            }


        }


    }
}