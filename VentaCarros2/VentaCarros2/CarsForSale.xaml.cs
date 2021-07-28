using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaCarros2.Context;
using VentaCarros2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaCarros2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsForSale : ContentPage
    {

        public CarsForSale()
        {
            InitializeComponent();
            CarsList.ItemsSource = GetCars();
        }

        public List<Car> GetCars()
            => new RestService().GetCars();

        private void ToolbarItem_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddCar());


        private void Button_Clicked(object sender, EventArgs e)
        => DisplayAlert("Auto favorito",
                new DatabaseManager().AddFavoriteCar((Car)((Button)sender).BindingContext)
                ? "Auto favorito agregado correctamente" : "El auto ya se encuentra en favoritos", "Ok");

    }
}