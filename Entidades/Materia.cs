using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia : Entidad
    {
        string _Descripcion;
        int _HSSemanales, _HSTotales, _IDPlan;

        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public int HSSemanales { get { return _HSSemanales; } set { _HSSemanales = value; } }
        public int HSTotales { get { return _HSTotales; } set { _HSTotales = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }
    }
}
