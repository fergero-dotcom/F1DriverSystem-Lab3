namespace F1DriverSystem.WinFormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewDrivers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnCalculateAvg = new System.Windows.Forms.Button();
            this.lblAvgPoints = new System.Windows.Forms.Label();
            this.cmbFilterTeam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).BeginInit();
            this.SuspendLayout();

            this.dataGridViewDrivers.Name = "dataGridViewDrivers";
            this.dataGridViewDrivers.Location = new System.Drawing.Point(12, 54);
            this.dataGridViewDrivers.Size = new System.Drawing.Size(860, 370);
            this.dataGridViewDrivers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridViewDrivers.AllowUserToAddRows = false;
            this.dataGridViewDrivers.AllowUserToDeleteRows = false;
            this.dataGridViewDrivers.ReadOnly = true;
            this.dataGridViewDrivers.MultiSelect = false;
            this.dataGridViewDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDrivers.TabIndex = 3;

            this.cmbFilterTeam.Name = "cmbFilterTeam";
            this.cmbFilterTeam.Location = new System.Drawing.Point(12, 16);
            this.cmbFilterTeam.Size = new System.Drawing.Size(260, 21);
            this.cmbFilterTeam.FormattingEnabled = true;
            this.cmbFilterTeam.TabIndex = 0;

            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Text = "Фильтр по команде";
            this.btnFilter.Location = new System.Drawing.Point(284, 12);
            this.btnFilter.Size = new System.Drawing.Size(150, 30);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Text = "Сбросить фильтр";
            this.btnResetFilter.Location = new System.Drawing.Point(446, 12);
            this.btnResetFilter.Size = new System.Drawing.Size(150, 30);
            this.btnResetFilter.TabIndex = 2;
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);

            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(12, 438);
            this.btnAdd.Size = new System.Drawing.Size(120, 32);
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "Изменить";
            this.btnEdit.Location = new System.Drawing.Point(144, 438);
            this.btnEdit.Size = new System.Drawing.Size(120, 32);
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnEdit.TabIndex = 5;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(276, 438);
            this.btnDelete.Size = new System.Drawing.Size(120, 32);
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnCalculateAvg.Name = "btnCalculateAvg";
            this.btnCalculateAvg.Text = "Рассчитать среднее";
            this.btnCalculateAvg.Location = new System.Drawing.Point(408, 438);
            this.btnCalculateAvg.Size = new System.Drawing.Size(180, 32);
            this.btnCalculateAvg.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnCalculateAvg.TabIndex = 7;
            this.btnCalculateAvg.UseVisualStyleBackColor = true;
            this.btnCalculateAvg.Click += new System.EventHandler(this.btnCalculateAvg_Click);

            this.lblAvgPoints.Name = "lblAvgPoints";
            this.lblAvgPoints.Text = "Среднее количество очков: —";
            this.lblAvgPoints.Location = new System.Drawing.Point(12, 486);
            this.lblAvgPoints.AutoSize = true;
            this.lblAvgPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblAvgPoints.TabIndex = 8;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 521);
            this.MinimumSize = new System.Drawing.Size(660, 360);
            this.Name = "MainForm";
            this.Text = "Система учёта гонщиков Формулы-1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dataGridViewDrivers);
            this.Controls.Add(this.cmbFilterTeam);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCalculateAvg);
            this.Controls.Add(this.lblAvgPoints);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewDrivers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnCalculateAvg;
        private System.Windows.Forms.Label lblAvgPoints;
        private System.Windows.Forms.ComboBox cmbFilterTeam;
    }
}
