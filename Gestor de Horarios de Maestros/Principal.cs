using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Gestor_de_Horarios_de_Maestros
{
    public partial class Principal : Form
    {
        string connectionString => ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        private void CargarComboMaestros()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdMaestro", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT IdMaestro, Nombre FROM Maestros";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    da.Fill(dt); // Si falla, salta al catch
                }
            }
            catch
            {
                // Si falla la conexión, dejamos el DT vacío para llenarlo solo con "Todos"
            }

            // Agregar la opción "Todos" siempre, falle o no la BD
            DataRow filaTodos = dt.NewRow();
            filaTodos["IdMaestro"] = 0;
            filaTodos["Nombre"] = "Todos";
            dt.Rows.InsertAt(filaTodos, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdMaestro";
        }

        private void CargarGrid(string nombreMaestro = "Todos")
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    // Nota: Asegúrate de que 'HorariosView' o tu Tabla exista en tu futura BD
                    string query = "SELECT * FROM HorariosView";

                    if (nombreMaestro != "Todos")
                    {
                        query += " WHERE MaestroNombre = @nombre";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    if (nombreMaestro != "Todos")
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreMaestro);
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Aquí es donde el programa intenta conectar. Si falla, salta al catch.
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                // Si no hay conexión, limpiamos el grid o mostramos un mensaje discreto
                dataGridView1.DataSource = null;
                // Opcional: imprimir el error en la consola de depuración para tu control
                System.Diagnostics.Debug.WriteLine("Error de conexión: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
            }
        }


        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboMaestros();
                CargarGrid();
            }
            catch (MySqlException)
            {
                MessageBox.Show("No se pudo conectar a la base de datos. " +
                    "Por favor, configure la conexión en el menú superior.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string seleccion = comboBox1.Text;
                CargarGrid(seleccion);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void conexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConfigConexion ventana = new ConfigConexion())
            {
                ventana.ShowDialog();
            }

            // Al cerrar la ventana, intentamos cargar los datos con la nueva conexión
            CargarComboMaestros();
            CargarGrid();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
