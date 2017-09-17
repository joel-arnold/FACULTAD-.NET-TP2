using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan : Entidad
    {
        string _Descripcion;
        int _IDEspecialidad;

        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public int IDEspecialidad { get { return _IDEspecialidad; } set { _IDEspecialidad = value; } }
    }
}
