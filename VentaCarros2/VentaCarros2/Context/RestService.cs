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
        /// <summary>
        /// Inserta en el servicio un coche nuevo
        /// </summary>
        /// <param name="car"></param>
        public void SetCar(Car car) 
        {
            var json = JsonConvert.SerializeObject(car);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("api/carsForSalesApi", data).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al tratar de enviar la informacion al servicio web");
            }      
        }
    }
}
