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
    public partial class FrmConsultas : Form
    {
        private string cadenaConexion;
        private string perfil;
        private ReportesDAO reportesDAO;
        private bool configurandoReportes = false;
        private Rectangle ventasBoundsOriginal;
        private Rectangle detalleBoundsOriginal;

        public FrmConsultas(string cadenaConexion, string perfil)
        {
            InitializeComponent();
            EstiloUI.Aplicar(this);
            EstiloUI.AgregarFranjaSuperior(this);
            ventasBoundsOriginal = dgvVentas.Bounds;
            detalleBoundsOriginal = dgvDetalleVenta.Bounds;
            ConfigurarTiposReporte();

            this.cadenaConexion = cadenaConexion;
            this.perfil = perfil;
            reportesDAO = new ReportesDAO(cadenaConexion);

            txtBuscar.Clear();
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;

            ConfigurarTabla();
            dgvVentas.CellClick += dgvVentas_CellClick;
            CargarVentas();
        }

        private void ConfigurarTabla()
        {
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.MultiSelect = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.AutoGenerateColumns = true;

            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.RowHeadersVisible = false;
            dgvDetalleVenta.AutoGenerateColumns = true;

            LimpiarDetalleVenta();
        }

        private void CargarVentas()
        {
            try
            {
                DataTable tabla = reportesDAO.ObtenerVentas(
                    txtBuscar.Text,
                    dtpFechaInicio.Checked,
                    dtpFechaInicio.Value,
                    dtpFechaFin.Checked,
                    dtpFechaFin.Value
                );

                dgvVentas.DataSource = tabla;

                dgvVentas.Columns["id_venta"].HeaderText = "N.º Venta";
                dgvVentas.Columns["fecha"].HeaderText = "Fecha";
                dgvVentas.Columns["cliente"].HeaderText = "Cliente";
                dgvVentas.Columns["metodo_pago"].HeaderText = "Método de pago";
                dgvVentas.Columns["total"].HeaderText = "Total";

                dgvVentas.Columns["total"].DefaultCellStyle.Format = "C2";

                CalcularTotalVentas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al consultar las ventas:\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CalcularTotalVentas()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvVentas.Rows)
            {
                if (fila.Cells["total"].Value != null)
                {
                    total += Convert.ToDecimal(fila.Cells["total"].Value);
                }
            }

            lblTotalVentas.Text = "Total vendido: " + total.ToString("C2");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Checked && dtpFechaFin.Checked &&
                dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor a la fecha final.",
                    "Fechas inválidas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            LimpiarDetalleVenta();
            CargarVentas();
        }

        private void btnMostarTodas_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;

            LimpiarDetalleVenta();
            CargarVentas();
        }

        private void CargarDetalleVenta(int idVenta)
        {
            try
            {
                DataTable tabla = reportesDAO.ObtenerDetalleVenta(idVenta);

                dgvDetalleVenta.DataSource = tabla;

                dgvDetalleVenta.Columns["producto"].HeaderText = "Producto";
                dgvDetalleVenta.Columns["cantidad"].HeaderText = "Cantidad";
                dgvDetalleVenta.Columns["precio_unitario"].HeaderText = "Precio unitario";
                dgvDetalleVenta.Columns["subtotal"].HeaderText = "Subtotal";

                dgvDetalleVenta.Columns["precio_unitario"].DefaultCellStyle.Format = "C2";
                dgvDetalleVenta.Columns["subtotal"].DefaultCellStyle.Format = "C2";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al consultar el detalle:\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idVenta = Convert.ToInt32(
                    dgvVentas.Rows[e.RowIndex].Cells["id_venta"].Value
                );

                CargarDetalleVenta(idVenta);
            }
        }

        private void LimpiarDetalleVenta()
        {
            DataTable tablaDetalle = new DataTable();
            tablaDetalle.Columns.Add("producto");
            tablaDetalle.Columns.Add("cantidad", typeof(int));
            tablaDetalle.Columns.Add("precio_unitario", typeof(decimal));
            tablaDetalle.Columns.Add("subtotal", typeof(decimal));

            dgvDetalleVenta.DataSource = tablaDetalle;

            dgvDetalleVenta.Columns["producto"].HeaderText = "Producto";
            dgvDetalleVenta.Columns["cantidad"].HeaderText = "Cantidad";
            dgvDetalleVenta.Columns["precio_unitario"].HeaderText = "Precio unitario";
            dgvDetalleVenta.Columns["subtotal"].HeaderText = "Subtotal";

            dgvDetalleVenta.Columns["precio_unitario"].DefaultCellStyle.Format = "C2";
            dgvDetalleVenta.Columns["subtotal"].DefaultCellStyle.Format = "C2";
        }
        private void ConfigurarTiposReporte()
        {
            configurandoReportes = true;

            cmbTipoReporte.Items.Clear();

            cmbTipoReporte.Items.Add("Historial de ventas");
            cmbTipoReporte.Items.Add("Reporte de inventario");
            cmbTipoReporte.Items.Add("Productos más vendidos");
            cmbTipoReporte.Items.Add("Ventas por método de pago");
            cmbTipoReporte.Items.Add("Ventas por mes");

            cmbTipoReporte.SelectedIndex = 0;

            configurandoReportes = false;
        }

        private void CargarInventario()
        {
            try
            {
                DataTable tabla = reportesDAO.ObtenerInventario();
                dgvVentas.DataSource = tabla;

                dgvVentas.Columns["id_producto"].HeaderText = "ID";
                dgvVentas.Columns["nombre"].HeaderText = "Producto";
                dgvVentas.Columns["categoria"].HeaderText = "Categoría";
                dgvVentas.Columns["precio"].HeaderText = "Precio";
                dgvVentas.Columns["stock"].HeaderText = "Existencias";
                dgvVentas.Columns["stock_minimo"].HeaderText = "Stock mínimo";
                dgvVentas.Columns["activo"].HeaderText = "Activo";
                dgvVentas.Columns["estado_stock"].HeaderText = "Estado";

                dgvVentas.Columns["precio"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["precio"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvVentas.Columns["stock"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.Columns["stock_minimo"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.Columns["activo"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.Columns["estado_stock"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarProductosMasVendidos()
        {
            try
            {
                DataTable tabla = reportesDAO.ObtenerProductosMasVendidos();
                dgvVentas.DataSource = tabla;

                dgvVentas.Columns["id_producto"].HeaderText = "ID";
                dgvVentas.Columns["nombre"].HeaderText = "Producto";
                dgvVentas.Columns["categoria"].HeaderText = "Categoría";
                dgvVentas.Columns["cantidad_vendida"].HeaderText = "Cantidad vendida";
                dgvVentas.Columns["total_generado"].HeaderText = "Total generado";

                dgvVentas.Columns["cantidad_vendida"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.Columns["total_generado"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["total_generado"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos más vendidos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarVentasPorMetodoPago()
        {
            dgvVentas.DataSource = reportesDAO.ObtenerVentasPorMetodoPago();

            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;

            dgvVentas.Columns["metodo_pago"].HeaderText = "Método de pago";
            dgvVentas.Columns["cantidad_ventas"].HeaderText = "Cantidad de ventas";
            dgvVentas.Columns["total_vendido"].HeaderText = "Total vendido";
            dgvVentas.Columns["promedio_venta"].HeaderText = "Promedio por venta";

            dgvVentas.Columns["total_vendido"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["promedio_venta"].DefaultCellStyle.Format = "C2";

            dgvDetalleVenta.DataSource = null;
            lblTotalVentas.Text = "";
        }
        private void CargarVentasPorMes()
        {
            dgvVentas.DataSource = reportesDAO.ObtenerVentasPorMes();

            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;

            dgvVentas.Columns["mes"].HeaderText = "Mes";
            dgvVentas.Columns["cantidad_ventas"].HeaderText = "Cantidad de ventas";
            dgvVentas.Columns["total_vendido"].HeaderText = "Total vendido";
            dgvVentas.Columns["promedio_venta"].HeaderText = "Promedio por venta";

            dgvVentas.Columns["total_vendido"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["promedio_venta"].DefaultCellStyle.Format = "C2";

            dgvDetalleVenta.DataSource = null;
            lblTotalVentas.Text = "";
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configurandoReportes)
                return;

            ConfigurarVistaReporte();

            int tipoReporte = cmbTipoReporte.SelectedIndex;

            bool esVentas = tipoReporte == 0;
            bool esInventario = tipoReporte == 1;
            bool esProductosMasVendidos = tipoReporte == 2;

            lblTitulo.Text = cmbTipoReporte.SelectedItem.ToString();

            lblBuscar.Visible = esVentas;
            txtBuscar.Visible = esVentas;
            dtpFechaInicio.Visible = esVentas;
            dtpFechaFin.Visible = esVentas;
            btnBuscar.Visible = esVentas;
            btnMostarTodas.Visible = esVentas;
            lblTotalVentas.Visible = esVentas;
            dgvDetalleVenta.Visible = esVentas;

            dgvVentas.Visible = true;

            switch (cmbTipoReporte.SelectedIndex)
            {
                case 0:
                    CargarVentas();
                    break;

                case 1:
                    CargarInventario();
                    break;

                case 2:
                    CargarProductosMasVendidos();
                    break;

                case 3:
                    CargarVentasPorMetodoPago();
                    break;

                case 4:
                    CargarVentasPorMes();
                    break;
            }
        }
        private void ConfigurarVistaReporte()
        {
            bool historial = cmbTipoReporte.SelectedIndex == 0;

            // Controles exclusivos del historial
            lblBuscar.Visible = historial;
            txtBuscar.Visible = historial;
            btnBuscar.Visible = historial;
            btnMostarTodas.Visible = historial;

            dtpFechaInicio.Visible = historial;
            dtpFechaFin.Visible = historial;

            dgvDetalleVenta.Visible = historial;

            // Ocultar títulos que no corresponden al reporte actual
            OcultarEtiqueta("Historial de ventas", !historial);
            OcultarEtiqueta("Detalle de la venta", !historial);
            OcultarEtiqueta("Desde:", !historial);
            OcultarEtiqueta("Hasta:", !historial);

            if (!historial)
            {
                // Hacer que la tabla aproveche el espacio disponible
                dgvVentas.Anchor = AnchorStyles.Top
                                 | AnchorStyles.Bottom
                                 | AnchorStyles.Left
                                 | AnchorStyles.Right;

                dgvVentas.Location = new Point(25, 130);

                dgvVentas.Size = new Size(
                    ClientSize.Width - 50,
                    ClientSize.Height - 190
                );

                dgvVentas.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dgvVentas.Bounds = ventasBoundsOriginal;
                dgvDetalleVenta.Bounds = detalleBoundsOriginal;
            }
        }
        private void OcultarEtiqueta(string texto, bool ocultar)
        {
            foreach (Control control in Controls)
            {
                if (control is Label && control.Text == texto)
                {
                    control.Visible = !ocultar;
                }
            }
        }
    }
}