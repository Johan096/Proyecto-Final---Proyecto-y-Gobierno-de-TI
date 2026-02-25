namespace Gestor_de_Horarios_de_Maestros
{
    partial class FormAgregar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMaestro = new System.Windows.Forms.TabPage();
            this.tabMateria = new System.Windows.Forms.TabPage();
            this.txtNombreMaestro = new System.Windows.Forms.TextBox();
            this.lblNombreMaestro = new System.Windows.Forms.Label();

            // Controles Materia
            this.txtIdMateria = new System.Windows.Forms.TextBox();
            this.cmbMaestro = new System.Windows.Forms.ComboBox();
            this.txtNombreMateria = new System.Windows.Forms.TextBox();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtAula = new System.Windows.Forms.TextBox();
            this.txtHDCredito = new System.Windows.Forms.TextBox();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.txtDiasMes = new System.Windows.Forms.TextBox();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.txtTotalCredito = new System.Windows.Forms.TextBox();
            this.txtInscritos = new System.Windows.Forms.TextBox();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Labels
            this.L1 = new System.Windows.Forms.Label(); this.L2 = new System.Windows.Forms.Label();
            this.L3 = new System.Windows.Forms.Label(); this.L4 = new System.Windows.Forms.Label();
            this.L5 = new System.Windows.Forms.Label(); this.L6 = new System.Windows.Forms.Label();
            this.L7 = new System.Windows.Forms.Label(); this.L8 = new System.Windows.Forms.Label();
            this.L9 = new System.Windows.Forms.Label(); this.L10 = new System.Windows.Forms.Label();
            this.L11 = new System.Windows.Forms.Label(); this.L12 = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabMaestro.SuspendLayout();
            this.tabMateria.SuspendLayout();
            this.SuspendLayout();

            this.tabControl.Controls.Add(this.tabMaestro);
            this.tabControl.Controls.Add(this.tabMateria);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Size = new System.Drawing.Size(435, 360);
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);

            // Tab Maestro
            this.tabMaestro.Controls.Add(this.lblNombreMaestro);
            this.tabMaestro.Controls.Add(this.txtNombreMaestro);
            this.tabMaestro.Text = "Nuevo Maestro";
            this.lblNombreMaestro.Text = "Nombre del Maestro:";
            this.lblNombreMaestro.Location = new System.Drawing.Point(20, 30);
            this.lblNombreMaestro.AutoSize = true;
            this.txtNombreMaestro.Location = new System.Drawing.Point(20, 50);
            this.txtNombreMaestro.Size = new System.Drawing.Size(300, 23);

            // Tab Materia
            this.tabMateria.Text = "Nueva Materia";

            // Columna 1
            Colocar(L1, "ID Materia:", 15, 20, tabMateria);
            this.txtIdMateria.Location = new System.Drawing.Point(110, 17);
            this.txtIdMateria.Size = new System.Drawing.Size(80, 23);
            tabMateria.Controls.Add(txtIdMateria);

            Colocar(L2, "Maestro:", 15, 55, tabMateria);
            this.cmbMaestro.Location = new System.Drawing.Point(110, 52);
            this.cmbMaestro.Size = new System.Drawing.Size(280, 23);
            this.cmbMaestro.DropDownStyle = ComboBoxStyle.DropDownList;
            tabMateria.Controls.Add(cmbMaestro);

            Colocar(L3, "Materia:", 15, 90, tabMateria);
            this.txtNombreMateria.Location = new System.Drawing.Point(110, 87);
            this.txtNombreMateria.Size = new System.Drawing.Size(280, 23);
            tabMateria.Controls.Add(txtNombreMateria);

            Colocar(L4, "Días:", 15, 125, tabMateria);
            this.txtDias.Location = new System.Drawing.Point(110, 122);
            this.txtDias.Size = new System.Drawing.Size(280, 23);
            tabMateria.Controls.Add(txtDias);

            // Fila Mixta
            Colocar(L5, "Hora:", 15, 160, tabMateria);
            this.txtHora.Location = new System.Drawing.Point(110, 157);
            this.txtHora.Size = new System.Drawing.Size(90, 23);
            tabMateria.Controls.Add(txtHora);

            Colocar(L6, "Aula:", 220, 160, tabMateria);
            this.txtAula.Location = new System.Drawing.Point(280, 157);
            this.txtAula.Size = new System.Drawing.Size(110, 23);
            tabMateria.Controls.Add(txtAula);

            Colocar(L7, "H/D Cred:", 15, 195, tabMateria);
            this.txtHDCredito.Location = new System.Drawing.Point(110, 192);
            this.txtHDCredito.Size = new System.Drawing.Size(90, 23);
            tabMateria.Controls.Add(txtHDCredito);

            Colocar(L8, "Sección:", 220, 195, tabMateria);
            this.txtSeccion.Location = new System.Drawing.Point(280, 192);
            this.txtSeccion.Size = new System.Drawing.Size(110, 23);
            tabMateria.Controls.Add(txtSeccion);

            Colocar(L9, "Días/Mes:", 15, 230, tabMateria);
            this.txtDiasMes.Location = new System.Drawing.Point(110, 227);
            this.txtDiasMes.Size = new System.Drawing.Size(90, 23);
            tabMateria.Controls.Add(txtDiasMes);

            Colocar(L10, "Créditos:", 220, 230, tabMateria);
            this.txtCredito.Location = new System.Drawing.Point(280, 227);
            this.txtCredito.Size = new System.Drawing.Size(110, 23);
            tabMateria.Controls.Add(txtCredito);

            Colocar(L11, "Total Cred:", 15, 265, tabMateria);
            this.txtTotalCredito.Location = new System.Drawing.Point(110, 262);
            this.txtTotalCredito.Size = new System.Drawing.Size(90, 23);
            tabMateria.Controls.Add(txtTotalCredito);

            Colocar(L12, "Inscritos:", 220, 265, tabMateria);
            this.txtInscritos.Location = new System.Drawing.Point(280, 262);
            this.txtInscritos.Size = new System.Drawing.Size(110, 23);
            tabMateria.Controls.Add(txtInscritos);

            // Botones
            this.btnGuardar.Location = new System.Drawing.Point(230, 385);
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnCancelar.Location = new System.Drawing.Point(340, 385);
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);

            this.ClientSize = new System.Drawing.Size(460, 440);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Agregar";

            this.tabControl.ResumeLayout(false);
            this.tabMaestro.ResumeLayout(false);
            this.tabMateria.ResumeLayout(false);
            this.tabMateria.PerformLayout();
            this.ResumeLayout(false);
        }

        private void Colocar(Label l, string t, int x, int y, Control p)
        {
            l.Text = t; l.Location = new System.Drawing.Point(x, y); l.AutoSize = true; p.Controls.Add(l);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMaestro, tabMateria;
        private System.Windows.Forms.TextBox txtNombreMaestro, txtIdMateria, txtNombreMateria, txtDias, txtHora, txtAula, txtSeccion, txtHDCredito, txtDiasMes, txtCredito, txtTotalCredito, txtInscritos;
        private System.Windows.Forms.ComboBox cmbMaestro;
        private System.Windows.Forms.Label lblNombreMaestro, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
    }
}
