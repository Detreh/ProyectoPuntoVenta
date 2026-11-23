using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PuntoVentaApp.Datos;

namespace PuntoVentaApp
{
    public partial class FrmClientes : Form
    {
        private string cadenaConexion;
        private string perfil;
        private int idClienteSeleccionado = 0;
        private ClientesDAO clientesDAO;

        public FrmClientes(string cadenaConexion, string perfil)
        {
            InitializeComponent();
            EstiloUI.Aplicar(this);
            EstiloUI.AgregarFranjaSuperior(this);

            this.cadenaConexion = cadenaConexion;
            this.perfil = perfil;

            clientesDAO = new ClientesDAO(cadenaConexion);

            CargarClientes();

            if (perfil != "Administrador")
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargarClientes(string filtro = "")
        {
            try
            {
                DataTable tabla = clientesDAO.ObtenerClientes(filtro);

                dgvClientes.DataSource = tabla;
                dgvClientes.ClearSelection();
                dgvClientes.CurrentCell = null;

                idClienteSeleccionado = 0;

                dgvClientes.Columns["id_cliente"].HeaderText = "ID";
                dgvClientes.Columns["nombre"].HeaderText = "Nombre";
                dgvClientes.Columns["apellidos"].HeaderText = "Apellidos";
                dgvClientes.Columns["telefono"].HeaderText = "Teléfono";
                dgvClientes.Columns["correo"].HeaderText = "Correo";
                dgvClientes.Columns["direccion"].HeaderText = "Dirección";
                dgvClientes.Columns["fecha_registro"].HeaderText = "Fecha de registro";

                dgvClientes.ClearSelection();
                dgvClientes.CurrentCell = null;

                idClienteSeleccionado = 0;

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                idClienteSeleccionado = Convert.ToInt32(fila.Cells["id_cliente"].Value);

                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["apellidos"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtNombre.Focus();
                return;
            }

            string correo = txtCorreo.Text.Trim();

            if (!string.IsNullOrWhiteSpace(correo))
            {
                try
                {
                    System.Net.Mail.MailAddress correoValidado =
                        new System.Net.Mail.MailAddress(correo);
                }
                catch
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.");
                    txtCorreo.Focus();
                    return;
                }
            }

            try
            {
                clientesDAO.AgregarCliente(
                    txtNombre.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    correo,
                    txtDireccion.Text.Trim()
                );

                MessageBox.Show("Cliente agregado correctamente.");

                CargarClientes();

                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ya existe un cliente registrado con ese correo.");
                }
                else
                {
                    MessageBox.Show("Error al agregar el cliente: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtNombre.Focus();
                return;
            }

            string correo = txtCorreo.Text.Trim();

            if (!string.IsNullOrWhiteSpace(correo))
            {
                try
                {
                    System.Net.Mail.MailAddress correoValidado =
                        new System.Net.Mail.MailAddress(correo);
                }
                catch
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.");
                    txtCorreo.Focus();
                    return;
                }
            }

            DialogResult resultado = MessageBox.Show(
                "¿Deseas guardar los cambios de este cliente?",
                "Confirmar edición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            try
            {
                clientesDAO.EditarCliente(
                    idClienteSeleccionado,
                    txtNombre.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    correo,
                    txtDireccion.Text.Trim()
                );

                MessageBox.Show("Cliente actualizado correctamente.");

                CargarClientes();

                LimpiarCampos();

                idClienteSeleccionado = 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ya existe otro cliente con ese correo electrónico.");
                }
                else
                {
                    MessageBox.Show("Error al editar el cliente: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                idClienteSeleccionado = Convert.ToInt32(fila.Cells["id_cliente"].Value);

                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["apellidos"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente de la tabla.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar a " +
                txtNombre.Text + " " + txtApellidos.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                clientesDAO.EliminarCliente(idClienteSeleccionado);

                MessageBox.Show("Cliente eliminado correctamente.");

                CargarClientes();

                LimpiarCampos();

                idClienteSeleccionado = 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "No se puede eliminar este cliente porque tiene ventas registradas.",
                        "Cliente relacionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            idClienteSeleccionado = 0;

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}