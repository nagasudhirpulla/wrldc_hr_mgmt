using Core.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetEmployeeBoss
{
    public class GetEmployeeBossQuery : IRequest<List<ApplicationUser>>
    {
        public class GetEmployeeBossQueryHandler : IRequestHandler<GetEmployeeBossQuery, List<ApplicationUser>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            public List<ApplicationUser> empUser = new();

            public GetEmployeeBossQueryHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<List<ApplicationUser>> Handle(GetEmployeeBossQuery request, CancellationToken cancellationToken)
            {
                // get the list of users
                List<ApplicationUser> users = await _userManager.Users
                                                .Include(u => u.Designation)
                                                .Include(u => u.Department)
                                                .Include(u => u.Grade)
                                                .OrderBy(u => u.UserName)
                                                .ToListAsync(cancellationToken: cancellationToken);

                foreach (ApplicationUser user in users)
                {
                    string userRole = "";
                    IList<string> existingRoles = await _userManager.GetRolesAsync(user);
                    if (existingRoles.Count > 0)
                    {
                        userRole = existingRoles.ElementAt(0);
                        if (userRole == "Employee")
                        {
                            empUser.Add(user);
                        }
                    }
                }
                return empUser;
            }
        }
    }
}
