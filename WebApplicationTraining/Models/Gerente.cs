using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationTraining.Models
{
    public class Gerente : Empleado
    {
        public string departamento { get; set; }

        public override string ObtenerInformacion()
        {
            return $"{nombre} {apellido} - Gerente de {departamento}, Sueldo: {sueldo}";
        }
    }
}
