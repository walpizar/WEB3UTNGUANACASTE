using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal3 : Form
    {
        public frmPrincipal3()
        {
            InitializeComponent();
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            //cierra todo el aplicativo
            Application.Exit();

            //cierra la ventana
            //this.Close();
        }

        private void frmPrincipal3_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "UTN App";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbMostrarMenu_Click(object sender, EventArgs e)
        {
            //== comparación
            //= asignación
            //if- estructura condicional
            //ocultarme el panel del menu cuando este desplegado
            if (pnlMenu.Width==170)
            {
                //cabia el ancho a 0
                pnlMenu.Width = 0;

            }
            else
            {
                //si es 0, esta oculto, me lo pasa a 170, me lo muestra.
                pnlMenu.Width = 170;
            }

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {


            frmClientes form = new frmClientes();
            form.ShowDialog();
        }
    }
}
