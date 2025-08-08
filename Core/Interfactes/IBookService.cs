using BookStore.Models;

namespace BookStore.Interfaces;

public interface IBookService
{
    public BookDto AddBook(NewBookDto book);
    public BookDto UpdateBook(BookDto book);
    public void DeleteBookById(Guid id);
    public BookDto GetBookById(Guid id);
    public List<BookDto> ListAllBooks();
}