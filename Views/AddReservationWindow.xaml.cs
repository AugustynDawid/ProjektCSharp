using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Views
{
    public partial class AddReservationWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("AddReservationWindow");

        public AddReservationWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
            SetupRoomsDropdown();
            SetupClientsDropdown();
        }

        private async void SetupRoomsDropdown()
        {
            RoomsCombo.DataContext = await GetRooms();
        }

        private async void SetupClientsDropdown()
        {
            ClientsLB.DataContext = await GetClients();
        }

        private void AddReservationSubmit(object sender, RoutedEventArgs e)
        {

        }

        private async Task<ObservableCollection<int>> GetRooms()
        {
            using (var repo = new RoomsRepository())
            {
                var rooms = await repo.GetAllRooms();
                var roomIds = new List<int>();

                foreach (Room room in rooms)
                {
                    roomIds.Add(room.Id);
                }

                return new ObservableCollection<int>(roomIds);
            }
        }

        private async Task<ObservableCollection<Client>> GetClients()
        {
            using (var repo = new ClientsRepository())
            {
                var clients = await repo.GetAllClients();
                return new ObservableCollection<Client>(clients);
            }
        }
    }
}
