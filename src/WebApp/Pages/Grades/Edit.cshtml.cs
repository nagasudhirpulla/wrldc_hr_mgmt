using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Grades.Commands.EditGrade;
using Application.Grades.Queries.GetGradeById;
using Application.Users;
using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Extensions;

namespace WebApp.Pages.Grades
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class EditModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public EditGradeCommand EditGrade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Grade grd = await _mediator.Send(new GetGradeByIdQuery() { Id = id.Value });
            if (grd == null)
            {
                return NotFound();
            }

            EditGrade = _mapper.Map<EditGradeCommand>(grd);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            List<string> errs = await _mediator.Send(EditGrade);

            foreach (var error in errs)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            if (errs.Count == 0)
            {
                return RedirectToPage($"./{nameof(Index)}").WithSuccess("Grade Editing done");
            }

            return Page();
        }

    }
}
