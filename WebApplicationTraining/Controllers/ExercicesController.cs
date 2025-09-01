using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Dynamic;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicesController : ControllerBase
    {

        private static Stack<string> pila = new Stack<string>();

        [HttpGet("saludo")]
        public IActionResult GetSaludo()
        {
            return Ok("Hola, mundo");
        }

        [HttpGet("saludoConNombre/{nombre}")]
        public IActionResult GetSaludoConNombre(string nombre)
        {
            return Ok($"Hola, {nombre.Trim()}");
        }

        [HttpGet("sumar/{a}/{b}")]
        public IActionResult Sumar(int a, int b)
        {
            int resultado = a + b;
            return Ok(resultado);
        }

        [HttpGet("par_impar/{numero}")]
        public IActionResult paroImpar(int numero)
        {
            string paroimpar = (numero % 2 == 0) ? "par" : "impar";
            return Ok($"El numero es {paroimpar}");
        }

        [HttpGet("frutasLista1")]
        public IActionResult GetFrutas()
        {
            string[] frutas = { "manzana", "banana", "naranja", "uva", "fresa", "mango", "piña" };
            return Ok(frutas);
        }

        [HttpGet("frutasLista2")]

        public IActionResult GetFrutas2()
        {
            var frutas = new List<string>
            {
                "manzana",
                "banana",
                "naranja",
                "uva",
                "fresa",
                "mango",
                "piña"
            };
                    return Ok(frutas);
        }

        [HttpGet("buscar/{item}")]

        public IActionResult Buscar(string item)
        {
            var electronicos = new List<string>
            {
                "licuadora",
                "sandwichera",
                "horno",
                "cafetera",
                
            };
            var electronicoEcontrado = electronicos.FirstOrDefault(f => f.Equals(item, StringComparison.OrdinalIgnoreCase));
            if (electronicoEcontrado != null)
            {
                return Ok($"El electronico {item} fue encontrado");
            }
            else
            {
                return NotFound($"El electronico {item} no fue encontrado");
            }
        }

        [HttpGet("filtrarNumerosPares")]

        public IActionResult filtrarNumerosPares([FromBody]List<int>numeros)
        {
            if (numeros == null || numeros.Count == 0)
            {
                return BadRequest("Por favor, envíe una lista de números en el body");
            }

            var numerosPares = numeros.Where(n => n % 2 == 0).ToList();

            return Ok(numerosPares);
        }

        [HttpGet("traducir/{palabra}")]
        public IActionResult Traducir(string palabra)
        {
            var traducciones = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"hello", "hola"},
                {"goodbye", "adiós"},
                {"thank you", "gracias"},
                {"please", "por favor"},
                {"yes", "sí"},
                {"no", "no"},
                {"water", "agua"},
                {"food", "comida"},
                {"house", "casa"},
                {"computer", "computadora"}
            };

            if (traducciones.TryGetValue(palabra, out string? palabraTraducida))
            {
                return Ok($"'{palabra}' en español es: {palabraTraducida}");
            }
            else
            {
                return NotFound($"Lo siento, no tengo traducción para '{palabra}'");
            }
        }

        [HttpGet("contarPalabras")]

        public IActionResult contarPalabras([FromBody] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return Ok(0);
            }
            char[] separadores = { ' ', ',', ';', '.', '?', '!' };
            string[] palabras = texto.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            int conteo = palabras.Length;

            return Ok($"Hay {conteo} palabras");
        }

        [HttpPost("pushPila")]
        public IActionResult Push([FromBody] string item)
        {
            pila.Push(item);
            return Ok(new { message = $"Elemento '{item}' agregado a la pila." });
        }

        [HttpPost("popPila")]
        public IActionResult Pop()
        {
            if (pila.Count == 0)
                return BadRequest(new { message = "La pila está vacía. No se puede hacer Pop." });

            var item = pila.Pop();
            return Ok(new { message = $"Elemento '{item}' retirado de la pila." });
        }

        [HttpGet("getPila")]
        public IActionResult GetPila()
        {
            return Ok(pila);
        }
    }
}
