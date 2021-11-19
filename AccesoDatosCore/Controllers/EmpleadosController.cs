using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;
using AccesoDatosCore.Data;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        //declaramos nuestro objeto context
        EmpleadosContext context;
        public EmpleadosController(EmpleadosContext context)
        {
            this.context = context;
            //String cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            
        }
        public IActionResult Index()
        {
            //utilizamos los métodos que necesitemos
            List<Empleado> empleados = this.context.GetEmpleados();
            return View(empleados);
        }

    }
}
