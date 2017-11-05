using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InscripcionesEditado : Entidad
    {
        string _Condicion, _Materia, _Comision, _Alumno;
        int _Nota;

        public string Condicion { get { return _Condicion; } set { _Condicion = value; } }
        public string Comision { get { return _Comision; } set { _Comision = value; } }
        public string Materia { get { return _Materia; } set { _Materia = value; } }
        public int Nota { get { return _Nota; } set { _Nota = value; } }
        public string Alumno { get { return _Alumno; } set { _Alumno = value; } }
    }
}