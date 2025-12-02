using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalCenterNetwork.Data;
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
            proceduresToolStripMenuItem.Visible = false; // ДОБАВЛЕНО: скрываем процедуры

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

            // Восстанавливаем исходный текст пункта меню (на случай переключения пользователей)
            myScheduleToolStripMenuItem.Text = "Мое расписание"; // ИЗМЕНЕНО

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
            // Администратору доступно всё, кроме создания записей в медкарте
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
            myScheduleToolStripMenuItem.Text = "Расписание филиала";
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = true;

            // Подпункты медкарт
            viewMedicalRecordsToolStripMenuItem.Visible = true;
            createRecordToolStripMenuItem.Visible = false;

            // Подпункты отчетов
            myStatisticsToolStripMenuItem.Visible = false;
            branchStatisticsToolStripMenuItem.Visible = true;

            // Подпункты процедур
            proceduresToolStripMenuItem.Visible = false;
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
            myScheduleToolStripMenuItem.Text = "Моё расписание"; 
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = false; // Врач не создает записи

            // Подпункты медкарт
            viewMedicalRecordsToolStripMenuItem.Visible = true;
            createRecordToolStripMenuItem.Visible = true;

            // Подпункты отчетов
            myStatisticsToolStripMenuItem.Visible = true;
            branchStatisticsToolStripMenuItem.Visible = false; // Врач не видит статистику филиала

            // Подпункты процедур
            proceduresToolStripMenuItem.Visible = false;
        }

        private void ConfigureNurseMenu()
        {
            // Медсестре доступно минимальное меню
            scheduleToolStripMenuItem.Visible = true;
            medicalRecordsToolStripMenuItem.Visible = false;

            // Подпункты расписания
            myScheduleToolStripMenuItem.Text = "Моё расписание";
            myScheduleToolStripMenuItem.Visible = true;
            createAppointmentToolStripMenuItem.Visible = false;

            // Подпункты медкарт
            viewMedicalRecordsToolStripMenuItem.Visible = false;
            createRecordToolStripMenuItem.Visible = false;

            // Показываем пункт "Процедуры" как отдельный главный пункт меню
            proceduresToolStripMenuItem.Visible = true;
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
            var profileForm = new ProfileForm();
            profileForm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new ChangePasswordForm(UserSession.Login, UserSession.FullName, true))
            {
                changePasswordForm.ShowDialog();
            }
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
            OpenChildForm(new CabinetsManagementForm());
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
            try
            {
                // Проверяем, авторизован ли пользователь
                if (UserSession.EmployeeID == 0)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Для медсестры открываем расписание процедур
                if (UserSession.Position == "Медсестра")
                {
                    OpenChildForm(new NurseScheduleForm());
                }
                // Для врача и администратора открываем обычное расписание
                else
                {
                    var scheduleForm = new ScheduleForm();

                    if (UserSession.Position == "Врач")
                    {
                        scheduleForm.SetSelectedDoctor(UserSession.EmployeeID);
                    }

                    OpenChildForm(scheduleForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при открытии расписания: {ex.Message}");
            }
        }

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Используем существующую форму записи на прием
            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }

        // Меню: Медкарты - Просмотр
        private void viewMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем авторизацию
                if (UserSession.EmployeeID == 0)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, что пользователь - врач или администратор
                if (UserSession.Position != "Врач" && UserSession.Position != "Администратор")
                {
                    MessageBox.Show("Доступно только для врачей и администраторов", "Ограничение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Сначала выбираем пациента
                var searchForm = new PatientSearchForm();
                if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedPatient != null)
                {
                    // Открываем форму медицинской карты с выбранным пациентом
                    OpenChildForm(new MedicalRecordForm(searchForm.SelectedPatient));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии медицинских карт: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при открытии медицинских карт: {ex.Message}");
            }
        }

        // Меню: Медкарты - Создание записи
        private void createRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем авторизацию
                if (UserSession.EmployeeID == 0)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, что пользователь - врач
                if (UserSession.Position != "Врач")
                {
                    MessageBox.Show("Доступно только для врачей", "Ограничение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Сначала выбираем пациента
                var searchForm = new PatientSearchForm();
                if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedPatient != null)
                {
                    // Открываем форму медицинской карты для создания новой записи
                    var medicalRecordForm = new MedicalRecordForm(searchForm.SelectedPatient);

                    // Автоматически создаем новую запись
                    medicalRecordForm.SetNewRecordMode();

                    medicalRecordForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании медицинской записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при создании медицинской записи: {ex.Message}");
            }
        }

        // Меню: Отчеты
        private void myStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем авторизацию пользователя
                if (UserSession.EmployeeID == 0)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, что пользователь - врач или администратор
                string position = UserSession.Position.ToLower();
                if (position != "врач" && position != "администратор")
                {
                    MessageBox.Show("Доступно только для врачей и администраторов", "Ограничение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Если пользователь администратор, предлагаем выбрать врача для отчета
                if (position == "администратор")
                {
                    OpenStatisticsForAdmin();
                }
                else // Если врач - открываем его статистику
                {
                    OpenChildForm(new MyStatisticsForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при открытии статистики: {ex.Message}");
            }
        }

        private void OpenStatisticsForAdmin()
        {
            // Создаем форму выбора врача
            using (var doctorSelectForm = new Form())
            {
                doctorSelectForm.Text = "Выбор врача для отчета";
                doctorSelectForm.Size = new Size(400, 200);
                doctorSelectForm.StartPosition = FormStartPosition.CenterParent;
                doctorSelectForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                doctorSelectForm.MaximizeBox = false;
                doctorSelectForm.MinimizeBox = false;

                // Комбобокс для выбора врача
                var comboBoxDoctors = new ComboBox
                {
                    Location = new Point(20, 40),
                    Size = new Size(340, 23),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                // Кнопки
                var btnOk = new Button
                {
                    Text = "Показать отчет",
                    Location = new Point(150, 80),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.OK
                };

                var btnCancel = new Button
                {
                    Text = "Отмена",
                    Location = new Point(260, 80),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.Cancel
                };

                // Список для хранения врачей
                List<KeyValuePair<int, string>> doctors = new List<KeyValuePair<int, string>>();

                // Заполняем комбобокс врачами
                try
                {
                    // Получаем DatabaseHelper для текущего филиала
                    var dbHelper = DatabaseManager.GetCurrentBranchDatabase();

                    // Используем правильные имена столбцов из таблицы Employees
                    string sql = @"
                        SELECT ID_employee, LastName || ' ' || FirstName || ' ' || COALESCE(MiddleName, '') 
                        FROM Employees 
                        WHERE Position = 'Врач' AND ID_branch = @BranchId
                        ORDER BY LastName, FirstName";

                    var parameters = new SQLiteParameter[]
                    {
            new SQLiteParameter("@BranchId", UserSession.BranchID)
                    };

                    var dataTable = dbHelper.ExecuteQuery(sql, parameters);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int doctorId = Convert.ToInt32(row[0]);
                        string doctorName = row[1].ToString();
                        doctors.Add(new KeyValuePair<int, string>(doctorId, doctorName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке списка врачей: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.LogError($"Ошибка при загрузке врачей для статистики: {ex.Message}");
                    return;
                }

                // Проверяем, есть ли врачи
                if (doctors.Count == 0)
                {
                    MessageBox.Show("В вашем филиале нет врачей", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Заполняем комбобокс
                comboBoxDoctors.DataSource = new BindingSource(doctors, null);
                comboBoxDoctors.DisplayMember = "Value";
                comboBoxDoctors.ValueMember = "Key";

                comboBoxDoctors.SelectedIndex = 0;

                // Добавляем элементы на форму
                var label = new Label
                {
                    Text = "Выберите врача для просмотра статистики:",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                doctorSelectForm.Controls.Add(label);
                doctorSelectForm.Controls.Add(comboBoxDoctors);
                doctorSelectForm.Controls.Add(btnOk);
                doctorSelectForm.Controls.Add(btnCancel);

                doctorSelectForm.AcceptButton = btnOk;
                doctorSelectForm.CancelButton = btnCancel;

                // Показываем форму выбора
                if (doctorSelectForm.ShowDialog() == DialogResult.OK && doctors.Count > 0)
                {
                    // Получаем выбранного врача
                    var selectedDoctor = (KeyValuePair<int, string>)comboBoxDoctors.SelectedItem;

                    // Открываем форму статистики для выбранного врача
                    var statisticsForm = new MyStatisticsForm(selectedDoctor.Key, selectedDoctor.Value);
                    OpenChildForm(statisticsForm);
                }
            }
        }

        private void branchStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что пользователь - администратор
                if (UserSession.Position != "Администратор")
                {
                    MessageBox.Show("Доступно только для администраторов", "Ограничение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OpenChildForm(new BranchStatisticsForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии статистики филиала: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при открытии статистики филиала: {ex.Message}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии главной формы выходим из приложения
            Application.Exit();
        }

        // Меню: Процедуры (для медсестры)
        private void proceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что пользователь - медсестра
                if (UserSession.Position != "Медсестра")
                {
                    MessageBox.Show("Доступно только для медсестер", "Ограничение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OpenChildForm(new CompletedProceduresForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии процедур: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при открытии процедур: {ex.Message}");
            }
        }
    }
}
