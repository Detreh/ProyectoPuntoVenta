using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PuntoVentaApp
{
    public static class EstiloUI
    {
        private static Color fondo = Color.FromArgb(241, 245, 249);
        private static Color azul = Color.FromArgb(37, 99, 235);
        private static Color oscuro = Color.FromArgb(30, 41, 59);
        private static Color blanco = Color.White;
        private static Color texto = Color.FromArgb(51, 65, 85);
        private static Color borde = Color.FromArgb(203, 213, 225);

        public static void Aplicar(Form formulario)
        {
            formulario.BackColor = fondo;
            formulario.Font = new Font("Verdana", 9F);
            formulario.ForeColor = texto;
            formulario.Icon = new Icon(
                Path.Combine(Application.StartupPath, "Imagenes", "icono.ico")
            );

            AplicarControles(formulario.Controls);
        }

        private static void AplicarControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is Button boton)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.Font = new Font("Segoe UI", 9F);
                    boton.Cursor = Cursors.Hand;

                    string nombre = boton.Text.ToLower();

                    if (nombre.Contains("eliminar") ||
                        nombre.Contains("salir"))
                    {
                        boton.BackColor = Color.FromArgb(220, 53, 69);
                        boton.ForeColor = blanco;
                    }
                    else if (nombre.Contains("registrar") ||
                             nombre.Contains("agregar"))
                    {
                        boton.BackColor = Color.FromArgb(22, 163, 74);
                        boton.ForeColor = blanco;
                    }
                    else if (nombre.Contains("buscar") ||
                             nombre.Contains("iniciar"))
                    {
                        boton.BackColor = azul;
                        boton.ForeColor = blanco;
                    }
                    else
                    {
                        boton.BackColor = Color.FromArgb(226, 232, 240);
                        boton.ForeColor = oscuro;
                    }
                }
                else if (control is TextBox textbox)
                {
                    textbox.Font = new Font("Segoe UI", 9F);
                    textbox.BackColor = blanco;
                    textbox.ForeColor = texto;
                }
                else if (control is ComboBox combo)
                {
                    combo.Font = new Font("Segoe UI", 9F);
                    combo.BackColor = blanco;
                    combo.ForeColor = texto;
                }
                else if (control is DataGridView tabla)
                {
                    tabla.BackgroundColor = blanco;
                    tabla.BorderStyle = BorderStyle.None;
                    tabla.EnableHeadersVisualStyles = false;

                    tabla.ColumnHeadersDefaultCellStyle.BackColor = oscuro;
                    tabla.ColumnHeadersDefaultCellStyle.ForeColor = blanco;
                    tabla.ColumnHeadersDefaultCellStyle.Font =
                        new Font("Segoe UI", 10F, FontStyle.Bold);

                    tabla.DefaultCellStyle.Font =
                        new Font("Segoe UI", 10F);

                    tabla.DefaultCellStyle.ForeColor = texto;
                    tabla.DefaultCellStyle.BackColor = blanco;

                    tabla.AlternatingRowsDefaultCellStyle.BackColor =
                        Color.FromArgb(241, 245, 249);

                    tabla.DefaultCellStyle.SelectionBackColor = azul;
                    tabla.DefaultCellStyle.SelectionForeColor = blanco;

                    tabla.GridColor = borde;
                }
                else if (control is Label etiqueta)
                {
                    etiqueta.ForeColor = texto;
                    etiqueta.Font = new Font("Segoe UI", 9F);
                }
                else if (control is GroupBox grupo)
                {
                    grupo.ForeColor = oscuro;
                    grupo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                if (control.HasChildren)
                {
                    AplicarControles(control.Controls);
                }
            }
        }
        public static void AplicarColoresMenu(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is Button boton)
                {
                    string nombre = boton.Text.ToLower();

                    Color color = oscuro;

                    if (nombre.Contains("producto"))
                        color = Color.FromArgb(37, 99, 235);

                    else if (nombre.Contains("cliente"))
                        color = Color.FromArgb(13, 148, 136);

                    else if (nombre.Contains("venta"))
                        color = Color.FromArgb(22, 163, 74);

                    else if (nombre.Contains("consulta") ||
                             nombre.Contains("reporte"))
                        color = Color.FromArgb(124, 58, 237);

                    else if (nombre.Contains("cerrar") ||
                             nombre.Contains("salir"))
                        color = Color.FromArgb(71, 85, 105);

                    boton.BackColor = color;
                    boton.ForeColor = Color.White;

                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;

                    // Efecto al pasar el cursor
                    boton.FlatAppearance.MouseOverBackColor =
                        ControlPaint.Light(color, 0.15f);

                    // Efecto al presionar
                    boton.FlatAppearance.MouseDownBackColor =
                        ControlPaint.Dark(color, 0.10f);

                    boton.Cursor = Cursors.Hand;
                }
            }
        }
        public static void AgregarFranjaSuperior(Form formulario)
        {
            if (formulario.Controls["pnlFranjaSuperior"] != null)
                return;

            Panel franja = new Panel();

            franja.Name = "pnlFranjaSuperior";
            franja.BackColor = Color.FromArgb(30, 41, 59);
            franja.Height = 12;
            franja.Location = new Point(0, 0);
            franja.Anchor = AnchorStyles.Top |
                            AnchorStyles.Left |
                            AnchorStyles.Right;

            franja.Width = formulario.ClientSize.Width;

            formulario.Controls.Add(franja);
            franja.BringToFront();
        }

    }
}