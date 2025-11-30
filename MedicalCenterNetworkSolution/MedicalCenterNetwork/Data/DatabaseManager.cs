using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Data
{
    public static class DatabaseManager
    {
        private static string basePath = Path.Combine(Application.StartupPath, "Databases");

        // Словарь с путями ко всем базам данных
        public static Dictionary<string, string> DatabasePaths = new Dictionary<string, string>
        {
            { "Main", Path.Combine(basePath, "MainDatabase.db") },
            { "North", Path.Combine(basePath, "Branch_North.db") },
            { "South", Path.Combine(basePath, "Branch_South.db") },
            { "West", Path.Combine(basePath, "Branch_West.db") }
        };

        // Получение DatabaseHelper для конкретной базы
        public static DatabaseHelper GetDatabase(string databaseKey)
        {
            if (DatabasePaths.ContainsKey(databaseKey))
            {
                return new DatabaseHelper(DatabasePaths[databaseKey]);
            }
            throw new ArgumentException($"База данных с ключом '{databaseKey}' не найдена");
        }

        // Получение DatabaseHelper для главной базы
        public static DatabaseHelper GetMainDatabase()
        {
            return GetDatabase("Main");
        }

        // Получение DatabaseHelper для базы текущего филиала пользователя
        public static DatabaseHelper GetCurrentBranchDatabase()
        {
            // Используем базу данных в зависимости от филиала пользователя
            switch (UserSession.BranchID)
            {
                case 1: return GetDatabase("Main");
                case 2: return GetDatabase("North");
                case 3: return GetDatabase("South");
                case 4: return GetDatabase("West");
                default: return GetMainDatabase();
            }
        }

        // Проверка существования всех баз данных
        public static bool CheckAllDatabasesExist()
        {
            foreach (var path in DatabasePaths.Values)
            {
                if (!File.Exists(path))
                {
                    return false;
                }
            }
            return true;
        }

        // Создание папки для баз данных, если её нет
        public static void EnsureDatabaseDirectoryExists()
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        // Метод для получения медицинских услуг из главной базы
        public static DataTable GetMedicalServices()
        {
            var mainDb = GetMainDatabase();
            string query = "SELECT ID_service, Name, Duration_minutes, Base_cost FROM MedicalServices ORDER BY Name";
            return mainDb.ExecuteQuery(query);
        }
    }
}
