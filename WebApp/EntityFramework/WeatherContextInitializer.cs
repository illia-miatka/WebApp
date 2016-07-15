using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models.Weather;
using WebApp.Services;

namespace WebApp
{
    class WeatherContextInitializer : DropCreateDatabaseAlways<WeatherContext>
    {
        CityService cityS = new CityService();
        protected override void Seed(WeatherContext db)
        {
            int i = 1;
            foreach (var p in cityS.GetAll())
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