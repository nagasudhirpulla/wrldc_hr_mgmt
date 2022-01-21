using Core.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetEmployeeBossOptions
{
    public class GetEmployeeBossOptionsQuery : IRequest<List<ApplicationUser>>
    {
        public class GetEmployeeBossOptionsQueryHandler : IRequestHandler<GetEmployeeBossOptionsQuery, List<ApplicationUser>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            public List<ApplicationUser> empUsers = new();

            public GetEmployeeBossOptionsQueryHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<List<ApplicationUser>> Handle(GetEmployeeBossOptionsQuery request, CancellationToken cancellationToken)
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
                            empUsers.Add(user);
                        }
                    }
                }
                return empUsers;
            }
        }
    }
}
