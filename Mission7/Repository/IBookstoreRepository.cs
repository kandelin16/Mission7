using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Repository
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> books { get;  }
    }
}
