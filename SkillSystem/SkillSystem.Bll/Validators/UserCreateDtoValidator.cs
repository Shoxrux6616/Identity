using FluentValidation;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;
using System.Text.RegularExpressions;

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

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email must not be empty")
            .Must(EmailCheck)
            .WithMessage("Email is invalid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password must not be empty")
            .Must(PasswordCheck)
            .WithMessage("Password is invalid");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName must not be empty")
            .Must(UserNameCheck)
            .WithMessage("UserName is invalid");
    }

    private bool EmailCheck(string email)
    { 
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        var isValid = Regex.IsMatch(email, pattern);

        return isValid;
    }

    private bool PasswordCheck(string password)
    {
        var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$";

        var isValid = Regex.IsMatch(password, pattern);

        return isValid;
    }

    private bool UserNameCheck(string userName)
    {
        var pattern = @"^[a-zA-Z0-9_]{3,20}$";

        var isValid = Regex.IsMatch(userName, pattern);

        return isValid;
    }
}
