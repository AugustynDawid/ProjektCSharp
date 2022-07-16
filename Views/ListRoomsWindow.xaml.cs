using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Views
{
    public partial class ListRoomsWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("ListRoomsWindow");

        public ListRoomsWindow()
        {
            SetupWindow();
        }

        private async void SetupWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();

            await RefreshRoomsDG();
        }

        private async void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Room client = button.DataContext as Room;
            await RemoveRoom(client.Id);
        }

        private async Task RemoveRoom(int id)
        {
            using (var repo = new RoomsRepository())
            {
                repo.DeleteRoom(id);
            }

            await RefreshRoomsDG();
        }

        private async Task<ObservableCollection<Client>> GetClients()
        {
            using (var repo = new ClientsRepository())
            {
                var clients = await repo.GetAllClients();
                return new ObservableCollection<Client>(clients);
            }
        }

        private async Task RefreshRoomsDG()
        {
            ObservableCollection<Client> clients = await GetClients();
            RoomsDG.DataContext = clients;
        }
    }
}
