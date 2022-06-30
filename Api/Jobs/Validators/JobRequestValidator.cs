using FluentValidation;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Validators;

public class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(j => j.Title).NotEmpty();
        RuleFor(j => j.Salary).GreaterThan(0);
        RuleFor(j => j.Requirements).NotEmpty();
    }
}