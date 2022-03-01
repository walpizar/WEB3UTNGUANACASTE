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
            throw new NotImplementedException();
        }

        public List<clsCliente> getAll()
        {
            //LINQ
            //empresion LAMBDA
            return this.lista.Where(x=>x.estado==true).ToList();
        }

        public clsCliente getById(int id)
        {
            throw new NotImplementedException();
        }

        public clsCliente save(clsCliente cliente)
        {
            //lista
            this.lista.Add(cliente);
            return cliente;


        }

        public clsCliente update(clsCliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
