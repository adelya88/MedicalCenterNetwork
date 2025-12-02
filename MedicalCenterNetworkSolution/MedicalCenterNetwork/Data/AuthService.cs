using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MedicalCenterNetwork.Models;
using MedicalCenterNetwork.Data;
using System.Data.SQLite;

namespace MedicalCenterNetwork.Services
{
    public class AuthService
    {
        public static Employee Authenticate(string login, string password)
        {

            // Сначала проверяем главную базу (там есть таблица Branches)
            var mainDb = DatabaseManager.GetDatabase("Main");

            // Получаем список всех филиалов из главной базы
            var branchesQuery = "SELECT ID_branch, Name FROM Branches";
            var branchesTable = mainDb.ExecuteQuery(branchesQuery);
            var branches = new Dictionary<int, string>();

            foreach (DataRow row in branchesTable.Rows)
            {
                branches[Convert.ToInt32(row["ID_branch"])] = row["Name"].ToString();
            }

            // Проверяем во всех базах данных
            var databases = new Dictionary<string, DatabaseHelper>
    {
        { "Main", DatabaseManager.GetDatabase("Main") },
        { "North", DatabaseManager.GetDatabase("North") },
        { "South", DatabaseManager.GetDatabase("South") },
        { "West", DatabaseManager.GetDatabase("West") }
    };

            foreach (var dbPair in databases)
            {
                try
                {

                    var db = dbPair.Value;

                    string query = @"
                SELECT e.*
                FROM Employees e 
                WHERE e.Login = @Login AND e.Password = @Password AND e.IsActive = 1";

                    var parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@Login", login),
                new SQLiteParameter("@Password", password)
                    };

                    var result = db.ExecuteQuery(query, parameters);

                    if (result.Rows.Count > 0)
                    {
                        var row = result.Rows[0];
                        var employee = new Employee
                        {
                            ID_employee = Convert.ToInt32(row["ID_employee"]),
                            ID_branch = Convert.ToInt32(row["ID_branch"]),
                            LastName = row["LastName"].ToString(),
                            FirstName = row["FirstName"].ToString(),
                            MiddleName = row["MiddleName"].ToString(),
                            ID_specialization = row["ID_specialization"] != DBNull.Value ? Convert.ToInt32(row["ID_specialization"]) : (int?)null,
                            Position = row["Position"].ToString(),
                            Login = row["Login"].ToString(),
                            Password = row["Password"].ToString()
                        };

                        // Определяем название филиала
                        if (branches.ContainsKey(employee.ID_branch))
                        {
                            UserSession.BranchName = branches[employee.ID_branch];
                        }
                        else
                        {
                            UserSession.BranchName = $"Филиал {dbPair.Key}";
                        }

                        return employee;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при проверке базы {dbPair.Key}: {ex.Message}");
                    continue;
                }
            }

            return null;
        }
    }
}
