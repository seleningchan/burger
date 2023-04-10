using System.Threading.Tasks;
using AutoMapper;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IStoreProvider _storeProvider;
        private readonly ImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public ImageService(IStoreProvider storeProvider, ImageRepository imageRepository,
            IMapper mapper)
        {
            _storeProvider = storeProvider;
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<ImageResource> UploadImage(IFormFile file)
        {
            int userId = 1;
            var imageResource = await _storeProvider.UploadFile(file);
            var image = _mapper.Map<ImageResource, ImageEntity>(imageResource);
            image.UploadUserId = userId;
            await _imageRepository.AddEntityAsync(image);
            return imageResource;
        }
    }
}
