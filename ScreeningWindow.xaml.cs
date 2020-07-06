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
    /// Relationship logic for class ScreeningWindow.xaml
    /// </summary>
    public partial class ScreeningWindow : Window
    {

        private CinemaDbService _service;
        private ObservableCollection<Screening> screenings;
        private ObservableCollection<CinemaHall> cinemaHalls;
        private readonly Cinema cinema;
        private List<ScreeningCinemaHall> list;

        /// <summary>
        /// Initializing ScreeningWindow
        /// </summary>
        /// <param name="cinema"></param>
        public ScreeningWindow(Cinema cinema)
        {
            InitializeComponent();
            this.cinema = cinema;
            Init();
        }

        /// <summary>
        /// Handling of window closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        /// <summary>
        /// Initialazing Database service and setting DataGrid item source
        /// </summary>
        private void Init()
        {

            _service = new CinemaDbService();
            screenings = new ObservableCollection<Screening>(_service.GetScreenings());
            cinemaHalls = new ObservableCollection<CinemaHall>(_service.GetCinemaHallByCinema(cinema.IdCinema));
            var movies = new ObservableCollection<Movie>(_service.GetMovies());

            var result = screenings.Join(cinemaHalls,
               s => s.IdCinemaHall,
               ch => ch.IdCinemaHall,
               (s, ch) => new ScreeningCinemaHall
               {
                   IdCinemaHall = ch.IdCinemaHall,
                   IdScreening = s.IdScreening,
                   DateOfProjection = s.DateOfProjection,
                   CinemaHallName = ch.Name,
                   Movie = s.Movie
               }).ToList();
            list = new List<ScreeningCinemaHall>(result);

            ScreeningsDataGrid.ItemsSource = result;
        }

        /// <summary>
        /// Handling the event of pressing a button to show seats in cinema hall
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void Show_Seats_Button_Click(object sender, RoutedEventArgs e)
        {
            var index = ScreeningsDataGrid.SelectedIndex;
            if (index > -1)
            {
                var screeningCinemaHall = list.ElementAt(index);
                SeatsWindow seatsWindow = new SeatsWindow(screeningCinemaHall.IdCinemaHall,screeningCinemaHall.IdScreening);
                if (_service.IsFree(screeningCinemaHall.IdCinemaHall))
                {
                    seatsWindow.ShowDialog();
                }
                else
                {
                    string messageBoxText = "No free seats on CinemaHall";
                    string caption = "No free seats";
                    MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
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
