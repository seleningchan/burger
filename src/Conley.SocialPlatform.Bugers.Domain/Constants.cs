using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Domain
{
    public sealed class Constants
    {
        public static class MongoCollections
        {
            public const string CategoryCollectionName = "Categories";
            public const string FoodCollectionName = "Foods";
            public const string RatingCollectionName = "Ratings";
            public const string RestuarantCollectionName = "Restuarants";
            public const string UserCollectionName = "Users";
            public const string ImageCollectionName = "Images";
            public const string CityCollectionName = "Cities";
        }

        public class LogMessageTemplates
        {
            public const string MongoLogQueryCommand = "{Repository} {Method} {DatabaseName} db.{CollectionName} {query}";
            public const string MongoLogUpdateCommand = "{Repository} {Method} {DatabaseName} db.{CollectionName} {@update} {@filter}";
            public const string MongoLogCommandStartedEvent = "Mongo {DatabaseName} {CommandName} - {@Command}";
        }

        public static class UploadFilePath
        {
            public const string BasePath = "Upload";
        }

        public static class WebRootPath
        {
            public const string WebPath = "wwwroot";
        }
    }
}
