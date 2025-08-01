﻿using FluentValidation;
using Microsoft.Extensions.Logging;
using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;
    private readonly IValidator<UserCreateDto> Validator;
    private readonly ILogger<UserService> Logger;

    public UserService(IUserRepository userRepository, IValidator<UserCreateDto> validator, ILogger<UserService> logger)
    {
        UserRepository = userRepository;
        Validator = validator;
        Logger = logger;
    }

    public Task DeleteAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<UserGetDto>> GetAllAsync()
    {
        var users = await UserRepository.SelectAllAsync();
        var usersDto = users.Select(u => Mappings.ConvertToUserGetDto(u)).ToList();
        return usersDto;
    }

    public async Task<long> PostAsync(UserCreateDto userCreateDto)
    {
        var result = Validator.Validate(userCreateDto);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var user = Mappings.ConvertToUser(userCreateDto);
        var userId = await UserRepository.InsertAsync(user);

        //Logger.LogInformation("User created successfully with ID: {UserId}", userId);

        return userId;
    }
}
