using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationTraining.Models
{
    public class Empleado : Persona
    {
        public int sueldo { get; set; }
        public string cargo { get; set; }
        public string jefe {  get; set; }

        public virtual string ObtenerInformacion()
        {
            return $"{nombre} {apellido} - Cargo: {cargo}, Sueldo: {sueldo}, Jefe: {jefe}";
        }
    }

}
