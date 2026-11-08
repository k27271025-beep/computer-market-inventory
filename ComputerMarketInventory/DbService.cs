// =====================================================================
// ФАЙЛ: DbService.cs
// =====================================================================
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ComputerMarketInventory
{
    public static class DbService
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>Возвращает открытое соединение. Использовать в using().</summary>
        public static IDbConnection GetConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>Быстрая проверка связи.</summary>
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}