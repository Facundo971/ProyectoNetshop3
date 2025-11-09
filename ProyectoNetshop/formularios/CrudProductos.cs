using Microsoft.Data.SqlClient;
using ProyectoNetshop.BD;
using ProyectoNetshop.Cruds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace ProyectoNetshop.formularios
{
    public partial class CrudProductos : Form
    {
        // Campo para guardar la ruta de la imagen seleccionada
        private string? _imagenSeleccionadaPath = null;

        // Campo que indica el producto seleccionado
        private int _productoSeleccionadoId = -1;

        private int _productoSeleccionadoEliminado = 1; // 1 = no eliminado, 0 = eliminado

        private bool _suppressPrecioTextChanged = false;

        private const string ImagenPorDefectoPath = @"Resources\producto_defecto.jpg";

        public CrudProductos()
        {
            InitializeComponent();

            tbDescripcionProducto.KeyPress -= TbDescripcion_KeyPress;
            tbDescripcionProducto.KeyPress += TbDescripcion_KeyPress;

            Load += CrudProductos_Load;
            dgvProductos.CellClick += DgvProductos_CellClick;

            dgvProductos.MouseDown += DgvProductos_MouseDown;
            this.Click += Form_Or_Container_Click;

            tbBusquedaNombreProducto.TextChanged += Busqueda_TextChanged;
            tbBusquedaPrecioMinProducto.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbBusquedaPrecioMaxProducto.KeyPress += TextBox_OnlyDigits_KeyPress;

            tbBusquedaPrecioMinProducto.TextChanged += TbBusquedaPrecio_SanitizarTextChanged;
            tbBusquedaPrecioMaxProducto.TextChanged += TbBusquedaPrecio_SanitizarTextChanged;

            cbActivosProductos.CheckedChanged += Filtro_CheckedChanged;
            cbInactivosProductos.CheckedChanged += Filtro_CheckedChanged;
        }

        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescarProductos();
        }

        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return; 
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true; 
        }

        private void DgvProductos_MouseDown(object? sender, MouseEventArgs e)
        {
            var hit = dgvProductos.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0)
            {
                dgvProductos.ClearSelection();
                _productoSeleccionadoId = -1;
                LimpiarControlesProducto();
            }
            else
            {
                dgvProductos.ClearSelection();
                dgvProductos.Rows[hit.RowIndex].Selected = true;
            }
        }

        private void Form_Or_Container_Click(object? sender, EventArgs e)
        {
            dgvProductos.ClearSelection();
            _productoSeleccionadoId = -1;
            LimpiarControlesProducto();
        }

        private void TbBusquedaPrecio_SanitizarTextChanged(object? sender, EventArgs e)
        {
            if (_suppressPrecioTextChanged) return;

            var tb = sender as TextBox;
            if (tb == null) return;

            var original = tb.Text;
            var cleaned = new string(original.Where(char.IsDigit).ToArray());

            if (cleaned != original)
            {
                _suppressPrecioTextChanged = true;
                try
                {
                    var selStart = tb.SelectionStart;
                    tb.Text = cleaned;
                    tb.SelectionStart = Math.Min(cleaned.Length, Math.Max(0, selStart - (original.Length - cleaned.Length)));
                }
                finally
                {
                    _suppressPrecioTextChanged = false;
                }
            }

            FiltrarYRefrescarProductos();
        }

        private void btnCargarImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _imagenSeleccionadaPath = openFileDialog.FileName;

                    pbImagenProducto.Image?.Dispose();
                    pbImagenProducto.Image = Image.FromFile(_imagenSeleccionadaPath);
                    pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;

                    validarCampos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string accion = _productoSeleccionadoId < 0 ? "crear" : "actualizar";
            var dr = MessageBox.Show($"¿Seguro que deseas {accion} este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.Yes) return;

            var producto = new Producto_model
            {
                nombre = tbNombreProducto.Text.Trim(),
                descripcion = string.IsNullOrWhiteSpace(tbDescripcionProducto.Text) ? null : tbDescripcionProducto.Text.Trim(),
                imagen = string.IsNullOrWhiteSpace(_imagenSeleccionadaPath) ? ImagenPorDefectoPath : _imagenSeleccionadaPath,
                precio = decimal.TryParse(tbPrecioProducto.Text.Trim(), out decimal p) ? p : 0m,
                precio_vta = decimal.TryParse(tbPrecioVentaProducto.Text.Trim(), out decimal pv) ? pv : 0m,
                stock = int.TryParse(tbStockProducto.Text.Trim(), out int s) ? s : 0,
                eliminado = rbProductoEliminadoNo.Checked ? 1 : 0,
                id_marca = Convert.ToInt32(cbMarcaProducto.SelectedValue),
                id_categoria = Convert.ToInt32(cbCategoriaProducto.SelectedValue)
            };

            // Ejecutar INSERT o UPDATE
            int filas;
            if (_productoSeleccionadoId < 0)
            {
                filas = Producto_controller.agregarProducto(producto);
            }
            else
            {
                producto.id_producto = _productoSeleccionadoId;
                filas = Producto_controller.actualizarProducto(producto);
            }

            if (filas == 1)
            {
                MessageBox.Show(_productoSeleccionadoId < 0 ? "Producto creado con éxito." : "Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FiltrarYRefrescarProductos();

                var lista = dgvProductos.DataSource as List<Producto_model>;
                Producto_model encontrado = null;
                if (_productoSeleccionadoId > 0 && lista != null)
                    encontrado = lista.FirstOrDefault(x => x.id_producto == _productoSeleccionadoId);

                if (encontrado == null && lista != null)
                    encontrado = lista.FirstOrDefault(x => x.nombre == producto.nombre && x.id_marca == producto.id_marca && x.id_categoria == producto.id_categoria);

                if (encontrado != null)
                {
                    for (int i = 0; i < dgvProductos.Rows.Count; i++)
                    {
                        var itm = dgvProductos.Rows[i].DataBoundItem as Producto_model;
                        if (itm != null && itm.id_producto == encontrado.id_producto)
                        {
                            dgvProductos.ClearSelection();
                            dgvProductos.Rows[i].Selected = true;
                            CargarProductoEnControles(encontrado);
                            break;
                        }
                    }
                }
                else
                {
                    LimpiarControlesProducto();
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error durante la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            FiltrarYRefrescarProductos();
            LimpiarControlesProducto();
        }

        private void FiltrarYRefrescarProductos()
        {
            var productos = ObtenerProductos();
            var filtrados = productos
                .Where(p => (cbActivosProductos.Checked && p.eliminado == 1) || (cbInactivosProductos.Checked && p.eliminado == 0))
                .ToList();

            var textoNom = tbBusquedaNombreProducto.Text.Trim();
            if (!string.IsNullOrEmpty(textoNom))
                filtrados = filtrados.Where(p => p.nombre != null && p.nombre.IndexOf(textoNom, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (int.TryParse(tbBusquedaPrecioMinProducto.Text.Trim(), out int precioMin))
                filtrados = filtrados.Where(p => p.precio >= precioMin).ToList();
            if (int.TryParse(tbBusquedaPrecioMaxProducto.Text.Trim(), out int precioMax))
                filtrados = filtrados.Where(p => p.precio <= precioMax).ToList();

            var marcas = ObtenerMarcas();
            var categorias = ObtenerCategorias();

            for (int i = 0; i < filtrados.Count; i++)
            {
                var item = filtrados[i];
                item.descripcionMarca = marcas.FirstOrDefault(m => m.id_marca == item.id_marca)?.descripcion ?? "Desconocido";
                item.descripcionCategoria = categorias.FirstOrDefault(c => c.id_categoria == item.id_categoria)?.descripcion ?? "Desconocido";
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;

            dgvProductos.ClearSelection();
            _productoSeleccionadoId = -1;
            ActualizarEstadoBtnBorrar();
        }

        private void CargarProductoEnControles(Producto_model p)
        {
            if (p == null) { LimpiarControlesProducto(); return; }

            _productoSeleccionadoId = p.id_producto;
            _productoSeleccionadoEliminado = p.eliminado;

            tbNombreProducto.Text = p.nombre ?? string.Empty;
            tbDescripcionProducto.Text = p.descripcion ?? string.Empty;
            tbPrecioProducto.Text = ((int)p.precio).ToString();
            tbPrecioVentaProducto.Text = ((int)p.precio_vta).ToString();
            tbStockProducto.Text = p.stock.ToString();

            try { cbMarcaProducto.SelectedValue = p.id_marca; } catch { cbMarcaProducto.SelectedIndex = -1; }
            try { cbCategoriaProducto.SelectedValue = p.id_categoria; } catch { cbCategoriaProducto.SelectedIndex = -1; }

            rbProductoEliminadoSi.Checked = (p.eliminado == 0);
            rbProductoEliminadoNo.Checked = (p.eliminado != 1);

            gbEstadoProducto.Visible = (p.eliminado == 0);

            ActualizarEstadoBtnBorrar();

            CargarImagenEnPictureBox(p.imagen);
        }

        private void LimpiarControlesProducto()
        {
            tbNombreProducto.Clear();
            tbDescripcionProducto.Clear();

            if (pbImagenProducto.Image != null)
            {
                pbImagenProducto.Image.Dispose();
                pbImagenProducto.Image = null;
            }
            try
            {
                pbImagenProducto.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
                pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pbImagenProducto.Image = null;
            }

            _imagenSeleccionadaPath = null;
            tbPrecioProducto.Clear();
            tbPrecioVentaProducto.Clear();
            tbStockProducto.Clear();

            rbProductoEliminadoNo.Checked = true;
            rbProductoEliminadoSi.Checked = false;
            cbMarcaProducto.SelectedIndex = -1;
            cbCategoriaProducto.SelectedIndex = -1;

            _productoSeleccionadoId = -1;
            _productoSeleccionadoEliminado = 1;

            gbEstadoProducto.Visible = false;
            btnBorrarProducto.Enabled = false;
            btnGuardarProducto.Enabled = false;

            ActualizarEstadoBtnBorrar();
        }

        private List<Producto_model> ObtenerProductos()
        {
            var lista = new List<Producto_model>();
            using var con = BD.BaseDeDatos.obtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"SELECT id_producto, nombre, descripcion, precio, stock, imagen, 
                                       eliminado, precio_vta, id_marca, id_categoria FROM producto";
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string? descripcion = rd.IsDBNull(2) ? null : rd.GetString(2);
                string? imagen = rd.IsDBNull(5) ? null : rd.GetString(5);

                var producto = new Producto_model
                {
                    id_producto = rd.GetInt32(0),
                    nombre = rd.GetString(1),
                    descripcion = descripcion,
                    precio = rd.GetDecimal(3),
                    stock = rd.GetInt32(4),
                    imagen = imagen,
                    eliminado = rd.GetInt32(6),
                    precio_vta = rd.GetDecimal(7),
                    id_marca = rd.GetInt32(8),
                    id_categoria = rd.GetInt32(9)
                };

                lista.Add(producto);
            }

            return lista;
        }

        private List<Marca_model> ObtenerMarcas()
        {
            var lista = new List<Marca_model>();

            using (SqlConnection conexion = BD.BaseDeDatos.obtenerConexion())
            using (SqlCommand comando = new SqlCommand("SELECT id_marca, descripcion, activo FROM marca", conexion))
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var marca = new Marca_model(
                            reader.GetInt32(0), // id_marca
                            reader.GetString(1), // nombre
                            reader.GetInt32(2) // activo
                        );
                        lista.Add(marca);
                    }
                }
            }

            return lista;
        }

        private List<Categoria_model> ObtenerCategorias()
        {
            var lista = new List<Categoria_model>();

            using (SqlConnection conexion = BD.BaseDeDatos.obtenerConexion())
            using (SqlCommand comando = new SqlCommand("SELECT id_categoria, descripcion, activo FROM categoria", conexion))
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoria = new Categoria_model(
                            reader.GetInt32(0), // id_categoria
                            reader.GetString(1), // nombre
                            reader.GetInt32(2) // activo
                        );
                        lista.Add(categoria);
                    }
                }
            }

            return lista;
        }


        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetraONumero = char.IsLetterOrDigit(e.KeyChar);
            bool esEspacio = e.KeyChar == ' ';

            if (!esControl && !esLetraONumero && !esEspacio)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras, números y espacios.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetraONumero = char.IsLetterOrDigit(e.KeyChar);
            bool esEspacio = e.KeyChar == ' ';

            if (!esControl && !esLetraONumero && !esEspacio)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras, números y espacios en la descripción.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbiDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CrudProductos_Load(object sender, EventArgs e)
        {
            btnGuardarProducto.Enabled = false;

            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;

            cbActivosProductos.CheckedChanged += Filtro_CheckedChanged;
            cbInactivosProductos.CheckedChanged += Filtro_CheckedChanged;

            cbActivosProductos.Checked = true;
            cbInactivosProductos.Checked = true;

            var marcas = ObtenerMarcas();
            cbMarcaProducto.DataSource = marcas;
            cbMarcaProducto.DisplayMember = "descripcion";
            cbMarcaProducto.ValueMember = "id_marca";
            cbMarcaProducto.SelectedIndex = -1;

            var categorias = ObtenerCategorias();
            cbCategoriaProducto.DataSource = categorias;
            cbCategoriaProducto.DisplayMember = "descripcion";
            cbCategoriaProducto.ValueMember = "id_categoria";
            cbCategoriaProducto.SelectedIndex = -1;

            // Llamada inicial a validarCampos para ajustar el estado del botón
            validarCampos();

            // Obtengo la lista de usuarios
            var productos = ObtenerProductos();

            // Obtener la descripcion de marcas de cada producto
            for (int i = 0; i < productos.Count; i++)
            {
                for (int j = 0; j < marcas.Count; j++)
                {
                    if (productos[i].id_marca == marcas[j].id_marca)
                    {
                        productos[i].descripcionMarca = marcas[j].descripcion;
                        break;
                    }
                }
            }

            // Obtener la descripcion de categorias de cada producto
            for (int i = 0; i < productos.Count; i++)
            {
                for (int j = 0; j < categorias.Count; j++)
                {
                    if (productos[i].id_categoria == categorias[j].id_categoria)
                    {
                        productos[i].descripcionCategoria = categorias[j].descripcion;
                        break;
                    }
                }
            }

            dgvProductos.CellClick += DgvProductos_CellClick;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            // Ajustar columnas al ancho del grid
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_producto",
                DataPropertyName = "id_producto",
                HeaderText = "ID"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre",
                DataPropertyName = "nombre",
                HeaderText = "Nombre"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "descripcion",
                DataPropertyName = "descripcion",
                HeaderText = "Descripción"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "precio",
                DataPropertyName = "precio",
                HeaderText = "Precio",
                DefaultCellStyle = {
                    Format = "C",
                    FormatProvider = new CultureInfo("es-AR")
                }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "precio_vta",
                DataPropertyName = "precio_vta",
                HeaderText = "Precio Venta",
                DefaultCellStyle = {
                    Format = "C",
                    FormatProvider = new CultureInfo("es-AR")
                }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "stock",
                DataPropertyName = "stock",
                HeaderText = "Stock"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_marca",
                DataPropertyName = "descripcionMarca",
                HeaderText = "Marca"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_categoria",
                DataPropertyName = "descripcionCategoria",
                HeaderText = "Categoría"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "eliminado",
                DataPropertyName = "EliminadoTexto",
                HeaderText = "Eliminado"
            });

            dgvProductos.Columns["id_producto"].Visible = false;

            dgvProductos.DataSource = productos;
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var p = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto_model;
            if (p == null) return;

            _productoSeleccionadoId = p.id_producto;
            _productoSeleccionadoEliminado = p.eliminado;

            tbNombreProducto.Text = p.nombre ?? string.Empty;
            tbDescripcionProducto.Text = p.descripcion ?? string.Empty;

            tbPrecioProducto.Text = ((int)p.precio).ToString();
            tbPrecioVentaProducto.Text = ((int)p.precio_vta).ToString();

            tbStockProducto.Text = p.stock.ToString();

            try { cbMarcaProducto.SelectedValue = p.id_marca; } catch { cbMarcaProducto.SelectedIndex = -1; }
            try { cbCategoriaProducto.SelectedValue = p.id_categoria; } catch { cbCategoriaProducto.SelectedIndex = -1; }

            rbProductoEliminadoSi.Checked = (p.eliminado == 0);
            rbProductoEliminadoNo.Checked = (p.eliminado == 1);

            gbEstadoProducto.Visible = (p.eliminado == 0);

            ActualizarEstadoBtnBorrar();

            CargarImagenEnPictureBox(p.imagen);
        }

        private void CargarImagenEnPictureBox(string rutaImagen)
        {
            if (pbImagenProducto.Image != null)
            {
                pbImagenProducto.Image.Dispose();
                pbImagenProducto.Image = null;
            }

            _imagenSeleccionadaPath = null;

            if (!string.IsNullOrWhiteSpace(rutaImagen) && File.Exists(rutaImagen))
            {
                try
                {
                    using (var src = Image.FromFile(rutaImagen))
                    {
                        pbImagenProducto.Image = new Bitmap(src);
                    }
                    _imagenSeleccionadaPath = rutaImagen;
                    pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;
                }
                catch
                {
                }
            }
            try
            {
                pbImagenProducto.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
                pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pbImagenProducto.Image = null;
            }
        }

        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbActivosProductos.Checked && !cbInactivosProductos.Checked)
            {
                var cb = sender as CheckBox;
                if (cb != null)
                    cb.Checked = true;
                return;
            }

            FiltrarYRefrescarProductos();
        }

        private void validarCampos()
        {
            bool baseValida = !string.IsNullOrWhiteSpace(tbNombreProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbPrecioProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbPrecioVentaProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbStockProducto.Text) &&
                              cbMarcaProducto.SelectedIndex >= 0 &&
                              cbCategoriaProducto.SelectedIndex >= 0;
            if (!baseValida)
            {
                btnGuardarProducto.Enabled = false;
                ActualizarEstadoBtnBorrar();
                return;
            }

            bool precioOk = decimal.TryParse(
                               tbPrecioProducto.Text.Trim(),
                               NumberStyles.Number,
                               CultureInfo.InvariantCulture,
                               out decimal precioOriginal);

            bool ventaOk = decimal.TryParse(
                               tbPrecioVentaProducto.Text.Trim(),
                               NumberStyles.Number,
                               CultureInfo.InvariantCulture,
                               out decimal precioVenta);

            bool stockOk = int.TryParse(
                               tbStockProducto.Text.Trim(),
                               NumberStyles.Integer,
                               CultureInfo.InvariantCulture,
                               out int stock);

            if (!precioOk || !ventaOk || !stockOk)
            {
                btnGuardarProducto.Enabled = false;
                ActualizarEstadoBtnBorrar();
                return;
            }

            btnGuardarProducto.Enabled = (precioVenta < precioOriginal);
            ActualizarEstadoBtnBorrar();
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbiDProducto_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }


        private void tbStock_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbMarca_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionadoId < 0)
            {
                LimpiarControlesProducto();
                return;
            }

            if (_productoSeleccionadoEliminado == 0)
            {
                MessageBox.Show("El producto ya se encuentra eliminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBorrarProducto.Enabled = false;
                return;
            }

            var dr = MessageBox.Show("¿Seguro que deseas marcar este producto como eliminado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.Yes) return;

            int filas = Producto_controller.CambiarEstadoEliminado(_productoSeleccionadoId, 0);
            if (filas == 1)
            {
                MessageBox.Show("Producto marcado como eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FiltrarYRefrescarProductos();
                LimpiarControlesProducto();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al cambiar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TieneDatosEnFormulario()
        {
            if (!string.IsNullOrWhiteSpace(tbNombreProducto.Text)) return true;
            if (!string.IsNullOrWhiteSpace(tbDescripcionProducto.Text)) return true;
            if (!string.IsNullOrWhiteSpace(tbPrecioProducto.Text)) return true;
            if (!string.IsNullOrWhiteSpace(tbPrecioVentaProducto.Text)) return true;
            if (!string.IsNullOrWhiteSpace(tbStockProducto.Text)) return true;
            if (cbMarcaProducto.SelectedIndex >= 0) return true;
            if (cbCategoriaProducto.SelectedIndex >= 0) return true;
            if (!string.IsNullOrWhiteSpace(_imagenSeleccionadaPath)) return true;
            return false;
        }


        private void ActualizarEstadoBtnBorrar()
        {
            bool seleccionValida = (_productoSeleccionadoId > 0) && (_productoSeleccionadoEliminado != 0);

            bool formularioConDatos = TieneDatosEnFormulario();

            btnBorrarProducto.Enabled = seleccionValida || formularioConDatos;
        }



        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBusquedaPrecioMinProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBusquedaPrecioMaxProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbImagenProducto_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

