using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Contacts.Models;

namespace Contacts.Services;

public class ContactValidator : IContactValidator
{
    public bool ValidateName(string name, [NotNullWhen(false)] out string? errorMessage)
    {
        errorMessage = null;
        var len = name.Trim().Length;
        switch (len)
        {
            case < 2:
                errorMessage = "Contact name is too short.";
                return false;
            case > 50:
                errorMessage = "Contact name is too long.";
                return false;
            default:
                return true;
        }
    }

    public bool ValidatePhone(string? phone, [NotNullWhen(false)] out string? errorMessage)
    {
        // "+7-xxx-xxx-xx-xx"
        const string pattern = @"\+7-\d{3}-\d{3}-\d{2}-\d{2}";

        var validated = string.IsNullOrWhiteSpace(phone) || new Regex(pattern).IsMatch(phone);

        errorMessage = validated ? null : "Invalid phone. Required format: '+7-xxx-xxx-xx-xx'.";
        return validated;
    }
}

