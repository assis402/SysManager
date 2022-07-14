using SysManager.Application.Contracts;
using SysManager.Application.Contracts.ProductType.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class ProductTypeRepository : BaseRepository
    {
        public ProductTypeRepository(MySqlContext context) : base(context)
        {
        }

        public async Task<ResponseDefault> CreateAsync(ProductTypeEntity entity)
        {
            var query = @"INSERT INTO category(id, name, active) " +
                        @"VALUES(@Id, @Name, @Active)";

            //var param = new
            //{
            //    entity.Id,
            //    entity.ProductCode,
            //    entity.Name,
            //    entity.Active,
            //    entity.ProductTypeId,
            //    entity.ProductProductTypeId,
            //    entity.ProductUnityId,
            //    entity.CostPrice,
            //    entity.Price,
            //    entity.Percentage
            //};

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Tipo de Produto criado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Tipo de Produto", true);
        }

        public async Task<ResponseDefault> UpdateAsync(ProductTypeEntity entity)
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

            return result ? new ResponseDefault("Tipo de Produto alterado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao alterar Tipo de Produto", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            var query = $"DELETE FROM category WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Tipo de Produto excluído com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao excluir Tipo de Produto", true);
        }

        public async Task<ProductTypeEntity> GetByIdAsync(Guid id)
        {
            var query = $"SELECT * FROM category WHERE id = '{id}' AND active = true";
            return await QueryFirstOrDefaultAsync<ProductTypeEntity>(query);
        }

        public async Task<ProductTypeEntity> GetByNameAsync(string name)
        {
            var query = $"SELECT * FROM category WHERE name = '{name}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<ProductTypeEntity>(query);
        }

        public async Task<PaginationResponse<ProductTypeEntity>> GetByFilterAsync(ProductTypeGetByFilterRequest filter)
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

            var result = await QueryAsync<ProductTypeEntity>(sql.ToString());

            return new PaginationResponse<ProductTypeEntity>(filter.PageSize, filter.Page, result);
        }
    }
}