using LibraryDemo.Core;
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
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }

        public AuthorForm(Author author)
        {
            InitializeComponent();
            Author = author;
        }

        static List<AuthorForm> openForms = new List<AuthorForm>();
        public static void Show(Author author)
        {
            var af = openForms.Find(f => f.Author.AuthorId == author.AuthorId);
            if (af == null)
            {
                af = new AuthorForm(author);
                af.FormClosed += Af_FormClosed;
                af.Show();
                openForms.Add(af);
            }
            af.BringToFront();
        }

        private static void Af_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorForm af = sender as AuthorForm;
            openForms.Remove(af);
        }

        public Author Author { get; }

        private void AuthorForm_Load(object sender, EventArgs e)
        {
            lblFullName.Text = Author.FullName;
            picPhoto.Image = ImageCache.Get(Author.FullName, Author.AuthorNote.Photo);
            txtBiography.Text = Author.AuthorNote.Biography;
            txtBiography.SelectionStart = 0;
        }
    }
}
