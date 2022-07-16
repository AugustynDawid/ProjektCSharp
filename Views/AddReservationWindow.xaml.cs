using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

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
            var roomId = int.Parse(RoomsCombo.Text);
            Room room;
            using (RoomsRepository roomsRepository = new RoomsRepository())
            {
                room = roomsRepository.GetRoom(roomId);
            }

            var startDate = ReservationStartPicker.SelectedDate.Value;
            var endDate = ReservationEndPicker.SelectedDate.Value;

            var guests = new List<ReservationGuest>();
            var selectedClients = ClientsLB.SelectedItems;
            foreach (Client client in selectedClients)
            {
                var guest = new ReservationGuest();
                guest.ClientId = client.Id;
                guests.Add(guest);
            }

            Reservation reservation = new Reservation();
            reservation.ReservationEnd = endDate;
            reservation.ReservationStart = startDate;
            reservation.RoomId = roomId;
            reservation.ReservationGuests = guests;

            using (ReservationsRepository reservationsRepository = new ReservationsRepository())
            {
                reservationsRepository.InsertReservation(reservation);
            }

            Close();
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
