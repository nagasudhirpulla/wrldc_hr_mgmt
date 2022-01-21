using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Grades.Commands.DeleteGrade;
using Application.Grades.Queries.GetGradeById;
using Application.Users;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Grades
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
        public Grade ExistingGrade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExistingGrade = await _mediator.Send(new GetGradeByIdQuery() { Id = id.Value });

            if (ExistingGrade == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<string> errs = await _mediator.Send(new DeleteGradeCommand() { Id = id.Value });

            if (errs.Count == 0)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                foreach (var error in errs)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }
        }
    }
}
