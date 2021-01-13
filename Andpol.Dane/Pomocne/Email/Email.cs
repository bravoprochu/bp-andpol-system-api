using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Andpol.Dane.Pomocne
{
    public static class Email
    {
        public static void PowiadomAdmina(string message)
        {
            var p = new Pomocne.IdentityHelp();
            var administratorzy = p.GetUsersByRoleName("Admin");

            MailAddress mailFrom = new MailAddress("andpolsystem@gmail.com", "AndpolSystem");

            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.Body = "<h1>Info</h1><h3>" + message + "</h3>";
            msg.From = mailFrom;
            msg.Subject = "Andpol System INFO";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;

            foreach (var admin in administratorzy)
            {
                msg.To.Add(new MailAddress(admin.Nazwa));
            }

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("andpolsystem@gmail.com", "AndpolSystem1234!");


            try
            {
                client.Send(msg);
            }
            catch (Exception)
            {

                throw;
            }
            return;
        }
    }
}