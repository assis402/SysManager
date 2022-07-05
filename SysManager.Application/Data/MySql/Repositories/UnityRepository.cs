using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UnityRepository
    {
        private readonly MySqlContext _context;

        public UnityRepository(MySqlContext context) => _context = context;

        public async Task<ResponseDefault> CreateAsync(UnityEntity entity)
        {
            string query = $"INSERT INTO unity(id, name, active) VALUES('{entity.Id}', '{entity.Name}', {entity.Active})";

            using var connection = _context.Connection();
            var result = await connection.ExecuteAsync(query);

            if (result > 0)
                return new ResponseDefault(entity.Id.ToString(), "Unidade de Medida criada com sucesso", false);

            return new ResponseDefault("", "Erro ao tentar criar Unidade de Medida", true);
        }

        public async Task<ResponseDefault> UpdateAsync(UnityEntity entity)
        {
            string query = $"update unity set name = '{entity.Name}', active = {entity.Active} where id = '{entity.Id}'";

            using (var connection = _context.Connection())
            {
                var result = await connection.ExecuteAsync(query);

                if (result > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Unidade de Medida alterada com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar alterada Unidade de Medida", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            string strQuery = $"delete from unity where id = '{id}'";

            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(strQuery);
                if (result > 0)
                    return new ResponseDefault(id.ToString(), "Unidade de Medida excluída com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar excluír Unidade de Medida", true);
        }

        public async Task<UnityEntity> GetByIdAsync(Guid id)
        {
            string query = $"select id, name, active from unity where id = '{id}'";

            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UnityEntity>(query);
                return result; 
            }
        }

        public async Task<UnityEntity> GetUnityByNameAsync(string name)
        {
            string query = $"select id, name, active from unity where name = '{name}' limit 1";

            using (var connection = _context.Connection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<UnityEntity>(query);
                return result;
            }
        }

        public async Task<PaginationResponse<UnityEntity>> GetByFilterAsync(UnityGetByFilterRequest filter)
        {
            var sql = new StringBuilder("select id, name, active from unity where 1=1");
            var where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                where.Append($" AND name = '{filter.Name}'");

            if (filter.Active != null)
                where.Append($" AND active = '{filter.Active}'");

            sql.Append(where);
            
            if (filter.Page > 0 && filter.PageSize > 0)
                sql.Append($" limit {filter.PageSize * filter.Page - 1}, {filter.PageSize}");

            using (var connection = _context.Connection())
            {
                var result = await connection.QueryAsync<UnityEntity>(sql.ToString());

                return new PaginationResponse<UnityEntity>(filter.PageSize, filter.Page, result);
            }
        }
    }
}