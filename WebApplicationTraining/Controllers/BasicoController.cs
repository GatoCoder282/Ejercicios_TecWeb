using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicoController : ControllerBase
    {
        [HttpGet("saludo")]
        public IActionResult GetSaludo()
        {
            return Ok("Hola, mundo");
        }

        [HttpGet("sumar/{a}/{b}")] 
        public IActionResult Sumar(int a, int b) 
        { 
            int resultado = a + b; 
            return Ok(resultado); 
        }
    }
}
