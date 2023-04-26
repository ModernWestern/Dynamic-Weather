using Utils;
using System;
using Json2CSharp;
using UnityEngine;

public class SunModule : MonoBehaviour
{
    public new Light light;

    private Color dayLight;

    private Vector3 color;

    private void Awake()
    {
        dayLight = light.color;
    }

    /// <summary>
    /// Altitude, Azimuth
    /// </summary>
    public Vector2 Position
    {
        set => transform.rotation = Quaternion.Euler(value.x, value.y, 0);
    }

    public Tuple<Weather.Description, float> Intensity
    {
        set
        {
            Color.RGBToHSV(dayLight, out color.x, out color.y, out _);

            color.z = CalcSunIntensity(value.Item1, value.Item2).LogarithmicMap(0, 100, 1, 0, 3);

            light.color = Color.HSVToRGB(color.x, color.y, color.z);
        }
    }

    private static float CalcSunIntensity(Weather.Description description, float clouds)
    {
        float intensity;

        switch (description)
        {
            case Weather.Description.Fog:
            case Weather.Description.Haze:
                intensity = clouds * 1.2f;
                break;
            case Weather.Description.Rain:
            case Weather.Description.Thunderstorm:
                intensity = clouds * 1.3f;
                break;
            case Weather.Description.Clouds:
                intensity = clouds >= 40 ? Mathf.Clamp(clouds * 1.45f, 0f, 95f) : clouds;
                break;
            case Weather.Description.Clear:
            default:
                intensity = clouds;
                break;
        }

        return Mathf.Clamp(intensity, 0f, 100f);
    }
}