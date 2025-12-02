using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;
using System.Text;

namespace MedicalCenterNetwork.Forms
{
    public partial class CompletedProceduresForm : Form
    {
        private DatabaseHelper db;

        public CompletedProceduresForm()
        {
            InitializeComponent();
            InitializeForm();

            textBoxSearch.KeyPress += textBoxSearch_KeyPress;
        }

        private void InitializeForm()
        {
            db = DatabaseManager.GetCurrentBranchDatabase();
            LoadCompletedProcedures();
        }

        private void LoadCompletedProcedures()
        {
            try
            {
                // Запрос для получения выполненных процедур
                string query = @"
                    SELECT 
                        cp.ID_procedure,
                        cp.ProcedureDateTime,
                        p.LastName || ' ' || p.FirstName || ' ' || p.MiddleName as PatientName,
                        cp.ProcedureName,
                        e_nurse.LastName || ' ' || e_nurse.FirstName || ' ' || e_nurse.MiddleName as NurseName,
                        e_doctor.LastName || ' ' || e_doctor.FirstName || ' ' || e_doctor.MiddleName as DoctorName,
                        mr.Diagnosis
                    FROM CompletedProcedures cp
                    INNER JOIN Patients p ON cp.ID_patient = p.ID_patient
                    INNER JOIN Employees e_nurse ON cp.ID_nurse = e_nurse.ID_employee
                    LEFT JOIN MedicalRecords mr ON cp.ID_record = mr.ID_record
                    LEFT JOIN Appointments a ON mr.ID_appointment = a.ID_appointment
                    LEFT JOIN Employees e_doctor ON a.ID_employee = e_doctor.ID_employee
                    WHERE cp.ID_branch = @BranchID
                    ORDER BY cp.ProcedureDateTime DESC";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                var data = db.ExecuteQuery(query, parameters);
                dataGridViewProcedures.DataSource = data;

                // Настройка внешнего вида DataGridView
                ConfigureDataGridView();

                // Обновляем статистику
                UpdateStatistics(data.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке процедур: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewProcedures.Columns.Count > 0)
            {
                // Настраиваем колонки
                dataGridViewProcedures.Columns["ID_procedure"].Visible = false;

                dataGridViewProcedures.Columns["ProcedureDateTime"].HeaderText = "Дата и время";
                dataGridViewProcedures.Columns["ProcedureDateTime"].Width = 150;

                dataGridViewProcedures.Columns["PatientName"].HeaderText = "Пациент";
                dataGridViewProcedures.Columns["PatientName"].Width = 200;

                dataGridViewProcedures.Columns["ProcedureName"].HeaderText = "Процедура";
                dataGridViewProcedures.Columns["ProcedureName"].Width = 150;

                dataGridViewProcedures.Columns["NurseName"].HeaderText = "Медсестра";
                dataGridViewProcedures.Columns["NurseName"].Width = 180;

                dataGridViewProcedures.Columns["DoctorName"].HeaderText = "Врач";
                dataGridViewProcedures.Columns["DoctorName"].Width = 180;

                dataGridViewProcedures.Columns["Diagnosis"].HeaderText = "Диагноз";
                dataGridViewProcedures.Columns["Diagnosis"].Width = 200;
            }
        }

        private void UpdateStatistics(int count)
        {
            labelStatistics.Text = $"Всего процедур: {count}";

            // Можно добавить дополнительную статистику
            try
            {
                // Количество процедур за сегодня
                string todayQuery = @"
                    SELECT COUNT(*) 
                    FROM CompletedProcedures 
                    WHERE ID_branch = @BranchID 
                    AND DATE(ProcedureDateTime) = DATE('now')";

                var todayParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                var todayResult = db.ExecuteScalar(todayQuery, todayParams);
                int todayCount = todayResult != null ? Convert.ToInt32(todayResult) : 0;

                labelTodayCount.Text = $"Сегодня: {todayCount} процедур";
            }
            catch
            {
                // Игнорируем ошибку статистики
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddProcedureForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCompletedProcedures();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadCompletedProcedures();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchProcedures();
        }

        private void SearchProcedures()
        {
            try
            {
                string searchText = textBoxSearch.Text.Trim();

                string query = @"
                    SELECT 
                        cp.ID_procedure,
                        cp.ProcedureDateTime,
                        p.LastName || ' ' || p.FirstName || ' ' || p.MiddleName as PatientName,
                        cp.ProcedureName,
                        e_nurse.LastName || ' ' || e_nurse.FirstName || ' ' || e_nurse.MiddleName as NurseName,
                        e_doctor.LastName || ' ' || e_doctor.FirstName || ' ' || e_doctor.MiddleName as DoctorName,
                        mr.Diagnosis
                    FROM CompletedProcedures cp
                    INNER JOIN Patients p ON cp.ID_patient = p.ID_patient
                    INNER JOIN Employees e_nurse ON cp.ID_nurse = e_nurse.ID_employee
                    LEFT JOIN MedicalRecords mr ON cp.ID_record = mr.ID_record
                    LEFT JOIN Appointments a ON mr.ID_appointment = a.ID_appointment
                    LEFT JOIN Employees e_doctor ON a.ID_employee = e_doctor.ID_employee
                    WHERE cp.ID_branch = @BranchID
                        AND (p.LastName LIKE @Search 
                             OR p.FirstName LIKE @Search
                             OR p.MiddleName LIKE @Search
                             OR cp.ProcedureName LIKE @Search
                             OR e_nurse.LastName LIKE @Search
                             OR e_nurse.FirstName LIKE @Search)
                    ORDER BY cp.ProcedureDateTime DESC";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID),
                    new SQLiteParameter("@Search", $"%{searchText}%")
                };

                var data = db.ExecuteQuery(query, parameters);
                dataGridViewProcedures.DataSource = data;

                UpdateStatistics(data.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProcedures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowProcedureDetails(e.RowIndex);
            }
        }

        private void ShowProcedureDetails(int rowIndex)
        {
            try
            {
                var row = dataGridViewProcedures.Rows[rowIndex];
                int procedureId = Convert.ToInt32(row.Cells["ID_procedure"].Value);

                string query = @"
                    SELECT 
                        cp.*,
                        p.LastName || ' ' || p.FirstName || ' ' || p.MiddleName as PatientFullName,
                        p.DateOfBirth,
                        p.Phone,
                        p.Gender,
                        e_nurse.LastName || ' ' || e_nurse.FirstName || ' ' || e_nurse.MiddleName as NurseFullName,
                        e_nurse.Position as NursePosition,
                        mr.Complaints,
                        mr.Diagnosis,
                        mr.Prescriptions,
                        mr.Anamnesis,
                        mr.ExaminationResults
                    FROM CompletedProcedures cp
                    INNER JOIN Patients p ON cp.ID_patient = p.ID_patient
                    INNER JOIN Employees e_nurse ON cp.ID_nurse = e_nurse.ID_employee
                    LEFT JOIN MedicalRecords mr ON cp.ID_record = mr.ID_record
                    WHERE cp.ID_procedure = @ProcedureID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ProcedureID", procedureId)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var dataRow = result.Rows[0];
                    ShowDetailsDialog(dataRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении деталей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetailsDialog(DataRow dataRow)
        {
            var detailsForm = new Form
            {
                Text = "Детали процедуры",
                Width = 600,
                Height = 500,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            var textBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10)
            };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== ИНФОРМАЦИЯ О ПРОЦЕДУРЕ ===");
            sb.AppendLine($"ID процедуры: {dataRow["ID_procedure"]}");
            sb.AppendLine($"Процедура: {dataRow["ProcedureName"]}");
            sb.AppendLine($"Дата и время: {Convert.ToDateTime(dataRow["ProcedureDateTime"]):dd.MM.yyyy HH:mm}");
            sb.AppendLine();

            sb.AppendLine("=== ПАЦИЕНТ ===");
            sb.AppendLine($"ФИО: {dataRow["PatientFullName"]}");
            sb.AppendLine($"Дата рождения: {Convert.ToDateTime(dataRow["DateOfBirth"]):dd.MM.yyyy}");
            sb.AppendLine($"Телефон: {dataRow["Phone"]}");
            sb.AppendLine($"Пол: {(dataRow["Gender"].ToString() == "M" ? "Мужской" : "Женский")}");
            sb.AppendLine();

            sb.AppendLine("=== МЕДСЕСТРА ===");
            sb.AppendLine($"ФИО: {dataRow["NurseFullName"]}");
            sb.AppendLine($"Должность: {dataRow["NursePosition"]}");
            sb.AppendLine();

            if (dataRow["ID_record"] != DBNull.Value)
            {
                sb.AppendLine("=== СВЯЗАННАЯ МЕДИЦИНСКАЯ ЗАПИСЬ ===");

                if (!string.IsNullOrEmpty(dataRow["Complaints"].ToString()))
                {
                    sb.AppendLine("Жалобы:");
                    sb.AppendLine(dataRow["Complaints"].ToString());
                    sb.AppendLine();
                }

                if (!string.IsNullOrEmpty(dataRow["Diagnosis"].ToString()))
                {
                    sb.AppendLine("Диагноз:");
                    sb.AppendLine(dataRow["Diagnosis"].ToString());
                    sb.AppendLine();
                }

                if (!string.IsNullOrEmpty(dataRow["Prescriptions"].ToString()))
                {
                    sb.AppendLine("Назначения:");
                    sb.AppendLine(dataRow["Prescriptions"].ToString());
                }
            }

            textBox.Text = sb.ToString();
            detailsForm.Controls.Add(textBox);
            detailsForm.ShowDialog();
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchProcedures();
                e.Handled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}