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
using NLog;


namespace ControlEscolar.View
{
    public partial class frmLogin : Form
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("ControlEscolar.View.frmLogin");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtUsuario.Text))
            //{
            //    MessageBox.Show("El campo de usuario no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtContraseña.Text))
            //{
            //    MessageBox.Show("El campo de contraseña no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!UsuarioNegocio.EsFormatoValido(txtUsuario.Text))
            //{
            //    MessageBox.Show("El nombre de usuario no tiene un formato correcto. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //MessageBox.Show("Listo para iniciar sesion. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Hide();
            //MDI_Control_escolar mdi = new MDI_Control_escolar();
            //mdi.Show();

            #region Solucion a los comentarios
            this.DialogResult = DialogResult.OK;
            this.Close();
            #endregion
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _Logger.Info("Usuario ha accedido a iniciar secion");
            _Logger.Warn("Espacio en disco abajo");

            //Aqui simulamos una exepcion
            try
            {
                try
                {
                    //aqui provocamos una exepcion
                    int divisor = 0;
                    int resultado = 10 / divisor; //esta linea provocara una exepcion
                }
                catch (DivideByZeroException ex)
                {
                    _Logger.Error(ex, "Error con la operacion");
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Se produjo un error en la aplicacion");
                if (ex.InnerException != null)
                {
                    _Logger.Fatal(ex.InnerException, "Error icritico con detalle interno");
                }
            }

        }
    }
}
