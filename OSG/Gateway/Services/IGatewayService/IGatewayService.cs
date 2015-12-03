using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.IGatewayService
{
    public interface IGatewayService<T>
    {
        
        T Create(T model);
        IEnumerable<T> ReadAll(int amound);
        T ReadById(int id);
        T Update(T model);
        bool Delete(T model);
    }
}
