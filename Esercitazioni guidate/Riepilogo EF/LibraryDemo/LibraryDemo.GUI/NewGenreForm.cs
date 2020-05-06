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
    public partial class NewGenreForm : Form
    {
        public NewGenreForm()
        {
            InitializeComponent();
        }

        public string GenreName { get; private set; }
        private void NewGenreForm_Load(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GenreName = txtName.Text.Trim();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtName.Text != "";
        }
    }
}
