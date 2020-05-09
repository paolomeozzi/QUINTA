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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Library db = new Library();

        private void Form1_Load(object sender, EventArgs e)
        {
            lstGenres.DisplayMember = "Name";
            lstGenres.ValueMember = "GenreId";

            lstAuthors.DisplayMember = "FullName";
            lstAuthors.ValueMember = "AuthorId";

            dvCatalog.AutoGenerateColumns = false;

            ShowGenres();
            ShowAuthors();
            ShowCatalog();  //!per ultimo
        }
        private void btnLoadCatalog_Click(object sender, EventArgs e)
        {
            ShowCatalog();
        }

        // visualizza dettagli libro: l'utente ha eseguito un doppio click sulla riga del datagridview
        private void dvCatalog_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var book = SelectedBook();
            if (book == null)
                return;
            BookForm.Show(book);
        }

        private void lstAuthors_DoubleClick(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedIndex < 1)
                return;
            var author = lstAuthors.SelectedItem as Author;
            AuthorForm.Show(author);
        }

        // inserimento di un nuovo genere
        private void btnNewGenre_Click(object sender, EventArgs e)
        {
            var gf = new NewGenreForm();
            var dr = gf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var genre = new Genre { Name = gf.GenreName };
                CreateGenre(genre);
            }
            gf.Dispose();
        }

        // prestito di un libro (solo se è stato selezionato)
        private void btnLoan_Click(object sender, EventArgs e)
        {
            var book = SelectedBook();
            if (book == null)
                return;

            //!qui sarebbe oppurtuno verificare se la disponibilità è > 0
            // (inutile esegure un'operazione destinata a fallire)

            var lf = new BookLoanForm(book, db.Affiliateds);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                LoanBook(book, lf.Affiliated);
                ShowCatalog();

            }
            lf.Dispose();                
        }


        #region METODI CHE ESEGUONO LE VARIE FUNZIONI
        private void ShowCatalog()
        {
            //ACCEDE DIRETTAMENTE AL VALORE DELLE CHIAVI
            var genreId = (int)lstGenres.SelectedValue;
            var authorId = (int)lstAuthors.SelectedValue;

            AvailableCriteria ac = rboAll.Checked ? AvailableCriteria.All : AvailableCriteria.OnlyAvailable;
            BooksFilter bf = new BooksFilter(db.Books, ac, genreId, authorId, txtTag.Text.Trim());

            dvCatalog.DataSource = bf.GetBooks().ToList();
        }

        private void ShowAuthors()
        {
            var a = new Author { FirstName = "[TUTTI]" };
            var authors = db.Authors.ToList();
            authors.Insert(0, a);
            lstAuthors.DataSource = authors;
        }

        private void ShowGenres()
        {
            var g = new Genre { Name = "[TUTTI]" };
            var genres = db.Genres.ToList();
            genres.Insert(0, g);
            lstGenres.DataSource = genres;
        }

        Book SelectedBook()
        {
            if (dvCatalog.SelectedRows.Count == 0)
                return null;
            return dvCatalog.SelectedRows[0].DataBoundItem as Book;
        }

        void CreateGenre(Genre genre)
        {
            try
            {
                db.Genres.Add(genre);
                db.SaveChanges();      //esegue: INSERT Genres...
                ShowGenres();
            }
            catch
            {
                var msg = $"Impossibile creare il nuovo genere";
                MessageBox.Show(msg, "Nuovo genere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoanBook(Book book, Affiliated affiliated)
        {
            book.AvailableCount--;
            var loan = new Loan
            {
                BookId = book.BookId,
                AffiliatedId = affiliated.AffiliatedId,
                LoanDate = DateTime.Now
            };

            try
            {
                db.Loans.Add(loan);
                db.SaveChanges();  //esegue: INSERT Loan... &  UPDATE Books...
            }
            catch
            {
                var msg = $"Impossibile eseguire il prestito";
                MessageBox.Show(msg, "Prestito libro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
