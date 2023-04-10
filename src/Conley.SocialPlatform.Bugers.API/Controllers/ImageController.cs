using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/image")]
public class ImageController : Controller
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        try
        {
            var resource = await _imageService.UploadImage(file);
            return Ok(resource);
        }
        catch(BadHttpRequestException ex)
        {
            return BadRequest(ex);
        }
    }
}