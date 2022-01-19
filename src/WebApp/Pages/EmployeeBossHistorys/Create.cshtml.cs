using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;
using Application.EmployeeBossHistorys.Commands.CreateBossHistory;
using MediatR;
using Application.Users.Queries.GetBossQueries;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Application.Users;

namespace WebApp.Pages.EmployeeBossHistorys
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
            NewBossHistory = new()
            {
                ApplicationUserId = usrId,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public CreateBossHistoryCommand NewBossHistory { get; set; }
        public SelectList ReportingOfficerNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new CreateBossHistoryCommandValidator().Validate(NewBossHistory);
            validationCheck.AddToModelState(ModelState, nameof(NewBossHistory));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errs = await _mediator.Send(NewBossHistory);
            if (errs.Count == 0)
            {
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = NewBossHistory.ApplicationUserId });
            }

            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }

        public async Task InitSelectListItems()
        {
            ReportingOfficerNameSL = new SelectList(await _mediator.Send(new GetEmployeeBossQuery()), "Id", "DisplayName");
        }
    }
}
