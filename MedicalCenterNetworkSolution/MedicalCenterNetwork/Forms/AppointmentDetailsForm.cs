using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MedicalCenterNetwork.Data;

namespace MedicalCenterNetwork.Forms
{
    public partial class AppointmentDetailsForm : Form
    {
        private int _appointmentId;
        private DatabaseHelper _db;

        public AppointmentDetailsForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _db = DatabaseManager.GetCurrentBranchDatabase();
        }

        private void AppointmentDetailsForm_Load(object sender, EventArgs e)
        {
            LoadAppointmentDetails();
        }

        private void LoadAppointmentDetails()
        {
            try
            {
                // Получаем DatabaseHelper для текущего филиала (для таблиц пациентов, врачей и записей)
                var branchDb = DatabaseManager.GetCurrentBranchDatabase();
                // Получаем DatabaseHelper для главной базы (для медицинских услуг)
                var mainDb = DatabaseManager.GetMainDatabase();

                // Запрос для получения данных о записи, пациенте, враче и кабинете
                string query = @"
                    SELECT 
                        a.*,
                        p.LastName || ' ' || p.FirstName || ' ' || p.MiddleName as PatientFullName,
                        p.DateOfBirth,
                        p.Gender,
                        p.Phone,
                        p.Email,
                        e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as DoctorFullName,
                        a.ID_service as ServiceID,
                        c.CabinetNumber,
                        c.Purpose
                    FROM Appointments a
                    INNER JOIN Patients p ON a.ID_patient = p.ID_patient
                    INNER JOIN Employees e ON a.ID_employee = e.ID_employee
                    LEFT JOIN Cabinets c ON a.ID_cabinet = c.ID_cabinet
                    WHERE a.ID_appointment = @AppointmentID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@AppointmentID", _appointmentId)
                };

                var result = branchDb.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];

                    // Получаем информацию об услуге из главной базы
                    int serviceId = Convert.ToInt32(row["ServiceID"]);
                    var serviceInfo = GetServiceInfo(mainDb, serviceId);

                    // Создаем словарь с данными для отображения
                    var appointmentData = new Dictionary<string, object>();

                    // Копируем все данные из DataRow в словарь
                    foreach (DataColumn column in result.Columns)
                    {
                        appointmentData[column.ColumnName] = row[column];
                    }

                    // Добавляем данные об услуге
                    appointmentData["ServiceName"] = serviceInfo.Name;
                    appointmentData["Duration_minutes"] = serviceInfo.Duration;
                    appointmentData["Base_cost"] = serviceInfo.BaseCost;

                    DisplayAppointmentDetails(appointmentData);
                }
                else
                {
                    MessageBox.Show("Запись на прием не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Вспомогательный метод для получения информации об услуге
        private (string Name, int Duration, decimal BaseCost) GetServiceInfo(DatabaseHelper db, int serviceId)
        {
            try
            {
                string query = "SELECT Name, Duration_minutes, Base_cost FROM MedicalServices WHERE ID_service = @ServiceID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ServiceID", serviceId)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    return (
                        row["Name"].ToString(),
                        Convert.ToInt32(row["Duration_minutes"]),
                        row["Base_cost"] != DBNull.Value ? Convert.ToDecimal(row["Base_cost"]) : 0
                    );
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении информации об услуге: {ex.Message}");
            }

            // Возвращаем значения по умолчанию в случае ошибки
            return ("Неизвестная услуга", 30, 0);
        }

        private void DisplayAppointmentDetails(Dictionary<string, object> appointmentData)
        {
            try
            {
                // Основная информация
                lblDateTime.Text = Convert.ToDateTime(appointmentData["DateTime"]).ToString("dd.MM.yyyy HH:mm");
                lblPatient.Text = appointmentData["PatientFullName"].ToString();
                lblDoctor.Text = appointmentData["DoctorFullName"].ToString();
                lblService.Text = appointmentData.ContainsKey("ServiceName") ? appointmentData["ServiceName"].ToString() : "Неизвестная услуга";

                // Длительность
                if (appointmentData.ContainsKey("Duration_minutes"))
                {
                    lblDuration.Text = $"{appointmentData["Duration_minutes"]} мин.";
                }
                else
                {
                    lblDuration.Text = "30 мин.";
                }

                // Базовая стоимость
                if (appointmentData.ContainsKey("Base_cost") && appointmentData["Base_cost"] != DBNull.Value)
                {
                    decimal baseCost = Convert.ToDecimal(appointmentData["Base_cost"]);
                    lblBaseCost.Text = $"{baseCost:N0} ₽";
                }
                else
                {
                    lblBaseCost.Text = "0 ₽";
                }

                lblStatus.Text = appointmentData["Status"].ToString();
                UpdateStatusColor(appointmentData["Status"].ToString());

                // Кабинет
                if (appointmentData["CabinetNumber"] != DBNull.Value)
                {
                    lblCabinet.Text = $"{appointmentData["CabinetNumber"]} ({appointmentData["Purpose"]})";
                }
                else
                {
                    lblCabinet.Text = "Не указан";
                }

                // Дополнительная информация о пациенте
                if (appointmentData["Gender"] != DBNull.Value && appointmentData["DateOfBirth"] != DBNull.Value)
                {
                    string gender = appointmentData["Gender"].ToString();
                    DateTime birthDate = Convert.ToDateTime(appointmentData["DateOfBirth"]);
                    int age = CalculateAge(birthDate);
                    lblPatientInfo.Text = $"{gender}, {birthDate:dd.MM.yyyy} ({age} лет)";
                }
                else
                {
                    lblPatientInfo.Text = "Не указано";
                }

                lblPhone.Text = appointmentData["Phone"] != DBNull.Value ? appointmentData["Phone"].ToString() : "Не указан";
                lblEmail.Text = appointmentData["Email"] != DBNull.Value ? appointmentData["Email"].ToString() : "Не указан";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении деталей записи: {ex.Message}", "Ошибка",
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

        // Дополнительный метод для изменения цвета статуса - ОСТАВЛЯЕМ ТОЛЬКО ОДИН ЭТОТ МЕТОД
        private void UpdateStatusColor(string status)
        {
            switch (status)
            {
                case "Запланирован":
                    lblStatus.ForeColor = Color.Blue;
                    break;
                case "Подтвержден":
                    lblStatus.ForeColor = Color.Green;
                    break;
                case "Завершен":
                    lblStatus.ForeColor = Color.Gray;
                    break;
                case "Отменен":
                    lblStatus.ForeColor = Color.Red;
                    break;
                case "Пациент не явился":
                    lblStatus.ForeColor = Color.Orange;
                    break;
                default:
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Диалог для изменения статуса
                using (var statusForm = new Form())
                {
                    statusForm.Text = "Изменение статуса приема";
                    statusForm.Size = new Size(300, 200);
                    statusForm.StartPosition = FormStartPosition.CenterParent;

                    var label = new Label
                    {
                        Text = "Выберите новый статус:",
                        Location = new Point(20, 20),
                        AutoSize = true
                    };

                    var comboBox = new ComboBox
                    {
                        Location = new Point(20, 50),
                        Size = new Size(240, 23),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    comboBox.Items.AddRange(new string[]
                    {
                        "Запланирован",
                        "Подтвержден",
                        "Завершен",
                        "Отменен",
                        "Пациент не явился"
                    });

                    // Устанавливаем текущий статус
                    comboBox.SelectedItem = lblStatus.Text;

                    var btnOk = new Button
                    {
                        Text = "Сохранить",
                        Location = new Point(20, 90),
                        Size = new Size(100, 30),
                        DialogResult = DialogResult.OK
                    };

                    var btnCancel = new Button
                    {
                        Text = "Отмена",
                        Location = new Point(140, 90),
                        Size = new Size(100, 30),
                        DialogResult = DialogResult.Cancel
                    };

                    statusForm.Controls.Add(label);
                    statusForm.Controls.Add(comboBox);
                    statusForm.Controls.Add(btnOk);
                    statusForm.Controls.Add(btnCancel);

                    statusForm.AcceptButton = btnOk;
                    statusForm.CancelButton = btnCancel;

                    if (statusForm.ShowDialog() == DialogResult.OK)
                    {
                        string newStatus = comboBox.SelectedItem.ToString();

                        // Обновляем статус в базе данных ФИЛИАЛА
                        string updateQuery = "UPDATE Appointments SET Status = @Status WHERE ID_appointment = @AppointmentID";
                        var parameters = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@Status", newStatus),
                            new SQLiteParameter("@AppointmentID", _appointmentId)
                        };

                        // Используем базу данных филиала
                        _db.ExecuteNonQuery(updateQuery, parameters);

                        // Обновляем отображение
                        lblStatus.Text = newStatus;

                        // Меняем цвет статуса в зависимости от значения
                        UpdateStatusColor(newStatus);

                        MessageBox.Show("Статус успешно изменен", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении статуса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}