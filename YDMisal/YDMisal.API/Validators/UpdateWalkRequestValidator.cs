using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    public class UpdateWalkRequestValidator : AbstractValidator<UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            RuleFor(x => x.Lenght)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");

            RuleFor(x => x.RegionId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.WalkDifficultyId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
