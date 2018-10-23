using System;
using CityInfoAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
	public class DummyController : Controller
    {
        private CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
