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

namespace Application.Users.Commands.UpdateUserLatestDesignation
{
    public class UpdateUserLatestDesignationCommandHandler : IRequestHandler<UpdateUserLatestDesignationCommand, List<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppDbContext _context;
        public UpdateUserLatestDesignationCommandHandler(UserManager<ApplicationUser> userManager, IAppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<string>> Handle(UpdateUserLatestDesignationCommand request, CancellationToken cancellationToken)
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

            // get the latest latest designation for the given application user
            EmployeeDesignationHistory usrLatestDesignationInfo = await _context.EmployeeDesignationHistorys
                        .Where(x => x.ApplicationUserId == request.ApplicationUserId)
                        .OrderByDescending(x => x.FromDate)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            int? latestDesignationId = null;

            if (usrLatestDesignationInfo != null)
            {
                latestDesignationId = usrLatestDesignationInfo.DesignationId;
            }

            if (user.DesignationId != latestDesignationId)
            {
                user.DesignationId = latestDesignationId;
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
