using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services
{
    public interface IGetWeather
    {
        Models.Weather.RootObject GetWeather(string city, int days);
        string GetWeatherIco(string code);
        string GetFlag(string code);
        string CheckCity(string city);
    }
    public class GetWeatherService : IGetWeather
    {
        private const string connection = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={2}&APPID={1}";
        private const string connectionOne = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&APPID={1}";
        private const string apikey = "1108d8304b12b6e64212f71a9bb28d78";
        private const string icoURL = "http://openweathermap.org/img/w/{0}.png";
        private const string flagURL = "http://www.geonames.org/flags/x/{0}.gif";

        public Models.Weather.RootObject GetWeather(string city, int days)
        {
            if (city != null)
            {
                string connectionstr;
                if (days == 1)
                { connectionstr = connectionOne; }
                else
                { connectionstr = connection; }
                var request = string.Format(connectionstr, city, apikey, days);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = webClient.DownloadString(request);
                    var r = JsonConvert.DeserializeObject<Models.Weather.RootObject>(response);
                    if (days == 1)
                    {
                        r.Sys.FlagURL = GetFlag(r.Sys.Country);
                        foreach (var p in r.Weather)
                        {
                            p.IcoURL = GetWeatherIco(p.Icon);
                        }
                    }
                    else
                    {
                        r.Name = r.City.Name;
                        r.City.FlagURL = GetFlag(r.City.Country);
                        foreach (var p in r.List)
                        {
                            foreach (var f in p.Weather)
                                f.IcoURL = GetWeatherIco(f.Icon);
                        }
                    }

                    using (WeatherContext db = new WeatherContext())
                    {
                        r.Modified = DateTime.Now;
                        db.RootObjects.Add(r);
                        db.SaveChanges();
                    }
                    return r;
                }
                catch (Exception ex)
                {
                    return new Models.Weather.RootObject { ErrorMsg = ex.Message };
                }
                finally
                {
                    webClient.Dispose();
                }
            }

            return new Models.Weather.RootObject { ErrorMsg = "No City!" }; ;

        }

        /*public Models.Weather.RootObject GetWeather(string city)
        {
            if (city != null)
            {
                var request = string.Format(connectionOne, city, apikey);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = webClient.DownloadString(request);
                    var r = JsonConvert.DeserializeObject<Models.Weather.RootObject>(response);
                    r.Sys.FlagURL = GetFlag(r.Sys.Country);
                    foreach (var p in r.Weather)
                    {
                        p.IcoURL = GetWeatherIco(p.Icon);
                    }
                    return r;
                }
                catch (Exception ex)
                {
                    return new Models.Weather.RootObject { ErrorMsg = ex.Message };
                }
                finally
                {
                    webClient.Dispose();
                }
            }

            return new Models.Weather.RootObject { ErrorMsg = "No City!" }; ;

        }*/

        public string GetWeatherIco(string code)
        {
            var request = string.Format(icoURL, code);
            return request;
        }

        public string GetFlag(string code)
        {
            var request = string.Format(flagURL, code.ToLower());
            return request;
        }

        public string CheckCity(string city)
        {
            if (city != null)
            {
                var request = string.Format(connectionOne, city, apikey);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = webClient.DownloadString(request);
                    var r = JsonConvert.DeserializeObject<Models.Weather.RootObject>(response);
                    return r.Name.ToString();
                }
                catch (Exception)
                {
                    return "Bad city!";
                }
                finally
                {
                    webClient.Dispose();
                }
            }

            return "No City!";
        }
    }
}