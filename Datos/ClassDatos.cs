using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidad;

namespace Datos
{
    public class ClassDatos
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable listar_clientes()
        {
            SqlCommand cmd = new SqlCommand("listar_clientes", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable find_clientes(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("buscar_clientes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public String mantenimiento_clientes(ClassEntidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("mantenimiento_clientes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", obje.ID);
            cmd.Parameters.AddWithValue("@Nombre", obje.Nombre);
            cmd.Parameters.AddWithValue("@Edad", obje.Edad);
            cmd.Parameters.AddWithValue("@Telefono", obje.Telefono);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (connection.State == ConnectionState.Open) connection.Close();
            connection.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            connection.Close();
            return accion;
        }
    }
}
