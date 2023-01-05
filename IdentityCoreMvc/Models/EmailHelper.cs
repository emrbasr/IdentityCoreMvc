using System.Net.Mail;

namespace IdentityCoreMvc.Models
{
    public class EmailHelper
    {
        public async Task<bool> SendEmail(string email, string message)
        {



            #region Mail Mesaj Ayarlari

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("saravap672@dewareff.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "REGİSTER İSLEMİNİ ONAYLAYİN";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            #endregion


            #region SMTP Ayarlari

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.sendgrid.net";
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("saravap672@dewareff.com", "123456789987654321");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            #endregion


            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

                return false;
            }



            return true;
        }
    }
}
