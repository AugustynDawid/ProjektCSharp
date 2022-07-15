using System.Windows;
using System;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Views
{
    public partial class ListClientsWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("ListClientsWindow");

        public ListClientsWindow()
        {
            SetupWindow();
        }

        private async void SetupWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();

            ObservableCollection<Client> clients = await GetClients();
            ClientsDG.DataContext = clients;
        }

        private async Task<ObservableCollection<Client>> GetClients()
        {
            var repo = new ClientsRepository();
            var clients = await repo.GetAllClients();
            return new ObservableCollection<Client>(clients);
        }
    }
}
