using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Services;
using Ninject;

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
            return View(cityList.GetAll());
        }

        // GET: GetWeatherDay
        public ActionResult GetWeatherDay(string city)
        {
            return View(getWeather.GetWeather(city));
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

        public ActionResult GetCity(FormCollection Form)
        {
            //var city = new Models.Weather.City();
            string name = Form["txtName"];
            var city = cityList.GetNew();
            city.name = getWeather.CheckCity(name);
            return View(city);
        }
    }
}