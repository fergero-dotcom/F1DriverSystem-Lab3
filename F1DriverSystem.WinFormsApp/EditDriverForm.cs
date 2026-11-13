using System;
using System.Windows.Forms;
using F1DriverSystem.Core;

namespace F1DriverSystem.WinFormsApp
{
    /// <summary>
    /// Диалоговая форма добавления и редактирования гонщика.
    /// </summary>
    public partial class EditDriverForm : Form
    {
        /// <summary>
        /// Введённое имя гонщика.
        /// </summary>
        public string DriverName { get; private set; }
        /// <summary>
        /// Введённое название команды.
        /// </summary>
        public string Team { get; private set; }
        /// <summary>
        /// Введённое количество очков.
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// Создаёт форму; при редактировании заполняет поля данными гонщика.
        /// </summary>
        /// <param name="driver">Гонщик для редактирования или null для добавления нового.</param>
        public EditDriverForm(Driver driver)
        {
            InitializeComponent();
            cmbTeamUnused.Visible = false;
            label3.Visible = false;
            if (driver != null)
            {
                txtName.Text = driver.Name;
                txtTeam.Text = driver.Team;
                txtPoints.Text = driver.Points.ToString();
            }
        }

        /// <summary>
        /// Обработчик кнопки сохранения: проверяет введённые данные и закрывает форму.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int points;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Введите имя гонщика."); return; }
            if (string.IsNullOrWhiteSpace(txtTeam.Text))
            { MessageBox.Show("Введите команду."); return; }
            if (!int.TryParse(txtPoints.Text, out points) || points < 0)
            { MessageBox.Show("Очки должны быть целым неотрицательным числом."); return; }
            DriverName = txtName.Text.Trim();
            Team = txtTeam.Text.Trim();
            Points = points;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик кнопки отмены: закрывает форму без сохранения.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
