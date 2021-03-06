using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmPrincipal2 : Form
    {
        public IServiceProvider ServiceProvider { get; }

        public frmPrincipal2(IServiceProvider _serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = _serviceProvider;
        }
      /// <summary>
      /// evento click de menu cliente, muestra el formulario cliente
      /// </summary>
      /// <param name="sender"> es para bla bla</param>
      /// <param name="e"> es para bla bla</param>
        private void mnuClientes_Click(object sender, EventArgs e)
        {
            //comentarios
            //una linea

            /* comentario de bloque
            int c = 0;
            int xc = 0;
            */


            var form = ServiceProvider.GetRequiredService<frmListaClientes>();
            //frmListaClientes form = new frmListaClientes();
            form.ShowDialog();
        }

        private void frmPrincipal2_Load(object sender, EventArgs e)
        {

        }
    }
}
