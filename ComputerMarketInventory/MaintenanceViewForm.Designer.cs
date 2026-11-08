// =====================================================================
// ФАЙЛ: MaintenanceViewForm.Designer.cs  — ДИЗАЙН НОВОЙ ФОРМЫ
// =====================================================================
namespace ComputerMarketInventory
{
    partial class MaintenanceViewForm
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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblSearchLbl = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvMaintenance = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenance)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 66;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);

            this.lblTitle.Text = "📋 Журнал технического обслуживания";
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 8);

            this.lblSubtitle.Text = "Просмотр для мастеров по ремонту";
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(220, 190, 240);
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(16, 42);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ── pnlToolbar
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 48;
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(245, 240, 250);
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);

            this.lblSearchLbl.Text = "🔍 Поиск:";
            this.lblSearchLbl.AutoSize = true;
            this.lblSearchLbl.Location = new System.Drawing.Point(10, 16);
            this.lblSearchLbl.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSearch.Location = new System.Drawing.Point(75, 13);
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            //this.txtSearch.PlaceholderText = "Устройство, S/N, исполнитель, тип работы...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.btnRefresh.Text = "↻ Обновить";
            this.btnRefresh.Location = new System.Drawing.Point(390, 11);
            this.btnRefresh.Size = new System.Drawing.Size(110, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.lblCount.Text = "Записей: 0";
            this.lblCount.Location = new System.Drawing.Point(520, 16);
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Italic);

            this.btnClose.Text = "✕ Закрыть";
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(770, 11);
            this.btnClose.Size = new System.Drawing.Size(110, 28);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlToolbar.Controls.Add(this.lblSearchLbl);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.btnClose);

            // ── dgvMaintenance
            this.dgvMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaintenance.Name = "dgvMaintenance";

            // ── Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Text = "КомпьютерМаркет | Журнал обслуживания (для мастеров)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.Controls.Add(this.dgvMaintenance);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);

            this.Load += new System.EventHandler(this.MaintenanceViewForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenance)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader, pnlToolbar;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblSearchLbl, lblCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh, btnClose;
        private System.Windows.Forms.DataGridView dgvMaintenance;
    }
}