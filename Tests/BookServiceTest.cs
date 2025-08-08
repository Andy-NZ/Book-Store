using System.ComponentModel.DataAnnotations;
using Moq;
using Xunit;
using AutoMapper;
using BookStore.Models;
using BookStore.Services;
using BookStore.Interfaces;

namespace BookStore.Tests;

public class BookServiceTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        _mapperMock = new Mock<IMapper>();
        _bookRepositoryMock = new Mock<IBookRepository>();
        _bookService = new BookService(_mapperMock.Object, _bookRepositoryMock.Object);
    }

    [Fact]
    public void AddBook_ShouldAddBookAndReturnBookDto()
    {
        // Arrange
        var newBookDto = new NewBookDto()
        {
            Title = "Book A",
            ISBN = "978-0-306-40615-7"
        };
        var bookEntity = new Book();
        var savedBook = new Book();
        var bookDto = new BookDto();

        _mapperMock.Setup(m => m.Map<Book>(newBookDto)).Returns(bookEntity);
        _bookRepositoryMock.Setup(m => m.AddBook(bookEntity)).Returns(savedBook);
        _mapperMock.Setup(m => m.Map<BookDto>(savedBook)).Returns(bookDto);

        // Act
        var result = _bookService.AddBook(newBookDto);

        // Assert
        Assert.Equal(bookDto, result);
    }

    [Fact]
    public void AddBook_InvalidISBN_ShouldThrowException()
    {
        // Arrange
        var newBookDto = new NewBookDto()
        {
            Title = "Book A",
            ISBN = "978-0-306-40615-6" // Invalid ISBN
        };

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _bookService.AddBook(newBookDto));
        Assert.Contains("ISBN is invalid.", ex.Message);
    }

    [Fact]
    public void AddBook_EmptyISBN_ShouldThrowException()
    {
        // Arrange
        var newBookDto = new NewBookDto()
        {
            Title = "Book A",
            ISBN = ""
        };

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _bookService.AddBook(newBookDto));
        Assert.Contains("ISBN is required.", ex.Message);
    }

    [Fact]
    public void AddBook_EmptyTitle_ShouldThrowException()
    {
        // Arrange
        var newBookDto = new NewBookDto()
        {
            Title = "",
            ISBN = "978-0-306-40615-7"
        };

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _bookService.AddBook(newBookDto));
        Assert.Contains("Title is required.", ex.Message);
    }

    [Fact]
    public void UpdateBook_ShouldUpdateAndReturnBookDto()
    {
        // Arrange 
        var bookDto = new BookDto()
        {
            Id = Guid.NewGuid(),
            Title = "Book A",
            ISBN = "978-0-306-40615-7"
        };
        var bookEntity = new Book();
        var updatedBook = new Book();
        var resultBook = new BookDto();

        _mapperMock.Setup(m => m.Map<Book>(bookDto)).Returns(bookEntity);
        _bookRepositoryMock.Setup(m => m.UpdateBook(bookEntity));
        _bookRepositoryMock.Setup(m => m.GetBookById(bookDto.Id)).Returns(updatedBook);
        _mapperMock.Setup(m => m.Map<BookDto>(updatedBook)).Returns(resultBook);

        // Act
        var result = _bookService.UpdateBook(bookDto);

        // Assert
        Assert.Equal(result, result);
    }


    [Fact]
    public void DeleteBook_ShouldCallBookRepositoryDelete()
    {
        // Arrange
        Guid bookId = Guid.NewGuid();

        // Act
        _bookService.DeleteBookById(bookId);

        // Assert
        _bookRepositoryMock.Verify(repository => repository.DeleteBook(bookId), Times.Once);
    }

    [Fact]
    public void GetBookById_ShouldReturnBookDto()
    {
        // Arrange
        Guid bookId = Guid.NewGuid();
        Book entityBook = new Book();
        BookDto bookDto = new BookDto();

        _mapperMock.Setup(m => m.Map<BookDto>(entityBook)).Returns(bookDto);
        _bookRepositoryMock.Setup(m => m.GetBookById(bookId)).Returns(entityBook);

        // Act
        var result = _bookService.GetBookById(bookId);

        // Assert
        Assert.Equal(bookDto, result);
    }

    [Fact]
    public void ListAllBooks_ShouldReturnBookDtoList()
    {
        // Arrange 
        List<Book> entityBooks = new List<Book>();
        List<BookDto> bookDtos = new List<BookDto>();

        _bookRepositoryMock.Setup(r => r.ListAllBooks()).Returns(entityBooks);
        _mapperMock.Setup(m => m.Map<List<BookDto>>(entityBooks)).Returns(bookDtos);

        // Act
        var result = _bookService.ListAllBooks();

        // Assert
        Assert.Equal(bookDtos, result);
    }
}