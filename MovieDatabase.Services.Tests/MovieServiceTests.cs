using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using MovieDatabase.Common.Helpers;
using MovieDatabase.Common.Mappings;
using MovieDatabase.Common.Models;
using MovieDatabase.Db;
using NUnit.Framework;

namespace MovieDatabase.Services.Tests
{
    [TestFixture]
    public class MovieServiceTests
    {
        private MovieService _service;

        
        [SetUp]
        public void Setup()
        {
            AutoMapperInitializer.Initialize();
            
            var connectionString = AppSettingsHelper.ConnectionString;

            var context = new MovieDatabaseContext(connectionString);
            _service = new MovieService(context);
        }

        [Test]
        public async Task TitleOnlySearchWorksAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Title = "Road Trip"
            };

            var searchResponses = await _service.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(EnumerableExtensions.Any(searchResponses));
        }

        [Test]
        public async Task InvalidTitleFindsNothing()
        {
            var searchCriteria = new SearchCriteria()
            {
                Title = "Road Trips"
            };

            var searchResponses = await _service.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsFalse(EnumerableExtensions.Any(searchResponses));
        }

        [Test]
        public async Task FilmWith2GenresIsCorrectAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Title = "Avengers Endgame" 
            };

            var searchResponses = await _service.SearchAsync(searchCriteria).ConfigureAwait(false);
            var avengers = searchResponses.FirstOrDefault(x => x.Title == "Avengers Endgame");
            Assert.IsTrue(EnumerableExtensions.Any(searchResponses));

            Assert.IsNotNull(avengers);
            Assert.AreEqual("Action,Thriller", avengers.Genres);
        }

        [Test]
        public async Task RomanceSearchReturnsNothingAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Genres = "Romance"
            };

            var searchResponses = await _service.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsFalse(EnumerableExtensions.Any(searchResponses));
        }

        [Test]
        public async Task TwoGenresWorksAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Genres = "Comedy,Animation"
            };

            var searchResponses = await _service.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.AreEqual(5, searchResponses.Count);
        }

        [Test]
        public void SearchTop5WorksAsync()
        {
            var searchResponses = _service.GetTop5ByAverageRatings();
            Assert.AreEqual(5, searchResponses.Count);
            Assert.IsFalse(searchResponses.Any(x=>string.IsNullOrEmpty(x.Genres)));
        }

        [Test]
        public void RoundDownWorks()
        {
            var searchResponses = _service.GetTop5ByAverageRatings(1);
            var movie = searchResponses.FirstOrDefault(x => x.Id == 2);
            Assert.IsNotNull(movie);
            Assert.AreEqual(4, movie.AverageRating);
        }
        
        [Test]
        public void SortingWorks()
        {
            var searchResponses = _service.GetTop5ByAverageRatings().Where(x=>x.AverageRating == 4
                                                                              && (x.Id == 9 || x.Id == 10) ).ToList();
            Assert.AreEqual(2, searchResponses.Count);

            Assert.AreEqual("Hot Fuzz", searchResponses[0].Title);
            Assert.AreEqual("The Hangover", searchResponses[1].Title);
        }


    }
}
