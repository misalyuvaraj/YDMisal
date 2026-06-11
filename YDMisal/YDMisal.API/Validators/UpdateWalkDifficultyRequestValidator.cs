using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    // Validates the data sent when updating an existing walk difficulty
    public class UpdateWalkDifficultyRequestValidator : AbstractValidator<UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            // Code must not be empty
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");
        }
    }
}
