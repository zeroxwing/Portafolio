using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class DetallesP
    {
        public Productos Producto { get; set; }
        public Tiendas Tienda { get; set; }
        public string Sku { get; set; }
        public string Stock { get; set; }
        public int PrecioU { get; set; }
    }
}
