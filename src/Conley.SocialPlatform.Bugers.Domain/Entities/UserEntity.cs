using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class UserEntity
    {
        public BsonObjectId _id { get; set; }
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
    }
}
