using Data.Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaDocenteCurso : Logica
    {
        AdaptadorDocenteCurso _DatosDocenteCurso;

        public LogicaDocenteCurso()
        {
            _DatosDocenteCurso = new AdaptadorDocenteCurso();
        }

        public AdaptadorDocenteCurso DatosDocenteCurso
        {
            get
            {
                return _DatosDocenteCurso;
            }
            set
            {
                _DatosDocenteCurso = value;
            }
        }

        public DocenteCurso TraerUno(int ID)
        {
            return DatosDocenteCurso.TraerUno(ID);
        }

        public List<DocenteCurso> TraerTodos()
        {
            return DatosDocenteCurso.TraerTodos();
        }

        public List<DocenteCurso> TraerTodos(int idProfesor)
        {
            return DatosDocenteCurso.TraerTodos(idProfesor);
        }

        public void Guardar(DocenteCurso docenteCurso)
        {
            if (docenteCurso.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(docenteCurso.ID);
            }
            else if (docenteCurso.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(docenteCurso);
            }
            else if (docenteCurso.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(docenteCurso);
            }
        }

        public void Borrar(int ID)
        {
            DatosDocenteCurso.Borrar(ID);
        }

        public void Agregar(DocenteCurso docenteCurso)
        {
            DatosDocenteCurso.Agregar(docenteCurso);
        }

        public void Actualizar(DocenteCurso docenteCurso)
        {
            DatosDocenteCurso.Actualizar(docenteCurso);
        }
    }
}
