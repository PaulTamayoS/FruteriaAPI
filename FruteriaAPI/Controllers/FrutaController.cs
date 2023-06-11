using FruteriaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrutaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Fruta myFruta)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Fruta myFruta) 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
