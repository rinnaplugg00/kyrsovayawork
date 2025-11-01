namespace MovieCatalog.Forms
{
    partial class MovieCard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picPoster = new PictureBox();
            lblTitle = new Label();
            lblGenre = new Label();
            lblRating = new Label();
            lblStatus = new Label();
            lblDescription = new Label();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // picPoster
            // 
            picPoster.Location = new Point(10, 10);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(180, 207);
            picPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 220);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 20);
            lblTitle.TabIndex = 1;
            // 
            // lblGenre
            // 
            lblGenre.Location = new Point(10, 245);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(180, 20);
            lblGenre.TabIndex = 2;
            // 
            // lblRating
            // 
            lblRating.Location = new Point(10, 270);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(80, 20);
            lblRating.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(100, 270);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 20);
            lblStatus.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 8F);
            lblDescription.ForeColor = Color.LightGray;
            lblDescription.Location = new Point(10, 295);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(180, 50);
            lblDescription.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(10, 357);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 25);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;
            // 
            // MovieCard
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(picPoster);
            Controls.Add(lblTitle);
            Controls.Add(lblGenre);
            Controls.Add(lblRating);
            Controls.Add(lblStatus);
            Controls.Add(lblDescription);
            Controls.Add(btnEdit);
            ForeColor = Color.White;
            Name = "MovieCard";
            Size = new Size(200, 400);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }
    }
}
