using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaDatos
{
    public class TipoClienteDatos : IDatos<tbTipoCliente>
    {
        public bool delete(tbTipoCliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<tbTipoCliente> getAll()
        {
            try
            {
                using (var context = new dbUtnProgra3Entities())
                {

                    return context.tbTipoCliente.ToList();

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public tbTipoCliente getById(string id)
        {
            throw new NotImplementedException();
        }

        public tbTipoCliente save(tbTipoCliente cliente)
        {
            throw new NotImplementedException();
        }

        public tbTipoCliente update(tbTipoCliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
