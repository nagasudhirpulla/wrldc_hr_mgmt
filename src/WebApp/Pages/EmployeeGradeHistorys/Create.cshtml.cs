using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Application.Grades.Queries.GetGrades;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Application.Users;
using Application.EmployeeGradeHistorys.Commands.CreateGradeHistory;

namespace WebApp.Pages.EmployeeGradeHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(string usrId)
        {
            if (usrId == null)
            {
                return NotFound();
            }
            await InitSelectListItems();
            NewGradeHistory = new()
            {
                ApplicationUserId = usrId,
                FromDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public CreateGradeHistoryCommand NewGradeHistory { get; set; }
        public SelectList GradeNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new CreateGradeHistoryCommandValidator().Validate(NewGradeHistory);
            validationCheck.AddToModelState(ModelState, nameof(NewGradeHistory));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errs = await _mediator.Send(NewGradeHistory);
            if (errs.Count == 0)
            {
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = NewGradeHistory.ApplicationUserId });
            }

            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }

        public async Task InitSelectListItems()
        {
            GradeNameSL = new SelectList(await _mediator.Send(new GetGradesQuery()), "Id", "Name");
        }
    }
}
