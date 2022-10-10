using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TPFINALVocosArriganiFacundoNatanael
{
    public class EmpleadoConexion
    {
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion.ConnectionString = "data source=DESKTOP-TMJ8SA7; initial catalog=EMPLEADOS_DB; integrated security=true";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select * from Empleados";
            comando.Connection = conexion;

            conexion.Open();
            reader = comando.ExecuteReader();
            
            while (reader.Read())
            {
                Empleado aux = new Empleado();
                aux.Id = reader.GetInt32(0);
                aux.NombreCompleto = reader.GetString(1);
                aux.DNI = reader.GetString(2);
                aux.Edad = reader.GetInt32(3);
                aux.Casado = reader.GetBoolean(4);
                aux.Salario = reader.GetDecimal(5);

                listaEmpleados.Add(aux);
            }

            conexion.Close();
            return listaEmpleados;
        }
    }
}
