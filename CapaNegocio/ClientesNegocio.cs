using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Exceptions;
using Utilidades.Interfaces;

namespace CapaNegocio
{
    public class ClientesNegocio : INegocio<tbCliente>
    {
        public IDatos<tbCliente> ClienteDatos { get; }



        public ClientesNegocio(IDatos<tbCliente> _clienteDatos)
        {
            ClienteDatos = _clienteDatos;
        }

   

        //ClientesDatos clienteDato = new ClientesDatos();

        public bool delete(tbCliente cliente)
        {
            try
            {
                return ClienteDatos.delete(cliente);
            }            
            catch (Exception ex)
            {

                throw;
            }
        
        }

        public List<tbCliente> getAll()
        {
            try
            {
                return ClienteDatos.getAll();
            }
            catch (Exception ex)
            {

                throw;
            }
   
        }

        public tbCliente getById(string id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public tbCliente save(tbCliente cliente)
        {
            
            try
            {
                //reglas de negocio
                //el cliente no exista mediante su identificacion
                var cli = ClienteDatos.getById(cliente.id);
                if(cli != null)
                {
                    throw new EntityExistException("Cliente");

                }

                return ClienteDatos.save(cliente);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public tbCliente update(tbCliente cliente)
        {
            try
            {
                //reglas de nogocio, en este no aplica ninguna de las que tenemos en el save

                return ClienteDatos.update(cliente);
            }
            catch (Exception ex)
            {

                throw;
            }
  
        }

    }
}
