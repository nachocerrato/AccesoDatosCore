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
    public class PlantillaTurnoController : Controller
    {
        PlantillaContext context;

        public PlantillaTurnoController(PlantillaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(String turno)
        {
            List<Plantilla> plantillas = this.context.GetPlantillaTurno(turno);
            return View(plantillas);
        }
    }
}
