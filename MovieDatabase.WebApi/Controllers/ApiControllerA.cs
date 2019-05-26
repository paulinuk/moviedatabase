using MovieDatabase.Services.Interfaces;

namespace MovieDatabase.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Catel;
    using Microsoft.AspNetCore.Mvc;
    using Common.Models;

    [Route("/api/[controller]")]
    [ApiController]
    public class ApiControllerA: ControllerBase
    {
        private readonly IMovieService _movieService;

        [HttpPost]
        [Route("search")]
        [ActionName("search")]
        public async Task<ActionResult<IEnumerable<SearchResponse>>> SearchAsync([FromBody] SearchCriteria searchCriteria)
        {
            if (searchCriteria.IsValid == false)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var result = await _movieService.SearchAsync(searchCriteria).ConfigureAwait(false);
            
            if (result.Any() == false)
                return StatusCode((int)HttpStatusCode.NotFound);
            
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        
        public ApiControllerA(IMovieService movieService)
        {
            Argument.IsNotNull(() => movieService);
            _movieService = movieService;
        }

    }
}
