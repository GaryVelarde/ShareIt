using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Publicacion
    {

		public Int64 publicacionId { get; set; }
		public Int64 usuarioId { get; set; }
		public string descripcion { get; set; }
		public Int64 privacidadId { get; set; }
		public Int64 cantLikes { get; set; }
		public Int64 cantComentarios { get; set; }
		public string estado { get; set; }
		public DateTime fechaCreacion { get; set; }
		public string nombres { get; set; }
		public string avatar { get; set; }

	}
}
