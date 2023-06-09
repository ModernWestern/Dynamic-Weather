using Utils;
using System;
using Json2CSharp;
using UnityEngine;
using System.Collections.Generic;

public class ModulesManager : MonoBehaviour
{
    public SunModule sun;

    public RainModule rain;

    public CloudsModule clouds;

    [Header("UI Modules"), Space] public InputModule input;

    public CityButtonsModule buttons;

    public ClockModule clock;

    private GameplayData gameplayData;

    private List<Api> api;

    private void Awake()
    {
        input.OnSet += (json, completed) => StartCoroutine(UNet.Fetch($"run.mocky.io/v3/{json}", (AppData data) =>
        {
            buttons.Populate(data.GetCitiesSortedByTime);

            api = data.api;
            
        }, completed));

        buttons.OnCityChange += city =>
        {
            DynamicWeatherController.Fetch(this, city, api, data =>
            {
                sun.Intensity = Tuple.Create(data.Location.WeatherDescription, data.Location.Clouds);

                sun.Position = new Vector2(data.Location.Altitude, data.Location.Azimuth);

                clouds.Direction = data.Location.WindAngle;

                clouds.Speed = data.Location.WindSpeed;

                clouds.Density = data.Location.Clouds;

                rain.OneHour = data.Location.Rain;

                gameplayData = data;

#if UNITY_EDITOR
                UDebug.ClearConsole();
#endif
                Debug.Log(data);
            });

            clock.City = city;
        };
    }

    // public void SetSunPosition(Transform directionalLight, float latitude, float longitude, DateTime time)
    // {
    //     var sunPosition = SunCalc.GetPosition(latitude, longitude, time);
    //
    //     var azimuth = sunPosition.y - 180;
    //
    //     var altitude = sunPosition.x;
    //
    //     directionalLight.rotation = Quaternion.Euler(altitude, azimuth, 0);
    // }
}