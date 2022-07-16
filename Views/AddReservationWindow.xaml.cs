using System.Windows;
using Microsoft.Extensions.Logging;
using Utils;

namespace Views
{
    public partial class AddReservationWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("AddReservationWindow");

        public AddReservationWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }

        private void SetupRoomsDropdown()
        {
        }

        private void AddReservationSubmit(object sender, RoutedEventArgs e)
        {

        }
    }
}
