using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;
using PuntoVentaApp.Datos;

namespace PuntoVentaApp
{
    public partial class FrmVentas : Form
    {
        private string cadenaConexion;
        private string perfil;
        private VentasDAO ventasDAO;

        public FrmVentas(string cadenaConexion, string perfil)
        {
            InitializeComponent();
            EstiloUI.Aplicar(this);
            EstiloUI.AgregarFranjaSuperior(this);
            this.cadenaConexion = cadenaConexion;
            this.perfil = perfil;
            ventasDAO = new VentasDAO(cadenaConexion);

            CargarClientes();
            CargarProductos();
            CargarMetodosPago();
            ConfigurarTabla();
        }

        private void CargarClientes()
        {
            try
            {
                DataTable tabla = ventasDAO.ObtenerClientes();

                cmbClientes.DataSource = tabla;
                cmbClientes.DisplayMember = "nombre_completo";
                cmbClientes.ValueMember = "id_cliente";
                cmbClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                DataTable tabla = ventasDAO.ObtenerProductos();

                cmbProductos.DataSource = tabla;
                cmbProductos.DisplayMember = "nombre";
                cmbProductos.ValueMember = "id_producto";
                cmbProductos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();

            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");

            cmbMetodoPago.SelectedIndex = -1;
        }

        private void ConfigurarTabla()
        {
            dgvDetalleVenta.Columns.Clear();
            dgvDetalleVenta.AutoGenerateColumns = false;

            dgvDetalleVenta.Columns.Add("id_producto", "ID");
            dgvDetalleVenta.Columns.Add("nombre", "Producto");
            dgvDetalleVenta.Columns.Add("precio", "Precio");
            dgvDetalleVenta.Columns.Add("cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("subtotal", "Subtotal");

            dgvDetalleVenta.Columns["id_producto"].Visible = false;

            dgvDetalleVenta.Columns["nombre"].FillWeight = 200;
            dgvDetalleVenta.Columns["precio"].FillWeight = 80;
            dgvDetalleVenta.Columns["cantidad"].FillWeight = 70;
            dgvDetalleVenta.Columns["subtotal"].FillWeight = 100;

            dgvDetalleVenta.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgvDetalleVenta.Columns["subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresa una cantidad válida mayor a cero.");
                txtCantidad.Focus();
                return;
            }

            DataRowView producto = (DataRowView)cmbProductos.SelectedItem;

            int idProducto = Convert.ToInt32(producto["id_producto"]);
            string nombre = producto["nombre"].ToString();
            decimal precio = Convert.ToDecimal(producto["precio"]);
            int stock = Convert.ToInt32(producto["stock"]);

            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock para esa cantidad.");
                return;
            }

            bool productoExistente = false;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (Convert.ToInt32(fila.Cells["id_producto"].Value) == idProducto)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["cantidad"].Value);
                    int nuevaCantidad = cantidadActual + cantidad;

                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show("No hay suficiente stock para esa cantidad.");
                        return;
                    }

                    decimal subtotal = precio * nuevaCantidad;

                    fila.Cells["cantidad"].Value = nuevaCantidad;
                    fila.Cells["subtotal"].Value = subtotal;

                    productoExistente = true;
                    break;
                }
            }

            if (!productoExistente)
            {
                decimal subtotal = precio * cantidad;

                dgvDetalleVenta.Rows.Add(
                    idProducto,
                    nombre,
                    precio,
                    cantidad,
                    subtotal
                );
            }

            decimal total = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                total += Convert.ToDecimal(fila.Cells["subtotal"].Value);
            }

            lblTotal.Text = "Total: " + total.ToString("C2");

            txtCantidad.Clear();
            cmbProductos.SelectedIndex = -1;
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto de la venta.");
                return;
            }

            dgvDetalleVenta.Rows.Remove(dgvDetalleVenta.SelectedRows[0]);

            decimal total = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                total += Convert.ToDecimal(fila.Cells["subtotal"].Value);
            }

            lblTotal.Text = "Total: " + total.ToString("C2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbClientes.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = -1;
            cmbProductos.SelectedIndex = -1;
            txtCantidad.Clear();

            dgvDetalleVenta.Rows.Clear();

            lblTotal.Text = "Total: $0.00";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un cliente.");
                return;
            }

            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un método de pago.");
                return;
            }

            if (dgvDetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Agrega productos a la venta.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Deseas registrar esta venta?",
                "Confirmar venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            string productosJson = "[";

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);

                productosJson += "{\"id_producto\":" + idProducto +
                                 ",\"cantidad\":" + cantidad + "},";
            }

            productosJson = productosJson.TrimEnd(',') + "]";

            try
            {
                int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
                string metodoPago = cmbMetodoPago.SelectedItem.ToString();

                int idVenta = ventasDAO.RegistrarVenta(
                    idCliente,
                    metodoPago,
                    productosJson
                );

                MessageBox.Show(
                    "Venta registrada correctamente.\nNúmero de venta: " + idVenta,
                    "Venta registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                btnLimpiar_Click(sender, e);
                CargarProductos();
            }
            catch (MySqlException ex)
            {
                string mensaje;

                switch (ex.Number)
                {
                    case 1062:
                        mensaje = "Ya existe un registro con esos datos.";
                        break;

                    case 1452:
                        mensaje = "El cliente o producto seleccionado no existe.";
                        break;

                    case 3819:
                        mensaje = "Los datos no cumplen las restricciones de la base de datos.";
                        break;

                    case 1044:
                    case 1142:
                    case 1370:
                        mensaje = "Tu usuario no tiene permisos para realizar esta operación.";
                        break;

                    case 1045:
                        mensaje = "No se pudo acceder a la base de datos. Verifica tus credenciales.";
                        break;

                    case 2002:
                    case 2003:
                        mensaje = "No se pudo conectar con el servidor de base de datos.";
                        break;

                    default:
                        mensaje = "Error de base de datos: " + ex.Message;
                        break;
                }

                MessageBox.Show(
                    mensaje,
                    "Error al registrar la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error inesperado:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}