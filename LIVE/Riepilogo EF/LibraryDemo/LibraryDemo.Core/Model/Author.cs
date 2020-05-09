using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDemo.Core
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual AuthorNote AuthorNote { get; set; }
        [NotMapped]
        public string FullName => LastName == null ? FirstName : $"{LastName}, {FirstName}";
    }
}
