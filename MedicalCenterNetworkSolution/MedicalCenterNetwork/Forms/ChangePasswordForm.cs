using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private string targetLogin; // Логин пользователя, для которого меняется пароль
        private string targetFullName; // ФИО пользователя
        private bool isSelfChange; // true - смена своего пароля, false - администратор меняет чужой пароль
        private DatabaseHelper db;

        public ChangePasswordForm(string targetLogin, string targetFullName, bool isSelfChange = false)
        {
            InitializeComponent();
            this.targetLogin = targetLogin;
            this.targetFullName = targetFullName;
            this.isSelfChange = isSelfChange;
            db = DatabaseManager.GetCurrentBranchDatabase();
            InitializeForm();

            // Добавляем обработчики для сброса ошибок при вводе
            AddValidationEventHandlers();
        }

        private void AddValidationEventHandlers()
        {
            textBoxOldPassword.TextChanged += (s, e) => ClearFieldError(textBoxOldPassword);
            textBoxNewPassword.TextChanged += (s, e) => ClearFieldError(textBoxNewPassword);
            textBoxConfirmPassword.TextChanged += (s, e) => ClearFieldError(textBoxConfirmPassword);
        }

        private void ClearFieldError(Control control)
        {
            errorProvider.SetError(control, "");
            ResetFieldColors();

            // Для textBoxOldPassword - особый случай, т.к. он может быть невидимым
            if (control == textBoxOldPassword && !isSelfChange)
                return;

            control.BackColor = SystemColors.Window;
        }

        private void InitializeForm()
        {
            if (isSelfChange)
            {
                this.Text = $"Смена пароля - {targetFullName}";
                labelEmployeeInfo.Text = $"Вы меняете свой пароль: {targetFullName}";

                // Для смены своего пароля нужен старый пароль
                labelOldPassword.Visible = true;
                textBoxOldPassword.Visible = true;
            }
            else
            {
                this.Text = $"Смена пароля сотрудника - {targetFullName}";
                labelEmployeeInfo.Text = $"Вы меняете пароль сотрудника: {targetFullName}";

                // Администратору не нужен старый пароль
                labelOldPassword.Visible = false;
                textBoxOldPassword.Visible = false;
            }

            // Добавляем подсказки
            AddToolTips();
        }

        private void AddToolTips()
        {
            ToolTip toolTip = new ToolTip();

            // Настройки ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            // Подсказки для полей
            toolTip.SetToolTip(textBoxNewPassword, "Пароль должен содержать не менее 5 символов");
            toolTip.SetToolTip(textBoxConfirmPassword, "Повторите новый пароль для подтверждения");

            if (isSelfChange)
            {
                toolTip.SetToolTip(textBoxOldPassword, "Введите ваш текущий пароль");
            }

            // Подсказка для кнопки генерации
            toolTip.SetToolTip(buttonGenerate, "Сгенерировать надежный пароль");
        }

        private void HighlightErrorFields()
        {
            // Сбрасываем цвета всех полей
            ResetFieldColors();

            // Подсвечиваем поля с ошибками
            if (errorProvider.GetError(textBoxOldPassword) != "")
            {
                textBoxOldPassword.BorderStyle = BorderStyle.Fixed3D;
                textBoxOldPassword.BackColor = Color.LightPink;
            }

            if (errorProvider.GetError(textBoxNewPassword) != "")
            {
                textBoxNewPassword.BorderStyle = BorderStyle.Fixed3D;
                textBoxNewPassword.BackColor = Color.LightPink;
            }

            if (errorProvider.GetError(textBoxConfirmPassword) != "")
            {
                textBoxConfirmPassword.BorderStyle = BorderStyle.Fixed3D;
                textBoxConfirmPassword.BackColor = Color.LightPink;
            }
        }

        private void ResetFieldColors()
        {
            textBoxOldPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxOldPassword.BackColor = SystemColors.Window;

            textBoxNewPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxNewPassword.BackColor = SystemColors.Window;

            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxConfirmPassword.BackColor = SystemColors.Window;
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            ResetFieldColors();

            bool isValid = true;
            Control firstErrorControl = null;

            // Проверка старого пароля (только для смены своего пароля)
            if (isSelfChange && string.IsNullOrWhiteSpace(textBoxOldPassword.Text))
            {
                errorProvider.SetError(textBoxOldPassword, "Введите текущий пароль");
                if (firstErrorControl == null) firstErrorControl = textBoxOldPassword;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                errorProvider.SetError(textBoxNewPassword, "Введите новый пароль");
                if (firstErrorControl == null) firstErrorControl = textBoxNewPassword;
                isValid = false;
            }
            else if (textBoxNewPassword.Text.Length < 5)
            {
                errorProvider.SetError(textBoxNewPassword, "Пароль должен быть не менее 5 символов");
                if (firstErrorControl == null) firstErrorControl = textBoxNewPassword;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text))
            {
                errorProvider.SetError(textBoxConfirmPassword, "Подтвердите пароль");
                if (firstErrorControl == null) firstErrorControl = textBoxConfirmPassword;
                isValid = false;
            }
            else if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                errorProvider.SetError(textBoxConfirmPassword, "Пароли не совпадают");
                if (firstErrorControl == null) firstErrorControl = textBoxConfirmPassword;
                isValid = false;
            }

            // Проверка, что новый пароль не совпадает со старым (только для смены своего пароля)
            if (isSelfChange && !string.IsNullOrWhiteSpace(textBoxOldPassword.Text) &&
                !string.IsNullOrWhiteSpace(textBoxNewPassword.Text) &&
                textBoxNewPassword.Text == textBoxOldPassword.Text)
            {
                errorProvider.SetError(textBoxNewPassword, "Новый пароль должен отличаться от старого");
                if (firstErrorControl == null) firstErrorControl = textBoxNewPassword;
                isValid = false;
            }

            // Подсвечиваем поля с ошибками
            if (!isValid)
            {
                HighlightErrorFields();

                // Устанавливаем фокус на первое поле с ошибкой
                if (firstErrorControl != null)
                {
                    firstErrorControl.Focus();
                    if (firstErrorControl is TextBox textBox)
                    {
                        textBox.SelectAll();
                    }
                }
            }

            return isValid;
        }

        private bool VerifyOldPassword()
        {
            try
            {
                string query = "SELECT Password FROM Employees WHERE Login = @Login";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@Login", targetLogin)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    string currentPassword = result.Rows[0]["Password"]?.ToString() ?? string.Empty;
                    return currentPassword == textBoxOldPassword.Text;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке пароля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                // Для смены своего пароля проверяем старый пароль
                if (isSelfChange && !VerifyOldPassword())
                {
                    MessageBox.Show("Неверный текущий пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOldPassword.Focus();
                    textBoxOldPassword.SelectAll();
                    return;
                }

                // Обновляем пароль в базе данных
                string query = "UPDATE Employees SET Password = @Password WHERE Login = @Login";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@Password", textBoxNewPassword.Text),
            new SQLiteParameter("@Login", targetLogin)
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Пароль успешно изменен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Записываем в лог
                    if (isSelfChange)
                    {
                        Logger.LogInfo($"Пользователь {targetLogin} изменил свой пароль");
                    }
                    else
                    {
                        Logger.LogInfo($"Администратор {UserSession.Login} изменил пароль пользователя {targetLogin}");
                    }

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Не удалось изменить пароль. Пользователь не найден.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных при изменении пароля: {sqlEx.Message}", "Ошибка базы данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(sqlEx, "Ошибка при изменении пароля");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex, "Ошибка при изменении пароля");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Генерация случайного пароля
            string generatedPassword = GenerateRandomPassword();
            textBoxNewPassword.Text = generatedPassword;
            textBoxConfirmPassword.Text = generatedPassword;
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(chars);
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOldPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
            textBoxNewPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
            textBoxConfirmPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

    }
}