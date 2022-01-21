using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Grades.Commands.CreateGrade;
using Application.Users;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp.Extensions;

namespace WebApp.Pages.Grades
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IMediator _mediator;
        public CreateModel(IMediator mediator, ILogger<CreateModel> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [BindProperty]
        public CreateGradeCommand NewGrade { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidationResult validationCheck = new CreateGradeCommandValidator().Validate(NewGrade);
            validationCheck.AddToModelState(ModelState, nameof(NewGrade));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errs = await _mediator.Send(NewGrade);
            if (errs.Count == 0)
            {
                _logger.LogInformation($"Created new Grade {NewGrade.Name}");
                return RedirectToPage($"./{nameof(Index)}").WithSuccess($"Created new Grade {NewGrade.Name}");
            }
            foreach (var error in errs)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return Page();
        }

    }
}
