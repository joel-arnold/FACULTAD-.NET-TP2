using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Modulo : Entidad
    {
        string _Descripcion;

        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
    }
}
