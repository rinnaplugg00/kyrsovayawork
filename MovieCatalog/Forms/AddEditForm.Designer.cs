namespace MovieCatalog.Forms
{
    partial class AddEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblGenre;
        private CheckedListBox clbGenre; // заменили ComboBox на CheckedListBox
        private Label lblRating;
        private NumericUpDown numRating;
        private Label lblYear;
        private NumericUpDown numYear;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblDescription;
        private TextBox txtDescription;
        private PictureBox picPoster;
        private Button btnChoosePoster;
        private Button btnSave;
        private CheckBox chkIsSeries;
        private Label lblEpisodes;
        private NumericUpDown numCurrentEpisode;
        private NumericUpDown numTotalEpisodes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblGenre = new Label();
            this.clbGenre = new CheckedListBox();
            this.lblRating = new Label();
            this.numRating = new NumericUpDown();
            this.lblYear = new Label();
            this.numYear = new NumericUpDown();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.picPoster = new PictureBox();
            this.btnChoosePoster = new Button();
            this.btnSave = new Button();
            this.chkIsSeries = new CheckBox();
            this.lblEpisodes = new Label();
            this.numCurrentEpisode = new NumericUpDown();
            this.numTotalEpisodes = new NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalEpisodes)).BeginInit();
            this.SuspendLayout();

            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color labelColor = Color.White;
            Color boxColor = Color.FromArgb(50, 50, 50);

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Text = "Добавить / Редактировать фильм";
            this.ClientSize = new System.Drawing.Size(900, 600);

            // --- Постер ---
            picPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            picPoster.BorderStyle = BorderStyle.FixedSingle;
            picPoster.BackColor = Color.Gray;
            picPoster.Location = new Point(650, 20);
            picPoster.Size = new Size(200, 300);
            picPoster.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnChoosePoster.Text = "Выбрать постер";
            btnChoosePoster.BackColor = Color.FromArgb(80, 80, 80);
            btnChoosePoster.ForeColor = labelColor;
            btnChoosePoster.FlatStyle = FlatStyle.Flat;
            btnChoosePoster.Size = new Size(200, 35);
            btnChoosePoster.Location = new Point(650, 330);
            btnChoosePoster.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChoosePoster.Click += new EventHandler(this.btnChoosePoster_Click);

            // --- Левые поля ---
            int leftX = 20;
            int labelWidth = 100;
            int inputX = 130;
            int inputWidth = 500;

            lblTitle.Text = "Название:";
            lblTitle.Location = new Point(leftX, 20);
            lblTitle.Size = new Size(labelWidth, 25);
            lblTitle.ForeColor = labelColor;
            lblTitle.Font = labelFont;

            txtTitle.Location = new Point(inputX, 20);
            txtTitle.Size = new Size(inputWidth, 25);
            txtTitle.BackColor = boxColor; txtTitle.ForeColor = labelColor;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblGenre.Text = "Жанры:";
            lblGenre.Location = new Point(leftX, 60);
            lblGenre.Size = new Size(labelWidth, 25);
            lblGenre.ForeColor = labelColor; lblGenre.Font = labelFont;

            clbGenre.Location = new Point(inputX, 60);
            clbGenre.Size = new Size(inputWidth, 100);
            clbGenre.BackColor = boxColor; clbGenre.ForeColor = labelColor;
            clbGenre.CheckOnClick = true;
            clbGenre.Items.AddRange(new object[]
            {
                "Боевик", "Комедия", "Драма", "Фантастика", "Аниме", "Мультфильм",
                "Ужасы", "Триллер", "Документальный", "Приключения", "Мюзикл",
                "Исторический", "Семейный"
            });
            clbGenre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblRating.Text = "Рейтинг:";
            lblRating.Location = new Point(leftX, 180);
            lblRating.Size = new Size(labelWidth, 25);
            lblRating.ForeColor = labelColor; lblRating.Font = labelFont;

            numRating.Location = new Point(inputX, 180);
            numRating.Size = new Size(100, 25);
            numRating.Minimum = 0;
            numRating.Maximum = 10;
            numRating.DecimalPlaces = 1;
            numRating.Increment = 0.1M;
            numRating.BackColor = boxColor;
            numRating.ForeColor = labelColor;

            lblYear.Text = "Год:";
            lblYear.Location = new Point(inputX + 120, 180);
            lblYear.Size = new Size(50, 25);
            lblYear.ForeColor = labelColor; lblYear.Font = labelFont;

            numYear.Location = new Point(inputX + 180, 180);
            numYear.Size = new Size(70, 25);
            numYear.Minimum = 1800;
            numYear.Maximum = DateTime.Now.Year;
            numYear.BackColor = boxColor;
            numYear.ForeColor = labelColor;

            // --- CheckBox "Сериал" ---
            chkIsSeries.Text = "Сериал / мультфильм с сериями";
            chkIsSeries.Location = new Point(leftX, 220);
            chkIsSeries.ForeColor = labelColor;
            chkIsSeries.AutoSize = true;
            chkIsSeries.CheckedChanged += new EventHandler(this.chkIsSeries_CheckedChanged);

            // --- Прогресс серий ---
            lblEpisodes.Text = "Прогресс серий:";
            lblEpisodes.Location = new Point(leftX, 250);
            lblEpisodes.Size = new Size(110, 25);
            lblEpisodes.ForeColor = labelColor;

            numCurrentEpisode.Location = new Point(inputX, 250);
            numCurrentEpisode.Width = 50;
            numCurrentEpisode.Minimum = 0;
            numCurrentEpisode.Maximum = 1000;
            numCurrentEpisode.Enabled = false;
            numCurrentEpisode.BackColor = boxColor;
            numCurrentEpisode.ForeColor = labelColor;

            numTotalEpisodes.Location = new Point(inputX + 60, 250);
            numTotalEpisodes.Width = 50;
            numTotalEpisodes.Minimum = 1;
            numTotalEpisodes.Maximum = 1000;
            numTotalEpisodes.Enabled = false;
            numTotalEpisodes.BackColor = boxColor;
            numTotalEpisodes.ForeColor = labelColor;

            lblStatus.Text = "Статус:";
            lblStatus.Location = new Point(leftX, 290);
            lblStatus.Size = new Size(labelWidth, 25);
            lblStatus.ForeColor = labelColor; lblStatus.Font = labelFont;

            cmbStatus.Location = new Point(inputX, 290);
            cmbStatus.Size = new Size(inputWidth, 25);
            cmbStatus.BackColor = boxColor; cmbStatus.ForeColor = labelColor;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Смотрю", "Хочу посмотреть", "Просмотрено" });
            cmbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblDescription.Text = "Описание:";
            lblDescription.Location = new Point(leftX, 330);
            lblDescription.Size = new Size(labelWidth, 25);
            lblDescription.ForeColor = labelColor; lblDescription.Font = labelFont;

            txtDescription.Location = new Point(inputX, 330);
            txtDescription.Size = new Size(inputWidth, 200);
            txtDescription.BackColor = boxColor; txtDescription.ForeColor = labelColor;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            btnSave.Text = "Сохранить";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.ForeColor = labelColor;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Size = new Size(150, 35);
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(this.ClientSize.Width - btnSave.Width - 20, this.ClientSize.Height - btnSave.Height - 20);
            btnSave.Click += new EventHandler(this.btnSave_Click);

            this.Controls.AddRange(new Control[]
            {
                lblTitle, txtTitle, lblGenre, clbGenre, lblRating, numRating,
                lblYear, numYear, chkIsSeries, lblEpisodes, numCurrentEpisode, numTotalEpisodes,
                lblStatus, cmbStatus, lblDescription, txtDescription,
                picPoster, btnChoosePoster, btnSave
            });

            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalEpisodes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
