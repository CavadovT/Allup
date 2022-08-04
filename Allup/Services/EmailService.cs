using Allup.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Allup.Services
{

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public bool SendEmail(List<string> emails, string subject, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_config.GetSection("MySettings:Mail").Value);

            


            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_config.GetSection("MySettings:Mail").Value, _config.GetSection("MySettings:Password").Value);

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                foreach (var email in emails)
                {
                    mail.To.Add(new MailAddress(email));

                }
                client.Send(mail);
               
            }
            catch (System.Exception)
            {


            }
            return false;
          
        }

    }
}
