namespace Gestor_de_Horarios_de_Maestros
{
    partial class FormAsignar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbMaestros;
        private System.Windows.Forms.ComboBox cmbMaterias; // Nuevo ComboBox
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;

        private void InitializeComponent()
        {
            this.cmbMaestros = new System.Windows.Forms.ComboBox();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Label Maestro
            this.lbl1.Text = "Seleccionar Maestro:";
            this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.lbl1.AutoSize = true;

            // Combo Maestros
            this.cmbMaestros.Location = new System.Drawing.Point(20, 40);
            this.cmbMaestros.Size = new System.Drawing.Size(240, 21);
            this.cmbMaestros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Label Materia
            this.lbl2.Text = "Seleccionar Materia:";
            this.lbl2.Location = new System.Drawing.Point(20, 80);
            this.lbl2.AutoSize = true;

            // Combo Materias
            this.cmbMaterias.Location = new System.Drawing.Point(20, 100);
            this.cmbMaterias.Size = new System.Drawing.Size(240, 21);
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Botón Guardar
            this.btnGuardar.Text = "Realizar Asignación";
            this.btnGuardar.Location = new System.Drawing.Point(70, 150);
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { cmbMaestros, cmbMaterias, btnGuardar, lbl1, lbl2 });
            this.Text = "Asignar Maestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}