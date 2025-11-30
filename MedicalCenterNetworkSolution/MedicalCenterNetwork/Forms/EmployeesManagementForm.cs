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
    public partial class EmployeesManagementForm : Form
    {
        private DatabaseHelper db;
        private BindingList<Employee> employees;
        private string currentSortColumn = "LastName";
        private SortOrder currentSortOrder = SortOrder.Ascending;

        public EmployeesManagementForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            employees = new BindingList<Employee>();
            dataGridViewEmployees.DataSource = employees;
            ConfigureDataGridView();
            LoadEmployees();
        }

        private void ConfigureDataGridView()
        {
            // Настраиваем внешний вид DataGridView
            dataGridViewEmployees.AutoGenerateColumns = false;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.ReadOnly = true;
            dataGridViewEmployees.AllowUserToResizeRows = false;
            dataGridViewEmployees.RowTemplate.Height = 35;

            // Добавляем колонки
            dataGridViewEmployees.Columns.Clear();

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ID_employee",
                DataPropertyName = "ID_employee",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "ФИО сотрудника",
                Width = 250,
                FillWeight = 30
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Position",
                DataPropertyName = "Position",
                HeaderText = "Должность",
                Width = 150,
                FillWeight = 20
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SpecializationName",
                DataPropertyName = "SpecializationName",
                HeaderText = "Специализация",
                Width = 180,
                FillWeight = 20
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BranchName",
                DataPropertyName = "BranchName",
                HeaderText = "Филиал",
                Width = 150,
                FillWeight = 15
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Login",
                DataPropertyName = "Login",
                HeaderText = "Логин",
                Width = 120,
                FillWeight = 15
            });

            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "Статус",
                Width = 100,
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Включаем сортировку для всех колонок
            foreach (DataGridViewColumn column in dataGridViewEmployees.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private bool showAllEmployees = false;

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            showAllEmployees = !showAllEmployees;
            buttonShowAll.Text = showAllEmployees ? "Только активные" : "Показать всех";
            LoadEmployees(textBoxSearch.Text.Trim());
        }

        private void LoadEmployees(string searchTerm = "")
        {
            try
            {
                // Получаем специализации из главной базы
                var specializations = DatabaseManager.GetSpecializations();

                string query = @"
                    SELECT 
                        e.ID_employee,
                        e.LastName,
                        e.FirstName,
                        e.MiddleName,
                        e.ID_specialization,
                        e.Position,
                        e.Login,
                        e.ID_branch,
                        e.IsActive,
                        e.LastName || ' ' || e.FirstName || ' ' || e.MiddleName as FullName,
                        CASE WHEN e.IsActive = 1 THEN 'Активен' ELSE 'Неактивен' END as Status
                    FROM Employees e
                    WHERE e.ID_branch = @BranchID";

                if (!showAllEmployees)
                {
                    query += " AND e.IsActive = 1";
                }

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (e.LastName LIKE @Search OR e.FirstName LIKE @Search OR e.Position LIKE @Search)";
                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@BranchID", UserSession.BranchID),
                        new SQLiteParameter("@Search", $"%{searchTerm}%")
                    };
                }

                query += $" ORDER BY {GetSortExpression()}";

                var dataTable = db.ExecuteQuery(query, parameters);

                // Очищаем текущий список и добавляем новые данные
                employees.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int specializationId = row["ID_specialization"] != DBNull.Value ?
                        Convert.ToInt32(row["ID_specialization"]) : 0;

                    string specializationName = "Не указана";
                    if (specializationId > 0)
                    {
                        var specialization = specializations.AsEnumerable()
                            .FirstOrDefault(s => Convert.ToInt32(s["ID_specialization"]) == specializationId);
                        if (specialization != null)
                        {
                            specializationName = specialization["Name"].ToString();
                        }
                    }

                    string branchName = GetBranchName(Convert.ToInt32(row["ID_branch"]));

                    // В цикле foreach при создании объектов Employee:
                    employees.Add(new Employee
                    {
                        ID_employee = Convert.ToInt32(row["ID_employee"]),
                        LastName = row["LastName"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        Position = row["Position"].ToString(),
                        Login = row["Login"].ToString(),
                        ID_specialization = specializationId,
                        SpecializationName = specializationName,
                        BranchName = branchName,
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        Status = Convert.ToBoolean(row["IsActive"]) ? "Активен" : "Неактивен" // ПРАВИЛЬНОЕ ОПРЕДЕЛЕНИЕ СТАТУСА
                    });
                }

                UpdateSortIcons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
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
                case "SpecializationName":
                    sortExpression = "ID_specialization";
                    break;
                case "BranchName":
                    sortExpression = "ID_branch";
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
            foreach (DataGridViewColumn column in dataGridViewEmployees.Columns)
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

        private string GetBranchName(int branchId)
        {
            switch (branchId)
            {
                case 1: return "Главный филиал";
                case 2: return "Северный филиал";
                case 3: return "Южный филиал";
                case 4: return "Западный филиал";
                default: return "Неизвестный филиал";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadEmployees(textBoxSearch.Text.Trim());
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            LoadEmployees();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm();
            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees(); // Обновляем список после добавления
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEmployee = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (selectedEmployee != null)
            {
                // Загружаем полные данные сотрудника перед редактированием
                string query = @"
                    SELECT 
                        LastName, FirstName, MiddleName, Position, Login,
                        ID_specialization, ID_branch, IsActive
                    FROM Employees 
                    WHERE ID_employee = @EmployeeID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@EmployeeID", selectedEmployee.ID_employee)
                };

                var result = db.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    selectedEmployee.LastName = row["LastName"].ToString();
                    selectedEmployee.FirstName = row["FirstName"].ToString();
                    selectedEmployee.MiddleName = row["MiddleName"].ToString();
                    selectedEmployee.Position = row["Position"].ToString();
                    selectedEmployee.Login = row["Login"].ToString();
                    selectedEmployee.ID_specialization = row["ID_specialization"] != DBNull.Value ?
                        Convert.ToInt32(row["ID_specialization"]) : 0;
                    selectedEmployee.ID_branch = Convert.ToInt32(row["ID_branch"]);
                    selectedEmployee.IsActive = Convert.ToBoolean(row["IsActive"]);
                }

                var employeeForm = new EmployeeForm(selectedEmployee);
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees(); // Обновляем список после редактирования
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для деактивации", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEmployee = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (selectedEmployee != null)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите деактивировать сотрудника:\n{selectedEmployee.FullName}?",
                    "Подтверждение деактивации",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    DeactivateEmployee(selectedEmployee.ID_employee);
                }
            }
        }

        private void DeactivateEmployee(int employeeId)
        {
            try
            {
                string query = "UPDATE Employees SET IsActive = 0 WHERE ID_employee = @EmployeeID";
                var parameters = new SQLiteParameter[]
                {
            new SQLiteParameter("@EmployeeID", employeeId)
                };

                int rowsAffected = db.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Сотрудник успешно деактивирован", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees(); // Обновляем список
                }
                else
                {
                    MessageBox.Show("Не удалось деактивировать сотрудника", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при деактивации сотрудника: {ex.Message}", "Ошибка",
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

        private void dataGridViewEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void dataGridViewEmployees_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewEmployees.Columns[e.ColumnIndex].Name;

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

            LoadEmployees(textBoxSearch.Text.Trim());
        }

        private void dataGridViewEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDelete_Click(sender, e);
                e.Handled = true;
            }
        }

    }
}