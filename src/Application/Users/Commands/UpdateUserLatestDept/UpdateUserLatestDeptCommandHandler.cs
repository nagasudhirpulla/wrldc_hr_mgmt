using Application.Common.Interfaces;
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

namespace Application.Users.Commands.UpdateUserLatestDept
{
    public class UpdateUserLatestDeptCommandHandler : IRequestHandler<UpdateUserLatestDeptCommand, List<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppDbContext _context;
        public UpdateUserLatestDeptCommandHandler(UserManager<ApplicationUser> userManager, IAppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<string>> Handle(UpdateUserLatestDeptCommand request, CancellationToken cancellationToken)
        {
            List<string> errors = new();
            if (request.ApplicationUserId == null)
            {
                errors.Add($"user id with null value is not accepted");
                return errors;
            }

            ApplicationUser user = await _userManager.FindByIdAsync(request.ApplicationUserId);
            if (user == null)
            {
                errors.Add($"Unable to find user with id {request.ApplicationUserId}");
                return errors;
            }

            // get the latest latest department for the given application user
            EmployeeDeptHistory usrLatestDeptInfo = await _context.EmployeeDeptHistorys
                        .Where(x => x.ApplicationUserId == request.ApplicationUserId)
                        .OrderByDescending(x => x.FromDate)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            int? latestDeptId = null;

            if (usrLatestDeptInfo != null)
            {
                latestDeptId = usrLatestDeptInfo.DepartmentId;
            }

            if (user.DepartmentId != latestDeptId)
            {
                user.DepartmentId = latestDeptId;
                IdentityResult res = await _userManager.UpdateAsync(user);
                if (!res.Succeeded)
                {
                    errors = res.Errors.Select(x => x.Description).ToList();
                }
            }

            return errors;
        }
    }
}
