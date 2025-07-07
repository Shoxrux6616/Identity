using Microsoft.AspNetCore.Mvc;
using SkillSystem.Bll.DesignPatternServices;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService UserService;
    private readonly OddSumContext OddSumContext;

    public UserController(IUserService userService, OddSumContext oddSumContext)
    {
        UserService = userService;
        OddSumContext = oddSumContext;
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

    [HttpPost("get-summ-of-odd")]
    public int GetResult(IEnumerable<int> numbers)
    {
        return OddSumContext.ExecuteStrategy(numbers);
    }

}
