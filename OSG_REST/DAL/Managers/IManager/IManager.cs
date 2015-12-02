using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers.IManager
{
    public interface IManager<T>
    {

        T Create(T model);
        T ReadByID(int Id);
        IEnumerable<T> ReadAll(int amound = 10);
        T Update(T model);
        Boolean Delete(T model);

    }
}
