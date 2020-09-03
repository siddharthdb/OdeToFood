using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantByName(string name);

    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1, Name = "Olive Garden", CusinineType = CusinineType.Italian, Location = "WoodBridge"
                },
                new Restaurant
                {
                    Id = 2, Name = "On the Border", CusinineType = CusinineType.Mexican, Location = "North Brunswick"
                },
                new Restaurant
                {
                    Id = 1, Name = "Mithas", CusinineType = CusinineType.Indian, Location = "Edison"
                }

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where r.Name.StartsWith(name)
                   select r;
        }
    }
}
