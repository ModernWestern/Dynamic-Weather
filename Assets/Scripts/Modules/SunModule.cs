using Utils;
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
    
    public float Intensity
    {
        set
        {
            Color.RGBToHSV(dayLight, out color.x, out color.y, out _);

            color.z = value.LogarithmicMap(0, 100, 1, 0, 3);

            light.color = Color.HSVToRGB(color.x, color.y, color.z);
        }
    }
}