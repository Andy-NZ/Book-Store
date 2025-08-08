using BookStore.Models;

namespace BookStore.Interfaces;

public interface IBookRepository
{
    public Book AddBook(Book book);
    public void UpdateBook(Book book);
    public void DeleteBook(Guid id);
    public Book GetBookById(Guid id);
    public List<Book> ListAllBooks();
}