using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetCurrentBossName
{
    public class GetCurrentBossNameQuery
    {
        public string Id { get; set; }
        public class GetCurrentBossNameQueryHandler
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public GetCurrentBossNameQueryHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<string> Handle(GetCurrentBossNameQuery request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                {
                    return null;
                }
                ApplicationUser user = await _userManager.Users
                                        .Include(x => x.Department)
                                        .Include(x => x.Designation)
                                        .Include(x => x.Grade)
                                        .Include(x => x.BossUser)
                                        .SingleAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                if (user == null)
                {
                    return null;
                }

                string ReportingOfficer = user.DisplayName;
                return ReportingOfficer;
            }
        }
    }
}
