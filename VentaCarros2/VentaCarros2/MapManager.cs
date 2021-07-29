using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace VentaCarros2
{
    public class MapManager
    {
        /// <summary>
        /// Transforma un objeto de tipo position proviniente de el paquete nuguen xam.plugin.geolocator a un objeto
        /// tipo Xamarin.Forms.Position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Position GetXamPosition(Plugin.Geolocator.Abstractions.Position position)
            => new Position(position.Latitude, position.Longitude);


        public Map GetMap(bool currentPosition, Position position, Circle circle = null, List<Pin> pins = null)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(30));
            var map = new Map(mapSpan);

            map.IsShowingUser = currentPosition;


            if (circle != null)
                map.MapElements.Add(circle);

            if (pins != null)
                pins.ForEach(x => map.Pins.Add(x));

            return map;
        }






    }
}
