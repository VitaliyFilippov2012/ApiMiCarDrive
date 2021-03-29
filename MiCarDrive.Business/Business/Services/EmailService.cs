using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business.Services
{
    public class EmailService : IEmailService
    {
        private const string _emailFrom = "iDonateBelarus@yandex.ru";

        public async Task SendEmailMessageAsync(string message, string emailTo)
        {
            var from = new MailAddress(_emailFrom, "Support FinanceCarManager");
            var to = new MailAddress(emailTo);
            var m = new MailMessage(from, to)
            {
                Subject = "Heeeyyy my friend",
                Body = message
            };
            var smtp = new SmtpClient("smtp.yandex.ru", 587)
            {
                Credentials = new NetworkCredential(_emailFrom, "igiveapieceofheart"),
                EnableSsl = true
            };
            var sending = true;
            while (sending)
            {
                try
                {
                    await smtp.SendMailAsync(m);
                    sending = false;
                }
                catch
                {
                    Thread.Sleep(1000);
                    sending = true;
                }

            }
        }
    }
}
