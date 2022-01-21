using Application.Common.Interfaces;
using Core.Entities;
using Core.Events;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.Commands.DeleteGradeHistory
{
    public class DeleteGradeHistoryCommandHandler : IRequestHandler<DeleteGradeHistoryCommand, List<string>>
    {
        private readonly IAppDbContext _context;

        public DeleteGradeHistoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(DeleteGradeHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeGradeHistory employeeHistItem = await _context.EmployeeGradeHistorys.FindAsync(request.Id);

            if (employeeHistItem == null)
            {
                string errorMsg = $"Employee Grade History Id {request.Id} not present for deleting";
                return new List<string>() { errorMsg };
            }

            _context.EmployeeGradeHistorys.Remove(employeeHistItem);

            // attach event
            employeeHistItem.DomainEvents.Add(new EmployeeGradeHistoryChangedEvent(employeeHistItem.ApplicationUserId));
            // commit to database
            _ = await _context.SaveChangesAsync(cancellationToken);

            return new List<string>();
        }
    }
}
