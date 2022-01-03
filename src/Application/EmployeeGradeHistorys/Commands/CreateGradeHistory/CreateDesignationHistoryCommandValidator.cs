using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory
{
    public class CreateDesignationHistoryCommandValidator : AbstractValidator<CreateDesignationHistoryCommand>
    {
        public CreateDesignationHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
