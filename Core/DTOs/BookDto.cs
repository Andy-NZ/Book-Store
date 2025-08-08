using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class NewBookDto : DtoBase
{
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "ISBN is required.")]
    [ISBN(ErrorMessage = "ISBN is invalid.")]
    public string ISBN { get; set; } = string.Empty;

    override
    public string ToString()
    {
        return $"Title: {Title}, ISBN: {ISBN}";
    }
}

public class BookDto : NewBookDto
{
    [Required(ErrorMessage = "BookId is required.")]
    public Guid Id { get; set; }

    override
    public string ToString()
    {
        return $"Id: {Id}, Title: {Title}, ISBN: {ISBN}";
    }
}