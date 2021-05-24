using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoreyStub = new Mock<IBookRepository>();
            bookRepositoreyStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                               .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoreyStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                               .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoreyStub.Object);
            var validIsbn = "ISBN 12345-67890";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoreyStub = new Mock<IBookRepository>();
            bookRepositoreyStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                               .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoreyStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                               .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoreyStub.Object);
            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
