﻿using Application.Common.Models;
using Application.Users.Commands.UpdateUserLatestDept;
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
    public class EmployeeDesignationHistoryChangedEventHandler : INotificationHandler<DomainEventNotification<EmployeeDeptHistoryChangedEvent>>
    {
        private readonly ILogger<EmployeeDesignationHistoryChangedEventHandler> _logger;
        private readonly IMediator _mediator;

        public EmployeeDesignationHistoryChangedEventHandler(ILogger<EmployeeDesignationHistoryChangedEventHandler> logger, IMediator mediator)
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
