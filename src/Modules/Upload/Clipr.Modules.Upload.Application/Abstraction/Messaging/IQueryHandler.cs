using Clipr.Modules.Upload.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clipr.Modules.Upload.Application.Abstraction.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;