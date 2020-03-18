using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDemo.Core
{
    using System;
    using System.Data.Entity;

    public class Library : DbContext
    {
        public Library()
            : base("Library")
        {
            Database.SetInitializer<Library>(null);
            Database.Log = OnSQLExecuted;
        }

        public event EventHandler<SQLExecutedEventArgs> SQLExecuted;

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }
        
        public DbSet<Affiliated> Affiliateds { get; set; }
        public DbSet<Loan> Loans { get; set; }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Author>()                 // un autore
            .HasMany(a => a.Books)              // ha N libri
            .WithMany(b => b.Authors)           // oguno dei quali ha N autori
            .Map(mc =>
            {
                mc.ToTable("Publications");    // join table: Pubblications
                mc.MapLeftKey("AuthorId");      // FK Author: AuthorId
                mc.MapRightKey("BookId");       // FK Book  : BookId
            });
        }

        private static Library _ctx;
        public static Library Context
        {
            get
            {
                if (_ctx == null)
                    _ctx = new Library();
                return _ctx;
            }
        }

        public static void DisposeContext()
        {
            _ctx.Dispose();
            _ctx = null;
        }

        private void OnSQLExecuted(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.StartsWith("--"))
                return;
            SQLExecuted?.Invoke(this, new SQLExecutedEventArgs { RawText = text });
        }

    }

    public class SQLExecutedEventArgs:EventArgs
    {
        public string RawText{ get; set; }
    }
}
