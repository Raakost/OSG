﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
