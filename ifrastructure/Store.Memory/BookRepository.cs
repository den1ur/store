using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 1234567890", "D. Knuth", "Art Of Programming", "wqfqwfweqfw", 7.19m),
            new Book(2, "ISBN 2222222222", "M. Fowler", "Refactoring", "dqwdwqfqwf", 8.43m),
            new Book(3, "ISBN 3333333322", "B. Kernighan, D. Ritchie", "C Programming Language", "dqwedqwd", 4.23123m),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    ||book.Title.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
