using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDemo.Core
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AvailableCount { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<Author> Authors { get; set; }
        public string GenreName { get { return Genre.Name; } }
        public string CoverFileName { get; set; }
    }
}
