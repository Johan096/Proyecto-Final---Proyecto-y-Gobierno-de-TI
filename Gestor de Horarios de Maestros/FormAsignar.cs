using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class FormAsignar : Form
    {
        string connectionString => ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public FormAsignar()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // Cargar Maestros
                    MySqlDataAdapter daM = new MySqlDataAdapter("SELECT IdMaestro, Nombre FROM Maestros", con);
                    DataTable dtM = new DataTable();
                    daM.Fill(dtM);
                    cmbMaestros.DataSource = dtM;
                    cmbMaestros.DisplayMember = "Nombre";
                    cmbMaestros.ValueMember = "IdMaestro";

                    // Cargar Materias (Asegúrate que el nombre de la tabla sea 'Materias')
                    MySqlDataAdapter daMat = new MySqlDataAdapter("SELECT IdMateria, Nombre FROM Materias", con);
                    DataTable dtMat = new DataTable();
                    daMat.Fill(dtMat);
                    cmbMaterias.DataSource = dtMat;
                    cmbMaterias.DisplayMember = "Nombre";
                    cmbMaterias.ValueMember = "IdMateria";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // Actualizamos la materia existente para asignarle el ID del maestro elegido
                    string query = "UPDATE Materias SET IdMaestro = @idM WHERE IdMateria = @idMat";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idM", cmbMaestros.SelectedValue);
                    cmd.Parameters.AddWithValue("@idMat", cmbMaterias.SelectedValue);

                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}