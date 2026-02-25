using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class FormAgregar : Form
    {
        string connectionString => ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public FormAgregar()
        {
            InitializeComponent();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
                CargarComboMaestros();
        }

        private void CargarComboMaestros()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT IdMaestro, Nombre FROM Maestros ORDER BY Nombre", con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbMaestro.Items.Clear();
                        while (reader.Read())
                            cmbMaestro.Items.Add(new ComboItem(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
                if (cmbMaestro.Items.Count > 0) cmbMaestro.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar maestros: " + ex.Message, "Error");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                GuardarMaestro();
            else
                GuardarMateria();
        }

        private void GuardarMaestro()
        {
            if (string.IsNullOrWhiteSpace(txtNombreMaestro.Text))
            {
                MessageBox.Show("El nombre del maestro es obligatorio.", "Validación");
                return;
            }
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Maestros (Nombre) VALUES (@nombre)", con);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreMaestro.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Maestro agregado correctamente.", "Éxito");
                txtNombreMaestro.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar maestro: " + ex.Message, "Error");
            }
        }

        private void GuardarMateria()
        {
            if (cmbMaestro.SelectedItem == null || string.IsNullOrWhiteSpace(txtNombreMateria.Text))
            {
                MessageBox.Show("Maestro y Materia son campos obligatorios.", "Validación");
                return;
            }

            try
            {
                int idMaestro = ((ComboItem)cmbMaestro.SelectedItem).Id;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // Query actualizado con IdMateria y TotalCredito
                    string query = @"INSERT INTO Materias 
                        (IdMateria, IdMaestro, Nombre, DiasImparte, Hora, HD_Credito, DiasMes, TotalCredito, Inscritos, Aula, Seccion, Credito)
                        VALUES (@idMateria, @idMaestro, @nombre, @dias, @hora, @hdCredito, @diasMes, @totalCredito, @inscritos, @aula, @seccion, @credito)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idMateria", ParseInt(txtIdMateria.Text));
                        cmd.Parameters.AddWithValue("@idMaestro", idMaestro);
                        cmd.Parameters.AddWithValue("@nombre", txtNombreMateria.Text.Trim());
                        cmd.Parameters.AddWithValue("@dias", txtDias.Text.Trim());
                        cmd.Parameters.AddWithValue("@hora", txtHora.Text.Trim());
                        cmd.Parameters.AddWithValue("@hdCredito", ParseInt(txtHDCredito.Text));
                        cmd.Parameters.AddWithValue("@diasMes", ParseInt(txtDiasMes.Text));
                        cmd.Parameters.AddWithValue("@totalCredito", ParseInt(txtTotalCredito.Text));
                        cmd.Parameters.AddWithValue("@inscritos", ParseInt(txtInscritos.Text));
                        cmd.Parameters.AddWithValue("@aula", txtAula.Text.Trim());
                        cmd.Parameters.AddWithValue("@seccion", txtSeccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@credito", ParseInt(txtCredito.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Materia agregada correctamente.", "Éxito");
                LimpiarTabMateria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar materia: " + ex.Message, "Error");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void LimpiarTabMateria()
        {
            txtIdMateria.Clear(); txtNombreMateria.Clear(); txtDias.Clear(); txtHora.Clear();
            txtHDCredito.Clear(); txtDiasMes.Clear(); txtTotalCredito.Clear(); txtInscritos.Clear();
            txtAula.Clear(); txtSeccion.Clear(); txtCredito.Clear();
        }

        private object ParseInt(string val) => int.TryParse(val, out int i) ? (object)i : DBNull.Value;
    }
    public class ComboItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ComboItem(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}