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
            if(plan.State == Entidad.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if(plan.State == Entidad.States.New)
            {
                this.Insert(plan);
            }
            else if(plan.State == Entidad.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = Entidad.States.Unmodified;
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
