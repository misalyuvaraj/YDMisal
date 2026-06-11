using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    // Validates the data sent when creating a new walk difficulty
    public class AddWalkDifficultyRequestValidator : AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            // Code must not be empty
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");
        }
    }
}
