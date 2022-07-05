using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(MySqlContext context) : base(context) { }

        public async Task<ResponseDefault> CreateAsync(CategoryEntity entity)
        {
            var query = @"INSERT INTO category(id, name, active, parentId) " + 
                        @"VALUES(@Id, @Name, @Active, @ParentId)";


            //var param = new
            //{
            //    entity.Id,
            //    entity.ProductCode,
            //    entity.Name,
            //    entity.Active,
            //    entity.ProductTypeId,
            //    entity.ProductCategoryId,
            //    entity.ProductUnityId,
            //    entity.CostPrice,
            //    entity.Price,
            //    entity.Percentage
            //};

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Categoria criado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Categoria", true);
        }

        public async Task<ResponseDefault> UpdateAsync(CategoryEntity entity)
        {
            var query = $"UPDATE category " +
                        $"SET name = @Name, active = @Active " +
                        $"WHERE id = @Id";

            //var param = new
            //{
            //    entity.Id,
            //    entity.Name,
            //    entity.Active
            //};

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Categoria alterado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao alterar Categoria", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            var query = $"DELETE FROM category WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Categoria excluído com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao excluir Categoria", true);
        }

        public async Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            var query = $"SELECT * FROM category WHERE id = '{id}' AND active = true";
            return await QueryFirstOrDefaultAsync<CategoryEntity>(query);
        }

        public async Task<CategoryEntity> GetByNameAsync(string name)
        {
            var query = $"SELECT * FROM category WHERE name = '{name}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<CategoryEntity>(query);
        }

        public async Task<PaginationResponse<CategoryEntity>> GetByFilterAsync(UnityGetByFilterRequest filter)
        {
            var sql = new StringBuilder("SELECT * FROM category WHERE 1=1");
            var where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                where.Append($" AND name = '{filter.Name}'");

            if (filter.Active != null)
                where.Append($" AND active = '{filter.Active}'");

            sql.Append(where);
            
            if (filter.Page > 0 && filter.PageSize > 0)
                sql.Append($" LIMIT {filter.PageSize * filter.Page - 1}, {filter.PageSize}");

            var result = await QueryAsync<CategoryEntity>(sql.ToString());

            return new PaginationResponse<CategoryEntity>(filter.PageSize, filter.Page, result);
        }
    }
}