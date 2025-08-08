using BookStore.Models;
using BookStore.Services;

namespace BookStore.Tests;

public interface IMockUserBehavior
{
    public void AddBook();
    public void UpdateBook();
    public void DeleteBook();
    public void GetBookById();
    public void ListAllBooks();
}