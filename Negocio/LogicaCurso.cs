using Data.Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaCurso : Logica
    {
        AdaptadorCurso _DatosCurso;

        public AdaptadorCurso DatosCurso
        {
            get
            {
                return _DatosCurso;
            }
            set
            {
                _DatosCurso = value;
            }
        }

        public LogicaCurso()
        {
            _DatosCurso = new AdaptadorCurso();
        }

        public Curso TraerUno(int ID)
        {
            return DatosCurso.TraerUno(ID);
        }

        public List<Curso> TraerTodos()
        {
            return DatosCurso.TraerTodos();
        }

        public List<Comision> TraerComisiones(int idMateria)
        {
            return DatosCurso.TraerComisiones(idMateria);
        }

        public void Guardar(Curso curso)
        {
            if (curso.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(curso.ID);
            }
            else if (curso.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(curso);
            }
            else if (curso.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(curso);
            }
        }

        public void Borrar(int ID)
        {
            DatosCurso.Borrar(ID);
        }

        public void Agregar(Curso curso)
        {
            DatosCurso.Agregar(curso);
        }

        public void Actualizar(Curso curso)
        {
            DatosCurso.Actualizar(curso);
        }
    }
}
