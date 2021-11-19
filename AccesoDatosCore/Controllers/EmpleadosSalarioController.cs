using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Data;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosSalarioController : Controller
    {
        EmpleadosContext context;

        public EmpleadosSalarioController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Index(int salario)
        {
            List<Empleado> empleados = this.context.GetEmpleadosSalario(salario);
            return View(empleados);
        }
    }
}
