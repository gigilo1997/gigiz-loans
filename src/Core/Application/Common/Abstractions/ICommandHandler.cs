using MediatR;
using Shared.Common;

namespace Application.Common.Abstractions;

internal interface ICommandHandler<TRequest> : IRequestHandler<TRequest, VoidResult>
    where TRequest : ICommand
{
}

internal interface ICommandHandler<TRequest, TResult> : IRequestHandler<TRequest, ValueResult<TResult>>
    where TRequest : ICommand<TResult>
{
}
