using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebMotors.Teste.Domain.Entities;
using WebMotors.Teste.Domain.Interfaces.Repositories;

namespace WebMotors.Teste.Infrastracture.SqlServer
{
    public class AnuncioSqlServerRepository : SqlServerRepository<Anuncio>, IAnuncioSqlServerRepository
    {
        public AnuncioSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<Anuncio> Add(Anuncio entity)
        {
            ProcedureName = "piAnuncioWebMotors";
            Params = new { entity.Marca, entity.Modelo, entity.Versao, entity.Ano, entity.Quilometragem, entity.Observacao };

            return await base.Add(entity);
        }

        public override async Task Delete(Anuncio entity)
        {
            ProcedureName = "pdAnuncioWebMotors";
            Params = new { entity.Id };
            
            await base.Delete(entity);
        }

        public override async Task<IEnumerable<Anuncio>> Get(Anuncio entity)
        {
            ProcedureName = "psAnuncioWebMotors";
            Params = new { entity.Marca, entity.Modelo, entity.Versao };

            return await base.Get(entity);
        }

        public override async Task<Anuncio> Update(Anuncio entity)
        {
            ProcedureName = "puAnuncioWebMotors";
            Params = new { entity.Id, entity.Marca, entity.Modelo, entity.Versao, entity.Ano, entity.Quilometragem, entity.Observacao };
            
            return await base.Update(entity);
        }
    }
}