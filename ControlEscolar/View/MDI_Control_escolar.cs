using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolar.View
{
    public partial class MDI_Control_escolar : Form
    {
        public MDI_Control_escolar()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstudiantes forma_estudiantes = new frmEstudiantes(this);
            forma_estudiantes.Show();
        }

        private void reporte111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte111 forma_reporte111 = new frmReporte111(this);
            forma_reporte111.Show();
        }

        private void reporte12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte12 forma_reporte12 = new frmReporte12(this);
            forma_reporte12.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles forma_roles = new frmRoles(this);
            forma_roles.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios forma_usuarios = new frmUsuarios(this);
            forma_usuarios.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicohToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mosaicoverticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }


        private void AbreVentanaHija(string nombre_forma)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.ToLower() == nombre_forma)
                {
                    //Si la ventana lla esta abierta traer al frente
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                }
            }

            //Si la ventana no esta abierta crear y mostrar una nueva instancia
            Form childForm;
            switch (nombre_forma.ToLower())
            {
                case "frmEstudiantes":
                    childForm = new frmEstudiantes(this);
                    break;
                case "frmReporte111":
                    childForm = new frmReporte111(this);
                    break;
                case "frmReporte12":
                    childForm = new frmReporte12(this);
                    break;
                case "frmRoles":
                    childForm = new frmRoles(this);
                    break;
                case "frmUsuarios":
                    childForm = new frmUsuarios(this);
                    break;
            }

        }

    }
}
