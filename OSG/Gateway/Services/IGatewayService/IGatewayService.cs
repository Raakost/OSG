using System.Collections.Generic;

namespace Gateway.Services.IGatewayService
{
    public interface IGatewayService<T>
    {
        
        T Create(T model);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        T Update(T model);
        bool Delete(int id);
    }
}
