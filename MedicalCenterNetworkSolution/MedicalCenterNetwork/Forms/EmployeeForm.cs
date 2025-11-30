using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalCenterNetwork.Models;
using MedicalCenterNetwork.Data;
using System.Data.SQLite;

namespace MedicalCenterNetwork.Forms
{
    public partial class EmployeeForm : Form
    {
        private Employee employee;
        private DatabaseHelper db;
        private bool isEditMode;

        public EmployeeForm(Employee existingEmployee = null)
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            employee = existingEmployee ?? new Employee();
            isEditMode = existingEmployee != null;

            LoadComboBoxData(); // ПЕРЕНЕСЕМ ЭТОТ ВЫЗОВ В НАЧАЛО
            InitializeForm();
            LoadEmployeeData();
        }

        private void InitializeForm()
        {
            this.Text = isEditMode ? "Редактирование сотрудника" : "Добавление сотрудника";
            buttonSave.Text = isEditMode ? "Сохранить" : "Добавить";

            // Скрываем поле пароля при редактировании
            if (isEditMode)
            {
                labelPassword.Visible = false;
                textBoxPassword.Visible = false;
            }

            // Добавляем подсказку для филиала
            labelBranch.Text = "Филиал: (текущий)";

            // Или можно добавить ToolTip
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(comboBoxBranch, "Филиал нельзя изменить. Сотрудник всегда привязан к вашему филиалу.");
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Загрузка специализаций из главной базы
                var specializations = DatabaseManager.GetSpecializations();
                comboBoxSpecialization.DataSource = specializations;
                comboBoxSpecialization.DisplayMember = "Name";
                comboBoxSpecialization.ValueMember = "ID_specialization";

                // ЗАГРУЗКА ФИЛИАЛОВ - ИЗМЕНЕНИЯ ЗДЕСЬ
                // ДЛЯ ВСЕХ СЛУЧАЕВ (добавление и редактирование) показываем только текущий филиал
                var currentBranch = new[]
                {
            new { ID = UserSession.BranchID, Name = GetCurrentBranchName(UserSession.BranchID) }
        };
                comboBoxBranch.DataSource = currentBranch;
                comboBoxBranch.DisplayMember = "Name";
                comboBoxBranch.ValueMember = "ID";
                comboBoxBranch.Enabled = false; // Всегда блокируем выбор филиала

                // Должности
                comboBoxPosition.Items.AddRange(new string[] { "Врач", "Медсестра", "Администратор" });

                // Статус активности
                comboBoxStatus.Items.AddRange(new string[] { "Активен", "Неактивен" });
                comboBoxStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCurrentBranchName(int branchId)
        {
            try
            {
                // Пытаемся получить название филиала из главной базы
                var mainDb = DatabaseManager.GetMainDatabase();
                string query = "SELECT Name FROM Branches WHERE ID_branch = @BranchID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", branchId)
                };

                var result = mainDb.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки используем резервные названия
                Console.WriteLine($"Ошибка при получении названия филиала: {ex.Message}");
            }

            // Резервные названия по ID
            switch (branchId)
            {
                case 1: return "Главный филиал";
                case 2: return "Северный филиал";
                case 3: return "Южный филиал";
                case 4: return "Западный филиал";
                default: return $"Филиал {branchId}";
            }
        }

        private void LoadEmployeeData()
        {
            if (isEditMode)
            {
                // Убедимся, что администратор редактирует сотрудника только из своего филиала
                if (employee.ID_branch != UserSession.BranchID)
                {
                    MessageBox.Show("Вы не можете редактировать сотрудников из других филиалов.",
                        "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                textBoxLastName.Text = employee.LastName;
                textBoxFirstName.Text = employee.FirstName;
                textBoxMiddleName.Text = employee.MiddleName;
                comboBoxPosition.Text = employee.Position;
                textBoxLogin.Text = employee.Login;
                comboBoxStatus.Text = employee.IsActive ? "Активен" : "Неактивен";

                if (employee.ID_specialization > 0)
                {
                    comboBoxSpecialization.SelectedValue = employee.ID_specialization;
                }
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                errorProvider.SetError(textBoxLastName, "Введите фамилию");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                errorProvider.SetError(textBoxFirstName, "Введите имя");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxMiddleName.Text))
            {
                errorProvider.SetError(textBoxMiddleName, "Введите отчество");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxPosition.Text))
            {
                errorProvider.SetError(comboBoxPosition, "Выберите должность");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                errorProvider.SetError(textBoxLogin, "Введите логин");
                isValid = false;
            }

            // Пароль обязателен только при создании нового сотрудника
            if (!isEditMode && string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                errorProvider.SetError(textBoxPassword, "Введите пароль");
                isValid = false;
            }

            return isValid;
        }

        private void SaveEmployee()
        {
            try
            {
                employee.LastName = textBoxLastName.Text.Trim();
                employee.FirstName = textBoxFirstName.Text.Trim();
                employee.MiddleName = textBoxMiddleName.Text.Trim();
                employee.Position = comboBoxPosition.Text;
                employee.Login = textBoxLogin.Text.Trim();
                employee.ID_specialization = comboBoxSpecialization.SelectedValue != null ?
                    Convert.ToInt32(comboBoxSpecialization.SelectedValue) : 0;

                // Для всех случаев используем текущий филиал
                employee.ID_branch = UserSession.BranchID; // Всегда текущий филиал

                employee.IsActive = comboBoxStatus.Text == "Активен";

                string query;
                SQLiteParameter[] parameters;

                if (isEditMode)
                {
                    query = @"
                    UPDATE Employees 
                    SET LastName = @LastName, 
                        FirstName = @FirstName, 
                        MiddleName = @MiddleName,
                        Position = @Position,
                        Login = @Login,
                        ID_specialization = @SpecializationID,
                        ID_branch = @BranchID,  -- Все равно обновляем, но значение то же самое
                        IsActive = @IsActive
                    WHERE ID_employee = @ID_employee";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@LastName", employee.LastName),
                        new SQLiteParameter("@FirstName", employee.FirstName),
                        new SQLiteParameter("@MiddleName", employee.MiddleName),
                        new SQLiteParameter("@Position", employee.Position),
                        new SQLiteParameter("@Login", employee.Login),
                        new SQLiteParameter("@SpecializationID", employee.ID_specialization > 0 ?
                            (object)employee.ID_specialization : DBNull.Value),
                        new SQLiteParameter("@BranchID", employee.ID_branch), // Текущий филиал
                        new SQLiteParameter("@IsActive", employee.IsActive ? 1 : 0),
                        new SQLiteParameter("@ID_employee", employee.ID_employee)
                    };
                }
                else
                {
                    query = @"
                    INSERT INTO Employees (
                        ID_branch, LastName, FirstName, MiddleName, 
                        ID_specialization, Position, Login, Password, IsActive
                    ) VALUES (
                        @BranchID, @LastName, @FirstName, @MiddleName,
                        @SpecializationID, @Position, @Login, @Password, @IsActive
                    )";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@BranchID", employee.ID_branch), // Текущий филиал
                        new SQLiteParameter("@LastName", employee.LastName),
                        new SQLiteParameter("@FirstName", employee.FirstName),
                        new SQLiteParameter("@MiddleName", employee.MiddleName),
                        new SQLiteParameter("@SpecializationID", employee.ID_specialization > 0 ?
                            (object)employee.ID_specialization : DBNull.Value),
                        new SQLiteParameter("@Position", employee.Position),
                        new SQLiteParameter("@Login", employee.Login),
                        new SQLiteParameter("@Password", textBoxPassword.Text), // Пароль только при создании
                        new SQLiteParameter("@IsActive", employee.IsActive ? 1 : 0)
                    };
                }

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show(isEditMode ? "Данные сотрудника успешно обновлены!" : "Сотрудник успешно добавлен!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сотрудника: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveEmployee();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем/скрываем специализацию в зависимости от должности
            bool isDoctor = comboBoxPosition.Text == "Врач";
            labelSpecialization.Visible = isDoctor;
            comboBoxSpecialization.Visible = isDoctor;

            if (!isDoctor)
            {
                comboBoxSpecialization.SelectedIndex = -1;
            }
        }
    }
}