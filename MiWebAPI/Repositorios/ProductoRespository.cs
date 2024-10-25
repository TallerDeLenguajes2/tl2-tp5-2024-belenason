using Microsoft.Data.Sqlite;
class ProductoRespository
{
    public void CrearProducto(Productos producto)
    {
        string connectionString = @"Data Source = ../Tienda.db;Cache=Shared";

        string query = $"INSERT INTO productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.ExecuteNonQuery();
            connection.Close();
            
        }

    }

}