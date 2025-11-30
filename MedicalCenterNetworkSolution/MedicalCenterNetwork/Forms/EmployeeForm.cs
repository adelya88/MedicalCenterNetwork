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

            // Для новых сотрудников устанавливаем текущий филиал по умолчанию
            if (!isEditMode)
            {
                comboBoxBranch.SelectedValue = UserSession.BranchID;
            }
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

                // Загрузка филиалов
                var branches = new[]
                {
                    new { ID = 1, Name = "Главный филиал" },
                    new { ID = 2, Name = "Северный филиал" },
                    new { ID = 3, Name = "Южный филиал" },
                    new { ID = 4, Name = "Западный филиал" }
                };
                comboBoxBranch.DataSource = branches;
                comboBoxBranch.DisplayMember = "Name";
                comboBoxBranch.ValueMember = "ID";

                // Автоматически выбираем филиал администратора для новых сотрудников
                if (!isEditMode)
                {
                    comboBoxBranch.SelectedValue = UserSession.BranchID;
                }

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

        private void LoadEmployeeData()
        {
            if (isEditMode)
            {
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

                if (employee.ID_branch > 0)
                {
                    comboBoxBranch.SelectedValue = employee.ID_branch;
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

            if (comboBoxBranch.SelectedValue == null)
            {
                errorProvider.SetError(comboBoxBranch, "Выберите филиал");
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
                employee.ID_branch = Convert.ToInt32(comboBoxBranch.SelectedValue);
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
                    ID_branch = @BranchID,
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
                new SQLiteParameter("@BranchID", employee.ID_branch),
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
                new SQLiteParameter("@BranchID", employee.ID_branch),
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