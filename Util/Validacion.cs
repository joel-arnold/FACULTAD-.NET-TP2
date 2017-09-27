using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Util
{
    public class Validacion
    {
        public bool esMailValido(string correoIngresado)
        {
            string expresionCorrecta = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(correoIngresado, expresionCorrecta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool esClaveValida(string claveIngresada)
        {
            if (claveIngresada.Length < 8) return false; else return true;
        }

        public bool clavesCoinciden(string clave1, string clave2)
        {
            if (clave1.Equals(clave2)) return true; else return false;
        }
    }
}