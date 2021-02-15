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
    public class Register : ControllerBase
    {
        [HttpPost]
        public string Registrar(Usuarios u)
        {
            string a = null;
            if (Registro.Register(u))
            {
                a = "Usuario registrado exitosamente";
            }
            else
            {
                a = "Error en registro de usuario";
            }
            return a;
        }
    }
}
