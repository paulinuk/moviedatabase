using System.Linq;
using System.Threading.Tasks;
using MovieDatabase.WebApi.Clients;
using NUnit.Framework;

namespace MovieDatabase.WebApi.Tests
{
    [TestFixture()]
    public class ApiControllerCTests
    {
        [Test]
        public async Task ResponseObtainedAsync()
        {
            var client = new ApiControllerCClient();
            var results = await client.Top5AverageRatingsByUser(1).ConfigureAwait(false);
            Assert.IsTrue(results.Any());
        }
    }
}
