using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ShareIt : Conexion
    {

        Entidad.ResultadoSql resSql = new Entidad.ResultadoSql();
        Datos.ShareIt log = new Datos.ShareIt();
        public List<Entidad.ResultadoSql> n_registrarPublicacion(Int64 usuarioId, string descripcion, string privacidad)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_registrarPublicacion(con, usuarioId, descripcion, privacidad);
                }
                catch (SqlException ex)
                {
                    //  Log.grabar(ex.ToString(), RutaLog);
                }
            }
            return (lbeUsu);
        }

        public List<Entidad.Privacidad> n_listarPrivacidad()
        {
            List<Entidad.Privacidad> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_listarPrivacidad(con);
                }
                catch (SqlException ex)
                {
                    //  Log.grabar(ex.ToString(), RutaLog);
                }
            }
            return (lbeUsu);
        }

        public List<Entidad.Publicacion> n_listarTopPublicaciones()
        {
            List<Entidad.Publicacion> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_listarTopPublicaciones(con);
                }
                catch (SqlException ex)
                {
                    //  Log.grabar(ex.ToString(), RutaLog);
                }
            }
            return (lbeUsu);
        }

        public List<Entidad.Publicacion> n_listarPublicaciones(Int64 usuarioId)
        {
            List<Entidad.Publicacion> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_listarPublicaciones(con, usuarioId);
                }
                catch (SqlException ex)
                {
                    //  Log.grabar(ex.ToString(), RutaLog);
                }
            }
            return (lbeUsu);
        }

        public List<Entidad.ResultadoSql> n_actualizarLike(string tipoLike, Int64 publicacionId, Int64 usuarioId)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    lbeUsu = log.d_actualizarLike(con, tipoLike, publicacionId, usuarioId);
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
