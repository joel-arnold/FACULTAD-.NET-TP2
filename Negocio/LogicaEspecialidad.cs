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
        EspecialidadAdapter _EspecialidadData;

        public EspecialidadAdapter EspecialidadData
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
            _EspecialidadData = new EspecialidadAdapter();
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
            if(especialidad.State == Entidad.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if(especialidad.State == Entidad.States.New)
            {
                this.Insert(especialidad);
            }
            else if(especialidad.State == Entidad.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = Entidad.States.Unmodified;
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }

        public void Insert(Especialidad especialidad)
        {
            EspecialidadData.Insert(especialidad);
        }

        public void Update(Especialidad especialidad)
        {
            EspecialidadData.Update(especialidad);
        }
    }
}
