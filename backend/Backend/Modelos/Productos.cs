using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public Clasificaciones Clasificaciones { get; set; }

        public Productos()
        {
            Clasificaciones = new Clasificaciones();
        }
    }
}
