using FluentValidation;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Validators;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Firstname must not be empty")
            .MaximumLength(50)
            .WithMessage("Length must be less than 50");


        RuleFor(x => x.LastName)
            .MaximumLength(50);
    }
}
