using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
