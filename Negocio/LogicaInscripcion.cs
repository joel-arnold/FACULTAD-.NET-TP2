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

        public LogicaInscripcion()
        {
            _DatosInscripcion = new AdaptadorInscripcion();
        }

        public AlumnoInscripciones TraerUno(int ID)
        {
            return DatosInscripcion.TraerUno(ID);
        }

        //public List<AlumnoInscripciones> TraerTodos()
        //{
        //    return DatosInscripcion.TraerTodos();
        //}

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

        public List<AlumnoInscripciones> TraerTodosPorIdPersona(int ID)
        {
            return DatosInscripcion.TraerTodosPorIdPersona(ID);
        }
    }
}
