using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaEspecialidad : Logica
    {
        AdaptadorEspecialidad _DatosEspecialidad;

        public AdaptadorEspecialidad DatosEspecialidad
        {
            get
            {
                return _DatosEspecialidad;
            }
            set
            {
                _DatosEspecialidad = value;
            }
        }

        public LogicaEspecialidad()
        {
            _DatosEspecialidad = new AdaptadorEspecialidad();
        }

        public Especialidad TraerUno(int ID)
        {
            return DatosEspecialidad.TraerUno(ID);
        }

        public List<Especialidad> TraerTodos()
        {
            return DatosEspecialidad.TraerTodos();
        }

        public void Guardar(Especialidad especialidad)
        {
            if(especialidad.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(especialidad.ID);
            }
            else if(especialidad.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(especialidad);
            }
            else if(especialidad.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(especialidad);
            }
        }

        public void Borrar(int ID)
        {
            DatosEspecialidad.Borrar(ID);
        }

        public void Agregar(Especialidad especialidad)
        {
            DatosEspecialidad.Agregar(especialidad);
        }

        public void Actualizar(Especialidad especialidad)
        {
            DatosEspecialidad.Actualizar(especialidad);
        }
    }
}
