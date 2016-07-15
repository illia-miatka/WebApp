using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Services;
using Ninject;
using WebApp.Models.Weather;

namespace WebApp.Controllers
{
    public class WeatherController : Controller
    {
        ICity cityList;
        IGetWeather getWeather;
        public WeatherController(ICity c, IGetWeather w)
        {
            cityList = c;
            getWeather = w;
        }
        // GET: Weather
        public ActionResult Index()
        {
            var cities = new List<City>();
            using (WeatherContext db = new WeatherContext())
            {
                var citiesSQL = db.Database.SqlQuery<City>("SELECT * FROM Cities");
                foreach (var city in citiesSQL)
                {
                    cities.Add(new City { Name = city.Name });
                }
            }
                return View(cities);
        }

        // GET: GetWeatherDay
        public ActionResult GetWeatherDay(string city)
        {
            int days = 1;
            return View(getWeather.GetWeather(city, days));
        }

        // GET: GetWeather3Days
        public ActionResult GetWeather3Days(string city)
        {
            int days = 3;
            return View(getWeather.GetWeather(city, days));
        }

        // GET: GetWeather7Days
        public ActionResult GetWeather7Days(string city)
        {
            int days = 7;
            return View(getWeather.GetWeather(city, days));
        }

        //GET: GetCity
        public ActionResult GetCity(FormCollection Form)
        {
            //var city = new Models.Weather.City();
            string name = Form["txtName"];
            var city = cityList.GetNew();
            city.Name = getWeather.CheckCity(name);
            return View(city);
        }

        // GET: Index
        public RedirectResult DeleteCity(string city)
        {
            using (WeatherContext db = new WeatherContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", city);
                int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM Cities WHERE Name = @name", param);
            }

            return Redirect("/Weather/Index");
        }

        public RedirectResult AddCity(City city)
        {
            using (WeatherContext db = new WeatherContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", city.Name);
                var citiesSQL = db.Database.SqlQuery<City>("SELECT * FROM Cities WHERE Name = @name", param);
                //int numberOfRow = db.Database.ExecuteSqlCommand("SELECT * FROM Cities WHERE Name like ('%@name%')", param);
                if (citiesSQL.Count() == 0)
                {
                    db.Citys.Add(city);
                    db.SaveChanges();
                }
            }

            return Redirect("/Weather/Index");
        }

        // GET: History
        public ActionResult History()
        {
            var hist = new List<RootObject>();
            using (WeatherContext db = new WeatherContext())
            {
                var vSQL = db.Database.SqlQuery<RootObject>("SELECT * FROM RootObjects ORDER BY Modified DESC");
                foreach (var p in vSQL)
                {
                    hist.Add(p);
                }
            }
            return View(hist);
        }
    }
}