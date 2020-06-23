using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Teste.Domain.Interfaces.Repositories;
using WebMotors.Teste.Domain.Interfaces.Services;

namespace WebMotors.Teste.Domain.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<IEnumerable<T>> Get(T entity)
        {
            return await _repository.Get(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}