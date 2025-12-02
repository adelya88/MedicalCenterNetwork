using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using MedicalCenterNetwork.Data;
using MedicalCenterNetwork.Models;

namespace MedicalCenterNetwork.Forms
{
    public partial class CabinetForm : Form
    {
        private Cabinet cabinet;
        private DatabaseHelper db;
        private bool isEditMode;

        public CabinetForm(Cabinet existingCabinet = null)
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            cabinet = existingCabinet ?? new Cabinet();
            isEditMode = existingCabinet != null;

            InitializeForm();
            LoadCabinetData();
        }

        private void InitializeForm()
        {
            this.Text = isEditMode ? "Редактирование кабинета" : "Добавление кабинета";
            buttonSave.Text = isEditMode ? "Сохранить" : "Добавить";

            // Автоматически устанавливаем текущий филиал
            cabinet.ID_branch = UserSession.BranchID;
            labelBranch.Text = $"Филиал: {GetBranchName(UserSession.BranchID)}";
        }

        private string GetBranchName(int branchId)
        {
            switch (branchId)
            {
                case 1: return "Главный филиал";
                case 2: return "Северный филиал";
                case 3: return "Южный филиал";
                case 4: return "Западный филиал";
                default: return $"Филиал {branchId}";
            }
        }

        private void LoadCabinetData()
        {
            if (isEditMode)
            {
                textBoxCabinetNumber.Text = cabinet.CabinetNumber;
                textBoxPurpose.Text = cabinet.Purpose;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxCabinetNumber.Text))
            {
                MessageBox.Show("Введите номер кабинета", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCabinetNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPurpose.Text))
            {
                MessageBox.Show("Введите назначение кабинета", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPurpose.Focus();
                return false;
            }

            // Проверяем уникальность номера кабинета в филиале
            if (!IsCabinetNumberUnique())
            {
                MessageBox.Show("Кабинет с таким номером уже существует в этом филиале", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCabinetNumber.Focus();
                textBoxCabinetNumber.SelectAll();
                return false;
            }

            return true;
        }

        private bool IsCabinetNumberUnique()
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM Cabinets 
                    WHERE ID_branch = @BranchID 
                    AND CabinetNumber = @CabinetNumber";

                if (isEditMode)
                {
                    query += " AND ID_cabinet != @CabinetID";
                }

                var parameters = new List<SQLiteParameter>
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID),
                    new SQLiteParameter("@CabinetNumber", textBoxCabinetNumber.Text.Trim())
                };

                if (isEditMode)
                {
                    parameters.Add(new SQLiteParameter("@CabinetID", cabinet.ID_cabinet));
                }

                var result = db.ExecuteScalar(query, parameters.ToArray());
                int count = Convert.ToInt32(result);

                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке уникальности номера кабинета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveCabinet()
        {
            try
            {
                cabinet.CabinetNumber = textBoxCabinetNumber.Text.Trim();
                cabinet.Purpose = textBoxPurpose.Text.Trim();

                string query;
                SQLiteParameter[] parameters;

                if (isEditMode)
                {
                    query = @"
                        UPDATE Cabinets 
                        SET CabinetNumber = @CabinetNumber, 
                            Purpose = @Purpose
                        WHERE ID_cabinet = @CabinetID";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@CabinetNumber", cabinet.CabinetNumber),
                        new SQLiteParameter("@Purpose", cabinet.Purpose),
                        new SQLiteParameter("@CabinetID", cabinet.ID_cabinet)
                    };
                }
                else
                {
                    query = @"
                        INSERT INTO Cabinets (ID_branch, CabinetNumber, Purpose)
                        VALUES (@BranchID, @CabinetNumber, @Purpose)";

                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@BranchID", UserSession.BranchID),
                        new SQLiteParameter("@CabinetNumber", cabinet.CabinetNumber),
                        new SQLiteParameter("@Purpose", cabinet.Purpose)
                    };
                }

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show(isEditMode ? "Кабинет успешно обновлен!" : "Кабинет успешно добавлен!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить кабинет", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении кабинета: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveCabinet();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonSave_Click(sender, e);
            }
        }
    }
}