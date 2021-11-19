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
    public class EmpleadosOficiosController : Controller
    {
        EmpleadosContext context;

        public EmpleadosOficiosController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> oficios = this.context.GetOficios();
            ViewBag.Oficios = oficios;
            return View();
        }

        [HttpPost]

        public IActionResult Index(String oficio)
        {
            List<Empleado> empleados = this.context.GetEmpleadosOficio(oficio);
            List<String> oficios = this.context.GetOficios();
            ViewBag.Oficios = oficios;
            return View(empleados);
        }
    }
}
