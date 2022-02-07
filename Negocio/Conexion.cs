using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Conexion
    {
        public string Cadena { get; set; }
        public Conexion()
        {
            Cadena = ConfigurationManager.ConnectionStrings["conex"].ConnectionString;
        }
    }
}
