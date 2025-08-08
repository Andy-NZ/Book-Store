using BookStore.Models;
using BookStore.Interfaces;

namespace BookStore.Repositories;

public class BookRepoistory : IBookRepository
{
    private List<Book> books = new List<Book>();

    public Book AddBook(Book book)
    {
        book.Id = Guid.NewGuid();
        books.Add(book);
        return book;
    }

    public void UpdateBook(Book book)
    {
        var index = books.FindIndex(b => b.Id == book.Id);

        if (index == -1)
        {
            throw new InvalidOperationException($"Book with Id {book.Id} not found.");
        }

        books[index] = book;
    }

    public void DeleteBook(Guid id)
    {
        var savedBook = GetBookById(id);
        books.Remove(savedBook);
    }

    public Book GetBookById(Guid id)
    {
        var savedBook = books.FirstOrDefault(book => book.Id == id);

        if (savedBook == null)
        {
            throw new InvalidOperationException($"Book with Id {id} not found.");
        }

        return savedBook;
    }

    public List<Book> ListAllBooks()
    {
        return books;
    }
}