using Contacts.Models;

namespace Contacts.WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly IAddressBook _addressBook;
        private readonly IContactValidator _validator;

        private MainFormModel Model
        {
            get => (MainFormModel)mainFormModelBindingSource.DataSource;
            set => mainFormModelBindingSource.DataSource = value;
        }

        public MainForm(IAddressBook addressBook, IContactValidator validator)
        {
            ArgumentNullException.ThrowIfNull(addressBook);
            ArgumentNullException.ThrowIfNull(validator);

            _addressBook = addressBook;
            _validator = validator;

            InitializeComponent();

            var contacts = _addressBook.GetContacts().ToList();

            Model = new MainFormModel { Contacts = contacts };

            RefreshDisplayedValues();
        }

        private IList<Contact> GetContacts() =>
            _addressBook.GetContacts(Model.ContactsFilter).ToList();

        private void RefreshDisplayedValues()
        {
            mainFormModelBindingSource.ResetBindings(metadataChanged: false);
            contactListBindingSource.ResetBindings(metadataChanged: false);
        }

        private void exitButton_Click(object sender, EventArgs e) => Close();

        private void newContactButton_Click(object sender, EventArgs e)
        {
            var defaultContact = new Contact() { Name = "Name", Phone = "+7-123-456-78-90" };
            var model = new EditContactFormModel
            {
                NewContact = true,
                Name = defaultContact.Name,
                Phone = defaultContact.Phone,
            };
            using var dialog = new EditContactForm(model, _validator);
            if (DialogResult.OK != dialog.ShowDialog(this))
            {
                return;
            }

            var newContact = new Contact()
            {
                Name = dialog.Model.Name, 
                Phone = dialog.Model.Phone,
            };
            var newContactId = _addressBook.AddContact(newContact);

            Model.Contacts = GetContacts();
            Model.SelectedContactIndex = Model.Contacts.ToList().FindIndex(x => x.ContactId == newContactId);

            RefreshDisplayedValues();
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            var contact = Model.Contacts[Model.SelectedContactIndex];
            var model = new EditContactFormModel
            {
                Name = contact.Name,
                Phone = contact.Phone
            };
            using var dialog = new EditContactForm(model, _validator);
            if (DialogResult.OK != dialog.ShowDialog(this))
            {
                return;
            }
            if (contact.Name  != dialog.Model.Name
             || contact.Phone != dialog.Model.Phone)
            {
                contact.Name = dialog.Model.Name;
                contact.Phone = dialog.Model.Phone;

                _addressBook.UpdateContact(contact);

                Model.Contacts = GetContacts();

                RefreshDisplayedValues();
            }
        }

        private void deleteContactButton_Click(object sender, EventArgs e)
        {
            var message = $"Delete contact '{Model.Contacts[Model.SelectedContactIndex].Name}'?";

            if (DialogResult.Yes != MessageBox.Show(message, 
                                                    Application.ProductName, 
                                                    MessageBoxButtons.YesNo, 
                                                    MessageBoxIcon.Question, 
                                                    MessageBoxDefaultButton.Button2))
            {
                return;
            }

            var selectedContactId = Model.Contacts[Model.SelectedContactIndex].ContactId;

            _addressBook.DeleteContact(selectedContactId);

            Model.Contacts = GetContacts();
            Model.SelectedContactIndex -= Model.SelectedContactIndex == Model.Contacts.Count ? 1 : 0;

            RefreshDisplayedValues();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using var dialog = new FilterForm(Model.ContactsFilter, _validator);
            if (DialogResult.OK != dialog.ShowDialog(this))
            {
                return;
            }

            Model.ContactsFilter = dialog.Filter;
            Model.Contacts = GetContacts();
            Model.SelectedContactIndex = -1;

            RefreshDisplayedValues();

            contactsListBox.Focus();
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            Model.ContactsFilter = null;
            Model.Contacts = GetContacts();

            RefreshDisplayedValues();

            contactsListBox.Focus();
        }

        private void contactListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Model.SelectedContactIndex = contactListBindingSource.Position;
        }
    }
}