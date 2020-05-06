using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDemo.GUI
{
    using Core;
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        public BookForm(Book book)
        {
            InitializeComponent();
            Book = book;
        }

        static List<BookForm> openForms = new List<BookForm>();
        public static void Show(Book book)
        {
            var bf = openForms.Find(f => f.Book.BookId == book.BookId);
            if (bf == null)
            {
                bf = new BookForm(book);
                bf.FormClosed += Bf_FormClosed;
                bf.Show();
                openForms.Add(bf);
            }
            bf.BringToFront();
        }

        private static void Bf_FormClosed(object sender, FormClosedEventArgs e)
        {
            var bf = sender as BookForm;
            openForms.Remove(bf);
        }

        public Book Book {get;}

        private void BookForm_Load(object sender, EventArgs e)
        {
            picCover.Image = ImageCache.Get(Book.CoverFileName);
            lblTitle.Text = Book.Title;
            lblGenre.Text = Book.GenreName;
            lblDate.Text = Book.PublicationDate != null ? $"{Book.PublicationDate:d}": "N.D";
            
            foreach (var au in Book.Authors)
            {
                Label lblAuthor = new Label();
                lblAuthor.Width = pnlAuthors.Width;
                lblAuthor.Font = new System.Drawing.Font("Arial", 10);
                lblAuthor.ForeColor = Color.DarkBlue;
                lblAuthor.Cursor = Cursors.Hand;
                lblAuthor.AutoSize = false;
                lblAuthor.Text = au.FullName;
                lblAuthor.Tag = au;
                pnlAuthors.Controls.Add(lblAuthor);
                lblAuthor.Click += lblAuthor_Click;
            }
        }

        void lblAuthor_Click(object sender, EventArgs e)
        {
            Author author = ((Label)(sender)).Tag as Author;
            AuthorForm.Show(author);
        }
    }
}
