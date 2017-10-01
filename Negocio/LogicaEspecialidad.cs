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
        AdaptadorEspecialidad _EspecialidadData;

        public AdaptadorEspecialidad EspecialidadData
        {
            get
            {
                return _EspecialidadData;
            }
            set
            {
                _EspecialidadData = value;
            }
        }

        public LogicaEspecialidad()
        {
            _EspecialidadData = new AdaptadorEspecialidad();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Especialidad especialidad)
        {
            if(especialidad.Estado == Entidad.Estados.Borrado)
            {
                this.Delete(especialidad.ID);
            }
            else if(especialidad.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(especialidad);
            }
            else if(especialidad.Estado == Entidad.Estados.Modificado)
            {
                this.Update(especialidad);
            }
            especialidad.Estado = Entidad.Estados.SinModificar;
        }

        public void Delete(int ID)
        {
            EspecialidadData.Borrar(ID);
        }

        public void Insert(Especialidad especialidad)
        {
            EspecialidadData.Agregar(especialidad);
        }

        public void Update(Especialidad especialidad)
        {
            EspecialidadData.Actualizar(especialidad);
        }
    }
}
