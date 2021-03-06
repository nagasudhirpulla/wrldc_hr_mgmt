using Application.Common.Models;
using Application.EmployeeDeptHistorys.Commands.CreateDeptHistory;
using Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory;
using Application.EmployeeGradeHistorys.Commands.CreateGradeHistory;
using Application.EmployeeBossHistorys.Commands.CreateBossHistory;
using Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.EventHandlers
{
    public class ApplicationUserCreatedEventHandler : INotificationHandler<DomainEventNotification<ApplicationUserCreatedEvent>>
    {
        private readonly ILogger<ApplicationUserCreatedEventHandler> _logger;
        private readonly IMediator _mediator;

        public ApplicationUserCreatedEventHandler(ILogger<ApplicationUserCreatedEventHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<ApplicationUserCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            // create department history for the user
            if (notification.DomainEvent.AppUser.DepartmentId.HasValue)
            {
                CreateDeptHistoryCommand NewDeptHistory = new()
                {
                    ApplicationUserId = notification.DomainEvent.AppUser.Id,
                    DepartmentId = notification.DomainEvent.AppUser.DepartmentId.Value,
                    FromDate = notification.DomainEvent.AppUser.DateofJoining
                };
                _ = await _mediator.Send(NewDeptHistory, cancellationToken);
            }
            // create Designation history for the user
            if (notification.DomainEvent.AppUser.DesignationId.HasValue)
            {
                CreateDesignationHistoryCommand NewDesignationHistory = new()
                {
                    ApplicationUserId = notification.DomainEvent.AppUser.Id,
                    DesignationId = notification.DomainEvent.AppUser.DesignationId.Value,
                    FromDate = notification.DomainEvent.AppUser.DateofJoining
                };
                _ = await _mediator.Send(NewDesignationHistory, cancellationToken);
            }
            // create Grade history for the user
            if (notification.DomainEvent.AppUser.GradeId.HasValue)
            {
                CreateGradeHistoryCommand NewGradeHistory = new()
                {
                    ApplicationUserId = notification.DomainEvent.AppUser.Id,
                    GradeId = notification.DomainEvent.AppUser.GradeId.Value,
                    FromDate = notification.DomainEvent.AppUser.DateofJoining
                };
                _ = await _mediator.Send(NewGradeHistory, cancellationToken);
            }
            // create Boss history for the user
            if (notification.DomainEvent.AppUser.BossUserId != null)
            {
                CreateBossHistoryCommand NewBossHistory = new()
                {
                    ApplicationUserId = notification.DomainEvent.AppUser.Id,
                    BossUserId = notification.DomainEvent.AppUser.BossUserId,
                    FromDate = notification.DomainEvent.AppUser.DateofJoining,
                    ToDate = notification.DomainEvent.AppUser.DateofJoining
                };
                _ = await _mediator.Send(NewBossHistory, cancellationToken);
            }
        }
    }
}
