using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UI.Escritorio
{
    public partial class FormularioAplicacion : Form
    {

        private ModosFormulario modo;

        public enum ModosFormulario
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        public ModosFormulario Modo
        { get { return modo; } set { modo = value; } }

        public virtual void MapearADatos(){}

        public virtual void MapearDeDatos() { }

        public virtual void GuardarCambios() { }

        public virtual bool Validar() { return false; }

        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public virtual void Notificar(string mensaje, MessageBoxButtons botones,MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

    }
}
