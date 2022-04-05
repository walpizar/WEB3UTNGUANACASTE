using CapaDatos;
using CapaNegocio;
using Entidades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades.Interfaces;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            configureService(services);


            using (var serviceProvider= services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<frmPrincipal3>();
                form.ShowDialog();
            }
         

        }

        private static void configureService(ServiceCollection services)
        {

            //transient= manejo de memoria dinamico, matiene la memoria memoria,no se usa se la elimina la memoria
            //scoped= manejo de memoria mediante un ambito, como login
            //singleton= mantiene la memoria durante la la ejecucaion del proyecto o servidor. 

            //inyecciones para formularios
            services.AddTransient<frmPrincipal3>();
            services.AddTransient<frmListaClientes>();
            services.AddTransient<frmClientes>();
            services.AddTransient<frmProducto>();
            services.AddTransient<frmBusquedaProducto>();

            //Form reportes
            services.AddTransient<frmRptListaClienteActivo>();
            services.AddTransient<frmRptClienteXTipo>();

            //inyecciones para negocio
            services.AddSingleton<INegocio<tbCliente>, ClientesNegocio>();
            services.AddSingleton<INegocio<tbTipoId>, TipoIdNegocio>();
            services.AddSingleton<INegocio<tbTipoCliente>, TipoClienteNegocio>();


            //inyecciones para datos
            services.AddSingleton<IDatos<tbCliente>, ClientesDatos>();
            services.AddSingleton<IDatos<tbTipoId>, TipoIdDatos>();
            services.AddSingleton<IDatos<tbTipoCliente>, TipoClienteDatos>();

        }
    }
}
