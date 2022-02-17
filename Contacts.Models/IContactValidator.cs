using System.Diagnostics.CodeAnalysis;

namespace Contacts.Models
{
    public interface IContactValidator
    {
        bool ValidateName(string name, [NotNullWhen(false)] out string? errorMessage);

        bool ValidatePhone(string? phone, [NotNullWhen(false)] out string? errorMessage);
    }
}
