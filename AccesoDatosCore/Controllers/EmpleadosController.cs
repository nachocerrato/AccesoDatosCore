using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {

        public EmpleadosController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
