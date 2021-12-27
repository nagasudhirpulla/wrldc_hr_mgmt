using Application.Common.Interfaces;
using Core.Entities;
using Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDesignationHistorys.Commands.DeleteDesignationHistory
{
    public class DeleteDesignationHistoryCommandHandler : IRequestHandler<DeleteDesignationHistoryCommand, List<string>>
    {
        private readonly IAppDbContext _context;

        public DeleteDesignationHistoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(DeleteDesignationHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeDesignationHistory employeeHistItem = await _context.EmployeeDesignationHistorys.FindAsync(request.Id);

            if (employeeHistItem == null)
            {
                string errorMsg = $"Employee Designation History Id {request.Id} not present for deleting";
                return new List<string>() { errorMsg };
            }

            _context.EmployeeDesignationHistorys.Remove(employeeHistItem);

            // attach event
            employeeHistItem.DomainEvents.Add(new EmployeeDeptHistoryChangedEvent(employeeHistItem.ApplicationUserId));
            // commit to database
            _ = await _context.SaveChangesAsync(cancellationToken);

            return new List<string>();
        }
    }
}
