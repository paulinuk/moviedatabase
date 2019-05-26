using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catel;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Common.Helpers;
using MovieDatabase.Common.Models;
using MovieDatabase.Db;
using MovieDatabase.Services.Interfaces;

namespace MovieDatabase.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDatabaseContext _context;

        public MovieService(MovieDatabaseContext context)
        {
            Argument.IsNotNull(() => context);

            _context = context;
        }
        
        public async Task<List<SearchResponse>> SearchAsync(SearchCriteria searchCriteria)
        {
            if (searchCriteria.IsValid == false)
                return new List<SearchResponse>();

            var genresToFind = await GenreIdsToFindAsync(searchCriteria.Genres).ConfigureAwait(false);
            var movies = await _context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieRatings)
                .Where(x => x.MovieGenres.Select(t => t.GenreId).Intersect(genresToFind).Any()
                            && (x.Title.Contains(searchCriteria.Title, StringComparison.OrdinalIgnoreCase) ||
                                string.IsNullOrEmpty(searchCriteria.Title))
                            && (x.YearOfRelease == searchCriteria.YearOfRelease || searchCriteria.YearOfRelease == 0))
                .ToListAsync().ConfigureAwait(false);

            var result = new List<SearchResponse>();
            foreach (var movie in movies)
            {
                var searchResponse = Mapper.Map<SearchResponse>(movie);
                result.Add(searchResponse);

                searchResponse.AverageRating = movie.MovieRatings.Average(x => x.Rating);
            }

            FinaliseSearchResponse(result);

            result = result.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();
            return result;
        }

        private async Task<List<int>> GenreIdsToFindAsync(string genres)
        {
            //Get all genres from database
            var allGenres = await _context.Genres.ToListAsync().ConfigureAwait(false);

            var genresToFind = new List<int>();
            var searchCriteriaGenreList = string.IsNullOrEmpty(genres) ? new List<string>() : genres.Split(",").ToList();

            if (searchCriteriaGenreList.Any())
                //Create a list of all of the required genres
                foreach (var criteriaGenre in searchCriteriaGenreList)
                {
                    var genre = allGenres.FirstOrDefault(x => string.Equals(x.Name, criteriaGenre, StringComparison.OrdinalIgnoreCase));

                    if (genre != null)
                        genresToFind.Add(genre.GenreId);
                }
            else
            {
                //Use all genres
                genresToFind.AddRange(allGenres.Select(x => x.GenreId).ToList());
            }

            return genresToFind;
        }

        //This can be used for both ways of geting ratings (Specific user and All users) because the ratings are filtered
        public List<SearchResponse> GetTop5ByAverageRatings(int userId = 0)
        {
            var movies =
                 (from b in _context.Ratings.Where(x=>x.UserId == userId || userId == 0)
                    join c in _context.Movies on b.MovieId equals c.MovieId
                    group b by new
                    {
                        b.MovieId,
                        c.Title,
                        c.RunningTime,
                        c.YearOfRelease
                    }
                    into g
                    select new SearchResponse()
                    {
                        Id = g.Key.MovieId,
                        Title = g.Key.Title,
                        AverageRating = g.Average(s => s.Rating),
                        YearOfRelease = g.Key.YearOfRelease,
                        RunningTime = g.Key.RunningTime
                    }).ToList()
                ;

            var enumerableMovies = movies.ToList();
            FinaliseSearchResponse(enumerableMovies);

            enumerableMovies = enumerableMovies.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).Take(5)
                .ToList();

            return enumerableMovies;
        }
        
        private void FinaliseSearchResponse(IReadOnlyCollection<SearchResponse> enumerableMovies)
        {
            var movieIds = enumerableMovies.Select(x => x.Id).ToList();
            var relevantGenres = _context.MovieGenres.Include(x=>x.Genre).Where(x => movieIds.Contains(x.MovieId)).ToList();

            foreach (var movie in enumerableMovies)
            {
                var genresForMovie = string.Join(",", relevantGenres.Where(x => x.MovieId == movie.Id).Select(x => x.Genre.Name)
                    .OrderBy(x => x).ToList());

                movie.Genres = genresForMovie;
                movie.AverageRating = movie.AverageRating.RoundToNearestHalf();
            }
        }
    }
}
