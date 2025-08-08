using BookStore.Interfaces;
using BookStore.Tests;

namespace BookStore;

public class AppRunner
{
    private IMockUserBehavior _mockUserBehavior;

    public AppRunner(IMockUserBehavior mockUserBehavior)
    {
        _mockUserBehavior = mockUserBehavior;
    }

    public void Run()
    {
        _mockUserBehavior.AddBook();
        _mockUserBehavior.UpdateBook();
        _mockUserBehavior.GetBookById();
        _mockUserBehavior.DeleteBook();
        _mockUserBehavior.ListAllBooks();
    }
}