using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VentaCarros2.Models;

namespace VentaCarros2.Context
{
    public class RestService
    {
        private HttpClient _client;
        private Uri _urlBase;

        public RestService()
        {
            _urlBase = new Uri("https://productsapidw.azurewebsites.net/");
            _client = new HttpClient();
            _client.BaseAddress = _urlBase;
        }

        public List<Car> GetCars() 
        {
            var response = _client.GetAsync("api/carsForSalesApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Car>>(content);
            }

            throw new Exception("Error al tratar de obtener la informacion");
        }


    }
}
