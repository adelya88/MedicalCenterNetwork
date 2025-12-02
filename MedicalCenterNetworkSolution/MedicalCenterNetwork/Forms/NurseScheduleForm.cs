using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;
using System.Collections.Generic;
using System.Text;

namespace MedicalCenterNetwork.Forms
{
    public partial class NurseScheduleForm : Form
    {
        private DatabaseHelper _db;
        private int _nurseId;
        private DateTime _currentDate;

        public NurseScheduleForm()
        {
            InitializeComponent();
            _db = DatabaseManager.GetCurrentBranchDatabase();
            _nurseId = UserSession.EmployeeID;
            _currentDate = DateTime.Today;

            // Обновляем метку даты сразу
            UpdateDateLabel();
        }

        private void NurseScheduleForm_Load(object sender, EventArgs e)
        {
            LoadNurseSchedule();
            UpdateDateLabel();
        }

        private void LoadNurseSchedule()
        {
            try
            {
                // Загружаем процедуры медсестры
                var procedures = GetNurseProcedures();
                DisplayProcedures(procedures);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при загрузке расписания медсестры: {ex.Message}");
            }
        }

        private List<NurseProcedure> GetNurseProcedures()
        {
            var procedures = new List<NurseProcedure>();

            try
            {
                // Запрос для получения назначенных процедур - ИСПРАВЛЕНО по вашей структуре таблицы
                string query = @"
            SELECT 
                cp.ID_procedure,
                cp.ID_patient,
                p.LastName || ' ' || p.FirstName || ' ' || COALESCE(p.MiddleName, '') as PatientFullName,
                cp.ID_nurse,
                cp.ProcedureName as ProcedureType,
                cp.ProcedureDateTime as ScheduledDateTime,
                NULL as CompletedDateTime,
                'Назначено' as Status,
                '' as Notes,
                cp.ID_record as MedicalRecordID,
                COALESCE(mr.Diagnosis, 'Не указан') as Diagnosis
            FROM CompletedProcedures cp
            INNER JOIN Patients p ON cp.ID_patient = p.ID_patient
            LEFT JOIN MedicalRecords mr ON cp.ID_record = mr.ID_record
            WHERE cp.ID_nurse = @NurseID
            AND DATE(cp.ProcedureDateTime) = @SelectedDate
            ORDER BY cp.ProcedureDateTime";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@NurseID", _nurseId),
            new SQLiteParameter("@SelectedDate", _currentDate.ToString("yyyy-MM-dd"))
                };

                var result = _db.ExecuteQuery(query, parameters);

                foreach (DataRow row in result.Rows)
                {
                    var procedure = new NurseProcedure
                    {
                        ID_procedure = Convert.ToInt32(row["ID_procedure"]),
                        ID_patient = Convert.ToInt32(row["ID_patient"]),
                        PatientFullName = row["PatientFullName"].ToString(),
                        ID_nurse = Convert.ToInt32(row["ID_nurse"]),
                        ProcedureType = row["ProcedureType"].ToString(),
                        ScheduledDateTime = Convert.ToDateTime(row["ScheduledDateTime"]),
                        Status = row["Status"].ToString(),
                        Notes = row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "",
                        MedicalRecordID = row["MedicalRecordID"] != DBNull.Value ?
                            Convert.ToInt32(row["MedicalRecordID"]) : (int?)null,
                        Diagnosis = row["Diagnosis"].ToString()
                    };

                    if (row["CompletedDateTime"] != DBNull.Value)
                    {
                        procedure.CompletedDateTime = Convert.ToDateTime(row["CompletedDateTime"]);
                    }

                    procedures.Add(procedure);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке процедур: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.LogError($"Ошибка при загрузке процедур медсестры: {ex.Message}");
            }

            return procedures;
        }

        private void DisplayProcedures(List<NurseProcedure> procedures)
        {
            listViewProcedures.Items.Clear();

            if (procedures.Count == 0)
            {
                var item = new ListViewItem("Нет назначенных процедур на выбранную дату");
                item.ForeColor = Color.Gray;
                listViewProcedures.Items.Add(item);
                return;
            }

            foreach (var procedure in procedures)
            {
                var item = new ListViewItem(procedure.ScheduledDateTime.ToString("HH:mm"));
                item.SubItems.Add(procedure.PatientFullName);
                item.SubItems.Add(procedure.ProcedureType);
                item.SubItems.Add(procedure.Diagnosis);
                item.SubItems.Add(procedure.Status);
                item.SubItems.Add(procedure.Notes);

                // Раскрашиваем в зависимости от статуса
                if (procedure.IsCompleted)
                {
                    item.BackColor = Color.LightGreen;
                    item.ForeColor = Color.DarkGreen;
                }
                else if (procedure.IsOverdue)
                {
                    item.BackColor = Color.LightPink;
                    item.ForeColor = Color.DarkRed;
                }
                else
                {
                    item.BackColor = Color.LightBlue;
                    item.ForeColor = Color.DarkBlue;
                }

                // Сохраняем ID процедуры в Tag
                item.Tag = procedure.ID_procedure;

                listViewProcedures.Items.Add(item);
            }
        }

        private void UpdateDateLabel()
        {
            if (labelDate != null && !labelDate.IsDisposed)
            {
                labelDate.Text = _currentDate.ToString("dd.MM.yyyy");
            }
        }

        private void buttonToday_Click(object sender, EventArgs e)
        {
            _currentDate = DateTime.Today;
            UpdateDateLabel();
            LoadNurseSchedule();
        }

        private void buttonPrevDay_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddDays(-1);
            UpdateDateLabel();
            LoadNurseSchedule();
        }

        private void buttonNextDay_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddDays(1);
            UpdateDateLabel();
            LoadNurseSchedule();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadNurseSchedule();
        }

        private void listViewProcedures_DoubleClick(object sender, EventArgs e)
        {
            if (listViewProcedures.SelectedItems.Count > 0)
            {
                var selectedItem = listViewProcedures.SelectedItems[0];
                if (selectedItem.Tag != null && selectedItem.Tag is int procedureId)
                {
                    OpenProcedureDetails(procedureId);
                }
            }
        }

        private void OpenProcedureDetails(int procedureId)
        {
            try
            {
                string query = @"
            SELECT 
                cp.*,
                p.LastName || ' ' || p.FirstName || ' ' || COALESCE(p.MiddleName, '') as PatientFullName,
                p.DateOfBirth,
                p.Gender,
                p.Phone,
                e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorFullName,
                COALESCE(mr.Diagnosis, 'Не указан') as Diagnosis,
                mr.Prescriptions
            FROM CompletedProcedures cp
            INNER JOIN Patients p ON cp.ID_patient = p.ID_patient
            LEFT JOIN MedicalRecords mr ON cp.ID_record = mr.ID_record
            LEFT JOIN Employees e ON mr.ID_doctor = e.ID_employee
            WHERE cp.ID_procedure = @ProcedureID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@ProcedureID", procedureId)
                };

                var result = _db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    ShowProcedureDetailsDialog(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии деталей процедуры: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowProcedureDetailsDialog(DataRow procedureData)
        {
            var detailsForm = new Form
            {
                Text = "Детали процедуры",
                Width = 500,
                Height = 400,
                StartPosition = FormStartPosition.CenterParent
            };

            var textBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10)
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== ДЕТАЛИ ПРОЦЕДУРЫ ===");
            sb.AppendLine($"Процедура: {procedureData["ProcedureName"]}");
            sb.AppendLine($"Пациент: {procedureData["PatientFullName"]}");

            if (procedureData["DateOfBirth"] != DBNull.Value)
            {
                DateTime birthDate = Convert.ToDateTime(procedureData["DateOfBirth"]);
                int age = CalculateAge(birthDate);
                sb.AppendLine($"Возраст: {age} лет, Пол: {procedureData["Gender"]}");
            }

            sb.AppendLine($"Телефон: {procedureData["Phone"]}");

            if (procedureData["DoctorFullName"] != DBNull.Value)
            {
                sb.AppendLine($"Назначил врач: {procedureData["DoctorFullName"]}");
            }

            sb.AppendLine($"Диагноз: {procedureData["Diagnosis"]}");

            if (procedureData["Prescriptions"] != DBNull.Value)
            {
                sb.AppendLine($"Назначения: {procedureData["Prescriptions"]}");
            }

            sb.AppendLine($"Дата процедуры: {Convert.ToDateTime(procedureData["ProcedureDateTime"]):dd.MM.yyyy HH:mm}");

            // В вашей таблице нет CompletedDateTime, но есть ProcedureDateTime
            sb.AppendLine($"Статус: Запланировано");

            textBox.Text = sb.ToString();
            detailsForm.Controls.Add(textBox);

            // Кнопка для отметки выполнения
            // В вашей таблице нет статуса, но можно добавить
            var btnComplete = new Button
            {
                Text = "Отметить выполненной",
                Location = new Point(20, 320),
                Size = new Size(150, 30)
            };

            btnComplete.Click += (s, e) =>
            {
                MarkProcedureAsCompleted(Convert.ToInt32(procedureData["ID_procedure"]));
                detailsForm.Close();
                LoadNurseSchedule(); // Обновляем список
            };

            detailsForm.Controls.Add(btnComplete);

            var btnClose = new Button
            {
                Text = "Закрыть",
                Location = new Point(330, 320),
                Size = new Size(150, 30)
            };

            btnClose.Click += (s, e) => detailsForm.Close();
            detailsForm.Controls.Add(btnClose);

            detailsForm.ShowDialog();
        }

        private void MarkProcedureAsCompleted(int procedureId)
        {
            try
            {
                // В вашей таблице нет поля CompletedDateTime, но можно добавить запись
                // или обновить существующую. Предположим, что мы просто отмечаем как выполненную
                string updateQuery = @"
            UPDATE CompletedProcedures 
            SET ProcedureDateTime = @CurrentDateTime
            WHERE ID_procedure = @ProcedureID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@CurrentDateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            new SQLiteParameter("@ProcedureID", procedureId)
                };

                _db.ExecuteNonQuery(updateQuery, parameters);

                MessageBox.Show("Процедура отмечена как выполненная", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении процедуры: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}