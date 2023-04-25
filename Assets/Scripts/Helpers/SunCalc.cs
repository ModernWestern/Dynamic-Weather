using System;
using UnityEngine;

namespace Mourner
{
    public static class SunCalc
    {
        public static Vector2 GetPosition(double latitude, double longitude, DateTime time)
        {
            // Convert latitude and longitude to radians
            double latRad = latitude * Math.PI / 180.0;
            double longRad = longitude * Math.PI / 180.0;

            // Calculate the Julian day
            int a = (14 - time.Month) / 12;
            int y = time.Year + 4800 - a;
            int m = time.Month + 12 * a - 3;
            int jday = time.Day + (153 * m + 2) / 5 + 365 * y + y / 4 - y / 100 + y / 400 - 32045;

            // Calculate the Julian century
            double T = (jday - 2451545.0) / 36525.0;

            // Calculate the sun's mean longitude and anomaly
            double L0 = 280.46646 + 36000.76983 * T + 0.0003032 * T * T;
            double M = 357.52911 + 35999.05029 * T - 0.0001537 * T * T;

            // Convert to radians
            L0 = L0 * Math.PI / 180.0;
            M = M * Math.PI / 180.0;

            // Calculate the sun's ecliptic longitude
            double C = (1.914602 - 0.004817 * T - 0.000014 * T * T) * Math.Sin(M) +
                       (0.019993 - 0.000101 * T) * Math.Sin(2 * M) +
                       0.000289 * Math.Sin(3 * M);
            double lambda = L0 + M + C;

            // Calculate the sun's declination
            double epsilon = 23.4392911 * Math.PI / 180.0; // Obliquity of the ecliptic for J2000.0
            double delta = Math.Asin(Math.Sin(epsilon) * Math.Sin(lambda));

            // Calculate the hour angle
            double h = (time.Hour + time.Minute / 60.0 + time.Second / 3600.0 - 12) * 15 * Math.PI / 180.0;

            // Calculate the sun's altitude and azimuth
            double sinAlt = Math.Sin(latRad) * Math.Sin(delta) + Math.Cos(latRad) * Math.Cos(delta) * Math.Cos(h);
            double altitude = Math.Asin(sinAlt);
            double cosAz = (Math.Sin(delta) - Math.Sin(latRad) * sinAlt) / (Math.Cos(latRad) * Math.Cos(altitude));
            double azimuth = Math.Acos(cosAz);
            if (Math.Sin(h) > 0)
            {
                azimuth = 2 * Math.PI - azimuth;
            }

            azimuth = azimuth * 180.0 / Math.PI;
            altitude = altitude * 180.0 / Math.PI;

            return new Vector2((float)altitude, (float)azimuth);
        }
    }
}