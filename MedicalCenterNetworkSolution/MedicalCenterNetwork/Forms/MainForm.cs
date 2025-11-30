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
            // Скрываем все меню сначала
            administrationToolStripMenuItem.Visible = false;
            patientsToolStripMenuItem.Visible = false;
            scheduleToolStripMenuItem.Visible = false;
            medicalRecordsToolStripMenuItem.Visible = false;
            reportsToolStripMenuItem.Visible = false;

            // Показываем меню в зависимости от должности
            switch (UserSession.Position)
            {
                case "Администратор":
                    administrationToolStripMenuItem.Visible = true;
                    patientsToolStripMenuItem.Visible = true;
                    scheduleToolStripMenuItem.Visible = true;
                    medicalRecordsToolStripMenuItem.Visible = true;
                    reportsToolStripMenuItem.Visible = true;
                    createAppointmentToolStripMenuItem.Visible = true;
                    break;

                case "Врач":
                    patientsToolStripMenuItem.Visible = true;
                    scheduleToolStripMenuItem.Visible = true;
                    medicalRecordsToolStripMenuItem.Visible = true;
                    reportsToolStripMenuItem.Visible = true;
                    createAppointmentToolStripMenuItem.Visible = true;
                    break;

                case "Медсестра":
                    scheduleToolStripMenuItem.Visible = true;
                    medicalRecordsToolStripMenuItem.Visible = true;
                    break;
            }
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
            MessageBox.Show("Форма управления сотрудниками будет реализована позже",
                "Управление сотрудниками", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cabinetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма управления кабинетами будет реализована позже",
                "Управление кабинетами", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Пациенты
        private void registerPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientsForm());
        }

        private void searchPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientsForm());
        }

        // Меню: Расписание
        private void myScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма моего расписания будет реализована позже",
                "Мое расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AppointmentForm());
        }

        // Меню: Медкарты
        private void viewMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма просмотра медкарт будет реализована позже",
                "Медицинские карты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма создания записи в медкарту будет реализована позже",
                "Создание записи в медкарту", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Отчеты
        private void myStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма личной статистики будет реализована позже",
                "Моя статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void branchStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма статистики филиала будет реализована позже",
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
