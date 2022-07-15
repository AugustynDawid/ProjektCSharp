using System.Windows;
using System;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;


namespace Views
{
    public partial class AddClientWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("MainWindow");

        public AddClientWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }

        private void AddUserSubmit(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            client.Name = Name_TBox.Text;
            client.Email = Email_TBox.Text;
            client.Notes = Notes_TBox.Text;

            using (var repository = new ClientsRepository())
            {
                try
                {
                    repository.InsertClient(client);
                    this.Close();
                }
                catch (Exception err)
                {
                    logger.LogError(err.ToString());
                }
            }
        }
    }
}
