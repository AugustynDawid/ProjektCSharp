using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System;

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

            await RefreshClientsDG();
        }

        private async void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Client client = button.DataContext as Client;
            await RemoveUser(client.Id);
        }

        private async Task RemoveUser(int id)
        {
            using (var repo = new ClientsRepository())
            {
                repo.DeleteClient(id);
            }

            await RefreshClientsDG();
        }

        private async Task<ObservableCollection<Client>> GetClients()
        {
            using (var repo = new ClientsRepository())
            {
                var clients = await repo.GetAllClients();
                return new ObservableCollection<Client>(clients);
            }
        }

        private async Task RefreshClientsDG()
        {
            ObservableCollection<Client> clients = await GetClients();
            ClientsDG.DataContext = clients;
        }
    }
}
