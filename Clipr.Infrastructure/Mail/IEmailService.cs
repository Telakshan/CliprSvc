using Clipr.Infrastructure.Models;

namespace Clipr.Infrastructure.Mail;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);

}
