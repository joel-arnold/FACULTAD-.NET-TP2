using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Util
{
    public static class Validacion
    {
        public static bool esMailValido(string correoIngresado)
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

        public static bool esClaveValida(string claveIngresada)
        {
            if (claveIngresada.Length < 8) return false; else return true;
        }

        public static bool clavesCoinciden(string clave1, string clave2)
        {
            if (clave1.Equals(clave2)) return true; else return false;
        }

        public static bool esPrivilegioValido(string PrivilegioIngresado)
        {
            if(PrivilegioIngresado == "admin" || PrivilegioIngresado == "invitado")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}