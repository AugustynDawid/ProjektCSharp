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
    public partial class ListReservationsWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("ListReservationsWindow");

        public ListReservationsWindow()
        {
            SetupWindow();
        }

        private async void SetupWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();

            await RefreshReservationsDG();
        }

        private async Task<ObservableCollection<Reservation>> GetReservations()
        {
            using (var repo = new ReservationsRepository())
            {
                var reservations = await repo.GetAllReservations();
                return new ObservableCollection<Reservation>(reservations);
            }
        }

        private async Task RefreshReservationsDG()
        {
            ObservableCollection<Reservation> reservations = await GetReservations();
            ReservationsDG.DataContext = reservations;
        }
    }
}
