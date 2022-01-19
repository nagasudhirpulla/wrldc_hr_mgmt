using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetBossQueries
{
    public class GetEmployeeBossQuery : IRequest<List<ApplicationUser>>
    {
        public class GetEmployeeBossQueryHandler : IRequestHandler<GetEmployeeBossQuery, List<ApplicationUser>>
        {
            private readonly IdentityInit _identityInit;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IAppDbContext _context;
            public List<ApplicationUser> empUser = new List<ApplicationUser>();

            public GetEmployeeBossQueryHandler(IAppDbContext context, UserManager<ApplicationUser> userManager, IdentityInit identityInit)
            {
                _identityInit = identityInit;
                _userManager = userManager;
                _context = context;
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
                    //}
                }
                return empUser;
            }
        }
    }
}
