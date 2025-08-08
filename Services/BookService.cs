using AutoMapper;
using BookStore.Models;
using BookStore.Interfaces;

namespace BookStore.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public BookService(IMapper mapper, IBookRepository bookRepoistory)
    {
        _mapper = mapper;
        _bookRepository = bookRepoistory;
    }

    public BookDto AddBook(NewBookDto newBook)
    {
        newBook.validate();
        Book savedBook = _bookRepository.AddBook(_mapper.Map<Book>(newBook));
        return _mapper.Map<BookDto>(savedBook);
    }

    public BookDto UpdateBook(BookDto book)
    {
        book.validate();
        _bookRepository.UpdateBook(_mapper.Map<Book>(book));
        Book savedBook = _bookRepository.GetBookById(book.Id);
        return _mapper.Map<BookDto>(savedBook);
    }
    public void DeleteBookById(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }

    public BookDto GetBookById(Guid id)
    {
        Book savedBook = _bookRepository.GetBookById(id);
        return _mapper.Map<BookDto>(savedBook);
    }

    public List<BookDto> ListAllBooks()
    {
        List<Book> books = _bookRepository.ListAllBooks();
        return _mapper.Map<List<BookDto>>(books);
    }
}