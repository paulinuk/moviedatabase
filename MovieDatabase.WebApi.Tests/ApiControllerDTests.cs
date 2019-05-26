using System;
using System.Linq;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using MovieDatabase.WebApi.Clients;
using NUnit.Framework;

namespace MovieDatabase.WebApi.Tests
{
    [TestFixture()]
    public class ApiControllerDTests
    {
        [Test]
        public async Task ResponseObtainedForValidSearchCriteriaAsync()
        {
            var searchCriteria = new SearchCriteria() {Title = "Road Trip"};
            var apiControllerAClient = new ApiControllerAClient();
            var movies = await apiControllerAClient.SearchAsync(searchCriteria).ConfigureAwait(false);

            Assert.AreEqual(1, movies.Count);
            var roadTrip = movies.FirstOrDefault();
            Assert.IsNotNull(roadTrip);

            var original = roadTrip.AverageRating;
            
            var apiControllerDClient = new ApiControllerDClient();
            await apiControllerDClient.AddOrUpdateRatingAsync(1, 3, 1.2M).ConfigureAwait(false);

            movies = await apiControllerAClient.SearchAsync(searchCriteria).ConfigureAwait(false);

            Assert.AreEqual(1, movies.Count);
            roadTrip = movies.FirstOrDefault();
            Assert.IsNotNull(roadTrip);

            Assert.IsFalse(original == roadTrip.AverageRating);

            await apiControllerDClient.AddOrUpdateRatingAsync(1, 3, 1).ConfigureAwait(false);

            movies = await apiControllerAClient.SearchAsync(searchCriteria).ConfigureAwait(false);

            Assert.AreEqual(1, movies.Count);
            roadTrip = movies.FirstOrDefault();
            Assert.IsNotNull(roadTrip);

            Assert.IsTrue(original == roadTrip.AverageRating);

        }


        private async Task AddOrUpdateRatingsAsync(int movieId, int userId, decimal rating)
        {
            var apiControllerDClient = new ApiControllerDClient();
            await apiControllerDClient.AddOrUpdateRatingAsync(movieId, userId, rating).ConfigureAwait(false);
        }

        [Test]
        public void InvalidRatingGeneratesError()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () => await AddOrUpdateRatingsAsync(1, 3, 9).ConfigureAwait(false));
            Assert.That(ex.Message, Is.EqualTo("Error: BadRequest"));
        }

        [Test]
        public void MissingMovieGeneratesError()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () => await AddOrUpdateRatingsAsync(0, 3, 4).ConfigureAwait(false));
            Assert.That(ex.Message, Is.EqualTo("Error: NotFound"));
        }

    }
}
