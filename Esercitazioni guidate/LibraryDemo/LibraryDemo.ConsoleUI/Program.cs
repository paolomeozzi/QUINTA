using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryDemo.ConsoleUI
{
    using Core;
    class Program
    {
        static void Main(string[] args)
        {

            Library db = new Library();
            var g = db.Genres.Find(10);  //-> genere "Cancellami"
            g.Name = "Modificato";
            //db.SaveChanges();
            //db.Genres.Remove(g);
            //db.SaveChanges();
            DeleteGenre(g);
            
            //UpdateGenre(g);
            Console.WriteLine("OK");
        }

        // genere caricato da un altro context
        static void DeleteGenre(Genre g)
        {
            Library db = new Library();
            var en = db.Entry<Genre>(g);
            en.State = EntityState.Deleted;
            db.SaveChanges();
        }

        // genere caricato da un altro context
        static void UpdateGenre(Genre g)
        {
            Library db = new Library();
            var en = db.Entry<Genre>(g);
            en.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
