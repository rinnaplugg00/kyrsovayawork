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
        private ComboBox cmbSort;
        private Label lblSort;
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
            components = new System.ComponentModel.Container();

            txtSearch = new TextBox();
            btnAdd = new Button();
            btnRefresh = new Button();
            buttonTop = new Button();
            cmbFilterGenre = new ComboBox();
            cmbFilterStatus = new ComboBox();
            cmbSort = new ComboBox();
            lblSort = new Label();
            flowMovies = new FlowLayoutPanel();
            lblFilterGenre = new Label();
            lblFilterStatus = new Label();

            SuspendLayout();

            // --- Общие цвета и шрифты ---
            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color labelColor = Color.White;
            Color boxColor = Color.FromArgb(60, 60, 60);

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(1200, 700);
            this.Text = "Каталог фильмов и сериалов";

            // --- Поиск ---
            txtSearch.BackColor = boxColor;
            txtSearch.ForeColor = labelColor;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.PlaceholderText = "Поиск фильма...";
            txtSearch.Location = new Point(20, 20);
            txtSearch.Size = new Size(300, 27);
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // --- Кнопки ---
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
            buttonTop.Text = "Наверх";
            buttonTop.Size = new Size(80, 30);
            buttonTop.BackColor = Color.FromArgb(0, 122, 204);
            buttonTop.ForeColor = Color.White;
            buttonTop.FlatStyle = FlatStyle.Flat;
            buttonTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTop.Click += (s, e) =>
            {
                flowMovies.VerticalScroll.Value = 0;
            };

            // --- Фильтры ---
            lblFilterGenre.Text = "Жанр:";
            lblFilterGenre.ForeColor = labelColor;
            lblFilterGenre.Font = labelFont;
            lblFilterGenre.AutoSize = true;
            lblFilterGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            cmbFilterGenre.BackColor = boxColor;
            cmbFilterGenre.ForeColor = labelColor;
            cmbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGenre.Items.AddRange(new object[]
            {
                "Все", "Боевик", "Комедия", "Драма", "Фантастика", "Аниме", "Мультфильм",
                "Ужасы", "Триллер", "Документальный", "Приключения", "Мюзикл",
                "Исторический", "Семейный"
            });
            cmbFilterGenre.Size = new Size(150, 28);
            cmbFilterGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblFilterStatus.Text = "Статус:";
            lblFilterStatus.ForeColor = labelColor;
            lblFilterStatus.Font = labelFont;
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            cmbFilterStatus.BackColor = boxColor;
            cmbFilterStatus.ForeColor = labelColor;
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Items.AddRange(new object[] { "Все", "Смотрю", "Хочу посмотреть", "Просмотрено" });
            cmbFilterStatus.Size = new Size(150, 28);
            cmbFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // --- Сортировка ---
            lblSort.Text = "Сортировка:";
            lblSort.ForeColor = labelColor;
            lblSort.Font = labelFont;
            lblSort.AutoSize = true; 
            lblSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            cmbSort.BackColor = boxColor;
            cmbSort.ForeColor = labelColor;
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Items.AddRange(new object[] { "Без сортировки", "Название", "Рейтинг", "Год" });
            cmbSort.SelectedIndex = 0;
            cmbSort.Size = new Size(150, 28);
            cmbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbSort.SelectedIndexChanged += FilterChanged;

            // --- FlowLayoutPanel ---
            flowMovies.BackColor = Color.FromArgb(45, 45, 48);
            flowMovies.Location = new Point(20, 60);
            flowMovies.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 80);
            flowMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowMovies.AutoScroll = true;

            // --- Расстановка элементов справа ---
            int rightMargin = 20;
            btnRefresh.Location = new Point(this.ClientSize.Width - btnRefresh.Width - rightMargin, 20);
            btnAdd.Location = new Point(btnRefresh.Left - btnAdd.Width - 10, 20);

            cmbFilterStatus.Location = new Point(btnAdd.Left - cmbFilterStatus.Width - 20, 20);
            lblFilterStatus.Location = new Point(cmbFilterStatus.Left - lblFilterStatus.Width - 5, 20);
            cmbFilterGenre.Location = new Point(lblFilterStatus.Left - cmbFilterGenre.Width - 10, 20);
            lblFilterGenre.Location = new Point(cmbFilterGenre.Left - lblFilterGenre.Width - 5, 20);

            cmbSort.Location = new Point(lblFilterGenre.Left - cmbSort.Width - 20, 20);
            lblSort.Location = new Point(cmbSort.Left - lblSort.Width - 10, 20);

            buttonTop.Location = new Point(this.ClientSize.Width - buttonTop.Width - 20, this.ClientSize.Height - 50);

            // --- Добавление на форму ---
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(lblFilterGenre);
            this.Controls.Add(cmbFilterGenre);
            this.Controls.Add(lblFilterStatus);
            this.Controls.Add(cmbFilterStatus);
            this.Controls.Add(lblSort);
            this.Controls.Add(cmbSort);
            this.Controls.Add(flowMovies);
            this.Controls.Add(buttonTop);

            // --- Обработчик ресайза ---
            this.Resize += MainForm_Resize;

            ResumeLayout(false);
            PerformLayout();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            int rightMargin = 20;

            // Кнопки справа
            btnRefresh.Left = this.ClientSize.Width - btnRefresh.Width - rightMargin;
            btnAdd.Left = btnRefresh.Left - btnAdd.Width - 10;

            // Фильтры справа
            cmbFilterStatus.Left = btnAdd.Left - cmbFilterStatus.Width - 20;
            lblFilterStatus.Left = cmbFilterStatus.Left - lblFilterStatus.Width - 5;
            cmbFilterGenre.Left = lblFilterStatus.Left - cmbFilterGenre.Width - 10;
            lblFilterGenre.Left = cmbFilterGenre.Left - lblFilterGenre.Width - 5;

            // Сортировка слева от фильтров
            cmbSort.Left = lblFilterGenre.Left - cmbSort.Width - 20;
            lblSort.Left = cmbSort.Left - lblSort.Width - 10;

            // FlowLayoutPanel
            flowMovies.Width = this.ClientSize.Width - 40;
            flowMovies.Height = this.ClientSize.Height - 80;

            // Кнопка "Наверх"
            buttonTop.Left = this.ClientSize.Width - buttonTop.Width - 20;
            buttonTop.Top = this.ClientSize.Height - 50;
        }
    }
}
