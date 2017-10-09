using Data.Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaAlumnoInscripciones : Logica
    {
        private AdaptadorInscripcion _AlumnoInscripcionData;
        public AdaptadorInscripcion AdaptadorInscripcion
        {
            get { return _AlumnoInscripcionData; }
            set { _AlumnoInscripcionData = value; }
        }

        public LogicaAlumnoInscripciones()
        {
            AdaptadorInscripcion = new AdaptadorInscripcion();
        }

        public AlumnoInscripciones TraerUno(int idAlumno, int idCurso)
        {
            try
            {
                return AdaptadorInscripcion.TraerUno(idAlumno, idCurso);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<AlumnoInscripciones> TraerTodos(int IdCurso)
        {
            try
            {
                return AdaptadorInscripcion.TraerTodos(IdCurso);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Guardar(AlumnoInscripciones inscripcion)
        {
            AdaptadorInscripcion.Guardar(inscripcion);
        }
    }
}
