﻿using Application.Common.Interfaces;
using Core.Entities;
using Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Commands.DeleteDeptHistory
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
            EmployeeDeptHistory deptHistItem = await _context.EmployeeDeptHistorys.FindAsync(request.Id);

            if (deptHistItem == null)
            {
                string errorMsg = $"Employee Dept History Id {request.Id} not present for deleting";
                return new List<string>() { errorMsg };
            }

            _context.EmployeeDeptHistorys.Remove(deptHistItem);

            // attach event
            deptHistItem.DomainEvents.Add(new EmployeeDeptHistoryChangedEvent(deptHistItem.ApplicationUserId));
            // commit to database
            _ = await _context.SaveChangesAsync(cancellationToken);

            return new List<string>();
        }
    }
}
