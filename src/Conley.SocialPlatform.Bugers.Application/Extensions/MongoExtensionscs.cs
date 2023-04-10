using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using static Conley.SocialPlatform.Bugers.Domain.Constants;

namespace Conley.SocialPlatform.Bugers.Application.Extensions
{
    public static class MongoExtensionscs
    {
        public static IFindFluent<TDocument, TProjection> LogCommand<TDocument, TProjection, TClass>(this IFindFluent<TDocument, TProjection> query, ILogger<TClass> logger, IMongoCollection<TDocument> mongoCollection = null, LogLevel logLevel = LogLevel.Debug, [CallerMemberName] string method = null)
        {
            if (logger.IsEnabled(logLevel))
            {
                mongoCollection = mongoCollection ??
                    query.GetType().GetField("_collection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                         .GetValue(query) as IMongoCollection<TDocument>;

                logger.Log(
                    logLevel,
                    LogMessageTemplates.MongoLogQueryCommand,
                    typeof(TClass),
                    method,
                    mongoCollection?.Database.DatabaseNamespace.DatabaseName,
                    mongoCollection?.CollectionNamespace.CollectionName,
                    query.ToString());
            }

            return query;
        }

        public static IMongoCollection<TDocument> LogCommand<TDocument, TClass>(this IMongoCollection<TDocument> mongoCollection, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, ILogger<TClass> logger, LogLevel logLevel = LogLevel.Debug, [CallerMemberName] string method = null)
        {
          
            if (logger.IsEnabled(logLevel))
            {
                var updateCommandRenderedJson =
                    update?.Render(mongoCollection.DocumentSerializer, mongoCollection.Settings.SerializerRegistry).ToJson();

                var filterRenderedJson =
                    filter?.Render(mongoCollection.DocumentSerializer, mongoCollection.Settings.SerializerRegistry).ToJson();

                logger.Log(
                    logLevel,
                    LogMessageTemplates.MongoLogUpdateCommand,
                    typeof(TClass),
                    method,
                    mongoCollection.Database.DatabaseNamespace.DatabaseName,
                    mongoCollection.CollectionNamespace.CollectionName,
                    updateCommandRenderedJson,
                    filterRenderedJson);
            }

            return mongoCollection;
        }

        public static IAggregateFluent<TProjection> LogCommand<TProjection, TClass>(this IAggregateFluent<TProjection> query, ILogger<TClass> logger, dynamic mongoCollection = null, LogLevel logLevel = LogLevel.Debug, [CallerMemberName] string method = null)
        {
            if (logger.IsEnabled(logLevel))
            {
                mongoCollection = mongoCollection ??
                                  query.GetType().GetField("_collection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                      .GetValue(query);
                logger.Log(
                    logLevel,
                    LogMessageTemplates.MongoLogQueryCommand,
                    typeof(TClass),
                    method,
                    (string)mongoCollection.Database.DatabaseNamespace.DatabaseName,
                    (string)mongoCollection.CollectionNamespace.CollectionName,
                    query.ToString());
            }

            return query;
        }

        public static async Task<bool> AnyAsync<TEntity>(
           this IMongoCollection<TEntity> collection,
           Func<FilterDefinitionBuilder<TEntity>, FilterDefinition<TEntity>> filterDefinitionBuilder)
        {
            return (await collection.CountDocumentsAsync(
                filterDefinitionBuilder(Builders<TEntity>.Filter), new CountOptions { Limit = 1 })) > 0;
        }
    }
}
