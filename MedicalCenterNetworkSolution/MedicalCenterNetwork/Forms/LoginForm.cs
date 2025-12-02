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
using MedicalCenterNetwork.Services;
using MedicalCenterNetwork.Data;

namespace MedicalCenterNetwork.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Проверяем существование баз данных при запуске
            CheckDatabases();
        }

        private void CheckDatabases()
        {
            DatabaseManager.EnsureDatabaseDirectoryExists();

            if (!DatabaseManager.CheckAllDatabasesExist())
            {
                MessageBox.Show("Базы данных не найдены! Убедитесь, что файлы баз данных находятся в папке Databases.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(textBoxUsername.Text))
            {
                errorProvider.SetError(textBoxUsername, "Введите логин");
                return;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorProvider.SetError(textBoxPassword, "Введите пароль");
                return;
            }

            try
            {
                // Аутентификация пользователя
                var employee = AuthService.Authenticate(textBoxUsername.Text, textBoxPassword.Text);

                if (employee != null)
                {
                    // Сохраняем данные пользователя в сессии
                    UserSession.EmployeeID = employee.ID_employee;
                    UserSession.Login = employee.Login;
                    UserSession.FullName = employee.FullName;
                    UserSession.Position = employee.Position;
                    UserSession.BranchID = employee.ID_branch;

                    MessageBox.Show($"Добро пожаловать, {employee.FullName}!",
                        "Успешная авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Закрываем форму авторизации и открываем главную форму
                    this.Hide();
                    var mainForm = new MainForm(); // Создадим её на следующем шаге
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
