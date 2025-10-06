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
        // Campo para guardar la ruta de la imagen seleccionada (nulo si no se eligió)
        private string? _imagenSeleccionadaPath = null;

        // Campo que indica el producto seleccionado (ejemplo ya visto)
        private int _productoSeleccionadoId = -1;

        private int _productoSeleccionadoEliminado = 1; // 1 = no eliminado, 0 = eliminado
        
        private bool _suppressPrecioTextChanged = false;

        public CrudProductos()
        {
            InitializeComponent();

            tbDescripcionProducto.KeyPress -= TbDescripcion_KeyPress;
            tbDescripcionProducto.KeyPress += TbDescripcion_KeyPress;

            // Subscribir handlers (igual que en usuarios)
            Load += CrudProductos_Load;
            dgvProductos.CellClick += DgvProductos_CellClick;

            // Búsqueda en tiempo real
            tbBusquedaNombreProducto.TextChanged += Busqueda_TextChanged;
            // Suscribir sanitizador y disparador a los TextBox de precio
            tbBusquedaPrecioMinProducto.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbBusquedaPrecioMaxProducto.KeyPress += TextBox_OnlyDigits_KeyPress;

            tbBusquedaPrecioMinProducto.TextChanged += TbBusquedaPrecio_SanitizarTextChanged;
            tbBusquedaPrecioMaxProducto.TextChanged += TbBusquedaPrecio_SanitizarTextChanged;


            // Checkboxes para activos/inactivos
            cbActivosProductos.CheckedChanged += Filtro_CheckedChanged;
            cbInactivosProductos.CheckedChanged += Filtro_CheckedChanged;
        }

        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescarProductos();
        }

        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;   // permitir Backspace, Delete, etc.
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;                     // bloquear cualquier otro carácter
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

            // Llamar al filtro una sola vez al final
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
                    // Guardar la ruta para usarla al guardar el producto
                    _imagenSeleccionadaPath = openFileDialog.FileName;

                    // Cargar imagen en el PictureBox
                    // Si la imagen ya fue cargada previamente y la descargaste, no olvides Dispose si corresponde
                    pbImagenProducto.Image?.Dispose();
                    pbImagenProducto.Image = Image.FromFile(_imagenSeleccionadaPath);
                    pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;

                    validarCampos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Confirmación de acción (crear o actualizar)
            string accion = _productoSeleccionadoId < 0 ? "crear" : "actualizar";
            var dr = MessageBox.Show($"¿Seguro que deseas {accion} este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            // Crear objeto Producto_model (se asume que la validación ya se hizo en otra capa)
            var producto = new Producto_model
            {
                nombre = tbNombreProducto.Text.Trim(),
                descripcion = string.IsNullOrWhiteSpace(tbDescripcionProducto.Text) ? null : tbDescripcionProducto.Text.Trim(),
                imagen = string.IsNullOrWhiteSpace(_imagenSeleccionadaPath) ? null : _imagenSeleccionadaPath,
                // Parseo sencillo de numéricos (si falla, quedará 0; la validación debe ocurrir en otra capa)
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

            // Resultado
            if (filas == 1)
            {
                MessageBox.Show(_productoSeleccionadoId < 0 ? "Producto creado con éxito." : "Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FiltrarYRefrescarProductos(); // recarga inmediata como usuarios
                LimpiarControlesProducto();
            }
            else
                MessageBox.Show("Ocurrió un error durante la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            FiltrarYRefrescarProductos();
            LimpiarControlesProducto();
        }

        private void FiltrarYRefrescarProductos()
        {
            var marcas = ObtenerMarcas();
            var categorias = ObtenerCategorias();
            var productos = ObtenerProductos();

            // Filtrar por activo/inactivo según CheckBoxes (cbActivos = eliminado == 1, cbInactivos = eliminado == 0)
            var filtrados = productos
                .Where(p => (cbActivosProductos.Checked && p.eliminado == 1) || (cbInactivosProductos.Checked && p.eliminado == 0))
                .ToList();

            // Búsqueda por nombre en tiempo real (si hay texto)
            var textoNom = tbBusquedaNombreProducto.Text.Trim();
            if (!string.IsNullOrEmpty(textoNom))
                filtrados = filtrados.Where(p => p.nombre != null && p.nombre.IndexOf(textoNom, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            // Ejemplo: buscar por SKU o id (si tenés)
            // var textoId = tbBusquedaIdProducto?.Text.Trim();
            // if (!string.IsNullOrEmpty(textoId) && int.TryParse(textoId, out int idBuscado))
            //     filtrados = filtrados.Where(p => p.id_producto == idBuscado).ToList();

            // Parsear precio min/max (si están)
            if (int.TryParse(tbBusquedaPrecioMinProducto.Text.Trim(), out int precioMin))
                filtrados = filtrados.Where(p => p.precio >= precioMin).ToList();

            if (int.TryParse(tbBusquedaPrecioMaxProducto.Text.Trim(), out int precioMax))
                filtrados = filtrados.Where(p => p.precio <= precioMax).ToList();


            // Mapear descripciones de marca y categoría en la lista filtrada
            foreach (var p in filtrados)
            {
                p.descripcionMarca = marcas.FirstOrDefault(m => m.id_marca == p.id_marca)?.descripcion ?? "Desconocido";
                p.descripcionCategoria = categorias.FirstOrDefault(c => c.id_categoria == p.id_categoria)?.descripcion ?? "Desconocido";
            }

            // Asignar DataSource con la lista filtrada (mantener Producto_model para DataBoundItem)
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;

            // UI post-procesamiento
            if (dgvProductos.Rows.Count == 0)
            {
                LimpiarControlesProducto();
                btnBorrarProducto.Enabled = false;
                _productoSeleccionadoId = -1;
            }
            else
            {
                dgvProductos.ClearSelection();
                _productoSeleccionadoId = -1;
            }
        }


        private void LimpiarControlesProducto()
        {
            tbNombreProducto.Clear();
            tbDescripcionProducto.Clear();

            // Quitar imagen del PictureBox y liberar la imagen si fue cargada dinámicamente
            // Liberar imagen actual si existe
            if (pbImagenProducto.Image != null)
            {
                pbImagenProducto.Image.Dispose();
                pbImagenProducto.Image = null;
            }

            // _imagenSeleccionadaPath guarda la ruta; al limpiar la dejamos en null
            _imagenSeleccionadaPath = null;

            // Asignar imagen por defecto al PictureBox (recomendado: agregar la imagen a Resources)
            try
            {
                // Si añadiste una imagen llamada prod_default en Properties.Resources
                pbImagenProducto.Image = (Bitmap)Properties.Resources.producto_defecto.Clone();
                pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                // Si no existe resource, dejamos el PictureBox vacío
                pbImagenProducto.Image = null;
            }

            tbPrecioProducto.Clear();
            tbPrecioVentaProducto.Clear();
            tbStockProducto.Clear();
            rbProductoEliminadoNo.Checked = true; // descomentar si corresponde
            rbProductoEliminadoSi.Checked = false;
            cbMarcaProducto.SelectedIndex = -1;
            cbCategoriaProducto.SelectedIndex = -1;

            _productoSeleccionadoId = -1;
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en la descripción.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // En el constructor o en Load
            cbActivosProductos.CheckedChanged += Filtro_CheckedChanged;
            cbInactivosProductos.CheckedChanged += Filtro_CheckedChanged;

            // Por defecto
            cbActivosProductos.Checked = true;
            cbInactivosProductos.Checked = true; // opcional según lo que quieras mostrar por defecto

            // Asume que ObtenerMarcas() y ObtenerCategorias() devuelven listas ya implementadas
            var marcas = ObtenerMarcas();
            cbMarcaProducto.DataSource = marcas;
            cbMarcaProducto.DisplayMember = "descripcion";   // propiedad del modelo Marca_model
            cbMarcaProducto.ValueMember = "id_marca";
            cbMarcaProducto.SelectedIndex = -1;

            var categorias = ObtenerCategorias();
            cbCategoriaProducto.DataSource = categorias;
            cbCategoriaProducto.DisplayMember = "descripcion"; // propiedad del modelo Categoria_model
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
                DefaultCellStyle = { Format = "N2" }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "precio_vta",
                DataPropertyName = "precio_vta",
                HeaderText = "Precio Venta",
                DefaultCellStyle = { Format = "N2" }
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

            //// Columna de imagen (mostrar miniatura). DataPropertyName contiene la ruta.
            //var imgCol = new DataGridViewImageColumn
            //{
            //    Name = "imagen",
            //    HeaderText = "Imagen",
            //    DataPropertyName = "ImagenRuta", // enlazamos la ruta; convertiremos en CellFormatting
            //    ImageLayout = DataGridViewImageCellLayout.Zoom,
            //    Width = 120
            //};
            //dgvProductos.Columns.Add(imgCol);

            //// Padding para que la imagen no quede pegada a la celda
            //dgvProductos.Columns["imagen"].DefaultCellStyle.Padding = new Padding(4);

            //// Si querés aumentar la altura de una fila concreta después de bindear:
            //dgvProductos.Rows[0].Height = 120;

            dgvProductos.DataSource = productos;

            //dgvProductos.CellFormatting -= DgvProductos_CellFormatting;
            //dgvProductos.CellFormatting += DgvProductos_CellFormatting;
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var p = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto_model;
            if (p == null) return;

            _productoSeleccionadoId = p.id_producto;
            _productoSeleccionadoEliminado = p.eliminado; // guardar estado para usarlo en el botón

            tbNombreProducto.Text = p.nombre ?? string.Empty;
            tbDescripcionProducto.Text = p.descripcion ?? string.Empty;
            tbPrecioProducto.Text = p.precio.ToString("F2");
            tbPrecioVentaProducto.Text = p.precio_vta.ToString("F2");
            tbStockProducto.Text = p.stock.ToString();

            rbProductoEliminadoSi.Checked = p.eliminado == 0;
            rbProductoEliminadoNo.Checked = p.eliminado != 0;

            try { cbMarcaProducto.SelectedValue = p.id_marca; } catch { cbMarcaProducto.SelectedIndex = -1; }
            try { cbCategoriaProducto.SelectedValue = p.id_categoria; } catch { cbCategoriaProducto.SelectedIndex = -1; }

            // Mostrar o ocultar el GroupBox de estado si está eliminado (0)
            gbEstadoProducto.Visible = (p.eliminado == 0);

            // Habilitar btnEliminar solo si el producto NO está eliminado (1)
            btnBorrarProducto.Enabled = (p.eliminado == 1);

            // Cargar imagen en el PictureBox (helper)
            CargarImagenEnPictureBox(p.imagen);
        }


        private void CargarImagenEnPictureBox(string rutaImagen)
        {
            // Liberar imagen anterior
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
                        pbImagenProducto.Image = new Bitmap(src); // copia
                    }
                    _imagenSeleccionadaPath = rutaImagen;
                    pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;
                }
                catch
                {
                    // caemos a imagen por defecto
                }
            }

            // Imagen por defecto desde Resources si no existe ruta válida
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
            // Evitar que los dos queden desmarcados
            if (!cbActivosProductos.Checked && !cbInactivosProductos.Checked)
            {
                var cb = sender as CheckBox;
                if (cb != null)
                    cb.Checked = true;
                return;
            }

            FiltrarYRefrescarProductos();
        }


        //// Formateo: convierte ruta (string) -> miniatura Image (copia) evitando lock
        //private void DgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // Ajustá el nombre "imagen" al Name que definiste para la columna Image
        //    if (dgvProductos.Columns[e.ColumnIndex].Name == "imagen")
        //    {
        //        var ruta = e.Value as string;

        //        // Si e.Value no trae la ruta, intentá obtenerla desde la fila ligada (debug)
        //        if (string.IsNullOrWhiteSpace(ruta))
        //        {
        //            // Intento alternativo: si tu fuente proyectada usa "ImagenRuta" en otra propiedad
        //            var dataItem = dgvProductos.Rows[e.RowIndex].DataBoundItem;
        //            if (dataItem != null)
        //            {
        //                // reflection seguro y sin lanzar: buscar propiedad ImagenRuta o imagen
        //                var prop = dataItem.GetType().GetProperty("ImagenRuta") ?? dataItem.GetType().GetProperty("imagen");
        //                ruta = prop?.GetValue(dataItem) as string;
        //            }
        //        }

        //        if (string.IsNullOrWhiteSpace(ruta) || !System.IO.File.Exists(ruta))
        //        {
        //            e.Value = null;
        //            e.FormattingApplied = true;
        //            return;
        //        }

        //        try
        //        {
        //            using (var src = Image.FromFile(ruta))
        //            {
        //                // Crear copia para evitar bloqueo del archivo y ajustar tamaño
        //                var thumb = new Bitmap(src, new Size(64, 64));
        //                e.Value = thumb;
        //            }
        //        }
        //        catch
        //        {
        //            e.Value = null;
        //        }

        //        e.FormattingApplied = true;
        //        return;
        //    }

        //    //// formateo para precios (opcional)
        //    //if (dgvProductos.Columns[e.ColumnIndex].Name == "precio" ||
        //    //    dgvProductos.Columns[e.ColumnIndex].Name == "precio_vta")
        //    //{
        //    //    if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal v))
        //    //    {
        //    //        e.Value = v.ToString("N2");
        //    //        e.FormattingApplied = true;
        //    //    }
        //    //}
        //}


        //private void DgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    // Evitar el cuadro de diálogo predeterminado
        //    e.ThrowException = false;

        //    // Opcional: loguear detalles para debug sin interrumpir la UI
        //    // var msg = $"DataError en fila {e.RowIndex}, columna {e.ColumnIndex}: {e.Exception?.Message}";
        //    // Debug.WriteLine(msg);
        //}

        private void validarCampos()
        {
            bool baseValida = !string.IsNullOrWhiteSpace(tbNombreProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbPrecioProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbPrecioVentaProducto.Text) &&
                              !string.IsNullOrWhiteSpace(tbStockProducto.Text) &&
                              cbMarcaProducto.SelectedIndex >= 0 &&
                              cbCategoriaProducto.SelectedIndex >= 0;
            // imagen ahora opcional, por eso se quitó la comprobación de pbImagenProducto.Image

            if (!baseValida)
            {
                btnGuardarProducto.Enabled = false;
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
                return;
            }

            btnGuardarProducto.Enabled = (precioVenta < precioOriginal);
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
            //tbNombreProducto.Text = "";
            //tbPrecioProducto.Text = "";
            //tbPrecioVentaProducto.Text = "";
            //tbDescripcionProducto.Text = "";
            //tbStockProducto.Text = "";
            //cbMarcaProducto.SelectedIndex = -1;
            //cbCategoriaProducto.SelectedIndex = -1;
            //btnGuardarProducto.Enabled = false;
            // Si no hay selección activa: comportamiento de "limpiar campos" durante creación
            if (_productoSeleccionadoId < 0)
            {
                // Borrar datos del formulario al crear un registro nuevo
                tbNombreProducto.Clear();
                tbPrecioProducto.Clear();
                tbPrecioVentaProducto.Clear();
                tbDescripcionProducto.Clear();
                tbStockProducto.Clear();
                cbMarcaProducto.SelectedIndex = -1;
                cbCategoriaProducto.SelectedIndex = -1;

                // Reset imagen a por defecto o limpiar
                pbImagenProducto.Image?.Dispose();
                pbImagenProducto.Image = (Bitmap)Properties.Resources.producto_defecto.Clone(); // o usar tu método de placeholder
                _imagenSeleccionadaPath = null;

                btnGuardarProducto.Enabled = false;
                return;
            }

            // Si hay producto seleccionado: solo permitir marcar como eliminado si actualmente NO está eliminado
            if (_productoSeleccionadoEliminado == 0)
            {
                // Producto ya eliminado: botón deshabilitado por CellClick, pero comprobamos por seguridad
                MessageBox.Show("El producto ya se encuentra eliminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBorrarProducto.Enabled = false;
                return;
            }

            // Confirmación y cambio de estado en BD: marcar como eliminado (0)
            var dr = MessageBox.Show("¿Seguro que deseas marcar este producto como eliminado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            int filas = Producto_controller.CambiarEstadoEliminado(_productoSeleccionadoId, 0);
            if (filas == 1)
            {
                MessageBox.Show("Producto marcado como eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar UI: recargar lista y limpiar controles
                FiltrarYRefrescarProductos();
                LimpiarControlesProducto();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al cambiar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}

