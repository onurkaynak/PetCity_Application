using FluentValidation;

public class IncidenceDTOValidator : AbstractValidator<IncidenceDTO>
{
    public IncidenceDTOValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(5);
        RuleFor(x => x.Date).NotNull().LessThanOrEqualTo(DateTime.Today);
    }
}