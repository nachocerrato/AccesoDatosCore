using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Data
{
    public class EmpleadosContext
    {
        //aquí declaramos los objetos de acceso a datos
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        //en el constructor creamos los objetos de acceso a datos
        //para construir un contexto, deben darme la cadena de conexión
        public EmpleadosContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //aquí tendríamos todos los métodos que vayamos a realizar sobre la BBDD
        //en este ejemplo, queremos un método que devuelva los empleados

        public List<Empleado> GetEmpleados()
        {
            string sql = "select * from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            //vamos a leer un conjunto de empleados, crearemos una colección de empleados
            List<Empleado> empleados = new List<Empleado>();
            //comenzamos a leer registros
            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();

                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Salario = (int)this.reader["SALARIO"];
                empleado.Oficio = this.reader["OFICIO"].ToString();

                //añadimos cada empleado a la lista
                empleados.Add(empleado);
            }

            this.cn.Close();
            this.reader.Close();

            return empleados;
        }
    }
}
