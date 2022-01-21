using FluentValidation;

namespace Application.EmployeeBossHistorys.Commands.EditBossHistory
{
    public class EditBossHistoryCommandValidator : AbstractValidator<EditBossHistoryCommand>
    {
        public EditBossHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
