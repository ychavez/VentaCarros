using Plugin.Geolocator;
using Plugin.Media.Abstractions;
using System;
using VentaCarros2.Context;
using VentaCarros2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaCarros2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var position = await locator.GetPositionAsync();

            var car = new Car
            {
                Brand = txtMarca.Text,
                Description = txtDescripcion.Text,
                Model = txtModelo.Text,
                Price = decimal.Parse(txtPrecio.Text),
                Year = int.Parse(txtAnno.Text),
                PhotoUrl = "https://images.segundamano.mx/api/v1/smmx/images/50/5085090212.jpg?rule=web_gallery_1x",
                Lat = position.Latitude,
                Lon = position.Longitude
            };

            if (validarObjeto(car))
            {
                new RestService().SetCar(new Car
                {
                    Brand = txtMarca.Text,
                    Description = txtDescripcion.Text,
                    Model = txtModelo.Text,
                    Price = decimal.Parse(txtPrecio.Text),
                    Year = int.Parse(txtAnno.Text),
                    PhotoUrl = "https://images.segundamano.mx/api/v1/smmx/images/50/5085090212.jpg?rule=web_gallery_1x",
                    Lat = position.Latitude,
                    Lon = position.Longitude
                });
                await DisplayAlert("Agregado", "El auto se ha agregado", "Aceptar");

                MessagingCenter.Send<Page>(this, "UpdateList");

                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("revise la informacion", "Es necesario llenar todos los campos","aceptar");
        }

        private bool validarObjeto(Car car)
        {
            return !string.IsNullOrWhiteSpace(car.Description);
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {

            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable && Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = false,
                    SaveMetaData = false
                });

                if (photo != null)
                {
                    img.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                }

            }

        }
    }
}