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
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillaController()
        {
            this.cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            this.cn = new SqlConnection(this.cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public IActionResult Index()
        {
            String sql = "select * from plantilla";
            cn.Open();
            this.com.CommandText = sql;
            this.reader = this.com.ExecuteReader();

            List<Plantilla> plantillas = new List<Plantilla>();

            while (this.reader.Read())
            {
                Plantilla plantilla = new Plantilla();
                plantilla.Apellido = this.reader["APELLIDO"].ToString();
                plantilla.Funcion = this.reader["FUNCION"].ToString();
                plantilla.Salario = int.Parse(this.reader["SALARIO"].ToString());

                plantillas.Add(plantilla);
            }


            this.cn.Close();
            this.reader.Close();

            return View(plantillas);
        }
    }
}
