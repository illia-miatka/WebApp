using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            CityService wService = new CityService();
            return View(wService.GetAll());
        }

        // GET: GetWeatherDay
        public ActionResult GetWeatherDay(string city)
        {
            return View(GetWeatherService.GetWeather(city));
        }

        // GET: GetWeather3Days
        public ActionResult GetWeather3Days(string city)
        {
            int days = 3;
            return View(GetWeatherService.GetWeather(city, days));
        }

        // GET: GetWeather7Days
        public ActionResult GetWeather7Days(string city)
        {
            int days = 7;
            return View(GetWeatherService.GetWeather(city, days));
        }

        public ActionResult GetCity(FormCollection Form)
        {
            var city = new Models.Weather.City();
            city.name = Form["txtName"]; ;
            return View(city);
        }
    }
}