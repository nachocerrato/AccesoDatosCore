using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EnfermosContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public EnfermosContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Enfermo> GetEnfermos()
        {
            String sql = "select * from enfermo";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();

            List<Enfermo> enfermos = new List<Enfermo>();

            while (this.reader.Read())
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Apellido = this.reader["APELLIDO"].ToString();
                enfermo.Direccion = this.reader["DIRECCION"].ToString();
                enfermo.Nss = int.Parse(this.reader["NSS"].ToString());

                enfermos.Add(enfermo);
            }

            this.cn.Close();
            this.reader.Close();

            if(enfermos.Count == 0)
            {
                return null;
            }
            else
            {
                return enfermos;
            }

        }

        public int EliminaEnfermo(int nss)
        {
            String sql = "delete from enfermo where nss =@nss";
            this.com.CommandText = sql;
            SqlParameter pamnss = new SqlParameter("@nss", nss);
            this.com.Parameters.Add(pamnss);
            this.cn.Open();

            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            return resultado;
        }
    }
}
