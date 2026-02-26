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

        private void CargarGrid(string nombreMaestro = "", string seccion = "", string dia = "", string credito = "", string hora = "")
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    // WHERE 1=1 permite que si no hay filtros, se muestren TODOS los registros
                    string query = @"SELECT 
                                MaestroNombre AS 'Docente', 
                                IdMateria AS 'ID',
                                Nombre AS 'Materia', 
                                DiasImparte AS 'Días', 
                                Hora AS 'Hora', 
                                HD_Credito AS 'H/D Credito',
                                DiasMes AS 'Días Mes',
                                TotalCredito AS 'Total Credito',
                                Inscritos AS 'Alum. Inscritos',
                                Aula AS 'Aula', 
                                Seccion AS 'Sección', 
                                Credito AS 'Créditos'
                             FROM HorariosView
                             WHERE 1=1";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    // Si es "Todos" o está vacío, NO agregamos el filtro de Maestro (mostrará todo)
                    if (!string.IsNullOrEmpty(nombreMaestro) && nombreMaestro != "Todos" && !nombreMaestro.Contains("System.Data.DataRowView"))
                    {
                        query += " AND MaestroNombre LIKE @nombre";
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombreMaestro + "%");
                    }

                    if (!string.IsNullOrEmpty(seccion))
                    {
                        query += " AND Seccion LIKE @seccion";
                        cmd.Parameters.AddWithValue("@seccion", "%" + seccion + "%");
                    }

                    if (!string.IsNullOrEmpty(dia))
                    {
                        query += " AND DiasImparte LIKE @dia";
                        cmd.Parameters.AddWithValue("@dia", "%" + dia + "%");
                    }

                    if (!string.IsNullOrEmpty(credito))
                    {
                        query += " AND Credito = @credito";
                        cmd.Parameters.AddWithValue("@credito", credito);
                    }

                    if (!string.IsNullOrEmpty(hora))
                    {
                        query += " AND Hora LIKE @hora";
                        cmd.Parameters.AddWithValue("@hora", "%" + hora + "%");
                    }

                    query += " ORDER BY MaestroNombre ASC";
                    cmd.CommandText = query;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
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
            
            using (FormModificar ventana = new FormModificar())
            {
                ventana.ShowDialog();
            }

            CargarComboMaestros();
            CargarGrid();
        }



        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAgregar ventana = new FormAgregar())
            {
                ventana.ShowDialog();
            }
            CargarComboMaestros();
            CargarGrid();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que acabamos de crear
            using (FormAsignar ventana = new FormAsignar())
            {
                // Si el usuario presiona el botón "Asignar Materia" y todo sale bien (DialogResult.OK)
                if (ventana.ShowDialog() == DialogResult.OK)
                {
                    // Refrescamos los datos para ver la nueva asignación en el Grid
                    CargarComboMaestros();
                    CargarGrid();

                    MessageBox.Show("La materia ha sido asignada al maestro correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscar fBusqueda = new FormBuscar())
            {
                if (fBusqueda.ShowDialog() == DialogResult.OK)
                {
                    // Enviamos los datos capturados de la ventanita al CargarGrid
                    CargarGrid(
                        comboBox1.Text,
                        fBusqueda.Seccion,
                        fBusqueda.Dia,
                        fBusqueda.Credito,
                        fBusqueda.Hora
                    );
                }
            }
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Solo actuamos si el usuario cambió la selección (tiene el foco)
            if (comboBox1.Focused && comboBox1.SelectedIndex != -1)
            {
                // Al seleccionar un maestro (o "Todos"), cargamos el grid 
                // enviando solo el nombre y dejando los demás filtros vacíos.
                CargarGrid(comboBox1.Text, "", "", "", "");
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
            CargarComboMaestros();
            CargarGrid();
            MessageBox.Show("Datos actualizados correctamente.", "Nítido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
