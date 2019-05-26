using System.Linq;
using System.Threading.Tasks;
using MovieDatabase.WebApi.Clients;
using NUnit.Framework;

namespace MovieDatabase.WebApi.Tests
{
    [TestFixture()]
    public class ApiControllerBTests
    {
        [Test]
        public async Task ResponseObtainedAsync()
        {
            var client = new ApiControllerBClient();
            var results = await client.Top5AverageRatingsAsync().ConfigureAwait(false);
            Assert.IsTrue(results.Any());
        }
    }
}
