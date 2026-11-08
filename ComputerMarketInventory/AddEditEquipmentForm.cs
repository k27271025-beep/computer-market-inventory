// =====================================================================
// ФАЙЛ: AddEditEquipmentForm.cs
// ИЗМЕНЕНО: добавлен ввод и редактирование износа (nudWear)
// =====================================================================
using ComputerMarketInventory.Models;
using Dapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerMarketInventory
{
    public partial class AddEditEquipmentForm : Form
    {
        private int? _equipmentId;
        private bool _isEditMode => _equipmentId.HasValue;

        public AddEditEquipmentForm(int? id = null)
        {
            InitializeComponent();
            _equipmentId = id;
        }

        private void AddEditEquipmentForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (_isEditMode)
            {
                this.Text = "Редактирование устройства";
                btnSave.Text = "Сохранить изменения";
                txtSerialNumber.ReadOnly = true;

                // При редактировании износ можно менять вручную
                nudWear.Enabled = true;
                lblWearHint.Text = "Можно скорректировать вручную";
                LoadEquipmentData();
            }
            else
            {
                this.Text = "Добавление нового устройства на витрину";
                btnSave.Text = "Выставить на витрину";
                dtpStartDate.Value = DateTime.Now;

                // При добавлении износ = 0, но можно указать если товар уже б/у
                nudWear.Value = 0;
                nudWear.Enabled = true;
                lblWearHint.Text = "0% — новый товар";
                SetDefaultStatus();
            }

            // Пересчёт уценённой цены при изменении любого из полей
            nudWear.ValueChanged += RecalcDiscountedPrice;
            nudBasePrice.ValueChanged += RecalcDiscountedPrice;
            RecalcDiscountedPrice(null, null);
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    var categories = db.Query<CategoryModel>(
                        "SELECT Id, Name FROM Categories ORDER BY Name").AsList();
                    cmbCategory.DataSource = null;
                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "Name";
                    cmbCategory.ValueMember = "Id";
                    cmbCategory.SelectedIndex = -1;

                    var statuses = db.Query<StatusModel>(
                        "SELECT Id, Name FROM Statuses ORDER BY Name").AsList();
                    cmbStatus.DataSource = null;
                    cmbStatus.DataSource = statuses;
                    cmbStatus.DisplayMember = "Name";
                    cmbStatus.ValueMember = "Id";
                    cmbStatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultStatus()
        {
            foreach (StatusModel item in cmbStatus.Items)
            {
                if (item.Name == "На витрине")
                {
                    cmbStatus.SelectedValue = item.Id;
                    cmbStatus.Enabled = false;
                    break;
                }
            }
        }

        private void LoadEquipmentData()
        {
            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    var eq = db.QuerySingleOrDefault<EquipmentModel>(
                        "SELECT * FROM DemoEquipments WHERE Id = @Id",
                        new { Id = _equipmentId });

                    if (eq == null)
                    {
                        MessageBox.Show("Запись не найдена.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }

                    txtDeviceName.Text = eq.DeviceName;
                    txtSerialNumber.Text = eq.SerialNumber;
                    dtpStartDate.Value = eq.DisplayStartDate;
                    nudBasePrice.Value = eq.BasePrice;

                    // Загружаем текущий износ в поле — теперь можно редактировать
                    nudWear.Value = eq.WearPercentage;

                    cmbCategory.SelectedValue = eq.CategoryId;
                    cmbStatus.SelectedValue = eq.StatusId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки устройства:\n{ex.Message}");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Пересчёт цены с уценкой в реальном времени
        private void RecalcDiscountedPrice(object sender, EventArgs e)
        {
            if (nudBasePrice.Value > 0)
            {
                decimal discounted = nudBasePrice.Value * (1m - nudWear.Value / 100m);
                lblDiscountedPrice.Text = $"Цена с уценкой: {discounted:N2} руб.";
                lblDiscountedPrice.ForeColor = nudWear.Value > 0
                    ? System.Drawing.Color.FromArgb(192, 57, 43)
                    : System.Drawing.Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblDiscountedPrice.Text = "Цена с уценкой: —";
                lblDiscountedPrice.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var eq = new EquipmentModel
            {
                DeviceName = txtDeviceName.Text.Trim(),
                SerialNumber = txtSerialNumber.Text.Trim(),
                DisplayStartDate = dtpStartDate.Value,
                CategoryId = (int)cmbCategory.SelectedValue,
                StatusId = (int)cmbStatus.SelectedValue,
                WearPercentage = (int)nudWear.Value,   // <-- берём из поля напрямую
                BasePrice = nudBasePrice.Value
            };

            try
            {
                using (IDbConnection db = DbService.GetConnection())
                {
                    if (_isEditMode)
                    {
                        eq.Id = _equipmentId.Value;
                        db.Execute(@"
                            UPDATE DemoEquipments SET
                                DeviceName       = @DeviceName,
                                CategoryId       = @CategoryId,
                                DisplayStartDate = @DisplayStartDate,
                                StatusId         = @StatusId,
                                WearPercentage   = @WearPercentage,
                                BasePrice        = @BasePrice
                            WHERE Id = @Id", eq);
                    }
                    else
                    {
                        bool exists = db.ExecuteScalar<bool>(
                            "SELECT COUNT(1) FROM DemoEquipments WHERE SerialNumber = @SN",
                            new { SN = eq.SerialNumber });
                        if (exists)
                        {
                            MessageBox.Show("Устройство с таким серийным номером уже есть в базе!",
                                "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSerialNumber.Focus();
                            return;
                        }
                        db.Execute(@"
                            INSERT INTO DemoEquipments
                                (DeviceName, CategoryId, SerialNumber, DisplayStartDate, WearPercentage, StatusId, BasePrice)
                            VALUES
                                (@DeviceName, @CategoryId, @SerialNumber, @DisplayStartDate, @WearPercentage, @StatusId, @BasePrice)",
                            eq);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            { MessageBox.Show("Введите название устройства.", "Валидация"); txtDeviceName.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtSerialNumber.Text))
            { MessageBox.Show("Введите серийный номер.", "Валидация"); txtSerialNumber.Focus(); return false; }

            if (cmbCategory.SelectedValue == null)
            { MessageBox.Show("Выберите категорию.", "Валидация"); cmbCategory.Focus(); return false; }

            if (cmbStatus.SelectedValue == null)
            { MessageBox.Show("Выберите статус.", "Валидация"); cmbStatus.Focus(); return false; }

            if (dtpStartDate.Value.Date > DateTime.Now.Date)
            { MessageBox.Show("Дата выставления не может быть в будущем.", "Валидация"); return false; }

            if (nudBasePrice.Value <= 0)
            { MessageBox.Show("Укажите базовую цену устройства.", "Валидация"); nudBasePrice.Focus(); return false; }

            if (nudWear.Value < 0 || nudWear.Value > 100)
            { MessageBox.Show("Износ должен быть от 0 до 100%.", "Валидация"); nudWear.Focus(); return false; }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}