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
            
            new RestService().SetCar( new Car
                {
                    Brand = txtMarca.Text,
                    Description = txtDescripcion.Text,
                    Model = txtModelo.Text,
                    Price = decimal.Parse(txtPrecio.Text),
                    Year = int.Parse(txtAnno.Text),
                    PhotoUrl = "https://images.segundamano.mx/api/v1/smmx/images/50/5085090212.jpg?rule=web_gallery_1x"
            });
           await DisplayAlert("Agregado", "El auto se ha agregado", "Aceptar");

            MessagingCenter.Send<Page>(this, "UpdateList");

           await Navigation.PopAsync();
        }
    }
}