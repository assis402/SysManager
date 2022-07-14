using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public abstract class BaseRepository
    {
        private readonly MySqlContext _context;

        public BaseRepository(MySqlContext context) => _context = context;

        public async Task<bool> ExecuteAsync(string query)
        {
            using var connection = _context.Connection();
            var result = await connection.ExecuteAsync(query);
            return result > 0;
        }

        public async Task<bool> ExecuteAsync(string query, object param)
        {
            using var connection = _context.Connection();
            var result = await connection.ExecuteAsync(query, param);
            return result > 0;
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query)
        {
            using var connection = _context.Connection();
            return await connection.QueryFirstOrDefaultAsync<T>(query);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using var connection = _context.Connection();
            return await connection.QueryAsync<T>(query);
        }
    }
}