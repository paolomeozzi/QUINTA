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
    public partial class BookLoanForm : Form
    {
        public BookLoanForm()
        {
            InitializeComponent();
        }

        IEnumerable<Affiliated> affiliateds;
        public BookLoanForm(Book book, IEnumerable<Affiliated> affiliateds)
        {
            InitializeComponent();
            this.affiliateds = affiliateds;
            Book = book;
        }

        public Book Book { get; }
        public Affiliated Affiliated { get; private set; }
        private void BookLoanForm_Load(object sender, EventArgs e)
        {
            lstAffiliateds.DisplayMember = "FullName";
            lstAffiliateds.DataSource = affiliateds.ToList();
            picCover.Image = ImageCache.Get(Book.CoverFileName);
            lblTitle.Text = Book.Title;
            lblGenre.Text = Book.GenreName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstAffiliateds.SelectedIndex < 0)
                return;
            Affiliated = lstAffiliateds.SelectedItem as Affiliated;
        }

        private void lstAffiliateds_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lstAffiliateds.SelectedIndex > -1;
        }
    }
}
