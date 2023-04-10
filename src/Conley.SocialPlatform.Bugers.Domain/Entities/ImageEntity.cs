using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class ImageEntity
    {
        public int _Id { get; set; }
        public int UploadUserId { get; set; }
        public string ImagePath { get; set; }
    }
}
