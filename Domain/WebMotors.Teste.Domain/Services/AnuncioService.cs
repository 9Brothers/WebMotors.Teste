using WebMotors.Teste.Domain.Entities;
using WebMotors.Teste.Domain.Interfaces.Repositories;
using WebMotors.Teste.Domain.Interfaces.Services;

namespace WebMotors.Teste.Domain.Services
{
    public class AnuncioService : Service<Anuncio>, IAnuncioService
    {
        public AnuncioService(IAnuncioSqlServerRepository repository) : base(repository)
        {
        }
    }
}