using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class ImageEntity
    {
        public BsonObjectId _Id { get; set; }
        public int UploadUserId { get; set; }
        public string ImagePath { get; set; }
    }
}
