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
        private static List<City> _cityList;
        
        public CityService()
        {
            _cityList = new List<City>();
            _cityList.Add(new City { Name = "Kiev" });
            _cityList.Add(new City { Name = "Lviv" });
            _cityList.Add(new City { Name = "Dnipropetrovsk" });
            _cityList.Add(new City { Name = "Kharkiv" });
            _cityList.Add(new City { Name = "Odessa" });
        }

        public City GetNew()
        { return new City(); }

        public List<City> GetAll()
        {
            return _cityList;
        }


    }
}