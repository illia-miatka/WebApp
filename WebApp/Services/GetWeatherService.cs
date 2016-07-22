using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApp.Models.Weather;

namespace WebApp.Services
{
    public interface IGetWeather
    {
        Task<RootObject> GetWeather(string city, int days);
        string GetFlag(string code);
        Task<string> CheckCity(string city);
    }
    public class GetWeatherService : IGetWeather
    {
        private const string Connection = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={2}&APPID={1}";
        private const string ConnectionOne = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&APPID={1}";
        private const string Apikey = "1108d8304b12b6e64212f71a9bb28d78";
        private const string IcoUrl = "http://openweathermap.org/img/w/{0}.png";
        private const string FlagUrl = "http://www.geonames.org/flags/x/{0}.gif";

        public async Task<RootObject> GetWeather(string city, int days)
        {
            if (city != null)
            {
                string connectionstr;
                if (days == 1)
                { connectionstr = ConnectionOne; }
                else
                { connectionstr = Connection; }
                var request = string.Format(connectionstr, city, Apikey, days);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = await webClient.DownloadStringTaskAsync(request);
                    var r = JsonConvert.DeserializeObject<Models.Weather.RootObject>(response);
                    if (days == 1)
                    {
                        r.Sys.FlagUrl = GetFlag(r.Sys.Country);
                        foreach (var p in r.Weather)
                        {
                            p.IcoUrl = GetWeatherIco(p.Icon);
                        }
                    }
                    else
                    {
                        r.Name = r.City.Name;
                        r.City.FlagUrl = GetFlag(r.City.Country);
                        foreach (var p in r.List)
                        {
                            foreach (var f in p.Weather)
                                f.IcoUrl = GetWeatherIco(f.Icon);
                        }
                    }

                    using (WeatherContext db = new WeatherContext())
                    {
                        r.Modified = DateTime.Now;
                        await db.RootObjects_AddRoot(r);
                    }
                    return r;
                }
                catch (Exception ex)
                {
                    return new RootObject { ErrorMsg = ex.Message };
                }
                finally
                {
                    webClient.Dispose();
                }
            }

            return new Models.Weather.RootObject { ErrorMsg = "No City!" }; ;

        }

        string GetWeatherIco(string code)
        {
            var request = string.Format(IcoUrl, code);
            return request;
        }

        public string GetFlag(string code)
        {
            var request = string.Format(FlagUrl, code.ToLower());
            return request;
        }

        public async Task<string> CheckCity(string city)
        {
            if (city != null)
            {
                var request = string.Format(ConnectionOne, city, Apikey);
                System.Net.WebClient webClient = new System.Net.WebClient();

                try
                {
                    string response = await webClient.DownloadStringTaskAsync(request);
                    var r = JsonConvert.DeserializeObject<RootObject>(response);
                    return r.Name;
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