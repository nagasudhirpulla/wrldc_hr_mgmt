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

namespace Application.EmployeeGradeHistorys.Commands.EditGradeHistory
{
    public class EditGradeHistoryCommandHandler : IRequestHandler<EditGradeHistoryCommand, List<string>>
    {
        private readonly ILogger<EditGradeHistoryCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditGradeHistoryCommandHandler(ILogger<EditGradeHistoryCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditGradeHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeGradeHistory gradeHistItem = await _context.EmployeeGradeHistorys
                                                .Where(deptHist => deptHist.Id == request.Id)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (gradeHistItem == null)
            {
                string errorMsg = $"Employee Grade History Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }

            // check if editing is required
            bool isEditRequired = false;
            if (gradeHistItem.GradeId != request.GradeId || gradeHistItem.FromDate != request.FromDate)
            {
                isEditRequired = true;
            }
            if (isEditRequired)
            {
                gradeHistItem.FromDate = request.FromDate;
                gradeHistItem.GradeId = request.GradeId;

                try
                {
                    // attach event
                    gradeHistItem.DomainEvents.Add(new EmployeeGradeHistoryChangedEvent(gradeHistItem.ApplicationUserId));
                    // commit to database
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EmployeeGradeHistorys.Any(e => e.Id == request.Id))
                    {
                        return new List<string>() { $"Employee Grade History Id {request.Id} not present for editing" };
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
