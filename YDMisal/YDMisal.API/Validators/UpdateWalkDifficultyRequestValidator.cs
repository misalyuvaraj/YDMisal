using FluentValidation;
using YDMisal.API.Models.DTO;

namespace YDMisal.API.Validators
{
    public class UpdateWalkDifficultyRequestValidator : AbstractValidator<UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty or white space");
        }
    }
}
