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
    public partial class DoctorSearchForm : Form
    {
        public Employee SelectedDoctor { get; private set; }
        private DatabaseHelper db;

        public DoctorSearchForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            LoadDoctors();
        }

        private void LoadDoctors(string searchTerm = "")
        {
            try
            {
                // Получаем специализации из главной базы
                var specializations = DatabaseManager.GetSpecializations();

                string query = @"
            SELECT 
                ID_employee,
                LastName,
                FirstName,
                MiddleName,
                ID_specialization,
                LastName || ' ' || FirstName || ' ' || MiddleName as FullName
            FROM Employees 
            WHERE Position = 'Врач' 
            AND IsActive = 1 
            AND ID_branch = @BranchID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (LastName LIKE @Search OR FirstName LIKE @Search)";
                    parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@BranchID", UserSession.BranchID),
                new SQLiteParameter("@Search", $"%{searchTerm}%")
                    };
                }

                query += " ORDER BY LastName, FirstName";

                var dataTable = db.ExecuteQuery(query, parameters);

                // Создаем новую таблицу с нужными колонками
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("ID_employee", typeof(int));
                resultTable.Columns.Add("LastName", typeof(string));
                resultTable.Columns.Add("FirstName", typeof(string));
                resultTable.Columns.Add("MiddleName", typeof(string));
                resultTable.Columns.Add("ID_specialization", typeof(int));
                resultTable.Columns.Add("FullName", typeof(string));
                resultTable.Columns.Add("SpecializationName", typeof(string)); // ДОБАВЛЯЕМ КОЛОНКУ

                // Заполняем новую таблицу данными
                foreach (DataRow row in dataTable.Rows)
                {
                    string specializationName = "Не указана";

                    if (row["ID_specialization"] != DBNull.Value)
                    {
                        int specializationId = Convert.ToInt32(row["ID_specialization"]);
                        var specialization = specializations.AsEnumerable()
                            .FirstOrDefault(s => Convert.ToInt32(s["ID_specialization"]) == specializationId);

                        if (specialization != null)
                        {
                            specializationName = specialization["Name"].ToString();
                        }
                    }

                    resultTable.Rows.Add(
                        row["ID_employee"],
                        row["LastName"],
                        row["FirstName"],
                        row["MiddleName"],
                        row["ID_specialization"],
                        row["FullName"],
                        specializationName
                    );
                }

                // Настраиваем DataGridView
                dataGridViewDoctors.AutoGenerateColumns = false;
                dataGridViewDoctors.Columns.Clear();

                // Колонка ФИО
                dataGridViewDoctors.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "FullName",
                    DataPropertyName = "FullName",
                    HeaderText = "ФИО врача",
                    Width = 250,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                // Колонка Специализация
                dataGridViewDoctors.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "SpecializationName",
                    DataPropertyName = "SpecializationName",
                    HeaderText = "Специализация",
                    Width = 200
                });

                // Устанавливаем источник данных
                dataGridViewDoctors.DataSource = resultTable;

                // Показываем количество найденных врачей
                if (labelResults != null)
                {
                    labelResults.Text = $"Найдено врачей: {resultTable.Rows.Count}";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке врачей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadDoctors(textBoxSearch.Text.Trim());
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewDoctors.SelectedRows.Count > 0)
            {
                var row = dataGridViewDoctors.SelectedRows[0];
                var dataRow = (row.DataBoundItem as DataRowView)?.Row;

                if (dataRow != null)
                {
                    SelectedDoctor = new Employee
                    {
                        ID_employee = Convert.ToInt32(dataRow["ID_employee"]),
                        LastName = dataRow["LastName"].ToString(),
                        FirstName = dataRow["FirstName"].ToString(),
                        MiddleName = dataRow["MiddleName"].ToString(),
                        SpecializationName = dataRow["SpecializationName"].ToString()
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите врача", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridViewDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonSelect_Click(sender, e);
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
    }
}
