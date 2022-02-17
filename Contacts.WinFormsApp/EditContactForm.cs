using Contacts.Models;

namespace Contacts.WinFormsApp
{
    public sealed partial class EditContactForm : Form
    {
        private readonly IContactValidator _validator;

        public EditContactFormModel Model { get; }

        public EditContactForm(EditContactFormModel model, 
                               IContactValidator validator)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(validator);

            Model = model;
            _validator = validator;

            Text = Model.NewContact ? "New contact" : "Change contact";

            InitializeComponent();

            bindingSource.DataSource = Model;
        }

        private bool ValidateName()
        {
            var validated = _validator.ValidateName(nameTextBox.Text, out var errorMessage);
            errorProvider.SetError(nameTextBox, validated ? null : errorMessage);
            return validated;
        }

        private bool ValidatePhone()
        {
            var validated = _validator.ValidatePhone(phoneTextBox.Text, out var errorMessage);
            errorProvider.SetError(phoneTextBox, validated ? null : errorMessage);
            return validated;
        }


        private void nameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) => 
            e.Cancel = !ValidateName();

        private void nameTextBox_TextChanged(object sender, EventArgs e) => 
            ValidateName();

        private void phoneTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) => 
            e.Cancel = !ValidatePhone();

        private void phoneTextBox_TextChanged(object sender, EventArgs e) => 
            ValidatePhone();
    }
}
