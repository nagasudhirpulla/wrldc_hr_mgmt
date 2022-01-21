using Application.Common.Models;
using Application.Users.Commands.UpdateUserLatestGrade;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.EventHandlers
{
    public class EmployeeGradeHistoryChangedEventHandler : INotificationHandler<DomainEventNotification<EmployeeGradeHistoryChangedEvent>>
    {
        private readonly ILogger<EmployeeGradeHistoryChangedEventHandler> _logger;
        private readonly IMediator _mediator;

        public EmployeeGradeHistoryChangedEventHandler(ILogger<EmployeeGradeHistoryChangedEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<EmployeeGradeHistoryChangedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            // update user's latest grade data
            _ = await _mediator.Send(new UpdateUserLatestGradeCommand() { ApplicationUserId = domainEvent.ApplicationUserId }, cancellationToken);
        }
    }
}
