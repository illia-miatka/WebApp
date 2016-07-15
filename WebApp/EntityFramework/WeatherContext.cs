using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApp
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base()
        {
            Database.SetInitializer<WeatherContext>(new WeatherContextInitializer());
        }

        public DbSet<Models.Weather.City> Citys { get; set; }
        public DbSet<Models.Weather.RootObject> RootObjects { get; set; }

    }
}