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
        AdaptadorMateria _DatosMateria;

        public AdaptadorMateria DatosMateria
        {
            get
            {
                return _DatosMateria;
            }
            set
            {
                _DatosMateria = value;
            }
        }

        public LogicaMateria()
        {
            _DatosMateria = new AdaptadorMateria();
        }

        public Materia TraerUno(int ID)
        {
            return DatosMateria.TraerUno(ID);
        }

        public List<Materia> TraerTodosPorIdPlan(int ID)
        {
            return DatosMateria.TraerTodosPorIdPlan(ID);
        }

        public List<Materia> TraerTodos()
        {
            return DatosMateria.TraerTodos();
        }

        public List<Materia> TraerTodos(int idPlan)
        {
            return DatosMateria.TraerTodos(idPlan);
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
            DatosMateria.Borrar(ID);
        }

        public void Agregar(Materia materia)
        {
            DatosMateria.Agregar(materia);
        }

        public void Actualizar(Materia materia)
        {
            DatosMateria.Actualizar(materia);
        }
    }
}
