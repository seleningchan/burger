using System.Threading.Tasks;
using AutoMapper;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Application.Dtos;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepositry _ratingRepository;

        public RatingService(IMapper mapper, IRatingRepositry ratingRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        public async Task AddRatingAsync(RatingDto ratingDto)
        {
            var entity = _mapper.Map<RatingDto, RatingEntity>(ratingDto);
            entity.UserId = 1;
            await _ratingRepository.AddEntityAsync(entity);
        }
    }
}
