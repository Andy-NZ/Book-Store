using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class ISBNAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string stringValue)
        {
            stringValue = stringValue.Replace("-", "").Replace(" ", "");

            if (!Regex.IsMatch(stringValue, @"^\d{13}$"))
                return false;

            int sum = stringValue
                        .ToList()
                        .Select((c, i) =>
                        {
                            int digit = int.Parse(c.ToString());
                            return (i % 2 == 0) ? digit : digit * 3;
                        })
                        .Sum();

            return sum % 10 == 0;
        }

        return false;
    }
}