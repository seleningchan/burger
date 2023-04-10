using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;
using Conley.SocialPlatform.Bugers.Domain;
using Conley.SocialPlatform.Bugers.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Providers
{
    public class MongoClientFactory: IMongoClientFactory
    {
        private readonly IOptions<MongoSettings> _mongoSettings;
        public MongoClientFactory(IOptions<MongoSettings> mongoSettings)
        {
            _mongoSettings = mongoSettings;
        }

        public MongoClient Build(ILogger logger = null)
        {
            logger = logger ?? NullLogger.Instance;
            var clientSettings = MongoClientSettings.FromConnectionString(_mongoSettings.Value.ConnectionString);
            clientSettings.ClusterConfigurator = cb =>
            {
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    cb.Subscribe<CommandStartedEvent>(e =>
                    {
                        logger.LogDebug(
                            Constants.LogMessageTemplates.MongoLogCommandStartedEvent,
                            e.DatabaseNamespace.DatabaseName,
                            e.CommandName,
                            e.Command.ToJson());
                    });
                }
            };

            return new MongoClient(clientSettings);
        }
    }
}
