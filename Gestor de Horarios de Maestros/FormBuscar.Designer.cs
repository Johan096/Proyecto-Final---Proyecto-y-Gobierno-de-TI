namespace Gestor_de_Horarios_de_Maestros
{
    partial class FormBuscar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSeccion;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // Labels y TextBoxes
            this.lbl1.Text = "Sección:"; this.lbl1.Location = new System.Drawing.Point(20, 20);
            this.txtSeccion.Location = new System.Drawing.Point(100, 17); this.txtSeccion.Size = new System.Drawing.Size(150, 20);

            this.lbl2.Text = "Día:"; this.lbl2.Location = new System.Drawing.Point(20, 50);
            this.txtDia.Location = new System.Drawing.Point(100, 47); this.txtDia.Size = new System.Drawing.Size(150, 20);

            this.lbl3.Text = "Crédito:"; this.lbl3.Location = new System.Drawing.Point(20, 80);
            this.txtCredito.Location = new System.Drawing.Point(100, 77); this.txtCredito.Size = new System.Drawing.Size(150, 20);

            this.lbl4.Text = "Hora:"; this.lbl4.Location = new System.Drawing.Point(20, 110);
            this.txtHora.Location = new System.Drawing.Point(100, 107); this.txtHora.Size = new System.Drawing.Size(150, 20);

            // Botones
            this.btnAceptar.Text = "Buscar";
            this.btnAceptar.Location = new System.Drawing.Point(40, 150);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(140, 150);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Config Form
            this.ClientSize = new System.Drawing.Size(280, 200);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtSeccion, txtDia, txtCredito, txtHora, lbl1, lbl2, lbl3, lbl4, btnAceptar, btnCancelar
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
