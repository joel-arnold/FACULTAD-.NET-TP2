using Data.Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaMateria : Logica
    {
        AdaptadorMateria _DatosEspecialidad;

        public AdaptadorMateria DatosEspecialidad
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

        public LogicaMateria()
        {
            _DatosEspecialidad = new AdaptadorMateria();
        }

        public Materia TraerUno(int ID)
        {
            return DatosEspecialidad.TraerUno(ID);
        }

        public List<Materia> TraerTodos()
        {
            return DatosEspecialidad.TraerTodos();
        }

        public void Guardar(Materia materia)
        {
            if (materia.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(materia.ID);
            }
            else if (materia.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(materia);
            }
            else if (materia.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(materia);
            }
        }

        public void Borrar(int ID)
        {
            DatosEspecialidad.Borrar(ID);
        }

        public void Agregar(Materia materia)
        {
            DatosEspecialidad.Agregar(materia);
        }

        public void Actualizar(Materia materia)
        {
            DatosEspecialidad.Actualizar(materia);
        }
    }
}
