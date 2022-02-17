using Contacts.Models;

namespace Contacts.WinFormsApp
{
    public sealed partial class FilterForm : Form
    {
        private readonly IContactValidator _validator;

        public string Filter => filterTextBox.Text;

        public FilterForm(string? filter, IContactValidator validator)
        {
            ArgumentNullException.ThrowIfNull(validator);

            _validator = validator;

            InitializeComponent();

            filterTextBox.Text = filter;
        }
    }
}
