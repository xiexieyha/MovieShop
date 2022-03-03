
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
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostAccount()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetAccount()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }
    }
}
