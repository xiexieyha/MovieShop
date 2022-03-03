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
    public class AdminController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostMovie()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateMovie()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetPurchases()
        {
            throw new NotImplementedException();
        }
    }
}
