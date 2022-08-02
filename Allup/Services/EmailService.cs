using Allup.Interfaces;
using Microsoft.Extensions.Configuration;
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

        public bool SendEmail(string email, string subject, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_config.GetSection("MailSettings:Mail").Value);

            mail.To.Add(new MailAddress(email));


            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_config.GetSection("MailSettings:Mail").Value, _config.GetSection("MailSettings:Password").Value);

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                return true;

            }
            catch (System.Exception)
            {


            }
            return false;
        }


    }
}
