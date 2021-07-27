using Xamarin.Forms;

namespace VentaCarros2
{
    //creamos una vista con puro C#
    public class MainTabbedPage : TabbedPage
    {
        /// <summary>
        /// asignamos el titulo principal de nuestra tabbed page
        /// </summary>
        public MainTabbedPage()
        {
            Title = "Vende mi carro";
            Children.Add(new CarsForSale());
        }

    }
}
