using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Interfaces
{
    public interface INegocio <entity>
    {
        //es un contrato con los objetos que implementan
        //solamente vamos a tener las firmas de los metodos.

        entity save(entity cliente);
        entity update(entity cliente);
        bool delete(entity cliente);
        List<entity> getAll();
        entity getById(string id);


    }
}
