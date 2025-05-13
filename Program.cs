using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Insertar Cliente");
            Console.WriteLine("3. Actualizar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.WriteLine("5. Salir");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarClientes();
                    break;
                case "2":
                    InsertarCliente();
                    break;
                case "3":
                    ActualizarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void ListarClientes()
    {
        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            try
            {
                conn.Open(); // Abrir la conexión
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", conn); // Consulta SQL
                SqlDataReader reader = cmd.ExecuteReader(); // Ejecutar la consulta

                Console.WriteLine("\nClientes:");
                while (reader.Read()) // Iterar sobre los resultados
                {
                    string tipoPersona = reader["tipo"].ToString().ToLower();
                    ConsoleColor originalColor = Console.ForegroundColor;

                    if (tipoPersona == "juridica")
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (tipoPersona == "natural")
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"ID: {reader["id_cliente"]}, Nombre: {reader["nombre"]}, Tipo: {reader["tipo"]}");

                    Console.ForegroundColor = originalColor; // Restaurar color original
                }

                reader.Close(); // Cerrar el lector de datos
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al listar clientes: " + ex.Message);
            }
        }
    }

    static void InsertarCliente()
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el tipo de persona (Juridica/Natural): ");
        string tipoPersona = Console.ReadLine();

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Cliente (nombre, tipo) VALUES (@Nombre, @Tipo)", conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Tipo", tipoPersona);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("✅ Proceso correcto: Cliente insertado.");
                else
                    Console.WriteLine("❌ Error en el proceso de inserción.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al insertar cliente: " + ex.Message);
            }
        }
    }

    static void ActualizarCliente()
    {
        Console.Write("Ingrese el ID del cliente a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("❌ ID no válido.");
            return;
        }

        Console.Write("Ingrese el nuevo nombre del cliente: ");
        string nuevoNombre = Console.ReadLine();

        Console.Write("Ingrese el nuevo tipo de persona (Juridica/Natural): ");
        string nuevoTipoPersona = Console.ReadLine();

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Cliente SET nombre = @Nombre, tipo = @Tipo WHERE id_cliente = @Id", conn);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                cmd.Parameters.AddWithValue("@Tipo", nuevoTipoPersona);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("✅ Proceso correcto: Cliente actualizado.");
                else
                    Console.WriteLine("❌ Error en el proceso: No se encontró el cliente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al actualizar cliente: " + ex.Message);
            }
        }
    }

    static void EliminarCliente()
    {
        Console.Write("Ingrese el ID del cliente a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("❌ ID no válido.");
            return;
        }

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE id_cliente = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("✅ Proceso correcto: Cliente eliminado.");
                else
                    Console.WriteLine("❌ Error en el proceso: No se encontró el cliente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al eliminar cliente: " + ex.Message);
            }
        }
    }
}
