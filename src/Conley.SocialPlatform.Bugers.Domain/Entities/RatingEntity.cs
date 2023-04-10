using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class RatingEntity
    {
        public int _Id { get; set; }
        public int UserId { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }
        public int RestaurantId { get; set; }
        public string Remark { get; set; }
        public BsonDateTime AddTime { get; set; }
    }
}
