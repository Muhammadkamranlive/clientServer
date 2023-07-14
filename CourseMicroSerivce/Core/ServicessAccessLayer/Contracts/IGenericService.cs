using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Contracts
{
    public interface IGenericService<T> where T:class
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Delete(int id );
        Task InsertAsync(T entity);
        void UpdateRecord(T entity);
        Task<int> CompleteAync();

    }
}
