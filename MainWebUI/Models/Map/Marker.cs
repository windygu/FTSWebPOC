using System;

namespace FTS.MainWebUI.Models
{
    public class Marker
    {
        public Marker(double latitude, double longitude, string name)
        {
            LatLng = new double[] { latitude, longitude };
            Name = name;
        }

        public double[] LatLng { get; set; }
        public string Name { get; set; }
    }
}
