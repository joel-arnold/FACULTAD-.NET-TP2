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
        UsuarioAdapter _UsuarioData;

        public UsuarioAdapter UsuarioData
        {
            get
            {
                return _UsuarioData;
            }
            set
            {
                _UsuarioData = value;
            }
        }

        public LogicaUsuario()
        {
            _UsuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
           return UsuarioData.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Usuario usuario)
        {
            if(usuario.State == Entidad.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if(usuario.State == Entidad.States.New)
            {
                this.Insert(usuario);
            }
            else if(usuario.State == Entidad.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = Entidad.States.Unmodified;
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Insert(Usuario usuario)
        {
            UsuarioData.Insert(usuario);
        }

        public void Update(Usuario usuario)
        {
            UsuarioData.Update(usuario);
        }

        public bool existeUsuario(string usuario, string clave)
        {
            return UsuarioData.existeUsuario(usuario, clave);
        }
    }
}
