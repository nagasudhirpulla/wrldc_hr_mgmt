using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;
using MediatR;
using Application.EmployeeDesignationHistorys.Queries.GetEmpDesignationHistById;
using Application.Users.Queries.IsUsrSelfOrAdmin;

namespace WebApp.Pages.EmployeeDesignationHistorys
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public EmployeeDesignationHistory EmpDesignationHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpDesignationHistory = await _mediator.Send(new GetEmpDesignationHistByIdQuery() { Id = id.Value });

            if (EmpDesignationHistory == null)
            {
                return NotFound();
            }

            // show details only for self or admin
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = EmpDesignationHistory.ApplicationUserId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }

            return Page();
        }
    }
}
