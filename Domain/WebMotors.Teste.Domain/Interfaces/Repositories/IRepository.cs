using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.Teste.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> Get(T entity);
    }
}