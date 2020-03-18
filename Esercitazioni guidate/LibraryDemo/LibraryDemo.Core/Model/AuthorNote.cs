using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDemo.Core
{
    [Table("AuthorsNote")]
    public class AuthorNote
    {
        [Key]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public byte[] Photo { get; set; }
        public string Biography { get; set; }
    }
}
