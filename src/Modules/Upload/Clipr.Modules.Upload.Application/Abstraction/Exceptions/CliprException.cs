
using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Application.Abstraction.Exceptions;

public sealed class CliprException : Exception
{
    public CliprException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
