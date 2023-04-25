using System;
using Newtonsoft.Json;

namespace Json2CSharp
{
    [Serializable]
    public class WeatherData
    {
        public Coord coord;
        public Main main;
        public Wind wind;
        public Rain rain;
        public Clouds clouds;
    }

    [Serializable]
    public class Clouds
    {
        public int all;
    }

    [Serializable]
    public class Coord
    {
        public float lon;
        public float lat;
    }

    [Serializable]
    public class Main
    {
        public float temp;
        public int humidity;
    }

    [Serializable]
    public class Rain
    {
        [JsonProperty("1h")] public float _1h;
    }

    [Serializable]
    public class Wind
    {
        public float speed;
        public int deg;
    }
}