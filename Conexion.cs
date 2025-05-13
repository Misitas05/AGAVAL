using System.Data.SqlClient;

public class Conexion
{
    // Cadena de conexión con la base de datos
    private static string cadena = @"Server=DESKTOP-UP918BR\SQLEXPRESS;Database=AGAVAL;Trusted_Connection=True;";

    // Método estático para obtener la conexión
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(cadena);
    }
}
