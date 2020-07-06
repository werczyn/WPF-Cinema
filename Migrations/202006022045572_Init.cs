namespace ProjektMAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        IdPerson = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.IdPerson);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        IdMovie = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MovieDescription = c.String(),
                        AverageUsersRating = c.Double(nullable: false),
                        MovieLength = c.Double(nullable: false),
                        Language = c.String(),
                        ProposedMinimumAge = c.Int(nullable: false),
                        IdDirector = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMovie)
                .ForeignKey("dbo.Director", t => t.IdDirector)
                .Index(t => t.IdDirector);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        IdMovieGenre = c.Int(nullable: false, identity: true),
                        NameOfGenere = c.String(),
                    })
                .PrimaryKey(t => t.IdMovieGenre);
            
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        IdScreening = c.Int(nullable: false, identity: true),
                        DateOfProjection = c.DateTime(nullable: false),
                        Translation = c.String(),
                        IdMovie = c.Int(nullable: false),
                        IdCinemaHall = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdScreening)
                .ForeignKey("dbo.CinemaHalls", t => t.IdCinemaHall, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.IdMovie, cascadeDelete: true)
                .Index(t => t.IdMovie)
                .Index(t => t.IdCinemaHall);
            
            CreateTable(
                "dbo.CinemaHalls",
                c => new
                    {
                        IdCinemaHall = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfSeats = c.Int(nullable: false),
                        IdCinema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCinemaHall)
                .ForeignKey("dbo.Cinema", t => t.IdCinema, cascadeDelete: true)
                .Index(t => t.IdCinema);
            
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        IdCinema = c.Int(nullable: false, identity: true),
                        CinemaName = c.String(nullable: false, maxLength: 255),
                        City = c.String(),
                        Street = c.String(),
                        ApartmentNumber = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCinema);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        IdSeat = c.Int(nullable: false, identity: true),
                        SeatRow = c.String(),
                        SeatNumber = c.Int(nullable: false),
                        IsSeatFree = c.Boolean(nullable: false),
                        IdCinemaHall = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeat)
                .ForeignKey("dbo.CinemaHalls", t => t.IdCinemaHall, cascadeDelete: true)
                .Index(t => t.IdCinemaHall);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        IdReservation = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IdScreening = c.Int(nullable: false),
                        IdSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReservation)
                .ForeignKey("dbo.Client", t => t.IdClient)
                .ForeignKey("dbo.Screenings", t => t.IdScreening, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.IdSeat, cascadeDelete: false)
                .Index(t => t.IdClient)
                .Index(t => t.IdScreening)
                .Index(t => t.IdSeat);
            
            CreateTable(
                "dbo.Repertoires",
                c => new
                    {
                        IdRepertoire = c.Int(nullable: false, identity: true),
                        SinceWhen = c.DateTime(nullable: false),
                        ToWhen = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdRepertoire);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_IdMovie = c.Int(nullable: false),
                        Actor_IdPerson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_IdMovie, t.Actor_IdPerson })
                .ForeignKey("dbo.Movies", t => t.Movie_IdMovie, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.Actor_IdPerson, cascadeDelete: true)
                .Index(t => t.Movie_IdMovie)
                .Index(t => t.Actor_IdPerson);
            
            CreateTable(
                "dbo.MovieGenreMovies",
                c => new
                    {
                        MovieGenre_IdMovieGenre = c.Int(nullable: false),
                        Movie_IdMovie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieGenre_IdMovieGenre, t.Movie_IdMovie })
                .ForeignKey("dbo.MovieGenres", t => t.MovieGenre_IdMovieGenre, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_IdMovie, cascadeDelete: true)
                .Index(t => t.MovieGenre_IdMovieGenre)
                .Index(t => t.Movie_IdMovie);
            
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        IdPerson = c.Int(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        NoumberOfActed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerson)
                .ForeignKey("dbo.People", t => t.IdPerson)
                .Index(t => t.IdPerson);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        IdPerson = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerson)
                .ForeignKey("dbo.People", t => t.IdPerson)
                .Index(t => t.IdPerson);
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        IdPerson = c.Int(nullable: false),
                        NumberOfDirectedFilms = c.Int(nullable: false),
                        AverageUsersRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerson)
                .ForeignKey("dbo.People", t => t.IdPerson)
                .Index(t => t.IdPerson);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Director", "IdPerson", "dbo.People");
            DropForeignKey("dbo.Client", "IdPerson", "dbo.People");
            DropForeignKey("dbo.Actor", "IdPerson", "dbo.People");
            DropForeignKey("dbo.Reservations", "IdSeat", "dbo.Seats");
            DropForeignKey("dbo.Reservations", "IdScreening", "dbo.Screenings");
            DropForeignKey("dbo.Reservations", "IdClient", "dbo.Client");
            DropForeignKey("dbo.Screenings", "IdMovie", "dbo.Movies");
            DropForeignKey("dbo.Seats", "IdCinemaHall", "dbo.CinemaHalls");
            DropForeignKey("dbo.Screenings", "IdCinemaHall", "dbo.CinemaHalls");
            DropForeignKey("dbo.CinemaHalls", "IdCinema", "dbo.Cinema");
            DropForeignKey("dbo.MovieGenreMovies", "Movie_IdMovie", "dbo.Movies");
            DropForeignKey("dbo.MovieGenreMovies", "MovieGenre_IdMovieGenre", "dbo.MovieGenres");
            DropForeignKey("dbo.Movies", "IdDirector", "dbo.Director");
            DropForeignKey("dbo.MovieActors", "Actor_IdPerson", "dbo.Actor");
            DropForeignKey("dbo.MovieActors", "Movie_IdMovie", "dbo.Movies");
            DropIndex("dbo.Director", new[] { "IdPerson" });
            DropIndex("dbo.Client", new[] { "IdPerson" });
            DropIndex("dbo.Actor", new[] { "IdPerson" });
            DropIndex("dbo.MovieGenreMovies", new[] { "Movie_IdMovie" });
            DropIndex("dbo.MovieGenreMovies", new[] { "MovieGenre_IdMovieGenre" });
            DropIndex("dbo.MovieActors", new[] { "Actor_IdPerson" });
            DropIndex("dbo.MovieActors", new[] { "Movie_IdMovie" });
            DropIndex("dbo.Reservations", new[] { "IdSeat" });
            DropIndex("dbo.Reservations", new[] { "IdScreening" });
            DropIndex("dbo.Reservations", new[] { "IdClient" });
            DropIndex("dbo.Seats", new[] { "IdCinemaHall" });
            DropIndex("dbo.CinemaHalls", new[] { "IdCinema" });
            DropIndex("dbo.Screenings", new[] { "IdCinemaHall" });
            DropIndex("dbo.Screenings", new[] { "IdMovie" });
            DropIndex("dbo.Movies", new[] { "IdDirector" });
            DropTable("dbo.Director");
            DropTable("dbo.Client");
            DropTable("dbo.Actor");
            DropTable("dbo.MovieGenreMovies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Repertoires");
            DropTable("dbo.Reservations");
            DropTable("dbo.Seats");
            DropTable("dbo.Cinema");
            DropTable("dbo.CinemaHalls");
            DropTable("dbo.Screenings");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Movies");
            DropTable("dbo.People");
        }
    }
}
