using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolar.Bussines;
using ControlEscolar.Utilities;
using ControlEscolar.Model;
using ControlEscolar.Controler;
using System.Linq.Expressions;

namespace ControlEscolar.View
{
    public partial class frmEstudiantes : Form
    {
        public frmEstudiantes(Form parent)
        {
            InitializeComponent();
            Formas.InicializarForma(this, parent);
        }

        private void InicializaVentanaEstudiantes()
        {
            scEstudiantes.Panel1Collapsed = true;
            lbFechaBaja.Visible = false;
            dtpFechaBaja.Visible = false;
            PoblaComboEstatus();
            PoblaComboTipoFecha();
        }


        private void PoblaComboEstatus()
        {
            Dictionary<int, string> list_estatus = new Dictionary<int, string>()
        {
            { 1, "Activo" },
            { 0, "Baja"},
            { 2, "Baja Temporal"}
        };
            // Asignar el diccionario al comboBox
            cbEstatus.DataSource = new BindingSource(list_estatus, null);
            cbEstatus.DisplayMember = "Value";  //lo que se muestra
            cbEstatus.ValueMember = "Key";      //lo que se guarda como seleccionado
            cbEstatus.SelectedValue = 1;
        }

        private void PoblaComboTipoFecha()
        {
            Dictionary<int, string> list_tipofechas = new Dictionary<int, string>()
    {
        { 1, "Nacimiento" },
        { 2, "Alta"},
        { 3, "Baja"}
    };
            // Asignar el diccionario al comboBox
            cbxTipoFecha.DataSource = new BindingSource(list_tipofechas, null);
            cbxTipoFecha.DisplayMember = "Value";  //lo que se muestra
            cbxTipoFecha.ValueMember = "Key";      //lo que se guarda como seleccionado
            cbxTipoFecha.SelectedValue = 2;
        }


        private void InicializaVentanaEstatus()
        {
            scEstudiantes.Panel1Collapsed = true;
            lbFechaBaja.Visible = false;
            dtpFechaBaja.Visible = false;
            PoblaComboEstatus();
            PoblaComboTipoFecha();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            InicializaVentanaEstudiantes();
        }

        private void btnMostrarCaptura_Click(object sender, EventArgs e)
        {
            if (scEstudiantes.Panel1Collapsed)
            {
                scEstudiantes.Panel1Collapsed = false;
                btnMostrarCaptura.Text = "Ocultar Captura rapida";
            }
            else
            {
                scEstudiantes.Panel1Collapsed = true;
                btnMostrarCaptura.Text = "Mostrar Captura rapida";
            }
        }

        private void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Seleccione el archivo de exel";
            ofdArchivo.Filter = "Archivos de exel|*.xlsx;*.xls";
            //ofdArchivo.InitialDirectory = @"C:\\"; //Carpeta inicial
            ofdArchivo.FilterIndex = 1; //Filtro por defecto
            ofdArchivo.RestoreDirectory = true; //Restaurar la carpeta inicial

            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArchivo.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".xlsx" || extension == ".xls")
                {
                    // Lógica para cargar el archivo de Excel
                    MessageBox.Show("Archivo cargado correctamente: " + filePath, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un archivo de Excel válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (GuardarEstudiante())
            {
                MessageBox.Show("Estudiante guardado correctamente.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool GuardarEstudiante()
        {
            if (DatosVacios())
            {
                MessageBox.Show("Favor de llenar todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DatosValidos())
            {
                return false;
            }
            return true;
        }

        private bool DatosVacios()
        {
            if (txtNombre.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == ""
                || txtCurp.Text == "" || upSemestre.Text == "" || txtNoControl.Text == ""
                || upSemestre.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DatosValidos()
        {
            if (!EstudiantesNegocio.EsCorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsCURPValido(txtCurp.Text.Trim()))
            {
                MessageBox.Show("CURP inválida.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsNoControlValido(txtNoControl.Text.Trim()))
            {
                MessageBox.Show("Número de control inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CargarEstudiantes()
        {
            try
            {
                // Mostrar indicador de carga si es nesesario
                Cursor = Cursors.WaitCursor;

                //Crear una instancia del controlador de estudiantes
                EstudiantesController estudiantesController = new EstudiantesController();

                //Obtener la lista de estudiantes (Solo activos por defecto)
                List<Estudiante> estudiantes = estudiantesController.ObtenerEstudiantes(
                    soloActivos: false,
                    tipoFecha: cbxTipoFecha.SelectedValue != null ? (int)cbxTipoFecha.SelectedValue : 0,
                    fechaInicio: dtpInicio.Enabled ? dtpInicio.Value : (DateTime?)null,
                    fechaFin: dtpFin.Enabled ? dtpFin.Value : (DateTime?)null
                    );

                //Limpiar el grid
                dgvEstudiantes.DataSource = null;

                if (estudiantes.Count == 0)
                {
                    lblTotalRegistros.Text = "Total de registros: 0";

                    //Mostrar mensaje de que no hay registros
                    if (!string.IsNullOrEmpty(txtBusqueda.Text))
                    {
                        {
                            MessageBox.Show("No se encontraron registros con el criterio de búsqueda especificado.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Matrícula", typeof(string));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Semestre", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("CURP", typeof(string));
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Fecha Alta", typeof(DateTime));
                dt.Columns.Add("Estatus", typeof(string));

                //Llenar el DataTable con los datos de los estudiantes
                foreach (Estudiante estudiante in estudiantes)
                {
                    dt.Rows.Add(
                        estudiante.Id,
                        estudiante.Matricula,
                        estudiante.DatosPersonales.NombreCompleto,
                        estudiante.Semestre,
                        estudiante.DatosPersonales.Correo,
                        estudiante.DatosPersonales.Telefono,
                        estudiante.DatosPersonales.Curp,
                        estudiante.DatosPersonales.FechaNacimiento,
                        estudiante.FechaAlta,
                        estudiante.DescripcionEstatus
                    );
                }

                //Asignar el DataTable como origen de datos
                dgvEstudiantes.DataSource = dt;

                //Configurar la apariencia del DataGridView
                ConfigurarDataGridView();

                //Actualizar el total de registros
                lblTotalRegistros.Text = "Total de registros: " + estudiantes.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los estudiantes. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }



        private void ConfigurarDataGridView()
        {
            //Ajustes generales
            dgvEstudiantes.AllowUserToAddRows = false;
            dgvEstudiantes.AllowUserToDeleteRows = false;
            dgvEstudiantes.ReadOnly = true;

            // Ajustar el ancho de las columnas
            dgvEstudiantes.Columns["Matrícula"].Width = 100;
            dgvEstudiantes.Columns["Nombre Completo"].Width = 200;
            dgvEstudiantes.Columns["Semestre"].Width = 80;
            dgvEstudiantes.Columns["Correo"].Width = 180;
            dgvEstudiantes.Columns["Teléfono"].Width = 120;
            dgvEstudiantes.Columns["CURP"].Width = 150;
            dgvEstudiantes.Columns["Fecha Nacimiento"].Width = 120;
            dgvEstudiantes.Columns["Fecha Alta"].Width = 120;
            dgvEstudiantes.Columns["Estatus"].Width = 100;

            // Ocultar columna ID si es necesario
            dgvEstudiantes.Columns["ID"].Visible = false;

            // Formato para las fechas
            dgvEstudiantes.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEstudiantes.Columns["Fecha Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Alineación
            dgvEstudiantes.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEstudiantes.Columns["Matrícula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Semestre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color alternado de filas
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Selección de fila completa
            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de cabeceras
            dgvEstudiantes.EnableHeadersVisualStyles = false;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEstudiantes.Font, FontStyle.Bold);
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenar al hacer clic en el encabezado
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstudiantes.ColumnHeadersHeight = 35;
        }
    }
}
    