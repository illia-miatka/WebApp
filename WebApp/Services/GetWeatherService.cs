using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services
{
    public static class GetWeatherService
    {
        private const string connection = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={2}&APPID={1}";
        private const string connectionOne = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&APPID={1}";
        private const string apikey = "1108d8304b12b6e64212f71a9bb28d78";
        private const string icoURL = "http://openweathermap.org/img/w/{0}.png";
        private const string flagURL = "http://www.geonames.org/flags/x/{0}.gif";

        public static Models.Weather.RootObject GetWeather(string city, int days)
        {
            if (city != null)
            {
                var request = string.Format(connection, city, apikey, days);
                System.Net.WebClient webClient = new System.Net.WebClient();
                
                try
                {
                    string response = webClient.DownloadString(request);
                    return JsonConvert.DeserializeObject<Models.Weather.RootObject>(response);
                }
                catch (Exception ex)
                {
                    return new Models.Weather.RootObject { errorMsg = ex.Message};
                }
            }

            return new Models.Weather.RootObject { errorMsg = "No City!" }; ;

        }

        public static Models.WeatherNow.RootObject GetWeather(string city)
        {
            if (city != null)
            {
                var request = string.Format(connectionOne, city, apikey);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = webClient.DownloadString(request);
                    return JsonConvert.DeserializeObject<Models.WeatherNow.RootObject>(response);
                }
                catch (Exception ex)
                {
                    return new Models.WeatherNow.RootObject { errorMsg = ex.Message };
                }
            }

            return new Models.WeatherNow.RootObject { errorMsg = "No City!" }; ;

        }

        public static string GetWeatherIco(string code)
        {
            var request = string.Format(icoURL, code);
            return request;
        }

        public static string GetFlag(string code)
        {
            var request = string.Format(flagURL, code.ToLower());
            return request;
        }
    }
}