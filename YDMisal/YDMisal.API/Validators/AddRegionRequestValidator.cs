using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    // Validates the data sent when creating a new region
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            // Code must not be empty
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            // Name must not be empty
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            // Area must be a positive number
            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");

            // Latitude must be between -90 and 90 degrees
            RuleFor(x => x.Lat)
                .InclusiveBetween(-90, 90).WithMessage("{PropertyName} must be between -90 and 90");

            // Longitude must be between -180 and 180 degrees
            RuleFor(x => x.Long)
                .InclusiveBetween(-180, 180).WithMessage("{PropertyName} must be between -180 and 180");

            // Population must be a positive number
            RuleFor(x => x.Population)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");
        }
    }
}
