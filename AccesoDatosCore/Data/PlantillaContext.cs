using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Data
{
    public class PlantillaContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillaContext(string cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Plantilla> GetPlantilla()
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

            return plantillas;
        }
    }
}
