using System.Windows;
using System;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;


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

        private void AddReservationSubmit(object sender, RoutedEventArgs e)
        {

        }
    }
}
