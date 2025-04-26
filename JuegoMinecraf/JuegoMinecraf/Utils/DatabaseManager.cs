using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace JuegoMinecraf.Utils
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            _connectionString = @"Data Source=FERNANDA\SQLEXPRESS;Initial Catalog=DBJUEGOEX;Integrated Security=True;TrustServerCertificate=True";
        }

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }

        public bool TestConnection()
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }
    }
}