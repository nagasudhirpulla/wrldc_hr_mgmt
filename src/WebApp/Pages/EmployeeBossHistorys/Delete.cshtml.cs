using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;
using MediatR;
using Application.EmployeeBossHistorys.Queries.GetEmpBossHistById;
using Application.EmployeeBossHistorys.Commands.DeleteBossHistory;
using Application.Users;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.EmployeeBossHistorys
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
        public EmployeeBossHistory EmployeeBossHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeBossHistory = await _mediator.Send(new GetEmpBossHistByIdQuery() { Id = id.Value });

            if (EmployeeBossHistory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //DeleteDeptHistoryCommand
            List<string> errs = await _mediator.Send(new DeleteBossHistoryCommand() { Id = EmployeeBossHistory.Id });
            if (errs.Count == 0)
            {
                return RedirectToPage("./Index", routeValues: new { usrId = EmployeeBossHistory.ApplicationUserId });
            }
            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }
    }
}
