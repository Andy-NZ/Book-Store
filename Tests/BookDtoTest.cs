using System.ComponentModel.DataAnnotations;
using BookStore.Models;
using Xunit;

namespace BookStore.Tests;

public class BookDtoTests
{
    [Theory]
    [InlineData("9780306406157")]
    [InlineData("978-0-306406157")]
    [InlineData("978 0 306 40615 7")]
    [InlineData("978-0-306-40615-7")]
    public void BookDtoValidate_ValidISBN_ShouldNotTrowException(string isbn)
    {
        // Arrange
        var bookDto = new BookDto()
        {
            Id = Guid.NewGuid(),
            Title = "Book A",
            ISBN = isbn
        };

        // Act
        bool result = bookDto.validate();

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("", "ISBN is required.")]
    [InlineData(" ", "ISBN is required.")]
    [InlineData("-", "ISBN is invalid.")]
    [InlineData("978-0-306-40615", "ISBN is invalid.")] // less than 13 digits
    [InlineData("978-0-306-40615-7-0", "ISBN is invalid.")] // more than 13 digits
    [InlineData("978-0-306-40615-6", "ISBN is invalid.")] // invalid ISBN
    [InlineData("a-978-0-306-40615-7", "ISBN is invalid.")] // include invalid letter e.g.'a' 
    public void BookDtoValidate_InvalidISBN_ShouldTrowException(string isbn, string expectedMsg)
    {
        // Arrange
        var bookDto = new BookDto()
        {
            Id = Guid.NewGuid(),
            Title = "Book A",
            ISBN = isbn
        };

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => bookDto.validate());
        Assert.Equal(expectedMsg, ex.Message);
    }

}