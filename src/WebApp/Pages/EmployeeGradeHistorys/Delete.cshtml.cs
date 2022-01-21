using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;
using MediatR;
using Application.EmployeeGradeHistorys.Queries.GetEmpGradeHistById;
using Application.EmployeeGradeHistorys.Commands.DeleteGradeHistory;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Application.Common.Interfaces;

namespace WebApp.Pages.EmployeeGradeHistorys
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
        public EmployeeGradeHistory EmployeeGradeHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeGradeHistory = await _mediator.Send(new GetEmpGradeHistByIdQuery() { Id = id.Value });

            if (EmployeeGradeHistory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            List<string> errs = await _mediator.Send(new DeleteGradeHistoryCommand() { Id = EmployeeGradeHistory.Id });
            if (errs.Count == 0)
            {
                return RedirectToPage("./Index", routeValues: new { usrId = EmployeeGradeHistory.ApplicationUserId });
            }
            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }
    }
}
