using Application.Common.Models;
using Application.Users.Commands.UpdateUserLatestBoss;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.EventHandlers
{
    public class EmployeeBossHistoryChangedEventHandler : INotificationHandler<DomainEventNotification<EmployeeBossHistoryChangedEvent>>
    {
        private readonly ILogger<EmployeeBossHistoryChangedEventHandler> _logger;
        private readonly IMediator _mediator;

        public EmployeeBossHistoryChangedEventHandler(ILogger<EmployeeBossHistoryChangedEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<EmployeeBossHistoryChangedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            // update user's latest Boss data
            _ = await _mediator.Send(new UpdateUserLatestBossCommand() { ApplicationUserId = domainEvent.ApplicationUserId }, cancellationToken);
        }
    }
}
