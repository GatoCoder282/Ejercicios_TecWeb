using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraining.Models;

namespace WebApplicationTraining.Controllers.ControllersPOO
{
    [Route("api/[controller]")]
    [ApiController]
    public class POOController : ControllerBase
    {

        private readonly ICalculadora _calculadora;
        public POOController(ICalculadora calculadora)
        {
            _calculadora = calculadora;
        }

        [HttpGet("productos")]
        public IActionResult GetProductos()
        {
            var productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Laptop", Precio = 1500.99m },
                new Producto { Id = 2, Nombre = "Mouse", Precio = 25.50m },
                new Producto { Id = 3, Nombre = "Teclado", Precio = 45.00m }
            };

            return Ok(productos);
        }

        [HttpGet("empleados")]
        public IActionResult GetEmpleados()
        {
            var empleados = new List<Empleado>
            { new Empleado
             {
                 ci = 123456,
                 nombre = "Ana",
                 apellido = "López",
                 sueldo = 2500,
                 cargo = "Analista",
                 jefe = "Carlos"
             },
                new Gerente
                {
                    ci = 654321,
                    nombre = "Pedro",
                    apellido = "Ramírez",
                    sueldo = 5000,
                    cargo = "Gerente General",
                    departamento = "Operaciones"
                }
            };

        var info = empleados.Select(e => e.ObtenerInformacion()).ToList();

            return Ok(info);
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] OperationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Operacion))
                return BadRequest("Datos inválidos.");

            int resultado;

            switch (request.Operacion.ToLower())
            {
                case "sumar":
                    resultado = _calculadora.Sumar(request.A, request.B);
                    break;
                case "restar":
                    resultado = _calculadora.Restar(request.A, request.B);
                    break;
                default:
                    return BadRequest("Operación no soportada. Use 'sumar' o 'restar'.");
            }

            return Ok(new { resultado });
        }
    }
}
