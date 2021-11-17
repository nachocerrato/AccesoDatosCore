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
    public class MaestroDetalleEmpleadosController : Controller
    {
        EmpleadosContext context;

        public MaestroDetalleEmpleadosController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult DatosEmpleados()
        {
            List<Empleado> empleados = this.context.GetEmpleados();

            return View(empleados);
        }

        public IActionResult DetallesEmpleado(int idempleado)
        {
            Empleado empleado = context.BuscarEmpleado(idempleado);
            return View(empleado);
        }
    }
}
