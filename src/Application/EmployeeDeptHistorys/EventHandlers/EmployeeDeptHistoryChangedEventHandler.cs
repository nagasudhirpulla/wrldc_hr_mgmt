using Application.Common.Models;
using Application.Users.Commands.UpdateUserLatestDept;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.EventHandlers
{
    public class EmployeeDeptHistoryChangedEventHandler : INotificationHandler<DomainEventNotification<EmployeeDeptHistoryChangedEvent>>
    {
        private readonly ILogger<EmployeeDeptHistoryChangedEventHandler> _logger;
        private readonly IMediator _mediator;

        public EmployeeDeptHistoryChangedEventHandler(ILogger<EmployeeDeptHistoryChangedEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<EmployeeDeptHistoryChangedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            // update user's latest department data
            _ = await _mediator.Send(new UpdateUserLatestDeptCommand() { ApplicationUserId = domainEvent.ApplicationUserId }, cancellationToken);
        }
    }
}
