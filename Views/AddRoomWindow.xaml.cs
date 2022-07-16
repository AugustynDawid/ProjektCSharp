using System.Windows;
using System;
using Microsoft.Extensions.Logging;
using Utils;
using Models;
using Repositories;


namespace Views
{
    public partial class AddRoomWindow : Window
    {
        private readonly ILogger logger = AppLoggerFactory.GetLogger("AddRoomWindow");

        public AddRoomWindow()
        {
            logger.LogInformation("Initializing");
            InitializeComponent();
        }

        private void AddRoomSubmit(object sender, RoutedEventArgs e)
        {
            var room = new Room();
            room.Description = Description_TBox.Text;
            room.Capacity = int.Parse(Capacity_TBox.Text);
            room.Id = int.Parse(Id_TBox.Text);

            using (var repository = new RoomsRepository())
            {
                try
                {
                    repository.InsertRoom(room);
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
