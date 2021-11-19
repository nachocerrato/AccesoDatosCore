using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class IncrementoPlantillaFuncionController : Controller
    {
        PlantillaContext context;

        public IncrementoPlantillaFuncionController(PlantillaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> funciones = this.context.GetFunciones();
            ViewBag.Funciones = funciones;
            return View();
        }

        [HttpPost]
        public IActionResult Index(String funcion, int incremento)
        {
            List<String> funciones = this.context.GetFunciones();
            ViewBag.Funciones = funciones;

            int resultado = this.context.IncrementarSalarioEmpleadoFuncion(funcion, incremento);

            List<Plantilla> plantillas = this.context.GetPlantillaFunciones(funcion);
            ViewBag.Mensaje = "Empleados modificados: " + resultado;

            return View(plantillas);
        }
    }
}
