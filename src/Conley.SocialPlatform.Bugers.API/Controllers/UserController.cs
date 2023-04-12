
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly BearerToken _bearerToken;

    public UserController(IUserService userService, BearerToken bearerToken)
    {
        _userService = userService;
        _bearerToken = bearerToken;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GenerateBearerToken(LoginParameter loginParameter)
    {
        (string, string) tokenAndExpiredTime = new(string.Empty, string.Empty);
        if (await _userService.CheckUserAsync(loginParameter))
        {
            tokenAndExpiredTime = _bearerToken.CreateAsString(loginParameter.UserName);
        }
        return Ok(new
        {
            token = tokenAndExpiredTime.Item1,
            expiredDate = tokenAndExpiredTime.Item2
        });
    }
}