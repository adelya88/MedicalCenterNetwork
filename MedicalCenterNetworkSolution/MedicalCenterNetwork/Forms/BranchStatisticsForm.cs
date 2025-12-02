using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class BranchStatisticsForm : Form
    {
        private BranchStatisticsReport _report;
        private DatabaseHelper _db;

        public BranchStatisticsForm()
        {
            InitializeComponent();
            _report = new BranchStatisticsReport();
            _db = DatabaseManager.GetCurrentBranchDatabase();
            LoadBranchName();
        }

        private void BranchStatisticsForm_Load(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = _report.PeriodStart;
            dateTimePickerTo.Value = _report.PeriodEnd;
            LoadReport();
        }

        private void LoadBranchName()
        {
            try
            {
                // Получаем название филиала из главной базы
                var mainDb = DatabaseManager.GetMainDatabase();
                string query = "SELECT BranchName FROM Branches WHERE ID_branch = @BranchID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", _report.BranchID)
                };

                var result = mainDb.ExecuteScalar(query, parameters);
                if (result != null)
                {
                    _report.BranchName = result.ToString();
                    labelBranchName.Text = $"Филиал: {_report.BranchName}";
                }
                else
                {
                    _report.BranchName = "Неизвестный филиал";
                    labelBranchName.Text = _report.BranchName;
                }
            }
            catch (Exception ex)
            {
                _report.BranchName = "Ошибка загрузки";
                labelBranchName.Text = _report.BranchName;
                Logger.LogError($"Ошибка при загрузке названия филиала: {ex.Message}");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _report.PeriodStart = dateTimePickerFrom.Value.Date;
            _report.PeriodEnd = dateTimePickerTo.Value.Date;

            if (_report.PeriodStart > _report.PeriodEnd)
            {
                MessageBox.Show("Дата начала периода не может быть позже даты окончания",
                    "Ошибка периода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                toolStripStatusLabel.Text = "Загрузка данных...";
                Application.DoEvents();

                GetStatisticsFromDatabase();
                DisplayReportData();
                LoadTopDoctors();
                LoadTopServices();

                toolStripStatusLabel.Text = $"Отчет сформирован за период с {_report.PeriodStart:dd.MM.yyyy} по {_report.PeriodEnd:dd.MM.yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при загрузке отчета филиала: {ex.Message}");
                toolStripStatusLabel.Text = "Ошибка загрузки данных";
            }
        }

        private void GetStatisticsFromDatabase()
        {
            // 1. Статистика по врачам
            GetDoctorsStatistics();

            // 2. Статистика по пациентам
            GetPatientsStatistics();

            // 3. Статистика по приемам
            GetAppointmentsStatistics();

            // 4. Статистика по медсестрам и процедурам
            GetNursesStatistics();
        }

        private void GetDoctorsStatistics()
        {
            try
            {
                // Всего врачей
                string queryDoctors = @"
                    SELECT 
                        COUNT(*) as TotalDoctors,
                        SUM(CASE WHEN IsActive = 1 THEN 1 ELSE 0 END) as ActiveDoctors
                    FROM Employees 
                    WHERE Position = 'Врач' AND ID_branch = @BranchID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", _report.BranchID)
                };

                var result = _db.ExecuteQuery(queryDoctors, parameters);
                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    _report.TotalDoctors = Convert.ToInt32(row["TotalDoctors"]);
                    _report.ActiveDoctors = Convert.ToInt32(row["ActiveDoctors"]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении статистики врачей: {ex.Message}");
            }
        }

        private void GetPatientsStatistics()
        {
            try
            {
                // Всего пациентов
                string queryTotalPatients = "SELECT COUNT(*) FROM Patients WHERE ID_branch = @BranchID";
                // Новые пациенты за период
                string queryNewPatients = @"
                    SELECT COUNT(*) 
                    FROM Patients 
                    WHERE ID_branch = @BranchID 
                    AND DATE(RegistrationDate) BETWEEN @StartDate AND @EndDate";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", _report.BranchID),
                    new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var totalPatients = _db.ExecuteScalar(queryTotalPatients, new SQLiteParameter[] {
                    new SQLiteParameter("@BranchID", _report.BranchID)
                });

                var newPatients = _db.ExecuteScalar(queryNewPatients, parameters);

                _report.TotalPatients = totalPatients != DBNull.Value ? Convert.ToInt32(totalPatients) : 0;
                _report.NewPatientsThisPeriod = newPatients != DBNull.Value ? Convert.ToInt32(newPatients) : 0;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении статистики пациентов: {ex.Message}");
            }
        }

        private void GetAppointmentsStatistics()
        {
            try
            {
                // Получаем DatabaseHelper для главной базы
                var mainDb = DatabaseManager.GetMainDatabase();

                string query = @"
            SELECT 
                COUNT(*) as TotalAppointments,
                SUM(CASE WHEN Status = 'Завершен' THEN 1 ELSE 0 END) as CompletedAppointments,
                SUM(CASE WHEN Status = 'Запланирован' THEN 1 ELSE 0 END) as PlannedAppointments,
                SUM(CASE WHEN Status = 'Отменен' THEN 1 ELSE 0 END) as CanceledAppointments,
                SUM(CASE WHEN Status = 'Пациент не явился' THEN 1 ELSE 0 END) as NoShowAppointments
            FROM Appointments 
            WHERE ID_branch = @BranchID 
            AND DATE(DateTime) BETWEEN @StartDate AND @EndDate";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", _report.BranchID),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var result = _db.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    _report.TotalAppointments = Convert.ToInt32(row["TotalAppointments"]);
                    _report.CompletedAppointments = Convert.ToInt32(row["CompletedAppointments"]);
                    _report.PlannedAppointments = Convert.ToInt32(row["PlannedAppointments"]);
                    _report.CanceledAppointments = Convert.ToInt32(row["CanceledAppointments"]);
                    _report.NoShowAppointments = Convert.ToInt32(row["NoShowAppointments"]);
                }

                // Теперь рассчитываем выручку отдельно
                CalculateRevenue(mainDb);

                // Средняя стоимость приема
                if (_report.CompletedAppointments > 0)
                {
                    _report.AverageAppointmentCost = _report.TotalRevenue / _report.CompletedAppointments;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении статистики приемов: {ex.Message}");
            }
        }

        private void CalculateRevenue(DatabaseHelper mainDb)
        {
            try
            {
                string query = @"
            SELECT 
                a.ID_appointment,
                a.ID_service,
                a.Actual_cost,
                a.Status
            FROM Appointments a
            WHERE a.ID_branch = @BranchID 
            AND DATE(a.DateTime) BETWEEN @StartDate AND @EndDate
            AND a.Status = 'Завершен'";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", _report.BranchID),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var result = _db.ExecuteQuery(query, parameters);

                _report.TotalRevenue = 0;

                foreach (DataRow row in result.Rows)
                {
                    decimal cost = 0;

                    // Если есть фактическая стоимость, используем её
                    if (row["Actual_cost"] != DBNull.Value)
                    {
                        cost = Convert.ToDecimal(row["Actual_cost"]);
                    }

                    // Если фактической стоимости нет или она 0, берём базовую стоимость
                    if (cost <= 0)
                    {
                        int serviceId = Convert.ToInt32(row["ID_service"]);
                        cost = GetServiceBaseCost(mainDb, serviceId);
                    }

                    _report.TotalRevenue += cost;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при расчете выручки: {ex.Message}");
            }
        }

        private void GetNursesStatistics()
        {
            try
            {
                // Всего медсестер
                string queryNurses = "SELECT COUNT(*) FROM Employees WHERE Position = 'Медсестра' AND ID_branch = @BranchID";
                // Выполненные процедуры
                string queryProcedures = @"
                    SELECT COUNT(*) 
                    FROM CompletedProcedures 
                    WHERE ID_branch = @BranchID 
                    AND DATE(ProcedureDateTime) BETWEEN @StartDate AND @EndDate";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", _report.BranchID),
                    new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var totalNurses = _db.ExecuteScalar(queryNurses, new SQLiteParameter[] {
                    new SQLiteParameter("@BranchID", _report.BranchID)
                });

                var completedProcedures = _db.ExecuteScalar(queryProcedures, parameters);

                _report.TotalNurses = totalNurses != DBNull.Value ? Convert.ToInt32(totalNurses) : 0;
                _report.CompletedProcedures = completedProcedures != DBNull.Value ? Convert.ToInt32(completedProcedures) : 0;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении статистики медсестер: {ex.Message}");
            }
        }

        private void DisplayReportData()
        {
            // Основная информация
            lblTotalDoctors.Text = _report.TotalDoctors.ToString();
            lblActiveDoctors.Text = _report.ActiveDoctors.ToString();
            lblTotalPatients.Text = _report.TotalPatients.ToString();
            lblNewPatients.Text = _report.NewPatientsThisPeriod.ToString();
            lblTotalNurses.Text = _report.TotalNurses.ToString();

            // Статистика приемов
            lblTotalAppointments.Text = _report.TotalAppointments.ToString();
            lblCompletedAppointments.Text = _report.CompletedAppointments.ToString();
            lblPlannedAppointments.Text = _report.PlannedAppointments.ToString();
            lblCanceledAppointments.Text = _report.CanceledAppointments.ToString();
            lblNoShowAppointments.Text = _report.NoShowAppointments.ToString();

            // Финансовая статистика
            lblTotalRevenue.Text = _report.TotalRevenue.ToString("N2") + " ₽";
            lblAvgAppointmentCost.Text = _report.AverageAppointmentCost.ToString("N2") + " ₽";
            lblCompletedProcedures.Text = _report.CompletedProcedures.ToString();

            // Процентные показатели
            lblCompletionRate.Text = $"{_report.CompletionRate:F1}%";
            lblNoShowRate.Text = $"{_report.NoShowRate:F1}%";
            lblAvgPerDoctor.Text = _report.AverageAppointmentsPerDoctor.ToString("F1");
            lblRevenuePerDoctor.Text = _report.AverageRevenuePerDoctor.ToString("N2") + " ₽";

            // Прогресс-бары
            progressBarCompletion.Value = (int)_report.CompletionRate;
            progressBarNoShow.Value = (int)_report.NoShowRate;

            // Цвета прогресс-баров
            progressBarCompletion.ForeColor = _report.CompletionRate >= 80 ? Color.Green :
                                             _report.CompletionRate >= 60 ? Color.YellowGreen :
                                             _report.CompletionRate >= 40 ? Color.Orange : Color.Red;

            progressBarNoShow.ForeColor = _report.NoShowRate <= 5 ? Color.Green :
                                         _report.NoShowRate <= 10 ? Color.YellowGreen :
                                         _report.NoShowRate <= 20 ? Color.Orange : Color.Red;
        }

        private void LoadTopDoctors()
        {
            try
            {
                var mainDb = DatabaseManager.GetMainDatabase();

                string query = @"
            SELECT 
                e.ID_employee,
                e.LastName || ' ' || e.FirstName || ' ' || COALESCE(e.MiddleName, '') as DoctorName,
                COUNT(a.ID_appointment) as AppointmentsCount
            FROM Employees e
            LEFT JOIN Appointments a ON e.ID_employee = a.ID_employee 
                AND DATE(a.DateTime) BETWEEN @StartDate AND @EndDate
            WHERE e.Position = 'Врач' 
            AND e.ID_branch = @BranchID
            GROUP BY e.ID_employee
            ORDER BY AppointmentsCount DESC
            LIMIT 5";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", _report.BranchID),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                DataTable doctorsData = _db.ExecuteQuery(query, parameters);

                // Добавляем колонку для выручки
                doctorsData.Columns.Add("Revenue", typeof(decimal));

                foreach (DataRow row in doctorsData.Rows)
                {
                    int doctorId = Convert.ToInt32(row["ID_employee"]);
                    decimal revenue = CalculateDoctorRevenue(doctorId, mainDb);
                    row["Revenue"] = revenue;
                }

                dataGridViewTopDoctors.DataSource = doctorsData;

                // Настраиваем заголовки
                if (dataGridViewTopDoctors.Columns.Count > 0)
                {
                    dataGridViewTopDoctors.Columns["DoctorName"].HeaderText = "Врач";
                    dataGridViewTopDoctors.Columns["AppointmentsCount"].HeaderText = "Кол-во приемов";
                    dataGridViewTopDoctors.Columns["Revenue"].HeaderText = "Выручка (₽)";

                    // Скрываем технические колонки
                    if (dataGridViewTopDoctors.Columns.Contains("ID_employee"))
                        dataGridViewTopDoctors.Columns["ID_employee"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при загрузке топ-врачей: {ex.Message}");
            }
        }

        private decimal CalculateDoctorRevenue(int doctorId, DatabaseHelper mainDb)
        {
            try
            {
                string query = @"
            SELECT 
                a.ID_service,
                a.Actual_cost
            FROM Appointments a
            WHERE a.ID_employee = @DoctorID
            AND a.Status = 'Завершен'
            AND DATE(a.DateTime) BETWEEN @StartDate AND @EndDate";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@DoctorID", doctorId),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var result = _db.ExecuteQuery(query, parameters);

                decimal totalRevenue = 0;

                foreach (DataRow row in result.Rows)
                {
                    decimal cost = 0;

                    // Если есть фактическая стоимость, используем её
                    if (row["Actual_cost"] != DBNull.Value)
                    {
                        cost = Convert.ToDecimal(row["Actual_cost"]);
                    }

                    // Если фактической стоимости нет или она 0, берём базовую стоимость
                    if (cost <= 0)
                    {
                        int serviceId = Convert.ToInt32(row["ID_service"]);
                        cost = GetServiceBaseCost(mainDb, serviceId);
                    }

                    totalRevenue += cost;
                }

                return totalRevenue;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при расчете выручки врача: {ex.Message}");
                return 0;
            }
        }

        private void LoadTopServices()
        {
            try
            {
                var mainDb = DatabaseManager.GetMainDatabase();

                string query = @"
            SELECT 
                a.ID_service,
                COUNT(*) as AppointmentsCount
            FROM Appointments a
            WHERE a.ID_branch = @BranchID
            AND DATE(a.DateTime) BETWEEN @StartDate AND @EndDate
            GROUP BY a.ID_service
            ORDER BY AppointmentsCount DESC
            LIMIT 5";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", _report.BranchID),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                DataTable servicesData = _db.ExecuteQuery(query, parameters);

                // Добавляем дополнительные колонки
                servicesData.Columns.Add("ServiceName", typeof(string));
                servicesData.Columns.Add("AvgCost", typeof(decimal));

                foreach (DataRow row in servicesData.Rows)
                {
                    int serviceId = Convert.ToInt32(row["ID_service"]);

                    // Получаем информацию об услуге
                    var serviceInfo = GetServiceInfo(mainDb, serviceId);
                    row["ServiceName"] = serviceInfo.Name;

                    // Рассчитываем среднюю стоимость для этой услуги
                    decimal avgCost = CalculateAverageCostForService(serviceId);
                    row["AvgCost"] = avgCost;
                }

                dataGridViewTopServices.DataSource = servicesData;

                // Настраиваем заголовки
                if (dataGridViewTopServices.Columns.Count > 0)
                {
                    dataGridViewTopServices.Columns["ServiceName"].HeaderText = "Услуга";
                    dataGridViewTopServices.Columns["AppointmentsCount"].HeaderText = "Кол-во";
                    dataGridViewTopServices.Columns["AvgCost"].HeaderText = "Ср. стоимость (₽)";

                    // Скрываем технические колонки
                    if (dataGridViewTopServices.Columns.Contains("ID_service"))
                        dataGridViewTopServices.Columns["ID_service"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при загрузке топ-услуг: {ex.Message}");
            }
        }

        private (string Name, decimal BaseCost) GetServiceInfo(DatabaseHelper db, int serviceId)
        {
            try
            {
                string query = "SELECT Name, Base_cost FROM MedicalServices WHERE ID_service = @ServiceID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@ServiceID", serviceId)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    return (
                        result.Rows[0]["Name"].ToString(),
                        result.Rows[0]["Base_cost"] != DBNull.Value ?
                            Convert.ToDecimal(result.Rows[0]["Base_cost"]) : 0
                    );
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении информации об услуге: {ex.Message}");
            }

            return ("Неизвестная услуга", 0);
        }

        private decimal CalculateAverageCostForService(int serviceId)
        {
            try
            {
                string query = @"
            SELECT 
                AVG(
                    CASE 
                        WHEN Actual_cost IS NOT NULL AND Actual_cost > 0 THEN Actual_cost
                        ELSE 0
                    END
                ) as AvgCost
            FROM Appointments 
            WHERE ID_service = @ServiceID
            AND ID_branch = @BranchID
            AND DATE(DateTime) BETWEEN @StartDate AND @EndDate";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@ServiceID", serviceId),
            new SQLiteParameter("@BranchID", _report.BranchID),
            new SQLiteParameter("@StartDate", _report.PeriodStart.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@EndDate", _report.PeriodEnd.ToString("yyyy-MM-dd"))
                };

                var result = _db.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    decimal avgCost = Convert.ToDecimal(result);

                    // Если средняя стоимость 0, берем базовую стоимость
                    if (avgCost <= 0)
                    {
                        var mainDb = DatabaseManager.GetMainDatabase();
                        avgCost = GetServiceBaseCost(mainDb, serviceId);
                    }

                    return Math.Round(avgCost, 2);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при расчете средней стоимости услуги: {ex.Message}");
            }

            return 0;
        }

        private decimal GetServiceBaseCost(DatabaseHelper db, int serviceId)
        {
            try
            {
                string query = "SELECT Base_cost FROM MedicalServices WHERE ID_service = @ServiceID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@ServiceID", serviceId)
                };

                var result = db.ExecuteScalar(query, parameters);
                return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении стоимости услуги: {ex.Message}");
                return 0;
            }
        }
    }
}