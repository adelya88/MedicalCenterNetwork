using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Data
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string databasePath)
        {
            connectionString = $"Data Source={databasePath};Version=3;";
        }

        // Основной метод для выполнения запросов без возврата данных
        public int ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Метод для выполнения запросов с возвратом скалярного значения
        public object ExecuteScalar(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteScalar();
                }
            }
        }

        // Метод для выполнения запросов с возвратом DataTable
        public DataTable ExecuteQuery(string query, SQLiteParameter[] parameters = null)
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        // Проверка подключения к базе данных
        public bool TestConnection()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
