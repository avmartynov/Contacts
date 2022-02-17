namespace Contacts.WinFormsApp
{
    public class EditContactFormModel
    {
        public bool NewContact { get; init; }

        public string Name { get; init; } = default!;

        public string? Phone { get; init; }
    }
}
