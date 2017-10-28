using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaInscripcion
    {
        public LogicaInscripcion()
        {
            _DatosInscripcion = new AdaptadorInscripcion();
        }

        AdaptadorInscripcion _DatosInscripcion;
        public AdaptadorInscripcion DatosInscripcion
        {
            get
            {
                return _DatosInscripcion;
            }
            set
            {
                _DatosInscripcion = value;
            }
        }

        public AlumnoInscripciones TraerUno(int ID)
        {
            return DatosInscripcion.TraerUno(ID);
        }

        public List<AlumnoInscripciones> TraerTodos()
        {
            return DatosInscripcion.TraerTodos();
        }

        public List<AlumnoInscripciones> TraerTodosPorIdPersona(int IdPersona)
        {
            return DatosInscripcion.TraerTodosPorIdPersona(IdPersona);
        }

        public List<AlumnoInscripciones> TraerTodosPorIdCurso(int IdCurso)
        {
            return DatosInscripcion.TraerTodosPorIdCurso(IdCurso);
        }

        public AlumnoInscripciones TraerUno(int idAlumno, int idCurso)
        {
            try
            {
                return DatosInscripcion.TraerUno(idAlumno, idCurso);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Guardar(AlumnoInscripciones ai)
        {
            if (ai.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(ai.ID);
            }
            else if (ai.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(ai);
            }
            else if (ai.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(ai);
            }
        }

        public void Borrar(int ID)
        {
            DatosInscripcion.Borrar(ID);
        }

        public void Agregar(AlumnoInscripciones ai)
        {
            DatosInscripcion.Agregar(ai);
        }

        public void Actualizar(AlumnoInscripciones ai)
        {
            DatosInscripcion.Actualizar(ai);
        }
    }
}
