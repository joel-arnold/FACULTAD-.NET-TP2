using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personas : Entidad
    {
        string _Apellido, _Direccion, _Email, _Nombre, _Telefono;
        DateTime _FechaNacimiento;
        int _IDPlan, _Legajo;

        public string Apellido { get { return _Apellido; } set { _Apellido = value; } }
        public string Direccion { get { return _Direccion; } set { _Direccion = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public string Telefono { get { return _Telefono; } set { _Telefono = value; } }
        public DateTime FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }
        public int Legajo { get { return _Legajo; } set { _Legajo = value; } }
    }
}
