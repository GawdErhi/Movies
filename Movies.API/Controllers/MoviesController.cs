using Microsoft.AspNetCore.Mvc;
using Movies.API.DTOs;
using Movies.API.HelperModels;
using Movies.API.Services.Contracts;
using ILogger = Movies.API.Services.Contracts.ILogger;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IOMDBService _omdbService;
        private readonly ILogger _logger;
        public MoviesController(IOMDBService omdbService, ILogger logger)
        {
            _omdbService = omdbService;
            _logger = logger;
        }

        [HttpGet("search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
            try
            {
                return Ok(new APIResponseModel<dynamic> { Message = "Success", Data = await _omdbService.SearchMovie(title) });
            } catch (Exception exception)
            {
                _logger.Error(exception.Message, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<dynamic> { Error = true, Message = "Something went wrong, please try again later.", Data = null });
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                return Ok(new APIResponseModel<MovieDetailDTO> { Message = "Success", Data = await _omdbService.GetMovie(id) });
            }catch(Exception exception)
            {
                _logger.Error(exception.Message, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<dynamic> { Error = true, Message = "Something went wrong, please try again later.", Data = null });
            }
        }
    }
}
