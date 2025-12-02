using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class ScheduleForm : Form
    {
        private DatabaseHelper db;
        private List<ScheduleDay> scheduleDays = new List<ScheduleDay>();
        private DateTime currentDate = DateTime.Today;
        private int viewMode = 0; // 0 - день, 1 - неделя, 2 - месяц
        private int? selectedDoctorID = null;

        public ScheduleForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            db = DatabaseManager.GetCurrentBranchDatabase();

            // Настройка начальной даты
            currentDate = DateTime.Today;
            UpdateDateLabel();

            // Загрузка списка врачей
            LoadDoctors();

            // Настройка видимости кнопок по ролям
            ConfigureButtonsByRole();

            // Загрузка расписания
            LoadSchedule();

            // Изменяем заголовок формы в зависимости от роли
            UpdateFormTitle();
        }

        private void UpdateFormTitle()
        {
            if (UserSession.Position == "Администратор")
            {
                this.Text = "Расписание филиала";
                labelDateRange.Text = "Расписание филиала";
            }
            else if (UserSession.Position == "Врач")
            {
                this.Text = "Мое расписание";
                labelDateRange.Text = "Мое расписание";
            }
            else
            {
                this.Text = "Расписание";
                labelDateRange.Text = "Расписание";
            }
        }

        private void UpdateDateLabel()
        {
            string viewText = "";
            switch (viewMode)
            {
                case 0: viewText = "День"; break;
                case 1: viewText = "Неделя"; break;
                case 2: viewText = "Месяц"; break;
                default: viewText = "День"; break;
            }

            string dateRange = "";
            switch (viewMode)
            {
                case 0:
                    dateRange = currentDate.ToString("dd.MM.yyyy");
                    break;
                case 1:
                    DateTime weekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek + 1);
                    dateRange = $"{weekStart:dd.MM} - {weekStart.AddDays(6):dd.MM.yyyy}";
                    break;
                case 2:
                    dateRange = currentDate.ToString("MMMM yyyy");
                    break;
                default:
                    dateRange = currentDate.ToString("dd.MM.yyyy");
                    break;
            }

            labelDateRange.Text = $"{viewText}: {dateRange}";
        }

        private void LoadDoctors()
        {
            try
            {
                // Проверяем, что пользователь авторизован
                if (UserSession.EmployeeID == 0)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Для загрузки врачей используем локальную базу филиала
                string query = @"
            SELECT 
                ID_employee, 
                LastName || ' ' || FirstName || ' ' || COALESCE(MiddleName, '') as FullName
            FROM Employees 
            WHERE Position = 'Врач' AND IsActive = 1 
            AND ID_branch = @BranchID
            ORDER BY LastName, FirstName";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                var doctors = db.ExecuteQuery(query, parameters);

                // Создаем новый DataTable с правильной структурой
                DataTable doctorsTable = new DataTable();
                doctorsTable.Columns.Add("ID_employee", typeof(int));
                doctorsTable.Columns.Add("FullName", typeof(string));

                // Добавляем "Все врачи" в начало списка
                DataRow allDoctorsRow = doctorsTable.NewRow();
                allDoctorsRow["ID_employee"] = 0;
                allDoctorsRow["FullName"] = "Все врачи";
                doctorsTable.Rows.Add(allDoctorsRow);

                // Добавляем врачей из запроса
                foreach (DataRow row in doctors.Rows)
                {
                    DataRow newRow = doctorsTable.NewRow();
                    newRow["ID_employee"] = row["ID_employee"];
                    newRow["FullName"] = row["FullName"];
                    doctorsTable.Rows.Add(newRow);
                }

                comboBoxDoctors.DataSource = doctorsTable;
                comboBoxDoctors.DisplayMember = "FullName";
                comboBoxDoctors.ValueMember = "ID_employee";

                // Если пользователь - врач, выбираем его автоматически
                if (UserSession.Position == "Врач")
                {
                    // Ищем врача в списке
                    bool doctorFound = false;
                    for (int i = 0; i < comboBoxDoctors.Items.Count; i++)
                    {
                        var rowView = comboBoxDoctors.Items[i] as DataRowView;
                        if (rowView != null && Convert.ToInt32(rowView["ID_employee"]) == UserSession.EmployeeID)
                        {
                            comboBoxDoctors.SelectedIndex = i;
                            doctorFound = true;
                            comboBoxDoctors.Enabled = false; // Запрещаем врачу менять врача
                            break;
                        }
                    }

                    if (!doctorFound)
                    {
                        MessageBox.Show("Ваша учетная запись врача не найдена в базе данных", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Для администратора выбираем "Все врачи"
                    comboBoxDoctors.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка врачей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtonsByRole()
        {
            if (UserSession.EmployeeID == 0) return;

            bool isDoctor = UserSession.Position == "Врач";
            bool isAdmin = UserSession.Position == "Администратор";

            // Кнопка "Новая запись" доступна только администраторам
            buttonNewAppointment.Visible = isAdmin;
        }   

        private void LoadSchedule()
        {
            try
            {
                scheduleDays.Clear();
                flowLayoutPanelSchedule.Controls.Clear();

                DateTime startDate = GetStartDateForViewMode();
                DateTime endDate = GetEndDateForViewMode();

                // Получаем медицинские услуги из главной базы
                var medicalServices = GetMedicalServices();

                string query = BuildScheduleQuery(medicalServices);
                var parameters = BuildScheduleParameters(startDate, endDate);

                var appointments = db.ExecuteQuery(query, parameters);

                ProcessAppointments(appointments, startDate, endDate, medicalServices);
                DisplaySchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime GetStartDateForViewMode()
        {
            switch (viewMode)
            {
                case 0:
                    return currentDate;
                case 1:
                    // Начало недели (понедельник)
                    int daysToMonday = ((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
                    return currentDate.AddDays(-daysToMonday);
                case 2:
                    return new DateTime(currentDate.Year, currentDate.Month, 1);
                default:
                    return currentDate;
            }
        }

        private DateTime GetEndDateForViewMode()
        {
            DateTime startDate = GetStartDateForViewMode();

            switch (viewMode)
            {
                case 0:
                    return startDate.AddDays(1).AddSeconds(-1);
                case 1:
                    return startDate.AddDays(7).AddSeconds(-1);
                case 2:
                    return startDate.AddMonths(1).AddSeconds(-1);
                default:
                    return startDate.AddDays(1).AddSeconds(-1);
            }
        }

        private string BuildScheduleQuery(Dictionary<int, (string Name, int Duration)> medicalServices)
        {
            string doctorFilter = "";
            if (selectedDoctorID.HasValue && selectedDoctorID.Value > 0)
            {
                doctorFilter = "AND a.ID_employee = @DoctorID";
            }

            // Создаем временную таблицу с медицинскими услугами
            var serviceCases = new StringBuilder();
            foreach (var service in medicalServices)
            {
                serviceCases.AppendLine($"WHEN {service.Key} THEN '{service.Value.Name.Replace("'", "''")}'");
            }

            var durationCases = new StringBuilder();
            foreach (var service in medicalServices)
            {
                durationCases.AppendLine($"WHEN {service.Key} THEN {service.Value.Duration}");
            }

            return $@"
                SELECT 
                    a.ID_appointment,
                    a.DateTime,
                    a.Status,
                    a.ID_cabinet,
                    p.LastName || ' ' || p.FirstName || ' ' || p.MiddleName as PatientFullName,
                    e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorFullName,
                    CASE a.ID_service
                        {serviceCases.ToString()}
                        ELSE 'Неизвестная услуга'
                    END as ServiceName,
                    CASE a.ID_service
                        {durationCases.ToString()}
                        ELSE 30
                    END as Duration_minutes
                FROM Appointments a
                INNER JOIN Patients p ON a.ID_patient = p.ID_patient
                INNER JOIN Employees e ON a.ID_employee = e.ID_employee
                WHERE a.ID_branch = @BranchID
                AND a.DateTime BETWEEN @StartDate AND @EndDate
                {doctorFilter}
                ORDER BY a.DateTime, e.LastName, e.FirstName";
        }

        private SQLiteParameter[] BuildScheduleParameters(DateTime startDate, DateTime endDate)
        {
            var parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@BranchID", UserSession.BranchID),
                new SQLiteParameter("@StartDate", startDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new SQLiteParameter("@EndDate", endDate.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            if (selectedDoctorID.HasValue && selectedDoctorID.Value > 0)
            {
                parameters.Add(new SQLiteParameter("@DoctorID", selectedDoctorID.Value));
            }

            return parameters.ToArray();
        }

        private void ProcessAppointments(DataTable appointments, DateTime startDate, DateTime endDate, Dictionary<int, (string Name, int Duration)> medicalServices)
        {
            // Создаем дни для отображения
            CreateScheduleDays(startDate, endDate);

            // Заполняем записи по дням
            foreach (DataRow row in appointments.Rows)
            {
                var appointmentTime = Convert.ToDateTime(row["DateTime"]);
                var appointmentDate = appointmentTime.Date;

                var scheduleItem = new ScheduleItem
                {
                    ID_appointment = Convert.ToInt32(row["ID_appointment"]),
                    DateTime = appointmentTime,
                    PatientFullName = row["PatientFullName"].ToString(),
                    DoctorFullName = row["DoctorFullName"].ToString(),
                    ServiceName = row["ServiceName"].ToString(),
                    Status = row["Status"].ToString(),
                    Cabinet = row["ID_cabinet"] != DBNull.Value ? $"Каб. {row["ID_cabinet"]}" : "Не указан",
                    Duration = TimeSpan.FromMinutes(Convert.ToInt32(row["Duration_minutes"]))
                };

                // Находим соответствующий день и добавляем запись
                var day = scheduleDays.FirstOrDefault(d => d.Date == appointmentDate);
                if (day != null)
                {
                    day.Appointments.Add(scheduleItem);
                }
            }
        }

        private void CreateScheduleDays(DateTime startDate, DateTime endDate)
        {
            scheduleDays.Clear();
            DateTime currentDay = startDate.Date;

            while (currentDay <= endDate.Date)
            {
                scheduleDays.Add(new ScheduleDay { Date = currentDay });
                currentDay = currentDay.AddDays(1);
            }
        }

        private void DisplaySchedule()
        {
            flowLayoutPanelSchedule.SuspendLayout();
            flowLayoutPanelSchedule.Controls.Clear();

            foreach (var day in scheduleDays)
            {
                var dayPanel = CreateDayPanel(day);
                flowLayoutPanelSchedule.Controls.Add(dayPanel);
            }

            flowLayoutPanelSchedule.ResumeLayout();
        }

        private Panel CreateDayPanel(ScheduleDay day)
        {
            int panelWidth = viewMode == 0 ? flowLayoutPanelSchedule.Width - 30 : 300;

            Panel panel = new Panel
            {
                Width = panelWidth,
                Height = 400,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            // Заголовок дня
            Label dayLabel = new Label
            {
                Text = $"{day.Date:dd.MM.yyyy} ({day.DayOfWeekRus})",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(dayLabel);

            // Список записей
            ListBox listBox = new ListBox
            {
                Location = new Point(10, 40),
                Width = panel.Width - 40,
                Height = 340,
                DrawMode = DrawMode.OwnerDrawVariable,
                Font = new Font("Segoe UI", 9)
            };
            listBox.DrawItem += ListBox_DrawItem;
            listBox.MeasureItem += ListBox_MeasureItem;
            listBox.DoubleClick += ListBox_DoubleClick;

            foreach (var appointment in day.Appointments.OrderBy(a => a.DateTime))
            {
                listBox.Items.Add(appointment);
            }

            if (listBox.Items.Count == 0)
            {
                listBox.Items.Add("Записей нет");
            }

            panel.Controls.Add(listBox);
            return panel;
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            ListBox listBox = sender as ListBox;
            object item = listBox.Items[e.Index];

            if (item is string)
            {
                // Отображение "Записей нет"
                e.Graphics.DrawString(item.ToString(),
                    e.Font, Brushes.Gray, e.Bounds);
            }
            else if (item is ScheduleItem scheduleItem)
            {
                // Отображение записи
                var bounds = e.Bounds;
                var padding = 5;

                // Фон по статусу
                Color statusColor = Color.White;
                switch (scheduleItem.Status)
                {
                    case "Запланирован": statusColor = Color.LightBlue; break;
                    case "Подтвержден": statusColor = Color.LightGreen; break;
                    case "Завершен": statusColor = Color.LightGray; break;
                    case "Отменен": statusColor = Color.LightPink; break;
                    case "Пациент не явился": statusColor = Color.Orange; break;
                }

                using (var brush = new SolidBrush(statusColor))
                {
                    e.Graphics.FillRectangle(brush, bounds);
                }

                // Текст записи
                string timeText = $"{scheduleItem.DateTime:HH:mm} - {scheduleItem.DateTime.Add(scheduleItem.Duration):HH:mm}";
                string patientText = $"Пациент: {scheduleItem.PatientFullName}";
                string doctorText = $"Врач: {scheduleItem.DoctorFullName}";
                string serviceText = $"Услуга: {scheduleItem.ServiceName}";
                string statusText = $"Статус: {scheduleItem.Status}";
                string cabinetText = $"Кабинет: {scheduleItem.Cabinet}";

                using (var fontBold = new Font(e.Font, FontStyle.Bold))
                using (var fontNormal = new Font(e.Font, FontStyle.Regular))
                {
                    int yPos = bounds.Y + padding;

                    e.Graphics.DrawString(timeText, fontBold, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                    yPos += 20;

                    e.Graphics.DrawString(patientText, fontNormal, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                    yPos += 20;

                    e.Graphics.DrawString(doctorText, fontNormal, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                    yPos += 20;

                    e.Graphics.DrawString(serviceText, fontNormal, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                    yPos += 20;

                    e.Graphics.DrawString(statusText, fontNormal, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                    yPos += 20;

                    e.Graphics.DrawString(cabinetText, fontNormal, Brushes.Black,
                        new Point(bounds.X + padding, yPos));
                }
            }

            e.DrawFocusRectangle();
        }

        private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (e.Index >= 0 && e.Index < listBox.Items.Count)
            {
                if (listBox.Items[e.Index] is ScheduleItem)
                {
                    e.ItemHeight = 140; // Высота для элемента записи
                }
                else
                {
                    e.ItemHeight = 20; // Высота для текста "Записей нет"
                }
            }
        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox?.SelectedItem is ScheduleItem selectedItem)
            {
                // Можно предложить выбор: детали приема или медкарта
                var dialog = new Form
                {
                    Text = "Выберите действие",
                    Width = 300,
                    Height = 150,
                    StartPosition = FormStartPosition.CenterParent
                };

                var btnDetails = new Button
                {
                    Text = "Детали приема",
                    Location = new Point(20, 20),
                    Width = 120,
                    Height = 40
                };

                var btnMedicalRecord = new Button
                {
                    Text = "Медкарта",
                    Location = new Point(150, 20),
                    Width = 120,
                    Height = 40
                };

                btnDetails.Click += (s, ev) =>
                {
                    OpenAppointmentDetails(selectedItem.ID_appointment);
                    dialog.Close();
                };

                btnMedicalRecord.Click += (s, ev) =>
                {
                    // Нужно получить ID пациента из записи
                    OpenMedicalRecordForAppointment(selectedItem.ID_appointment, GetPatientIdFromAppointment(selectedItem.ID_appointment));
                    dialog.Close();
                };

                dialog.Controls.Add(btnDetails);
                dialog.Controls.Add(btnMedicalRecord);
                dialog.ShowDialog();
            }
        }

        private int GetPatientIdFromAppointment(int appointmentId)
        {
            try
            {
                string query = "SELECT ID_patient FROM Appointments WHERE ID_appointment = @AppointmentID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@AppointmentID", appointmentId)
                };

                var result = db.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch
            {
                return 0;
            }
        }

        private void OpenAppointmentDetails(int appointmentId)
        {
            try
            {
                var detailsForm = new AppointmentDetailsForm(appointmentId);
                detailsForm.ShowDialog();

                // После закрытия формы обновляем расписание (на случай изменения статуса)
                LoadSchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии деталей записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToday_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            UpdateDateLabel();
            LoadSchedule();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            switch (viewMode)
            {
                case 0: currentDate = currentDate.AddDays(-1); break;
                case 1: currentDate = currentDate.AddDays(-7); break;
                case 2: currentDate = currentDate.AddMonths(-1); break;
            }
            UpdateDateLabel();
            LoadSchedule();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            switch (viewMode)
            {
                case 0: currentDate = currentDate.AddDays(1); break;
                case 1: currentDate = currentDate.AddDays(7); break;
                case 2: currentDate = currentDate.AddMonths(1); break;
            }
            UpdateDateLabel();
            LoadSchedule();
        }

        private void radioButtonDay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDay.Checked)
            {
                viewMode = 0;
                UpdateDateLabel();
                LoadSchedule();
            }
        }

        private void radioButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeek.Checked)
            {
                viewMode = 1;
                UpdateDateLabel();
                LoadSchedule();
            }
        }

        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonth.Checked)
            {
                viewMode = 2;
                UpdateDateLabel();
                LoadSchedule();
            }
        }

        private void comboBoxDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDoctors.SelectedItem != null)
                {
                    var selectedRow = comboBoxDoctors.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        int selectedValue = Convert.ToInt32(selectedRow["ID_employee"]);
                        selectedDoctorID = selectedValue > 0 ? selectedValue : (int?)null;
                        LoadSchedule();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе врача: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void buttonNewAppointment_Click(object sender, EventArgs e)
        {
            var appointmentForm = new AppointmentForm();
            if (appointmentForm.ShowDialog() == DialogResult.OK)
            {
                LoadSchedule(); // Обновляем расписание после создания новой записи
            }
        }

        public void SetSelectedDoctor(int doctorId)
        {
            selectedDoctorID = doctorId;

            // Устанавливаем выбранного врача в комбобоксе
            if (comboBoxDoctors.Items.Count > 0)
            {
                for (int i = 0; i < comboBoxDoctors.Items.Count; i++)
                {
                    var rowView = comboBoxDoctors.Items[i] as DataRowView;
                    if (rowView != null && Convert.ToInt32(rowView["ID_employee"]) == doctorId)
                    {
                        comboBoxDoctors.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Блокируем комбобокс для врача (чтобы он не мог менять врача)
            if (UserSession.EmployeeID != 0)
            {
                comboBoxDoctors.Enabled = UserSession.Position != "Врач";
            }

            // Обновляем заголовок формы
            UpdateFormTitle();
        }

        private Dictionary<int, (string Name, int Duration)> GetMedicalServices()
        {
            var services = new Dictionary<int, (string Name, int Duration)>();

            try
            {
                // Получаем медицинские услуги из главной базы
                var mainDb = DatabaseManager.GetMainDatabase();
                string query = "SELECT ID_service, Name, Duration_minutes FROM MedicalServices";

                var result = mainDb.ExecuteQuery(query);
                foreach (DataRow row in result.Rows)
                {
                    int id = Convert.ToInt32(row["ID_service"]);
                    string name = row["Name"].ToString();
                    int duration = Convert.ToInt32(row["Duration_minutes"]);
                    services[id] = (name, duration);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке медицинских услуг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return services;
        }

        // В обработчике двойного клика или добавьте отдельную кнопку
        private void OpenMedicalRecordForAppointment(int appointmentId, int patientId)
        {
            try
            {
                // Получаем данные о пациенте - ИСПРАВЛЕНО: DateOfBirth вместо BirthDate
                string patientQuery = "SELECT * FROM Patients WHERE ID_patient = @PatientID";
                var patientParams = new SQLiteParameter[]
                {
            new SQLiteParameter("@PatientID", patientId)
                };

                var patientResult = db.ExecuteQuery(patientQuery, patientParams);
                if (patientResult.Rows.Count > 0)
                {
                    var patientRow = patientResult.Rows[0];
                    var patient = new Patient
                    {
                        ID_patient = Convert.ToInt32(patientRow["ID_patient"]),
                        LastName = patientRow["LastName"].ToString(),
                        FirstName = patientRow["FirstName"].ToString(),
                        MiddleName = patientRow["MiddleName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(patientRow["DateOfBirth"]), // ИСПРАВЛЕНО
                        Gender = patientRow["Gender"].ToString(),
                        Phone = patientRow["Phone"].ToString(),
                        Address = patientRow["Address"] != DBNull.Value ? patientRow["Address"].ToString() : ""
                    };

                    // Получаем данные о приеме
                    string appointmentQuery = "SELECT * FROM Appointments WHERE ID_appointment = @AppointmentID";
                    var appointmentParams = new SQLiteParameter[]
                    {
                new SQLiteParameter("@AppointmentID", appointmentId)
                    };

                    var appointmentResult = db.ExecuteQuery(appointmentQuery, appointmentParams);
                    Appointment appointment = null;

                    if (appointmentResult.Rows.Count > 0)
                    {
                        var appointmentRow = appointmentResult.Rows[0];
                        appointment = new Appointment
                        {
                            ID_appointment = Convert.ToInt32(appointmentRow["ID_appointment"]),
                            ID_patient = Convert.ToInt32(appointmentRow["ID_patient"]),
                            ID_employee = Convert.ToInt32(appointmentRow["ID_employee"]),
                            DateTime = Convert.ToDateTime(appointmentRow["DateTime"]),
                            Status = appointmentRow["Status"].ToString()
                        };
                    }

                    // Открываем форму медицинской карты
                    var medicalRecordForm = new MedicalRecordForm(patient, appointment);
                    medicalRecordForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии медицинской карты: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            LoadSchedule();
        }
    }
}