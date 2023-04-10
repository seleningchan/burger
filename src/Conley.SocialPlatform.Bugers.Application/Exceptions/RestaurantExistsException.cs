using System;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Application.Exceptions
{
    public class RestaurantExistsException : Exception
    {
        public const string ExceptionMessage = "Restaurant with the same name already exists";

        public RestaurantExistsException(RestaurantEntity restaurant, Exception innerException = null)
            : base(ExceptionMessage, innerException)
        {
            DuplicateRestaurant = restaurant;
        }

        public RestaurantEntity DuplicateRestaurant { get; }
    }
}
