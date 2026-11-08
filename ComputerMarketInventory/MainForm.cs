// =====================================================================
// ФАЙЛ: MainForm.cs  — Главная форма
// =====================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComputerMarketInventory.Models;
using Dapper;

namespace ComputerMarketInventory
{
    public partial class MainForm : Form
    {
        private List<EquipmentFlatModel> _allEquipment = new List<EquipmentFlatModel>();
        private BindingSource _bindingSource = new BindingSource();
        private bool _isLoading = false;

        public MainForm()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------
        // ЗАГРУЗКА ФОРМЫ
        // ---------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCategoriesFilter();
            CalculateWearAndUpdateDB();
            LoadMainData();
        }

        // ---------------------------------------------------------------
        // НАСТРОЙКА DATAGRIDVIEW (программно — надёжнее дизайнера)
        // ---------------------------------------------------------------
        private void SetupDataGridView()
        {
            dgvEquipment.AutoGenerateColumns = false;
            dgvEquipment.ReadOnly = true;
            dgvEquipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipment.AllowUserToAddRows = false;
            dgvEquipment.AllowUserToDeleteRows = false;
            dgvEquipment.RowHeadersVisible = false;
            dgvEquipment.BackgroundColor = Color.White;
            dgvEquipment.BorderStyle = BorderStyle.None;
            dgvEquipment.GridColor = Color.FromArgb(220, 220, 220);
            dgvEquipment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvEquipment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEquipment.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvEquipment.EnableHeadersVisualStyles = false;
            dgvEquipment.RowTemplate.Height = 26;
            dgvEquipment.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvEquipment.Columns.Clear();

            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSN",
                HeaderText = "S/N  Сер.номер",
                DataPropertyName = "SerialNumber",
                Width = 140,
                ReadOnly = true
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Название устройства",
                DataPropertyName = "DeviceName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCat",
                HeaderText = "Категория",
                DataPropertyName = "CategoryName",
                Width = 130,
                ReadOnly = true
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Дата выст.",
                DataPropertyName = "DisplayStartDate",
                Width = 95,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colWear",
                HeaderText = "Износ %",
                DataPropertyName = "WearPercentage",
                Width = 70,
                ReadOnly = true
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Цена (руб.)",
                DataPropertyName = "BasePrice",
                Width = 110,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Статус",
                DataPropertyName = "StatusName",
                Width = 150,
                ReadOnly = true
            });

            // Раскраска строк по статусу
            dgvEquipment.CellFormatting += DgvEquipment_CellFormatting;

            dgvEquipment.DataSource = _bindingSource;
        }

        // Раскраска строк: красный = уценка, жёлтый = обслуживание, серый = списано
        private void DgvEquipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgvEquipment.Rows[e.RowIndex].DataBoundItem is EquipmentFlatModel item)) return;

            Color rowColor;
            switch (item.StatusName)
            {
                case "Продано с уценкой": rowColor = Color.FromArgb(255, 220, 220); break;
                case "На обслуживании": rowColor = Color.FromArgb(255, 250, 200); break;
                case "Списано": rowColor = Color.FromArgb(220, 220, 220); break;
                default: rowColor = Color.White; break;
            }

            // Цена уценки — красным жирным в колонке цены
            if (dgvEquipment.Columns[e.ColumnIndex].Name == "colPrice" &&
                item.StatusName == "Продано с уценкой")
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font(dgvEquipment.Font, FontStyle.Bold);
                e.Value = item.DiscountedPrice.ToString("N2") + " ₽";
                e.FormattingApplied = true;
            }
            else
            {
                dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
            }
        }

        // ---------------------------------------------------------------
        // ЗАГРУЗКА ДАННЫХ
        // ---------------------------------------------------------------
        private void LoadMainData()
        {
            _isLoading = true;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    string sql = @"
                        SELECT t1.Id, t1.SerialNumber, t1.DeviceName,
                               t1.DisplayStartDate, t1.WearPercentage, t1.BasePrice,
                               t2.Name AS CategoryName,
                               t3.Name AS StatusName
                        FROM DemoEquipments t1
                        INNER JOIN Categories t2 ON t1.CategoryId = t2.Id
                        INNER JOIN Statuses   t3 ON t1.StatusId   = t3.Id
                        ORDER BY t1.DisplayStartDate DESC";

                    _allEquipment = db.Query<EquipmentFlatModel>(sql).ToList();
                }

                txtSearch.Text = string.Empty;
                if (cmbCategoryFilter.Items.Count > 0)
                    cmbCategoryFilter.SelectedIndex = 0;

                _bindingSource.DataSource = _allEquipment;
                toolStripStatusLabel1.Text =
                    $"Загружено позиций: {_allEquipment.Count}  |  БД подключена  |  {DateTime.Now:dd.MM.yyyy HH:mm}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка загрузки данных:\n{ex.Message}",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Ошибка подключения к БД.";
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _isLoading = false;
            }
        }

        private void LoadCategoriesFilter()
        {
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    var list = db.Query<CategoryModel>(
                        "SELECT Id, Name FROM Categories ORDER BY Name").AsList();
                    list.Insert(0, new CategoryModel { Id = -1, Name = "-- Все категории --" });
                    cmbCategoryFilter.DataSource = list;
                    cmbCategoryFilter.DisplayMember = "Name";
                    cmbCategoryFilter.ValueMember = "Id";
                    cmbCategoryFilter.SelectedIndex = 0;
                }
            }
            catch { /* не критично */ }
        }

        // ---------------------------------------------------------------
        // ФИЛЬТРАЦИЯ (только в памяти, без обращений к БД)
        // ---------------------------------------------------------------
        private void ApplyFilters()
        {
            if (_isLoading) return;

            IEnumerable<EquipmentFlatModel> filtered = _allEquipment;

            if (cmbCategoryFilter.SelectedValue is int catId && catId != -1)
            {
                string catName = ((CategoryModel)cmbCategoryFilter.SelectedItem).Name;
                filtered = filtered.Where(x => x.CategoryName == catName);
            }

            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(x =>
                    (x.DeviceName != null && x.DeviceName.ToLower().Contains(search)) ||
                    (x.SerialNumber != null && x.SerialNumber.ToLower().Contains(search)));
            }

            var result = filtered.ToList();
            _bindingSource.DataSource = result;
            toolStripStatusLabel1.Text = $"Найдено: {result.Count} из {_allEquipment.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();

        // ---------------------------------------------------------------
        // БИЗНЕС-ЛОГИКА: пересчёт износа
        // ---------------------------------------------------------------
        private void CalculateWearAndUpdateDB()
        {
            toolStripStatusLabel1.Text = "Пересчёт износа оборудования...";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    var list = db.Query(@"
                        SELECT d.Id, d.DisplayStartDate, d.WearPercentage
                        FROM DemoEquipments d
                        INNER JOIN Statuses s ON d.StatusId = s.Id
                        WHERE s.Name = N'На витрине' AND d.WearPercentage < 100").ToList();

                    int updated = 0;
                    foreach (var item in list)
                    {
                        DateTime start = (DateTime)item.DisplayStartDate;
                        int currentWear = (int)item.WearPercentage;
                        int months = ((DateTime.Now.Year - start.Year) * 12)
                                     + DateTime.Now.Month - start.Month;
                        if (DateTime.Now.Day < start.Day) months--;
                        if (months > 0)
                        {
                            int newWear = Math.Min(months * 2, 100);
                            if (newWear > currentWear)
                            {
                                db.Execute("UPDATE DemoEquipments SET WearPercentage=@w WHERE Id=@Id",
                                    new { w = newWear, Id = (int)item.Id });
                                updated++;
                            }
                        }
                    }

                    toolStripStatusLabel1.Text = updated > 0
                        ? $"Износ актуализирован — обновлено {updated} поз."
                        : "Проверка износа завершена. Изменений нет.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка пересчёта износа:\n{ex.Message}", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        // ---------------------------------------------------------------
        // КНОПКИ
        // ---------------------------------------------------------------
        private EquipmentFlatModel GetSelected()
        {
            return dgvEquipment.CurrentRow?.DataBoundItem as EquipmentFlatModel;
        }

        // [++] Добавить устройство
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditEquipmentForm(null))
                if (form.ShowDialog() == DialogResult.OK) LoadMainData();
        }

        // Редактировать
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var sel = GetSelected();
            if (sel == null)
            {
                MessageBox.Show("Выберите устройство для редактирования.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var form = new AddEditEquipmentForm(sel.Id))
                if (form.ShowDialog() == DialogResult.OK) LoadMainData();
        }

        // Обслуживание
        private void btnService_Click(object sender, EventArgs e)
        {
            var sel = GetSelected();
            if (sel == null)
            {
                MessageBox.Show("Выберите устройство для отправки на обслуживание.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sel.StatusName == "Продано с уценкой" || sel.StatusName == "Списано")
            {
                MessageBox.Show(
                    $"Устройство «{sel.DeviceName}» выбыло с витрины (статус: {sel.StatusName}).\nРегистрация обслуживания невозможна.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new MaintenanceForm(sel))
                if (form.ShowDialog() == DialogResult.OK) LoadMainData();
        }

        // Оформить УЦЕНКУ
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            var sel = GetSelected();
            if (sel == null)
            {
                MessageBox.Show("Выберите устройство для оформления уценки.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sel.StatusName != "На витрине")
            {
                MessageBox.Show(
                    $"Оформить уценку можно только для товара со статусом «На витрине».\nТекущий статус: {sel.StatusName}",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal discounted = sel.DiscountedPrice;
            string msg =
                $"Оформить продажу с уценкой?\n\n" +
                $"Устройство:   {sel.DeviceName}\n" +
                $"Серийный №:  {sel.SerialNumber}\n" +
                $"Износ:           {sel.WearPercentage}%\n\n" +
                $"Базовая цена:   {sel.BasePrice:N2} ₽\n" +
                $"Цена с уценкой: {discounted:N2} ₽  (-{sel.WearPercentage}%)";

            if (MessageBox.Show(msg, "Подтверждение уценки и продажи",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection db = DbService.GetConnection())
                    {
                        db.Execute(@"
                            UPDATE DemoEquipments
                            SET StatusId = (SELECT Id FROM Statuses WHERE Name = N'Продано с уценкой')
                            WHERE Id = @Id", new { Id = sel.Id });
                        LoadMainData();
                        MessageBox.Show(
                            $"Товар переведён в статус «Продано с уценкой».\nЦена продажи: {discounted:N2} ₽",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка БД:\n{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Журнал обслуживания (новая форма для мастеров)
        private void btnMaintenanceView_Click(object sender, EventArgs e)
        {
            using (var form = new MaintenanceViewForm())
                form.ShowDialog();
        }
    }
}