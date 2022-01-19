using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Commands.CreateBossHistory
{
    public class CreateBossHistoryCommandValidator : AbstractValidator<CreateBossHistoryCommand>
    {
        public CreateBossHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
