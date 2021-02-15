using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Procesos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Search : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Productos> Buscar(string e)
        {
            return BusquedaProductos.Busqueda(e);
        }
    }
}
