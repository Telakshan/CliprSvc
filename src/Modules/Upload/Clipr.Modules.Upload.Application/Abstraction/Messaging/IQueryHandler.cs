using MediatR;
using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Application.Abstraction.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
