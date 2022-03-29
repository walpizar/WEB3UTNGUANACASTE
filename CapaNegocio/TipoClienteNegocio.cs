using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaNegocio
{
    public class TipoClienteNegocio : INegocio<tbTipoCliente>
    {
        public IDatos<tbTipoCliente> TipoClienteDatos { get; }
        
        public TipoClienteNegocio(IDatos<tbTipoCliente> _tipoClienteDatos)
        {
            TipoClienteDatos = _tipoClienteDatos;
        }   

        public bool delete(tbTipoCliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<tbTipoCliente> getAll()
        {
            try
            {
                return TipoClienteDatos.getAll();
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
