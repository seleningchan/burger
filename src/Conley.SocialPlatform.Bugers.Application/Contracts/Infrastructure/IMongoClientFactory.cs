using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure
{
    public interface IMongoClientFactory
    {
        MongoClient Build(ILogger logger = null);
    }
}
