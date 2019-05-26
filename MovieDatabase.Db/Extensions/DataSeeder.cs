using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Common.Models;

namespace MovieDatabase.Db.Extensions
{
    public static class DataSeeder
    {

        private static IEnumerable<Genre> GetGenres()
        {
            var result = new List<Genre>()
            {
                new Genre() {GenreId = 1, Name = "Action"},
                new Genre() {GenreId = 2, Name = "Thriller"},
                new Genre() {GenreId = 3, Name = "Comedy"},
                new Genre() {GenreId = 4, Name = "Animation"},
                new Genre() {GenreId = 5, Name = "Romance"}
            };

            return result;
        }
        
        private static IEnumerable<Movie> GetMovies()
        {
            var genres = GetGenres();

            var result = new List<Movie>()
            {
                new Movie {MovieId = 1, Title = "Road Trip", RunningTime = 94, YearOfRelease = 2000},
                new Movie {MovieId = 2, Title = "Avengers Endgame", RunningTime = 182, YearOfRelease = 2019},
                new Movie {MovieId = 3, Title = "Wonder Woman", RunningTime = 149, YearOfRelease = 2017},
                new Movie {MovieId = 4, Title = "The Silence Of The Lambs", RunningTime = 139, YearOfRelease = 1991},
                new Movie {MovieId = 5, Title = "It", RunningTime = 135, YearOfRelease = 2017},
                new Movie {MovieId = 6, Title = "Bridesmaids", RunningTime = 132, YearOfRelease = 2011},
                new Movie {MovieId = 7, Title = "Incredibles 2", RunningTime = 125, YearOfRelease = 2018},
                new Movie {MovieId = 8, Title = "The Lion King", RunningTime = 89, YearOfRelease = 1994},
                new Movie {MovieId = 9, Title = "The Hangover", RunningTime = 108, YearOfRelease = 2009},
                new Movie {MovieId = 10, Title = "Hot Fuzz", RunningTime = 121, YearOfRelease = 2007}
            };

            return result;
        }
        
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(GetGenres());
            modelBuilder.Entity<Movie>().HasData(GetMovies());
            modelBuilder.Entity<User>().HasData(GetUsers());
            modelBuilder.Entity<MovieGenre>().HasData(GetMovieGenres());
            modelBuilder.Entity<MovieRating>().HasData(GetMovieRatings());
        }

        private static IEnumerable<MovieGenre> GetMovieGenres()
        {
            var result = new List<MovieGenre>()
            {
                new MovieGenre() {Id = 1, MovieId = 1, GenreId = 3},
                new MovieGenre() {Id = 2, MovieId = 2, GenreId = 1}, //Deliberatly set Avengers Endgame to have 2 genres
                new MovieGenre() {Id = 3, MovieId = 2, GenreId = 2},
                new MovieGenre() {Id = 4, MovieId = 3, GenreId = 1},
                new MovieGenre() {Id = 5, MovieId = 4, GenreId = 2},
                new MovieGenre() {Id = 6, MovieId = 5, GenreId = 2},
                new MovieGenre() {Id = 7, MovieId = 6, GenreId = 1},
                new MovieGenre() {Id = 8, MovieId = 7, GenreId = 4},
                new MovieGenre() {Id = 9, MovieId = 8, GenreId = 4},
                new MovieGenre() {Id = 10, MovieId = 9, GenreId = 3},
                new MovieGenre() {Id = 11, MovieId = 10, GenreId = 3}
            };

            return result;
        }

        private static IEnumerable<MovieRating> GetMovieRatings()
        {
            var result = new List<MovieRating>()
            {
                new MovieRating() {MovieId = 1, UserId = 1, Rating = 4.5M, MovieRatingId = 1},
                new MovieRating() {MovieId = 2, UserId = 1, Rating = 4.249M, MovieRatingId = 2},
                new MovieRating() {MovieId = 1, UserId = 2, Rating = 4.5M, MovieRatingId = 3},
                new MovieRating() {MovieId = 2, UserId = 2, Rating = 4.249M, MovieRatingId = 4},
                new MovieRating() {MovieId = 3, UserId = 1, Rating = 3.8M, MovieRatingId = 5},
                new MovieRating() {MovieId = 8, UserId = 2, Rating = 2.4M, MovieRatingId = 6},
                new MovieRating() {MovieId = 5, UserId = 1, Rating = 4.94M, MovieRatingId = 7},
                new MovieRating() {MovieId = 4, UserId = 2, Rating = 1.4M, MovieRatingId = 9},
                new MovieRating() {MovieId = 5, UserId = 2, Rating = 4.94M, MovieRatingId = 10},
                new MovieRating() {MovieId = 7, UserId = 1, Rating = 3, MovieRatingId = 11},
                new MovieRating() {MovieId = 7, UserId = 2, Rating = 3.8M, MovieRatingId = 12},
                new MovieRating() {MovieId = 9, UserId = 1, Rating = 3.8M, MovieRatingId = 13},
                new MovieRating() {MovieId = 10, UserId = 1, Rating = 3.8M, MovieRatingId = 14},
            };

            return result;
        }

        private static List<User> GetUsers()
        {
            var result = new List<User>()
            {
                new User() {Name = "Paul Saxton", UserId = 1},
                new User() {Name = "Fred Smith", UserId = 2},
                new User() {Name = "John Jones", UserId = 3}

            };

            return result;
        }
        
    }
}
