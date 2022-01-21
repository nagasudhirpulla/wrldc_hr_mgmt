using FluentValidation;

namespace Application.EmployeeBossHistorys.Commands.CreateBossHistory
{
    public class CreateBossHistoryCommandValidator : AbstractValidator<CreateBossHistoryCommand>
    {
        public CreateBossHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();

            RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(r => r.FromDate)
                            .WithMessage("End date should be greater than or equal to Start date")
            .When(m => m.ToDate.HasValue);
        }
    }
}
