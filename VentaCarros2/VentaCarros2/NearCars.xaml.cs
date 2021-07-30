using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaCarros2.Context;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace VentaCarros2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearCars : ContentPage
    {
        private readonly MapManager mapManager;

        public NearCars()
        {
            InitializeComponent();
            mapManager = new MapManager();
        }
        private async void setMapCars()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;
            var position = await locator.GetPositionAsync();

            List<Pin> pins = new List<Pin>();

            new RestService().GetCars().ForEach(x =>
            {

                if (!(x.Lon == null || x.Lat == null))
                {
                    pins.Add(new Pin
                    {
                        Type = PinType.SearchResult,
                        Label = x.Model,
                        Address = x.Description,
                        Position = new Position(x.Lat.Value, x.Lon.Value)
                    });
                }
            });


            var circle = new Circle
            {
                Center = new Position(position.Latitude, position.Longitude),
                Radius = new Distance(10000),
                StrokeColor = Color.Aqua,
                StrokeWidth = 8,
                FillColor = Color.Blue
            };


            Content = mapManager.GetMap(true, new Position(position.Latitude, position.Longitude), circle, pins);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            setMapCars();
        }

    }
}