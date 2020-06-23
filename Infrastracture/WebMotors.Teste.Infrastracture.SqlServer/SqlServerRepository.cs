using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebMotors.Teste.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Collections.Generic;

namespace WebMotors.Teste.Infrastracture.SqlServer
{
    public class SqlServerRepository<T> : ISqlServerRepository<T> where T : class
    {
        protected string ProcedureName;
        protected object Params;

        private readonly string _connectionString;

        public SqlServerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public virtual async Task<T> Add(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task Delete(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.ExecuteAsync(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<IEnumerable<T>> Get(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<T> Update(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        
    }
}