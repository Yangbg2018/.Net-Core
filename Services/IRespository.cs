using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Services
{
    public interface IRespository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Detail(int id);
        T Add(T newModel);
    }
}
