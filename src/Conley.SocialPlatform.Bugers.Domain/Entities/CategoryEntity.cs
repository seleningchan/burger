using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class CategoryEntity
    {
        public BsonObjectId _Id { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
