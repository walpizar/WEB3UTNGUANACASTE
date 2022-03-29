using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Interfaces;

namespace CapaDatos
{
    public class TipoIdDatos : IDatos<tbTipoId>
    {
        public bool delete(tbTipoId cliente)
        {
            throw new NotImplementedException();
        }

        public List<tbTipoId> getAll()
        {
            try
            {
                using (var context = new dbUtnProgra3Entities())
                {

                    return context.tbTipoId.ToList();

                }

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
