using System;

namespace Conley.SocialPlatform.Bugers.Application.Dtos
{
    public class RatingDto
    {
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }
        public int RestaurantId { get; set; }
        public string Remark { get; set; }
        public DateTime AddTime => DateTime.UtcNow;
    }
}
