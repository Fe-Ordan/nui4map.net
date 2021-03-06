using System.Windows;
using MapUtils.Converter;
using MapUtils.Distance;
using MapUtils.Structs;
using Telerik.Windows.Controls.Map;

namespace TelerikMapCommons.Extensions
{
    public static class TelerikMapExtensions
    {

        public static double DistanceFrom(this Location point1, Location point2)
        {
            return new Point(point1.Longitude, point1.Latitude).DistanceFrom(new Point(point2.Longitude, point2.Latitude));
        }

        public static MapCoord ToMapCoord(this Location mapPoint)
        {
            var mapCoord = new MapCoord {Latitude = mapPoint.Latitude, 
                                         Longitude = mapPoint.Longitude,
                                         ProjectionWkid = CoordinateSystems.Wgs84ProjectionWkid};
            return mapCoord;
        }

        
    } 

}

