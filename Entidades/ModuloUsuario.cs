using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModuloUsuario : Entidad
    {
        int _IDUsuario, _IDModulo;
        bool _PermiteAlta, _PermiteBaja, _PermiteModificacion, _PermiteConsulta;

        public int IDUsuario { get { return _IDUsuario; } set { _IDUsuario = value; } }
        public int IDModulo { get { return _IDModulo; } set { _IDModulo = value; } }
        public bool PermiteAlta { get { return _PermiteAlta; } set { _PermiteAlta = value; } }
        public bool PermiteBaja { get { return _PermiteBaja; } set { _PermiteBaja = value; } }
        public bool PermiteModificacion { get { return _PermiteModificacion; } set { _PermiteModificacion = value; } }
        public bool PermiteConsulta { get { return _PermiteConsulta; } set { _PermiteConsulta = value; } }
    }
}
