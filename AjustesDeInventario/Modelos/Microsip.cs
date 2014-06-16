using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjustesDeInventario.Modelos
{
    public class Microsip
    {
        public string Sucusal { set; get; }
        public string Usuario { set; get; }
        public string Contraseña { set; get; }
        public string BaseDeDatos { set; get; }        
        public int Puerto { set; get; }
    }
}
