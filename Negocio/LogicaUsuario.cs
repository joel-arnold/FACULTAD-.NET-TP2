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

        public Usuario GetOne(int ID)
        {
           return DatosUsuario.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            return DatosUsuario.GetAll();
        }

        public void Save(Usuario usuario)
        {
            if(usuario.Estado == Entidad.Estados.Borrado)
            {
                this.Delete(usuario.ID);
            }
            else if(usuario.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(usuario);
            }
            else if(usuario.Estado == Entidad.Estados.Modificado)
            {
                this.Update(usuario);
            }
            usuario.Estado = Entidad.Estados.SinModificar;
        }

        public void Delete(int ID)
        {
            DatosUsuario.Delete(ID);
        }

        public void Insert(Usuario usuario)
        {
            DatosUsuario.Insert(usuario);
        }

        public void Update(Usuario usuario)
        {
            DatosUsuario.Update(usuario);
        }

        public Usuario existeUsuario(string usuario, string clave)
        {
            return DatosUsuario.existeUsuario(usuario, clave);
        }
    }
}
