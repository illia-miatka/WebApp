using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.Weather;
using System.Web.Mvc;

namespace WebApp.Services
{
    public interface ICity
    {
        List<City> GetAll();
        City GetNew();
    }

    public class CityService : ICity
    {
        private static List<City> cityList;
        
        public CityService()
        {
            cityList = new List<City>();
            cityList.Add(new City { Name = "Kiev" });
            cityList.Add(new City { Name = "Lviv" });
            cityList.Add(new City { Name = "Dnipropetrovsk" });
            cityList.Add(new City { Name = "Kharkiv" });
            cityList.Add(new City { Name = "Odessa" });
        }

        public City GetNew()
        { return new City(); }

        public List<City> GetAll()
        {
            return cityList;
        }


    }
}