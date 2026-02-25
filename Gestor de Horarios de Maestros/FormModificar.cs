using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class FormModificar : Form
    {
        string connectionString => ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public FormModificar()
        {
            InitializeComponent();
            CargarCombosIniciales();
        }

        private void CargarCombosIniciales()
        {
            CargarComboMaestros(cmbMaestros);      // Combo de la pestaña Maestro
            CargarComboMaestros(cmbMaestroAsoc);  // Combo dentro de la pestaña Materia
            CargarComboMaterias();                 // Combo selector de materia
        }

        private void CargarComboMaestros(ComboBox cb)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT IdMaestro, Nombre FROM Maestros ORDER BY Nombre", con);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        cb.Items.Clear();
                        while (r.Read()) cb.Items.Add(new ComboItem(r.GetInt32(0), r.GetString(1)));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error maestros: " + ex.Message); }
        }

        private void CargarComboMaterias()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "SELECT IdMateria, Nombre FROM Materias ORDER BY Nombre";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        cmbMaterias.Items.Clear();
                        while (r.Read()) cmbMaterias.Items.Add(new ComboItem(r.GetInt32(0), r.GetString(1)));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error materias: " + ex.Message); }
        }

        private void CmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbMaterias.SelectedItem is ComboItem item)) return;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM Materias WHERE IdMateria = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtIdMateria.Text = r["IdMateria"].ToString();
                            txtNombreM.Text = r["Nombre"].ToString();
                            txtDias.Text = r["DiasImparte"].ToString();
                            txtHora.Text = r["Hora"].ToString();
                            txtHDCredito.Text = r["HD_Credito"].ToString();
                            txtDiasMes.Text = r["DiasMes"].ToString();
                            txtTotalCredito.Text = r["TotalCredito"].ToString();
                            txtInscritos.Text = r["Inscritos"].ToString();
                            txtAula.Text = r["Aula"].ToString();
                            txtSeccion.Text = r["Seccion"].ToString();
                            txtCredito.Text = r["Credito"].ToString();

                            // Seleccionar el maestro actual en el combo
                            int idM = Convert.ToInt32(r["IdMaestro"]);
                            foreach (ComboItem m in cmbMaestroAsoc.Items)
                            {
                                if (m.Id == idM) { cmbMaestroAsoc.SelectedItem = m; break; }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) GuardarMaestro();
            else GuardarMateria();
        }

        private void GuardarMaestro()
        {
            if (!(cmbMaestros.SelectedItem is ComboItem item)) return;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE Maestros SET Nombre=@n WHERE IdMaestro=@id", con);
                    cmd.Parameters.AddWithValue("@n", txtNuevoNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Maestro actualizado.");
                    CargarCombosIniciales();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GuardarMateria()
        {
            if (!(cmbMaterias.SelectedItem is ComboItem selector) || !(cmbMaestroAsoc.SelectedItem is ComboItem maestro)) return;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // Incluimos IdMateria en el SET por si se editó
                    string sql = @"UPDATE Materias SET IdMateria=@newId, IdMaestro=@idM, Nombre=@nom, DiasImparte=@d, 
                                 Hora=@h, HD_Credito=@hd, DiasMes=@dm, TotalCredito=@tot, Inscritos=@ins, 
                                 Aula=@a, Seccion=@s, Credito=@c WHERE IdMateria=@oldId";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@newId", txtIdMateria.Text);
                    cmd.Parameters.AddWithValue("@idM", maestro.Id);
                    cmd.Parameters.AddWithValue("@nom", txtNombreM.Text);
                    cmd.Parameters.AddWithValue("@d", txtDias.Text);
                    cmd.Parameters.AddWithValue("@h", txtHora.Text);
                    cmd.Parameters.AddWithValue("@hd", ParseInt(txtHDCredito.Text));
                    cmd.Parameters.AddWithValue("@dm", ParseInt(txtDiasMes.Text));
                    cmd.Parameters.AddWithValue("@tot", ParseInt(txtTotalCredito.Text));
                    cmd.Parameters.AddWithValue("@ins", ParseInt(txtInscritos.Text));
                    cmd.Parameters.AddWithValue("@a", txtAula.Text);
                    cmd.Parameters.AddWithValue("@s", txtSeccion.Text);
                    cmd.Parameters.AddWithValue("@c", ParseInt(txtCredito.Text));
                    cmd.Parameters.AddWithValue("@oldId", selector.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Materia actualizada.");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private object ParseInt(string v) => int.TryParse(v, out int i) ? (object)i : DBNull.Value;
        private void BtnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void CmbMaestros_SelectedIndexChanged(object sender, EventArgs e) { if (cmbMaestros.SelectedItem is ComboItem i) txtNuevoNombre.Text = i.Nombre; }
    }
}
