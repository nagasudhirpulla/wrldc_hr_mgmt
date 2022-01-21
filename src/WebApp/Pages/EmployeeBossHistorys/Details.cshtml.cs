using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;
using MediatR;
using Application.EmployeeBossHistorys.Queries.GetEmpBossHistById;
using Application.Users.Queries.IsUsrSelfOrAdmin;

namespace WebApp.Pages.EmployeeBossHistorys
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public EmployeeBossHistory EmpBossHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpBossHistory = await _mediator.Send(new GetEmpBossHistByIdQuery() { Id = id.Value });

            if (EmpBossHistory == null)
            {
                return NotFound();
            }

            // show details only for self or admin
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = EmpBossHistory.ApplicationUserId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }

            return Page();
        }
    }
}
