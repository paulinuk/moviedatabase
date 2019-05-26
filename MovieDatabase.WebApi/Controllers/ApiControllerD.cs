using System.Threading.Tasks;
using MovieDatabase.Services;
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
    public class ApiControllerD : ControllerBase
    {
        private readonly IRatingService _ratingService;
        
        [HttpGet]
        [Route("addorupdaterating")]
        [ActionName("addorupdaterating")]
        public async Task<ActionResult> AddOrUpdateRatingAsync(int movieId, int userId, decimal rating)
        {
            if (rating < 1 || rating > 5)
                return StatusCode((int) HttpStatusCode.BadRequest);

            var result = await _ratingService.AddOrUpdateRatingAsync(movieId, userId, rating).ConfigureAwait(false);

            if (result == null)
                return StatusCode((int) HttpStatusCode.NotFound);

            return StatusCode((int)HttpStatusCode.OK);
        }

        public ApiControllerD(IRatingService ratingService, IMovieService movieService)
        {
            Argument.IsNotNull(() => ratingService);
            _ratingService = ratingService;
        }
    }
}
