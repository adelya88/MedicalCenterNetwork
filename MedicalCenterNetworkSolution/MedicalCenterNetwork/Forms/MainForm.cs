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

namespace MedicalCenterNetwork.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Устанавливаем заголовок с информацией о пользователе
            this.Text = $"Медицинская сеть - Главная | Пользователь: {UserSession.FullName} | Должность: {UserSession.Position} | Филиал: {UserSession.BranchID}";

            // Настраиваем видимость меню в зависимости от роли пользователя
            ConfigureMenuByRole();
        }

        private void ConfigureMenuByRole()
        {
            // Сначала скрываем все меню
            administrationToolStripMenuItem.Visible = false;
            patientsToolStripMenuItem.Visible = false;
            scheduleToolStripMenuItem.Visible = false;
            medicalRecordsToolStripMenuItem.Visible = false;
            reportsToolStripMenuItem.Visible = false;

            // Скрываем подпункты, которые будут настраиваться отдельно
            employeesToolStripMenuItem.Visible = false;
            cabinetsToolStripMenuItem.Visible = false;
            registerPatientToolStripMenuItem.Visible = false;
            searchPatientToolStripMenuItem.Visible = false;
            myScheduleToolStripMenuItem.Visible = false;
            createAppointmentToolStripMenuItem.Visible = false;
            viewMedicalRecordsToolStripMenuItem.Visible = false;
            createRecordToolStripMenuItem.Visible = false;
            myStatisticsToolStripMenuItem.Visible = false;
            branchStatisticsToolStripMenuItem.Visible = false;

            // Настраиваем меню в зависимости от должности
            switch (UserSession.Position.ToLower())
            {
                case "администратор":
                    ConfigureAdminMenu();
                    break;
                case "врач":
                    ConfigureDoctorMenu();
                    break;
                case "медсестра":
                    ConfigureNurseMenu();
                    break;
                default:
                    MessageBox.Show("Неизвестная роль пользователя", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ConfigureAdminMenu()
        {
            // Администратору доступно всё
            administrationToolStripMenuItem.Visible = true;
            patientsToolStripMenuItem.Visible = true;
            scheduleToolStripMenuItem.Visible = true;
            medicalRecordsToolStripMenuItem.Visible = true;
            reportsToolStripMenuItem.Visible = true;

            // Подпункты администрирования
            employeesToolStripMenuItem.Visible = true;
            cabinetsToolStripMenuItem.Visible = true;

            // Подпункты пациентов
            registerPatientToolStripMenuItem.Visible = true;
            searchPatientToolStripMenuItem.Visible = true;

            // Подпункты расписания
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = true;

            // Подпункты медкарт
            viewMedicalRecordsToolStripMenuItem.Visible = true;
            createRecordToolStripMenuItem.Visible = true;

            // Подпункты отчетов
            myStatisticsToolStripMenuItem.Visible = true;
            branchStatisticsToolStripMenuItem.Visible = true;
        }

        private void ConfigureDoctorMenu()
        {
            // Врачу доступно ограниченное меню
            patientsToolStripMenuItem.Visible = true;
            scheduleToolStripMenuItem.Visible = true;
            medicalRecordsToolStripMenuItem.Visible = true;
            reportsToolStripMenuItem.Visible = true;

            // Подпункты пациентов (только поиск)
            searchPatientToolStripMenuItem.Visible = true;
            registerPatientToolStripMenuItem.Visible = false; // Врач не регистрирует новых пациентов

            // Подпункты расписания
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = false; // Врач не создает записи

            // Подпункты медкарт
            viewMedicalRecordsToolStripMenuItem.Visible = true;
            createRecordToolStripMenuItem.Visible = true;

            // Подпункты отчетов
            myStatisticsToolStripMenuItem.Visible = true;
            branchStatisticsToolStripMenuItem.Visible = false; // Врач не видит статистику филиала
        }

        private void ConfigureNurseMenu()
        {
            // Медсестре доступно минимальное меню
            scheduleToolStripMenuItem.Visible = true;
            medicalRecordsToolStripMenuItem.Visible = true;

            // Подпункты расписания
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = false;

            // Подпункты медкарт (только просмотр)
            viewMedicalRecordsToolStripMenuItem.Visible = true;
            createRecordToolStripMenuItem.Visible = false; // Медсестра не создает записи в медкарты
        }

        private void OpenChildForm(Form childForm)
        {
            // Закрываем предыдущую дочернюю форму
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // Настраиваем и открываем новую форму
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        // Меню: Система
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Профиль пользователя:\n\nФИО: {UserSession.FullName}\nДолжность: {UserSession.Position}\nЛогин: {UserSession.Login}\nФилиал: {UserSession.BranchID}",
                "Мой профиль", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция смены пароля будет реализована позже",
                "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Меню: Администрирование
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeesManagementForm());
        }

        private void cabinetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма управления кабинетами будет реализована на следующем этапе",
                "Управление кабинетами", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Пациенты
        private void registerPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientsForm());
        }

        private void searchPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientSearchForm());
        }

        // Меню: Расписание
        private void myScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма просмотра расписания будет реализована на следующем этапе",
                "Мое расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Используем существующую форму записи на прием
            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }

        // Меню: Медкарты
        private void viewMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма просмотра медкарт будет реализована на следующем этапе",
                "Медицинские карты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма создания записи в медкарту будет реализована на следующем этапе",
                "Создание записи в медкарту", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Отчеты
        private void myStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма личной статистики будет реализована на следующем этапе",
                "Моя статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void branchStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма статистики филиала будет реализована на следующем этапе",
                "Статистика филиала", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Справка
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Медицинская информационная система\nВерсия 1.0\n\nРазработано для сети медицинских центров",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для получения помощи обратитесь к системному администратору",
                "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии главной формы выходим из приложения
            Application.Exit();
        }
    }
}
