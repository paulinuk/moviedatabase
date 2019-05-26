using System;
using System.Linq;
using System.Threading.Tasks;
using MovieDatabase.Common.Models;
using MovieDatabase.WebApi.Clients;
using NUnit.Framework;

namespace MovieDatabase.WebApi.Tests
{
    [TestFixture()]
    public class ApiControllerATests
    {
        [Test]
        public async Task ResponseObtainedAsync()
        {
            var searchCriteria = new SearchCriteria()
            {
                Title = "Road Trip"
            };
            
            var client = new ApiControllerAClient();
            var results = await client.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void InvalidRequestGeneratesError()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () => await SearchWithSearchCriteriaAsync(new SearchCriteria()).ConfigureAwait(false));
            Assert.That(ex.Message, Is.EqualTo("Error: BadRequest"));
        }

        [Test]
        public void SearchWithNoResultsGeneratesError()
        {
            var searchCriteria = new SearchCriteria() {Title = "Missing"};
            var ex = Assert.ThrowsAsync<Exception>(async () => await SearchWithSearchCriteriaAsync(searchCriteria).ConfigureAwait(false));
            Assert.That(ex.Message, Is.EqualTo("Error: NotFound"));
        }

        private async Task SearchWithSearchCriteriaAsync(SearchCriteria searchCriteria)
        {
            var client = new ApiControllerAClient();
            var results = await client.SearchAsync(searchCriteria).ConfigureAwait(false);
            Assert.IsTrue(results.Any());
        }

    }
}
