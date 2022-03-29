using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaNegocio
{
    public class TipoIdNegocio : INegocio<tbTipoId>
    {
        public IDatos<tbTipoId> TipoIdDatos { get; }

        public TipoIdNegocio(IDatos<tbTipoId> _tipoIdDatos)
        {
            TipoIdDatos = _tipoIdDatos;
        }      

        public bool delete(tbTipoId cliente)
        {
            throw new NotImplementedException();
        }

        public List<tbTipoId> getAll()
        {
            try
            {
                return TipoIdDatos.getAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public tbTipoId getById(string id)
        {
            throw new NotImplementedException();
        }

        public tbTipoId save(tbTipoId cliente)
        {
            throw new NotImplementedException();
        }

        public tbTipoId update(tbTipoId cliente)
        {
            throw new NotImplementedException();
        }
    }
}
