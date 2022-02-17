namespace Contacts.Models
{
    public interface IAddressBook 
    {
        IEnumerable<Contact> GetContacts(string? nameFilter = null);

        int AddContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(int contactId);
    }
}
