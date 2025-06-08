using Clipr.Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace Clipr.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private readonly IOptions<EmailSettings> _options;
    public EmailService(IOptions<EmailSettings> options)
    {
        _options = options;
    }
    public Task<bool> SendEmail(Email email)
    {
        throw new NotImplementedException();
    }
}
