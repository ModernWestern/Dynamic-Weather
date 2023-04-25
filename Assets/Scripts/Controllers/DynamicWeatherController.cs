using Utils;
using System;
using Json2CSharp;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public static class DynamicWeatherController
{
    private static string currenCity;

    private static GameplayData data;

    public static void Fetch(MonoBehaviour mono, City city, List<Api> api, Action<GameplayData> completed)
    {
        var weather = api.FirstOrDefault(a => a.name.Equals("weather"));

        var astronomy = api.FirstOrDefault(a => a.name.Equals("astronomy"));

        if (weather == null || astronomy == null)
        {
            return;
        }

        if (currenCity == city.name)
        {
            completed?.Invoke(data);
            
            return;
        }

        currenCity = city.name;

        mono.StartCoroutine(UNet.Fetch($"{weather.url}/data/2.5/weather?q={city.name},{city.country}&APPID={weather.key}&units=metric", (WeatherData wd) =>
        {
            mono.StartCoroutine(UNet.Fetch($"{astronomy.url}/astronomy?apiKey={astronomy.key}&lat={wd.coord.lat}&long={wd.coord.lon}", (AstronomyData ad) =>
            {
                data = new GameplayData(city.name,
                                        city.country,
                                        ad.sun_altitude,
                                        ad.sun_azimuth,
                                        wd.coord.lat,
                                        wd.coord.lon,
                                        wd.main.temp,
                                        wd.main.humidity,
                                        wd.wind.speed,
                                        wd.wind.deg,
                                        wd.clouds.all,
                                        wd.rain._1h,
                                        DateTime.UtcNow.AddHours(city.gmt));

                completed?.Invoke(data);
            }));
        }));
    }
}