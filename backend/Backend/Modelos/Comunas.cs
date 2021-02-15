using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Comunas
    {
        public int CodComuna { get; set; }
        public string Nombre { get; set; }
        public Regiones Region { get; set; }
    }
}
