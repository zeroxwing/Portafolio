using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Comunas Comuna { get; set; }
        public Regiones Region { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }

        public Usuarios()
        {
            Comuna = new Comunas();
            Region = new Regiones();
        }
    }
}
