using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/restaurant")]
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> FindLocalRestaurant(string city)
    {
        var restaurants = await _restaurantService.FindLocalBurgerRestaurantAsync(city);
        return Ok(restaurants);
    }

    [HttpGet("{position}")]
    public async Task<IActionResult> FindNearRestaurant(string position)
    {
        var postionDetails = position.Split(",");
        if(!double.TryParse(postionDetails[0], out double longitude))
        {
            return BadRequest("longitude invalidated");
        }
        if (!double.TryParse(postionDetails[1], out double latitude))
        {
            return BadRequest("latitude invalidated");
        }
        var restaurants = await _restaurantService.FindNearBurgerRestaurantAsync(longitude,latitude);
        return Ok(restaurants);
    }
}