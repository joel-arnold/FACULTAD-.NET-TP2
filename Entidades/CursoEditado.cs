using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CursoEditado : Entidad
    {
        int _AnioCalendario, _Cupo, _IDComision, _IDMateria;
        string _Descripcion, _Comision, _Materia;

        public int AnioCalendario { get { return _AnioCalendario; } set { _AnioCalendario = value; } }
        public int Cupo { get { return _Cupo; } set { _Cupo = value; } }
        public int IDComision { get { return _IDComision; } set { _IDComision = value; } }
        public int IDMateria { get { return _IDMateria; } set { _IDMateria = value; } }
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public string Comision { get { return _Comision; } set { _Comision = value; } }
        public string Materia { get { return _Materia; } set { _Materia = value; } }
    }
}
