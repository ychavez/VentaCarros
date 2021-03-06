using SQLite;
using System;
using System.IO;
using VentaCarros2.DependencyServices;
using VentaCarros2.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace VentaCarros2.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            //declaramos el mobre de el archivo de base de datos
            string sqlFileName = "Cars.db3";
            //obtenemos la ruta de donde esta instalada la aplicacion
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // armamos la ruta completa con el archivo y la ruta
            string path = Path.Combine(docPath, sqlFileName);

            ///armamos la connection 
            SQLiteConnection conn = new SQLiteConnection(path);

            //regresamos el objeto
            return conn;

        }
    }
}