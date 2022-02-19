using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Login
    {

        public List<Entidad.ResultadoSql> d_registrarUsuario(SqlConnection con, string nombres, string apellidos, string correo,
            string clave, DateTime fechaNacimiento, string celular)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_registrarUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombres", nombres);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@clave", clave);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@celular", celular);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {

                int posCodigo = drd.GetOrdinal("Codigo");
                int posMensaje = drd.GetOrdinal("Mensaje");
                int posDatos = drd.GetOrdinal("Datos");

                Entidad.ResultadoSql clbEtr;
                lbeUsu = new List<Entidad.ResultadoSql>();
                while (drd.Read())
                {
                    clbEtr = new Entidad.ResultadoSql();
                    clbEtr.Codigo = drd.GetString(posCodigo);
                    clbEtr.Mensaje = drd.GetString(posMensaje);
                    clbEtr.Datos = drd.GetString(posDatos);
                    
                    lbeUsu.Add(clbEtr);
                }
                drd.Close();
            }

            return (lbeUsu);
        }

        public List<Entidad.ResultadoSql> d_validarUsuario(SqlConnection con, string correo, string clave)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_validarUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@clave", clave);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {

                int posCodigo = drd.GetOrdinal("Codigo");
                int posMensaje = drd.GetOrdinal("Mensaje");
                int posDatos = drd.GetOrdinal("Datos");

                Entidad.ResultadoSql clbEtr;
                lbeUsu = new List<Entidad.ResultadoSql>();
                while (drd.Read())
                {
                    clbEtr = new Entidad.ResultadoSql();
                    clbEtr.Codigo = drd.GetString(posCodigo);
                    clbEtr.Mensaje = drd.GetString(posMensaje);
                    clbEtr.Datos = drd.GetString(posDatos);

                    lbeUsu.Add(clbEtr);
                }
                drd.Close();
            }

            return (lbeUsu);
        }

    }
}
