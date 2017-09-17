using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision : Entidad
    {
        int _AnioEspecialidad, _IDPlan;
        string _Descripcion;

        public int AnioEspecialidad { get { return _AnioEspecialidad; } set { _AnioEspecialidad = value; } }
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }
    }
}
