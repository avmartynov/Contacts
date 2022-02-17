using Contacts.Models;

namespace Contacts.WinFormsApp;

public class MainFormModel
{
    public IList<Contact> Contacts { get; set; } = default!;

    public string? ContactsFilter { get; set; }

    public int SelectedContactIndex { get; set; } = -1;

    public string FilterMessage =>
        string.IsNullOrWhiteSpace(ContactsFilter) ? "" : $"Filtered by: '{ContactsFilter}'";

    public bool SelectedContactEnabled =>
        SelectedContactIndex != -1;

    public string ContactListLabel =>
        $"Contacts ({Contacts.Count} items):";

}