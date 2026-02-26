using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class FormBuscar : Form
    {
        // Propiedades para enviar los datos de vuelta al formulario Principal
        public string Seccion => txtSeccion.Text;
        public string Dia => txtDia.Text;
        public string Credito => txtCredito.Text;
        public string Hora => txtHora.Text;

        public FormBuscar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Criterios de Búsqueda";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Indica que se presionó buscar
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
