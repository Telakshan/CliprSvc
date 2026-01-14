using MediatR;
using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
