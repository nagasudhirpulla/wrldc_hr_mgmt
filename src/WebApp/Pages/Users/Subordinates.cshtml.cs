using Application.Common.Interfaces;
using Application.EmployeeBossHistorys.Queries.GetSubordinatesForEmp;
using Application.Users.Queries.GetAppUsers;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.IsUsrSelfOrAdmin;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Pages.Users
{
    public class SubordinatesModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public SubordinatesModel(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }
        public List<EmployeeBossHistory> Subordinates { get; set; }
        public string RequestId { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            RequestId = id;

            // check if user is authorized
            string curUsrId = _currentUserService.UserId;
            // show details only for self or admin
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = id ?? curUsrId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }

            Subordinates = await _mediator.Send(new GetSubordinatesForEmpQuery() { ApplicationUserId = id ?? curUsrId });
            if (Subordinates == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
