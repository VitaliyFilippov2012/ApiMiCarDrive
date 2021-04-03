using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business.Services
{
    public class EmailService : IEmailService
    {
        private const string _emailFrom = "MiCarDrive2021@yandex.by";
        private const string _emailPassword = "MiCarDrive";
        private const string _phone= "+375 (29) 895-46-35";


        public async Task SendEmailMessageAsync(string message, string emailTo)
        {
            var from = new MailAddress(_emailFrom, "Support FinanceCarManager");
            var to = new MailAddress(emailTo);
            var m = new MailMessage(from, to)
            {
                Subject = "Heeeyyy my friend",
                Body = $"Здравствуйте!<br>{message}<br> При возникновении вопросов обращайтесь на почту <h2><a href={_emailFrom}>{_emailFrom}</a></h2> или обратитесь в поддержку по телефону <h2>{_phone}</h2>.<br> До скорого!<br> Magnificent",
            };
            m.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.yandex.by", 587)
            {
                Credentials = new NetworkCredential(_emailFrom, _emailPassword),
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
