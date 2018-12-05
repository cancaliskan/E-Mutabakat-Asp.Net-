using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DorukProvider
{
    public class clsPrepareMail
    {

        private string _sqlStrInsertLog
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO DRK_TBL_LOG");
                sb.AppendLine("([LOGTIPI],[LOGYERI],[LOGACIKLAMA])");
                sb.AppendLine(" VALUES (@LOGTIPI,@LOGYERI,@LOGACIKLAMA) ");

                return sb.ToString();


            }
        }



        protected DorukProvider.clsSqlProvider sqlProvider;
        string strLink;
        private string mailBody(int aggrement_TYPE_ID, DataRow[] dr, string firmID)
        {
            string result = "";

            StringBuilder sb = new StringBuilder();

            if (aggrement_TYPE_ID == 1)
            {
                //sb.AppendLine("<br>Sayın,");
                //sb.AppendLine("<br>#CARI_ADI# ");
                //sb.AppendLine("<br> ");


                //sb.AppendLine("<br>Nezdimizdeki hesabınız hakkında.  ");
                
                //foreach (var RW in dr)
                //{
                //    sb.AppendLine("<br>");
                //    //sb.AppendFormat("Şirketimizdeki #CARI_KOD{0}# numaralı cari hesabınız #TARIH# tarihi itibari ile #DEGER{1}# YTL #BORC_ALACAK{2}# bakiyesi vermektedir. "

                //    sb.AppendFormat("<br>Şirketimizdeki {0} numaralı cari hesabınız #TARIH# tarihi itibari ile {1} {2} {3} bakiyesi vermektedir. "
                //        , RW["CURRENT_ACCOUNT_NO"].ToString()
                //        , RW["BALANCE"].ToString()
                //        , RW["CURRENCY"].ToString()
                //        , RW["BORC_ALACAK"].ToString());
                //  }

                //sb.AppendLine("<br>Aşağıdakli kısayol ile ulaşacağınız sayfadan. Mutabık olup olmadığımızı bildirmenizi rica ederiz.");
                //sb.AppendLine("<br>Saygılarımızla,");

                
                sb.AppendLine("<div class=WordSection1>");
                sb.AppendLine("");
                sb.AppendLine("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");
                sb.AppendLine("");
                sb.AppendLine("<table class=MsoNormalTable border=0 cellspacing=3 cellpadding=0 width=768");
                 sb.AppendLine("style='width:576.0pt;mso-cellspacing:2.2pt;mso-yfti-tbllook:1184;mso-padding-alt:");
                 sb.AppendLine("0cm 0cm 0cm 0cm'>");
                 sb.AppendLine("<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:39.0pt'>");
                  sb.AppendLine("<td colspan=4 style='border:none;border-bottom:solid #DFDFDF 1.0pt;");
                  sb.AppendLine("background:#60AA17;padding:0cm 0cm 0cm 0cm;height:39.0pt'>");
                  sb.AppendLine("<p class=MsoNormal align=center style='text-align:center'><span");
                  sb.AppendLine("style='font-size:15.0pt;font-family:'Arial',sans-serif;color:white'>Cari");
                  sb.AppendLine("Hesap Mutabakat Mektubu Dönem (#YEAR# / #TERM#) <o:p></o:p></span></p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:1'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal><strong>Gönderen Firma : #GONFIRMA#</strong></p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:2'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:3'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Vergi Dairesi :#VD#</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:4'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Vergi No : #VN#</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:5'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:6'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal><strong>Gönderim Tarih :#DATE#</strong></p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:7'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:8'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Konu : Cari Hesap Mutabakat Mektubu Dönem (#YEAR# / #TERM#) </p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:9'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:10'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal><strong>Sayın Yetkili : </strong></p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:11'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 //sb.AppendLine("<tr style='mso-yfti-irow:12'>");
                 // sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                 // sb.AppendLine("<p class=MsoNormal>Vergi Dairesi : #C_VD#</p>");
                 // sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:13'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Vergi No : #C_VN#</p>");
                  sb.AppendLine("</td>");
                  sb.AppendLine("</tr>");
                  sb.AppendLine("<tr style='mso-yfti-irow:13'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Ünvan : #CARI_ADI# </p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:14'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:15'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:16'>");
                  sb.AppendLine("<td colspan=4 style='background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal align=center style='text-align:center'><strong>Cari Hesap");
                  sb.AppendLine("Mutabakat Mektubu Dönem (#YEAR# / #TERM#)</strong></p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                sb.AppendLine(" ");
                 sb.AppendLine("<tr style='mso-yfti-irow:17'>");
                 sb.AppendLine("<td width='25%' style='width:35.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                 sb.AppendLine("<p class=MsoNormal><strong>Müsteri Kodu</strong></p>");
                 sb.AppendLine("</td>");
                  sb.AppendLine("<td width='25%' style='width:35.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal><strong>Alacak/Borç</strong></p>");
                  sb.AppendLine("</td>");
                  sb.AppendLine("<td width='25%' style='width:35.0%;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Tutar</p>");
                  sb.AppendLine("</td>");
                    sb.AppendLine("<td width='25%' style='width:35.0%;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Para Birimi</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 //sb.AppendLine("///////////////////////////////////////////");

                 foreach (var RW in dr)
                 {



                     sb.AppendLine("<tr style='mso-yfti-irow:17'>");
                     sb.AppendLine("<td width='25%' style='width:35.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                     sb.AppendLine("");
                     sb.AppendFormat("<p class=MsoNormal><strong>{0}</strong></p>", RW["CURRENT_ACCOUNT_NO"].ToString());
                     sb.AppendLine("</td>");

                     sb.AppendLine("<td width='25%' style='width:35.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");

                     sb.AppendLine("");
                     sb.AppendFormat("<p class=MsoNormal style='text-align:center' >{0} </p>", RW["BORC_ALACAK"].ToString());
                     sb.AppendLine("</td>");
                     sb.AppendLine("<td width='25%' style='width:35.0%;padding:0cm 0cm 0cm 0cm'>");
                     sb.AppendLine("");
                     sb.AppendFormat("<p class=MsoNormal>{0:n2}</p>", Convert.ToDouble( RW["BALANCE"].ToString()) );
                     sb.AppendLine("</td>");
                     sb.AppendLine("<td width='25%' style='width:35.0%;padding:0cm 0cm 0cm 0cm'>");
                     sb.AppendLine("");
                     sb.AppendFormat("<p class=MsoNormal>{0}</p>", RW["CURRENCY"].ToString());
                     sb.AppendLine("</td>");
                     sb.AppendLine("</tr>");

                     //sb.AppendFormat("Şirketimizdeki #CARI_KOD{0}# numaralı cari hesabınız #TARIH# tarihi itibari ile #DEGER{1}# YTL #BORC_ALACAK{2}# bakiyesi vermektedir. "

                     //sb.AppendFormat("<br>Şirketimizdeki {0} numaralı cari hesabınız #TARIH# tarihi itibari ile {1} {2} {3} bakiyesi vermektedir. "
                     //    , RW["CURRENT_ACCOUNT_NO"].ToString()
                     //    , RW["BALANCE"].ToString()
                     //    , RW["CURRENCY"].ToString()
                     //    , RW["BORC_ALACAK"].ToString());
                 }


                 //sb.AppendLine("///////////////////////////////////////////");
                 sb.AppendLine("<tr style='mso-yfti-irow:21'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:22;mso-yfti-lastrow:yes'>");
                  sb.AppendLine("<td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>Söz konusu tarih için, bu bakiyede mutabıksanız alttaki");
                  sb.AppendLine("“Mutabıkız” butonunu tıklamanızı, mutabık değilseniz “Mutabık değiliz”");
                  sb.AppendLine("butonunu tıklayarak cari ekstrenizi sistem üzerinden paylaşmanızı rica");
                  sb.AppendLine("ederiz. </p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("");
                sb.AppendLine("<p class=MsoNormal><span style='display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p>");
                sb.AppendLine("");
                sb.AppendLine("<table class=MsoNormalTable border=0 cellspacing=3 cellpadding=0 width=768");
                 sb.AppendLine("style='width:576.0pt;mso-cellspacing:2.2pt;mso-yfti-tbllook:1184;mso-padding-alt:");
                 sb.AppendLine("0cm 0cm 0cm 0cm'>");
                 sb.AppendLine("<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>");
                  sb.AppendLine("<td style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                  sb.AppendLine("<td width=668 style='width:501.0pt;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("<tr style='mso-yfti-irow:1'>");
                  sb.AppendLine("<td style='padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp; </p>");
                  sb.AppendLine("</td>");
                  sb.AppendLine("<td width=668 style='width:501.0pt;padding:0cm 0cm 0cm 0cm'>");
                  sb.AppendLine("<p class=MsoNormal>&nbsp;</p>");
                  sb.AppendLine("</td>");
                 sb.AppendLine("</tr>");
                sb.AppendLine("</table>");
               
                sb.AppendLine("<p class=MsoNormal><span style='display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p> ");

                sb.AppendLine("<table class=MsoNormalTable border=0 cellspacing=3 cellpadding=0 width=768");
                sb.AppendLine(" style='width:576.0pt;mso-cellspacing:2.2pt;mso-yfti-tbllook:1184;mso-padding-alt:");
                sb.AppendLine(" 0cm 0cm 0cm 0cm'>");

                sb.AppendLine("  <td width='50%' style='width:50.0%;border:none;border-bottom:solid #DFDFDF 1.0pt;");
                sb.AppendLine("  background:#2E8DEF;padding:0cm 0cm 0cm 0cm;height:30.0pt'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><a");
                sb.AppendLine("  href='#LINK#'");
                sb.AppendLine("  target='_blank'><span style='font-family:'Arial',sans-serif;color:white'>  Mutabakat için linke tıklayınız  </span></a></p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine("</table>");




                sb.AppendLine(" <br> ");
                sb.AppendLine("");
                sb.AppendLine("</div>");





              
            }
            //else if (aggrement_TYPE_ID == 3)
            //{
            //    sb.AppendLine("Sayın,");
            //    sb.AppendLine("#CARI_ADI# ");
            //    sb.AppendLine(" ");
            //    sb.AppendLine("Nezdimizdeki BA-BS hakkında.  ");
            //    sb.AppendLine("Şirketimizdeki #CARI_KOD# numaralı cari hesabınız #TARIH# tarihi itibari ile #DEGER_ALIS# YTL #BORC_ALACAK# bakiyesi vermektedir. ");
            //    sb.AppendLine("Aşağıdakli kısayol ile ulaşacağınız sayfadan. Mutabık olup olmadığımızı bildirmenizi rica ederiz.");
            //    sb.AppendLine("Saygılarımızla,");
            //}
            else if (aggrement_TYPE_ID == 2)
            {
                //sb.AppendLine("<br>Sayın,");
                //sb.AppendLine("<br>#CARI_ADI# ");
                //sb.AppendLine("<br> ");


                //sb.AppendLine("<br>Nezdimizdeki BA-BS hakkında.  ");

                //sb.AppendLine("<br>Şirketimizdeki #CARI_KOD# numaralı cari hesabınız #TARIH# tarihi itibari ile ; ");
                //sb.AppendLine("<br>");
                //foreach (var RW in dr)
                //{
                //    sb.AppendLine("<br>");
                //    sb.AppendFormat ("{0} YTL, {1} adet fatura ile {2} işlemi"
                //        , RW["BALANCE"].ToString()
                //        , RW["COUNT"].ToString()
                //        , RW["BORC_ALACAK"].ToString()
                        
                //        );
                //}

                //sb.AppendLine("<br>");
                //sb.AppendLine("<br> gerçekleşmiştir. ");

                //sb.AppendLine("<br>Aşağıdakli kısayol ile ulaşacağınız sayfadan. Mutabık olup olmadığımızı bildirmenizi rica ederiz.");
                //sb.AppendLine("<br>Saygılarımızla,");

                sb.AppendLine("<div class=WordSection1>");

                sb.AppendLine("<p class=MsoNormal><span style='mso-tab-count:1'> </span></p>");
                sb.AppendLine("<table class=MsoNormalTable border=0 cellspacing=3 cellpadding=0 width=768");
                sb.AppendLine(" style='width:576.0pt;mso-cellspacing:2.2pt;mso-yfti-tbllook:1184;mso-padding-alt:");
                sb.AppendLine(" 0cm 0cm 0cm 0cm'>");
                sb.AppendLine(" <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:39.0pt'>");
                sb.AppendLine("  <td colspan=4 style='border:none;border-bottom:solid #DFDFDF 1.0pt;");
                sb.AppendLine("  background:#60AA17;padding:0cm 0cm 0cm 0cm;height:39.0pt'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><span");
                sb.AppendLine("  style='font-size:15.0pt;line-height:107%;font-family:'Arial',sans-serif;");
                sb.AppendLine("  color:white'>Form BA&amp;BS Mutabakat Mektubu Dönem (#YEAR# / #TERM#) <o:p></o:p></span></p>");
                sb.AppendLine(" </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:1'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal><strong><span style='font-family:'Calibri',sans-serif;");
                sb.AppendLine("  mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
                sb.AppendLine("  'Times New Roman';mso-bidi-theme-font:minor-bidi'>Gönderen Firma : #GONFIRMA# </span></strong><span");
                sb.AppendLine("  style='font-size:12.0pt;line-height:107%;font-family:'Times New Roman',serif'><o:p></o:p></span></p>");
                sb.AppendLine(" </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:2'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:3'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine(" <p class=MsoNormal>Vergi Dairesi : #VD#</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:4'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>Vergi No : #VN#</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:5'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:6'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal><strong><span style='font-family:'Calibri',sans-serif;");
                sb.AppendLine("  mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
                sb.AppendLine("  'Times New Roman';mso-bidi-theme-font:minor-bidi'>Gönderim Tarih : #DATE#</span></strong></p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:7'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:8'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>Konu : Form BA&amp;BS Mutabakat Mektubu Dönem (#YEAR# / #TERM#) </p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:9'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:10'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal><strong><span style='font-family:'Calibri',sans-serif;");
                sb.AppendLine("  mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
                sb.AppendLine("  'Times New Roman';mso-bidi-theme-font:minor-bidi'>Sayın Yetkili : </span></strong></p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:11'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:12'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal> #CARI_ADI# </p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:13'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>Vergi No : #C_VN#</p>");
                sb.AppendLine(" </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:14'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine(" <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:15'>");
                sb.AppendLine("  <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal>&nbsp;</p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine(" <tr style='mso-yfti-irow:16'>");
                sb.AppendLine("  <td colspan=2 style='background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><strong><span");
                sb.AppendLine("  style='font-family:'Calibri',sans-serif;mso-ascii-theme-font:minor-latin;");
                sb.AppendLine("  mso-hansi-theme-font:minor-latin;mso-bidi-font-family:'Times New Roman';");
                sb.AppendLine("  mso-bidi-theme-font:minor-bidi'>FORM TIPI</span></strong></p>");
                sb.AppendLine("  </td>");
  
                sb.AppendLine("    <td  style='background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><strong><span");
                sb.AppendLine("  style='font-family:'Calibri',sans-serif;mso-ascii-theme-font:minor-latin;");
                sb.AppendLine("  mso-hansi-theme-font:minor-latin;mso-bidi-font-family:'Times New Roman';");
                sb.AppendLine("  mso-bidi-theme-font:minor-bidi'>Belge Sayısı:</span></strong></p>");
                sb.AppendLine("  </td>");
                sb.AppendLine("    <td colspan=2 style='background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><strong><span");
                sb.AppendLine("  style='font-family:'Calibri',sans-serif;mso-ascii-theme-font:minor-latin;");
                sb.AppendLine("  mso-hansi-theme-font:minor-latin;mso-bidi-font-family:'Times New Roman';");
                sb.AppendLine("  mso-bidi-theme-font:minor-bidi'>Net Tutar:</span></strong></p>");
                sb.AppendLine("  </td> ");
  
                sb.AppendLine("  </tr>");
 
                sb.AppendLine("  <tr style='mso-yfti-irow:17'>");
                sb.AppendLine("   <td colspan=2 width='25%' style='width:25.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal><strong><span style='font-family:'Calibri',sans-serif;");
                sb.AppendLine("   mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
                sb.AppendLine("   'Times New Roman';mso-bidi-theme-font:minor-bidi'>#BA#</span></strong></p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("   <td width='25%' style='width:25.0%;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal style='text-align:center' > #BA_COUNT# </p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("     <td width='25%' style='width:25.0%;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal style='text-align:center' > #BA_BALANCE# </p>");
                sb.AppendLine("   </td>");
 
                sb.AppendLine("  </tr>");
 
 
 
 
 
                sb.AppendLine("   <tr style='mso-yfti-irow:17'>");
                sb.AppendLine("   <td colspan=2 width=225%' style='width:25.0%;background:#EDEDED;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal><strong><span style='font-family:'Calibri',sans-serif;");
                sb.AppendLine("   mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
                sb.AppendLine("   'Times New Roman';mso-bidi-theme-font:minor-bidi'>#BS#</span></strong></p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("   <td width='25%' style='width:25.0%;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal style='text-align:center' > #BS_COUNT# </p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("     <td width='25%' style='width:25.0%;padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal style='text-align:center' > #BS_BALANCE# </p>");
                sb.AppendLine("   </td>");
 
                sb.AppendLine("  </tr>");
 
 
 
 
                sb.AppendLine("  <tr style='mso-yfti-irow:19'>");
                sb.AppendLine("   <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal>&nbsp;<span style='font-size:12.0pt;line-height:107%'><o:p></o:p></span></p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr style='mso-yfti-irow:20;mso-yfti-lastrow:yes'>");
                sb.AppendLine("   <td colspan=4 style='padding:0cm 0cm 0cm 0cm'>");
                sb.AppendLine("   <p class=MsoNormal>Bilindiği Üzere 213 Sayılı V.U.K&quot; nun 148.149 mükerrer ve 257.");
                sb.AppendLine("   Maddelerinin Maliye Bakanlığına verdiği yetkiye dayanarak <br>");
                sb.AppendLine("   362,381,396 sıra nolu V.U.K tebliğ ile Esasına göre defter tutan mükellefler Form");
                sb.AppendLine("   BA/BS Düzenleyeceklerdir <br>");
                sb.AppendLine("   #YEAR# / #TERM# Cari Dönemine");
                sb.AppendLine("   ait Form BA/BS tutar bilgisinde, <br>");
                sb.AppendLine("    alttaki kısayoldan acilan pencerede  mutabıksanız  ONAY butonunu tıklamanızı, mutabık değilseniz");
                sb.AppendLine("   “REDDET” butonunu tıklayarak cari ekstrenizi sistem üzerinden");
                sb.AppendLine("   paylaşmanızı rica ederiz. </p>");
                sb.AppendLine("   </td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine(" </table>");



                sb.AppendLine("<p class=MsoNormal><span style='display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p> ");

                sb.AppendLine("<table class=MsoNormalTable border=0 cellspacing=3 cellpadding=0 width=768");
                sb.AppendLine(" style='width:576.0pt;mso-cellspacing:2.2pt;mso-yfti-tbllook:1184;mso-padding-alt:");
                sb.AppendLine(" 0cm 0cm 0cm 0cm'>");

                sb.AppendLine("  <td width='50%' style='width:50.0%;border:none;border-bottom:solid #DFDFDF 1.0pt;");
                sb.AppendLine("  background:#2E8DEF;padding:0cm 0cm 0cm 0cm;height:30.0pt'>");
                sb.AppendLine("  <p class=MsoNormal align=center style='text-align:center'><a");
                sb.AppendLine("  href='#LINK#'");
                sb.AppendLine("  target='_blank'><span style='font-family:'Arial',sans-serif;color:white'>  Mutabakat için linke tıklayınız  </span></a></p>");
                sb.AppendLine("  </td>");
                sb.AppendLine(" </tr>");
                sb.AppendLine("</table>");

                

                sb.AppendLine(" </div> ");



            }

          
            string hash = clsSifrele.Encrypt(firmID + ":" + dr[0]["TAXTNUMBER"].ToString() + ":" + Convert.ToDateTime(dr[0]["AGGREMENT_DATE"]).ToString("yyyy-MM-dd") + ":" + aggrement_TYPE_ID, true);
            hash = hash.Replace("+", "%2B");
           
            if (aggrement_TYPE_ID == 1)
            {
         
                 //sb.AppendFormat(" <a href='http://{1}/cari_mutabakat.aspx?ID={0}' >Lutfen Linki Tklayınız</a>", hash, dr[0]["WEB_LINK"].ToString());
                strLink = string.Format("http://{1}/cari_mutabakat.aspx?ID={0}", hash, dr[0]["WEB_LINK"].ToString());
                 //(" <a href='http://{1}/cari_mutabakat.aspx?ID={0}' >Lutfen Linki Tklayınız</a>", hash, dr[0]["WEB_LINK"].ToString());
                result = sb.ToString();

                result = sb.ToString();
                result = result.Replace("#CARI_ADI#", dr[0]["CURRENTTITLE"].ToString());
                result = result.Replace("#CARI_KOD#", dr[0]["CURRENT_ACCOUNT_NO"].ToString());
                result = result.Replace("#GONFIRMA#", dr[0]["FIRM_NAME"].ToString());
                


                result = result.Replace("#VN#", dr[0]["FIRM_CODE"].ToString());
                result = result.Replace("#VD#", dr[0]["FIRMVD"].ToString());


                result = result.Replace("#YEAR#", dr[0]["AG_YEAR"].ToString());
                result = result.Replace("#TERM#", dr[0]["TERMID"].ToString());

                //result = result.Replace("#C_VD#", dr[0]["TAXTNUMBER"].ToString());
                result = result.Replace("#C_VN#", dr[0]["TAXTNUMBER"].ToString());

                result = result.Replace("#DATE#", DateTime.Now.ToString("dd.MM.yyyy"));
                result = result.Replace("#LINK#", strLink);  

                //result = result.Replace("#CARI_ADI#", dr[0]["CURRENTTITLE"].ToString());
                //result = result.Replace("#TARIH#", Convert.ToDateTime(dr[0]["AGGREMENT_DATE"]).ToString("dd.MM.yyyy"));


                    //result = result.Replace("#CARI_KOD{0}#", dr[0]["CURRENT_ACCOUNT_NO"].ToString());
                    //result = result.Replace("#DEGER#", dr[0]["BALANCE"].ToString());
                    //result = result.Replace("#BORC_ALACAK#", dr[0]["BORC_ALACAK"].ToString());
                


            }
            else if (aggrement_TYPE_ID == 2)
            {

   
                //sb.AppendFormat("<a href='http://{1}/babs_mutabakat.aspx?ID={0}' >Lutfen Linki Tklayınız</a>", hash, dr[0]["WEB_LINK"].ToString());
               // sb.AppendFormat("http://{1}/babs_mutabakat.aspx?ID={0}", hash, dr[0]["WEB_LINK"].ToString());
                result = sb.ToString();
                result = result.Replace("#CARI_ADI#", dr[0]["CURRENTTITLE"].ToString() );
                result = result.Replace("#CARI_KOD#", dr[0]["CURRENT_ACCOUNT_NO"].ToString());
                result = result.Replace("#GONFIRMA#", dr[0]["FIRM_NAME"].ToString());

                

                result = result.Replace("#VN#", dr[0]["FIRM_CODE"].ToString());
                result = result.Replace("#VD#", dr[0]["FIRMVD"].ToString());


                result = result.Replace("#YEAR#", dr[0]["AG_YEAR"].ToString());
                result = result.Replace("#TERM#", dr[0]["TERMID"].ToString());

                //result = result.Replace("#C_VD#", dr[0]["TAXTNUMBER"].ToString());
                result = result.Replace("#C_VN#", dr[0]["TAXTNUMBER"].ToString());

                result = result.Replace("#DATE#", DateTime.Now.ToString("dd.MM.yyyy"));


                result = result.Replace("#BA#", dr[0]["BORC_ALACAK"].ToString());
                result = result.Replace("#BA_COUNT# ", dr[0]["COUNT"].ToString());
                result = result.Replace("#BA_BALANCE#", string.Format("{0:n2}", Convert.ToDouble( dr[0]["BALANCE"].ToString() )));
                result = result.Replace("#BS#", dr[1]["BORC_ALACAK"].ToString());
                result = result.Replace("#BS_COUNT# ", dr[1]["COUNT"].ToString());
                result = result.Replace("#BS_BALANCE# ", string.Format("{0:n2}", Convert.ToDouble(  dr[1]["BALANCE"].ToString() ))    );

                strLink = string.Format("http://{1}/babs_mutabakat.aspx?ID={0}", hash, dr[0]["WEB_LINK"].ToString()); 
                result = result.Replace("#TARIH#", Convert.ToDateTime(dr[0]["AGGREMENT_DATE"]).ToString("dd.MM.yyyy"));
                result = result.Replace("#LINK#",  strLink );
            }

            return result;

        }

        private string mailSubject(int aggrement_TYPE_ID)
        {
            StringBuilder sb = new StringBuilder();

            if (aggrement_TYPE_ID == 1)
            {
                sb.Append("CARI MUTABAKAT HK");

            }
            else if (aggrement_TYPE_ID == 2)
            {
                sb.Append("BA-BS MUTABAKAT HK");

            }
            else if (aggrement_TYPE_ID == 3)
            {
                sb.Append("BS MUTABAKAT HK");

            }

            return sb.ToString();




        }


        public clsPrepareMail(string sqlConStr)
        {

            sqlProvider = new DorukProvider.clsSqlProvider(sqlConStr);

        }

        public void PrepareMail(string firmId, int aggrement_TYPE_ID , int mailWaitTime)
        {

            #region getInformationCurrent

            DataTable CurrentList = new DataTable();
            string strSqlCurrentList = " SELECT DISTINCT top 50  TAXTNUMBER  FROM VW_NOT_MAILED_AGGREMENT_BY_FIRMCODE  WHERE TYPE_ID IN (@TYPE_ID)";
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@TYPE_ID", aggrement_TYPE_ID);
            CurrentList = sqlProvider.dataTableReader(strSqlCurrentList, false);

            #endregion


            #region getInformationToSend


            DataTable dtMailList = new DataTable();
            string sqlStrAggrement = "SELECT top 50 * FROM VW_NOT_MAILED_AGGREMENT_BY_FIRMCODE  WHERE TYPE_ID IN (@TYPE_ID) AND TAXTNUMBER=@TAXTNUMBER ";
        


            #endregion

            #region getFirmInformation
            string sqlStrFirm = "SELECT * FROM [TBL_FIRMS] where ID = @FIRMID";
            DataTable dtFirm = new DataTable();
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@FIRMID", firmId);
            dtFirm = sqlProvider.dataTableReader(sqlStrFirm, false);

            #endregion

            string emailAdress = "";

            if (dtFirm != null && dtFirm.Rows.Count > 0)
            {
                #region Send_Mail
                clsSendMail eMailSender = new clsSendMail();
                eMailSender.fromMail = dtFirm.Rows[0]["SENDER_EMAIL"].ToString();
                eMailSender.fromMailText = dtFirm.Rows[0]["SENDER_EMAIL_TEXT"].ToString();

                eMailSender.mailPort = Convert.ToInt32(dtFirm.Rows[0]["EMAIL_PORT"].ToString());
                eMailSender.mailServer = dtFirm.Rows[0]["SMTP_SERVER"].ToString();
                eMailSender.password = dtFirm.Rows[0]["EMAIL_PASSWORD"].ToString();
                eMailSender.ssl = Convert.ToBoolean(dtFirm.Rows[0]["SSL"]);

                #endregion

                #region UpdateMailedStarus
                string strUpdateMailedStatus = "UPDATE [TBL_CURRENT_AGGREMENT] SET [LAST_MAIL_DATE] = GETDATE(), MAILED = @MAILED, MAIL_TRY_COUNT = MAIL_TRY_COUNT +  1  WHERE ID = @ID ";

                StringBuilder strInsertSentMailLog = new StringBuilder();
                strInsertSentMailLog.AppendLine("INSERT INTO [dbo].[TBL_MAIL_LOG] ");
                strInsertSentMailLog.AppendLine("([AG_ID] ");
                strInsertSentMailLog.AppendLine(",[MAILEDDATE] ");
                strInsertSentMailLog.AppendLine(",[HASHCODE] ");
                strInsertSentMailLog.AppendLine(",[BODY] , [EMAILADDRESS] ) ");
                strInsertSentMailLog.AppendLine("VALUES ");
                strInsertSentMailLog.AppendLine("(@ID ");
                strInsertSentMailLog.AppendLine(",GETDATE() ");
                strInsertSentMailLog.AppendLine(",@HASHKOD ");
                strInsertSentMailLog.AppendLine(",@BODY , @EMAILADDRESS ) ");




                foreach (DataRow currentRw in CurrentList.Rows)
                    {

                        sqlProvider.ClearParameter();
                        sqlProvider.addParameter("@TYPE_ID", aggrement_TYPE_ID);
                        sqlProvider.addParameter("@TAXTNUMBER", currentRw[0].ToString());
                        dtMailList = sqlProvider.dataTableReader(sqlStrAggrement, false);

                    Console.WriteLine(currentRw[0].ToString() + " " + dtMailList.Rows[0]["CURRENTEMAIL"].ToString());
                        string[] maillist = dtMailList.Rows[0]["CURRENTEMAIL"].ToString().Split(';');

                        foreach (string mail_address in maillist)
	                    {
                            if (mail_address.Length > 7 && mail_address.Contains('@'))
                            { 
                                
                                eMailSender.toMailAd = mail_address;
                                emailAdress = emailAdress + ";" + mail_address; 
                            }
	                    }

                        
                        eMailSender.mailBody = mailBody(aggrement_TYPE_ID, dtMailList.Select(), dtFirm.Rows[0]["FIRM_CODE"].ToString());
                        eMailSender.mailSuject = mailSubject(aggrement_TYPE_ID);

                        if  (mailWaitTime > 120)
                        { mailWaitTime = 120;}

                            Thread.Sleep(mailWaitTime * 1000 );
                            int emailStatus = eMailSender.sendMail();



                        foreach (DataRow rw in dtMailList.Rows)
                        {
                            sqlProvider.ClearParameter();
                            sqlProvider.addParameter("@ID", Convert.ToInt32(rw["ID"]));
                            sqlProvider.addParameter("@MAILED", emailStatus);
                            sqlProvider.nonQueryMethod(strUpdateMailedStatus, false);

                        if (emailStatus == 1)
                        {
                            sqlProvider.ClearParameter();
                            sqlProvider.addParameter("@ID", Convert.ToInt32(rw["ID"]));
                            sqlProvider.addParameter("@HASHKOD", strLink);
                            sqlProvider.addParameter("@BODY", eMailSender.mailBody);
                            sqlProvider.addParameter("@EMAILADDRESS", emailAdress);

                            sqlProvider.nonQueryMethod(strInsertSentMailLog.ToString(), false);

                            sqlProvider.ClearParameter();
                            sqlProvider.addParameter("@ID", Convert.ToInt32(rw["ID"]));
                            sqlProvider.nonQueryMethod("UPDATE [TBL_CURRENT_AGGREMENT] SET [MAIL_TRY_COUNT] = 0 WHERE ID= @ID", false);



                        }
                        else
                        {

                            logs(eMailSender.hata, "e-Mail gönder");

                        }

                        }





                    }
                #endregion

            }


            

        }

        protected void logs(string ex, string logYeri)
        {

            //@LOGTIPI,@LOGYERI,@LOGACIKLAMA
            sqlProvider.ClearParameter();
            sqlProvider.addParameter("@LOGTIPI", "HATA");
            sqlProvider.addParameter("@LOGYERI", logYeri);
            sqlProvider.addParameter("@LOGACIKLAMA", ex);
            sqlProvider.nonQueryMethod(_sqlStrInsertLog, false);

        }

    }
}
