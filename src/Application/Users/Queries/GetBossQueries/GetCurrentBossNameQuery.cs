using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Users.Queries.GetAppUsers;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetBossQueries
{
    public class GetCurrentBossNameQuery
    {
        public string Id { get; set; }
        public class GetCurrentBossNameQueryHandler
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public GetCurrentBossNameQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
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
