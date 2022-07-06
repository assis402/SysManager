using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UnityRepository : BaseRepository
    {
        public UnityRepository(MySqlContext context) : base(context) { }

        public async Task<ResponseDefault> CreateAsync(UnityEntity entity)
        {
            var query = @"INSERT INTO unity(id, name, active) VALUES(@Id, @Name, @Active)";

            var param = new
            {
                entity.Id,
                entity.Name,
                entity.Active
            };

            var result = await ExecuteAsync(query, param);

            return result ? new ResponseDefault("Unidade de Medida criada com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Unidade de Medida", true);
        }

        public async Task<ResponseDefault> UpdateAsync(UnityEntity entity)
        {
            var query = $"UPDATE unity SET name = @Name, active = @Active WHERE id = @Id";

            var param = new
            {
                entity.Id,
                entity.Name,
                entity.Active
            };

            var result = await ExecuteAsync(query, param);

            return result ? new ResponseDefault("Unidade de Medida alterada com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao alterar Unidade de Medida", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            var query = $"DELETE FROM unity WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Unidade de Medida excluída com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao excluir Unidade de Medida", true);
        }

        public async Task<UnityEntity> GetByIdAsync(Guid id)
        {
            var query = $"SELECT id, name, active FROM unity WHERE id = '{id}' AND active = true";
            return await QueryFirstOrDefaultAsync<UnityEntity>(query);
        }

        public async Task<UnityEntity> GetByNameAsync(string name)
        {
            var query = $"SELECT id, name, active FROM unity WHERE name = '{name}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<UnityEntity>(query);
        }

        public async Task<PaginationResponse<UnityEntity>> GetByFilterAsync(UnityGetByFilterRequest filter)
        {
            var sql = new StringBuilder("SELECT id, name, active FROM unity WHERE 1=1");
            var where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                where.Append($" AND name = '{filter.Name}'");

            if (filter.Active != null)
                where.Append($" AND active = '{filter.Active}'");

            sql.Append(where);
            
            if (filter.Page > 0 && filter.PageSize > 0)
                sql.Append($" LIMIT {filter.PageSize * filter.Page - 1}, {filter.PageSize}");

            var result = await QueryAsync<UnityEntity>(sql.ToString());

            return new PaginationResponse<UnityEntity>(filter.PageSize, filter.Page, result);
        }
    }
}