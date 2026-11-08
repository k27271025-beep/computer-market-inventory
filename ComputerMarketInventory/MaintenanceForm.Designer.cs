// =====================================================================
// ФАЙЛ: MaintenanceForm.Designer.cs
// ИСПРАВЛЕНО: убраны анонимные Label (new Label{...}) внутри метода —
// Designer падает с NullReferenceException на них.
// Все Label объявлены как поля класса и инициализируются явно.
// =====================================================================
namespace ComputerMarketInventory
{
    partial class MaintenanceForm
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlDeviceInfo = new System.Windows.Forms.Panel();
            this.lblDevInfoTitle = new System.Windows.Forms.Label();
            // Поля панели информации об устройстве
            this.lblDNCaption = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblSNCaption = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblCatCaption = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblWearCaption = new System.Windows.Forms.Label();
            this.lblWear = new System.Windows.Forms.Label();
            // Поля формы
            this.lblWorkType = new System.Windows.Forms.Label();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblServicePrice = new System.Windows.Forms.Label();
            this.nudServicePrice = new System.Windows.Forms.NumericUpDown();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudServicePrice)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlDeviceInfo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader (y=0, h=50)
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.pnlHeader.Name = "pnlHeader";

            this.lblFormTitle.Text = "Регистрация обслуживания";
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(14, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.pnlHeader.Controls.Add(this.lblFormTitle);

            // ── pnlDeviceInfo (y=58, h=108)
            this.pnlDeviceInfo.Location = new System.Drawing.Point(10, 58);
            this.pnlDeviceInfo.Size = new System.Drawing.Size(480, 108);
            this.pnlDeviceInfo.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlDeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeviceInfo.Name = "pnlDeviceInfo";

            this.lblDevInfoTitle.Text = "УСТРОЙСТВО:";
            this.lblDevInfoTitle.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblDevInfoTitle.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.lblDevInfoTitle.Location = new System.Drawing.Point(8, 6);
            this.lblDevInfoTitle.AutoSize = true;
            this.lblDevInfoTitle.Name = "lblDevInfoTitle";

            // Строка "Название:"
            this.lblDNCaption.Text = "Название:";
            this.lblDNCaption.Location = new System.Drawing.Point(8, 26);
            this.lblDNCaption.AutoSize = true;
            this.lblDNCaption.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDNCaption.Name = "lblDNCaption";

            this.lblDeviceName.Location = new System.Drawing.Point(90, 26);
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDeviceName.MaximumSize = new System.Drawing.Size(375, 0);
            this.lblDeviceName.Name = "lblDeviceName";

            // Строка "S/N:"
            this.lblSNCaption.Text = "S/N:";
            this.lblSNCaption.Location = new System.Drawing.Point(8, 50);
            this.lblSNCaption.AutoSize = true;
            this.lblSNCaption.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSNCaption.Name = "lblSNCaption";

            this.lblSerialNumber.Location = new System.Drawing.Point(90, 50);
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSerialNumber.Name = "lblSerialNumber";

            // Строка "Категория:" и "Износ:"
            this.lblCatCaption.Text = "Категория:";
            this.lblCatCaption.Location = new System.Drawing.Point(8, 74);
            this.lblCatCaption.AutoSize = true;
            this.lblCatCaption.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCatCaption.Name = "lblCatCaption";

            this.lblCategory.Location = new System.Drawing.Point(90, 74);
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCategory.Name = "lblCategory";

            this.lblWearCaption.Text = "Износ:";
            this.lblWearCaption.Location = new System.Drawing.Point(300, 74);
            this.lblWearCaption.AutoSize = true;
            this.lblWearCaption.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblWearCaption.Name = "lblWearCaption";

            this.lblWear.Location = new System.Drawing.Point(348, 74);
            this.lblWear.AutoSize = true;
            this.lblWear.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblWear.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblWear.Name = "lblWear";

            this.pnlDeviceInfo.Controls.Add(this.lblDevInfoTitle);
            this.pnlDeviceInfo.Controls.Add(this.lblDNCaption);
            this.pnlDeviceInfo.Controls.Add(this.lblDeviceName);
            this.pnlDeviceInfo.Controls.Add(this.lblSNCaption);
            this.pnlDeviceInfo.Controls.Add(this.lblSerialNumber);
            this.pnlDeviceInfo.Controls.Add(this.lblCatCaption);
            this.pnlDeviceInfo.Controls.Add(this.lblCategory);
            this.pnlDeviceInfo.Controls.Add(this.lblWearCaption);
            this.pnlDeviceInfo.Controls.Add(this.lblWear);

            // Все Y вычислены заранее:
            // lx=20, cx=170, cw=310, gap=38, y0=176
            // row0=176, row1=214, row2=252, row3=290, row4=328, btnY=400

            // ── Строка 0 (y=176): Тип работы
            this.lblWorkType.Text = "Тип работы:";
            this.lblWorkType.AutoSize = true;
            this.lblWorkType.Location = new System.Drawing.Point(20, 180);
            this.lblWorkType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblWorkType.Name = "lblWorkType";

            this.cmbWorkType.Location = new System.Drawing.Point(170, 176);
            this.cmbWorkType.Size = new System.Drawing.Size(310, 26);
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbWorkType.Name = "cmbWorkType";

            // ── Строка 1 (y=214): Исполнитель
            this.lblEmployee.Text = "Исполнитель:";
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(20, 218);
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblEmployee.Name = "lblEmployee";

            this.cmbEmployee.Location = new System.Drawing.Point(170, 214);
            this.cmbEmployee.Size = new System.Drawing.Size(310, 26);
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbEmployee.Name = "cmbEmployee";

            // ── Строка 2 (y=252): Дата работы
            this.lblDate.Text = "Дата работы:";
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 256);
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDate.Name = "lblDate";

            this.dtpWorkDate.Location = new System.Drawing.Point(170, 252);
            this.dtpWorkDate.Size = new System.Drawing.Size(200, 26);
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Name = "dtpWorkDate";

            // ── Строка 3 (y=290): Стоимость
            this.lblServicePrice.Text = "Стоимость (руб.):";
            this.lblServicePrice.AutoSize = true;
            this.lblServicePrice.Location = new System.Drawing.Point(20, 294);
            this.lblServicePrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblServicePrice.Name = "lblServicePrice";

            this.nudServicePrice.Location = new System.Drawing.Point(170, 290);
            this.nudServicePrice.Size = new System.Drawing.Size(160, 26);
            this.nudServicePrice.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudServicePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudServicePrice.DecimalPlaces = 2;
            this.nudServicePrice.ThousandsSeparator = true;
            this.nudServicePrice.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.nudServicePrice.Name = "nudServicePrice";

            // ── Строка 4 (y=328): Примечание
            this.lblNotes.Text = "Примечание:";
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 332);
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblNotes.Name = "lblNotes";

            this.txtNotes.Location = new System.Drawing.Point(170, 328);
            this.txtNotes.Size = new System.Drawing.Size(310, 62);
            this.txtNotes.Multiline = true;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtNotes.Name = "txtNotes";

            // ── Кнопки (y=402)
            this.btnSubmit.Text = "Зарегистрировать обслуживание";
            this.btnSubmit.Location = new System.Drawing.Point(170, 402);
            this.btnSubmit.Size = new System.Drawing.Size(230, 38);
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(410, 402);
            this.btnCancel.Size = new System.Drawing.Size(90, 38);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── Form
            this.ClientSize = new System.Drawing.Size(510, 458);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация обслуживания";
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Name = "MaintenanceForm";

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.nudServicePrice);
            this.Controls.Add(this.lblServicePrice);
            this.Controls.Add(this.dtpWorkDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbWorkType);
            this.Controls.Add(this.lblWorkType);
            this.Controls.Add(this.pnlDeviceInfo);
            this.Controls.Add(this.pnlHeader);

            this.Load += new System.EventHandler(this.MaintenanceForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.nudServicePrice)).EndInit();
            this.pnlDeviceInfo.ResumeLayout(false);
            this.pnlDeviceInfo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlDeviceInfo;
        private System.Windows.Forms.Label lblDevInfoTitle;
        private System.Windows.Forms.Label lblDNCaption;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblSNCaption;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblCatCaption;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblWearCaption;
        private System.Windows.Forms.Label lblWear;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblServicePrice;
        private System.Windows.Forms.NumericUpDown nudServicePrice;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}