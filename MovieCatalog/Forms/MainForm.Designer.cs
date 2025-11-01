namespace MovieCatalog.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnRefresh;
        private Button buttonTop;
        private ComboBox cmbFilterGenre;
        private ComboBox cmbFilterStatus;
        private FlowLayoutPanel flowMovies;
        private Label lblFilterGenre;
        private Label lblFilterStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnRefresh = new Button();
            cmbFilterGenre = new ComboBox();
            cmbFilterStatus = new ComboBox();
            flowMovies = new FlowLayoutPanel();
            lblFilterGenre = new Label();
            lblFilterStatus = new Label();

            SuspendLayout();

            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color labelColor = Color.White;
            Color boxColor = Color.FromArgb(60, 60, 60);

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(1200, 700);
            this.Text = "Каталог фильмов и сериалов";

            // --- Поиск (фиксированное место слева) ---
            txtSearch.BackColor = boxColor;
            txtSearch.ForeColor = labelColor;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.PlaceholderText = "Поиск фильма...";
            txtSearch.Location = new Point(20, 20);
            txtSearch.Size = new Size(300, 27);
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // --- Кнопки (правый верхний угол) ---
            btnAdd.BackColor = Color.FromArgb(0, 122, 204);
            btnAdd.ForeColor = labelColor;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Size = new Size(120, 33);
            btnAdd.Text = "Добавить";
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Click += btnAdd_Click;

            btnRefresh.BackColor = Color.FromArgb(80, 80, 80);
            btnRefresh.ForeColor = labelColor;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Size = new Size(120, 33);
            btnRefresh.Text = "Обновить";
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Click += btnRefresh_Click;

            // --- Кнопка Наверх ---
            buttonTop = new Button();
            buttonTop.Text = "Наверх";
            buttonTop.Size = new Size(80, 30);
            buttonTop.BackColor = Color.FromArgb(0, 122, 204);
            buttonTop.ForeColor = Color.White;
            buttonTop.FlatStyle = FlatStyle.Flat;
            buttonTop.Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 50);
            buttonTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTop.Click += (s, e) => flowMovies.VerticalScroll.Value = 0;

            this.Controls.Add(buttonTop);


            // Кнопки справа
            int rightMargin = 20;
            btnRefresh.Location = new Point(this.ClientSize.Width - btnRefresh.Width - rightMargin, 20);
            btnAdd.Location = new Point(btnRefresh.Left - btnAdd.Width - 10, 20);

            // --- Фильтры (правее кнопок) ---
            lblFilterGenre.Text = "Жанр:";
            lblFilterGenre.ForeColor = labelColor;
            lblFilterGenre.Font = labelFont;
            lblFilterGenre.Size = new Size(50, 25);
            lblFilterGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            cmbFilterGenre.BackColor = boxColor;
            cmbFilterGenre.ForeColor = labelColor;
            cmbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGenre.Items.AddRange(new object[] { "Все", "Боевик", "Комедия", "Драма", "Фантастика", "Аниме", "Мультфильм",
                "Ужасы", "Триллер", "Документальный", "Приключения", "Мюзикл",
                "Исторический", "Семейный" });
            cmbFilterGenre.Size = new Size(150, 28);
            cmbFilterGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblFilterStatus.Text = "Статус:";
            lblFilterStatus.ForeColor = labelColor;
            lblFilterStatus.Font = labelFont;
            lblFilterStatus.Size = new Size(60, 25);
            lblFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            cmbFilterStatus.BackColor = boxColor;
            cmbFilterStatus.ForeColor = labelColor;
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Items.AddRange(new object[] { "Все", "Смотрю", "Хочу посмотреть", "Просмотрено" });
            cmbFilterStatus.Size = new Size(150, 28);
            cmbFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Расположение фильтров справа (отдельная группа)
            int filterRightMargin = 20;
            cmbFilterStatus.Location = new Point(btnAdd.Left - cmbFilterStatus.Width - 20, 20);
            lblFilterStatus.Location = new Point(cmbFilterStatus.Left - lblFilterStatus.Width - 5, 20);
            cmbFilterGenre.Location = new Point(lblFilterStatus.Left - cmbFilterGenre.Width - 10, 20);
            lblFilterGenre.Location = new Point(cmbFilterGenre.Left - lblFilterGenre.Width - 5, 20);

            // --- FlowLayoutPanel ---
            flowMovies.BackColor = Color.FromArgb(45, 45, 48);
            flowMovies.Location = new Point(20, 60);
            flowMovies.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 80);
            flowMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowMovies.AutoScroll = true;

            // --- Добавляем на форму ---
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(lblFilterGenre);
            this.Controls.Add(cmbFilterGenre);
            this.Controls.Add(lblFilterStatus);
            this.Controls.Add(cmbFilterStatus);
            this.Controls.Add(flowMovies);

            ResumeLayout(false);
            PerformLayout();

            // --- Обработчик ресайза ---
            this.Resize += MainForm_Resize;
        }

        // --- Метод для перерасчета кнопок и фильтров при изменении формы ---
        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Кнопки справа
            int rightMargin = 20;
            btnRefresh.Left = this.ClientSize.Width - btnRefresh.Width - rightMargin;
            btnAdd.Left = btnRefresh.Left - btnAdd.Width - 10;

            // Фильтры справа
            cmbFilterStatus.Left = btnAdd.Left - cmbFilterStatus.Width - 20;
            lblFilterStatus.Left = cmbFilterStatus.Left - lblFilterStatus.Width - 5;
            cmbFilterGenre.Left = lblFilterStatus.Left - cmbFilterGenre.Width - 10;
            lblFilterGenre.Left = cmbFilterGenre.Left - lblFilterGenre.Width - 5;

            // FlowLayoutPanel
            flowMovies.Width = this.ClientSize.Width - 40;
            flowMovies.Height = this.ClientSize.Height - 80;
        }

    }
}
