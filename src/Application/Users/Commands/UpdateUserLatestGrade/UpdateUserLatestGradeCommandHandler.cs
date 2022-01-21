using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUserLatestGrade
{
    public class UpdateUserLatestGradeCommandHandler : IRequestHandler<UpdateUserLatestGradeCommand, List<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppDbContext _context;
        public UpdateUserLatestGradeCommandHandler(UserManager<ApplicationUser> userManager, IAppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<string>> Handle(UpdateUserLatestGradeCommand request, CancellationToken cancellationToken)
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

            // get the latest latest grade for the given application user
            EmployeeGradeHistory usrLatestGradeInfo = await _context.EmployeeGradeHistorys
                        .Where(x => x.ApplicationUserId == request.ApplicationUserId)
                        .OrderByDescending(x => x.FromDate)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            int? latestGradeId = null;

            if (usrLatestGradeInfo != null)
            {
                latestGradeId = usrLatestGradeInfo.GradeId;
            }

            if (user.GradeId != latestGradeId)
            {
                user.GradeId = latestGradeId;
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
