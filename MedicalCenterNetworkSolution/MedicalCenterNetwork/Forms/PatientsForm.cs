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
    public partial class PatientsForm : Form
    {
        private DatabaseHelper db;
        private BindingList<Patient> patients;
        private string currentSortColumn = "LastName";
        private SortOrder currentSortOrder = SortOrder.Ascending;

        public PatientsForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            patients = new BindingList<Patient>();
            dataGridViewPatients.DataSource = patients;
            ConfigureDataGridView();
            LoadPatients();
        }

        private string GetCurrentDatabaseKey()
        {
            switch (UserSession.BranchID)
            {
                case 1:
                    return "Main";
                case 2:
                    return "North";
                case 3:
                    return "South";
                case 4:
                    return "West";
                default:
                    return "Main";
            }
        }

        private void ConfigureDataGridView()
        {
            // Настраиваем внешний вид DataGridView
            dataGridViewPatients.AutoGenerateColumns = false;
            dataGridViewPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPatients.MultiSelect = false;
            dataGridViewPatients.ReadOnly = true;
            dataGridViewPatients.AllowUserToResizeRows = false;
            dataGridViewPatients.RowTemplate.Height = 35;

            // Добавляем колонки
            dataGridViewPatients.Columns.Clear();

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ID_patient",
                DataPropertyName = "ID_patient",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "ФИО",
                Width = 250,
                FillWeight = 30
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DateOfBirth",
                DataPropertyName = "DateOfBirth",
                HeaderText = "Дата рождения",
                Width = 120,
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd.MM.yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Age",
                DataPropertyName = "Age",
                HeaderText = "Возраст",
                Width = 80,
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Gender",
                DataPropertyName = "Gender",
                HeaderText = "Пол",
                Width = 60,
                FillWeight = 8,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Phone",
                DataPropertyName = "Phone",
                HeaderText = "Телефон",
                Width = 150,
                FillWeight = 20
            });

            dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "RegistrationDate",
                DataPropertyName = "RegistrationDate",
                HeaderText = "Дата регистрации",
                Width = 150,
                FillWeight = 17,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd.MM.yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            // Включаем сортировку для всех колонок
            foreach (DataGridViewColumn column in dataGridViewPatients.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void LoadPatients(string searchTerm = "")
        {
            try
            {
                var currentDb = DatabaseManager.GetCurrentBranchDatabase();

                string query = @"
            SELECT 
                p.ID_patient,
                p.LastName,
                p.FirstName,
                p.MiddleName,
                p.DateOfBirth,
                p.Gender,
                p.Phone,
                p.Email,
                p.PassportSeriesNumber,
                p.Address,
                p.RegistrationDate,
                (strftime('%Y', 'now') - strftime('%Y', p.DateOfBirth)) - 
                (strftime('%m-%d', 'now') < strftime('%m-%d', p.DateOfBirth)) as Age
            FROM Patients p
            WHERE p.ID_branch = @BranchID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (p.LastName LIKE @Search OR p.FirstName LIKE @Search OR p.Phone LIKE @Search)";
                    parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@BranchID", UserSession.BranchID),
                new SQLiteParameter("@Search", $"%{searchTerm}%")
                    };
                }

                query += $" ORDER BY {GetSortExpression()}";

                var dataTable = currentDb.ExecuteQuery(query, parameters);

                // Очищаем текущий список и добавляем новые данные
                patients.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    patients.Add(new Patient
                    {
                        ID_patient = Convert.ToInt32(row["ID_patient"]),
                        LastName = row["LastName"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        Gender = row["Gender"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),
                        PassportSeriesNumber = row["PassportSeriesNumber"].ToString(),
                        Address = row["Address"].ToString(),
                        RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                    });
                }

                UpdateSortIcons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пациентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSortExpression()
        {
            string sortExpression = currentSortColumn;

            switch (currentSortColumn)
            {
                case "FullName":
                    sortExpression = "LastName, FirstName, MiddleName";
                    break;
                case "Age":
                    sortExpression = "DateOfBirth";
                    break;
            }

            if (currentSortOrder == SortOrder.Descending)
            {
                sortExpression += " DESC";
            }

            return sortExpression;
        }

        private void UpdateSortIcons()
        {
            foreach (DataGridViewColumn column in dataGridViewPatients.Columns)
            {
                if (column.Name == currentSortColumn)
                {
                    column.HeaderCell.SortGlyphDirection = currentSortOrder;
                }
                else
                {
                    column.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(textBoxSearch.Text.Trim());
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            LoadPatients();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientForm();
            if (patientForm.ShowDialog() == DialogResult.OK)
            {
                LoadPatients(); // Обновляем список после добавления
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPatient = dataGridViewPatients.SelectedRows[0].DataBoundItem as Patient;
            if (selectedPatient != null)
            {
                // Загружаем полные данные пациента перед редактированием
                string query = @"
            SELECT 
                LastName, FirstName, MiddleName, DateOfBirth, Gender,
                Phone, Email, PassportSeriesNumber, Address, RegistrationDate
            FROM Patients 
            WHERE ID_patient = @PatientID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@PatientID", selectedPatient.ID_patient)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    selectedPatient.LastName = row["LastName"].ToString();
                    selectedPatient.FirstName = row["FirstName"].ToString();
                    selectedPatient.MiddleName = row["MiddleName"].ToString();
                    selectedPatient.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    selectedPatient.Gender = row["Gender"].ToString();
                    selectedPatient.Phone = row["Phone"].ToString();
                    selectedPatient.Email = row["Email"].ToString();
                    selectedPatient.PassportSeriesNumber = row["PassportSeriesNumber"].ToString();
                    selectedPatient.Address = row["Address"].ToString();
                }

                var patientForm = new PatientForm(selectedPatient);
                if (patientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPatients(); // Обновляем список после редактирования
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPatient = dataGridViewPatients.SelectedRows[0].DataBoundItem as Patient;
            if (selectedPatient != null)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить пациента:\n{selectedPatient.FullName}?\n\nВнимание: Это действие нельзя отменить!",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    DeletePatient(selectedPatient.ID_patient);
                }
            }
        }

        private void DeletePatient(int patientId)
        {
            try
            {
                // Проверяем, есть ли связанные записи
                string checkQuery = @"
                    SELECT COUNT(*) FROM Appointments WHERE ID_patient = @PatientID
                    UNION ALL
                    SELECT COUNT(*) FROM MedicalRecords WHERE ID_patient = @PatientID
                    UNION ALL
                    SELECT COUNT(*) FROM CompletedProcedures WHERE ID_patient = @PatientID";

                var checkParams = new SQLiteParameter[] { new SQLiteParameter("@PatientID", patientId) };
                var checkResult = db.ExecuteQuery(checkQuery, checkParams);

                int appointmentsCount = Convert.ToInt32(checkResult.Rows[0][0]);
                int recordsCount = Convert.ToInt32(checkResult.Rows[1][0]);
                int proceduresCount = Convert.ToInt32(checkResult.Rows[2][0]);

                if (appointmentsCount > 0 || recordsCount > 0 || proceduresCount > 0)
                {
                    MessageBox.Show(
                        $"Невозможно удалить пациента!\n\n" +
                        $"У пациента есть:\n" +
                        $"• Записей на прием: {appointmentsCount}\n" +
                        $"• Медицинских записей: {recordsCount}\n" +
                        $"• Выполненных процедур: {proceduresCount}\n\n" +
                        $"Сначала удалите все связанные записи.",
                        "Ошибка удаления",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Удаляем пациента
                string deleteQuery = "DELETE FROM Patients WHERE ID_patient = @PatientID";
                var deleteParams = new SQLiteParameter[] { new SQLiteParameter("@PatientID", patientId) };

                int rowsAffected = db.ExecuteNonQuery(deleteQuery, deleteParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Пациент успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatients(); // Обновляем список
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пациента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void dataGridViewPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void dataGridViewPatients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewPatients.Columns[e.ColumnIndex].Name;

            if (columnName == currentSortColumn)
            {
                // Меняем направление сортировки для той же колонки
                currentSortOrder = currentSortOrder == SortOrder.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // Новая колонка для сортировки
                currentSortColumn = columnName;
                currentSortOrder = SortOrder.Ascending;
            }

            LoadPatients(textBoxSearch.Text.Trim());
        }

        private void dataGridViewPatients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDelete_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
