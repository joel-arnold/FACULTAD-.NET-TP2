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
using Negocio;

namespace UI.Escritorio
{
    public partial class FormularioNotasCarga : FormularioAplicacion
    {
        private InscripcionesEditado inscripcionActual = new InscripcionesEditado();
        private string condicion;

        private InscripcionesEditado InscripcionActual
        {
            get
            {
                return inscripcionActual;
            }
            set
            {
                inscripcionActual = value;
            }
        }

        public FormularioNotasCarga()
        {
            
        }

        public FormularioNotasCarga(InscripcionesEditado i)
        {
            InitializeComponent();
            InscripcionActual = i;
            this.lblNombre.Text = i.Alumno;
            for(int n=1; n<11; n++)
            {
                cbbxNota.Items.Add(n);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbbxNota.SelectedItem != null)
            {
                switch (cbbxNota.SelectedItem)
                {
                    case 1:
                    case 2:
                    case 3:
                        condicion = "Aplazado";
                        break;
                    case 4:
                    case 5:
                        condicion = "Regular";
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        condicion = "Aprobado";
                        break;
                }
                AlumnoInscripciones ai = new AlumnoInscripciones();
                LogicaInscripcion lc = new LogicaInscripcion();
                ai = lc.TraerUno(inscripcionActual.ID);
                ai.Nota = Convert.ToInt32(cbbxNota.SelectedItem);
                ai.Condicion = condicion;
                lc.Actualizar(ai);
                this.Dispose();
            }
            else { MessageBox.Show("No ha seleccionado ninguna nota"); }          
        }
    }
}
