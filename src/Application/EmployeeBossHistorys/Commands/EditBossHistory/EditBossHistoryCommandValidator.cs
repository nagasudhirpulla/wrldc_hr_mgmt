using FluentValidation;

namespace Application.EmployeeBossHistorys.Commands.EditBossHistory
{
    public class EditBossHistoryCommandValidator : AbstractValidator<EditBossHistoryCommand>
    {
        public EditBossHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();

            RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(r => r.FromDate)
                            .WithMessage("End date should be greater than or equal to Start date")
            .When(m => m.ToDate.HasValue);
        }
    }
}
