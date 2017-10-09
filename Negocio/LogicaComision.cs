using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaComision : Logica
    {
        AdaptadorComision _DatosComision;

        public AdaptadorComision DatosComision
        {
            get
            {
                return _DatosComision;
            }
            set
            {
                _DatosComision = value;
            }
        }

        public LogicaComision()
        {
            _DatosComision = new AdaptadorComision();
        }

        public Comision TraerUno(int ID)
        {
            return DatosComision.TraerUno(ID);
        }

        public List<Comision> TraerTodos()
        {
            return DatosComision.TraerTodos();
        }

        public void Guardar(Comision comision)
        {
            if (comision.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(comision.ID);
            }
            else if (comision.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(comision);
            }
            else if (comision.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(comision);
            }
        }

        public void Borrar(int ID)
        {
            DatosComision.Borrar(ID);
        }

        public void Agregar(Comision comision)
        {
            DatosComision.Agregar(comision);
        }

        public void Actualizar(Comision comision)
        {
            DatosComision.Actualizar(comision);
        }
    }
}
