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
        AdaptadorPlan _DatosPlan;

        public AdaptadorPlan DatosPlan
        {
            get
            {
                return _DatosPlan;
            }
            set
            {
                _DatosPlan = value;
            }
        }

        public LogicaPlan()
        {
            _DatosPlan = new AdaptadorPlan();
        }

        public Plan TraerUno(int ID)
        {
           return DatosPlan.TraerUno(ID);
        }

        public List<Plan> TraerTodos()
        {
            return DatosPlan.TraerTodos();
        }

        public void Guardar(Plan plan)
        {
            if(plan.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(plan.ID);
            }
            else if(plan.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(plan);
            }
            else if(plan.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(plan);
            }
        }

        public void Borrar(int ID)
        {
            DatosPlan.Borrar(ID);
        }

        public void Agregar(Plan plan)
        {
            DatosPlan.Agregar(plan);
        }

        public void Actualizar(Plan plan)
        {
            DatosPlan.Actualizar(plan);
        }
    }
}
