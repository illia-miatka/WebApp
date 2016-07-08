using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.Weather;
using System.Web.Mvc;

namespace WebApp.Services
{
    public class CityService
    {
        private static List<City> cityList;
        
        public CityService()
        {
            cityList = new List<City>();
            cityList.Add(new City { name = "Kiev" });
            cityList.Add(new City { name = "Lviv" });
            cityList.Add(new City { name = "Dnipropetrovsk" });
            cityList.Add(new City { name = "Kharkiv" });
            cityList.Add(new City { name = "Odessa" });
        }

        public List<City> GetAll()
        {
            return cityList;
        }


    }
}