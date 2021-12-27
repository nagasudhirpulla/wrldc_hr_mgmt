using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;
using MediatR;
using Application.EmployeeDesignationHistorys.Queries.GetEmpDesignationHistById;
using Application.EmployeeDesignationHistorys.Commands.DeleteDesignationHistory;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using WebApp.Extensions;
using Application.Common;
using Application.Users.Queries.GetAppUsers;
using Application.Users.Queries.GetUserById;

namespace WebApp.Pages.EmployeeDesignationHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public DeleteModel(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [BindProperty]
        public EmployeeDesignationHistory EmployeeDesignationHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeDesignationHistory = await _mediator.Send(new GetEmpDesignationHistByIdQuery() { Id = id.Value });

            if (EmployeeDesignationHistory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //DeleteDeptHistoryCommand
            List<string> errs = await _mediator.Send(new DeleteDesignationHistoryCommand() { Id = EmployeeDesignationHistory.Id });
            if (errs.Count == 0)
            {
                return RedirectToPage("./Index", routeValues: new { usrId = EmployeeDesignationHistory.ApplicationUserId });
            }
            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }
    }
}
