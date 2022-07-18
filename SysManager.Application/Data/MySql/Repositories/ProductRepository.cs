using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Product.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(MySqlContext context) : base(context)
        {
        }

        public async Task<ResponseDefault> CreateAsync(ProductEntity entity)
        {
            var query = @"INSERT INTO product(id, productCode, name, active, productTypeId, productCategoryId, productUnityId, costPrice, price, percentage) " +
                        @"VALUES(@Id, @ProductCode, @Name, @Active, @ProductTypeId, @ProductCategoryId, @ProductUnityId, @CostPrice, @Price, @Percentage)";

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Produto criado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Produto", true);
        }

        public async Task<ResponseDefault> UpdateAsync(ProductEntity entity)
        {
            var query = $"UPDATE product " +
                        $"SET name = @Name, active = @Active, costPrice = @CostPrice, price = @Price, percentage = @Percentage " +
                        $"WHERE id = @Id";

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Produto alterado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao alterar Produto", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            var query = $"DELETE FROM product WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Produto excluído com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao excluir Produto", true);
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            var query = $"SELECT * FROM product WHERE id = '{id}' AND active = true";
            return await QueryFirstOrDefaultAsync<ProductEntity>(query);
        }

        public async Task<ProductEntity> GetByNameAsync(string name)
        {
            var query = $"SELECT * FROM product WHERE name = '{name}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<ProductEntity>(query);
        }

        public async Task<CategoryEntity> GetByProductCodeAsync(string productCode)
        {
            var query = $"SELECT * FROM category WHERE productCode = '{productCode}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<CategoryEntity>(query);
        }

        public async Task<PaginationResponse<ProductEntity>> GetByFilterAsync(ProductGetByFilterRequest filter)
        {
            var sql = new StringBuilder("select * from product where 1=1");
                var where = new StringBuilder();

                if (!string.IsNullOrEmpty(filter.Name))
                    where.Append(" AND name like '%" + filter.Name + "%'");

                if (!string.IsNullOrEmpty(filter.ProductTypeId))
                    where.Append(" AND productTypeId = '" + filter.ProductTypeId + "'");

                if (!string.IsNullOrEmpty(filter.UnityId))
                    where.Append(" AND unityId = '" + filter.UnityId + "'");

                if (!string.IsNullOrEmpty(filter.CategoryId))
                    where.Append(" AND categoryId = '" + filter.CategoryId + "'");

                if (filter.Active.ToLower() != "todos")
                {
                    string _booleanFilter = "";
                    if (filter.Active.ToLower() == "ativos")
                        _booleanFilter = " AND active = true";
                    else if (filter.Active.ToLower() == "inativos")
                        _booleanFilter = " AND active = false";

                    where.Append(_booleanFilter);
                }

                sql.Append(where);

                if (filter.Page > 0 && filter.PageSize > 0)
                    sql.Append($" Limit {filter.PageSize * (filter.Page - 1)}, {filter.PageSize}");

            var result = await QueryAsync<ProductEntity>(sql.ToString());

            return new PaginationResponse<ProductEntity>(filter.PageSize, filter.Page, result);
        }
    }
}