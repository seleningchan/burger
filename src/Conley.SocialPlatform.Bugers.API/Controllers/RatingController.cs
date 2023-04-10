using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/rating")]
public class RatingController : Controller
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpPost]
    public async Task<IActionResult> AddRating([FromBody] RatingDto ratingDto)
    {
        await _ratingService.AddRatingAsync(ratingDto);
        return Ok();
    }
}