using System.ComponentModel.DataAnnotations;
using Contacts.Models;
using Contacts.Services.Utility;

namespace Contacts.Services;

public sealed class AddressBook : IAddressBook
{
    private readonly string _filePath;
    private readonly IContactValidator _contactValidator;
    private readonly List<Contact> _contacts;

    private const string _rootXmlTag = "Contacts";

    public AddressBook(AddressBookSettings settings, IContactValidator contactValidator)
    {
        ArgumentNullException.ThrowIfNull(contactValidator);
        ArgumentNullException.ThrowIfNull(settings);

        _contactValidator = contactValidator;
        _filePath = settings.StorageFilePath;
        _contacts = Load(_filePath, _rootXmlTag);
    }

    public IEnumerable<Contact> GetContacts(string? nameFilter = null)
    {
        var filteredContacts = _contacts
            .Where(x => string.IsNullOrWhiteSpace(nameFilter) || x.Name.ToUpper().Contains(nameFilter.ToUpper()))
            .OrderBy(x => x.Name);

        foreach (var contact in filteredContacts)
        {
            yield return new Contact
            {
                ContactId = contact.ContactId, 
                Name = contact.Name, 
                Phone = contact.Phone
            };
        }
    }

    public int AddContact(Contact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);

        if (!_contactValidator.ValidateName(contact.Name, out _))
        {
            throw new ValidationException(nameof(Contact.Name));
        }

        if (!_contactValidator.ValidatePhone(contact.Phone, out _))
        {
            throw new ValidationException(nameof(Contact.Phone));
        }

        contact.ContactId = (_contacts.MaxBy(x => x.ContactId)?.ContactId ?? 0) + 1;

        _contacts.Add(contact);

        Save(_contacts, _filePath, _rootXmlTag);

        return contact.ContactId;
    }

    public void UpdateContact(Contact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);

        if (!_contactValidator.ValidateName(contact.Name, out _))
        {
            throw new ValidationException(nameof(Contact.Name));
        }

        if (!_contactValidator.ValidatePhone(contact.Phone, out _))
        {
            throw new ValidationException(nameof(Contact.Phone));
        }

        var contactTarget = _contacts.First(x => x.ContactId == contact.ContactId);
        if (contactTarget == null)
        {
            throw new ArgumentOutOfRangeException($"Invalid ContactId: {contact.ContactId}.");
        }

        contactTarget.Name = contact.Name;
        contactTarget.Phone = contact.Phone;

        Save(_contacts, _filePath, _rootXmlTag);
    }

    public void DeleteContact(int contactId)
    {
        var idx = _contacts.FindIndex(x => x.ContactId == contactId);
        if (idx == -1)
        {
            throw new ArgumentOutOfRangeException($"Invalid contactId: {contactId}.");
        }

        _contacts.RemoveAt(idx);

        Save(_contacts, _filePath, _rootXmlTag);
    }

    private static List<Contact> Load(string filePath, string rootTag) =>
        XmlUtility.ReadFile<List<Contact>>(filePath, rootTag);

    private static void Save(List<Contact> contacts, string filePath, string rootTag) =>
        XmlUtility.WriteFile(contacts, filePath, rootTag);
}
