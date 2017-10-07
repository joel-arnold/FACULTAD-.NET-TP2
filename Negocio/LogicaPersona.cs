using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class LogicaPersona : Logica
    {
        AdaptadorPersona _DatosPersona;

        public AdaptadorPersona DatosPersona
        {
            get
            {
                return _DatosPersona;
            }
            set
            {
                _DatosPersona = value;
            }
        }

        public LogicaPersona()
        {
            _DatosPersona = new AdaptadorPersona();
        }

        public Personas TraerUno(int ID)
        {
            try
            {
                return DatosPersona.TraerUno(ID);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<Personas> TraerTodos()
        {
            return DatosPersona.TraerTodos();
        }

        public void Guardar(Personas persona)
        {
            if (persona.Estado == Entidad.Estados.Borrado)
            {
                this.Borrar(persona.ID);
            }
            else if (persona.Estado == Entidad.Estados.Nuevo)
            {
                this.Agregar(persona);
            }
            else if (persona.Estado == Entidad.Estados.Modificado)
            {
                this.Actualizar(persona);
            }
        }

        public void Borrar(int ID)
        {
            DatosPersona.Borrar(ID);
        }

        public void Agregar(Personas persona)
        {
            DatosPersona.Agregar(persona);
        }

        public void Actualizar(Personas persona)
        {
            DatosPersona.Actualizar(persona);
        }
    }
}
