using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;
using System.Data.SQLite; // ИЗМЕНЕНО: добавьте это

namespace MedicalCenterNetwork.Forms
{
    public partial class MyStatisticsForm : Form
    {
        // Модель отчета
        private DoctorStatisticsReport _report;

        // ID врача для отчета (по умолчанию текущий пользователь)
        private int _doctorId;

        // Конструктор по умолчанию (для текущего пользователя)
        public MyStatisticsForm()
        {
            InitializeComponent();
            _report = new DoctorStatisticsReport();
            _doctorId = UserSession.EmployeeID;
            this.Text = "Моя статистика";
        }

        // Конструктор для администратора (просмотр статистики другого врача)
        public MyStatisticsForm(int doctorId, string doctorName)
        {
            InitializeComponent();
            _report = new DoctorStatisticsReport();
            _doctorId = doctorId;
            this.Text = $"Статистика врача: {doctorName}";
        }

        private void MyStatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Настраиваем начальные значения DateTimePicker
                dateTimePickerFrom.Value = _report.PeriodStart;
                dateTimePickerTo.Value = _report.PeriodEnd;

                // Загружаем отчет по умолчанию
                LoadReport();

                // Настраиваем DataGridView
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при загрузке MyStatisticsForm: {ex.Message}");
            }
        }

        private void ConfigureDataGridView()
        {
            // Настраиваем колонки для детализации
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.Columns.Clear();

            // Создаем колонки с правильными именами DataPropertyName
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn
            {
                Name = "FormattedDate",
                HeaderText = "Дата приема",
                DataPropertyName = "FormattedDate",
                Width = 120
            };

            DataGridViewTextBoxColumn colPatient = new DataGridViewTextBoxColumn
            {
                Name = "PatientName",
                HeaderText = "Пациент",
                DataPropertyName = "PatientName",
                Width = 200
            };

            DataGridViewTextBoxColumn colService = new DataGridViewTextBoxColumn
            {
                Name = "ServiceName",
                HeaderText = "Услуга",
                DataPropertyName = "ServiceName",
                Width = 150
            };

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Статус",
                DataPropertyName = "Status",
                Width = 120
            };

            DataGridViewTextBoxColumn colCost = new DataGridViewTextBoxColumn
            {
                Name = "FormattedCost",
                HeaderText = "Стоимость",
                DataPropertyName = "FormattedCost",
                Width = 100
            };

            DataGridViewTextBoxColumn colDiagnosis = new DataGridViewTextBoxColumn
            {
                Name = "Diagnosis",
                HeaderText = "Диагноз",
                DataPropertyName = "Diagnosis",
                Width = 200
            };

            // Добавляем колонки
            dataGridViewDetails.Columns.AddRange(
                colDate, colPatient, colService, colStatus, colCost, colDiagnosis);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Обновляем период отчета
                _report.PeriodStart = dateTimePickerFrom.Value.Date;
                _report.PeriodEnd = dateTimePickerTo.Value.Date;

                // Проверяем корректность периода
                if (_report.PeriodStart > _report.PeriodEnd)
                {
                    MessageBox.Show("Дата начала периода не может быть позже даты окончания",
                        "Ошибка периода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Загружаем отчет
                LoadReport();

                // Обновляем статус
                toolStripStatusLabel.Text = $"Отчет сформирован за период с {_report.PeriodStart:dd.MM.yyyy} по {_report.PeriodEnd:dd.MM.yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при формировании отчета: {ex.Message}");
            }
        }

        private void LoadReport()
        {
            try
            {
                toolStripStatusLabel.Text = "Загрузка данных...";
                Application.DoEvents();

                // Получаем статистику из базы данных
                GetStatisticsFromDatabase();

                // Отображаем данные
                DisplayReportData();

                // Загружаем детализацию
                LoadAppointmentsDetails();

                toolStripStatusLabel.Text = "Готово";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "Ошибка загрузки";
                throw new Exception($"Не удалось загрузить отчет: {ex.Message}", ex);
            }
        }

        private void GetStatisticsFromDatabase()
        {
            // Получаем DatabaseHelper для текущего филиала
            var dbHelper = DatabaseManager.GetCurrentBranchDatabase();

            var parameters = new SQLiteParameter[]
            {
        new SQLiteParameter("@DoctorId", _doctorId),
        new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
        new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
            };

            // 1. Основная статистика по приемам
            string sqlAppointments = @"
                SELECT 
                    COUNT(*) as TotalAppointments,
                    SUM(CASE WHEN Status = 'Завершен' THEN 1 ELSE 0 END) as CompletedAppointments,
                    SUM(CASE WHEN Status = 'Запланирован' THEN 1 ELSE 0 END) as PlannedAppointments,
                    SUM(CASE WHEN Status = 'Отменен' THEN 1 ELSE 0 END) as CanceledAppointments,
                    SUM(CASE WHEN Status = 'Пациент не явился' THEN 1 ELSE 0 END) as NoShowAppointments
                FROM Appointments 
                WHERE ID_employee = @DoctorId 
                AND DATE(DateTime) BETWEEN @StartDate AND @EndDate";

            var appointmentsData = dbHelper.ExecuteQuery(sqlAppointments, parameters);
            if (appointmentsData.Rows.Count > 0)
            {
                var row = appointmentsData.Rows[0];
                _report.TotalAppointments = Convert.ToInt32(row["TotalAppointments"]);
                _report.CompletedAppointments = Convert.ToInt32(row["CompletedAppointments"]);
                _report.PlannedAppointments = Convert.ToInt32(row["PlannedAppointments"]);
                _report.CanceledAppointments = Convert.ToInt32(row["CanceledAppointments"]);
                _report.NoShowAppointments = Convert.ToInt32(row["NoShowAppointments"]);
            }

            // 2. Количество уникальных пациентов
            string sqlUniquePatients = @"
                SELECT COUNT(DISTINCT ID_patient) as UniquePatients
                FROM Appointments 
                WHERE ID_employee = @DoctorId 
                AND DATE(DateTime) BETWEEN @StartDate AND @EndDate";

            var uniquePatientsData = dbHelper.ExecuteScalar(sqlUniquePatients, parameters);
            _report.UniquePatientsCount = uniquePatientsData != DBNull.Value ? Convert.ToInt32(uniquePatientsData) : 0;

            // 3. Количество созданных записей в медкартах
            string sqlMedicalRecords = @"
                SELECT COUNT(*) as MedicalRecords
                FROM MedicalRecords mr
                INNER JOIN Appointments ap ON mr.ID_appointment = ap.ID_appointment
                WHERE mr.ID_doctor = @DoctorId 
                AND DATE(mr.CreatedDateTime) BETWEEN @StartDate AND @EndDate";

            try
            {
                var medicalRecordsData = dbHelper.ExecuteScalar(sqlMedicalRecords, parameters);
                _report.MedicalRecordsCreated = medicalRecordsData != DBNull.Value ? Convert.ToInt32(medicalRecordsData) : 0;
            }
            catch (Exception ex)
            {
                // Если не удалось получить данные
                _report.MedicalRecordsCreated = 0;
                Logger.LogError($"Ошибка при получении медицинских записей: {ex.Message}");
            }
        }

        private void LoadAppointmentsDetails()
        {
            try
            {
                var branchDb = DatabaseManager.GetCurrentBranchDatabase();
                var mainDb = DatabaseManager.GetMainDatabase(); // Для MedicalServices

                // Используем правильные английские имена столбцов
                string sqlDetails = @"
            SELECT 
                ap.DateTime as AppointmentDate,
                p.LastName || ' ' || p.FirstName || ' ' || COALESCE(p.MiddleName, '') as PatientName,
                ap.ID_service as ServiceID,
                ap.Status as Status,
                ap.Actual_cost as ActualCost,
                COALESCE(mr.Diagnosis, 'Не указан') as Diagnosis
            FROM Appointments ap
            INNER JOIN Patients p ON ap.ID_patient = p.ID_patient
            LEFT JOIN MedicalRecords mr ON ap.ID_appointment = mr.ID_appointment
            WHERE ap.ID_employee = @DoctorId 
            AND DATE(ap.DateTime) BETWEEN @StartDate AND @EndDate
            ORDER BY ap.DateTime DESC";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@DoctorId", _doctorId),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                DataTable dataTable = branchDb.ExecuteQuery(sqlDetails, parameters);

                // Если нет данных, показываем сообщение
                if (dataTable.Rows.Count == 0)
                {
                    dataGridViewDetails.DataSource = null;
                    dataGridViewDetails.Rows.Clear();
                    toolStripStatusLabel.Text = "Нет данных за выбранный период";
                    return;
                }

                // Добавляем колонки для форматированных данных
                dataTable.Columns.Add("FormattedDate", typeof(string));
                dataTable.Columns.Add("FormattedCost", typeof(string));
                dataTable.Columns.Add("ServiceName", typeof(string));

                foreach (DataRow row in dataTable.Rows)
                {
                    // Форматируем дату
                    if (row["AppointmentDate"] != DBNull.Value)
                    {
                        DateTime date = Convert.ToDateTime(row["AppointmentDate"]);
                        row["FormattedDate"] = date.ToString("dd.MM.yyyy HH:mm");
                    }
                    else
                    {
                        row["FormattedDate"] = "Не указано";
                    }

                    // Форматируем стоимость
                    if (row["ActualCost"] != DBNull.Value)
                    {
                        try
                        {
                            decimal cost = Convert.ToDecimal(row["ActualCost"]);
                            row["FormattedCost"] = cost.ToString("C");
                        }
                        catch
                        {
                            row["FormattedCost"] = "0 ₽";
                        }
                    }
                    else
                    {
                        row["FormattedCost"] = "0 ₽";
                    }

                    // Получаем название услуги из главной базы
                    if (row["ServiceID"] != DBNull.Value)
                    {
                        try
                        {
                            int serviceId = Convert.ToInt32(row["ServiceID"]);
                            string serviceName = GetServiceName(mainDb, serviceId);
                            row["ServiceName"] = serviceName;
                        }
                        catch
                        {
                            row["ServiceName"] = "Неизвестная услуга";
                        }
                    }
                    else
                    {
                        row["ServiceName"] = "Не указано";
                    }
                }

                // Привязываем к DataGridView
                dataGridViewDetails.DataSource = dataTable;

                // Скрываем технические колонки
                if (dataGridViewDetails.Columns.Contains("AppointmentDate"))
                    dataGridViewDetails.Columns["AppointmentDate"].Visible = false;
                if (dataGridViewDetails.Columns.Contains("ServiceID"))
                    dataGridViewDetails.Columns["ServiceID"].Visible = false;
                if (dataGridViewDetails.Columns.Contains("ActualCost"))
                    dataGridViewDetails.Columns["ActualCost"].Visible = false;

                toolStripStatusLabel.Text = $"Загружено {dataTable.Rows.Count} записей";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке детализации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.LogError($"Ошибка при загрузке детализации приемов: {ex.Message}");
                toolStripStatusLabel.Text = "Ошибка загрузки данных";
            }
        }

        // Вспомогательный метод для получения названия услуги
        private string GetServiceName(DatabaseHelper db, int serviceId)
        {
            try
            {
                string query = "SELECT Name FROM MedicalServices WHERE ID_service = @ServiceID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@ServiceID", serviceId)
                };

                var result = db.ExecuteScalar(query, parameters);
                return result != null ? result.ToString() : "Неизвестная услуга";
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении названия услуги: {ex.Message}");
                return "Неизвестная услуга";
            }
        }

        private void DisplayReportData()
        {
            try
            {
                // Обновляем основные показатели
                labelTotalValue.Text = _report.TotalAppointments.ToString();
                labelCompletedValue.Text = _report.CompletedAppointments.ToString();
                labelPlannedValue.Text = _report.PlannedAppointments.ToString();
                labelCanceledValue.Text = _report.CanceledAppointments.ToString();
                labelNoShowValue.Text = _report.NoShowAppointments.ToString();
                labelUniquePatientsValue.Text = _report.UniquePatientsCount.ToString();
                labelRecordsCreatedValue.Text = _report.MedicalRecordsCreated.ToString();
                labelAvgPerDayValue.Text = _report.AverageAppointmentsPerDay.ToString("0.0");

                // Обновляем процентные показатели
                int completionPercent = (int)_report.CompletionRate;
                int noShowPercent = (int)_report.NoShowRate;

                progressBarCompletion.Value = completionPercent;
                progressBarNoShow.Value = noShowPercent;

                labelCompletionRate.Text = $"Доля завершенных приемов: {_report.CompletionRate:F1}%";
                labelNoShowRate.Text = $"Доля неявок пациентов: {_report.NoShowRate:F1}%";

                // Меняем цвет прогресс-баров в зависимости от значений
                progressBarCompletion.ForeColor = completionPercent >= 80 ? Color.Green :
                                                completionPercent >= 60 ? Color.YellowGreen :
                                                completionPercent >= 40 ? Color.Orange : Color.Red;

                progressBarNoShow.ForeColor = noShowPercent <= 5 ? Color.Green :
                                             noShowPercent <= 10 ? Color.YellowGreen :
                                             noShowPercent <= 20 ? Color.Orange : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении данных отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при отображении данных отчета: {ex.Message}");
            }
        }
    }
}