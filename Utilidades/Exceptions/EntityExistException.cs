using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Exceptions
{
    public class EntityExistException : Exception
    {
        //public EntityExistException(string entity): base(entity+ " ya existe en la base de datos.")
        //{
        //}

        //string format, new line= salto de linea.
        //public EntityExistException(string entity) : base(string.Format("{0} ya existe en la base {3} de datos. {1}", entity, 5, Environment.NewLine))
        //{
        //}
        public EntityExistException(string entity) : base(string.Format("{0} ya existe en la base de datos.", entity))
        {
        }
    }
}
