using Application.Common.Models;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // TODO update user latest department data
            string appUsrId = notification.DomainEvent.ApplicationUserId;
            _ = await _mediator.Send(NewDeptHistory, cancellationToken);
        }
    }
}
