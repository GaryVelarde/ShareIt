using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ShareIt
    {

        public List<Entidad.ResultadoSql> d_registrarPublicacion(SqlConnection con, Int64 usuarioId, string descripcion, string privacidad)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_registrarPublicacion", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@privacidadId", privacidad);

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

        public List<Entidad.Privacidad> d_listarPrivacidad(SqlConnection con)
        {
            List<Entidad.Privacidad> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_listarPrivacidad", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {

                int posprivacidadId = drd.GetOrdinal("privacidadId");
                int posdescripcion = drd.GetOrdinal("descripcion");
                int posselected = drd.GetOrdinal("selected");

                Entidad.Privacidad clbEtr;
                lbeUsu = new List<Entidad.Privacidad>();
                while (drd.Read())
                {
                    clbEtr = new Entidad.Privacidad();
                    clbEtr.privacidadId = drd.GetInt32(posprivacidadId);
                    clbEtr.descripcion = drd.GetString(posdescripcion);
                    clbEtr.selected = drd.GetString(posselected);

                    lbeUsu.Add(clbEtr);
                }
                drd.Close();
            }
            return (lbeUsu);
        }

        public List<Entidad.Publicacion> d_listarTopPublicaciones(SqlConnection con)
        {
            List<Entidad.Publicacion> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_listarTopPublicaciones", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {

                int pospublicacionId = drd.GetOrdinal("publicacionId");
                int posnombres = drd.GetOrdinal("nombres");
                int posavatar = drd.GetOrdinal("avatar");
                int posdescripcion = drd.GetOrdinal("descripcion");
                int poscantLikes = drd.GetOrdinal("cantLikes");
                int poscantComentarios = drd.GetOrdinal("cantComentarios");
                int posfechaCreacion = drd.GetOrdinal("fechaCreacion");

                Entidad.Publicacion clbEtr;
                lbeUsu = new List<Entidad.Publicacion>();
                while (drd.Read())
                {
                    clbEtr = new Entidad.Publicacion();
                    clbEtr.publicacionId = drd.GetInt64(pospublicacionId);
                    clbEtr.nombres = drd.GetString(posnombres);
                    clbEtr.avatar = drd.GetString(posavatar);
                    clbEtr.descripcion = drd.GetString(posdescripcion);
                    clbEtr.cantLikes = drd.GetInt64(poscantLikes);
                    clbEtr.cantComentarios = drd.GetInt64(poscantComentarios);
                    clbEtr.fechaCreacion = drd.GetDateTime(posfechaCreacion);

                    lbeUsu.Add(clbEtr);
                }
                drd.Close();
            }
            return (lbeUsu);
        }

        public List<Entidad.Publicacion> d_listarPublicaciones(SqlConnection con, Int64 usuarioId)
        {
            List<Entidad.Publicacion> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_listarPublicaciones", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {

                int pospublicacionId = drd.GetOrdinal("publicacionId");
                int posnombres = drd.GetOrdinal("nombres");
                int posavatar = drd.GetOrdinal("avatar");
                int posdescripcion = drd.GetOrdinal("descripcion");
                int poscantLikes = drd.GetOrdinal("cantLikes");
                int poscantComentarios = drd.GetOrdinal("cantComentarios");
                int posfechaCreacion = drd.GetOrdinal("fechaCreacion");
                int posarchivos = drd.GetOrdinal("archivos");
                int posmeGusta = drd.GetOrdinal("meGusta");

                Entidad.Publicacion clbEtr;
                lbeUsu = new List<Entidad.Publicacion>();
                while (drd.Read())
                {
                    clbEtr = new Entidad.Publicacion();
                    clbEtr.publicacionId = drd.GetInt64(pospublicacionId);
                    clbEtr.nombres = drd.GetString(posnombres);
                    clbEtr.avatar = drd.GetString(posavatar);
                    clbEtr.descripcion = drd.GetString(posdescripcion);
                    clbEtr.cantLikes = drd.GetInt64(poscantLikes);
                    clbEtr.cantComentarios = drd.GetInt64(poscantComentarios);
                    clbEtr.fechaCreacion = drd.GetDateTime(posfechaCreacion);
                    clbEtr.archivos = drd.GetString(posarchivos);
                    clbEtr.meGusta = drd.GetString(posmeGusta);

                    lbeUsu.Add(clbEtr);
                }
                drd.Close();
            }
            return (lbeUsu);
        }

        public List<Entidad.ResultadoSql> d_actualizarLike(SqlConnection con, string tipoLike, Int64 publicacionId, Int64 usuarioId)
        {
            List<Entidad.ResultadoSql> lbeUsu = null;

            SqlCommand cmd = new SqlCommand("sp_actualizarLike", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipoLike", tipoLike);
            cmd.Parameters.AddWithValue("@publicacionId", publicacionId);
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

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
