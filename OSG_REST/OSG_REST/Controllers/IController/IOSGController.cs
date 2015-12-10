using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OSG_REST.Controllers.IController
{
    public interface IOSGController<T>
    {
      
        T Create(T dto);
        T ReadById(int id);
        IEnumerable<T> ReadAll();
        T Update(int id, T dto);
        Boolean Delete(int id);

    }
}
