using MediatR;
using Shared.Common;

namespace Application.Common.Abstractions;

internal interface ICommand : IRequest<VoidResult>
{
}

internal interface ICommand<TResult> : IRequest<ValueResult<TResult>>
{
}
