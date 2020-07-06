using ProjektMAS.DAL;
using ProjektMAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Relationship logic for class ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private CinemaDbService _service;
        private int idScreening;
        private int idSeat;

        /// <summary>
        /// Initialize ClientWindow
        /// </summary>
        /// <param name="idScreening">Identifier of Screening</param>
        /// <param name="idSeat">Identifier of Seat</param>
        public ClientWindow(int idScreening, int idSeat)
        {
            InitializeComponent();
            this.idScreening = idScreening;
            this.idSeat = idSeat;
            _service = new CinemaDbService();
        }

        /// <summary>
        /// Handling the event of pressing a button to make reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void Make_Reservation_Button_Click(object sender, RoutedEventArgs e)
        {
            Regex emailRegex = new Regex("^.+@.+\\..+$");
            Regex phoneRegex = new Regex("^\\d{1,9}$");
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var emaliAddress = EmailAddressTextBox.Text;
            var phoneNumber = PhoneNumberTextBox.Text;

            if (String.IsNullOrEmpty(firstName) ||
                String.IsNullOrEmpty(lastName) ||
                String.IsNullOrEmpty(emaliAddress) ||
                String.IsNullOrEmpty(phoneNumber))
            {
                string messageBoxText = "Insert value into textbox";
                string caption = "Empty Text Box";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!phoneRegex.IsMatch(phoneNumber))
            {
                string messageBoxText = "Wrong phone number syntax";
                string caption = "Syntax error";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!emailRegex.IsMatch(emaliAddress))
            {
                string messageBoxText = "Wrong email address syntax";
                string caption = "Syntax error";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Client client = new Client
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emaliAddress,
                    PhoneNumber = int.Parse(phoneNumber)
                };

                _service.AddClient(client);
                var date = _service.GetDateOfProjection(idScreening).AddMinutes(-30);

                Reservation reservation = new Reservation
                {
                    IdScreening = idScreening,
                    IdSeat = idSeat,
                    IdClient = client.IdPerson,
                    ExpirationDate = date
                };

                _service.AddReservation(reservation);

                string messageBoxText = "Your reservation number is: "+reservation.IdReservation;
                string caption = "Reservation number";
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
        }

        /// <summary>
        /// Handling the event of pressing a button to close reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            _service.UpdateSeat(idSeat, true);
            this.Close();
        }
    }
}
