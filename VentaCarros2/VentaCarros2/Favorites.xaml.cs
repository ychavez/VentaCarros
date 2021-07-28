using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaCarros2.Context;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaCarros2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData() 
        {
            CarsList.ItemsSource = null;
            CarsList.ItemsSource = new DatabaseManager().GetFavoriteCars();

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }
    }
}