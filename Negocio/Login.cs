using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Login : Conexion
    {
        Entidad.ResultadoSql resSql = new Entidad.ResultadoSql();
        Datos.Login log = new Datos.Login();
        public List<Entidad.ResultadoSql> n_registrarUsuario(string nombres, string apellidos, string correo,
            string clave, DateTime fechaNacimiento, string celular)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_registrarUsuario(con, nombres, apellidos, correo, clave, fechaNacimiento, celular);
                }
                catch (SqlException ex)
                {
                    //  Log.grabar(ex.ToString(), RutaLog);
                }
            }
            return (lbeUsu);
        }
    }
}
