using SQLite;

namespace VentaCarros2.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
