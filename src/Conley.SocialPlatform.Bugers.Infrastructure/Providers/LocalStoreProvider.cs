using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Application.Exceptions;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Conley.SocialPlatform.Bugers.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Providers
{
    class LocalStoreProvider : IStoreProvider
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public LocalStoreProvider(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<ImageResource> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                throw new BadRequestException("File is null");
            }

            if (file.Length == 0)
            {
                throw new BadRequestException("File is empty");
            }

            if (file.Length > 10 * 1024 * 1024)
            {
                throw new BadRequestException("File size cannot exceed 10M");
            }

            var acceptTypes = new[] { ".jpg", ".jpeg", ".png" };
            if (acceptTypes.All(t => t != Path.GetExtension(file.FileName).ToLower()))
            {
                throw new BadRequestException("File type not valid, only jpg and png are acceptable.");
            }

            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), Constants.WebRootPath.WebPath);
            }

            var uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, Constants.UploadFilePath.BasePath);
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return new ImageResource { ImagePath = filePath };
        }
    }
}
