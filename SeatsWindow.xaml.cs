using ProjektMAS.DAL;
using ProjektMAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektMAS
{
    /// <summary>
    /// Relationship logic for class SeatsWindow.xaml
    /// </summary>
    public partial class SeatsWindow : Window
    {
        private CinemaDbService _service;
        private ObservableCollection<Seat> seats;
        private int idScreening;

        /// <summary>
        /// initialize SeatsWindow
        /// </summary>
        /// <param name="idCinemaHall">identifier of CinemaHall</param>
        /// <param name="idScreening">identifier of Screening</param>
        public SeatsWindow(int idCinemaHall, int idScreening)
        {
            InitializeComponent();
            _service = new CinemaDbService();
            seats = new ObservableCollection<Seat>(_service.GetSeatsByCinemaHall(idCinemaHall));
            SeatsDataGrid.ItemsSource = seats;
            this.idScreening = idScreening;
        }

        /// <summary>
        /// Button operation for seat reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void Reserve_Seat_Button_Click(object sender, RoutedEventArgs e)
        {
            var index = SeatsDataGrid.SelectedIndex;
            if (index > -1)
            {
                var seat = seats.ElementAt(index);
                if (seat.IsSeatFree)
                {
                    seats.Remove(seat);
                    seat.IsSeatFree = false;
                    seats.Add(seat);
                    _service.UpdateSeat(seat.IdSeat, false);
                    
                    ClientWindow clientWindow = new ClientWindow(idScreening, seat.IdSeat);
                    clientWindow.Show();
                    this.Close();
                }
                else
                {
                    string messageBoxText = "This seat is not free";
                    string caption = "Select seat";
                    MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
                }
;
            }
            else
            {
                string messageBoxText = "Select seat to see reserve";
                string caption = "Select seat";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
