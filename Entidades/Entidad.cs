using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidad
    {
        public Entidad()
        {
            this.Estado = Estados.Nuevo;
        }

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        
        private Estados _Estado;
        public Estados Estado
        { get { return _Estado; } set { _Estado = value; } }

        public enum Estados
        {
            Borrado,
            Nuevo,
            Modificado,
            SinModificar
        }
    }
}
