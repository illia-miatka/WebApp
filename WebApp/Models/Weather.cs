using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace WebApp.Models.Weather
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("flagURL")]
        public string FlagURL { get; set; }
    }

    public class Temp
    {
        [JsonProperty("day")]
        public double Day { get; set; }
        [JsonProperty("min")]
        public double Min { get; set; }
        [JsonProperty("max")]
        public double Max { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; }
        [JsonProperty("eve")]
        public double Eve { get; set; }
        [JsonProperty("morn")]
        public double Morn { get; set; }
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

    public class List
    {
        [JsonProperty("dt")]
        public int DT { get; set; }
        [JsonProperty("temp")]
        public Temp Temp { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Deg { get; set; }
        [JsonProperty("clouds")]
        public int Clouds { get; set; }
        [JsonProperty("rain")]
        public double Rain { get; set; }
        public DateTime datetime()
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(DT).ToLocalTime();
            return dtDateTime;
        }
    }

    public class RootObject
    {
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("cod")]
        public int Cod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<List> List { get; set; }
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }
    }
}