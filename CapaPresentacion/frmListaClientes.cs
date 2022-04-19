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
        List<tbCliente> lista;
        public INegocio<tbCliente> ClienteNegocio { get; }
        public IServiceProvider ServiceProvider { get; }

        //ClientesNegocio clienteNegocio = new ClientesNegocio();

        //inyeccion
        public frmListaClientes(INegocio<tbCliente> _clienteNegocio, IServiceProvider _serviceProvider )
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
            try
            {
                lista = ClienteNegocio.getAll();

                cargarListView(lista);
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo cargar la lista", "Cargar lista clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cargarListView(List<tbCliente> lista)
        {
            lstvLista.Items.Clear();


            foreach (var cliente in lista)
            {
                ListViewItem item = new ListViewItem();
                item.Text = cliente.id;
                item.SubItems.Add( cliente.tbPersona.nombre.Trim().ToUpper());
                item.SubItems.Add( cliente.tbPersona.apellido1.Trim().ToUpper());
                item.SubItems.Add( cliente.tbPersona.apellido2.Trim().ToUpper());
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

        private void lstvLista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var ident = lstvLista.SelectedItems[0].Text;
                var cliente = lista.Where(x => x.id.Trim().Equals(ident.Trim())).SingleOrDefault();

                var form = ServiceProvider.GetRequiredService<frmClientes>();
                form.clienteGlobal = cliente;
                form.ShowDialog();


                obtenerDatos();
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo cargar el cliente", "Cargar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == string.Empty)
            {
                cargarListView(lista);

            }
            else
            {
                var listaFiltrada = lista.Where(x => x.id.Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()) 
                || x.tbPersona.nombre.Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper())
                || x.tbPersona.apellido1.Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper())
                || x.tbPersona.apellido2.Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper())).ToList();

                cargarListView(listaFiltrada);
            }

        }

        private void btnReporteActivos_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<frmRptListaClienteActivo>();        
            form.ShowDialog();
        }

        private void btnReporteXTipo_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<frmRptClienteXTipo>();
            form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<frmRptComprasCliente>();
            form.ShowDialog();
        }
    }
}
