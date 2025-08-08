using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Tests;

public delegate void Operation();

public class MockUserBehavior : IMockUserBehavior
{
    private readonly IBookService _bookService;

    public MockUserBehavior(IBookService bookService)
    {
        _bookService = bookService;
    }

    public void AddBook()
    {
        tryCatch("Add Book", () =>
        {
            NewBookDto bookA = new NewBookDto()
            {
                Title = "Book A",
                ISBN = "978-0-306-40615-7"
            };

            Console.WriteLine("- Add new book");
            Console.WriteLine($"  {bookA.ToString()}");

            BookDto savedBook = _bookService.AddBook(bookA);

            Console.WriteLine($"  New book: {savedBook.ToString()}");
        });
    }

    public void UpdateBook()
    {
        tryCatch("Update Book", () =>
        {
            NewBookDto bookB = new NewBookDto()
            {
                Title = "Book B",
                ISBN = "978-0-306-40615-7"
            };

            Console.WriteLine("- Add new book");
            Console.WriteLine($"  {bookB.ToString()}");

            BookDto book = _bookService.AddBook(bookB);
            Console.WriteLine($"  New book: {book.ToString()}");

            book.Title = "Book C";
            Console.WriteLine("- Update book");
            Console.WriteLine($"  book.Title = 'Book C'");

            BookDto updatedBook = _bookService.UpdateBook(book);
            Console.WriteLine("- After updated");
            Console.WriteLine($"  {updatedBook.ToString()}");
        });
    }

    public void GetBookById()
    {
        tryCatch("Get Book By Id", () =>
        {
            NewBookDto newBook = new NewBookDto()
            {
                Title = "Book B",
                ISBN = "978-0-306-40615-7"
            };

            Console.WriteLine("- Add new book");
            Console.WriteLine($"  {newBook.ToString()}");

            BookDto book = _bookService.AddBook(newBook);
            Console.WriteLine($"  New book: {book.ToString()}");

            Console.WriteLine($"- GetBookById {book.Id}");
            BookDto savedBook = _bookService.GetBookById(book.Id);
            Console.WriteLine($"  Return: {savedBook.ToString()}");
        });
    }

    public void DeleteBook()
    {
        tryCatch("Delete Book", () =>
        {
            NewBookDto newBook = new NewBookDto()
            {
                Title = "Book B",
                ISBN = "978-0-306-40615-7"
            };

            Console.WriteLine("- Add new book");
            Console.WriteLine($"  {newBook.ToString()}");

            BookDto book = _bookService.AddBook(newBook);
            Console.WriteLine($"  New book: {book.ToString()}");

            Console.WriteLine($"- DeleteBook {book.Id}");
            _bookService.DeleteBookById(book.Id);
        });
    }
    public void ListAllBooks()
    {
        tryCatch("List All Books", () =>
        {
            Console.WriteLine("- bookService.ListAllBooks()");
            List<BookDto> books = _bookService.ListAllBooks();
            books.ForEach(book =>
            {
                Console.WriteLine($"  {book.ToString()}");
            });
        });
    }
    private void tryCatch(string text, Operation operation)
    {
        Console.WriteLine("");
        Console.WriteLine($"--- {text} ---");

        try
        {
            operation();
            Console.WriteLine($"Successfull!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed. See errors:");
            Console.WriteLine(ex.Message);
        }
    }
}