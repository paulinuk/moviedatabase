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
    public class ApiControllerB : ControllerBase
    {
        private readonly IMovieService _movieService;
        
        [Route("top5averageratings")]
        [ActionName("top5averageratings")]
        public ActionResult<IEnumerable<SearchResponse>> Top5AverageRatings()
        {
            var result = _movieService.GetTop5ByAverageRatings();
            
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        public ApiControllerB(IMovieService movieService)
        {
            Argument.IsNotNull(() => movieService);
            _movieService = movieService;
        }
    }
}
