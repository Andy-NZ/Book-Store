using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class DtoBase
{
    public bool validate()
    {
        var book = this;
        var context = new ValidationContext(book);
        var errors = new List<ValidationResult>();

        if (!Validator.TryValidateObject(book, context, errors, true))
        {
            throw new ValidationException(string.Join(" ", errors));
        }

        return true;
    }
}