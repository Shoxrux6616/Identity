using FluentValidation;
using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services.Helper;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository UserRepository;
    private readonly IValidator<UserCreateDto> Validator;

    public AuthService(IUserRepository userRepository, IValidator<UserCreateDto> validator)
    {
        UserRepository = userRepository;
        Validator = validator;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await UserRepository.SelectUserByUserNameAsync(userLoginDto.UserName);

        var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.Password, user.Salt);

        if (checkUserPassword == false)
        {
            throw new UnauthorizedException("UserName or password incorrect");
        }

        var userGetDto = new UserGetDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = (UserRoleDto)user.Role,
        };

        var token = TokenService.GenerateToken(userGetDto);
        var refreshToken = TokenService.GenerateRefreshToken();

        var refreshTokenToDB = new RefreshToken()
        {
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(21),
            IsRevoked = false,
            UserId = user.UserId
        };

        await RefreshTokenRepository.AddRefreshTokenAsync(refreshTokenToDB);

        var loginResponseDto = new LoginResponseDto()
        {
            AccessToken = token,
            RefreshToken = refreshToken,
            TokenType = "Bearer",
            Expires = 24
        };


        return loginResponseDto;
    }

    public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }

    public async Task<long> SignUpAsync(UserCreateDto userCreateDto)
    {
        var result = Validator.Validate(userCreateDto);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var hashedPassword = PasswordHasher.HashPassword(userCreateDto.Password);

        var user = Mappings.ConvertToUser(userCreateDto);
        user.Password = hashedPassword.Hash;
        user.Salt = hashedPassword.Salt;

        var userId = await UserRepository.InsertAsync(user);

        return userId;
    }
}
