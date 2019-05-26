using System.Threading.Tasks;

namespace MovieDatabase.Services.Interfaces
{
    using System.Collections.Generic;
    using Common.Models;

    public interface IMovieService
    {
        List<SearchResponse> GetTop5ByAverageRatings(int userId = 0);
        Task<List<SearchResponse>> SearchAsync(SearchCriteria searchCriteria);
    }
}