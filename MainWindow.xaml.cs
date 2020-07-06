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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektMAS
{
    /// <summary>
    /// Relationship logic for class MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CinemaDbService _service;
        private ObservableCollection<Cinema> _cinemas;

        /// <summary>
        /// Initialize MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Initialize dbservice and seting data grid item source
        /// </summary>
        private void Init()
        {
            _service = new CinemaDbService();
            _cinemas = new ObservableCollection<Cinema>(_service.GetCinemas());
            CinemasDataGrid.ItemsSource = _cinemas;
        }

        /// <summary>
        /// Handling the event of pressing a button to Show Screenings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowScreeningsClick(object sender, RoutedEventArgs e)
        {
            var index = CinemasDataGrid.SelectedIndex;
            if (index > -1)
            {
                var cinema = _cinemas.ElementAt(index);

                ScreeningWindow screeningView = new ScreeningWindow(cinema);
                screeningView.Show();
                this.Close();
            }
            else
            {
                string messageBoxText = "Select cinema to see screenings";
                string caption = "Select cinema";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
