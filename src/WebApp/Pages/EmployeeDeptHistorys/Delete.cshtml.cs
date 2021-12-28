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
using Application.EmployeeDeptHistorys.Queries.GetEmpDeptHistById;
using Application.EmployeeDeptHistorys.Commands.DeleteDeptHistory;
using Application.Users;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;

        public DeleteModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public EmployeeDeptHistory EmployeeDeptHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeDeptHistory = await _mediator.Send(new GetEmpDeptHistByIdQuery() { Id = id.Value });

            if (EmployeeDeptHistory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //DeleteDeptHistoryCommand
            List<string> errs = await _mediator.Send(new DeleteDeptHistoryCommand() { Id = EmployeeDeptHistory.Id });
            if (errs.Count == 0)
            {
                return RedirectToPage("./Index", routeValues: new { usrId = EmployeeDeptHistory.ApplicationUserId });
            }
            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }
    }
}
