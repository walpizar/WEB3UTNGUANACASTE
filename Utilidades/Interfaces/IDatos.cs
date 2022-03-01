using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Interfaces
{
    public interface IDatos <entity>
    {
        entity save(entity cliente);
        entity update(entity cliente);
        bool delete(entity cliente);
        List<entity> getAll();
        entity getById(int id);

    }
}
