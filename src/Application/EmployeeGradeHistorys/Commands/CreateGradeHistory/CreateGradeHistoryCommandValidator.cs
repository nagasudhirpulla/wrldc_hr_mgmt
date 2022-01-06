using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.Commands.CreateGradeHistory
{
    public class CreateGradeHistoryCommandValidator : AbstractValidator<CreateGradeHistoryCommand>
    {
        public CreateGradeHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
