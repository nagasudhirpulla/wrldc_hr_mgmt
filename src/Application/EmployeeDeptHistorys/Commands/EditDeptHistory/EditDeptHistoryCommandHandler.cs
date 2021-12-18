using Application.Common;
using Application.Common.Interfaces;
using Application.Users;
using AutoMapper;
using Core.Entities;
using Core.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Commands.EditDeptHistory
{
    public class EditDeptHistoryCommandHandler : IRequestHandler<EditDeptHistoryCommand, List<string>>
    {
        private readonly ILogger<EditDeptHistoryCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditDeptHistoryCommandHandler(ILogger<EditDeptHistoryCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditDeptHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeDeptHistory deptHistItem = await _context.EmployeeDeptHistorys
                                                .Where(deptHist => deptHist.Id == request.Id)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (deptHistItem == null)
            {
                string errorMsg = $"Employee Dept History Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }

            // check if editing is required
            bool isEditRequired = false;
            if (deptHistItem.DepartmentId != request.DepartmentId || deptHistItem.FromDate != request.FromDate)
            {
                isEditRequired = true;
            }
            if (isEditRequired)
            {
                deptHistItem.FromDate = request.FromDate;
                deptHistItem.DepartmentId = request.DepartmentId;

                try
                {
                    // attach event
                    deptHistItem.DomainEvents.Add(new EmployeeDeptHistoryChangedEvent(deptHistItem.ApplicationUserId));
                    // commit to database
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EmployeeDeptHistorys.Any(e => e.Id == request.Id))
                    {
                        return new List<string>() { $"Employee Dept History Id {request.Id} not present for editing" };
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return new List<string>();
        }
    }
}
