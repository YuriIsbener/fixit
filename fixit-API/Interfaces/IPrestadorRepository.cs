using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface IPrestadorRepository
    {
        List<Prestador> ListarMinhas(int id);

    }
}
