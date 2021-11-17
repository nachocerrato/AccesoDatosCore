using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class Bici1Controller : Controller
    {
        private Bicicleta bici;
        public Bici1Controller(Bicicleta bici)
        {
            this.bici = bici;
        }

        //GET
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.bici);
        }

        //HTTPOST
        [HttpPost]
        public IActionResult Index(String accion)
        {
            if (accion == "acelerar")
            {
                this.bici.Acelerar();
            }
            else
            {
                this.bici.Frenar();
            }
            return View(this.bici);
        }
    }
}
