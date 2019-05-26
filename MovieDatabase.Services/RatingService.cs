namespace MovieDatabase.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catel;
    using Common.Models;
    using Db;

    public class RatingService : IRatingService
    {
        private readonly MovieDatabaseContext _context;

        public RatingService(MovieDatabaseContext context)
        {
            Argument.IsNotNull(() => context);

            _context = context;
        }

        public async Task<MovieRating> AddOrUpdateRatingAsync(int movieId, int userId, decimal rating)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);
            if (movie == null)
                return null; //Invalid movie

            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null)
                return null; //Invalid user

            var movieRating = _context.Ratings.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
            if (movieRating == null)
            {
                movieRating = new MovieRating()
                {
                    MovieId = movieId,
                    UserId = userId
                };

                _context.Ratings.Add(movieRating);
            }

            movieRating.Rating = rating;
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return movieRating;
        }
    }
}
