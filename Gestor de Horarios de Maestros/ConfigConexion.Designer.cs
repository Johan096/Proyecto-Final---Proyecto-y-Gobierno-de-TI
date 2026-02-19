namespace Gestor_de_Horarios_de_Maestros
{
    partial class ConfigConexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtServer = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            txtDatabase = new TextBox();
            label5 = new Label();
            txtUser = new TextBox();
            label6 = new Label();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 9);
            label1.Name = "label1";
            label1.Size = new Size(303, 28);
            label1.TabIndex = 0;
            label1.Text = "Escribe la Ruta de la Conexión:";
            label1.Click += label1_Click;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(121, 65);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(275, 23);
            txtServer.TabIndex = 1;
            txtServer.TextChanged += txtServer_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 37);
            label2.Name = "label2";
            label2.Size = new Size(487, 20);
            label2.TabIndex = 2;
            label2.Text = "Ejemplo: Server=TU_SERVIDOR; Database=TuBD; Integrated Security=True;";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(523, 150);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 63);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 4;
            label3.Text = "Server";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 92);
            label4.Name = "label4";
            label4.Size = new Size(81, 21);
            label4.TabIndex = 6;
            label4.Text = "DataBase";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(121, 94);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(275, 23);
            txtDatabase.TabIndex = 5;
            txtDatabase.TextChanged += txtDatabase_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 121);
            label5.Name = "label5";
            label5.Size = new Size(44, 21);
            label5.TabIndex = 8;
            label5.Text = "User";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(122, 123);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(275, 23);
            txtUser.TabIndex = 7;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(34, 150);
            label6.Name = "label6";
            label6.Size = new Size(82, 21);
            label6.TabIndex = 10;
            label6.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(122, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(275, 23);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // ConfigConexion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 180);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtUser);
            Controls.Add(label4);
            Controls.Add(txtDatabase);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtServer);
            Controls.Add(label1);
            Name = "ConfigConexion";
            Text = "ConfigConexion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServer;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
        private TextBox txtDatabase;
        private Label label5;
        private TextBox txtUser;
        private Label label6;
        private TextBox txtPassword;
    }
}