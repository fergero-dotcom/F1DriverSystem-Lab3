namespace F1DriverSystem.WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Контейнер компонентов формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает используемые формой ресурсы.
        /// </summary>
        /// <param name="disposing">true, если необходимо освободить управляемые ресурсы.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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