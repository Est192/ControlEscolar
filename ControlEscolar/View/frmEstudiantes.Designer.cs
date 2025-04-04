namespace ControlEscolar.View
{
    partial class frmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            scEstudiantes = new SplitContainer();
            groupBox1 = new GroupBox();
            lbCambiosObligatorios = new Label();
            btnGuardar = new Button();
            dtpFechaBaja = new DateTimePicker();
            lbFechaBaja = new Label();
            cbEstatus = new ComboBox();
            lbEstatus = new Label();
            dtpFechaAlta = new DateTimePicker();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            txtNoControl = new TextBox();
            lbNControl = new Label();
            lbSemestre = new Label();
            upSemestre = new NumericUpDown();
            label2 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            txtCurp = new TextBox();
            tctCURP = new Label();
            txtTelefono = new TextBox();
            lbTelefono = new Label();
            txtCorreo = new TextBox();
            lbCorreo = new Label();
            txtNombre = new TextBox();
            lbNombreCompleto = new Label();
            dgvEstudiantes = new DataGridView();
            gbFiltros = new GroupBox();
            soloActicos = new CheckBox();
            btnActualizar = new Button();
            txtBusqueda = new TextBox();
            lbBusquedaPorTexto = new Label();
            dtpFin = new DateTimePicker();
            lbFechaFin = new Label();
            dtpInicio = new DateTimePicker();
            lbFechaInicio = new Label();
            cbxTipoFecha = new ComboBox();
            label4 = new Label();
            gbHerramientas = new GroupBox();
            lbRutaDeArchivoImportar = new Label();
            btnCargaMasiva = new Button();
            btnMostrarCaptura = new Button();
            toolTip1 = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            lblTotalRegistros = new Label();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).BeginInit();
            scEstudiantes.Panel1.SuspendLayout();
            scEstudiantes.Panel2.SuspendLayout();
            scEstudiantes.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            gbFiltros.SuspendLayout();
            gbHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1554, 46);
            label1.TabIndex = 0;
            label1.Text = "Control de estudiantes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scEstudiantes
            // 
            scEstudiantes.Location = new Point(12, 74);
            scEstudiantes.Name = "scEstudiantes";
            // 
            // scEstudiantes.Panel1
            // 
            scEstudiantes.Panel1.Controls.Add(groupBox1);
            // 
            // scEstudiantes.Panel2
            // 
            scEstudiantes.Panel2.Controls.Add(lblTotalRegistros);
            scEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scEstudiantes.Panel2.Controls.Add(gbFiltros);
            scEstudiantes.Panel2.Controls.Add(gbHerramientas);
            scEstudiantes.Panel2.Paint += splitContainer1_Panel2_Paint_1;
            scEstudiantes.Size = new Size(1554, 758);
            scEstudiantes.SplitterDistance = 517;
            scEstudiantes.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbCambiosObligatorios);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(dtpFechaBaja);
            groupBox1.Controls.Add(lbFechaBaja);
            groupBox1.Controls.Add(cbEstatus);
            groupBox1.Controls.Add(lbEstatus);
            groupBox1.Controls.Add(dtpFechaAlta);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(txtNoControl);
            groupBox1.Controls.Add(lbNControl);
            groupBox1.Controls.Add(lbSemestre);
            groupBox1.Controls.Add(upSemestre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(txtCurp);
            groupBox1.Controls.Add(tctCURP);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(lbTelefono);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(lbCorreo);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lbNombreCompleto);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(511, 752);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alta o edicion";
            // 
            // lbCambiosObligatorios
            // 
            lbCambiosObligatorios.AutoSize = true;
            lbCambiosObligatorios.Location = new Point(50, 660);
            lbCambiosObligatorios.Name = "lbCambiosObligatorios";
            lbCambiosObligatorios.Size = new Size(192, 25);
            lbCambiosObligatorios.TabIndex = 22;
            lbCambiosObligatorios.Text = "* Campos obligatorios";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(313, 655);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 34);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(50, 565);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(182, 31);
            dtpFechaBaja.TabIndex = 20;
            // 
            // lbFechaBaja
            // 
            lbFechaBaja.AutoSize = true;
            lbFechaBaja.Location = new Point(50, 537);
            lbFechaBaja.Name = "lbFechaBaja";
            lbFechaBaja.Size = new Size(95, 25);
            lbFechaBaja.TabIndex = 19;
            lbFechaBaja.Text = "Fecha baja";
            // 
            // cbEstatus
            // 
            cbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstatus.FormattingEnabled = true;
            cbEstatus.Location = new Point(50, 501);
            cbEstatus.Name = "cbEstatus";
            cbEstatus.Size = new Size(182, 33);
            cbEstatus.TabIndex = 18;
            // 
            // lbEstatus
            // 
            lbEstatus.AutoSize = true;
            lbEstatus.Location = new Point(50, 473);
            lbEstatus.Name = "lbEstatus";
            lbEstatus.Size = new Size(68, 25);
            lbEstatus.TabIndex = 17;
            lbEstatus.Text = "Estatus";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(50, 439);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(182, 31);
            dtpFechaAlta.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 411);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 15;
            label3.Text = "Fecha alta";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._33760_block_retro_question_icon;
            pictureBox1.Location = new Point(403, 377);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "T/M-Año de ingreso-Número de alumno\r\n");
            // 
            // txtNoControl
            // 
            txtNoControl.Location = new Point(49, 377);
            txtNoControl.MaxLength = 20;
            txtNoControl.Name = "txtNoControl";
            txtNoControl.Size = new Size(348, 31);
            txtNoControl.TabIndex = 13;
            // 
            // lbNControl
            // 
            lbNControl.AutoSize = true;
            lbNControl.Location = new Point(49, 349);
            lbNControl.Name = "lbNControl";
            lbNControl.Size = new Size(99, 25);
            lbNControl.TabIndex = 12;
            lbNControl.Text = "No.Control";
            // 
            // lbSemestre
            // 
            lbSemestre.AutoSize = true;
            lbSemestre.Location = new Point(295, 287);
            lbSemestre.Name = "lbSemestre";
            lbSemestre.Size = new Size(85, 25);
            lbSemestre.TabIndex = 11;
            lbSemestre.Text = "Semestre";
            // 
            // upSemestre
            // 
            upSemestre.Location = new Point(295, 315);
            upSemestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            upSemestre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            upSemestre.Name = "upSemestre";
            upSemestre.Size = new Size(140, 31);
            upSemestre.TabIndex = 10;
            upSemestre.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 287);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 9;
            label2.Text = "Fecha nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(50, 315);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(149, 31);
            dtpFechaNacimiento.TabIndex = 8;
            // 
            // txtCurp
            // 
            txtCurp.Location = new Point(49, 253);
            txtCurp.MaxLength = 18;
            txtCurp.Name = "txtCurp";
            txtCurp.Size = new Size(386, 31);
            txtCurp.TabIndex = 7;
            // 
            // tctCURP
            // 
            tctCURP.AutoSize = true;
            tctCURP.Location = new Point(49, 225);
            tctCURP.Name = "tctCURP";
            tctCURP.Size = new Size(56, 25);
            tctCURP.TabIndex = 6;
            tctCURP.Text = "CURP";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(49, 191);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(386, 31);
            txtTelefono.TabIndex = 5;
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.Location = new Point(49, 163);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(79, 25);
            lbTelefono.TabIndex = 4;
            lbTelefono.Text = "Telefono";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(49, 129);
            txtCorreo.MaxLength = 30;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(386, 31);
            txtCorreo.TabIndex = 3;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // lbCorreo
            // 
            lbCorreo.AutoSize = true;
            lbCorreo.Location = new Point(49, 101);
            lbCorreo.Name = "lbCorreo";
            lbCorreo.Size = new Size(66, 25);
            lbCorreo.TabIndex = 2;
            lbCorreo.Text = "Correo";
            lbCorreo.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(49, 67);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(386, 31);
            txtNombre.TabIndex = 1;
            // 
            // lbNombreCompleto
            // 
            lbNombreCompleto.AutoSize = true;
            lbNombreCompleto.Location = new Point(49, 39);
            lbNombreCompleto.Name = "lbNombreCompleto";
            lbNombreCompleto.Size = new Size(159, 25);
            lbNombreCompleto.TabIndex = 0;
            lbNombreCompleto.Text = "Nombre completo";
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.Location = new Point(3, 270);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.RowHeadersWidth = 62;
            dgvEstudiantes.Size = new Size(1027, 485);
            dgvEstudiantes.TabIndex = 2;
            // 
            // gbFiltros
            // 
            gbFiltros.Controls.Add(soloActicos);
            gbFiltros.Controls.Add(btnActualizar);
            gbFiltros.Controls.Add(txtBusqueda);
            gbFiltros.Controls.Add(lbBusquedaPorTexto);
            gbFiltros.Controls.Add(dtpFin);
            gbFiltros.Controls.Add(lbFechaFin);
            gbFiltros.Controls.Add(dtpInicio);
            gbFiltros.Controls.Add(lbFechaInicio);
            gbFiltros.Controls.Add(cbxTipoFecha);
            gbFiltros.Controls.Add(label4);
            gbFiltros.Location = new Point(3, 83);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(1027, 150);
            gbFiltros.TabIndex = 1;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros";
            gbFiltros.Enter += gbFiltros_Enter;
            // 
            // soloActicos
            // 
            soloActicos.AutoSize = true;
            soloActicos.Location = new Point(887, 34);
            soloActicos.Name = "soloActicos";
            soloActicos.Size = new Size(134, 29);
            soloActicos.TabIndex = 3;
            soloActicos.Text = "Solo activos";
            soloActicos.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(859, 91);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(112, 34);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(211, 97);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(322, 31);
            txtBusqueda.TabIndex = 7;
            // 
            // lbBusquedaPorTexto
            // 
            lbBusquedaPorTexto.AutoSize = true;
            lbBusquedaPorTexto.Location = new Point(32, 96);
            lbBusquedaPorTexto.Name = "lbBusquedaPorTexto";
            lbBusquedaPorTexto.Size = new Size(166, 25);
            lbBusquedaPorTexto.TabIndex = 6;
            lbBusquedaPorTexto.Text = "Busqueda Por texto";
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(735, 31);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(138, 31);
            dtpFin.TabIndex = 5;
            // 
            // lbFechaFin
            // 
            lbFechaFin.AutoSize = true;
            lbFechaFin.Location = new Point(647, 35);
            lbFechaFin.Name = "lbFechaFin";
            lbFechaFin.Size = new Size(82, 25);
            lbFechaFin.TabIndex = 4;
            lbFechaFin.Text = "Fecha fin";
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(496, 32);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(129, 31);
            dtpInicio.TabIndex = 3;
            // 
            // lbFechaInicio
            // 
            lbFechaInicio.AutoSize = true;
            lbFechaInicio.Location = new Point(387, 35);
            lbFechaInicio.Name = "lbFechaInicio";
            lbFechaInicio.Size = new Size(103, 25);
            lbFechaInicio.TabIndex = 2;
            lbFechaInicio.Text = "Fecha inicio";
            // 
            // cbxTipoFecha
            // 
            cbxTipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoFecha.FormattingEnabled = true;
            cbxTipoFecha.Location = new Point(145, 37);
            cbxTipoFecha.Name = "cbxTipoFecha";
            cbxTipoFecha.Size = new Size(197, 33);
            cbxTipoFecha.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 37);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 0;
            label4.Text = "Tipo de fecha";
            // 
            // gbHerramientas
            // 
            gbHerramientas.Controls.Add(lbRutaDeArchivoImportar);
            gbHerramientas.Controls.Add(btnCargaMasiva);
            gbHerramientas.Controls.Add(btnMostrarCaptura);
            gbHerramientas.Location = new Point(3, 3);
            gbHerramientas.Name = "gbHerramientas";
            gbHerramientas.Size = new Size(1027, 74);
            gbHerramientas.TabIndex = 0;
            gbHerramientas.TabStop = false;
            gbHerramientas.Text = "Herramientas";
            // 
            // lbRutaDeArchivoImportar
            // 
            lbRutaDeArchivoImportar.AutoSize = true;
            lbRutaDeArchivoImportar.Location = new Point(387, 35);
            lbRutaDeArchivoImportar.Name = "lbRutaDeArchivoImportar";
            lbRutaDeArchivoImportar.Size = new Size(217, 25);
            lbRutaDeArchivoImportar.TabIndex = 2;
            lbRutaDeArchivoImportar.Text = "Ruta de archivo a inportar";
            // 
            // btnCargaMasiva
            // 
            btnCargaMasiva.Location = new Point(208, 30);
            btnCargaMasiva.Name = "btnCargaMasiva";
            btnCargaMasiva.Size = new Size(134, 34);
            btnCargaMasiva.TabIndex = 1;
            btnCargaMasiva.Text = "Carga Masiva";
            btnCargaMasiva.UseVisualStyleBackColor = true;
            btnCargaMasiva.Click += btnCargaMasiva_Click;
            // 
            // btnMostrarCaptura
            // 
            btnMostrarCaptura.Location = new Point(37, 30);
            btnMostrarCaptura.Name = "btnMostrarCaptura";
            btnMostrarCaptura.Size = new Size(152, 34);
            btnMostrarCaptura.TabIndex = 0;
            btnMostrarCaptura.Text = "MostrarCaptura";
            btnMostrarCaptura.UseVisualStyleBackColor = true;
            btnMostrarCaptura.Click += btnMostrarCaptura_Click;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "Cargamasiva";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(23, 242);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(192, 25);
            lblTotalRegistros.TabIndex = 3;
            lblTotalRegistros.Text = "                                    ";
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(scEstudiantes);
            Controls.Add(label1);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            scEstudiantes.Panel1.ResumeLayout(false);
            scEstudiantes.Panel2.ResumeLayout(false);
            scEstudiantes.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).EndInit();
            scEstudiantes.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            gbHerramientas.ResumeLayout(false);
            gbHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private SplitContainer scEstudiantes;
        private GroupBox groupBox1;
        private Label lbCorreo;
        private TextBox txtNombre;
        private Label lbNombreCompleto;
        private Label lbTelefono;
        private TextBox txtCorreo;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtCurp;
        private Label tctCURP;
        private TextBox txtTelefono;
        private NumericUpDown upSemestre;
        private Label label2;
        private TextBox txtNoControl;
        private Label lbNControl;
        private Label lbSemestre;
        private PictureBox pictureBox1;
        private Label label3;
        private ToolTip toolTip1;
        private DateTimePicker dtpFechaAlta;
        private ComboBox cbEstatus;
        private Label lbEstatus;
        private GroupBox gbFiltros;
        private GroupBox gbHerramientas;
        private Button btnMostrarCaptura;
        private Button btnCargaMasiva;
        private Label lbRutaDeArchivoImportar;
        private Label lbFechaBaja;
        private DateTimePicker dtpFechaBaja;
        private Label lbFechaInicio;
        private ComboBox cbxTipoFecha;
        private Label label4;
        private Button btnActualizar;
        private TextBox txtBusqueda;
        private Label lbBusquedaPorTexto;
        private DateTimePicker dtpFin;
        private Label lbFechaFin;
        private DateTimePicker dtpInicio;
        private Label lbCambiosObligatorios;
        private Button btnGuardar;
        private OpenFileDialog ofdArchivo;
        private DataGridView dgvEstudiantes;
        private CheckBox soloActicos;
        private Label lblTotalRegistros;
    }
}