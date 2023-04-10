using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Microsoft.AspNetCore.Http;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Services
{
    public interface IImageService
    {
        public Task<ImageResource> UploadImage(IFormFile file);
    }
}
