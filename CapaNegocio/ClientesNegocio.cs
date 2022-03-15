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
    public class ClientesNegocio : INegocio<clsCliente>
    {
        public IDatos<clsCliente> ClienteDatos { get; }
        public ClientesNegocio(IDatos<clsCliente> _clienteDatos)
        {
            ClienteDatos = _clienteDatos;
        }

   

        //ClientesDatos clienteDato = new ClientesDatos();

        public bool delete(clsCliente cliente)
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

        public List<clsCliente> getAll()
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

        public clsCliente getById(int id)
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

        public clsCliente save(clsCliente cliente)
        {
            
            try
            {
                //reglas de negocio
                //el cliente no exista mediante su identificacion
                var cli = ClienteDatos.getByIdent(cliente.identificacion);
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

        public clsCliente update(clsCliente cliente)
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
