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
    public partial class PatientSearchForm : Form
    {
        public Patient SelectedPatient { get; private set; }
        private DatabaseHelper db;

        public PatientSearchForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            LoadPatients();
        }

        private void LoadPatients(string searchTerm = "")
        {
            try
            {
                string query = @"
            SELECT 
                ID_patient,
                LastName,
                FirstName,
                MiddleName,
                DateOfBirth,
                Phone,
                Email,
                LastName || ' ' || FirstName || ' ' || MiddleName as FullName
            FROM Patients 
            WHERE ID_branch = @BranchID";

                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (LastName LIKE @Search OR FirstName LIKE @Search OR Phone LIKE @Search)";
                    parameters = new SQLiteParameter[]
                    {
                new SQLiteParameter("@BranchID", UserSession.BranchID),
                new SQLiteParameter("@Search", $"%{searchTerm}%")
                    };
                }

                query += " ORDER BY LastName, FirstName";

                var dataTable = db.ExecuteQuery(query, parameters);

                // Настраиваем DataGridView
                dataGridViewPatients.AutoGenerateColumns = false;
                dataGridViewPatients.Columns.Clear();

                // Колонка ФИО
                dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "FullName",
                    DataPropertyName = "FullName",
                    HeaderText = "ФИО",
                    Width = 250,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                // Колонка Телефон
                dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "Phone",
                    DataPropertyName = "Phone",
                    HeaderText = "Телефон",
                    Width = 150
                });

                // Колонка Дата рождения
                dataGridViewPatients.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "DateOfBirth",
                    DataPropertyName = "DateOfBirth",
                    HeaderText = "Дата рождения",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        Format = "dd.MM.yyyy"
                    }
                });

                // Устанавливаем источник данных
                dataGridViewPatients.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пациентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(textBoxSearch.Text.Trim());
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                var row = dataGridViewPatients.SelectedRows[0];
                var dataRow = (row.DataBoundItem as DataRowView)?.Row;

                if (dataRow != null)
                {
                    SelectedPatient = new Patient
                    {
                        ID_patient = Convert.ToInt32(dataRow["ID_patient"]),
                        LastName = dataRow["LastName"].ToString(),
                        FirstName = dataRow["FirstName"].ToString(),
                        MiddleName = dataRow["MiddleName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(dataRow["DateOfBirth"]),
                        Phone = dataRow["Phone"].ToString()
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите пациента", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridViewPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
