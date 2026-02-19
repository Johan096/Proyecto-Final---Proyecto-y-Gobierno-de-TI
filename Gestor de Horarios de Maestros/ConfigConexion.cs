using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class ConfigConexion : Form
    {
        public ConfigConexion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevaCadena = $"Server={txtServer.Text};Database={txtDatabase.Text};Uid={txtUser.Text};Pwd={txtPassword.Text};";

            try
            {
                // Abrimos la configuración del archivo ejecutable
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Actualizamos la sección connectionStrings
                config.ConnectionStrings.ConnectionStrings["MiConexion"].ConnectionString = nuevaCadena;

                // Guardamos los cambios de forma permanente
                config.Save(ConfigurationSaveMode.Modified);

                // Forzamos la recarga en memoria para que el programa use los nuevos datos inmediatamente
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Conexión guardada con éxito. Los cambios se aplicarán ahora.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
