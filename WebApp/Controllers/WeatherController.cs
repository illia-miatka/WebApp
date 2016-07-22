using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.Services;
using WebApp.Models.Weather;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApp.Controllers
{
    public class WeatherController : Controller
    {
        readonly ICity _cityList;
        readonly IGetWeather _getWeather;
        public WeatherController(ICity c, IGetWeather w)
        {
            _cityList = c;
            _getWeather = w;
        }
        
        // GET: Weather
        public async Task<ActionResult> Index()
        {
            var cities = new List<City>();
            using (WeatherContext db = new WeatherContext())
            {
                foreach (var city in await db.Citys.ToListAsync())
                {
                   cities.Add(city);
                }
            }
                return View(cities);
        }

        // GET: GetWeatherDay
        public async Task<ActionResult> GetWeatherDay(string city)
        {
            int days = 1;
            return View(await _getWeather.GetWeather(city, days));
        }

        // GET: GetWeather3Days
        public async Task<ActionResult> GetWeather3Days(string city)
        {
            int days = 3;
            return View(await _getWeather.GetWeather(city, days));
        }

        // GET: GetWeather7Days
        public async Task<ActionResult> GetWeather7Days(string city)
        {
            int days = 7;
            return View(await _getWeather.GetWeather(city, days));
        }

        //GET: GetCity
        public async Task<ActionResult> GetCity(FormCollection form)
        {
            string name = form["txtName"];
            var city = _cityList.GetNew();
            city.Name = await _getWeather.CheckCity(name);
            return View(city);
        }

        // GET: Index
        public async Task<RedirectResult> DeleteCity(string city)
        {
            using (WeatherContext db = new WeatherContext())
            {
                await db.Citys_DelCity(city);
            }
            return Redirect("/Weather/Index");
        }

        public async Task<RedirectResult> AddCity(City city)
        {
            using (WeatherContext db = new WeatherContext())
            {
                await db.Citys_AddCity(city);
            }
            return Redirect("/Weather/Index");
        }

        // GET: History
        public async Task<ActionResult> History()
        {
            List<RootObject> hist = new List<RootObject>();
            using (WeatherContext db = new WeatherContext())
            {
                await db.RootObjects_GetList(hist);
            }
            return View(hist);
        }
    }
}