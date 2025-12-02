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
    public partial class CabinetsManagementForm : Form
    {
        private DatabaseHelper db;
        private BindingList<Cabinet> cabinets;
        private string currentSortColumn = "CabinetNumber";
        private SortOrder currentSortOrder = SortOrder.Ascending;

        public CabinetsManagementForm()
        {
            InitializeComponent();
            db = DatabaseManager.GetCurrentBranchDatabase();
            cabinets = new BindingList<Cabinet>();
            dataGridViewCabinets.DataSource = cabinets;
            ConfigureDataGridView();
            InitializeFormForCabinets(); // Инициализируем форму для кабинетов
            LoadCabinets();
        }

        private void InitializeFormForCabinets()
        {
            // Если в вашей таблице Cabinets нет поля IsActive, скрываем кнопку "Показать все"
            buttonShowAll.Visible = false;
        }

        private void ConfigureDataGridView()
        {
            // Настраиваем внешний вид DataGridView
            dataGridViewCabinets.AutoGenerateColumns = false;
            dataGridViewCabinets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCabinets.MultiSelect = false;
            dataGridViewCabinets.ReadOnly = true;
            dataGridViewCabinets.AllowUserToResizeRows = false;
            dataGridViewCabinets.RowTemplate.Height = 35;

            // Добавляем колонки
            dataGridViewCabinets.Columns.Clear();

            dataGridViewCabinets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ID_cabinet",
                DataPropertyName = "ID_cabinet",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            });

            dataGridViewCabinets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CabinetNumber",
                DataPropertyName = "CabinetNumber",
                HeaderText = "Номер кабинета",
                Width = 150,
                FillWeight = 30
            });

            dataGridViewCabinets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Purpose",
                DataPropertyName = "Purpose",
                HeaderText = "Назначение",
                Width = 250,
                FillWeight = 50
            });

            dataGridViewCabinets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BranchInfo",
                DataPropertyName = "BranchInfo",
                HeaderText = "Филиал",
                Width = 200,
                FillWeight = 20
            });

            // Включаем сортировку для всех колонок
            foreach (DataGridViewColumn column in dataGridViewCabinets.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            // Эта функция не нужна, если нет поля IsActive
            // Оставляем пустой или удаляем кнопку из дизайнера
        }

        private void LoadCabinets(string searchTerm = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        c.ID_cabinet,
                        c.ID_branch,
                        c.CabinetNumber,
                        c.Purpose
                    FROM Cabinets c
                    WHERE c.ID_branch = @BranchID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", UserSession.BranchID)
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (c.CabinetNumber LIKE @Search OR c.Purpose LIKE @Search)";
                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@BranchID", UserSession.BranchID),
                        new SQLiteParameter("@Search", $"%{searchTerm}%")
                    };
                }

                query += $" ORDER BY {GetSortExpression()}";

                var dataTable = db.ExecuteQuery(query, parameters);

                // Получаем информацию о филиале
                string branchName = GetBranchName(UserSession.BranchID);

                // Очищаем текущий список и добавляем новые данные
                cabinets.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    cabinets.Add(new Cabinet
                    {
                        ID_cabinet = Convert.ToInt32(row["ID_cabinet"]),
                        ID_branch = Convert.ToInt32(row["ID_branch"]),
                        CabinetNumber = row["CabinetNumber"].ToString(),
                        Purpose = row["Purpose"].ToString(),
                        // Создаем временный Branch объект для отображения
                        Branch = new Branch
                        {
                            ID_branch = Convert.ToInt32(row["ID_branch"]),
                            Name = branchName
                        }
                    });
                }

                UpdateSortIcons();
                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке кабинетов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetBranchName(int branchId)
        {
            // Получаем название филиала
            try
            {
                var mainDb = DatabaseManager.GetMainDatabase();
                string query = "SELECT Name FROM Branches WHERE ID_branch = @BranchID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BranchID", branchId)
                };

                var result = mainDb.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении названия филиала: {ex.Message}");
            }

            // Резервные названия
            switch (branchId)
            {
                case 1: return "Главный филиал";
                case 2: return "Северный филиал";
                case 3: return "Южный филиал";
                case 4: return "Западный филиал";
                default: return $"Филиал {branchId}";
            }
        }

        private void UpdateStatusLabel()
        {
            labelStatus.Text = $"Найдено кабинетов: {cabinets.Count}";
        }

        private string GetSortExpression()
        {
            string sortExpression = currentSortColumn;

            switch (currentSortColumn)
            {
                case "CabinetNumber":
                    sortExpression = "CabinetNumber";
                    break;
                case "Purpose":
                    sortExpression = "Purpose";
                    break;
                case "BranchInfo":
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
            foreach (DataGridViewColumn column in dataGridViewCabinets.Columns)
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
            LoadCabinets(textBoxSearch.Text.Trim());
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            LoadCabinets();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var cabinetForm = new CabinetForm();
            if (cabinetForm.ShowDialog() == DialogResult.OK)
            {
                LoadCabinets();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCabinets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кабинет для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCabinet = dataGridViewCabinets.SelectedRows[0].DataBoundItem as Cabinet;
            if (selectedCabinet != null)
            {
                var cabinetForm = new CabinetForm(selectedCabinet);
                if (cabinetForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCabinets();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCabinets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кабинет для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCabinet = dataGridViewCabinets.SelectedRows[0].DataBoundItem as Cabinet;
            if (selectedCabinet != null)
            {
                // Проверяем, используется ли кабинет в записях на прием
                if (IsCabinetInUse(selectedCabinet.ID_cabinet))
                {
                    MessageBox.Show("Нельзя удалить кабинет, так как он используется в записях на прием.\nСначала удалите или измените связанные записи.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить кабинет:\n{selectedCabinet.CabinetNumber} - {selectedCabinet.Purpose}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    DeleteCabinet(selectedCabinet.ID_cabinet);
                }
            }
        }

        private bool IsCabinetInUse(int cabinetId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Appointments WHERE ID_cabinet = @CabinetID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@CabinetID", cabinetId)
                };

                var result = db.ExecuteScalar(query, parameters);
                int count = Convert.ToInt32(result);

                return count > 0;
            }
            catch (Exception ex)
            {
                // Используем переменную ex
                MessageBox.Show($"Ошибка при проверке использования кабинета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // В случае ошибки считаем, что кабинет используется (безопасный вариант)
            }
        }

        private void DeleteCabinet(int cabinetId)
        {
            try
            {
                string query = "DELETE FROM Cabinets WHERE ID_cabinet = @CabinetID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@CabinetID", cabinetId)
                };

                int rowsAffected = db.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Кабинет успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCabinets();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить кабинет", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении кабинета: {ex.Message}", "Ошибка",
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

        private void dataGridViewCabinets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void dataGridViewCabinets_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewCabinets.Columns[e.ColumnIndex].Name;

            if (columnName == currentSortColumn)
            {
                currentSortOrder = currentSortOrder == SortOrder.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                currentSortColumn = columnName;
                currentSortOrder = SortOrder.Ascending;
            }

            LoadCabinets(textBoxSearch.Text.Trim());
        }

        private void dataGridViewCabinets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDelete_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}