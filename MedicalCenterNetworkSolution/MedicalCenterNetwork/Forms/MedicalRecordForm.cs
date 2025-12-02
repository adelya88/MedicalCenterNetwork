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
    public partial class MedicalRecordForm : Form
    {
        private DatabaseHelper db;
        private Patient currentPatient;
        private Appointment currentAppointment;
        private List<MedicalRecord> patientHistory = new List<MedicalRecord>();
        private MedicalRecord currentRecord;

        // Режимы работы формы
        private bool isViewMode = false; // true - только просмотр, false - редактирование
        private bool isNewRecord = false;

        public MedicalRecordForm(Patient patient = null, Appointment appointment = null)
        {
            InitializeComponent();

            db = DatabaseManager.GetCurrentBranchDatabase();
            currentPatient = patient;
            currentAppointment = appointment;

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Настройка формы по роли пользователя
            ConfigureFormByRole();

            if (currentPatient != null)
            {
                LoadPatientData();
                LoadPatientHistory();
            }

            if (currentAppointment != null)
            {
                LoadAppointmentData();
                LoadCurrentMedicalRecord();
            }
        }

        private void ConfigureFormByRole()
        {
            bool isDoctor = UserSession.Position == "Врач";

            if (!isDoctor)
            {
                // Для не-врачей только просмотр
                isViewMode = true;
                SetControlsReadOnly(true);
                buttonSave.Visible = false;
                buttonNewRecord.Visible = false;
                this.Text = "Просмотр медицинской карты";
            }
            else
            {
                // Для врачей можно редактировать
                isViewMode = false;
                SetControlsReadOnly(false);
                this.Text = "Медицинская карта пациента";
            }
        }

        private void SetControlsReadOnly(bool readOnly)
        {
            textBoxComplaints.ReadOnly = readOnly;
            textBoxDiagnosis.ReadOnly = readOnly;
            textBoxAnamnesis.ReadOnly = readOnly;
            textBoxExaminationResults.ReadOnly = readOnly;
            textBoxPrescriptions.ReadOnly = readOnly;

            // Визуальные подсказки
            if (readOnly)
            {
                textBoxComplaints.BackColor = SystemColors.Control;
                textBoxDiagnosis.BackColor = SystemColors.Control;
                textBoxAnamnesis.BackColor = SystemColors.Control;
                textBoxExaminationResults.BackColor = SystemColors.Control;
                textBoxPrescriptions.BackColor = SystemColors.Control;
            }
            else
            {
                textBoxComplaints.BackColor = Color.White;
                textBoxDiagnosis.BackColor = Color.White;
                textBoxAnamnesis.BackColor = Color.White;
                textBoxExaminationResults.BackColor = Color.White;
                textBoxPrescriptions.BackColor = Color.White;
            }
        }

        private void LoadPatientData()
        {
            try
            {
                if (currentPatient == null) return;

                labelPatientName.Text = currentPatient.FullName;
                labelPatientBirthDate.Text = $"Дата рождения: {currentPatient.DateOfBirth:dd.MM.yyyy}";
                labelPatientAge.Text = $"Возраст: {CalculateAge(currentPatient.DateOfBirth)} лет";
                labelPatientPhone.Text = $"Телефон: {currentPatient.Phone}";

                if (!string.IsNullOrEmpty(currentPatient.Address))
                    labelPatientAddress.Text = $"Адрес: {currentPatient.Address}";
                else
                    labelPatientAddress.Text = "Адрес: не указан";

                // Пол
                string gender = currentPatient.Gender == "M" ? "Мужской" :
                               currentPatient.Gender == "F" ? "Женский" : "Не указан";
                labelPatientGender.Text = $"Пол: {gender}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных пациента: {ex.Message}", "Ошибка",
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

        private void LoadAppointmentData(string doctorFullName = null, int serviceId = 0)
        {
            try
            {
                if (currentAppointment == null) return;

                labelAppointmentDate.Text = $"Дата приема: {currentAppointment.DateTime:dd.MM.yyyy HH:mm}";

                // Используем переданное имя врача или показываем "Не указан"
                string doctorText = !string.IsNullOrEmpty(doctorFullName) ? doctorFullName : "Не указан";
                labelAppointmentDoctor.Text = $"Врач: {doctorText}";

                // Формируем текст услуги
                string serviceText = "Услуга не указана";
                if (serviceId > 0)
                {
                    // Пробуем получить название услуги из главной базы
                    try
                    {
                        // Создаем DatabaseHelper для главной базы
                        var mainDb = DatabaseManager.GetMainDatabase();
                        string serviceQuery = "SELECT Name FROM MedicalServices WHERE ID_service = @ServiceID";
                        var serviceParam = new SQLiteParameter("@ServiceID", serviceId);
                        var serviceResult = mainDb.ExecuteScalar(serviceQuery, new[] { serviceParam });

                        if (serviceResult != null)
                            serviceText = serviceResult.ToString();
                        else
                            serviceText = $"Услуга #{serviceId}";
                    }
                    catch
                    {
                        serviceText = $"Услуга #{serviceId}";
                    }
                }

                labelAppointmentService.Text = $"Услуга: {serviceText}";
                labelAppointmentStatus.Text = $"Статус: {currentAppointment.Status}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных приема: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentMedicalRecord()
        {
            try
            {
                if (currentAppointment == null) return;

                string query = @"
                    SELECT * FROM MedicalRecords 
                    WHERE ID_appointment = @AppointmentID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@AppointmentID", currentAppointment.ID_appointment)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    currentRecord = new MedicalRecord
                    {
                        ID_record = Convert.ToInt32(row["ID_record"]),
                        ID_patient = Convert.ToInt32(row["ID_patient"]),
                        ID_appointment = Convert.ToInt32(row["ID_appointment"]),
                        ID_doctor = Convert.ToInt32(row["ID_doctor"]),
                        Complaints = row["Complaints"] != DBNull.Value ? row["Complaints"].ToString() : "",
                        Diagnosis = row["Diagnosis"] != DBNull.Value ? row["Diagnosis"].ToString() : "",
                        Anamnesis = row["Anamnesis"] != DBNull.Value ? row["Anamnesis"].ToString() : "",
                        ExaminationResults = row["ExaminationResults"] != DBNull.Value ? row["ExaminationResults"].ToString() : "",
                        Prescriptions = row["Prescriptions"] != DBNull.Value ? row["Prescriptions"].ToString() : "",
                        CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"])
                    };

                    // Заполняем поля формы
                    textBoxComplaints.Text = currentRecord.Complaints;
                    textBoxDiagnosis.Text = currentRecord.Diagnosis;
                    textBoxAnamnesis.Text = currentRecord.Anamnesis;
                    textBoxExaminationResults.Text = currentRecord.ExaminationResults;
                    textBoxPrescriptions.Text = currentRecord.Prescriptions;

                    isNewRecord = false;
                }
                else
                {
                    // Создаем новую запись
                    currentRecord = new MedicalRecord
                    {
                        ID_patient = currentPatient?.ID_patient ?? 0,
                        ID_appointment = currentAppointment.ID_appointment,
                        ID_doctor = currentAppointment.ID_employee,
                        CreatedDateTime = DateTime.Now
                    };

                    ClearForm();
                    isNewRecord = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке медицинской записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientHistory()
        {
            try
            {
                if (currentPatient == null) return;

                patientHistory.Clear();
                dataGridViewHistory.Rows.Clear();

                string query = @"
                    SELECT mr.*, 
                           a.DateTime as AppointmentDate,
                           e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorName
                    FROM MedicalRecords mr
                    INNER JOIN Appointments a ON mr.ID_appointment = a.ID_appointment
                    INNER JOIN Employees e ON mr.ID_doctor = e.ID_employee
                    WHERE mr.ID_patient = @PatientID
                    ORDER BY a.DateTime DESC";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@PatientID", currentPatient.ID_patient)
                };

                var result = db.ExecuteQuery(query, parameters);

                foreach (DataRow row in result.Rows)
                {
                    var record = new MedicalRecord
                    {
                        ID_record = Convert.ToInt32(row["ID_record"]),
                        ID_patient = Convert.ToInt32(row["ID_patient"]),
                        ID_appointment = Convert.ToInt32(row["ID_appointment"]),
                        ID_doctor = Convert.ToInt32(row["ID_doctor"]),
                        Complaints = row["Complaints"] != DBNull.Value ? row["Complaints"].ToString() : "",
                        Diagnosis = row["Diagnosis"] != DBNull.Value ? row["Diagnosis"].ToString() : "",
                        Anamnesis = row["Anamnesis"] != DBNull.Value ? row["Anamnesis"].ToString() : "",
                        ExaminationResults = row["ExaminationResults"] != DBNull.Value ? row["ExaminationResults"].ToString() : "",
                        Prescriptions = row["Prescriptions"] != DBNull.Value ? row["Prescriptions"].ToString() : "",
                        CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"])
                    };

                    patientHistory.Add(record);

                    // Добавляем в DataGridView
                    DateTime appointmentDate = Convert.ToDateTime(row["AppointmentDate"]);
                    string doctorName = row["DoctorName"].ToString();
                    string diagnosis = record.Diagnosis.Length > 50 ?
                        record.Diagnosis.Substring(0, 50) + "..." : record.Diagnosis;

                    dataGridViewHistory.Rows.Add(
                        appointmentDate.ToString("dd.MM.yyyy HH:mm"),
                        doctorName,
                        diagnosis,
                        record.ID_record
                    );
                }

                labelHistoryCount.Text = $"История обращений: {patientHistory.Count} записей";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории пациента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            textBoxComplaints.Text = "";
            textBoxDiagnosis.Text = "";
            textBoxAnamnesis.Text = "";
            textBoxExaminationResults.Text = "";
            textBoxPrescriptions.Text = "";
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            // Проверка жалоб (обязательное поле)
            if (string.IsNullOrWhiteSpace(textBoxComplaints.Text))
            {
                errorProvider.SetError(textBoxComplaints, "Заполните жалобы пациента");
                isValid = false;
            }

            // Проверка диагноза (обязательное поле)
            if (string.IsNullOrWhiteSpace(textBoxDiagnosis.Text))
            {
                errorProvider.SetError(textBoxDiagnosis, "Укажите диагноз");
                isValid = false;
            }

            return isValid;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Отладочная информация
                Console.WriteLine($"isNewRecord: {isNewRecord}");
                Console.WriteLine($"currentRecord is null: {currentRecord == null}");
                if (currentRecord != null)
                {
                    Console.WriteLine($"Patient ID: {currentRecord.ID_patient}");
                    Console.WriteLine($"Doctor ID: {currentRecord.ID_doctor}");
                }

                if (!ValidateForm()) return;

                if (currentRecord == null)
                {
                    MessageBox.Show("Нет данных для сохранения", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновляем данные записи
                currentRecord.Complaints = textBoxComplaints.Text;
                currentRecord.Diagnosis = textBoxDiagnosis.Text;
                currentRecord.Anamnesis = textBoxAnamnesis.Text;
                currentRecord.ExaminationResults = textBoxExaminationResults.Text;
                currentRecord.Prescriptions = textBoxPrescriptions.Text;
                currentRecord.CreatedDateTime = DateTime.Now;

                if (isNewRecord)
                {
                    Console.WriteLine("Сохранение новой записи...");

                    // Вставляем новую запись
                    string insertQuery = @"
                INSERT INTO MedicalRecords 
                (ID_patient, ID_appointment, ID_doctor, Complaints, Diagnosis, 
                 Anamnesis, ExaminationResults, Prescriptions, CreatedDateTime)
                VALUES 
                (@PatientID, @AppointmentID, @DoctorID, @Complaints, @Diagnosis,
                 @Anamnesis, @ExaminationResults, @Prescriptions, @CreatedDateTime);
                SELECT last_insert_rowid();";

                    var parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@PatientID", currentRecord.ID_patient),
                new SQLiteParameter("@AppointmentID", currentRecord.ID_appointment > 0 ?
                    (object)currentRecord.ID_appointment : DBNull.Value),
                new SQLiteParameter("@DoctorID", currentRecord.ID_doctor),
                new SQLiteParameter("@Complaints", currentRecord.Complaints ?? (object)DBNull.Value),
                new SQLiteParameter("@Diagnosis", currentRecord.Diagnosis ?? (object)DBNull.Value),
                new SQLiteParameter("@Anamnesis", currentRecord.Anamnesis ?? (object)DBNull.Value),
                new SQLiteParameter("@ExaminationResults", currentRecord.ExaminationResults ?? (object)DBNull.Value),
                new SQLiteParameter("@Prescriptions", currentRecord.Prescriptions ?? (object)DBNull.Value),
                new SQLiteParameter("@CreatedDateTime", currentRecord.CreatedDateTime.ToString("yyyy-MM-dd HH:mm:ss"))
                    };

                    var result = db.ExecuteScalar(insertQuery, parameters);
                    if (result != null)
                    {
                        currentRecord.ID_record = Convert.ToInt32(result);
                        isNewRecord = false;

                        MessageBox.Show("Медицинская запись успешно создана!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Console.WriteLine($"Новая запись создана с ID: {currentRecord.ID_record}");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать запись", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine("Обновление существующей записи...");

                    // Обновляем существующую запись
                    string updateQuery = @"
                UPDATE MedicalRecords SET
                    Complaints = @Complaints,
                    Diagnosis = @Diagnosis,
                    Anamnesis = @Anamnesis,
                    ExaminationResults = @ExaminationResults,
                    Prescriptions = @Prescriptions,
                    CreatedDateTime = @CreatedDateTime
                WHERE ID_record = @RecordID";

                    var parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@Complaints", currentRecord.Complaints ?? (object)DBNull.Value),
                new SQLiteParameter("@Diagnosis", currentRecord.Diagnosis ?? (object)DBNull.Value),
                new SQLiteParameter("@Anamnesis", currentRecord.Anamnesis ?? (object)DBNull.Value),
                new SQLiteParameter("@ExaminationResults", currentRecord.ExaminationResults ?? (object)DBNull.Value),
                new SQLiteParameter("@Prescriptions", currentRecord.Prescriptions ?? (object)DBNull.Value),
                new SQLiteParameter("@CreatedDateTime", currentRecord.CreatedDateTime.ToString("yyyy-MM-dd HH:mm:ss")),
                new SQLiteParameter("@RecordID", currentRecord.ID_record)
                    };

                    int rowsAffected = db.ExecuteNonQuery(updateQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Медицинская запись успешно обновлена", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить запись", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Обновляем историю
                LoadPatientHistory();

                // Если есть привязка к приему, обновляем статус
                if (currentAppointment != null && currentAppointment.Status == "Запланирован")
                {
                    UpdateAppointmentStatus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении медицинской записи: {ex.Message}\n\nДетали:\n{ex.StackTrace}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAppointmentStatus()
        {
            try
            {
                string query = "UPDATE Appointments SET Status = 'Завершен' WHERE ID_appointment = @AppointmentID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@AppointmentID", currentAppointment.ID_appointment)
                };

                db.ExecuteNonQuery(query, parameters);
                currentAppointment.Status = "Завершен";
                labelAppointmentStatus.Text = "Статус: Завершен";
            }
            catch (Exception ex)
            {
                // Логируем, но не прерываем работу
                Logger.LogError($"Ошибка при обновлении статуса приема: {ex.Message}");
            }
        }

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPatient == null)
                {
                    MessageBox.Show("Сначала выберите пациента", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Спрашиваем подтверждение, если есть несохраненные изменения
                if (!string.IsNullOrEmpty(textBoxComplaints.Text) ||
                    !string.IsNullOrEmpty(textBoxDiagnosis.Text))
                {
                    var result = MessageBox.Show("Есть несохраненные изменения. Создать новую запись?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                ClearForm();

                // Создаем новую запись
                currentRecord = new MedicalRecord
                {
                    ID_patient = currentPatient.ID_patient,
                    ID_doctor = UserSession.EmployeeID,
                    CreatedDateTime = DateTime.Now
                };

                // Если есть текущий прием, связываем с ним
                if (currentAppointment != null)
                {
                    currentRecord.ID_appointment = currentAppointment.ID_appointment;
                    currentRecord.ID_doctor = currentAppointment.ID_employee;
                }

                isNewRecord = true;

                // Обновляем статус формы
                this.Text = $"Медицинская карта пациента - Новая запись";

                // Устанавливаем фокус
                textBoxComplaints.Focus();

                // Показываем сообщение для отладки
                MessageBox.Show("Режим создания новой записи активирован. Заполните поля и нажмите 'Сохранить'.",
                    "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании новой записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearchPatient_Click(object sender, EventArgs e)
        {
            var searchForm = new PatientSearchForm();
            if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedPatient != null)
            {
                currentPatient = searchForm.SelectedPatient;
                LoadPatientData();
                LoadPatientHistory();
                ClearForm();

                // Сбрасываем привязку к приему при смене пациента
                currentAppointment = null;
                LoadAppointmentData(); // Просто без параметров
            }
        }

        private DataRow GetAppointmentDataRowById(int appointmentId)
        {
            try
            {
                // Запрос БЕЗ MedicalServices
                string query = @"
                    SELECT 
                        a.*,
                        e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorFullName
                    FROM Appointments a
                    INNER JOIN Employees e ON a.ID_employee = e.ID_employee
                    WHERE a.ID_appointment = @AppointmentID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@AppointmentID", appointmentId)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            if (currentPatient == null)
            {
                MessageBox.Show("Сначала выберите пациента", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Здесь можно реализовать форму поиска записей на прием для пациента
            // Пока упрощенный вариант
            string query = @"
                SELECT a.*, 
                       e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorFullName
                FROM Appointments a
                INNER JOIN Employees e ON a.ID_employee = e.ID_employee
                WHERE a.ID_patient = @PatientID
                AND a.Status IN ('Запланирован', 'Подтвержден')
                ORDER BY a.DateTime DESC
                LIMIT 10";

            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@PatientID", currentPatient.ID_patient)
            };

            try
            {
                var appointments = db.ExecuteQuery(query, parameters);

                if (appointments.Rows.Count == 0)
                {
                    MessageBox.Show("Нет активных записей на прием для этого пациента", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Простая форма выбора
                var selectForm = new Form
                {
                    Text = "Выберите запись на прием",
                    Width = 600,
                    Height = 400,
                    StartPosition = FormStartPosition.CenterParent
                };

                var listBox = new ListBox
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10),
                    DisplayMember = "Display"
                };

                foreach (DataRow row in appointments.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["DateTime"]);
                    string doctor = row["DoctorFullName"].ToString();

                    // Формируем отображаемый текст
                    string displayText = $"{date:dd.MM.yyyy HH:mm} - {doctor}";

                    // Добавляем статус
                    string status = row["Status"].ToString();
                    displayText += $" ({status})";

                    listBox.Items.Add(new
                    {
                        ID_appointment = Convert.ToInt32(row["ID_appointment"]),
                        Display = displayText,
                        RowIndex = listBox.Items.Count // Сохраняем индекс для доступа к DataRow
                    });
                }

                var buttonSelect = new Button
                {
                    Text = "Выбрать",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                buttonSelect.Click += (s, ev) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        dynamic selected = listBox.SelectedItem;
                        DataRow selectedRow = appointments.Rows[selected.RowIndex];

                        // Создаем объект Appointment
                        currentAppointment = new Appointment
                        {
                            ID_appointment = selected.ID_appointment,
                            ID_branch = Convert.ToInt32(selectedRow["ID_branch"]),
                            ID_patient = Convert.ToInt32(selectedRow["ID_patient"]),
                            ID_employee = Convert.ToInt32(selectedRow["ID_employee"]),
                            ID_service = selectedRow["ID_service"] != DBNull.Value ?
                                Convert.ToInt32(selectedRow["ID_service"]) : 0,
                            DateTime = Convert.ToDateTime(selectedRow["DateTime"]),
                            Status = selectedRow["Status"].ToString(),
                            Actual_cost = selectedRow["Actual_cost"] != DBNull.Value ?
                                Convert.ToDecimal(selectedRow["Actual_cost"]) : (decimal?)null,
                            ID_cabinet = selectedRow["ID_cabinet"] != DBNull.Value ?
                                Convert.ToInt32(selectedRow["ID_cabinet"]) : (int?)null
                        };

                        // Сохраняем имя врача в отдельной переменной
                        string doctorFullName = selectedRow["DoctorFullName"].ToString();

                        // Загружаем данные
                        LoadAppointmentData(doctorFullName, currentAppointment.ID_service);
                        LoadCurrentMedicalRecord();
                        selectForm.DialogResult = DialogResult.OK;
                        selectForm.Close();
                    }
                };

                var buttonCancel = new Button
                {
                    Text = "Отмена",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                buttonCancel.Click += (s, ev) =>
                {
                    selectForm.DialogResult = DialogResult.Cancel;
                    selectForm.Close();
                };

                var panel = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 80
                };

                panel.Controls.Add(buttonSelect);
                panel.Controls.Add(buttonCancel);
                buttonSelect.Location = new Point(selectForm.Width - 220, 10);
                buttonSelect.Size = new Size(100, 30);
                buttonCancel.Location = new Point(selectForm.Width - 110, 10);
                buttonCancel.Size = new Size(100, 30);

                selectForm.Controls.Add(listBox);
                selectForm.Controls.Add(panel);
                selectForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске записей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка при поиске записей на прием: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void dataGridViewHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= patientHistory.Count) return;

            var record = patientHistory[e.RowIndex];
            ShowRecordDetails(record);
        }

        private void ShowRecordDetails(MedicalRecord record)
        {
            var detailsForm = new Form
            {
                Text = $"Медицинская запись от {record.CreatedDateTime:dd.MM.yyyy HH:mm}",
                Width = 700,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent
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
            sb.AppendLine($"=== МЕДИЦИНСКАЯ ЗАПИСЬ #{record.ID_record} ===");
            sb.AppendLine($"Дата создания: {record.CreatedDateTime:dd.MM.yyyy HH:mm}");
            sb.AppendLine();
            sb.AppendLine("=== ЖАЛОБЫ ===");
            sb.AppendLine(record.Complaints);
            sb.AppendLine();
            sb.AppendLine("=== ДИАГНОЗ ===");
            sb.AppendLine(record.Diagnosis);
            sb.AppendLine();

            if (!string.IsNullOrEmpty(record.Anamnesis))
            {
                sb.AppendLine("=== АНАМНЕЗ ===");
                sb.AppendLine(record.Anamnesis);
                sb.AppendLine();
            }

            if (!string.IsNullOrEmpty(record.ExaminationResults))
            {
                sb.AppendLine("=== РЕЗУЛЬТАТЫ ОСМОТРА ===");
                sb.AppendLine(record.ExaminationResults);
                sb.AppendLine();
            }

            if (!string.IsNullOrEmpty(record.Prescriptions))
            {
                sb.AppendLine("=== НАЗНАЧЕНИЯ И РЕКОМЕНДАЦИИ ===");
                sb.AppendLine(record.Prescriptions);
            }

            textBox.Text = sb.ToString();
            detailsForm.Controls.Add(textBox);
            detailsForm.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void SetNewRecordMode()
        {
            try
            {
                // Проверяем, что пациент выбран
                if (currentPatient == null)
                {
                    MessageBox.Show("Сначала выберите пациента", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Очищаем форму
                ClearForm();

                // Создаем новую запись
                currentRecord = new MedicalRecord
                {
                    ID_patient = currentPatient.ID_patient,
                    ID_doctor = UserSession.EmployeeID,
                    CreatedDateTime = DateTime.Now
                };

                isNewRecord = true;

                // Обновляем информацию о враче
                if (currentAppointment != null)
                {
                    currentRecord.ID_appointment = currentAppointment.ID_appointment;
                    currentRecord.ID_doctor = currentAppointment.ID_employee;
                }

                // Устанавливаем фокус на поле жалоб
                textBoxComplaints.Focus();

                MessageBox.Show("Готово к созданию новой записи", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подготовке новой записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckTableColumnExists(string tableName, string columnName)
        {
            try
            {
                string query = $"PRAGMA table_info({tableName})";
                var result = db.ExecuteQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    if (row["name"].ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void MedicalRecordForm_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация при загрузке формы
        }
    }
}