using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaPlan : Logica
    {
        PlanAdapter _PlanData;

        public PlanAdapter PlanData
        {
            get
            {
                return _PlanData;
            }
            set
            {
                _PlanData = value;
            }
        }

        public LogicaPlan()
        {
            _PlanData = new PlanAdapter();
        }

        public Plan GetOne(int ID)
        {
           return PlanData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Plan plan)
        {
            if(plan.Estado == Entidad.Estados.Borrado)
            {
                this.Delete(plan.ID);
            }
            else if(plan.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(plan);
            }
            else if(plan.Estado == Entidad.Estados.Modificado)
            {
                this.Update(plan);
            }
            plan.Estado = Entidad.Estados.SinModificar;
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public void Insert(Plan plan)
        {
            PlanData.Insert(plan);
        }

        public void Update(Plan plan)
        {
            PlanData.Update(plan);
        }
    }
}
