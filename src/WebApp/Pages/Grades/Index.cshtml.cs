using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Grades.Queries.GetGrades;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Grade> Grades { get; set; }
        public async Task OnGetAsync()
        {
            Grades = await _mediator.Send(new GetGradesQuery());
        }
    }
}
