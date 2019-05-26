using System.Linq;
using System.Threading.Tasks;
using MovieDatabase.Common.Helpers;
using MovieDatabase.Common.Mappings;
using MovieDatabase.Common.Models;
using MovieDatabase.Db;
using NUnit.Framework;

namespace MovieDatabase.Services.Tests
{
    [TestFixture]
    public class RatingServiceTests
    {
        private RatingService _ratingService;
        private MovieService _movieService;


        [SetUp]
        public void Setup()
        {
            AutoMapperInitializer.Initialize();

            var connectionString = AppSettingsHelper.ConnectionString;

            var context = new MovieDatabaseContext(connectionString);
            _ratingService = new RatingService(context);
            _movieService = new MovieService(context);


        }

        [Test]
        public async Task ChangeRatingWorksAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Title = "Wonder Woman"
            };

            var movies = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(movies.Any());
            var wonderWoman = movies.FirstOrDefault();
            Assert.IsNotNull(wonderWoman);
            var originalRating = wonderWoman.AverageRating;

            await _ratingService.AddOrUpdateRatingAsync(wonderWoman.Id, 1, 1.3M);
            
            movies = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(movies.Any());
            wonderWoman = movies.FirstOrDefault();
            Assert.IsNotNull(wonderWoman);
            
            Assert.IsFalse(originalRating == wonderWoman.AverageRating);
            
            //Now reinstate the rating
            await _ratingService.AddOrUpdateRatingAsync(wonderWoman.Id, 1, 3.8M);
            movies = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(movies.Any());
            wonderWoman = movies.FirstOrDefault();
            Assert.IsNotNull(wonderWoman);

            Assert.IsTrue(originalRating == wonderWoman.AverageRating);
        }
        
        [Test]
        public async Task AddNewRatingWorksAsync()
        {
            //This test will only pass once 
            var searchCriteria = new SearchCriteria()
            {
                Title = "Road Trip"
            };

            var movies = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(movies.Any());
            var roadTrip = movies.FirstOrDefault();
            Assert.IsNotNull(roadTrip);
            var originalRating = roadTrip.AverageRating;

            await _ratingService.AddOrUpdateRatingAsync(roadTrip.Id, 3, 1M);

            movies = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(movies.Any());
            roadTrip = movies.FirstOrDefault();
            Assert.IsNotNull(roadTrip);

            Assert.IsFalse(originalRating == roadTrip.AverageRating);
        }
    }
}
