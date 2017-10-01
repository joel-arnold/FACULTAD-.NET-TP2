using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaUsuario : Logica
    {
        AdaptadorUsuario _DatosUsuario;

        public AdaptadorUsuario DatosUsuario
        {
            get
            {
                return _DatosUsuario;
            }
            set
            {
                _DatosUsuario = value;
            }
        }

        public LogicaUsuario()
        {
            _DatosUsuario = new AdaptadorUsuario();
        }

        public Usuario TraerUno(int ID)
        {
           return DatosUsuario.TraerUno(ID);
        }

        public List<Usuario> TraerTodos()
        {
            return DatosUsuario.TraerTodos();
        }

        public void Guardar(Usuario usuario)
        {
            if(usuario.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(usuario.ID);
            }
            else if(usuario.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(usuario);
            }
            else if(usuario.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(usuario);
            }
        }

        public void Borrar(int ID)
        {
            DatosUsuario.Borrar(ID);
        }

        public void Agregar(Usuario usuario)
        {
            DatosUsuario.Agregar(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            DatosUsuario.Actualizar(usuario);
        }

        public Usuario existeUsuario(string usuario, string clave)
        {
            return DatosUsuario.existeUsuario(usuario, clave);
        }
    }
}
