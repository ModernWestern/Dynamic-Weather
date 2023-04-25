using System;

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

    public string City, Country;

    public DateTime Time;

    public override string ToString()
    {
        return $"Sun Altitude: {Altitude}, Sun Azimuth: {Azimuth}, Lat: {Latitude}, Long: {Longitude}, Temp: {Temp}, Humidity: {Humidity}, Wind speed: {WindSpeed}, Wind angle: {WindAngle}, Clouds: {Clouds}, Rain: {Rain}";
    }
}