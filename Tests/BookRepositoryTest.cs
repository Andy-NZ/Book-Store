
using BookStore.Models;
using BookStore.Repositories;
using Xunit;

namespace BookStore.Tests;

public class BookRepositoryTests
{
    private BookRepoistory InitRepository()
    {
        return new BookRepoistory();
    }

    [Fact]
    public void AddBook_ShouldAddBookAndReturnBookEntity()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        Book newBook = new Book { Title = "Book A", ISBN = "978-0-306-40615-7" };

        // Act
        var result = repo.AddBook(newBook);

        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Book A", result.Title);
    }


    [Fact]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        Book newBook = new Book { Title = "Book A", ISBN = "978-0-306-40615-7" };
        Book savedBook = repo.AddBook(newBook);

        // Act
        savedBook.Title = "Book B";
        repo.UpdateBook(savedBook);

        var result = repo.GetBookById(savedBook.Id);

        // Assert
        Assert.Equal("Book B", result.Title);
    }

    [Fact]
    public void UpdateBook_InvalidId_ShouldThrowException()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        Guid bookId = Guid.NewGuid();
        Book book = new Book
        {
            Id = bookId,
            Title = "Book A",
            ISBN = "978-0-306-40615-7"
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => repo.UpdateBook(book));

        // Assert
        Assert.Contains($"Book with Id {bookId} not found.", ex.Message);
    }

    [Fact]
    public void DeleteBook_ShouldDeleteBookFromList()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        Book newBook = new Book
        {
            Title = "Book A",
            ISBN = "978-0-306-40615-7"
        };

        var book = repo.AddBook(newBook);

        // Act
        repo.DeleteBook(book.Id);
        var bookList = repo.ListAllBooks();

        // Assert
        Assert.DoesNotContain(book, bookList);
    }

    [Fact]
    public void DeleteBook_InvalidId_ShouldThrowException()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        Guid bookId = Guid.NewGuid();

        // Act & Asser
        var ex = Assert.Throws<InvalidOperationException>(() => repo.DeleteBook(bookId));
        Assert.Contains($"Book with Id {bookId} not found.", ex.Message);
    }

    [Fact]
    public void DeleteBook_ShouldReturnAllBooks()
    {
        // Arrange
        BookRepoistory repo = InitRepository();
        repo.AddBook(new Book { Title = "Book A", ISBN = "978-0-306-40615-7" });
        repo.AddBook(new Book { Title = "Book B", ISBN = "978-3-161-48410-0" });

        // Act
        var allBooks = repo.ListAllBooks();

        // Asser
        Assert.Equal(2, allBooks.Count());
    }

}