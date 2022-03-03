using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movieshop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public  IActionResult GetCast(int id)
        {
            var cast =  _castService.GetAllCast(id);

            if (cast != null)
            {
                return Ok(cast);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
