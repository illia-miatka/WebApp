using System.Data.Entity;
using WebApp.Models.Weather;
using WebApp.Services;

namespace WebApp
{
    class WeatherContextInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        private readonly CityService _cityS = new CityService();
        protected override void Seed(WeatherContext db)
        {
            int i = 1;
            foreach (var p in _cityS.GetAll())
            {
                var city = new City { Name = p.Name };
                city.Id = i;
                i++;
                db.Citys.Add(city);
            }
            db.SaveChanges();
        }
    }
}