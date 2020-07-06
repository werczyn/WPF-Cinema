using ProjektMAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAS.DAL
{
    /// <summary>
    /// class for queries in the database
    /// </summary>
    class CinemaDbService
    {
        private readonly CinemaDbContext _context = new CinemaDbContext();

        //-----Adding-----

        /// <summary>
        /// Add cinema to database
        /// </summary>
        /// <param name="cinema"></param>
        public void AddCinema(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add seat to database
        /// </summary>
        /// <param name="seat"></param>
        public void AddSeat(Seat seat)
        {
            _context.Seats.Add(seat);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add client to database
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add reservation to database
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add director to database
        /// </summary>
        /// <param name="director"></param>
        public void AddDirector(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add Actor to database
        /// </summary>
        /// <param name="actor"></param>
        public void AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Add repertoire to database
        /// </summary>
        /// <param name="repertoire"></param>
        public void AddRepertoire(Repertoire repertoire)
        {
            _context.Repertoires.Add(repertoire);
        }

        //-----Removing-----

        /// <summary>
        /// RemoveReservation from database
        /// </summary>
        /// <param name="reservation"></param>
        public void RemoveReservation(Reservation reservation)
        {
            var res = _context.Reservations.Find(reservation.IdReservation);
            _context.Reservations.Remove(res);
            _context.SaveChanges();
        }

        //-----Getting-----

        /// <summary>
        /// Select * from Cinemas
        /// </summary>
        /// <returns>List of cinemas</returns>
        public IEnumerable<Cinema> GetCinemas()
        {
            return _context.Cinemas.ToList();
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }

        /// <summary>
        /// select * from CinemaHalls where IdCinema = cinema.IdCinema
        /// </summary>
        /// <param name="idCinema"></param>
        /// <returns>List of CinemaHalls</returns>
        public IEnumerable<CinemaHall> GetCinemaHallByCinema(int idCinema)
        {
            return _context.CinemaHalls.Where(ch => ch.IdCinema == idCinema).ToList();
        }

        /// <summary>
        /// select * from seats where IdCinemaHall == idCinemaHall
        /// </summary>
        /// <param name="idCinemaHall"></param>
        /// <returns>List of seats in cinemahall</returns>
        internal IEnumerable<Seat> GetSeatsByCinemaHall(int idCinemaHall)
        {
            return _context.Seats.Where(s => s.IdCinemaHall == idCinemaHall).ToList();
        }

        /// <summary>
        /// select * from Screenings
        /// </summary>
        /// <returns>List of screenings</returns>
        public IEnumerable<Screening> GetScreenings()
        {
            return _context.Screenings.ToList();
        }

        /// <summary>
        /// select * from Movies
        /// </summary>
        /// <returns>List of Movies</returns>
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        /// <summary>
        /// select * from Seats
        /// </summary>
        /// <returns>List of seats</returns>
        public IEnumerable<Seat> GetSeats()
        {
            return _context.Seats.ToList();
        }

        /// <summary>
        /// select DateOfProjection Screenings where Screenings.idScreening == idScreening
        /// </summary>
        /// <param name="idScreening"></param>
        /// <returns>DateTime of projection</returns>
        public DateTime GetDateOfProjection(int idScreening)
        {
            return _context.Screenings.SingleOrDefault(s => s.IdScreening == idScreening).DateOfProjection;
        }

        //-----Updating-----

        /// <summary>
        /// Update Seat state if its free
        /// </summary>
        /// <param name="idSeat"></param>
        /// <param name="isSeatFree"></param>
        public void UpdateSeat(int idSeat, bool isSeatFree)
        {
            var result = _context.Seats.SingleOrDefault(s => s.IdSeat == idSeat);
            result.IsSeatFree = isSeatFree;
            _context.SaveChanges();
        }

        //-----Checking-----
        /// <summary>
        /// Check if seats in cinemahall are free
        /// </summary>
        /// <returns></returns>
        public bool IsFree(int idCinemaHall)
        {
            return _context.Seats.Where(s => s.IdCinemaHall == idCinemaHall && s.IsSeatFree == true).Any();
        }
    }
}
