using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class RatingRepository : IRatingRepositry
    {
        private readonly IMongoCollection<RatingEntity> _ratingRepository;
        private readonly ILogger<RatingRepository> _logger;

        public RatingRepository(IMongoCollection<RatingEntity> ratingRepository, ILogger<RatingRepository> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }
        public async Task AddEntityAsync(RatingEntity rating)
        {
            await _ratingRepository.InsertOneAsync(rating);
        }
    }
}
