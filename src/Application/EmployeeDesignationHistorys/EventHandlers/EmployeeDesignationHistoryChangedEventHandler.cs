using Application.Common.Models;
using Application.Users.Commands.UpdateUserLatestDesignation;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDesignationHistorys.EventHandlers
{
    public class EmployeeDesignationHistoryChangedEventHandler : INotificationHandler<DomainEventNotification<EmployeeDesignationHistoryChangedEvent>>
    {
        private readonly ILogger<EmployeeDesignationHistoryChangedEventHandler> _logger;
        private readonly IMediator _mediator;

        public EmployeeDesignationHistoryChangedEventHandler(ILogger<EmployeeDesignationHistoryChangedEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<EmployeeDesignationHistoryChangedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            // update user's latest department data
            _ = await _mediator.Send(new UpdateUserLatestDesignationCommand() { ApplicationUserId = domainEvent.ApplicationUserId }, cancellationToken);
        }
    }
}
