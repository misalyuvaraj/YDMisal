using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    // Validates the data sent when creating a new walk
    public class AddWalkRequestValidator : AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            // Walk name must not be empty
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            // Length must be greater than 0
            RuleFor(x => x.Lenght)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");

            // A region ID must be provided
            RuleFor(x => x.RegionId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            // A difficulty level ID must be provided
            RuleFor(x => x.WalkDifficultyId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
