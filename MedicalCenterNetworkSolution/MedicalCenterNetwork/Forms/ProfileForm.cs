using System;
using System.Data.SQLite;
using System.Windows.Forms;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class ProfileForm : Form
    {
        private DatabaseHelper db;
        private Employee currentEmployee;

        public ProfileForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();

            // Получаем ID пользователя из сессии
            int employeeId = UserSession.EmployeeID;

            if (employeeId > 0)
            {
                LoadUserProfile(employeeId);
                DisplayProfile();
            }
            else
            {
                MessageBox.Show("Не удалось определить пользователя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadUserProfile(int employeeId)
        {
            try
            {
                // Загружаем данные текущего пользователя
                string query = @"
                    SELECT 
                        e.ID_employee,
                        e.ID_branch,
                        e.LastName,
                        e.FirstName,
                        e.MiddleName,
                        e.ID_specialization,
                        e.Position,
                        e.Login,
                        e.IsActive
                    FROM Employees e
                    WHERE e.ID_employee = @EmployeeID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@EmployeeID", employeeId)
                };

                var dataTable = db.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];

                    currentEmployee = new Employee
                    {
                        ID_employee = Convert.ToInt32(row["ID_employee"]),
                        ID_branch = Convert.ToInt32(row["ID_branch"]),
                        LastName = row["LastName"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        Position = row["Position"].ToString(),
                        Login = row["Login"].ToString(),
                        IsActive = Convert.ToBoolean(row["IsActive"])
                    };

                    if (row["ID_specialization"] != DBNull.Value)
                    {
                        currentEmployee.ID_specialization = Convert.ToInt32(row["ID_specialization"]);
                    }

                    LoadAdditionalInfo();
                }
                else
                {
                    MessageBox.Show("Профиль пользователя не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке профиля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdditionalInfo()
        {
            try
            {
                // Загружаем специализацию, если она есть
                if (currentEmployee.ID_specialization.HasValue && currentEmployee.ID_specialization > 0)
                {
                    var mainDb = DatabaseManager.GetMainDatabase();
                    string query = "SELECT Name FROM Specializations WHERE ID_specialization = @SpecializationID";
                    var parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@SpecializationID", currentEmployee.ID_specialization.Value)
                    };

                    var result = mainDb.ExecuteQuery(query, parameters);
                    if (result.Rows.Count > 0)
                    {
                        currentEmployee.SpecializationName = result.Rows[0]["Name"].ToString();
                    }
                }

                // Загружаем информацию о филиале
                var mainDb2 = DatabaseManager.GetMainDatabase();
                string branchQuery = "SELECT Name FROM Branches WHERE ID_branch = @BranchID";
                var branchParameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", currentEmployee.ID_branch)
                };

                var branchResult = mainDb2.ExecuteQuery(branchQuery, branchParameters);
                if (branchResult.Rows.Count > 0)
                {
                    currentEmployee.BranchName = branchResult.Rows[0]["Name"].ToString();
                }
                else
                {
                    // Резервные названия
                    currentEmployee.BranchName = GetBranchName(currentEmployee.ID_branch);
                }

                // Устанавливаем статус
                currentEmployee.Status = currentEmployee.IsActive ? "Активен" : "Неактивен";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке дополнительной информации: {ex.Message}");
            }
        }

        private string GetBranchName(int branchId)
        {
            switch (branchId)
            {
                case 1: return "Главный филиал";
                case 2: return "Северный филиал";
                case 3: return "Южный филиал";
                case 4: return "Западный филиал";
                default: return $"Филиал {branchId}";
            }
        }

        private void DisplayProfile()
        {
            if (currentEmployee == null)
                return;

            // Основная информация
            labelFullName.Text = currentEmployee.FullName;
            labelPosition.Text = currentEmployee.Position;
            labelLogin.Text = currentEmployee.Login;
            labelBranch.Text = currentEmployee.BranchName ?? "Не указан";
            labelStatus.Text = currentEmployee.Status;
            labelEmployeeID.Text = currentEmployee.ID_employee.ToString();

            // Специализация
            if (!string.IsNullOrEmpty(currentEmployee.SpecializationName))
            {
                labelSpecialization.Text = currentEmployee.SpecializationName;
            }
            else
            {
                labelSpecialization.Text = "Не указана";
            }

            // Обновляем заголовок формы
            this.Text = $"Профиль - {currentEmployee.FullName}";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // Можно добавить дополнительные настройки при загрузке формы
        }

        // Дополнительный конструктор для просмотра профиля другого сотрудника (для администратора)
        public ProfileForm(int employeeId) : this()
        {
            // Если передали конкретный ID, загружаем его профиль
            if (employeeId > 0 && employeeId != UserSession.EmployeeID)
            {
                LoadUserProfile(employeeId);
                DisplayProfile();
                this.Text = $"Профиль сотрудника - {currentEmployee.FullName}";
            }
        }
    }
}