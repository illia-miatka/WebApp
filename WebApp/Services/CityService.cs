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
            _cityList = new List<City>
            {
                new City {Name = "Kiev"},
                new City {Name = "Lviv"},
                new City {Name = "Dnipropetrovsk"},
                new City {Name = "Kharkiv"},
                new City {Name = "Odessa"}
            };
        }

        public City GetNew()
        { return new City(); }

        public List<City> GetAll()
        {
            return _cityList;
        }


    }
}