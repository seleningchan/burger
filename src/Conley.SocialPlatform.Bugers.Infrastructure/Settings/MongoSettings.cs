using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Settings
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";
        public string DatabaseName { get; set; } = "burgersocialplatform";

        public static class EnvironmentVariables
        {
            public static readonly string ConnectionString = $"{nameof(MongoSettings)}__{nameof(MongoSettings.ConnectionString)}";
        }

        public static class Arguments
        {
            public static readonly string ConnectionString = $"{nameof(MongoSettings)}:{nameof(MongoSettings.ConnectionString)}";
            public static readonly string DatabaseName = $"{nameof(MongoSettings)}:{nameof(MongoSettings.DatabaseName)}";
        }
    }
}
