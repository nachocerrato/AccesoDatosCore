using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class PlantillaController : Controller
    {
        PlantillaContext context;

        public PlantillaController(PlantillaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantillas = this.context.GetPlantilla();

            return View(plantillas);
        }
    }
}
