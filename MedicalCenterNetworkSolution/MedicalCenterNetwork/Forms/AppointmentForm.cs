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
using MedicalCenterNetwork.Data;
using System.Data.SQLite;
using System.Windows.Forms.VisualStyles;

namespace MedicalCenterNetwork.Forms
{
    public partial class AppointmentForm : Form
    {
        private Appointment appointment;
        private DatabaseHelper db;

        public AppointmentForm(Patient patient = null)
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            appointment = new Appointment();

            if (patient != null)
            {
                appointment.ID_patient = patient.ID_patient;
                textBoxPatient.Text = patient.FullName;
                textBoxPatient.Tag = patient; // Сохраняем объект пациента
            }

            InitializeForm();
            LoadComboBoxData();
        }

        private void InitializeForm()
        {
            this.Text = "Запись на прием";
            // Устанавливаем минимальную дату - текущий день
            dateTimePickerDate.MinDate = DateTime.Today;

            // Устанавливаем время по умолчанию - следующий час
            dateTimePickerDate.Value = DateTime.Today.AddDays(1);
            dateTimePickerTime.Value = DateTime.Today.AddHours(10);
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Медицинские услуги из главной базы
                var services = DatabaseManager.GetMedicalServices();
                comboBoxService.DataSource = services;
                comboBoxService.DisplayMember = "Name";
                comboBoxService.ValueMember = "ID_service";

                // Врачи из текущей базы (простой запрос без специализаций)
                string doctorsQuery = @"
    SELECT 
        ID_employee, 
        LastName || ' ' || FirstName || ' ' || MiddleName as FullName
    FROM Employees 
    WHERE Position = 'Врач' AND IsActive = 1 
    AND ID_branch = @BranchID
    ORDER BY LastName, FirstName";

                var doctorsParams = new SQLiteParameter[] {
    new SQLiteParameter("@BranchID", UserSession.BranchID)
};
                var doctors = db.ExecuteQuery(doctorsQuery, doctorsParams);
                comboBoxDoctor.DataSource = doctors;
                comboBoxDoctor.DisplayMember = "FullName";
                comboBoxDoctor.ValueMember = "ID_employee";

                // Убедитесь, что комбобокс в нормальном режиме
                comboBoxDoctor.DrawMode = DrawMode.Normal;

                // Убираем кастомное отображение, так как у нас нет специализации в локальной базе
                comboBoxDoctor.DrawMode = DrawMode.Normal;

                // Кабинеты из текущей базы
                string cabinetsQuery = @"
                    SELECT ID_cabinet, CabinetNumber || ' - ' || Purpose as CabinetInfo 
                    FROM Cabinets 
                    WHERE ID_branch = @BranchID 
                    ORDER BY CabinetNumber";

                var cabinetsParams = new SQLiteParameter[] {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };
                var cabinets = db.ExecuteQuery(cabinetsQuery, cabinetsParams);
                comboBoxCabinet.DataSource = cabinets;
                comboBoxCabinet.DisplayMember = "CabinetInfo";
                comboBoxCabinet.ValueMember = "ID_cabinet";

                // Статусы записей
                comboBoxStatus.Items.AddRange(new string[] {
                    "Запланирован", "Подтвержден", "Завершен", "Отменен", "Пациент не явился"
                });
                comboBoxStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearchPatient_Click(object sender, EventArgs e)
        {
            var searchForm = new PatientSearchForm();
            if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedPatient != null)
            {
                var patient = searchForm.SelectedPatient;
                appointment.ID_patient = patient.ID_patient;
                textBoxPatient.Text = patient.FullName;
                textBoxPatient.Tag = patient;
            }
        }

        // НОВЫЙ МЕТОД: Поиск врача
        private void buttonSearchDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                var searchForm = new DoctorSearchForm();
                if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedDoctor != null)
                {
                    var doctor = searchForm.SelectedDoctor;

                    // Ищем врача в комбобоксе и устанавливаем его как выбранного
                    bool doctorFound = false;
                    for (int i = 0; i < comboBoxDoctor.Items.Count; i++)
                    {
                        var item = comboBoxDoctor.Items[i] as DataRowView;
                        if (item != null && Convert.ToInt32(item["ID_employee"]) == doctor.ID_employee)
                        {
                            comboBoxDoctor.SelectedIndex = i;
                            doctorFound = true;
                            break;
                        }
                    }

                    if (!doctorFound)
                    {
                        MessageBox.Show("Выбранный врач не найден в списке доступных врачей", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе врача: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveAppointment();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Проверка пациента
            if (appointment.ID_patient == 0)
            {
                errorProvider.SetError(textBoxPatient, "Выберите пациента");
                isValid = false;
            }

            // Проверка врача
            if (comboBoxDoctor.SelectedValue == null)
            {
                errorProvider.SetError(comboBoxDoctor, "Выберите врача");
                isValid = false;
            }

            // Проверка услуги
            if (comboBoxService.SelectedValue == null)
            {
                errorProvider.SetError(comboBoxService, "Выберите услугу");
                isValid = false;
            }

            // Проверка даты и времени
            DateTime selectedDateTime = dateTimePickerDate.Value.Date + dateTimePickerTime.Value.TimeOfDay;
            if (selectedDateTime <= DateTime.Now)
            {
                errorProvider.SetError(dateTimePickerDate, "Дата и время должны быть в будущем");
                isValid = false;
            }

            return isValid;
        }

        private void SaveAppointment()
        {
            try
            {
                // Формируем дату и время
                DateTime appointmentDateTime = dateTimePickerDate.Value.Date + dateTimePickerTime.Value.TimeOfDay;

                appointment.ID_branch = UserSession.BranchID;
                appointment.ID_employee = Convert.ToInt32(comboBoxDoctor.SelectedValue);
                appointment.ID_service = Convert.ToInt32(comboBoxService.SelectedValue);
                appointment.DateTime = appointmentDateTime;
                appointment.Status = comboBoxStatus.Text;
                appointment.ID_cabinet = comboBoxCabinet.SelectedValue != null ?
                    Convert.ToInt32(comboBoxCabinet.SelectedValue) : (int?)null;

                string query = @"
                    INSERT INTO Appointments (
                        ID_branch, ID_patient, ID_employee, ID_service, 
                        DateTime, Status, ID_cabinet
                    ) VALUES (
                        @BranchID, @PatientID, @EmployeeID, @ServiceID,
                        @DateTime, @Status, @CabinetID
                    )";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", appointment.ID_branch),
                    new SQLiteParameter("@PatientID", appointment.ID_patient),
                    new SQLiteParameter("@EmployeeID", appointment.ID_employee),
                    new SQLiteParameter("@ServiceID", appointment.ID_service),
                    new SQLiteParameter("@DateTime", appointment.DateTime.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SQLiteParameter("@Status", appointment.Status),
                    new SQLiteParameter("@CabinetID", appointment.ID_cabinet ?? (object)DBNull.Value)
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Запись на прием успешно создана!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем информацию о выбранной услуге
            if (comboBoxService.SelectedValue != null)
            {
                var selectedService = (comboBoxService.SelectedItem as DataRowView)?.Row;
                if (selectedService != null)
                {
                    int duration = Convert.ToInt32(selectedService["Duration_minutes"]);
                    decimal cost = Convert.ToDecimal(selectedService["Base_cost"]);
                    labelServiceInfo.Text = $"{duration} мин., {cost} руб.";
                }
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}