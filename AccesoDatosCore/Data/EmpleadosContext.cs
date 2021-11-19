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

        public Empleado BuscarEmpleado(int idempleado)
        {
            string sql = "select * from emp where emp_no=@empno";
            this.com.CommandText = sql;
            SqlParameter pamempno = new SqlParameter("@empno", idempleado);
            this.com.Parameters.Add(pamempno);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            Empleado empleado;
            if (this.reader.Read())
            {
                empleado = new Empleado();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
                empleado.Oficio = this.reader["OFICIO"].ToString();
            }
            else
            {
                empleado = null;
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();

            return empleado;

        }

        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            String sql = "select * from emp where salario > @salario";
            this.com.CommandText = sql;
            SqlParameter pamsalario = new SqlParameter("@salario", salario);
            this.com.Parameters.Add(pamsalario);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();

            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = int.Parse(this.reader["SALARIO"].ToString());

                empleados.Add(empleado);
            }

            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();

            if (empleados.Count == 0)
            {
                return null;
            }
            else
            {
                return empleados;
            }
        }
    
        public List<String> GetOficios()
        {
            String sql = "select distinct oficio from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();


            List<String> oficios = new List<string>();
            while (this.reader.Read())
            {
                String oficio = this.reader["OFICIO"].ToString();
                oficios.Add(oficio);
            }


            this.reader.Close();
            this.cn.Close();

            return oficios;
        }

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            String sql = "select * from emp where oficio = @oficio";
            this.com.CommandText = sql;
            this.cn.Open();
            SqlParameter pamoficio = new SqlParameter("@oficio", oficio);
            this.com.Parameters.Add(pamoficio);
            this.reader = this.com.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();

            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = int.Parse(this.reader["SALARIO"].ToString());

                empleados.Add(empleado);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();

            if(empleados.Count == 0)
            {
                return null;
            }
            else
            {
                return empleados;
            }
        }

        public List<String> GetApellidos()
        {
            String sql = "selct apellido from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<String> apellidos = new List<string>();

            while (this.reader.Read())
            {
                apellidos.Add(this.reader["APELLIDO"].ToString());
            }


            this.cn.Close();
            this.reader.Close();

            if (apellidos.Count == 0)
            {
                return null;
            }
            else
            {
                return apellidos;
            }

        }

        public int IncrementarSalarioEmpleado (int idempleado, int incremento)
        {
            String sql = "update emp set salario = salario + @incremento"
                        + " where emp_no = @idempleado";
            this.com.CommandText = sql;
            SqlParameter pamincremento = new SqlParameter("@incremento", incremento);
            SqlParameter pamidempleado = new SqlParameter("@idempleado", idempleado);

            this.com.Parameters.Add(pamincremento);
            this.com.Parameters.Add(pamidempleado);


            this.cn.Open();
            
            int resultado = this.com.ExecuteNonQuery();


            this.cn.Close();
            this.com.Parameters.Clear();

            return resultado;
        }

        public int IncrementarSalarioEmpleadoFuncion(String funcion, int incremento)
        {
            String sql = "update emp set salario = salario + @incremento"
                        + " where funciona = @funcion";
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
