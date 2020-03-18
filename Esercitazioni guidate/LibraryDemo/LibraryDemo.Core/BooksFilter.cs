using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryDemo.Core
{
    public class BooksFilter
    {
        AvailableCriteria availableCriteria;
        int genreId;
        int authorId;
        string tag;

        // E' FONDAMENTALE USARE IL TIPO IQueryable<>!
        // SOLO COSI'LA QUERY SARA' TRADOTTA NELL'ISTRUZIONE SQL PIU' APPROPRIATA!

        IQueryable<Book> books;

        // SE FOSSE IEnumerable<> SAREBBERO CARICATI TUTTI I LIBRI E SOLTANTO DOPO, IN MEMORIA, 
        // SAREBBERO ESEGUITI I FILTRI!
        //IEnumerable<Book> books;
        public BooksFilter(IQueryable<Book> books, AvailableCriteria availableCriteria, int genreId, int authorId, string tag)
        {
            this.books = books;
            this.availableCriteria = availableCriteria;
            this.genreId = genreId;
            this.authorId = authorId;
            this.tag = tag;
        }

        public IEnumerable<Book> GetBooks()
        {
            if (genreId != 0)
                books = books.Where(b => b.GenreId == genreId);

            //!per ogni libro verifica se c'è un autore con l'id specificato!
            // (il metodo Any() ritorna vero se almeno un elemento soddisfa la condizione
            if (authorId != 0)
                books = books.Where(b => b.Authors.Any(a => a.AuthorId == authorId));

            if (availableCriteria == AvailableCriteria.OnlyAvailable)
                books = books.Where(b => b.AvailableCount > 0);

            if (!string.IsNullOrEmpty(tag))
                books = books.Where(b => b.Title.Contains(tag));

            return books;
        }
    }

    public enum AvailableCriteria
    {
        All,
        OnlyAvailable
    }
}
