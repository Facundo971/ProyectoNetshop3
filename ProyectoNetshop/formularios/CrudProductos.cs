// Importa librerías.
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

        // Campo que indica si el producto seleccionado está eliminado
        private int _productoSeleccionadoEliminado = 1; // 1 = no eliminado, 0 = eliminado

        // Bandera para evitar recursión en el evento TextChanged de tbPrecioProducto y tbPrecioVentaProducto
        private bool _suppressPrecioTextChanged = false;

        // Ruta de la imagen por defecto
        private const string ImagenPorDefectoPath = @"Resources\producto_defecto.jpg";


        // Constructor del formulario de gestión de productos: inicializa componentes, configura validaciones de entrada para descripción y precios,
        // y enlaza eventos para interacción dinámica. Incluye lógica para selección en la grilla, limpieza de controles al hacer clic fuera,
        // y filtrado reactivo por nombre y precio. También gestiona los checkboxes de estado (activos/inactivos) para aplicar filtros.
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

        // Evento que se dispara al modificar el texto del campo de búsqueda de nombre de producto: invoca el método `FiltrarYRefrescarProductos()`
        // para actualizar dinámicamente la grilla según el texto ingresado.
        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescarProductos();
        }

        // Restringe la entrada del `TextBox` a solo dígitos y teclas de control: bloquea letras, símbolos y decimales para asegurar que el campo reciba
        // únicamente números enteros válidos.
        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return; 
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true; 
        }

        // Maneja el clic del mouse sobre la grilla de productos: si se hace clic fuera de una fila válida, limpia la selección y los controles
        // asociados al producto. Si se hace clic sobre una fila, la selecciona exclusivamente.
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

        // Maneja el clic fuera de la grilla de productos (formulario o contenedor): limpia la selección activa del DataGridView, reinicia el
        // identificador del producto seleccionado y borra los datos cargados en los controles.
        private void Form_Or_Container_Click(object? sender, EventArgs e)
        {
            dgvProductos.ClearSelection();
            _productoSeleccionadoId = -1;
            LimpiarControlesProducto();
        }

        // Elimina cualquier carácter no numérico, preserva la posición del cursor y evita bucles de eventos mediante un flag de supresión.
        // Luego actualiza la grilla aplicando los filtros.
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

        // Permite al usuario seleccionar una imagen desde el sistema de archivos para asociarla al producto: abre un diálogo con filtros de formatos
        // válidos, guarda la ruta seleccionada, carga la imagen en el `PictureBox` y ajusta su visualización.
        // Luego invoca `validarCampos()` para actualizar el estado del formulario.
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

        // Maneja la lógica de guardado del producto: determina si se trata de una creación o actualización según el estado de selección,
        // construye el objeto Producto_model con los datos del formulario, y ejecuta el INSERT o UPDATE correspondiente.
        // Si la operación es exitosa, muestra un mensaje de confirmación, actualiza la grilla, intenta reseleccionar el producto afectado y
        // recarga los controles. Si falla, informa el error. Finalmente, refresca la vista y limpia los campos.
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

        // Aplica filtros dinámicos sobre la lista de productos y actualiza la grilla: filtra por estado (activo/inactivo), nombre parcial y
        // rango de precios. Luego enriquece cada producto con las descripciones de marca y categoría, y actualiza el DataGridView con los resultados.
        // Limpia la selección actual y reinicia el ID del producto seleccionado.
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

        // Carga los datos del producto seleccionado en los controles del formulario: asigna valores a los campos de texto, combos y
        // radio buttons según el objeto Producto_model. También actualiza el estado visual del grupo de eliminación y carga la imagen correspondiente.
        // Si el producto es nulo, limpia los controles.
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

        // Restaura el formulario de producto a su estado inicial: limpia todos los campos de texto, restablece la imagen al recurso por defecto,
        // deselecciona marca y categoría, y reinicia los flags de selección y eliminación. También oculta el grupo de estado,
        // desactiva los botones de acción y actualiza su visibilidad.
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

        // Recupera todos los productos desde la base de datos: ejecuta una consulta SQL sobre la tabla producto, lee cada fila con un SqlDataReader,
        // y construye una lista de objetos Producto_model. Maneja posibles valores nulos en descripcion e imagen, y asigna todos los campos
        // relevantes (precio, stock, estado, marca, categoría, etc.).
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

        // Recupera todas las marcas desde la base de datos: ejecuta una consulta SQL sobre la tabla marca, lee cada fila con SqlDataReader y
        // construye una lista de objetos Marca_model con sus respectivos campos (`id_marca`, `descripcion`, `activo`).
        // Esta lista se utiliza para poblar combos, enriquecer productos y aplicar filtros por marca en el CRUD.
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

        // Recupera todas las categorías desde la base de datos: ejecuta una consulta SQL sobre la tabla categoria, lee cada fila con SqlDataReader y
        // construye una lista de objetos Categoria_model con sus respectivos campos (`id_categoria`, `descripcion`, `activo`).
        // Esta lista se utiliza para poblar combos, enriquecer productos y aplicar filtros por categoría en el CRUD.
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

        // Valida la entrada del campo de nombre de producto: permite únicamente letras, números, espacios y teclas de control.
        // Si se detecta un carácter inválido, lo bloquea y muestra una advertencia al usuario. Previene errores de formato y asegura consistencia en
        // los nombres registrados dentro del CRUD.
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

        // Valida la entrada del campo de descripción del producto: permite únicamente letras, números, espacios y teclas de control.
        // Si se detecta un carácter inválido (como símbolos o signos de puntuación), lo bloquea y muestra una advertencia.
        // Refuerza la integridad del contenido descriptivo y previene errores de formato en el CRUD.
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

        // Valida la entrada del campo de precio: permite únicamente dígitos y teclas de control (como retroceso).
        // Si se ingresa un carácter no numérico, lo bloquea y muestra una advertencia.
        // Previene errores de formato y asegura que el valor ingresado sea un número entero válido para operaciones posteriores.
        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Valida la entrada del campo de precio de venta: permite únicamente dígitos y teclas de control.
        // Si se ingresa un carácter no numérico, lo bloquea y muestra una advertencia.
        // Asegura que el valor ingresado sea un número entero válido, evitando errores en cálculos o persistencia de datos.
        private void tbPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Valida la entrada del campo de stock: permite únicamente dígitos y teclas de control.
        // Si se ingresa un carácter no numérico, lo bloquea y muestra una advertencia.
        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Valida la entrada del campo ID de producto: permite únicamente dígitos y teclas de control.
        // Si se ingresa un carácter no numérico, lo bloquea y muestra una advertencia.
        private void tbiDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Inicializa el formulario del CRUD de productos: configura el DataGridView para solo lectura, selección exclusiva por fila y
        // sin edición directa. Asocia eventos de cambio de filtros, carga las listas de marcas y categorías en sus respectivos combos,
        // y aplica formato monetario a las columnas de precios.
        // Luego, obtiene los productos desde la base de datos, les asigna las descripciones de marca y categoría,
        // y los vincula al `DataGridView`. También define manualmente las columnas visibles y oculta el ID interno.
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

        // Maneja la selección de una fila en el DataGridView: cuando el usuario hace clic en una celda, se recupera el objeto Producto_model
        // asociado a esa fila y se cargan sus datos en los controles del formulario.
        // Esto incluye nombre, descripción, precios, stock, marca, categoría, estado de eliminación y la imagen del producto.
        // También actualiza el estado visual del grupo de eliminación y los botones relacionados.
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

        // Carga una imagen en el PictureBox del producto: libera la imagen anterior si existe, limpia la ruta seleccionada, y
        // verifica si la nueva ruta es válida y el archivo existe. Si es así, intenta cargarla como Bitmap y ajusta el modo de visualización.
        // Si falla o la ruta es inválida, carga una imagen por defecto desde los recursos.
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

        // Maneja los cambios en los filtros de estado (activos/inactivos): si ambos checkboxes están desmarcados, vuelve a marcar el que disparó el
        // evento para evitar un estado sin productos visibles. Si al menos uno está marcado, aplica los filtros actualizados llamando a
        // FiltrarYRefrescarProductos().
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

        // Valida los campos del formulario antes de habilitar el botón Guardar: verifica que los campos obligatorios no estén vacíos y
        // que los valores numéricos (precio, precio de venta y stock) sean válidos. Solo habilita el botón si el precio de venta es menor al
        // precio original, lo que sugiere una lógica de control de márgenes o promociones. También actualiza el estado del botón Borrar para
        // mantener coherencia visual y funcional.
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

        // Asocia eventos de cambio de texto y selección a la validación de campos: cada vez que el usuario modifica un campo relevante del formulario
        // (nombre, descripción, precios, stock, marca, categoría, etc.), se invoca validarCampos() para actualizar dinámicamente el estado del
        // botón Guardar.
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

        // Maneja la lógica de eliminación de un producto: si no hay producto seleccionado, limpia el formulario.
        // Si el producto ya está marcado como eliminado (`eliminado == 0`), muestra una advertencia y desactiva el botón.
        // Si no, solicita confirmación al usuario. Al aceptar, llama al controlador para cambiar el estado a eliminado.
        // Si la operación fue exitosa, actualiza la grilla y limpia los controles;
        // si falla, muestra un mensaje de error.
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

        // Verifica si el formulario contiene datos ingresados: evalúa si alguno de los campos relevantes
        // (nombre, descripción, precios, stock, marca, categoría o imagen) tiene contenido o selección válida.
        // Retorna true si al menos uno está completo, lo que indica que el formulario no está vacío.
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

        // Actualiza el estado del botón Borrar: lo habilita si hay un producto seleccionado que no está marcado como eliminado
        // (`eliminado != 0`) o si el formulario contiene datos ingresados.
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

