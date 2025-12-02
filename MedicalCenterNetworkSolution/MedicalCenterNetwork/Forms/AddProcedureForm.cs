using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class AddProcedureForm : Form
    {
        private DatabaseHelper db;
        private Employee currentNurse;

        // Вспомогательный класс для хранения данных о медицинских записях
        private class MedicalRecordItem
        {
            public string Display { get; set; }
            public int? ID_record { get; set; }
            public string Prescriptions { get; set; }

            public override string ToString()
            {
                return Display;
            }
        }

        public AddProcedureForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            db = DatabaseManager.GetCurrentBranchDatabase();

            // Получаем данные медсестры из UserSession
            currentNurse = new Employee
            {
                ID_employee = UserSession.EmployeeID
            };

            labelNurse.Text = $"Медсестра: {UserSession.FullName}";

            LoadPatients();
            LoadProceduresList();

            // Устанавливаем текущую дату и время
            dateTimePickerDate.Value = DateTime.Today;
            dateTimePickerTime.Value = DateTime.Now;
        }

        private void LoadPatients()
        {
            try
            {
                string query = @"
                    SELECT ID_patient, 
                           LastName || ' ' || FirstName || ' ' || COALESCE(MiddleName, '') as FullName
                    FROM Patients 
                    WHERE ID_branch = @BranchID
                    ORDER BY LastName, FirstName";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                var patients = db.ExecuteQuery(query, parameters);
                comboBoxPatient.DataSource = patients;
                comboBoxPatient.DisplayMember = "FullName";
                comboBoxPatient.ValueMember = "ID_patient";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пациентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProceduresList()
        {
            // Стандартные процедуры
            comboBoxProcedure.Items.AddRange(new string[]
            {
                "Инъекция",
                "Капельница",
                "Перевязка",
                "Измерение давления",
                "Измерение температуры",
                "Забор крови",
                "ЭКГ",
                "Физиотерапия",
                "Массаж",
                "Другая процедура"
            });

            comboBoxProcedure.SelectedIndex = 0;
        }

        private void LoadPatientMedicalRecords(int patientId)
        {
            try
            {
                string query = @"
                    SELECT 
                        mr.ID_record,
                        mr.Diagnosis,
                        mr.Prescriptions,
                        a.DateTime as AppointmentDate,
                        e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorName
                    FROM MedicalRecords mr
                    INNER JOIN Appointments a ON mr.ID_appointment = a.ID_appointment
                    INNER JOIN Employees e ON mr.ID_doctor = e.ID_employee
                    WHERE mr.ID_patient = @PatientID
                    ORDER BY a.DateTime DESC
                    LIMIT 10";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@PatientID", patientId)
                };

                var records = db.ExecuteQuery(query, parameters);

                if (records.Rows.Count > 0)
                {
                    listBoxRecords.Items.Clear();
                    foreach (DataRow row in records.Rows)
                    {
                        string recordInfo = $"{Convert.ToDateTime(row["AppointmentDate"]):dd.MM.yyyy} - " +
                                          $"{row["DoctorName"]} - {row["Diagnosis"]}";

                        // Преобразуем ID_record в int? с проверкой на DBNull
                        int? recordId = null;
                        if (row["ID_record"] != DBNull.Value)
                        {
                            // Явное преобразование в int (SQLite возвращает long)
                            recordId = Convert.ToInt32(row["ID_record"]);
                        }

                        var item = new MedicalRecordItem
                        {
                            Display = recordInfo,
                            ID_record = recordId,
                            Prescriptions = row["Prescriptions"]?.ToString() ?? ""
                        };

                        listBoxRecords.Items.Add(item);
                    }
                    groupBoxRecords.Visible = true;
                }
                else
                {
                    groupBoxRecords.Visible = false;
                }
            }
            catch (Exception ex)
            {
                groupBoxRecords.Visible = false;
            }
        }

        public void SetPatientInfo(string patientName, string prescriptions, int appointmentId)
        {
            // Устанавливаем пациента в комбобокс
            foreach (DataRowView item in comboBoxPatient.Items)
            {
                if (item["FullName"].ToString() == patientName)
                {
                    comboBoxPatient.SelectedItem = item;
                    break;
                }
            }

            // Показываем назначения
            if (!string.IsNullOrEmpty(prescriptions))
            {
                textBoxPrescriptions.Text = prescriptions;
                textBoxPrescriptions.Visible = true;
                labelPrescriptions.Visible = true;
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (comboBoxPatient.SelectedValue == null)
            {
                errorProvider.SetError(comboBoxPatient, "Выберите пациента");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxProcedure.Text))
            {
                errorProvider.SetError(comboBoxProcedure, "Укажите процедуру");
                isValid = false;
            }

            DateTime selectedDateTime = dateTimePickerDate.Value.Date + dateTimePickerTime.Value.TimeOfDay;
            if (selectedDateTime > DateTime.Now)
            {
                errorProvider.SetError(dateTimePickerDate, "Дата и время не могут быть в будущем");
                isValid = false;
            }

            return isValid;
        }

        private int GetSelectedPatientId()
        {
            if (comboBoxPatient.SelectedItem is DataRowView selectedRow)
            {
                return Convert.ToInt32(selectedRow["ID_patient"]);
            }

            throw new Exception("Пациент не выбран");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                // Формируем дату и время
                DateTime procedureDateTime = dateTimePickerDate.Value.Date + dateTimePickerTime.Value.TimeOfDay;

                // Получаем ID_record, если выбран
                int? recordId = null;
                if (listBoxRecords.SelectedItem is MedicalRecordItem selected)
                {
                    recordId = selected.ID_record;
                }

                // Получаем ID выбранного пациента
                int patientId = GetSelectedPatientId();

                string query = @"
                    INSERT INTO CompletedProcedures (
                        ID_branch, ID_patient, ID_nurse, 
                        ProcedureName, ProcedureDateTime, ID_record
                    ) VALUES (
                        @BranchID, @PatientID, @NurseID,
                        @ProcedureName, @ProcedureDateTime, @RecordID
                    )";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID),
                    new SQLiteParameter("@PatientID", patientId),
                    new SQLiteParameter("@NurseID", currentNurse.ID_employee),
                    new SQLiteParameter("@ProcedureName", comboBoxProcedure.Text),
                    new SQLiteParameter("@ProcedureDateTime", procedureDateTime.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SQLiteParameter("@RecordID", recordId ?? (object)DBNull.Value)
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Процедура успешно добавлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении процедуры: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatient.SelectedItem is DataRowView selectedRow)
            {
                int patientId = Convert.ToInt32(selectedRow["ID_patient"]);
                LoadPatientMedicalRecords(patientId);
            }
        }

        private void listBoxRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRecords.SelectedItem is MedicalRecordItem selected)
            {
                textBoxPrescriptions.Text = selected.Prescriptions;
            }
        }
    }
}