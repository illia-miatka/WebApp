using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Weather
{
    public class Coord
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
        public string FlagUrl { get; set; }
    }

    public class Temp
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
        public string IcoUrl { get; set; }

    }

    public class List
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
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
        public DateTime Datetime()
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Dt).ToLocalTime();
            return dtDateTime;
        }
    }

    public class Main
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }

    public class Wind
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Deg { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
        public string FlagUrl { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("city")]
        [NotMapped]
        public City City { get; set; }
        [JsonProperty("cod")]
        public int Cod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<List> List { get; set; }
        public string ErrorMsg { get; set; }
        [JsonProperty("coord")]
        [NotMapped]
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
        public int Dt { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Datetime(int date)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(date).ToLocalTime();
            return dtDateTime;
        }
    }
}