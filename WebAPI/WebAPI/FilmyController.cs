using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmyController : ControllerBase
    {
        private readonly IDataService _dataService;
        public FilmyController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            var filmy = await _dataService.GetFilmyDataAsync();
            return Ok(filmy);
        }

        [HttpGet("lista/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filmy = await _dataService.GetFilmyDataByIdAsync(id);
            if (filmy == null)
            {
                return NotFound();
            }
            return Ok(filmy);
        }

        [HttpPost("formularz")]
        public async Task<IActionResult> Post([FromBody] NewFilmyDto newFilmyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _dataService.PostFormularzDataAsync(newFilmyDto);

            if (success)
            {
                return Ok(new { message = "Film został pomyślnie dodany z formularza." });
            }

            return BadRequest("Wystąpił błąd podczas dodawania filmu.");
        }

        [HttpPut("formularz")]
        public async Task<IActionResult> Put([FromBody] FilmyDto filmyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _dataService.PutFormularzDataAsync(filmyDto);

            if (success)
            {
                return Ok(new { message = "Film został pomyślnie zaktualizowany." });
            }

            return BadRequest("Wystąpił błąd podczas edycji filmu.");
        }
    }
}
