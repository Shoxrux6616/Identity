using FluentValidation;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Validators;

public class SkillCreateDtoValidator : AbstractValidator<SkillCreateDto>
{
    private readonly IUserRepository UserRepository;
    public SkillCreateDtoValidator(IUserRepository userRepository)
    {
        UserRepository = userRepository;

        RuleFor(s => s.Type)
            .NotEmpty()
            .WithMessage("Type must not be empty")
            .MaximumLength(20)
            .WithMessage("Length must be less than 20");


        RuleFor(s => s.Name)
            .NotNull()
            .WithMessage("Type must not be null")
            .NotEmpty()
            .WithMessage("Type must not be empty")
            .MaximumLength(20)
            .WithMessage("Length must be less than 20");

        RuleFor(s => s.Description)
            .MaximumLength(255)
            .WithMessage("Description length must be less than 255");
    }
}
