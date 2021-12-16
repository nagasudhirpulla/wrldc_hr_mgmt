using Application.Common;
using Application.Common.Interfaces;
using Application.Users;
using AutoMapper;
using Core.Entities;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public EditDeptHistoryCommandHandler(ILogger<EditDeptHistoryCommandHandler> logger, IAppDbContext context, ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        public async Task<List<string>> Handle(EditDeptHistoryCommand request, CancellationToken cancellationToken)
        {
            string curUsrId = _currentUserService.UserId;
            ApplicationUser curUsr = await _userManager.FindByIdAsync(curUsrId);
            if (curUsr == null)
            {
                var errorMsg = "User not found for editing proposal";
                _logger.LogError(errorMsg);
                return new List<string>() { errorMsg };
            }

            // fetch the notesheet for editing
            var employeeDeptHistory = await _context.EmployeeDeptHistorys.Where(deptHist => deptHist.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (employeeDeptHistory == null)
            {
                string errorMsg = $"Employee Dept History Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }

            // check if user is authorized for editing proposal
            IList<string> usrRoles = await _userManager.GetRolesAsync(curUsr);
            if (curUsr.UserName != employeeDeptHistory.CreatedBy && !usrRoles.Contains(SecurityConstants.AdminRoleString))
            {
                return new List<string>() { "This user is not authorized for updating this proposal since this is not his created by this user and he is not in admin role" };
            }

            if (employeeDeptHistory.FromDate != request.FromDate) //new field
            {
                employeeDeptHistory.FromDate = request.FromDate;
            }
            if (employeeDeptHistory.DepartmentId != request.DepartmentId)
            {
                employeeDeptHistory.DepartmentId = request.DepartmentId;
            }
            

            try
            {
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

            return new List<string>();

        }
    }
}
