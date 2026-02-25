namespace Gestor_de_Horarios_de_Maestros
{
    partial class FormModificar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMaestro = new System.Windows.Forms.TabPage();
            this.tabMateria = new System.Windows.Forms.TabPage();
            this.cmbMaestros = new System.Windows.Forms.ComboBox();
            this.txtNuevoNombre = new System.Windows.Forms.TextBox();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.cmbMaestroAsoc = new System.Windows.Forms.ComboBox();
            this.txtIdMateria = new System.Windows.Forms.TextBox();
            this.txtNombreM = new System.Windows.Forms.TextBox();
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

            this.SuspendLayout();

            // TabControl
            this.tabControl.Controls.Add(this.tabMaestro);
            this.tabControl.Controls.Add(this.tabMateria);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Size = new System.Drawing.Size(430, 390);

            // TAB MAESTRO
            this.tabMaestro.Text = "Maestro";
            this.AgregarL(tabMaestro, "Seleccionar maestro:", 15, 20);
            this.cmbMaestros.Location = new System.Drawing.Point(15, 40);
            this.cmbMaestros.Size = new System.Drawing.Size(350, 23);
            this.cmbMaestros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaestros.SelectedIndexChanged += new System.EventHandler(this.CmbMaestros_SelectedIndexChanged);
            this.AgregarL(tabMaestro, "Nuevo nombre:", 15, 80);
            this.txtNuevoNombre.Location = new System.Drawing.Point(15, 100);
            this.txtNuevoNombre.Size = new System.Drawing.Size(350, 23);
            this.tabMaestro.Controls.AddRange(new System.Windows.Forms.Control[] { cmbMaestros, txtNuevoNombre });

            // TAB MATERIA
            this.tabMateria.Text = "Materia";
            this.AgregarL(tabMateria, "1. Elija Materia a editar:", 15, 15);
            this.cmbMaterias.Location = new System.Drawing.Point(15, 35);
            this.cmbMaterias.Size = new System.Drawing.Size(380, 23);
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterias.SelectedIndexChanged += new System.EventHandler(this.CmbMaterias_SelectedIndexChanged);
            this.tabMateria.Controls.Add(cmbMaterias);

            // Campos de edición
            this.Config(txtIdMateria, "ID Materia:", 15, 75, 110, 80, tabMateria);
            this.Config(cmbMaestroAsoc, "Maestro:", 210, 75, 270, 125, tabMateria);
            this.cmbMaestroAsoc.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Config(txtNombreM, "Materia:", 15, 110, 110, 285, tabMateria);
            this.Config(txtDias, "Días:", 15, 145, 110, 285, tabMateria);

            this.Config(txtHora, "Hora:", 15, 180, 110, 90, tabMateria);
            this.Config(txtAula, "Aula:", 220, 180, 280, 115, tabMateria);

            this.Config(txtHDCredito, "H/D Cred:", 15, 215, 110, 90, tabMateria);
            this.Config(txtSeccion, "Sección:", 220, 215, 280, 115, tabMateria);

            this.Config(txtDiasMes, "Días/Mes:", 15, 250, 110, 90, tabMateria);
            this.Config(txtCredito, "Créditos:", 220, 250, 280, 115, tabMateria);

            this.Config(txtTotalCredito, "Total Cred:", 15, 285, 110, 90, tabMateria);
            this.Config(txtInscritos, "Inscritos:", 220, 285, 280, 115, tabMateria);

            // BOTONES
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(215, 415);
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(345, 415);
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);

            this.ClientSize = new System.Drawing.Size(465, 465);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { tabControl, btnGuardar, btnCancelar });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Modificar Registros";
            this.ResumeLayout(false);
        }

        private void Config(System.Windows.Forms.Control c, string t, int lx, int ty, int tx, int tw, System.Windows.Forms.Control p)
        {
            System.Windows.Forms.Label l = new System.Windows.Forms.Label { Text = t, Location = new System.Drawing.Point(lx, ty + 3), AutoSize = true };
            c.Location = new System.Drawing.Point(tx, ty); c.Width = tw;
            p.Controls.Add(l); p.Controls.Add(c);
        }

        private void AgregarL(System.Windows.Forms.Control p, string t, int x, int y)
        {
            p.Controls.Add(new System.Windows.Forms.Label { Text = t, Location = new System.Drawing.Point(x, y), AutoSize = true });
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMaestro, tabMateria;
        private System.Windows.Forms.ComboBox cmbMaestros, cmbMaterias, cmbMaestroAsoc;
        private System.Windows.Forms.TextBox txtNuevoNombre, txtIdMateria, txtNombreM, txtDias, txtHora, txtHDCredito, txtDiasMes, txtInscritos, txtAula, txtSeccion, txtCredito, txtTotalCredito;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
    }
}
