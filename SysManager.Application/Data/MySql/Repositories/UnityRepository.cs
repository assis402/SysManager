using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UnityRepository
    {
        private readonly MySqlContext _context;

        public UnityRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<ResponseDefault> PostAsync(UserEntity entity)
        {
            return new ResponseDefault("", "", true);
        }

        public async Task<ResponseDefault> PutAsync(UserEntity entity)
        {
            return new ResponseDefault("", "", true);
        }

        public async Task<ResponseDefault> DeleteByIdAsync(Guid id)
        {
            return new ResponseDefault("", "", true);
        }

        public async Task<ResponseDefault> GetByIdAsync(Guid id)
        {
            return new ResponseDefault("", "", true);
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


            using (var context = _context.Connection())
            {
                var result = await context.QueryAsync<UnityEntity>(sql.ToString());

                return new PaginationResponse<UnityEntity>(filter.PageSize, filter.Page, result);
            }
        }
    }
}