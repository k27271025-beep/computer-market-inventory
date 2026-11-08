// =====================================================================
// ФАЙЛ: MaintenanceViewForm.cs  — Журнал обслуживания (для мастеров)
// =====================================================================
using ComputerMarketInventory.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerMarketInventory
{
    public partial class MaintenanceViewForm : Form
    {
        private List<MaintenanceFlatModel> _allLogs = new List<MaintenanceFlatModel>();
        private BindingSource _bs = new BindingSource();

        public MaintenanceViewForm()
        {
            InitializeComponent();
        }

        private void MaintenanceViewForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvMaintenance.AutoGenerateColumns = false;
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.BackgroundColor = Color.White;
            dgvMaintenance.BorderStyle = BorderStyle.None;
            dgvMaintenance.GridColor = Color.FromArgb(210, 210, 210);
            dgvMaintenance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
            dgvMaintenance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaintenance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvMaintenance.EnableHeadersVisualStyles = false;
            dgvMaintenance.RowTemplate.Height = 28;
            dgvMaintenance.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 245, 255);

            dgvMaintenance.Columns.Clear();

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Дата работы", DataPropertyName = "WorkDate", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" } });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDevice", HeaderText = "Устройство", DataPropertyName = "DeviceName", Width = 100 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSN", HeaderText = "S/N", DataPropertyName = "SerialNumber", Width = 140 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCat", HeaderText = "Категория", DataPropertyName = "CategoryName", Width = 120 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colWork", HeaderText = "Тип работы", DataPropertyName = "WorkType", Width = 160 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmployee", HeaderText = "Исполнитель", DataPropertyName = "EmployeeName", Width = 150 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colWear", HeaderText = "Износ %", DataPropertyName = "WearPercentage", Width = 70 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Статус", DataPropertyName = "StatusName", Width = 130 });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Стоимость ₽", DataPropertyName = "ServicePrice", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNotes", HeaderText = "Примечание", DataPropertyName = "Notes", Width = 200 });

            dgvMaintenance.DataSource = _bs;
        }

        private void LoadData()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    string sql = @"
                        SELECT
                            ml.Id          AS LogId,
                            d.DeviceName,
                            d.SerialNumber,
                            c.Name         AS CategoryName,
                            wt.Name        AS WorkType,
                            ml.WorkDate,
                            e.FullName     AS EmployeeName,
                            ml.Notes,
                            ml.ServicePrice,
                            d.WearPercentage,
                            s.Name         AS StatusName
                        FROM MaintenanceLogs ml
                        INNER JOIN DemoEquipments d  ON ml.EquipmentId  = d.Id
                        INNER JOIN Categories      c  ON d.CategoryId    = c.Id
                        INNER JOIN WorkTypes       wt ON ml.WorkTypeId   = wt.Id
                        INNER JOIN Employees       e  ON ml.EmployeeId   = e.Id
                        INNER JOIN Statuses        s  ON d.StatusId      = s.Id
                        ORDER BY ml.WorkDate DESC";

                    _allLogs = db.Query<MaintenanceFlatModel>(sql).ToList();
                }

                txtSearch.Text = string.Empty;
                _bs.DataSource = _allLogs;
                lblCount.Text = $"Записей: {_allLogs.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void ApplySearch()
        {
            string q = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(q))
            {
                _bs.DataSource = _allLogs;
            }
            else
            {
                _bs.DataSource = _allLogs.Where(x =>
                    (x.DeviceName != null && x.DeviceName.ToLower().Contains(q)) ||
                    (x.SerialNumber != null && x.SerialNumber.ToLower().Contains(q)) ||
                    (x.EmployeeName != null && x.EmployeeName.ToLower().Contains(q)) ||
                    (x.WorkType != null && x.WorkType.ToLower().Contains(q))).ToList();
            }
            lblCount.Text = $"Показано: {_bs.Count} из {_allLogs.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplySearch();

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}