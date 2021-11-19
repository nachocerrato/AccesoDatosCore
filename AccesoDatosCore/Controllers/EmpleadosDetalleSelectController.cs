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
    public class EmpleadosDetalleSelectController : Controller
    {
        EmpleadosContext context;

        public EmpleadosDetalleSelectController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Empleado> empleados = this.context.GetEmpleados();
            ViewBag.Empleados = empleados;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int idempleado)
        {
            Empleado empleado = this.context.BuscarEmpleado(idempleado);
            List<Empleado> empleados = this.context.GetEmpleados();
            ViewBag.Empleados = empleados;
            return View(empleado);
        }
    }
}
