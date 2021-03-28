using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailMessageAsync(string message, string emailTo, string emailFrom = "iDonateBelarus@yandex.ru");
    }
}
