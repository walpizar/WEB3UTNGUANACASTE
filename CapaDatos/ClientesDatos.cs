using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaDatos
{
    public class ClientesDatos : IDatos<tbCliente>
    {

        //declaracion
       // List<tbCliente> lista;

        public ClientesDatos()
        {
            //instanciacion de lista
           // this.lista = new List<tbCliente>();
        }

        public bool delete(tbCliente cliente)
        {
            try
            {

                cliente.estado = false;
                using (var context = new dbUtnProgra3Entities())
                {                 
                    context.Entry<tbCliente>(cliente).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                }

                return true;
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
                using (var context = new dbUtnProgra3Entities())
                {

                   return context.tbCliente.Include("tbPersona").Where(x=>x.estado==true).ToList();

                }


                //LINQ
                //empresion LAMBDA
                //return this.lista.Where(x => x.estado == true).ToList();
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
                using (var context = new dbUtnProgra3Entities())
                {

                    return context.tbCliente.Where(x => x.id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        //private int getNextId()
        //{
        //    try
        //    {
        //        return lista.Count() + 1;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
           
        //}

        public tbCliente save(tbCliente cliente)
        {
            try
            {
                //lista
                //manejo excpciones

                //  cliente.id = getNextId();
                //this.lista.Add(cliente);

                using (var context= new dbUtnProgra3Entities())
                {
                    context.tbCliente.Add(cliente);
                    context.SaveChanges();//commit

                }
                 
                return cliente;
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
                using (var context = new dbUtnProgra3Entities())
                {
                    context.Entry<tbPersona>(cliente.tbPersona).State = System.Data.Entity.EntityState.Modified;
                    context.Entry<tbCliente>(cliente).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                }


                return cliente;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        //public tbCliente getByIdent(string id)
        //{
        //    try
        //    {
        //        //trabajo clase devuelve cliente sino devuelve null.

        //        //return lista.Where(x => x.identificacion.Trim().Equals(id.Trim())).SingleOrDefault();

        //        return null;

        //        //foreach (var cliente in lista)
        //        //{
        //        //    if (cliente.identificacion==id) {

        //        //        return cliente;
        //        //    }

        //        //}
        //        //return null;

               
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
           
        //}
    }
}
