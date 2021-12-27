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

namespace Application.EmployeeDesignationHistorys.Commands.EditDesignationHistory
{
    public class EditDesignationHistoryCommandHandler : IRequestHandler<EditDesignationHistoryCommand, List<string>>
    {
        private readonly ILogger<EditDesignationHistoryCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditDesignationHistoryCommandHandler(ILogger<EditDesignationHistoryCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditDesignationHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeDesignationHistory designationHistItem = await _context.EmployeeDesignationHistorys
                                                .Where(deptHist => deptHist.Id == request.Id)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (designationHistItem == null)
            {
                string errorMsg = $"Employee Designation History Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }

            // check if editing is required
            bool isEditRequired = false;
            if (designationHistItem.DesignationId != request.DesignationId || designationHistItem.FromDate != request.FromDate)
            {
                isEditRequired = true;
            }
            if (isEditRequired)
            {
                designationHistItem.FromDate = request.FromDate;
                designationHistItem.DesignationId = request.DesignationId;

                try
                {
                    // attach event
                    designationHistItem.DomainEvents.Add(new EmployeeDesignationHistoryChangedEvent(designationHistItem.ApplicationUserId));
                    // commit to database
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EmployeeDesignationHistorys.Any(e => e.Id == request.Id))
                    {
                        return new List<string>() { $"Employee Designation History Id {request.Id} not present for editing" };
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
