using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Application.Designations.Queries.GetDesignations;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Application.Users;
using Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory;

namespace WebApp.Pages.EmployeeDesignationHistorys
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
            NewDesignationHistory = new()
            {
                ApplicationUserId = usrId,
                FromDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public CreateDesignationHistoryCommand NewDesignationHistory { get; set; }
        public SelectList DesignationNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new CreateDesignationHistoryCommandValidator().Validate(NewDesignationHistory);
            validationCheck.AddToModelState(ModelState, nameof(NewDesignationHistory));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errs = await _mediator.Send(NewDesignationHistory);
            if (errs.Count == 0)
            {
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = NewDesignationHistory.ApplicationUserId });
            }

            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }

        public async Task InitSelectListItems()
        {
            DesignationNameSL = new SelectList(await _mediator.Send(new GetDesignationsQuery()), "Id", "Name");
        }
    }
}
