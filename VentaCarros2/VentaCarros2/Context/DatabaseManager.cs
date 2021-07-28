using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VentaCarros2.DependencyServices;
using VentaCarros2.Models;
using Xamarin.Forms;

namespace VentaCarros2.Context
{
    public class DatabaseManager
    {
        private SQLiteConnection db;

        public DatabaseManager()
        {
            //obtenemos la connection de la plataforma en uso
            db = DependencyService.Get<ISQLite>().GetConnection();

            if (!TableExists("Car"))
                db.CreateTable<Car>();

            //Application.Current.Properties["Rating"] = 10;
            //int Rating;
            //if (Application.Current.Properties.ContainsKey("Rating"))
            //    Rating = (int)Application.Current.Properties["Rating"];
          
        }
        /// <summary>
        /// nos regresa la lista de coches marcados como favoritos desde la tabla Car
        /// </summary>
        /// <returns></returns>
        public List<Car> GetFavoriteCars() 
        {

            var cars = db.Query<Car>("Select * from car");

            var ServiceCars = new RestService().GetCars();

            var soldCards = cars.Where(x => 
                     !ServiceCars.Any(c => c.Id == x.Id) ).ToList();

            foreach (var car in soldCards)
            {
                db.Delete<Car>(car.Id);
            }

            return db.Query<Car>("Select * from car");

        }

        private object RestService()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// valida si el carro no existe ya en la tabla y lo inserta
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool AddFavoriteCar(Car car)
        {
            if (db.Query<Car>($"select * from car where id = {car.Id}").Count == 0)
            {
                db.Insert(car);
                return true;
            }
            else
                return false;

        }



        /// <summary>
        /// Valida si la tabla exista en la base de datos
        /// </summary>
        /// <param name="tableName">Nombre de la tabla</param>
        /// <returns></returns>
        private bool TableExists(string tableName)
        {
            TableMapping map = new TableMapping(typeof(SqlDbType));

            object[] ps = new object[0];

            int tableCount =
                db.Query(map, "select * from sqlite_master where type = 'table' and name = '" + tableName + "'", ps).Count;

            if (tableCount == 0)
                return false;
            else if (tableCount == 1)
                return true;
            else
                throw new Exception($"Hay mas de una tabla con este nombre {tableName} en la base de datos");

        }
    }
}
