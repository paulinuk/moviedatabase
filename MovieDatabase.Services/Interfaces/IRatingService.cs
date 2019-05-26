using System.Threading.Tasks;
using MovieDatabase.Common.Models;

namespace MovieDatabase.Services
{
    public interface IRatingService
    {
        Task<MovieRating> AddOrUpdateRatingAsync(int movieId, int userId, decimal rating);
    }
}