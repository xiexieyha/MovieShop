using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostUserPurchase()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostUserFavorite()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostUserUnfavorite()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetUserFavorite(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostReview()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateReview()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetUserPurchases(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetUserFavorites(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetUserReviews(int id)
        {
            throw new NotImplementedException();
        }
    }
}
