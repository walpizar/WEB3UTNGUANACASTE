using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClientesNegocio
    {

        public clsCliente guardar(clsCliente cliente)
        {

            //aplique reglas de negocio
            //regla no exista en la base datos la cedula 6-1111111


            //llamar a mi capa de datos. al metodo guardar()
            ClientesDatos clienteDatos = new ClientesDatos();
            return clienteDatos.guardar(cliente);
          
        }
    }
}
