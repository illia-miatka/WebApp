using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WebApp.Models.Weather;
using System.Threading.Tasks;

namespace WebApp
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base()
        {
            Database.SetInitializer<WeatherContext>(new WeatherContextInitializer());
        }

        public DbSet<City> Citys { get; set; }
        public DbSet<RootObject> RootObjects { get; set; }

        public async Task RootObjects_AddRoot(RootObject root)
        { 
                this.RootObjects.Add(root);
                await this.SaveChangesAsync();
        }

        public async Task Citys_DelCity(string city)
        {
            var c = this.Citys.FirstOrDefault(x => x.Name == city);
            if (c == null) return;
            this.Citys.Remove(c);
            await this.SaveChangesAsync();
        }

        public async Task Citys_AddCity(City city)
        {
            var c = this.Citys.FirstOrDefault(x => x.Name == city.Name);
            if (c == null)
            {
                this.Citys.Add(city);
                await this.SaveChangesAsync();
            }
        }

        public async Task RootObjects_GetList(List<RootObject> list )
        {
            var root = await this.RootObjects.ToListAsync();
            if (!root.Any()) return;
            foreach (var p in root)
            {
                list.Add(p);
            }
        }
    }
}