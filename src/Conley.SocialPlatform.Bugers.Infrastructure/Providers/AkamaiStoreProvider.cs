using System;
using System.IO;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Microsoft.AspNetCore.Http;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Providers
{
    public class AkamaiStoreProvider : IStoreProvider
    {
        public Task<ImageResource> UploadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
