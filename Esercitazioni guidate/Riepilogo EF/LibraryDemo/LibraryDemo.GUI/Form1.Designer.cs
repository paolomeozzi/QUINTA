namespace LibraryDemo.GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBar = new System.Windows.Forms.Panel();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnLoadCatalog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboAll = new System.Windows.Forms.RadioButton();
            this.rboOnlyAvailable = new System.Windows.Forms.RadioButton();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.statBar = new System.Windows.Forms.StatusStrip();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnNewGenre = new System.Windows.Forms.Button();
            this.lstAuthors = new System.Windows.Forms.ListBox();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.dvCatalog = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvCatalog)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBar
            // 
            this.pnlBar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlBar.Controls.Add(this.btnLoan);
            this.pnlBar.Controls.Add(this.btnLoadCatalog);
            this.pnlBar.Controls.Add(this.groupBox1);
            this.pnlBar.Controls.Add(this.txtTag);
            this.pnlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBar.Location = new System.Drawing.Point(0, 0);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(825, 53);
            this.pnlBar.TabIndex = 0;
            // 
            // btnLoan
            // 
            this.btnLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.Location = new System.Drawing.Point(684, 6);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(133, 41);
            this.btnLoan.TabIndex = 3;
            this.btnLoan.Text = "Presta";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnLoadCatalog
            // 
            this.btnLoadCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCatalog.Location = new System.Drawing.Point(534, 7);
            this.btnLoadCatalog.Name = "btnLoadCatalog";
            this.btnLoadCatalog.Size = new System.Drawing.Size(133, 41);
            this.btnLoadCatalog.TabIndex = 2;
            this.btnLoadCatalog.Text = "Visualizza";
            this.btnLoadCatalog.UseVisualStyleBackColor = true;
            this.btnLoadCatalog.Click += new System.EventHandler(this.btnLoadCatalog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboAll);
            this.groupBox1.Controls.Add(this.rboOnlyAvailable);
            this.groupBox1.Location = new System.Drawing.Point(301, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rboAll
            // 
            this.rboAll.AutoSize = true;
            this.rboAll.Checked = true;
            this.rboAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAll.Location = new System.Drawing.Point(118, 18);
            this.rboAll.Name = "rboAll";
            this.rboAll.Size = new System.Drawing.Size(51, 20);
            this.rboAll.TabIndex = 0;
            this.rboAll.TabStop = true;
            this.rboAll.Text = "Tutti";
            this.rboAll.UseVisualStyleBackColor = true;
            // 
            // rboOnlyAvailable
            // 
            this.rboOnlyAvailable.AutoSize = true;
            this.rboOnlyAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboOnlyAvailable.Location = new System.Drawing.Point(7, 20);
            this.rboOnlyAvailable.Name = "rboOnlyAvailable";
            this.rboOnlyAvailable.Size = new System.Drawing.Size(86, 20);
            this.rboOnlyAvailable.TabIndex = 0;
            this.rboOnlyAvailable.Text = "Solo disp.";
            this.rboOnlyAvailable.UseVisualStyleBackColor = true;
            // 
            // txtTag
            // 
            this.txtTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTag.Location = new System.Drawing.Point(3, 12);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(270, 29);
            this.txtTag.TabIndex = 0;
            // 
            // statBar
            // 
            this.statBar.Location = new System.Drawing.Point(0, 388);
            this.statBar.Name = "statBar";
            this.statBar.Size = new System.Drawing.Size(825, 22);
            this.statBar.TabIndex = 1;
            this.statBar.Text = "statusStrip1";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnNewGenre);
            this.pnlContent.Controls.Add(this.lstAuthors);
            this.pnlContent.Controls.Add(this.lstGenres);
            this.pnlContent.Controls.Add(this.dvCatalog);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 53);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(825, 335);
            this.pnlContent.TabIndex = 2;
            // 
            // btnNewGenre
            // 
            this.btnNewGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGenre.Location = new System.Drawing.Point(534, 286);
            this.btnNewGenre.Name = "btnNewGenre";
            this.btnNewGenre.Size = new System.Drawing.Size(133, 41);
            this.btnNewGenre.TabIndex = 4;
            this.btnNewGenre.Text = "Nuovo";
            this.btnNewGenre.UseVisualStyleBackColor = true;
            this.btnNewGenre.Click += new System.EventHandler(this.btnNewGenre_Click);
            // 
            // lstAuthors
            // 
            this.lstAuthors.DisplayMember = "Name";
            this.lstAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAuthors.FormattingEnabled = true;
            this.lstAuthors.ItemHeight = 16;
            this.lstAuthors.Location = new System.Drawing.Point(684, 3);
            this.lstAuthors.Name = "lstAuthors";
            this.lstAuthors.Size = new System.Drawing.Size(133, 324);
            this.lstAuthors.TabIndex = 1;
            this.lstAuthors.DoubleClick += new System.EventHandler(this.lstAuthors_DoubleClick);
            // 
            // lstGenres
            // 
            this.lstGenres.DisplayMember = "Name";
            this.lstGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.ItemHeight = 16;
            this.lstGenres.Location = new System.Drawing.Point(534, 4);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(133, 276);
            this.lstGenres.TabIndex = 1;
            // 
            // dvCatalog
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCatalog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.PublicationDate,
            this.GenreName,
            this.AvailableCount});
            this.dvCatalog.Location = new System.Drawing.Point(3, 3);
            this.dvCatalog.Name = "dvCatalog";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvCatalog.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dvCatalog.Size = new System.Drawing.Size(525, 325);
            this.dvCatalog.TabIndex = 0;
            this.dvCatalog.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvCatalog_RowHeaderMouseDoubleClick);
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Titolo";
            this.Title.Name = "Title";
            this.Title.Width = 200;
            // 
            // PublicationDate
            // 
            this.PublicationDate.DataPropertyName = "PublicationDate";
            this.PublicationDate.HeaderText = "Data";
            this.PublicationDate.Name = "PublicationDate";
            // 
            // GenreName
            // 
            this.GenreName.DataPropertyName = "GenreName";
            this.GenreName.HeaderText = "Genere";
            this.GenreName.Name = "GenreName";
            // 
            // AvailableCount
            // 
            this.AvailableCount.DataPropertyName = "AvailableCount";
            this.AvailableCount.HeaderText = "Disp.";
            this.AvailableCount.Name = "AvailableCount";
            this.AvailableCount.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 410);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.statBar);
            this.Controls.Add(this.pnlBar);
            this.Name = "Form1";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlBar.ResumeLayout(false);
            this.pnlBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvCatalog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.StatusStrip statBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dvCatalog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableCount;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.ListBox lstAuthors;
        private System.Windows.Forms.Button btnLoadCatalog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboAll;
        private System.Windows.Forms.RadioButton rboOnlyAvailable;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnNewGenre;
    }
}

