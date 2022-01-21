using FluentValidation;

namespace Application.EmployeeDeptHistorys.Commands.CreateDeptHistory
{
    public class CreateDeptHistoryCommandValidator : AbstractValidator<CreateDeptHistoryCommand>
    {
        public CreateDeptHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
