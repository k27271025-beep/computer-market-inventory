// =====================================================================
// ФАЙЛ: MaintenanceForm.cs  — Форма регистрации обслуживания
// =====================================================================
using ComputerMarketInventory.Models;
using Dapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerMarketInventory
{
    public partial class MaintenanceForm : Form
    {
        private readonly EquipmentFlatModel _equipment;

        public MaintenanceForm(EquipmentFlatModel equipment)
        {
            InitializeComponent();
            _equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            // Показываем информацию об устройстве
            lblDeviceName.Text = _equipment.DeviceName;
            lblSerialNumber.Text = _equipment.SerialNumber;
            lblCategory.Text = _equipment.CategoryName;
            lblWear.Text = $"{_equipment.WearPercentage}%";

            dtpWorkDate.Value = DateTime.Now;
            dtpWorkDate.MaxDate = DateTime.Now;

            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    var workTypes = db.Query<WorkTypeModel>(
                        "SELECT Id, Name FROM WorkTypes ORDER BY Name").AsList();
                    cmbWorkType.DataSource = null;
                    cmbWorkType.DataSource = workTypes;
                    cmbWorkType.DisplayMember = "Name";
                    cmbWorkType.ValueMember = "Id";
                    cmbWorkType.SelectedIndex = -1;

                    var employees = db.Query<EmployeeModel>(
                        "SELECT Id, FullName, Position FROM Employees ORDER BY FullName").AsList();
                    cmbEmployee.DataSource = null;
                    cmbEmployee.DataSource = employees;
                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "Id";
                    cmbEmployee.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Валидация
            if (cmbWorkType.SelectedValue == null)
            { MessageBox.Show("Выберите тип выполненной работы.", "Валидация"); cmbWorkType.Focus(); return; }
            if (cmbEmployee.SelectedValue == null)
            { MessageBox.Show("Выберите исполнителя.", "Валидация"); cmbEmployee.Focus(); return; }
            if (nudServicePrice.Value <= 0)
            { MessageBox.Show("Укажите стоимость обслуживания.", "Валидация"); nudServicePrice.Focus(); return; }

            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    // 1. Сохранить запись обслуживания
                    db.Execute(@"
                        INSERT INTO MaintenanceLogs
                            (EquipmentId, WorkTypeId, WorkDate, EmployeeId, Notes, ServicePrice)
                        VALUES
                            (@EquipmentId, @WorkTypeId, @WorkDate, @EmployeeId, @Notes, @ServicePrice)",
                        new
                        {
                            EquipmentId = _equipment.Id,
                            WorkTypeId = (int)cmbWorkType.SelectedValue,
                            WorkDate = dtpWorkDate.Value,
                            EmployeeId = (int)cmbEmployee.SelectedValue,
                            Notes = txtNotes.Text.Trim(),
                            ServicePrice = nudServicePrice.Value
                        });

                    // 2. Изменить статус устройства на "На обслуживании"
                    db.Execute(@"
                        UPDATE DemoEquipments
                        SET StatusId = (SELECT Id FROM Statuses WHERE Name = N'На обслуживании')
                        WHERE Id = @Id", new { Id = _equipment.Id });
                }

                MessageBox.Show(
                    $"Обслуживание зарегистрировано.\nУстройство «{_equipment.DeviceName}» переведено в статус «На обслуживании».",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}