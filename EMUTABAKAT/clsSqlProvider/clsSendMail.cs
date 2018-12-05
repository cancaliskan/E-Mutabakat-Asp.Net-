using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DorukProvider
{
   public class clsSendMail
    {

        private string _hata;

        public string hata
        {
            get { return _hata; }
            set { _hata = value; }
        }


        public bool ssl { get; set; }


        private string _mailSubject;
        public string mailSuject
        {
            get { return _mailSubject; }
            set { _mailSubject = value; }
        }

        private string _mailBody;
        public string mailBody
        {
            get { return _mailBody; }
            set { _mailBody = value; }
        }

        private string _mailServer;
        public string mailServer
        {
            get { return _mailServer; }
            set { _mailServer = value; }
        }

        private int _mailPort;
        public int mailPort
        {
            get
            {
                if (_mailPort == null || _mailPort == 0)
                { _mailPort = 587; }
                return _mailPort;
            }
            set { _mailPort = value; }
        }

        private string _fromMailAd;
        public string fromMail
        {
            get { return _fromMailAd; }
            set { _fromMailAd = value; }
        }

        private string _toMailAd;
        public string toMailAd
        {
            get { return _toMailAd; }
            set { _toMailAd = value; }
        }

        private string _fromMailText;
        public string fromMailText
        {
            get { return _fromMailText; }
            set { _fromMailText = value; }
        }


        private int _result;
        public int result
        {
            get { return _result; }
            set { _result = value; }
        }


        public string password { get; set; }




        public clsSendMail()
        {


        }

        public int sendMail()
        {
            try
            {

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new MailAddress(fromMail);
            mailMessage.To.Add(toMailAd);
            mailMessage.Subject = mailSuject;
            mailMessage.Body = mailBody;
            mailMessage.IsBodyHtml = true;
            SmtpClient mailSender = new SmtpClient(mailServer);
            mailSender.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailSender.UseDefaultCredentials = false;
            mailSender.Credentials = new System.Net.NetworkCredential(fromMail, password);
            mailSender.Port = mailPort;
            mailSender.EnableSsl = this.ssl;
           

           
                mailSender.Send(mailMessage);
                result = 1;
            }
            catch (Exception ex)
            {
                hata = ex.ToString();
                result = -1;

            }

            return result;

        }

      


    }
}
