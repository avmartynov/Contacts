using Contacts.Models;
using Contacts.Services;

namespace Contacts.WinFormsApp
{
    internal static class Program
    {
        private const string _storageFilePath = "Contacts.xml";

        [STAThread]
        private static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();

                Application.ThreadException += (_, e) => e.Exception.Handle();
                TaskScheduler.UnobservedTaskException += (_, e) => e.Exception.HandleFatal();
                AppDomain.CurrentDomain.UnhandledException += (_, e) => ((Exception)e.ExceptionObject).HandleFatal();

                var config = new AddressBookSettings { StorageFilePath = _storageFilePath };
                var validator = new ContactValidator();   
                var addressBook = new AddressBook(config, validator);

                Application.Run(new MainForm(addressBook, validator));

                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            }
            catch (Exception e)
            {
                e.HandleFatal();
            }
        }

        /// <summary> Обработка ошибок при обработке оконных сообщений. </summary>
        private static void Handle(this Exception e)
        {
            var message = $"The application performed an invalid action.{Environment.NewLine}" +
                          $"An error has occurred: '{e.Message}'.{Environment.NewLine}" +
                          $"Do you want to continue the application?";
            var result = MessageBox.Show(message,
                                         Application.ProductName,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Error,
                                         MessageBoxDefaultButton.Button1);
            if (result != DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary> Обработка ошибок в стартовом и завершающем коде приложения. </summary>
        private static void HandleFatal(this Exception e)
        {
            var message = $"The application performed an invalid action.{Environment.NewLine}" +
                          $"An error has occurred: '{e.Message}'.{Environment.NewLine}" +
                          $"The application will be terminated.";

            MessageBox.Show(message,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}