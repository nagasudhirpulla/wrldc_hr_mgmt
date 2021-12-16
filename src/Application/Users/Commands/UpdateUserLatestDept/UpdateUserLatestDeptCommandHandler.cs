using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUserLatestDept
{
    public class UpdateUserLatestDeptCommandHandler : IRequestHandler<UpdateUserLatestDeptCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UpdateUserLatestDeptCommandHandler> _logger;
        public UpdateUserLatestDeptCommandHandler(UserManager<ApplicationUser> userManager, ILogger<UpdateUserLatestDeptCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IdentityResult> Handle(UpdateUserLatestDeptCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
