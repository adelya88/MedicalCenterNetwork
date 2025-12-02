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

namespace MedicalCenterNetwork.Forms
{
    public partial class PatientForm : Form
    {
        private Patient patient;
        private DatabaseHelper db;
        private bool isEditMode;

        public PatientForm(Patient existingPatient = null)
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            patient = existingPatient ?? new Patient();
            isEditMode = existingPatient != null;

            InitializeForm();

            // ★★★ ДОБАВЛЯЕМ ПОДСКАЗКИ ТОЛЬКО ДЛЯ НОВЫХ ПАЦИЕНТОВ ★★★
            if (!isEditMode)
            {
                textBoxPassport.Text = "XXXX XXXXXX";
                textBoxAddress.Text = "г. Москва, ул. Примерная, д. 1, кв. 1";

                // Устанавливаем серый цвет для подсказок
                textBoxPassport.ForeColor = System.Drawing.Color.Gray;
                textBoxAddress.ForeColor = System.Drawing.Color.Gray;
            }

            LoadPatientData();
        }

        private void InitializeForm()
        {
            this.Text = isEditMode ? "Редактирование пациента" : "Добавление пациента";
            buttonSave.Text = isEditMode ? "Сохранить" : "Добавить";

            // Устанавливаем текущую дату регистрации для нового пациента
            if (!isEditMode)
            {
                patient.RegistrationDate = DateTime.Now;
            }
        }

        private void LoadPatientData()
        {
            if (isEditMode)
            {
                // Загружаем полные данные пациента из базы
                string query = @"
            SELECT 
                LastName, FirstName, MiddleName, DateOfBirth, Gender,
                Phone, Email, PassportSeriesNumber, Address, RegistrationDate
            FROM Patients 
            WHERE ID_patient = @PatientID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@PatientID", patient.ID_patient)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];

                    textBoxLastName.Text = row["LastName"].ToString();
                    textBoxFirstName.Text = row["FirstName"].ToString();
                    textBoxMiddleName.Text = row["MiddleName"].ToString();
                    dateTimePickerBirthDate.Value = Convert.ToDateTime(row["DateOfBirth"]);
                    comboBoxGender.Text = row["Gender"].ToString();

                    // Телефон уже должен быть в правильном формате в базе
                    textBoxPhone.Text = row["Phone"].ToString();

                    textBoxEmail.Text = row["Email"].ToString();

                    // ★★★ ВСТАВЛЯЕМ ЗДЕСЬ - Форматируем паспортные данные при редактировании ★★★
                    string passportFromDb = row["PassportSeriesNumber"].ToString();
                    if (!string.IsNullOrEmpty(passportFromDb) && passportFromDb.Length == 10)
                    {
                        textBoxPassport.Text = $"{passportFromDb.Substring(0, 4)} {passportFromDb.Substring(4, 6)}";
                    }
                    else
                    {
                        textBoxPassport.Text = passportFromDb;
                    }

                    // ★★★ ВСТАВЛЯЕМ ЗДЕСЬ - Адрес уже должен быть в правильном формате ★★★
                    textBoxAddress.Text = row["Address"].ToString();

                    labelRegistrationDate.Text = Convert.ToDateTime(row["RegistrationDate"]).ToString("dd.MM.yyyy HH:mm");

                    // Обновляем объект пациента
                    patient.LastName = textBoxLastName.Text;
                    patient.FirstName = textBoxFirstName.Text;
                    patient.MiddleName = textBoxMiddleName.Text;
                    patient.DateOfBirth = dateTimePickerBirthDate.Value;
                    patient.Gender = comboBoxGender.Text;
                    patient.Phone = textBoxPhone.Text;
                    patient.Email = textBoxEmail.Text;
                    patient.PassportSeriesNumber = passportFromDb; // Сохраняем оригинальный формат (без пробелов)
                    patient.Address = textBoxAddress.Text;
                }
            }
            else
            {
                labelRegistrationDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }

            CalculateAge();
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Фамилия - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                errorProvider.SetError(textBoxLastName, "Введите фамилию");
                isValid = false;
            }

            // Имя - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                errorProvider.SetError(textBoxFirstName, "Введите имя");
                isValid = false;
            }

            // Отчество - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxMiddleName.Text))
            {
                errorProvider.SetError(textBoxMiddleName, "Введите отчество");
                isValid = false;
            }

            // Дата рождения - проверка
            if (dateTimePickerBirthDate.Value > DateTime.Now.AddYears(-1) ||
                dateTimePickerBirthDate.Value < DateTime.Now.AddYears(-120))
            {
                errorProvider.SetError(dateTimePickerBirthDate, "Некорректная дата рождения");
                isValid = false;
            }

            // Пол - обязательное поле
            if (string.IsNullOrWhiteSpace(comboBoxGender.Text))
            {
                errorProvider.SetError(comboBoxGender, "Выберите пол");
                isValid = false;
            }

            // Телефон - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                errorProvider.SetError(textBoxPhone, "Введите телефон");
                isValid = false;
            }
            else
            {
                // Проверяем формат телефона
                string phone = textBoxPhone.Text;
                string digitsOnly = new string(phone.Where(char.IsDigit).ToArray());

                if (digitsOnly.Length != 11 || !digitsOnly.StartsWith("7"))
                {
                    errorProvider.SetError(textBoxPhone, "Телефон должен содержать 11 цифр в формате +7 (XXX) XXX-XX-XX");
                    isValid = false;
                }
            }

            // Email - обязательное поле с проверкой формата
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                errorProvider.SetError(textBoxEmail, "Введите email");
                isValid = false;
            }
            else if (!IsValidEmail(textBoxEmail.Text))
            {
                errorProvider.SetError(textBoxEmail, "Введите корректный email");
                isValid = false;
            }

            // Паспортные данные - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxPassport.Text))
            {
                errorProvider.SetError(textBoxPassport, "Введите серию и номер паспорта");
                isValid = false;
            }
            else
            {
                // Проверяем формат паспорта (XXXX XXXXXX)
                string passport = textBoxPassport.Text;
                string digitsOnly = new string(passport.Where(char.IsDigit).ToArray());

                if (digitsOnly.Length != 10)
                {
                    errorProvider.SetError(textBoxPassport, "Паспорт должен содержать 10 цифр в формате XXXX XXXXXX");
                    isValid = false;
                }
            }

            // Адрес - обязательное поле
            if (string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                errorProvider.SetError(textBoxAddress, "Введите адрес проживания");
                isValid = false;
            }

            return isValid;
        }

        // Метод для проверки формата email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void FormatPhoneNumber()
        {
            string phone = textBoxPhone.Text;

            // Удаляем все нецифровые символы
            string digitsOnly = new string(phone.Where(char.IsDigit).ToArray());

            // Если номер начинается с 7 или 8, оставляем только 11 цифр
            if (digitsOnly.Length >= 11 && (digitsOnly.StartsWith("7") || digitsOnly.StartsWith("8")))
            {
                digitsOnly = "7" + digitsOnly.Substring(digitsOnly.Length - 10);
            }
            // Если номер без кода страны, добавляем 7
            else if (digitsOnly.Length == 10)
            {
                digitsOnly = "7" + digitsOnly;
            }

            // Форматируем в нужный формат
            if (digitsOnly.Length == 11 && digitsOnly.StartsWith("7"))
            {
                string formatted = $"+7 ({digitsOnly.Substring(1, 3)}) {digitsOnly.Substring(4, 3)}-{digitsOnly.Substring(7, 2)}-{digitsOnly.Substring(9, 2)}";
                textBoxPhone.Text = formatted;

                // Устанавливаем курсор в конец
                textBoxPhone.SelectionStart = textBoxPhone.Text.Length;
            }
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            // Форматируем только если пользователь закончил ввод
            if (textBoxPhone.Focused && textBoxPhone.Text.Length >= 16)
            {
                FormatPhoneNumber();
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            // Форматируем при потере фокуса
            FormatPhoneNumber();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, +, -, пробел, скобки и Backspace
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' &&
                e.KeyChar != '-' &&
                e.KeyChar != ' ' &&
                e.KeyChar != '(' &&
                e.KeyChar != ')' &&
                e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            // Автоматически добавляем +7 если поле пустое и пользователь начинает ввод с цифры
            if (textBoxPhone.Text.Length == 0 && char.IsDigit(e.KeyChar))
            {
                textBoxPhone.Text = "+7 (";
                textBoxPhone.SelectionStart = textBoxPhone.Text.Length;
            }
        }

        private void SavePatient()
        {
            try
            {
                patient.LastName = textBoxLastName.Text.Trim();
                patient.FirstName = textBoxFirstName.Text.Trim();
                patient.MiddleName = textBoxMiddleName.Text.Trim();
                patient.DateOfBirth = dateTimePickerBirthDate.Value;
                patient.Gender = comboBoxGender.Text;
                patient.Phone = NormalizePhoneNumber(textBoxPhone.Text.Trim());
                patient.Email = textBoxEmail.Text.Trim();
                patient.PassportSeriesNumber = new string(textBoxPassport.Text.Where(c => !char.IsWhiteSpace(c)).ToArray());
                patient.Address = textBoxAddress.Text.Trim();
                patient.ID_branch = UserSession.BranchID;

                string query;
                SQLiteParameter[] parameters;

                if (isEditMode)
                {
                    query = @"
                        UPDATE Patients 
                        SET LastName = @LastName, 
                            FirstName = @FirstName, 
                            MiddleName = @MiddleName,
                            DateOfBirth = @DateOfBirth,
                            Gender = @Gender,
                            Phone = @Phone,
                            Email = @Email,
                            PassportSeriesNumber = @Passport,
                            Address = @Address
                        WHERE ID_patient = @ID_patient";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@LastName", patient.LastName),
                        new SQLiteParameter("@FirstName", patient.FirstName),
                        new SQLiteParameter("@MiddleName", patient.MiddleName),
                        new SQLiteParameter("@DateOfBirth", patient.DateOfBirth.ToString("yyyy-MM-dd")),
                        new SQLiteParameter("@Gender", patient.Gender),
                        new SQLiteParameter("@Phone", patient.Phone),
                        new SQLiteParameter("@Email", patient.Email ?? (object)DBNull.Value),
                        new SQLiteParameter("@Passport", patient.PassportSeriesNumber ?? (object)DBNull.Value),
                        new SQLiteParameter("@Address", patient.Address ?? (object)DBNull.Value),
                        new SQLiteParameter("@ID_patient", patient.ID_patient)
                    };
                }
                else
                {
                    query = @"
                        INSERT INTO Patients (
                            ID_branch, LastName, FirstName, MiddleName, 
                            DateOfBirth, Gender, Phone, Email, 
                            PassportSeriesNumber, Address, RegistrationDate
                        ) VALUES (
                            @BranchID, @LastName, @FirstName, @MiddleName,
                            @DateOfBirth, @Gender, @Phone, @Email,
                            @Passport, @Address, @RegistrationDate
                        )";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@BranchID", patient.ID_branch),
                        new SQLiteParameter("@LastName", patient.LastName),
                        new SQLiteParameter("@FirstName", patient.FirstName),
                        new SQLiteParameter("@MiddleName", patient.MiddleName),
                        new SQLiteParameter("@DateOfBirth", patient.DateOfBirth.ToString("yyyy-MM-dd")),
                        new SQLiteParameter("@Gender", patient.Gender),
                        new SQLiteParameter("@Phone", patient.Phone),
                        new SQLiteParameter("@Email", patient.Email ?? (object)DBNull.Value),
                        new SQLiteParameter("@Passport", patient.PassportSeriesNumber ?? (object)DBNull.Value),
                        new SQLiteParameter("@Address", patient.Address ?? (object)DBNull.Value),
                        new SQLiteParameter("@RegistrationDate", patient.RegistrationDate)
                    };
                }

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show(isEditMode ? "Данные пациента успешно обновлены!" : "Пациент успешно добавлен!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении пациента: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string NormalizePhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return phone;

            // Удаляем все нецифровые символы
            string digitsOnly = new string(phone.Where(char.IsDigit).ToArray());

            // Приводим к формату +7 (XXX) XXX-XX-XX
            if (digitsOnly.Length == 11 && digitsOnly.StartsWith("7"))
            {
                return $"+7 ({digitsOnly.Substring(1, 3)}) {digitsOnly.Substring(4, 3)}-{digitsOnly.Substring(7, 2)}-{digitsOnly.Substring(9, 2)}";
            }
            else if (digitsOnly.Length == 10)
            {
                return $"+7 ({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3, 3)}-{digitsOnly.Substring(6, 2)}-{digitsOnly.Substring(8, 2)}";
            }

            return phone; // Возвращаем как есть, если формат не распознан
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SavePatient();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormatPassportNumber()
        {
            string passport = textBoxPassport.Text;

            // Удаляем все нецифровые символы
            string digitsOnly = new string(passport.Where(char.IsDigit).ToArray());

            // Форматируем в ХХХХ ХХХХХХ
            if (digitsOnly.Length == 10)
            {
                string formatted = $"{digitsOnly.Substring(0, 4)} {digitsOnly.Substring(4, 6)}";
                textBoxPassport.Text = formatted;
                textBoxPassport.SelectionStart = textBoxPassport.Text.Length;
            }
            else if (digitsOnly.Length > 10)
            {
                // Если цифр больше 10, берем первые 10
                string formatted = $"{digitsOnly.Substring(0, 4)} {digitsOnly.Substring(4, 6)}";
                textBoxPassport.Text = formatted;
                textBoxPassport.SelectionStart = textBoxPassport.Text.Length;
            }
        }

        private void textBoxPassport_TextChanged(object sender, EventArgs e)
        {
            // Форматируем только если пользователь закончил ввод
            if (textBoxPassport.Focused && textBoxPassport.Text.Length >= 11)
            {
                FormatPassportNumber();
            }
        }


        private void textBoxPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            // Автоматически добавляем пробел после 4 цифр
            if (char.IsDigit(e.KeyChar) && textBoxPassport.Text.Length == 4 && !textBoxPassport.Text.Contains(" "))
            {
                textBoxPassport.Text += " ";
                textBoxPassport.SelectionStart = textBoxPassport.Text.Length;
            }
        }

        private void textBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем все символы, но форматируем при потере фокуса
        }

        private void FormatAddress()
        {
            string address = textBoxAddress.Text.Trim();

            if (string.IsNullOrEmpty(address))
                return;

            // Проверяем, не отформатирован ли уже адрес
            if (address.StartsWith("г.") && address.Contains("ул.") && address.Contains("д."))
            {
                return; // Уже отформатирован
            }

            // Простое форматирование - добавляем префиксы если их нет
            if (!address.StartsWith("г.") && !address.StartsWith("ул.") && !address.StartsWith("д."))
            {
                // Попробуем разбить по запятым
                string[] parts = address.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 4)
                {
                    string formatted = $"г. {parts[0].Trim()}, ул. {parts[1].Trim()}, д. {parts[2].Trim()}, кв. {parts[3].Trim()}";
                    textBoxAddress.Text = formatted;
                    textBoxAddress.SelectionStart = textBoxAddress.Text.Length;
                }
                else if (parts.Length >= 3)
                {
                    string formatted = $"г. {parts[0].Trim()}, ул. {parts[1].Trim()}, д. {parts[2].Trim()}";
                    textBoxAddress.Text = formatted;
                    textBoxAddress.SelectionStart = textBoxAddress.Text.Length;
                }
                else if (parts.Length >= 2)
                {
                    string formatted = $"г. {parts[0].Trim()}, ул. {parts[1].Trim()}";
                    textBoxAddress.Text = formatted;
                    textBoxAddress.SelectionStart = textBoxAddress.Text.Length;
                }
                else if (parts.Length >= 1)
                {
                    string formatted = $"г. {parts[0].Trim()}";
                    textBoxAddress.Text = formatted;
                    textBoxAddress.SelectionStart = textBoxAddress.Text.Length;
                }
            }
        }

        private void CalculateAge()
        {
            DateTime birthDate = dateTimePickerBirthDate.Value;
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;

            labelAge.Text = $"{age} лет";
        }

        private void dateTimePickerBirthDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }

        // ★★★ ОБРАБОТЧИКИ ДЛЯ ПОДСКАЗОК ★★★
        private void textBoxPassport_Enter(object sender, EventArgs e)
        {
            if (textBoxPassport.Text == "XXXX XXXXXX" && textBoxPassport.ForeColor == System.Drawing.Color.Gray)
            {
                textBoxPassport.Text = "";
                textBoxPassport.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxAddress_Enter(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "г. Москва, ул. Примерная, д. 1, кв. 1" && textBoxAddress.ForeColor == System.Drawing.Color.Gray)
            {
                textBoxAddress.Text = "";
                textBoxAddress.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxPassport_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassport.Text))
            {
                textBoxPassport.Text = "XXXX XXXXXX";
                textBoxPassport.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                textBoxAddress.Text = "г. Москва, ул. Примерная, д. 1, кв. 1";
                textBoxAddress.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
