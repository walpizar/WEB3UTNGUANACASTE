using CapaNegocio;
using Entidades;
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
using Utilidades.Interfaces;

namespace CapaPresentacion
{
    public partial class frmListaClientes : Form
    {
        public INegocio<clsCliente> ClienteNegocio { get; }
        public IServiceProvider ServiceProvider { get; }

        //ClientesNegocio clienteNegocio = new ClientesNegocio();

        //inyeccion
        public frmListaClientes(INegocio<clsCliente> _clienteNegocio, IServiceProvider _serviceProvider )
        {
            InitializeComponent();
            ClienteNegocio = _clienteNegocio;
            ServiceProvider = _serviceProvider;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Mantenimiento de Clientes";
            obtenerDatos();

        }
        private void obtenerDatos()
        {

           var lista= ClienteNegocio.getAll();

            cargarListView(lista);


        }
        private void cargarListView(List<clsCliente> lista)
        {
            lstvLista.Items.Clear();


            foreach (var cliente in lista)
            {
                ListViewItem item = new ListViewItem();
                item.Text = cliente.identificacion;
                item.SubItems.Add( cliente.nombre.Trim().ToUpper());
                item.SubItems.Add( cliente.apellido1.Trim().ToUpper());
                item.SubItems.Add( cliente.apellido2.Trim().ToUpper());
                lstvLista.Items.Add(item);
            }
        }



        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //abrir el formulario de crear frmClientes
            var form = ServiceProvider.GetRequiredService<frmClientes>();
            //frmListaClientes form = new frmListaClientes();
            form.ShowDialog();

            obtenerDatos();






        }
    }
}
