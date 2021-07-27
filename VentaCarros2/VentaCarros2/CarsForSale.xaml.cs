using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            => new List<Car>()
                    {
                        new Car
                        {
                          Brand = "Chevrolet" ,
                          Description ="Camaro bonito un solo dueño",
                          Model ="Camaro", 
                          Price = 10000.00M,
                          Year = 2016,
                          PhotoUrl="https://media.wired.com/photos/5d09594a62bcb0c9752779d9/1:1/w_1500,h_1500,c_limit/Transpo_G70_TA-518126.jpg"
                        },
                        new Car
                        {
                          Brand = "Ford" ,
                          Description ="Mutang bonito un solo dueño",
                          Model ="Mustang", 
                          Price = 9000.00M,
                          Year = 2015,
                          PhotoUrl="https://media.wired.com/photos/5d09594a62bcb0c9752779d9/1:1/w_1500,h_1500,c_limit/Transpo_G70_TA-518126.jpg"
                        }
                    };

        private void ToolbarItem_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddCar());
       
    }
}