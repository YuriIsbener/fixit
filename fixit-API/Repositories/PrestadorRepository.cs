using fixit_API.Domains;
using fixit_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        fixit_dbContext ctx = new fixit_dbContext();

    }
}
