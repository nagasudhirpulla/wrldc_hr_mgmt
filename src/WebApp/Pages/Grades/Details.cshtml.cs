using System.Threading.Tasks;
using Application.Grades.Queries.GetGradeById;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Grades
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Grade Grade { get; set; }
        public async Task OnGetAsync(int id)
        {
            Grade = await _mediator.Send(new GetGradeByIdQuery() { Id = id });
        }
    }
}
