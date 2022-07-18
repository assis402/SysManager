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
        public UnityRepository(MySqlContext context) : base(context)
        {
        }

        public virtual async Task<ResponseDefault> CreateAsync(UnityEntity entity)
        {
            var query = @"INSERT INTO unity(id, name, active) VALUES(@Id, @Name, @Active)";

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Unidade de Medida criada com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Unidade de Medida", true);
        }

        public virtual async Task<ResponseDefault> UpdateAsync(UnityEntity entity)
        {
            var query = $"UPDATE unity SET name = @Name, active = @Active WHERE id = @Id";

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Unidade de Medida alterada com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao alterar Unidade de Medida", true);
        }

        public virtual async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            var query = $"DELETE FROM unity WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Unidade de Medida excluída com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao excluir Unidade de Medida", true);
        }

        public virtual async Task<UnityEntity> GetByIdAsync(Guid id)
        {
            var query = $"SELECT id, name, active FROM unity WHERE id = '{id}' AND active = true";
            return await QueryFirstOrDefaultAsync<UnityEntity>(query);
        }

        public virtual async Task<UnityEntity> GetByNameAsync(string name)
        {
            var query = $"SELECT id, name, active FROM unity WHERE name = '{name}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<UnityEntity>(query);
        }

        public virtual async Task<PaginationResponse<UnityEntity>> GetByFilterAsync(UnityGetByFilterRequest filter)
        {
            var _sql = new StringBuilder("select id, name, active from unity where 1=1");
            var _where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                _where.Append($" AND name = '{filter.Name}'");

            if (filter.Active != "todos")
            {
                string _booleanField = "";
                if (filter.Active == "ativos")
                    _booleanField = " AND active = true";
                else if (filter.Active == "inativos")
                    _booleanField = " AND active = false";

                _where.Append(_booleanField);
            }
            _sql.Append(_where);

            if (filter.page > 0 && filter.pageSize > 0)
                _sql.Append($" limit {filter.pageSize * (filter.page - 1)}, {filter.pageSize}");

            var result = await QueryAsync<UnityEntity>(_sql.ToString());

            return new PaginationResponse<UnityEntity>(filter.pageSize, filter.page, result);
        }
    }
}