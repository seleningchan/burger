using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Microsoft.AspNetCore.Http;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure
{
    public interface IStoreProvider
    {
        Task<ImageResource> UploadFile(IFormFile file);
    }
}
