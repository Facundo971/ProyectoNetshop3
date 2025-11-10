// Importa librerías.
using FontAwesome.Sharp;
using iTextSharp.text.pdf.codec.wmf;
using Microsoft.Data.SqlClient;
using ProyectoNetshop.BD;
using ProyectoNetshop.Cruds;
using ProyectoNetshop.formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace vistaDeProyectoC
{
    public partial class FRegistrarCliente : Form
    {
        // Campo que guarda el ID del usuario seleccionado en la grilla
        // Inicializado en -1 para indicar que ningun usuario se eligio
        private int _clienteSeleccionadoId = -1;

        // Inicializa el formulario de registro y edición de clientes: configura eventos para filtros de estado (activo/inactivo),
        // validación reactiva de campos, búsqueda dinámica por DNI y nombre, y selección contextual en la grilla.
        // También establece comportamientos visuales como limpieza de selección al hacer clic fuera de filas y formateo textual
        // del estado activo ("SI"/"NO").
        public FRegistrarCliente()
        {
            InitializeComponent();

            cbActivos.CheckedChanged += Filtro_CheckedChanged;
            cbInactivos.CheckedChanged += Filtro_CheckedChanged;

            this.Load += FRegistrarCliente_Load;

            tbNombre.TextChanged += InputFields_Changed;
            tbApellido.TextChanged += InputFields_Changed;
            tbDNI.TextChanged += InputFields_Changed;
            tbEmail.TextChanged += InputFields_Changed;
            tbTelefono.TextChanged += InputFields_Changed;

            rbMasculino.CheckedChanged += InputFields_Changed;
            rbFemenino.CheckedChanged += InputFields_Changed;
            rbOtros.CheckedChanged += InputFields_Changed;
            fechaNacimiento.ValueChanged += InputFields_Changed;
            fechaNacimiento.MouseClick += InputFields_Changed;

            tbBusquedaDniCliente.KeyPress -= tbBusquedaDniCliente_KeyPress;
            tbBusquedaNombreCliente.KeyPress -= tbBusquedaNombreCliente_KeyPress;

            tbBusquedaDniCliente.KeyPress += tbBusquedaDniCliente_KeyPress;
            tbBusquedaDniCliente.TextChanged += tbBusquedaDniCliente_TextChanged;
            tbBusquedaNombreCliente.KeyPress += tbBusquedaNombreCliente_KeyPress;
            tbBusquedaNombreCliente.TextChanged += tbBusquedaNombreCliente_TextChanged;

            dgvClientes.CellClick += DgvClientes_CellClick;
            // Limpieza de selección al clicar fuera de filas
            dgvClientes.MouseDown += DgvClientes_MouseDown;
            // Permitir limpiar selección al clicar en cualquier parte del formulario
            this.MouseDown += Form_MouseDown;

            // Formateo para mostrar SI/NO en la columna activo
            dgvClientes.CellFormatting += DgvClientes_CellFormatting;
        }

        // Maneja el clic del mouse sobre el DataGridView de clientes: si el clic ocurre fuera de una fila válida (`RowIndex < 0`),
        // se limpia la selección, se reinicia el ID del cliente seleccionado, se vacían los campos del formulario y se oculta el GroupBox de estado.
        // Si el clic ocurre sobre una fila, se selecciona explícitamente esa fila.
        private void DgvClientes_MouseDown(object? sender, MouseEventArgs e)
        {
            var hit = dgvClientes.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0)
            {
                dgvClientes.ClearSelection();
                _clienteSeleccionadoId = -1;
                vaciarCampos();
                gbActivoCliente.Visible = false;
            }
            else
            {
                // conservar comportamiento normal: seleccionar fila bajo el cursor
                dgvClientes.ClearSelection();
                dgvClientes.Rows[hit.RowIndex].Selected = true;
            }
        }

        // Maneja el clic en cualquier parte del formulario: limpia la selección del DataGridView, reinicia el ID del cliente seleccionado y
        // vacía todos los campos del formulario. Además, oculta el GroupBox de estado activo/inactivo para evitar confusión visual.
        private void Form_MouseDown(object? sender, MouseEventArgs e)
        {
            // Limpiar selección y campos al clicar en el formulario
            dgvClientes.ClearSelection();
            _clienteSeleccionadoId = -1;
            vaciarCampos();

            // Asegurar groupbox oculto
            gbActivoCliente.Visible = false;
        }

        // Formatea la columna "activo" del DataGridView para mostrar texto legible: si el valor es null, se muestra "NO"; si es numérico,
        // se interpreta `1` como "SI" y cualquier otro valor como "NO".
        private void DgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].DataPropertyName == "activo" || dgvClientes.Columns[e.ColumnIndex].Name == "activo")
            {
                if (e.Value == null)
                {
                    e.Value = "NO";
                    e.FormattingApplied = true;
                    return;
                }

                if (int.TryParse(e.Value.ToString(), out int val))
                {
                    e.Value = val == 1 ? "SI" : "NO";
                    e.FormattingApplied = true;
                }
            }
        }

        // Valida la entrada en campos clave del formulario de cliente:  
        // -tbNombre y tbApellido permiten solo letras y espacios, bloqueando cualquier otro carácter.
        // -tbTelefono y tbDNI aceptan únicamente dígitos, impidiendo letras o símbolos.  
        // En todos los casos, si el carácter ingresado no es válido, se cancela la entrada (`e.Handled = true`) y se muestra una advertencia.
        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsLetter(e.KeyChar)
                 && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Configura el formulario al cargarse: desactiva el botón "Guardar", activa ambos filtros (activos/inactivos), y establece límites de entrada
        // para DNI (8 dígitos) y teléfono (10 dígitos). Inicializa el DateTimePicker con formato personalizado y sin fecha seleccionada por defecto.
        // Define manualmente las columnas del DataGridView para clientes, asegurando control total sobre nombres, orden y formato.
        // Oculta el ID interno (`id_cliente`) y ajusta las columnas al ancho del grid. Finalmente, carga la lista de clientes desde la base de datos y
        // limpia la selección.
        private void FRegistrarCliente_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            cbActivos.Checked = true;
            cbInactivos.Checked = true;
            // Máximo de dígitos
            tbDNI.MaxLength = 8;
            tbTelefono.MaxLength = 10;

            fechaNacimiento.ShowCheckBox = true;
            fechaNacimiento.Checked = false;
            fechaNacimiento.Value = DateTime.Today;
            fechaNacimiento.Format = DateTimePickerFormat.Custom;
            fechaNacimiento.CustomFormat = "dd/MM/yyyy";

            // Configurar columnas fijas para controlar nombres y formateo
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            // Ajustar columnas al ancho del grid
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_cliente",
                DataPropertyName = "id_cliente",
                HeaderText = "ID"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre",
                DataPropertyName = "nombre",
                HeaderText = "Nombre"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "apellido",
                DataPropertyName = "apellido",
                HeaderText = "Apellido"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dni",
                DataPropertyName = "dni",
                HeaderText = "DNI"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "email",
                DataPropertyName = "email",
                HeaderText = "Email"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "telefono",
                DataPropertyName = "telefono",
                HeaderText = "Telefono"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "sexo",
                DataPropertyName = "sexo",
                HeaderText = "Sexo"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_nacimiento",
                DataPropertyName = "fecha_nacimiento",
                HeaderText = "Fecha de Nacimiento"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "activo",
                DataPropertyName = "activo",
                HeaderText = "Activo"
            });

            //Ocultar la columna id_usuario
            dgvClientes.Columns["id_cliente"].Visible = false;

            dgvClientes.DataSource = ObtenerClientes();
            dgvClientes.ClearSelection();
        }

        // Detecta cambios en los campos del formulario de cliente: cada vez que el usuario modifica un campo relevante (texto, selección o fecha),
        // se invoca validarCampos() para actualizar dinámicamente el estado del botón "Guardar".
        private void InputFields_Changed(object sender, EventArgs e)
        {
            validarCampos();
        }

        // Valida el estado general del formulario de cliente: habilita el botón "Guardar" solo si todos los campos obligatorios están completos y
        // válidos. Esto incluye nombre, apellido, DNI, email, teléfono, selección de sexo y fecha de nacimiento (si está activada).
        private void validarCampos()
        {
            btnGuardar.Enabled =
                !string.IsNullOrWhiteSpace(tbNombre.Text) &&
                !string.IsNullOrWhiteSpace(tbApellido.Text) &&
                ValidarDNI() &&
                ValidarEmail() &&
                ValidarTelefono() &&
                (rbMasculino.Checked || rbFemenino.Checked || rbOtros.Checked) &&
                ValidarFechaNacimiento();
        }

        // Validadores individuales para campos del formulario de cliente:
        // - ValidarDNI(): exige al menos 8 caracteres para considerar el DNI válido, sin validar contenido numérico aquí (eso se hace en confirmarCampos()).
        // - ValidarEmail(): requiere que el campo no esté vacío y que cumpla con un patrón básico de email que termine en .com, usando expresión regular.
        // - ValidarTelefono(): permite que el campo esté vacío (opcional), pero si tiene contenido, debe tener al menos 10 dígitos.
        // - ValidarFechaNacimiento(): si el checkbox está activado, valida que la fecha no sea futura y que la edad esté entre 18 y 100 años.
        // Si no está activado, se considera válida por omisión.
        private bool ValidarDNI()
        {
            return tbDNI.Text.Length >= 8;
        }
        private bool ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
                return false;

            return Regex.IsMatch(
                tbEmail.Text,
                @"^[^@\s]+@[^@\s]+\.com$",
                RegexOptions.IgnoreCase);
        }
        private bool ValidarTelefono()
        {
            return string.IsNullOrWhiteSpace(tbTelefono.Text) || tbTelefono.Text.Length >= 10;
        }
        private bool ValidarFechaNacimiento()
        {
            if (!fechaNacimiento.Checked)
                return true;

            DateTime hoy = DateTime.Today;
            DateTime fn = fechaNacimiento.Value.Date;
            if (fn > hoy)
                return false;

            int edad = hoy.Year - fn.Year;
            if (fn > hoy.AddYears(-edad))
                edad--;

            return edad >= 18 && edad <= 100;
        }

        // Maneja la acción de guardar cliente: primero valida todos los campos mediante confirmarCampos(). Según si hay un cliente
        // seleccionado (_clienteSeleccionadoId < 0), determina si se trata de una creación o actualización.
        // Solicita confirmación al usuario antes de continuar. Luego construye el objeto Cliente_model con los datos del formulario,
        // incluyendo conversión de fecha y sexo. Ejecuta el INSERT o UPDATE correspondiente a través del controlador.
        // Si la operación fue exitosa, muestra un mensaje de éxito; si no, informa el error.
        // Finalmente, actualiza la grilla, limpia los campos y reinicia la selección.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!confirmarCampos())
                return;

            // Se confirmar cual acción de se va a ejecutar (crear o actualizar)
            string accion = _clienteSeleccionadoId < 0 ? "crear" : "actualizar";
            var dr = MessageBox.Show($"¿Seguro que deseas {accion} este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr != DialogResult.Yes)
                return;

            // Se arma el objeto Cliente_model
            var cliente = new Cliente_model
            {
                nombre = tbNombre.Text.Trim(),
                apellido = tbApellido.Text.Trim(),
                email = tbEmail.Text.Trim(),
                activo = rbActivo.Checked ? 1 : 0,
                sexo = rbMasculino.Checked ? "Masculino" : rbFemenino.Checked ? "Femenino" : "Otros",
                fecha_nacimiento = fechaNacimiento.Checked ? fechaNacimiento.Value.Date : (DateTime?)null,
                telefono = tbTelefono.Text,
                dni = int.Parse(tbDNI.Text),
            };

            // Se ejecuta el INSERT o UPDATE
            int filas;
            if (_clienteSeleccionadoId < 0)
                filas = Cliente_controller.agregarCliente(cliente);
            else
            {
                cliente.id_cliente = _clienteSeleccionadoId;
                filas = Cliente_controller.actualizarCliente(cliente);
            }

            if (filas == 1)
                MessageBox.Show(_clienteSeleccionadoId < 0 ? "Cliente creado con éxito." : "Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ocurrió un error durante la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            FiltrarYRefrescar();
            vaciarCampos();
            dgvClientes.ClearSelection();
        }

        // Maneja la lógica de desactivación de un cliente: si no hay cliente seleccionado (_clienteSeleccionadoId < 0), simplemente limpia el formulario.
        // Si hay uno seleccionado, solicita confirmación al usuario antes de marcarlo como inactivo mediante Cliente_controller.eliminarCliente().
        // Si la operación fue exitosa, muestra un mensaje de éxito; si el cliente ya estaba desactivado, informa al usuario.
        // Luego limpia los campos, actualiza la grilla y reinicia la selección.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si no hay selección: limpio los campos
            if (_clienteSeleccionadoId < 0)
            {
                vaciarCampos();
                return;
            }

            var dr = MessageBox.Show("¿Seguro que deseas desactivar este cliente?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr != DialogResult.Yes)
                return;

            int filas = Cliente_controller.eliminarCliente(_clienteSeleccionadoId);

            if (filas == 1)
            {
                MessageBox.Show("Cliente desactivado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cliente ya estaba desactivado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            vaciarCampos();
            FiltrarYRefrescar();
            dgvClientes.ClearSelection();
        }

        // Carga los datos del cliente seleccionado en el formulario:  
        // Asigna nombre, apellido, email, teléfono, DNI, sexo y fecha de nacimiento.
        // Actualiza el estado activo/inactivo y muestra el GroupBox si está inactivo.
        // Habilita el botón "Eliminar" solo si el cliente está activo.  
        // Permite editar o desactivar el cliente con contexto visual claro.
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cliente = (Cliente_model)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            _clienteSeleccionadoId = cliente.id_cliente;

            tbNombre.Text = cliente.nombre;
            tbApellido.Text = cliente.apellido;
            tbEmail.Text = cliente.email;

            rbMasculino.Checked = cliente.sexo == "Masculino";
            rbFemenino.Checked = cliente.sexo == "Femenino";
            rbOtros.Checked = cliente.sexo == "Otros";

            if (!cliente.fecha_nacimiento.HasValue)
            {
                fechaNacimiento.Checked = false;

            }
            else
            {
                fechaNacimiento.Checked = true;
                fechaNacimiento.Value = (DateTime)cliente.fecha_nacimiento;
            }

            tbTelefono.Text = cliente.telefono?.ToString() ?? string.Empty;
            tbDNI.Text = cliente.dni.ToString();

            // Asignación explícita de los radios Activo / Inactivo
            // Convención: activo == 1 -> SI; activo == 0 -> NO
            rbActivo.Checked = cliente.activo == 1;
            rbInactivo.Checked = cliente.activo == 0;

            // Mostrar el GroupBox solo cuando el cliente esté inactivo (activo == 0)
            gbActivoCliente.Visible = cliente.activo == 0;

            // Habilita “Eliminar” solo si activa == 1
            btnBorrar.Enabled = cliente.activo == 1;
        }

        // Aplica filtros dinámicos sobre la lista de clientes y actualiza la grilla:  
        // Filtra por estado(activo/inactivo) según los checkboxes, por prefijo de DNI si hay texto numérico, y por coincidencia parcial en el nombre.
        // Luego refresca el DataGridView con los resultados filtrados.
        private void FiltrarYRefrescar()
        {
            var clientes = ObtenerClientes();

            // Se aplica un filtro por activo/inactivo
            var filtrados = clientes.Where(u => (cbActivos.Checked && u.activo == 1) || (cbInactivos.Checked && u.activo == 0)).ToList();

            // Si hay texto en el DNI, filtrar por prefijo
            var textoDni = tbBusquedaDniCliente.Text.Trim();
            if (textoDni.Length > 0 && textoDni.All(char.IsDigit))
            {
                filtrados = filtrados.Where(u => u.dni.ToString().StartsWith(textoDni)).ToList();
            }

            // Si hay texto en el Nombre, filtrar por contenido
            var textoNom = tbBusquedaNombreCliente.Text.Trim();
            if (textoNom.Length > 0)
            {
                filtrados = filtrados.Where(u => u.nombre.IndexOf(textoNom, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Se refresca el DataGridView con la lista filtrada
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = filtrados;
        }

        // Recupera todos los clientes desde la base de datos:  
        // Ejecuta una consulta SQL sobre la tabla cliente y construye una lista de objetos Cliente_model con los campos relevantes.
        // Maneja valores nulos para fecha_nacimiento y telefono de forma segura.
        private List<Cliente_model> ObtenerClientes()
        {
            var lista = new List<Cliente_model>();
            using var con = ProyectoNetshop.BD.BaseDeDatos.obtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"SELECT id_cliente, nombre, apellido, email, activo, sexo, fecha_nacimiento, telefono, dni FROM cliente";
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DateTime? fn = rd.IsDBNull(6) ? (DateTime?)null : rd.GetDateTime(6);
                string? tel = rd.IsDBNull(7) ? (string?)null : rd.GetString(7);

                var cliente = new Cliente_model
                {
                    id_cliente = rd.GetInt32(0),
                    nombre = rd.GetString(1),
                    apellido = rd.GetString(2),
                    email = rd.GetString(3),
                    activo = rd.GetInt32(4),
                    sexo = rd.GetString(5),
                    fecha_nacimiento = fn,
                    telefono = tel,
                    dni = rd.GetInt32(8),
                };

                lista.Add(cliente);
            }

            return lista;
        }

        // Limpia todos los campos del formulario de cliente:  
        // Resetea los textos, radios, fecha de nacimiento y desactiva el botón "Guardar".  
        // Oculta el GroupBox de estado y reinicia el ID de cliente seleccionado.
        private void vaciarCampos()
        {
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbDNI.Text = "";
            tbEmail.Text = "";
            tbTelefono.Text = "";
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            rbOtros.Checked = true;
            fechaNacimiento.Value = DateTime.Today;
            fechaNacimiento.Checked = false;
            btnGuardar.Enabled = false;

            // Ocultar el GroupBox cuando no hay selección o al limpiar
            gbActivoCliente.Visible = false;

            // Resetear id seleccionado
            _clienteSeleccionadoId = -1;
        }

        // Valida todos los campos antes de guardar:  
        // Verifica nombre, apellido, email, fecha de nacimiento, DNI y teléfono.
        // Confirma que no haya duplicados de email o DNI en otros clientes.
        // Muestra advertencias específicas y enfoca el campo con error.
        // Solo permite guardar si todos los datos son válidos y únicos.
        private bool confirmarCampos()
        {
            // Nombre
            if (string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombre.Focus();
                return false;
            }

            if (!tbNombre.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo puede contener letras", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombre.Focus();
                return false;
            }
            // Apellido
            if (string.IsNullOrWhiteSpace(tbApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbApellido.Focus();
                return false;
            }

            if (!tbApellido.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El apellido solo puede contener letras.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbApellido.Focus();
                return false;
            }

            // Email
            string email = tbEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "El email es obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbEmail.Focus();
                return false;
            }

            // Email Regex
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.com$", RegexOptions.IgnoreCase);
            if (!emailRegex.IsMatch(email))
            {
                MessageBox.Show(
                    "El email debe tener formato válido y terminar en .com.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbEmail.Focus();
                return false;
            }

            // Fecha de nacimiento
            if (fechaNacimiento.Checked)
            {
                DateTime fn = fechaNacimiento.Value.Date;
                DateTime hoy = DateTime.Today;
                int edad = hoy.Year - fn.Year;
                if (fn > hoy.AddYears(-edad))
                    edad--;

                if (edad < 18 || edad > 100)
                {
                    MessageBox.Show(
                        "La edad debe estar entre 18 y 100 años.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    fechaNacimiento.Focus();
                    return false;
                }
            }

            // DNI
            if (!int.TryParse(tbDNI.Text, out int dni)
             || dni < 10_000_000 || dni > 99_999_999)
            {
                MessageBox.Show("El DNI debe ser un número entre 10.000.000 y 99.999.999.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDNI.Focus();
                return false;
            }

            // Teléfono
            string txtTel = tbTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(txtTel))
            {
                if (!long.TryParse(txtTel, out long tel)
                 || tel < 1_000_000_000L
                 || tel > 9_999_999_999L)
                {
                    MessageBox.Show(
                        "El teléfono debe ser un número de 10 dígitos válido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    tbTelefono.Focus();
                    return false;
                }
            }

            // Extraer valores para la comprobación
            int dniR = int.Parse(tbDNI.Text);
            string emailR = tbEmail.Text.Trim();
            int idActR = _clienteSeleccionadoId < 0 ? 0 : _clienteSeleccionadoId;

            //  Última validación: DNI o email duplicados
            if (Cliente_controller.ExisteEmailODni(dniR, emailR, idActR))
            {
                MessageBox.Show("El DNI o el email ya están registrados en otro usuario.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDNI.Focus();
                return false;
            }

            return true;
        }

        // Filtra en tiempo real según lo que escribe el usuario:  
        // - Solo permite números en el campo de búsqueda por DNI.
        // - Solo letras y espacios en el campo de nombre.
        // - Cada cambio de texto actualiza automáticamente la grilla con FiltrarYRefrescar().  
        private void tbBusquedaDniCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Sólo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbBusquedaDniCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescar();
        }
        private void tbBusquedaNombreCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescar();
        }
        private void tbBusquedaNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Sólo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Aplica filtros al cambiar los checkboxes de estado:  
        // Cada vez que se marca o desmarca "Activos" o "Inactivos", se actualiza la grilla llamando a FiltrarYRefrescar().  
        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescar();
        }
        private void cbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarYRefrescar();
        }

        // Evita que ambos filtros de estado estén desmarcados:  
        // Si el usuario desmarca tanto "Activos" como "Inactivos", se vuelve a marcar el checkbox que disparó el evento para mantener al menos un filtro activo.
        // Luego actualiza la grilla con FiltrarYRefrescar().
        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbActivos.Checked && !cbInactivos.Checked)
            {
                var cb = (CheckBox)sender;
                cb.Checked = true;
                return;
            }

            FiltrarYRefrescar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
