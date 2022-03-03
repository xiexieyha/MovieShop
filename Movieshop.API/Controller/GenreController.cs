using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
namespace Movieshop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;
        public GenreController(IGenreService gen)
        {
            genreService = gen;
        }

        [Route("list")]
        public IActionResult GetAll()
        {
            var data = genreService.GetAllGenres();
            if (data == null)
            {
                return NotFound("No Genre available");
            }
            return Ok(data);
        }

        [HttpPost]
        
        public IActionResult Post(GenreModel model)
        {
            if (genreService.InsertGenre(model) >0)
                return Ok(model);
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (genreService.DeleteGenre(id) > 0)
                return Ok("Genre is deleted");
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(GenreModel m)
        {
            if (genreService.UpdateGenre(m) > 0)
                return Ok("Genre is updated");
            return NoContent();
        }
    }
}
