using FluentValidation;

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
