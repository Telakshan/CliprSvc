using Clipr.Common.Domain.Abstractions;
using MediatR;

namespace Clipr.Modules.Upload.Application.Abstraction.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
