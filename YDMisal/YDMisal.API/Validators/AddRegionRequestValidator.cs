using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");

            RuleFor(x => x.Lat)
                .InclusiveBetween(-90, 90).WithMessage("{PropertyName} must be between -90 and 90");

            RuleFor(x => x.Long)
                .InclusiveBetween(-180, 180).WithMessage("{PropertyName} must be between -180 and 180");

            RuleFor(x => x.Population)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than or equal to zero");
        }
    }
}
