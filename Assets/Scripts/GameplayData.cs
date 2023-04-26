using Utils;
using System;
using Json2CSharp;

public class GameplayData
{
    public readonly LocationData Location;

    public GameplayData(string city,
                        string country,
                        float altitude,
                        float azimuth,
                        float lat,
                        float lon,
                        float temp,
                        float humidity,
                        float windSpeed,
                        float windDeg,
                        float clouds,
                        float rain,
                        string weatherDescription,
                        DateTime time)
    {
        Location.City = city;
        Location.Country = country;
        Location.Altitude = altitude;
        Location.Azimuth = azimuth;
        Location.Latitude = lat;
        Location.Longitude = lon;
        Location.Temp = temp;
        Location.Humidity = humidity;
        Location.WindSpeed = windSpeed;
        Location.WindAngle = windDeg;
        Location.Clouds = clouds;
        Location.Rain = rain;
        Location.WeatherDescription = weatherDescription.ToEnum<Weather.Description>();
        Location.Time = time;
    }

    public override string ToString()
    {
        return Location.ToString();
    }
}

public struct LocationData
{
    public float Altitude, Azimuth, Latitude, Longitude, Temp, Humidity, WindSpeed, WindAngle, Clouds, Rain;

    public Weather.Description WeatherDescription;

    public string City, Country;

    public DateTime Time;

    public string Name => $"{City.ToFirstUpper()},{Country.ToUpper()}";

    public override string ToString()
    {
        return $"<color=yellow>[{Name}]</color> Temp: {Temp}, Wind speed: {WindSpeed}, Wind angle: {WindAngle}, Clouds: {Clouds}, Rain: {Rain}, Weather Description: {WeatherDescription}";
    }
}