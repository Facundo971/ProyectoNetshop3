using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfiumViewer;
using ProyectoNetshop.Cruds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace ProyectoNetshop.formularios
{
    public partial class ventas : Form
    {
        //Vendedor
        private readonly int vendedorDni;
        private readonly string vendedorNombreCompleto;
        private readonly int vendedorId;

        //Cliente
        private ListBox lbClientesSugeridos = new ListBox();
        private Dictionary<string, Cliente_model> clientesMap = new Dictionary<string, Cliente_model>();

        //Producto
        private ListBox lbProductosSugeridos = new ListBox();
        private Dictionary<string, Producto_model> productosMap = new Dictionary<string, Producto_model>();
        private bool bloqueandoFiltroProducto = false;

        //Boton lista de productos
        private DataGridView dgvProductosVenta;
        private Panel panelVistaProductosVenta;

        //Vista del PDF
        private Panel panelVisorPdf;
        private PdfViewer visorPdf;

        public ventas(int p_dni, string p_nombre, int p_vendedor_id)
        {
            InitializeComponent();

            string dllOrigen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes", "win-x64", "native", "pdfium.dll");
            string dllDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdfium.dll");

            // Color de fondo
            Color fondoAzul = Color.FromArgb(0, 0, 64);

            // Crear visor PDF
            visorPdf = new PdfViewer
            {
                Dock = DockStyle.Fill
            };

            // Crear panel visor PDF
            panelVisorPdf = new Panel
            {
                Name = "panelVisorPdf",
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = fondoAzul,
                BorderStyle = BorderStyle.None
            };

            // Crear barra superior
            Panel panelBarraPdf = new Panel
            {
                Size = new Size(panelVisorPdf.Width, 60),
                Dock = DockStyle.Top,
                BackColor = fondoAzul
            };

            // Botón cerrar visor
            Button btnCerrarVisor = new Button
            {
                Text = "Cerrar",
                Size = new Size(120, 40),
                Location = new Point(10, 10),
                BackColor = Color.LightGray,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnCerrarVisor.FlatAppearance.BorderSize = 0;
            btnCerrarVisor.Click += (s, e) =>
            {
                visorPdf.Document?.Dispose();
                panelVisorPdf.Visible = false;
            };

            // Agregar botón a barra
            panelBarraPdf.Controls.Add(btnCerrarVisor);

            // Agregar barra y visor al panel principal
            panelVisorPdf.Controls.Add(panelBarraPdf);
            panelVisorPdf.Controls.Add(visorPdf);

            // Agregar panel al formulario
            this.Controls.Add(panelVisorPdf);
            panelVisorPdf.BringToFront();

            //Vendedor
            vendedorDni = p_dni;
            vendedorNombreCompleto = p_nombre;
            vendedorId = p_vendedor_id;

            // Eventos para autocompletar cliente y ocultar lista
            tbNombreClienteVenta.TextChanged += tbClienteFiltro_TextChanged;
            tbDniClienteVenta.TextChanged += tbClienteFiltro_TextChanged;
            tbEmailClienteVenta.TextChanged += tbClienteFiltro_TextChanged;
            tbNombreClienteVenta.Leave += OcultarListaClientes;
            tbDniClienteVenta.Leave += OcultarListaClientes;
            tbEmailClienteVenta.Leave += OcultarListaClientes;

            //Ocular lista del filtro
            this.MouseDown += OcultarListaClientesPorClickGlobal;

            cbVentaProductoVendidos.CheckedChanged += cbVentaProductoVendidos_CheckedChanged;
            cbVentaProductoCancelados.CheckedChanged += cbVentaProductoCancelados_CheckedChanged;
            cbVentaProductoPendientes.CheckedChanged += cbVentaProductoPendientes_CheckedChanged;
            cbVentaProductoPendientes.Checked = true;

            //Producto
            tbIdProductoVenta.TextChanged += tbProductoFiltro_TextChanged;
            tbNombreProductoVenta.TextChanged += tbProductoFiltro_TextChanged;
            tbIdProductoVenta.Leave += OcultarListaProductos;
            tbNombreProductoVenta.Leave += OcultarListaProductos;
            lbProductosSugeridos.Click += LbProductosSugeridos_Click;

            bListaProductosVenta.Click += bListaProductosVenta_Click;

            this.Load += ventas_Load;

            tbDniClienteVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbNombreClienteVenta.KeyPress += TextBox_OnlyLetters_KeyPress;

            tbNombreProductoVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            tbStockProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbPrecioVtaProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbCantidadProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbCantidadProductoVenta.TextChanged += ValidarCantidadVsStock;

            ibBotonAgregarProductoVenta.Click += IbBotonAgregarProductoVenta_Click;

            ibBotonAgregarProductoVenta.Enabled = false;

            dtpFechaVenta.ShowCheckBox = true;

            ibBotonGuardarVenta.Click -= ibBotonGuardarVenta_Click;
            ibBotonGuardarVenta.Click += ibBotonGuardarVenta_Click;
            ibBotonBorrarVenta.Click += ibBotonBorrarVenta_Click;

            dgvVentas.CellClick += dgvVentas_CellClick;
            dgvVentas.CellMouseMove += dgvVentas_CellMouseMove;
        }

        private void bListaProductosVenta_Click(object sender, EventArgs e)
        {
            var tbNombre = panelVistaProductosVenta.Controls["tbFiltroNombre"] as TextBox;
            var tbMin = panelVistaProductosVenta.Controls["tbFiltroPrecioMin"] as TextBox;
            var tbMax = panelVistaProductosVenta.Controls["tbFiltroPrecioMax"] as TextBox;
            var lblTitulo = panelVistaProductosVenta.Controls["lblTituloProductos"] as Label;

            tbNombre.KeyPress += txtFiltroNombre_KeyPress;
            tbMin.KeyPress += txtFiltroPrecio_KeyPress;
            tbMax.KeyPress += txtFiltroPrecio_KeyPress;

            lblTitulo.ForeColor = Color.White;
            tbNombre.Text = "";
            tbMin.Text = "";
            tbMax.Text = "";

            MostrarProductosEnGrid();
            panelVistaProductosVenta.Visible = true;
        }

        private void MostrarProductosEnGrid()
        {
            dgvProductosVenta.Columns.Clear();
            dgvProductosVenta.Rows.Clear();

            dgvProductosVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductosVenta.RowTemplate.Height = 80;
            dgvProductosVenta.AllowUserToAddRows = false;
            dgvProductosVenta.ReadOnly = true;

            dgvProductosVenta.Columns.Add(new DataGridViewImageColumn
            {
                Name = "colImagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dgvProductosVenta.Columns.Add("colNombre", "Nombre");
            dgvProductosVenta.Columns.Add("colDescripcion", "Descripción");
            dgvProductosVenta.Columns.Add("colPrecio", "Precio");
            dgvProductosVenta.Columns.Add("colStock", "Stock");
            dgvProductosVenta.Columns.Add("colMarca", "Marca");
            dgvProductosVenta.Columns.Add("colCategoria", "Categoría");

            var productos = Producto_controller.ObtenerProductos();

            foreach (var p in productos)
            {
                System.Drawing.Image img;

                if (!string.IsNullOrWhiteSpace(p.imagen) && File.Exists(p.imagen))
                {
                    img = System.Drawing.Image.FromFile(p.imagen);
                }
                else
                {
                    img = (Bitmap)Properties.Resources.producto_defecto.Clone();
                }

                dgvProductosVenta.Rows.Add(img, p.nombre, p.descripcion, p.precio_vta, p.stock, p.descripcionMarca, p.descripcionCategoria);
            }

            dgvProductosVenta.Columns["colPrecio"].DefaultCellStyle.Format = "C";
            dgvProductosVenta.Columns["colPrecio"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");
        }

        private void txtFiltroPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFiltroNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void AplicarFiltroProductos()
        {
            var nombre = panelVistaProductosVenta.Controls["tbFiltroNombre"] as TextBox;
            var precioMin = panelVistaProductosVenta.Controls["tbFiltroPrecioMin"] as TextBox;
            var precioMax = panelVistaProductosVenta.Controls["tbFiltroPrecioMax"] as TextBox;

            string nombreFiltro = nombre?.Text.Trim() ?? "";
            int min = int.TryParse(precioMin?.Text, out int pMin) ? pMin : 0;
            int max = int.TryParse(precioMax?.Text, out int pMax) ? pMax : int.MaxValue;

            var productosFiltrados = Producto_controller.ObtenerProductos()
                .Where(p => p.nombre.Contains(nombreFiltro, StringComparison.OrdinalIgnoreCase))
                .Where(p => p.precio_vta >= min && p.precio_vta <= max)
                .ToList();

            dgvProductosVenta.Rows.Clear();

            foreach (var p in productosFiltrados)
            {
                System.Drawing.Image img;

                if (!string.IsNullOrWhiteSpace(p.imagen) && File.Exists(p.imagen))
                {
                    img = System.Drawing.Image.FromFile(p.imagen);
                }
                else
                {
                    img = (Bitmap)Properties.Resources.producto_defecto.Clone();
                }

                dgvProductosVenta.Rows.Add(img, p.nombre, p.descripcion, p.precio_vta, p.stock, p.descripcionMarca, p.descripcionCategoria);
            }
        }

        private void tbClienteFiltro_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;
            if (campo == null) return;

            string nombre = "";
            string dni = "";
            string email = "";

            if (campo == tbNombreClienteVenta)
                nombre = campo.Text.Trim();
            else if (campo == tbDniClienteVenta)
                dni = campo.Text.Trim();
            else if (campo == tbEmailClienteVenta)
                email = campo.Text.Trim();

            var clientes = Cliente_controller.BuscarClientes(nombre, dni, email);

            clientesMap.Clear();
            lbClientesSugeridos.Items.Clear();

            foreach (var c in clientes)
            {
                string clave = campo == tbNombreClienteVenta ? $"{c.nombre} {c.apellido}" :
                               campo == tbDniClienteVenta ? c.dni.ToString() :
                               c.email;

                lbClientesSugeridos.Items.Add(clave);
                clientesMap[clave] = c;
            }

            if (lbClientesSugeridos.Parent != this)
                this.Controls.Add(lbClientesSugeridos);

            this.BeginInvoke(new Action(() =>
            {
                lbClientesSugeridos.Visible = false;

                Point posicionCampo = campo.PointToScreen(new Point(0, campo.Height));
                Point posicionEnFormulario = this.PointToClient(posicionCampo);
                lbClientesSugeridos.Location = posicionEnFormulario;
                lbClientesSugeridos.Width = campo.Width;
                lbClientesSugeridos.BringToFront();

                bool mostrar = !string.IsNullOrWhiteSpace(campo.Text) && lbClientesSugeridos.Items.Count > 0;
                lbClientesSugeridos.Visible = mostrar;
            }));
        }

        private void tbProductoFiltro_TextChanged(object sender, EventArgs e)
        {
            if (bloqueandoFiltroProducto) return;

            TextBox campo = sender as TextBox;
            if (campo == null) return;

            string nombre = "";
            string id = "";

            if (campo == tbNombreProductoVenta)
                nombre = campo.Text.Trim();
            else if (campo == tbIdProductoVenta)
                id = campo.Text.Trim();

            var productos = Producto_controller.BuscarProductos(nombre, id);

            productosMap.Clear();
            lbProductosSugeridos.Items.Clear();

            foreach (var p in productos)
            {
                string clave = campo == tbNombreProductoVenta ? p.nombre :
                               campo == tbIdProductoVenta ? p.id_producto.ToString() :
                               "";

                lbProductosSugeridos.Items.Add(clave);
                productosMap[clave] = p;
            }

            if (lbProductosSugeridos.Parent != this)
                this.Controls.Add(lbProductosSugeridos);

            this.BeginInvoke(new Action(() =>
            {
                lbProductosSugeridos.Visible = false;

                Point posicionCampo = campo.PointToScreen(new Point(0, campo.Height));
                Point posicionEnFormulario = this.PointToClient(posicionCampo);
                lbProductosSugeridos.Location = posicionEnFormulario;
                lbProductosSugeridos.Width = campo.Width;
                lbProductosSugeridos.BringToFront();

                lbProductosSugeridos.Visible = !string.IsNullOrWhiteSpace(campo.Text) && lbProductosSugeridos.Items.Count > 0;
            }));
        }

        private void LbProductosSugeridos_Click(object sender, EventArgs e)
        {
            if (lbProductosSugeridos.SelectedItem == null) return;

            string clave = lbProductosSugeridos.SelectedItem.ToString();
            if (!productosMap.ContainsKey(clave)) return;

            var producto = productosMap[clave];

            bloqueandoFiltroProducto = true;

            tbIdProductoVenta.Text = producto.id_producto.ToString();
            tbNombreProductoVenta.Text = producto.nombre;
            tbCategoriaProductoVenta.Text = producto.descripcionCategoria;
            tbMarcaProductoVenta.Text = producto.descripcionMarca;
            tbPrecioVtaProductoVenta.Text = producto.precio_vta.ToString("0.00");
            tbStockProductoVenta.Text = producto.stock.ToString();

            pbImagenProductoVenta.Image?.Dispose();

            if (!string.IsNullOrWhiteSpace(producto.imagen) && File.Exists(producto.imagen))
            {
                pbImagenProductoVenta.Image = System.Drawing.Image.FromFile(producto.imagen);
            }
            else
            {
                pbImagenProductoVenta.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
            }
            pbImagenProductoVenta.SizeMode = PictureBoxSizeMode.StretchImage;

            bloqueandoFiltroProducto = false;

            lbProductosSugeridos.Visible = false;
        }

        private void OcultarListaClientes(object sender, EventArgs e)
        {
            Task.Delay(100).ContinueWith(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!lbClientesSugeridos.Focused)
                        lbClientesSugeridos.Visible = false;
                }));
            });
        }

        private void ConectarOcultamientoEnControles(Control control)
        {
            control.MouseDown += OcultarListaClientesPorClickGlobal;

            foreach (Control hijo in control.Controls)
            {
                ConectarOcultamientoEnControles(hijo);
            }
        }

        private void OcultarListaClientesPorClickGlobal(object sender, MouseEventArgs e)
        {
            if (!tbNombreClienteVenta.Focused &&
                !tbDniClienteVenta.Focused &&
                !tbEmailClienteVenta.Focused &&
                !lbClientesSugeridos.Focused)
            {
                lbClientesSugeridos.Visible = false;
            }
        }

        private void OcultarListaProductos(object sender, EventArgs e)
        {
            Task.Delay(100).ContinueWith(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!lbProductosSugeridos.Focused)
                        lbProductosSugeridos.Visible = false;
                }));
            });
        }

        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox_OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void cbVentaProductoPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentaProductoPendientes.Checked)
            {
                cbVentaProductoVendidos.Checked = false;
                cbVentaProductoCancelados.Checked = false;
                MostrarCarritoEnGrid();

                decimal totalCarrito = ObtenerTotalCarrito();
                CultureInfo culturaAR = new CultureInfo("es-AR");
                lbTotalVendidoVenta.Text = totalCarrito.ToString("C", culturaAR);
            }
            else if (!cbVentaProductoVendidos.Checked && !cbVentaProductoCancelados.Checked)
            {
                cbVentaProductoPendientes.Checked = true;
            }
        }

        private void cbVentaProductoVendidos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentaProductoVendidos.Checked)
            {
                cbVentaProductoPendientes.Checked = false;
                cbVentaProductoCancelados.Checked = false;
                MostrarVentasPorEstadoEnGrid(2); // Finalizado

                decimal total = Venta_controller.ObtenerTotalVentasPorEstadoYVendedor(2, vendedorId);
                CultureInfo culturaAR = new CultureInfo("es-AR");
                lbTotalVendidoVenta.Text = total.ToString("C", culturaAR);
            }
            else if (!cbVentaProductoPendientes.Checked && !cbVentaProductoCancelados.Checked)
            {
                cbVentaProductoVendidos.Checked = true;
            }
        }

        private void cbVentaProductoCancelados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentaProductoCancelados.Checked)
            {
                cbVentaProductoPendientes.Checked = false;
                cbVentaProductoVendidos.Checked = false;
                MostrarVentasPorEstadoEnGrid(3);

                decimal total = Venta_controller.ObtenerTotalVentasPorEstadoYVendedor(3, vendedorId);
                CultureInfo culturaAR = new CultureInfo("es-AR");
                lbTotalVendidoVenta.Text = total.ToString("C", culturaAR);
            }
            else if (!cbVentaProductoPendientes.Checked && !cbVentaProductoVendidos.Checked)
            {
                cbVentaProductoCancelados.Checked = true;
            }
        }

        private void MostrarVentasPorEstadoEnGrid(int estado)
        {
            dgvVentas.Columns.Clear();
            dgvVentas.Rows.Clear();

            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.ReadOnly = true;

            var colIdOculta = new DataGridViewTextBoxColumn
            {
                Name = "colIdVenta",
                HeaderText = "ID Venta",
                Visible = false
            };
            dgvVentas.Columns.Add(colIdOculta);

            dgvVentas.Columns.Add("colNroFactura", "Nro Factura");
            dgvVentas.Columns.Add("colCliente", "Cliente");
            dgvVentas.Columns.Add("colVendedor", "Vendedor");
            dgvVentas.Columns.Add("colFecha", "Fecha");
            dgvVentas.Columns.Add("colTipoFactura", "Tipo Factura");
            dgvVentas.Columns.Add("colTotal", "Total");
            dgvVentas.Columns.Add("colEstado", "Estado");

            if (estado == 2)
            {
                var colCancelar = new DataGridViewButtonColumn
                {
                    Name = "colCancelar",
                    HeaderText = "Cancelar",
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true
                };
                dgvVentas.Columns.Add(colCancelar);

                var colDescargarPDF = new DataGridViewButtonColumn
                {
                    Name = "colDescargarPDF",
                    HeaderText = "PDF",
                    Text = "Descargar",
                    UseColumnTextForButtonValue = true
                };
                dgvVentas.Columns.Add(colDescargarPDF);
            }

            var ventas = Venta_controller.ObtenerVentasPorEstadoYVendedor(estado, vendedorId);
            foreach (var v in ventas)
            {
                dgvVentas.Rows.Add(
                    v.id_venta,
                    v.nro_factura,
                    v.nombre_cliente,
                    v.nombre_vendedor,
                    v.fecha.ToString("dd/MM/yyyy"),
                    v.tipo_factura,
                    v.total_venta.ToString("C", new CultureInfo("es-AR")),
                    estado == 2 ? "Finalizado" : "Cancelado"
                );
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void ventas_Load(object sender, EventArgs e)
        {
            //Vendedor
            tbDniVendedorVenta.Text = vendedorDni.ToString();
            tbNombreVendedorVenta.Text = vendedorNombreCompleto;
            tbIdVendedorVenta.Text = vendedorId.ToString();

            //Marcar como solo lectura para evitar edición (Vendedor)
            tbDniVendedorVenta.ReadOnly = true;
            tbNombreVendedorVenta.ReadOnly = true;
            tbIdVendedorVenta.ReadOnly = true;

            //Cliente
            lbClientesSugeridos.Visible = false;
            lbClientesSugeridos.Width = 300;
            lbClientesSugeridos.Height = 300;
            lbClientesSugeridos.BringToFront();

            lbClientesSugeridos.Click += LbClientesSugeridos_Click;

            //Producto
            lbProductosSugeridos.Visible = false;
            lbProductosSugeridos.Width = 300;
            lbProductosSugeridos.Height = 300;
            this.Controls.Add(lbProductosSugeridos);
            lbProductosSugeridos.BringToFront();

            panelVistaProductosVenta = new Panel();
            panelVistaProductosVenta.Name = "panelVistaProductosVenta";

            panelVistaProductosVenta.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 2);
            panelVistaProductosVenta.Location = new Point(0, 60);
            panelVistaProductosVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            panelVistaProductosVenta.Visible = false;
            panelVistaProductosVenta.BackColor = Color.FromArgb(0, 0, 64);
            this.Controls.Add(panelVistaProductosVenta);
            panelVistaProductosVenta.BringToFront();

            Label lblTitulo = new Label();
            lblTitulo.Name = "lblTituloProductos";
            lblTitulo.Text = "Lista de Productos";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(35, 15);
            lblTitulo.Visible = true;
            panelVistaProductosVenta.Controls.Add(lblTitulo);

            TextBox tbFiltroNombre = new TextBox();
            tbFiltroNombre.Name = "tbFiltroNombre";
            tbFiltroNombre.PlaceholderText = "Filtrar por nombre";
            tbFiltroNombre.Width = 200;
            tbFiltroNombre.Location = new Point(40, 50);

            TextBox tbFiltroPrecioMin = new TextBox();
            tbFiltroPrecioMin.Name = "tbFiltroPrecioMin";
            tbFiltroPrecioMin.PlaceholderText = "Precio mínimo";
            tbFiltroPrecioMin.Width = 120;
            tbFiltroPrecioMin.Location = new Point(260, 50);

            TextBox tbFiltroPrecioMax = new TextBox();
            tbFiltroPrecioMax.Name = "tbFiltroPrecioMax";
            tbFiltroPrecioMax.PlaceholderText = "Precio máximo";
            tbFiltroPrecioMax.Width = 120;
            tbFiltroPrecioMax.Location = new Point(400, 50);

            panelVistaProductosVenta.Controls.Add(tbFiltroNombre);
            panelVistaProductosVenta.Controls.Add(tbFiltroPrecioMin);
            panelVistaProductosVenta.Controls.Add(tbFiltroPrecioMax);

            tbFiltroNombre.TextChanged += (s, e) => AplicarFiltroProductos();
            tbFiltroPrecioMin.TextChanged += (s, e) => AplicarFiltroProductos();
            tbFiltroPrecioMax.TextChanged += (s, e) => AplicarFiltroProductos();

            int margenInferior = 20;
            int botonAltura = 40;

            dgvProductosVenta = new DataGridView();
            dgvProductosVenta.Name = "dgvProductosVenta";
            dgvProductosVenta.Location = new Point(40, 80);
            dgvProductosVenta.Size = new Size(panelVistaProductosVenta.Width - 80, panelVistaProductosVenta.Height - 120);
            dgvProductosVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvProductosVenta.ReadOnly = true;
            dgvProductosVenta.AllowUserToAddRows = false;
            dgvProductosVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvProductosVenta.Font, FontStyle.Bold);
            dgvProductosVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            panelVistaProductosVenta.Controls.Add(dgvProductosVenta);

            Button btnCerrarVista = new Button();
            btnCerrarVista.Cursor = Cursors.Hand;
            btnCerrarVista.Font = new System.Drawing.Font("Dubai", 12, FontStyle.Bold | FontStyle.Italic);
            btnCerrarVista.BackColor = Color.White;
            btnCerrarVista.ForeColor = SystemColors.ActiveCaptionText;
            btnCerrarVista.Text = "Volver";
            btnCerrarVista.Size = new Size(100, 40);
            btnCerrarVista.Location = new Point(1060, 20);
            btnCerrarVista.Click += (s, e) => panelVistaProductosVenta.Visible = false;

            panelVistaProductosVenta.Controls.Add(btnCerrarVista);

            dtpFechaVenta.ShowCheckBox = true;
            dtpFechaVenta.Checked = true;
            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Checked = true;
            dtpFechaVenta.ValueChanged += dtpFechaVenta_ValueChanged;

            cbTipoFacturaVenta.SelectedIndex = 0;

            dgvVentas.Columns.Clear();
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVentas.Columns.Add("colNombre", "Nombre Producto");
            dgvVentas.Columns.Add("colDescripcion", "Descripción");
            dgvVentas.Columns.Add("colCantidad", "Cantidad");
            dgvVentas.Columns.Add("colPrecioUnitario", "Precio Unitario");
            dgvVentas.Columns.Add("colTotal", "Total");
            dgvVentas.Columns.Add("colFecha", "Fecha");
            dgvVentas.Columns.Add("colEstado", "Estado");

            var colBorrar = new DataGridViewButtonColumn
            {
                Name = "colBorrar",
                HeaderText = "Acción",
                Text = "Borrar",
                UseColumnTextForButtonValue = true
            };
            dgvVentas.Columns.Add(colBorrar);

            dgvVentas.Columns["colDescripcion"].FillWeight = 200;
            dgvVentas.Columns["colNombre"].FillWeight = 100;
            dgvVentas.Columns["colCantidad"].FillWeight = 80;
            dgvVentas.Columns["colPrecioUnitario"].FillWeight = 80;
            dgvVentas.Columns["colTotal"].FillWeight = 80;
            dgvVentas.Columns["colFecha"].FillWeight = 100;
            dgvVentas.Columns["colEstado"].FillWeight = 100;
            dgvVentas.Columns["colBorrar"].FillWeight = 30;

            dgvVentas.ReadOnly = true;
            dgvVentas.Columns["colBorrar"].ReadOnly = false;

            dgvVentas.AllowUserToAddRows = false;

            dgvVentas.CellPainting += dgvVentas_CellPainting;

            MostrarCarritoEnGrid();
            ActualizarTotalVendido();

            ConectarOcultamientoEnControles(this);

            var clickFilter = new ClickMessageFilter();
            clickFilter.ClickFueraDetectado += (clickeado) =>
            {
                if (clickeado != tbNombreClienteVenta &&
                    clickeado != tbDniClienteVenta &&
                    clickeado != tbEmailClienteVenta &&
                    clickeado != lbClientesSugeridos)
                {
                    lbClientesSugeridos.Visible = false;
                }
            };

            Application.AddMessageFilter(clickFilter);

            if (CarritoVentaSession.Carrito.Count > 0)
            {
                var primerDetalle = CarritoVentaSession.Carrito.First();

                // Restaurar cliente
                tbNombreClienteVenta.Text = primerDetalle.nombre_cliente;
                tbDniClienteVenta.Text = primerDetalle.dni_cliente;
                tbEmailClienteVenta.Text = primerDetalle.email_cliente;
                tbIdClienteVenta.Text = primerDetalle.id_cliente.ToString();

                tbNombreClienteVenta.ReadOnly = true;
                tbDniClienteVenta.ReadOnly = true;
                tbEmailClienteVenta.ReadOnly = true;
                tbIdClienteVenta.ReadOnly = true;

                tbNombreClienteVenta.Enabled = false;
                tbDniClienteVenta.Enabled = false;
                tbEmailClienteVenta.Enabled = false;
                tbIdClienteVenta.Enabled = false;

                // Restaurar y bloquear tipo de factura
                cbTipoFacturaVenta.SelectedItem = primerDetalle.tipo_factura;
                cbTipoFacturaVenta.Enabled = false;

                // Restaurar y bloquear fecha
                dtpFechaVenta.Value = primerDetalle.fecha_venta;
                dtpFechaVenta.Enabled = false;
            }
        }

        private void dtpFechaVenta_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpFechaVenta.Checked)
            {
                dtpFechaVenta.Checked = true;
            }
        }

        private void dgvVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombreColumna = dgvVentas.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colBorrar" || nombreColumna == "colCancelar" || nombreColumna == "colDescargarPDF")
            {
                e.PaintBackground(e.CellBounds, true);

                int margen = 4;
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                    e.CellBounds.X + margen,
                    e.CellBounds.Y + margen,
                    e.CellBounds.Width - 2 * margen,
                    e.CellBounds.Height - 2 * margen
                );

                int radio = 8;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                    path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                    path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                    path.CloseFigure();

                    Color colorFondo = nombreColumna switch
                    {
                        "colBorrar" => Color.Red,
                        "colCancelar" => Color.Red,
                        "colDescargarPDF" => Color.Blue,
                    };

                    using (Brush backColorBrush = new SolidBrush(colorFondo))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(backColorBrush, path);
                    }

                    string texto = nombreColumna switch
                    {
                        "colBorrar" => "Borrar",
                        "colCancelar" => "Cancelar",
                        "colDescargarPDF" => "Descargar",
                        _ => ""
                    };

                    TextRenderer.DrawText(
                        e.Graphics,
                        texto,
                        dgvVentas.Font,
                        rect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
            }
        }

        private void dgvVentas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvVentas.Columns[e.ColumnIndex].Name;

                if (nombreColumna == "colBorrar" || nombreColumna == "colCancelar" || nombreColumna == "colDescargarPDF")
                {
                    dgvVentas.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvVentas.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombreColumna = dgvVentas.Columns[e.ColumnIndex].Name;

            // Botón "Cancelar" en ventas finalizadas
            if (nombreColumna == "colCancelar")
            {
                int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["colIdVenta"].Value);

                // Validación: evitar cancelación duplicada
                if (Venta_controller.YaFueCancelada(idVenta))
                {
                    MessageBox.Show("Esta venta ya fue cancelada previamente.", "Cancelación duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show("¿Está seguro que desea cancelar esta venta?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        bool exito = Venta_controller.CancelarVentaDuplicando(idVenta);
                        if (exito)
                        {
                            MostrarVentasPorEstadoEnGrid(2);
                        }
                        else
                        {
                            MessageBox.Show("La operación no se completó. Verificá si la venta tiene detalles o si el ID es válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error técnico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Botón "Borrar" en el carrito (ventas pendientes)
            else if (nombreColumna == "colBorrar")
            {
                DialogResult confirm = MessageBox.Show("¿Deseás eliminar este producto del carrito?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (confirm != DialogResult.Yes) return;

                string nombreProducto = dgvVentas.Rows[e.RowIndex].Cells["colNombre"].Value?.ToString();
                var item = CarritoVentaSession.Carrito.FirstOrDefault(p => p.producto_nombre == nombreProducto);
                if (item != null)
                {
                    CarritoVentaSession.Carrito.Remove(item);
                    MostrarCarritoEnGrid();

                    // Actualizar total
                    decimal totalCarrito = CarritoVentaSession.Carrito.Sum(p => p.precio_unitario * p.cantidad);
                    CultureInfo culturaAR = new CultureInfo("es-AR");
                    lbTotalVendidoVenta.Text = totalCarrito.ToString("C", culturaAR);
                }
            }
            else if (nombreColumna == "colDescargarPDF")
            {
                var fila = dgvVentas.Rows[e.RowIndex];
                string nroFactura = fila.Cells["colNroFactura"].Value?.ToString()?.Trim();

                if (Venta_controller.ExisteVentaCanceladaPorFactura(nroFactura))
                {
                    MessageBox.Show("No se puede descargar el PDF de una venta cancelada.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idVenta = Convert.ToInt32(fila.Cells["colIdVenta"].Value);

                try
                {
                    string rutaPdf = GenerarPdfVenta(idVenta);

                    if (string.IsNullOrWhiteSpace(rutaPdf) || !File.Exists(rutaPdf))
                    {
                        MessageBox.Show("No se pudo generar o encontrar el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult respuesta = MessageBox.Show("PDF generado correctamente.\n¿Deseás visualizarlo ahora?", "PDF generado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (respuesta == DialogResult.Yes)
                    {
                        visorPdf.Document?.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        string rutaTemporal = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.pdf");
                        File.Copy(rutaPdf, rutaTemporal, true);

                        visorPdf.Document = PdfiumViewer.PdfDocument.Load(rutaTemporal);
                        visorPdf.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
                        panelVisorPdf.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarTotalVendido()
        {
            decimal total = CarritoVentaSession.Carrito
                .Sum(d => d.cantidad * d.precio_unitario);

            CultureInfo culturaAR = new CultureInfo("es-AR");
            lbTotalVendidoVenta.Text = total.ToString("C", culturaAR);
        }

        private decimal ObtenerTotalCarrito()
        {
            return CarritoVentaSession.Carrito.Sum(p => p.precio_unitario * p.cantidad);
        }

        private void LbClientesSugeridos_Click(object sender, EventArgs e)
        {
            if (lbClientesSugeridos.SelectedItem == null) return;

            string clave = lbClientesSugeridos.SelectedItem.ToString();
            if (!clientesMap.ContainsKey(clave)) return;

            var cliente = clientesMap[clave];

            tbNombreClienteVenta.Text = $"{cliente.nombre} {cliente.apellido}";
            tbDniClienteVenta.Text = cliente.dni.ToString();
            tbEmailClienteVenta.Text = cliente.email;
            tbIdClienteVenta.Text = cliente.id_cliente.ToString();

            lbClientesSugeridos.Visible = false;
        }

        private void IbBotonAgregarProductoVenta_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (!int.TryParse(tbIdClienteVenta.Text, out int idCliente))
            {
                MessageBox.Show("Debe seleccionar un cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTipoFacturaVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaVenta = dtpFechaVenta.Value.Date;
            if (fechaVenta > DateTime.Today)
            {
                MessageBox.Show("La fecha de venta no puede ser mayor al día de hoy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbIdProductoVenta.Text, out int idProducto))
            {
                MessageBox.Show("Debe seleccionar un producto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbCantidadProductoVenta.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tbPrecioVtaProductoVenta.Text, out decimal precioUnitario))
            {
                MessageBox.Show("El precio de venta no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreIngresado = tbNombreProductoVenta.Text.Trim();
            string idIngresado = tbIdProductoVenta.Text.Trim();

            Producto_model producto = null;

            // Buscar por nombre
            if (productosMap.ContainsKey(nombreIngresado))
            {
                producto = productosMap[nombreIngresado];
            }
            // Buscar por ID si no se encontró por nombre
            else if (int.TryParse(idIngresado, out int idProd))
            {
                producto = productosMap.Values.FirstOrDefault(p => p.id_producto == idProd);
            }

            if (producto == null)
            {
                MessageBox.Show("El producto ingresado no es válido. Verifique que haya seleccionado un producto de la lista.", "Error de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string descripcion = string.IsNullOrWhiteSpace(producto.descripcion) ? null : producto.descripcion;
            string categoria = string.IsNullOrWhiteSpace(producto.descripcionCategoria) ? null : producto.descripcionCategoria;
            string marca = string.IsNullOrWhiteSpace(producto.descripcionMarca) ? null : producto.descripcionMarca;

            List<string> partes = new List<string>();

            if (!string.IsNullOrWhiteSpace(descripcion))
                partes.Add(descripcion);

            if (!string.IsNullOrWhiteSpace(categoria) || !string.IsNullOrWhiteSpace(marca))
            {
                string catMarca = $"Categoría: {categoria ?? "Sin categoría"} - Marca: {marca ?? "Sin marca"}";
                partes.Add($"({catMarca})");
            }

            string descripcionCompleta = partes.Count > 0 ? string.Join(" ", partes) : "Sin información";

            // Crear modelo temporal
            var detalle = new Venta_detalle_model
            {
                id_producto = producto.id_producto,
                cantidad = cantidad,
                precio_unitario = producto.precio_vta,
                producto_nombre = producto.nombre,
                producto_descripcion = descripcionCompleta,

                descripcionCategoria = producto.descripcionCategoria,
                descripcionMarca = producto.descripcionMarca,

                id_cliente = idCliente,
                nombre_cliente = tbNombreClienteVenta.Text,
                dni_cliente = tbDniClienteVenta.Text,
                email_cliente = tbEmailClienteVenta.Text,

                tipo_factura = cbTipoFacturaVenta.SelectedItem?.ToString(),
                fecha_venta = fechaVenta
            };

            var existente = CarritoVentaSession.Carrito.FirstOrDefault(p => p.id_producto == detalle.id_producto);

            if (existente != null)
            {
                existente.cantidad += detalle.cantidad;
            }
            else
            {
                CarritoVentaSession.Carrito.Add(detalle);
            }

            // Bloquear campos de cliente si es el primer producto agregado
            if (CarritoVentaSession.Carrito.Count == 1)
            {
                // Bloquear cliente
                tbNombreClienteVenta.ReadOnly = true;
                tbDniClienteVenta.ReadOnly = true;
                tbEmailClienteVenta.ReadOnly = true;
                tbIdClienteVenta.ReadOnly = true;

                tbNombreClienteVenta.Enabled = false;
                tbDniClienteVenta.Enabled = false;
                tbEmailClienteVenta.Enabled = false;
                tbIdClienteVenta.Enabled = false;

                // Bloquear tipo de factura
                cbTipoFacturaVenta.Enabled = false;

                // Bloquear fecha
                dtpFechaVenta.Enabled = false;
            }

            MostrarCarritoEnGrid();

            decimal totalCarrito = CarritoVentaSession.Carrito.Sum(p => p.precio_unitario * p.cantidad);
            CultureInfo culturaAR = new CultureInfo("es-AR");
            lbTotalVendidoVenta.Text = totalCarrito.ToString("C", culturaAR);

            // Limpiar campos
            tbIdProductoVenta.Clear();
            tbNombreProductoVenta.Clear();
            tbCategoriaProductoVenta.Clear();
            tbMarcaProductoVenta.Clear();
            tbPrecioVtaProductoVenta.Clear();
            tbStockProductoVenta.Clear();
            tbCantidadProductoVenta.Clear();
            pbImagenProductoVenta.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
            ibBotonAgregarProductoVenta.Enabled = false;

            ActualizarTotalVendido();
        }

        private void MostrarCarritoEnGrid()
        {
            dgvVentas.Columns.Clear();
            dgvVentas.Rows.Clear();

            dgvVentas.Columns.Add("colNombre", "Nombre Producto");
            dgvVentas.Columns.Add("colDescripcion", "Descripción");
            dgvVentas.Columns.Add("colCantidad", "Cantidad");
            dgvVentas.Columns.Add("colPrecioUnitario", "Precio Unitario");
            dgvVentas.Columns.Add("colTotal", "Total");
            dgvVentas.Columns.Add("colFecha", "Fecha");
            dgvVentas.Columns.Add("colEstado", "Estado");

            var colBorrar = new DataGridViewButtonColumn();
            colBorrar.Name = "colBorrar";
            colBorrar.HeaderText = "Acción";
            colBorrar.Text = "Borrar";
            colBorrar.UseColumnTextForButtonValue = true;
            dgvVentas.Columns.Add(colBorrar);

            CultureInfo culturaAR = new CultureInfo("es-AR");

            foreach (var item in CarritoVentaSession.Carrito)
            {
                decimal totalItem = item.precio_unitario * item.cantidad;

                dgvVentas.Rows.Add(
                    item.producto_nombre,
                    item.producto_descripcion,
                    item.cantidad,
                    item.precio_unitario.ToString("C", culturaAR),
                    totalItem.ToString("C", culturaAR),
                    item.fecha_venta.ToString("dd/MM/yyyy"),
                    "Pendiente"
                );
            }
        }

        private void ibBotonBuscarClienteVenta_Click(object sender, EventArgs e)
        {

        }

        private void ibBotonGuardarVenta_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show(
                "¿Deseás realizar la venta?",
                "Confirmar venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (confirmar != DialogResult.Yes)
                return;

            // Validaciones
            if (CarritoVentaSession.Carrito.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito para guardar la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbIdClienteVenta.Text, out int idCliente))
            {
                MessageBox.Show("Debe seleccionar un cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTipoFacturaVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaVenta = dtpFechaVenta.Checked ? dtpFechaVenta.Value.Date : DateTime.Today;
            if (fechaVenta > DateTime.Today)
            {
                MessageBox.Show("La fecha de venta no puede ser mayor al día de hoy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoFactura = cbTipoFacturaVenta.SelectedItem.ToString();

            // Validar stock agrupado por producto
            var productosAgrupados = CarritoVentaSession.Carrito
                .GroupBy(d => d.id_producto)
                .Select(g => new
                {
                    id_producto = g.Key,
                    cantidadTotal = g.Sum(d => d.cantidad),
                    nombre = g.First().producto_nombre
                });

            foreach (var item in productosAgrupados)
            {
                int stockActual = Producto_controller.ObtenerStockActual(item.id_producto);
                if (item.cantidadTotal > stockActual)
                {
                    MessageBox.Show($"No hay suficiente stock para el producto '{item.nombre}'. Stock disponible: {stockActual}, solicitado: {item.cantidadTotal}.", "Error de stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Calcular total de la venta
            decimal totalCalculado = CarritoVentaSession.Carrito
                .Sum(d => d.cantidad * d.precio_unitario);

            // Crear venta principal
            var venta = new Venta_model
            {
                id_cliente = idCliente,
                id_vendedor = vendedorId,
                fecha = fechaVenta,
                tipo_factura = tipoFactura,
                total_venta = totalCalculado,
                id_estado = 2
            };

            // Generar número de factura automáticamente
            string nroFacturaGenerado = Venta_controller.GenerarNroFactura(tipoFactura);
            venta.nro_factura = nroFacturaGenerado;

            int idVentaGenerada = Venta_controller.GuardarVenta(venta);

            if (idVentaGenerada <= 0)
            {
                MessageBox.Show("No se pudo guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guardar detalles y actualizar stock
            foreach (var detalle in CarritoVentaSession.Carrito)
            {
                var detalleVenta = new Venta_detalle_model
                {
                    id_venta = idVentaGenerada,
                    id_producto = detalle.id_producto,
                    cantidad = detalle.cantidad,
                    precio_unitario = detalle.precio_unitario
                };

                Venta_controller.GuardarDetalleVenta(detalleVenta);

                Producto_controller.ActualizarStock(detalle.id_producto, -detalle.cantidad);
            }

            DialogResult postVenta = MessageBox.Show(
                $"Venta realizada correctamente.\nFactura #{venta.nro_factura}\n¿Deseás visualizar el PDF?",
                "Venta finalizada",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2
            );

            if (postVenta == DialogResult.Yes)
            {
                string rutaPdf = GenerarPdfVenta(idVentaGenerada);

                visorPdf.Document?.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                string rutaTemporal = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.pdf");
                File.Copy(rutaPdf, rutaTemporal, true);

                visorPdf.Document = PdfiumViewer.PdfDocument.Load(rutaTemporal);
                visorPdf.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
                panelVisorPdf.Visible = true;
            }

            // Limpiar todo
            CarritoVentaSession.Carrito.Clear();
            MostrarCarritoEnGrid();
            ActualizarTotalVendido();
            LimpiarCamposVenta();
        }

        private void ibBotonBorrarVenta_Click(object sender, EventArgs e)
        {
            // Limpiar campos de producto
            tbIdProductoVenta.Clear();
            tbNombreProductoVenta.Clear();
            tbCategoriaProductoVenta.Clear();
            tbMarcaProductoVenta.Clear();
            tbPrecioVtaProductoVenta.Clear();
            tbStockProductoVenta.Clear();
            tbCantidadProductoVenta.Clear();
            pbImagenProductoVenta.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
            ibBotonAgregarProductoVenta.Enabled = false;

            // Limpiar campos de cliente
            tbIdClienteVenta.Clear();
            tbNombreClienteVenta.Clear();
            tbDniClienteVenta.Clear();
            tbEmailClienteVenta.Clear();

            // Restaurar campos de cliente
            tbNombreClienteVenta.ReadOnly = false;
            tbDniClienteVenta.ReadOnly = false;
            tbEmailClienteVenta.ReadOnly = false;
            tbIdClienteVenta.ReadOnly = false;

            tbNombreClienteVenta.Enabled = true;
            tbDniClienteVenta.Enabled = true;
            tbEmailClienteVenta.Enabled = true;
            tbIdClienteVenta.Enabled = true;

            // Limpiar campos de factura
            cbTipoFacturaVenta.SelectedIndex = 0;
            cbTipoFacturaVenta.Enabled = true;
            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Checked = true;
            dtpFechaVenta.Enabled = true;

            if (CarritoVentaSession.Carrito.Count > 0)
            {
                CarritoVentaSession.Carrito.Clear();
                MostrarCarritoEnGrid();
                ActualizarTotalVendido();
            }
        }

        private void LimpiarCamposVenta()
        {
            CarritoVentaSession.Carrito.Clear();

            tbIdProductoVenta.Clear();
            tbNombreProductoVenta.Clear();
            tbCategoriaProductoVenta.Clear();
            tbMarcaProductoVenta.Clear();
            tbPrecioVtaProductoVenta.Clear();
            tbStockProductoVenta.Clear();
            tbCantidadProductoVenta.Clear();
            pbImagenProductoVenta.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();

            tbIdClienteVenta.Clear();
            tbNombreClienteVenta.Clear();
            tbDniClienteVenta.Clear();
            tbEmailClienteVenta.Clear();

            tbNombreClienteVenta.ReadOnly = false;
            tbDniClienteVenta.ReadOnly = false;
            tbEmailClienteVenta.ReadOnly = false;
            tbIdClienteVenta.ReadOnly = false;

            tbNombreClienteVenta.Enabled = true;
            tbDniClienteVenta.Enabled = true;
            tbEmailClienteVenta.Enabled = true;
            tbIdClienteVenta.Enabled = true;

            cbTipoFacturaVenta.SelectedIndex = 0;
            cbTipoFacturaVenta.Enabled = true;
            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Checked = true;
            dtpFechaVenta.Enabled = true;

            ibBotonAgregarProductoVenta.Enabled = false;
        }

        private void tbPrecioVtaProductoVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDescripcionProductoVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tbNombreVendedorVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNombreClienteVenta_TextChanged(object sender, EventArgs e)
        {
            string nombre = tbNombreClienteVenta.Text.Trim();
            string dni = tbDniClienteVenta.Text.Trim();
            string email = tbEmailClienteVenta.Text.Trim();

            var clientes = Cliente_controller.BuscarClientes(
                string.IsNullOrWhiteSpace(nombre) ? "" : nombre,
                string.IsNullOrWhiteSpace(dni) ? "" : dni,
                string.IsNullOrWhiteSpace(email) ? "" : email
            );

            lbClientesSugeridos.Items.Clear();
            foreach (var c in clientes)
            {
                lbClientesSugeridos.Items.Add($"{c.nombre} {c.apellido} | DNI: {c.dni} | Email: {c.email}");
            }

            lbClientesSugeridos.Location = new Point(tbNombreClienteVenta.Left, tbNombreClienteVenta.Bottom);
            lbClientesSugeridos.Visible = clientes.Count > 0;
        }

        private void ValidarCantidadVsStock(object sender, EventArgs e)
        {
            string cantidadText = tbCantidadProductoVenta.Text.Trim();
            string stockText = tbStockProductoVenta.Text.Trim();

            if (int.TryParse(cantidadText, out int cantidad) &&
                int.TryParse(stockText, out int stock) &&
                cantidad > 0 &&
                cantidad <= stock)
            {
                ibBotonAgregarProductoVenta.Enabled = true;
            }
            else
            {
                ibBotonAgregarProductoVenta.Enabled = false;
            }
        }

        private void ibBotonAgregarProductoVenta_Click_1(object sender, EventArgs e)
        {

        }

        private void lbTotalVendidoVenta_Click(object sender, EventArgs e)
        {

        }

        private string GenerarPdfVenta(int idVenta)
        {
            var venta = Venta_controller.ObtenerCabeceraVenta(idVenta);
            var detalles = Venta_controller.ObtenerDetalleVenta(idVenta);
            if (venta == null || detalles.Count == 0)
            {
                MessageBox.Show("No se pudo generar el PDF. La venta está vacía o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Venta_{venta.nro_factura ?? idVenta.ToString()}_{timestamp}.pdf");

            // Generar el PDF
            using (FileStream stream = new FileStream(ruta, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fuenteTabla = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                CultureInfo culturaAR = new CultureInfo("es-AR");

                doc.Add(new Paragraph("Factura de Venta", fuenteTitulo));
                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteNormal));
                doc.Add(new Paragraph($"Factura: {venta.nro_factura ?? "Sin número"}", fuenteNormal));
                doc.Add(new Paragraph($"Cliente: {venta.nombre_cliente}", fuenteNormal));
                doc.Add(new Paragraph($"Vendedor: {venta.nombre_vendedor}", fuenteNormal));
                doc.Add(new Paragraph($"Tipo: {venta.tipo_factura}", fuenteNormal));
                doc.Add(new Paragraph($"Estado: {(venta.id_estado == 2 ? "Finalizado" : "Cancelado")}", fuenteNormal));
                doc.Add(new Paragraph(" "));

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.AddCell("Producto");
                tabla.AddCell("Cantidad");
                tabla.AddCell("Precio Unitario");
                tabla.AddCell("Subtotal");

                foreach (var d in detalles)
                {
                    tabla.AddCell(new Phrase(d.producto_nombre, fuenteTabla));
                    tabla.AddCell(new Phrase(d.cantidad.ToString(), fuenteTabla));
                    tabla.AddCell(new Phrase(d.precio_unitario.ToString("C", culturaAR), fuenteTabla));
                    tabla.AddCell(new Phrase((d.precio_unitario * d.cantidad).ToString("C", culturaAR), fuenteTabla));
                }

                doc.Add(tabla);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"TOTAL: {venta.total_venta.ToString("C", culturaAR)}", fuenteTitulo));

                doc.Close();
                stream.Close();
            }

            return ruta;
        }
    }
}
