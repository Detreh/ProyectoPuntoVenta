using MySqlConnector;
using System.Configuration;

namespace PuntoVentaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            string cadena = ConfigurationManager
            .ConnectionStrings["PuntoVenta"]
            .ConnectionString;

            try
            {
                using (MySqlConnection conexion =
                    new MySqlConnection(cadena))
                {
                    conexion.Open();

                    MessageBox.Show(
                        "Conexión exitosa con MySQL",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al conectar con MySQL:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
