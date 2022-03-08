using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaDatos
{
    public class ClientesDatos : IDatos<clsCliente>
    {

        //declaracion
        List<clsCliente> lista;

        public ClientesDatos()
        {
            //instanciacion de lista
            this.lista = new List<clsCliente>();
        }

        public bool delete(clsCliente cliente)
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

        public List<clsCliente> getAll()
        {
            try
            {
                //LINQ
                //empresion LAMBDA
                return this.lista.Where(x => x.estado == true).ToList();
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

        private int getNextId()
        {
            try
            {
                return lista.Count() + 1;
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
                //lista
                //manejo excpciones
                           
                cliente.id = getNextId();
                this.lista.Add(cliente);
                return cliente;
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
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        public clsCliente getByIdent(string id)
        {
            try
            {
                //trabajo clase devuelve cliente sino devuelve null.

                return lista.Where(x => x.identificacion.Trim().Equals(id.Trim())).SingleOrDefault();



                //foreach (var cliente in lista)
                //{
                //    if (cliente.identificacion==id) {

                //        return cliente;
                //    }

                //}
                //return null;

               
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
