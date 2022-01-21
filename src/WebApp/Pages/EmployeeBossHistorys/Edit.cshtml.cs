using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Application.EmployeeBossHistorys.Commands.EditBossHistory;
using Application.EmployeeBossHistorys.Queries.GetEmpBossHistById;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using WebApp.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Application.Users;
using Application.Users.Queries.GetEmployeeBoss;

namespace WebApp.Pages.EmployeeBossHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator, IMapper mapper, ILogger<EditModel> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [BindProperty]
        public EditBossHistoryCommand EmpBossHistItem { get; set; }
        public SelectList ReportingOfficerNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await InitSelectListItems();
            EmpBossHistItem = _mapper.Map<EditBossHistoryCommand>(await _mediator.Send(new GetEmpBossHistByIdQuery() { Id = id.Value }));

            if (EmpBossHistItem == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new EditBossHistoryCommandValidator().Validate(EmpBossHistItem);
            validationCheck.AddToModelState(ModelState, nameof(EmpBossHistItem));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errors = await _mediator.Send(EmpBossHistItem);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("User Boss History edit operation successful");
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = EmpBossHistItem.ApplicationUserId })
                            .WithSuccess("User Boss History editing done");
            }

            return Page();
        }

        public async Task InitSelectListItems()
        {
            ReportingOfficerNameSL = new SelectList(await _mediator.Send(new GetEmployeeBossQuery()), "Id", "DisplayName");
        }
    }
}
