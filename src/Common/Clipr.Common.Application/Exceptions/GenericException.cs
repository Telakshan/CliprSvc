using Clipr.Common.Domain.Abstractions;

namespace Clipr.Common.Application.Exceptions;

public class GenericException: Exception
{
    public GenericException(string requestName, Error error, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public  Error Error { get; }
}
