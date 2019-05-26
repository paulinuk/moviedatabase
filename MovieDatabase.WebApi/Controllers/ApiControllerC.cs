using MovieDatabase.Services.Interfaces;

namespace MovieDatabase.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using Catel;
    using Microsoft.AspNetCore.Mvc;
    using Common.Models;

    [Route("/api/[controller]")]
    [ApiController]
    public class ApiControllerC : ControllerBase
    {
        private readonly IMovieService _movieService;

        [Route("top5averageratingsbyuser")]
        [ActionName("top5averageratingsbyuser")]
        public ActionResult<IEnumerable<SearchResponse>> Top5AverageRatingsByUser(int userId)
        {
            var result = _movieService.GetTop5ByAverageRatings(userId);

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        public ApiControllerC(IMovieService movieService)
        {
            Argument.IsNotNull(() => movieService);
            _movieService = movieService;
        }
    }
}
