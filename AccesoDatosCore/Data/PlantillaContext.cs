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
            this.cn.Open();
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

        public List<Plantilla> GetPlantillaTurno(String turno)
        {
            String sql = "select * from plantilla where t = @turno";
            this.com.CommandText = sql;
            SqlParameter pamturno = new SqlParameter("@turno", turno);
            this.com.Parameters.Add(pamturno);
            this.cn.Open();
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
            this.com.Parameters.Clear();

            if(plantillas.Count == 0)
            {
                return null;
            }
            else
            {
                return plantillas;
            }
        }

        public List<String> GetFunciones()
        {
            String sql = "select distinct funcion from plantilla";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<String> funciones = new List<string>();

            while (this.reader.Read())
            {
                funciones.Add(this.reader["FUNCION"].ToString());
            }

            this.reader.Close();
            this.cn.Close();

            if (funciones.Count == 0)
            {
                return null;
            }
            else
            {
                return funciones;
            }

        }

        public List<Plantilla> GetPlantillaFunciones(String funcion)
        {
            String sql = "select * from plantilla where funcion=@funcion";
            this.com.CommandText = sql;

            SqlParameter pamfuncion = new SqlParameter("@funcion", funcion);
            this.com.Parameters.Add(pamfuncion);
            this.cn.Open();

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
            this.com.Parameters.Clear();
            this.reader.Close();

            return plantillas;
        }

        public int IncrementarSalarioEmpleadoFuncion(String funcion, int incremento)
        {
            String sql = "update plantilla set salario = salario + @incremento" +
                " where funcion = @funcion";
            this.com.CommandText = sql;

            SqlParameter pamincremento = new SqlParameter("@incremento", incremento);
            SqlParameter pamfuncion = new SqlParameter("@funcion", funcion);


            this.com.Parameters.Add(pamincremento);
            this.com.Parameters.Add(pamfuncion);

            this.cn.Open();


            int resultado = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();

            return resultado;
        }
    }
}
