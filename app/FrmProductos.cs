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
    public partial class FrmProductos : Form
    {
        private string cadenaConexion;
        private string perfil;
        private ProductosDAO productosDAO;

        public FrmProductos(string cadenaConexion, string perfil)
        {
            InitializeComponent();
            EstiloUI.Aplicar(this);
            EstiloUI.AgregarFranjaSuperior(this);

            this.cadenaConexion = cadenaConexion;
            this.perfil = perfil;

            productosDAO = new ProductosDAO(cadenaConexion);

            CargarProductos();

            if (perfil != "Administrador")
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargarProductos(string filtro = "")
        {
            try
            {
                DataTable tabla = productosDAO.ObtenerProductos(filtro);

                dgvProductos.DataSource = tabla;

                dgvProductos.Columns["id_producto"].HeaderText = "ID";
                dgvProductos.Columns["nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["descripcion_producto"].HeaderText = "Descripción";
                dgvProductos.Columns["categoria"].HeaderText = "Categoría";
                dgvProductos.Columns["precio"].HeaderText = "Precio";
                dgvProductos.Columns["stock"].HeaderText = "Existencias";
                dgvProductos.Columns["stock_minimo"].HeaderText = "Stock mínimo";
                dgvProductos.Columns["activo"].HeaderText = "Activo";

                dgvProductos.Columns["precio"].DefaultCellStyle.Format = "C2";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text.Trim());
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string categoria = txtCategoria.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (nombre == "" || categoria == "" ||
                txtPrecio.Text == "" || txtStock.Text == "" ||
                txtStockMinimo.Text == "")
            {
                MessageBox.Show("Completa todos los campos obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido mayor a cero.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero mayor o igual a cero.");
                return;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un número entero mayor o igual a cero.");
                return;
            }

            try
            {
                productosDAO.AgregarProducto(
                    nombre,
                    descripcion,
                    categoria,
                    precio,
                    stock,
                    stockMinimo
                );

                MessageBox.Show("Producto agregado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ya existe un producto con ese nombre.");
                }
                else
                {
                    MessageBox.Show("Error al agregar el producto: " + ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells["categoria"].Value.ToString();
                txtDescripcion.Text = dgvProductos.Rows[e.RowIndex].Cells["descripcion_producto"].Value.ToString();
                txtPrecio.Text = dgvProductos.Rows[e.RowIndex].Cells["precio"].Value.ToString();
                txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                txtStockMinimo.Text = dgvProductos.Rows[e.RowIndex].Cells["stock_minimo"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            int idProducto = Convert.ToInt32(
                dgvProductos.SelectedRows[0].Cells["id_producto"].Value
            );

            string nombre = txtNombre.Text.Trim();
            string categoria = txtCategoria.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (nombre == "" || categoria == "" ||
                txtPrecio.Text == "" || txtStock.Text == "" ||
                txtStockMinimo.Text == "")
            {
                MessageBox.Show("Completa todos los campos obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido mayor a cero.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero mayor o igual a cero.");
                return;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un número entero mayor o igual a cero.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Deseas guardar los cambios de este producto?",
                "Confirmar edición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                productosDAO.EditarProducto(
                    idProducto,
                    nombre,
                    descripcion,
                    categoria,
                    precio,
                    stock,
                    stockMinimo
                );

                MessageBox.Show("Producto actualizado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ya existe otro producto con ese nombre.");
                }
                else
                {
                    MessageBox.Show("Error al editar el producto: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            int idProducto = Convert.ToInt32(
                dgvProductos.SelectedRows[0].Cells["id_producto"].Value
            );

            string nombre = dgvProductos.SelectedRows[0].Cells["nombre"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar el producto '" + nombre + "'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                productosDAO.EliminarProducto(idProducto);

                MessageBox.Show("Producto eliminado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "No se puede eliminar este producto porque está relacionado con una venta.",
                        "Producto relacionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Error al eliminar el producto: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}