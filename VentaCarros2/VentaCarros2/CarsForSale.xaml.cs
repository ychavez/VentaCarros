using System;
using System.Collections.Generic;
using System.Linq;
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
            LoadList();
            MessagingCenter.Subscribe<Page>(this, "UpdateList", messageCallBack);
        }

        private void messageCallBack(object obj)
            => LoadList();

        private void LoadList()
            => CarsList.ItemsSource = GetCars();

        public List<Car> GetCars()
            => new RestService().GetCars();

        private void ToolbarItem_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddCar());


        private void Button_Clicked(object sender, EventArgs e)
        => DisplayAlert("Auto favorito",
                new DatabaseManager().AddFavoriteCar((Car)((Button)sender).BindingContext)
                ? "Auto favorito agregado correctamente" : "El auto ya se encuentra en favoritos", "Ok");

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchCar.Text.ToUpper();

            var carsSearched = new RestService().GetCars()
                .Where(x => x.Model.ToUpper().Contains(searchText)
                            || x.Description.ToUpper().Contains(searchText)
                            || x.Brand.ToUpper().Contains(searchText));

            CarsList.ItemsSource = carsSearched;
        }
    }
}