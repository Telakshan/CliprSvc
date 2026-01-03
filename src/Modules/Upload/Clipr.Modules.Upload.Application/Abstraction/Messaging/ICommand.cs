using Clipr.Modules.Upload.Domain.Abstractions;
using MediatR;

namespace Clipr.Modules.Upload.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
