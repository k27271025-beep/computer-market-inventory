// =====================================================================
// ФАЙЛ: MainForm.Designer.cs
// ИСПРАВЛЕНО: убраны лямбды — Designer их не поддерживает
// =====================================================================
namespace ComputerMarketInventory
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnService = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnMaintenanceView = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // ── statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel1 });
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);

            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Text = "КомпьютерМаркет | Готов к работе";
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;

            // ── pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 54;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);

            this.lblSearch.Text = "Поиск по S/N или Названию:";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(8, 18);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSearch.Location = new System.Drawing.Point(200, 14);
            this.txtSearch.Size = new System.Drawing.Size(320, 23);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblCategory.Text = "Категория:";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(540, 18);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.cmbCategoryFilter.Location = new System.Drawing.Point(620, 14);
            this.cmbCategoryFilter.Size = new System.Drawing.Size(220, 23);
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblCategory);
            this.pnlTop.Controls.Add(this.cmbCategoryFilter);

            // ── pnlRight
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Width = 185;
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);

            // btnAdd
            this.btnAdd.Text = "[++] Добавить";
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Size = new System.Drawing.Size(163, 44);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Location = new System.Drawing.Point(10, 65);
            this.btnEdit.Size = new System.Drawing.Size(163, 44);
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnService
            this.btnService.Text = "Обслуживание";
            this.btnService.Location = new System.Drawing.Point(10, 120);
            this.btnService.Size = new System.Drawing.Size(163, 44);
            this.btnService.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnService.ForeColor = System.Drawing.Color.White;
            this.btnService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnService.FlatAppearance.BorderSize = 0;
            this.btnService.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);

            // btnMaintenanceView
            this.btnMaintenanceView.Text = "Журнал мастеров";
            this.btnMaintenanceView.Location = new System.Drawing.Point(10, 175);
            this.btnMaintenanceView.Size = new System.Drawing.Size(163, 44);
            this.btnMaintenanceView.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnMaintenanceView.ForeColor = System.Drawing.Color.White;
            this.btnMaintenanceView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenanceView.FlatAppearance.BorderSize = 0;
            this.btnMaintenanceView.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnMaintenanceView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenanceView.Click += new System.EventHandler(this.btnMaintenanceView_Click);

            // btnDiscount
            this.btnDiscount.Text = "Оформить УЦЕНКУ";
            this.btnDiscount.Location = new System.Drawing.Point(10, 250);
            this.btnDiscount.Size = new System.Drawing.Size(163, 44);
            this.btnDiscount.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);

            this.pnlRight.Controls.Add(this.btnAdd);
            this.pnlRight.Controls.Add(this.btnEdit);
            this.pnlRight.Controls.Add(this.btnService);
            this.pnlRight.Controls.Add(this.btnMaintenanceView);
            this.pnlRight.Controls.Add(this.btnDiscount);

            // ── dgvEquipment
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipment.Name = "dgvEquipment";

            // ── MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 560);
            this.MinimumSize = new System.Drawing.Size(900, 480);
            this.Text = "[КомпьютерМаркет] Мониторинг демонстрационного оборудования";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.Controls.Add(this.dgvEquipment);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip1);

            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvEquipment;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnMaintenanceView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTop;
    }
}