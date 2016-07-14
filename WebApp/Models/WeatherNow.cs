using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace WebApp.Models.WeatherNow
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("icoURL")]
        public string IcoURL { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }
        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Deg { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public double All { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        [JsonProperty("flagURL")]
        public string FlagURL { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("@base")]
        public string Base { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("dt")]
        public int DT { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cod")]
        public int Cod { get; set; }
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }
        public DateTime datetime(int date)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(date).ToLocalTime();
            return dtDateTime;
        }
    }

}