using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Controllers
{
    public class EliminarEnfermosController : Controller
    {
        EnfermosContext context;

        public EliminarEnfermosController(EnfermosContext context)
        {
            this.context = context;
        }

        public IActionResult EliminarEnfermosGet(String nss)
        {
            //los parámetros opcionales los recibiremos como string aunque sean números
            if(nss != null)
            {
                int eliminados = this.context.EliminaEnfermo(int.Parse(nss));
            }

            List<Enfermo> enfermos = this.context.GetEnfermos();
            return View(enfermos);
        }
        //public IActionResult EliminarEnfermosGet()
        //{
        //    List<Enfermo> enfermos = this.context.GetEnfermos();
        //    return View(enfermos);
        //}

        public IActionResult EliminarEnfermosFormulario()
        {
            List<Enfermo> enfermos = this.context.GetEnfermos();
            return View(enfermos);
        }

        [HttpPost]
        public IActionResult EliminarEnfermosFormulario(int nss)
        {
            int resultado = this.context.EliminaEnfermo(nss);
            List<Enfermo> enfermos = this.context.GetEnfermos();
            ViewBag.Enfermos = enfermos;


            return View(enfermos);
        }
    }
}
