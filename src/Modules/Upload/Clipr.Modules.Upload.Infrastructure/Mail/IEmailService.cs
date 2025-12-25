using Clipr.Modules.Upload.Infrastructure.Models;

namespace Clipr.Modules.Upload.Infrastructure.Mail;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);

}
