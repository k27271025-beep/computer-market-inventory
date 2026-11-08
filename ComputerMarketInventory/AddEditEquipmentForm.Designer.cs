// =====================================================================
// ФАЙЛ: AddEditEquipmentForm.Designer.cs
// ИЗМЕНЕНО: добавлены nudWear, lblWear, lblWearHint, lblDiscountedPrice
// Все координаты — конкретные числа (без переменных и лямбд)
// =====================================================================
namespace ComputerMarketInventory
{
    partial class AddEditEquipmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudBasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblWear = new System.Windows.Forms.Label();
            this.nudWear = new System.Windows.Forms.NumericUpDown();
            this.lblWearHint = new System.Windows.Forms.Label();
            this.pnlDiscounted = new System.Windows.Forms.Panel();
            this.lblDiscountedPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWear)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlDiscounted.SuspendLayout();
            this.SuspendLayout();

            // Сетка: lx=20 cx=175 cw=300 lh=26 gap=40
            // row0=65  row1=105  row2=145  row3=185  row4=225
            // row5=265 row6=305  panel=348 btnY=402

            // ── pnlHeader (h=50)
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.Text = "Устройство";
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.pnlHeader.Controls.Add(this.lblTitle);

            // ── row0 y=65: Название
            this.lblDeviceName.Text = "Название устройства:";
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(20, 69);
            this.lblDeviceName.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDeviceName.Name = "lblDeviceName";

            this.txtDeviceName.Location = new System.Drawing.Point(175, 65);
            this.txtDeviceName.Size = new System.Drawing.Size(300, 26);
            this.txtDeviceName.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtDeviceName.Name = "txtDeviceName";

            // ── row1 y=105: Серийный номер
            this.lblSerial.Text = "Серийный номер (S/N):";
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(20, 109);
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSerial.Name = "lblSerial";

            this.txtSerialNumber.Location = new System.Drawing.Point(175, 105);
            this.txtSerialNumber.Size = new System.Drawing.Size(300, 26);
            this.txtSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtSerialNumber.Name = "txtSerialNumber";

            // ── row2 y=145: Категория
            this.lblCategory.Text = "Категория:";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 149);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCategory.Name = "lblCategory";

            this.cmbCategory.Location = new System.Drawing.Point(175, 145);
            this.cmbCategory.Size = new System.Drawing.Size(300, 26);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbCategory.Name = "cmbCategory";

            // ── row3 y=185: Статус
            this.lblStatus.Text = "Статус:";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 189);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStatus.Name = "lblStatus";

            this.cmbStatus.Location = new System.Drawing.Point(175, 185);
            this.cmbStatus.Size = new System.Drawing.Size(300, 26);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbStatus.Name = "cmbStatus";

            // ── row4 y=225: Дата выставления
            this.lblDate.Text = "Дата выставления:";
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 229);
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDate.Name = "lblDate";

            this.dtpStartDate.Location = new System.Drawing.Point(175, 225);
            this.dtpStartDate.Size = new System.Drawing.Size(200, 26);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Name = "dtpStartDate";

            // ── row5 y=265: Базовая цена
            this.lblPrice.Text = "Базовая цена (руб.):";
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 269);
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblPrice.Name = "lblPrice";

            this.nudBasePrice.Location = new System.Drawing.Point(175, 265);
            this.nudBasePrice.Size = new System.Drawing.Size(170, 26);
            this.nudBasePrice.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudBasePrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.nudBasePrice.DecimalPlaces = 2;
            this.nudBasePrice.ThousandsSeparator = true;
            this.nudBasePrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.nudBasePrice.Name = "nudBasePrice";

            // ── row6 y=305: Износ % — НОВОЕ ПОЛЕ
            this.lblWear.Text = "Износ (%):";
            this.lblWear.AutoSize = true;
            this.lblWear.Location = new System.Drawing.Point(20, 309);
            this.lblWear.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblWear.Name = "lblWear";

            this.nudWear.Location = new System.Drawing.Point(175, 305);
            this.nudWear.Size = new System.Drawing.Size(80, 26);
            this.nudWear.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudWear.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudWear.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWear.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.nudWear.Name = "nudWear";

            // Подсказка рядом с полем износа
            this.lblWearHint.Text = "0% — новый товар";
            this.lblWearHint.AutoSize = true;
            this.lblWearHint.Location = new System.Drawing.Point(265, 309);
            this.lblWearHint.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Italic);
            this.lblWearHint.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblWearHint.Name = "lblWearHint";

            // ── pnlDiscounted y=348: панель с расчётной ценой
            this.pnlDiscounted.Location = new System.Drawing.Point(20, 346);
            this.pnlDiscounted.Size = new System.Drawing.Size(455, 36);
            this.pnlDiscounted.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlDiscounted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiscounted.Name = "pnlDiscounted";

            this.lblDiscountedPrice.Text = "Цена с уценкой: —";
            this.lblDiscountedPrice.AutoSize = true;
            this.lblDiscountedPrice.Location = new System.Drawing.Point(8, 9);
            this.lblDiscountedPrice.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDiscountedPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblDiscountedPrice.Name = "lblDiscountedPrice";
            this.pnlDiscounted.Controls.Add(this.lblDiscountedPrice);

            // ── Кнопки y=400
            this.btnSave.Text = "Выставить на витрину";
            this.btnSave.Location = new System.Drawing.Point(175, 400);
            this.btnSave.Size = new System.Drawing.Size(195, 36);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(380, 400);
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── Form  (высота = 400 + 36 + 18 = 454)
            this.ClientSize = new System.Drawing.Size(500, 454);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Устройство";
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Name = "AddEditEquipmentForm";

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlDiscounted);
            this.Controls.Add(this.lblWearHint);
            this.Controls.Add(this.nudWear);
            this.Controls.Add(this.lblWear);
            this.Controls.Add(this.nudBasePrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.pnlHeader);

            this.Load += new System.EventHandler(this.AddEditEquipmentForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWear)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDiscounted.ResumeLayout(false);
            this.pnlDiscounted.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudBasePrice;
        private System.Windows.Forms.Label lblWear;
        private System.Windows.Forms.NumericUpDown nudWear;
        private System.Windows.Forms.Label lblWearHint;
        private System.Windows.Forms.Panel pnlDiscounted;
        private System.Windows.Forms.Label lblDiscountedPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}