using Microsoft.AspNetCore.Mvc;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService UserService;

    public UserController(IUserService userService)
    {
        UserService = userService;
    }

    [HttpPost("add")]
    public async Task<long> PostUser(UserCreateDto userCreateDto)
    {
        return await UserService.PostAsync(userCreateDto);
    }

    [HttpGet("get-all")]
    public async Task<ICollection<UserGetDto>> GetAll()
    {
        return await UserService.GetAllAsync();
    }

}
