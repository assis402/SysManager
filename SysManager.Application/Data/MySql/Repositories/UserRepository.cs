using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<ResponseDefault> CreateAsync(UserEntity entity)
        {
            var query = $@"insert into user (id, username, email, password, active)
                          value(@id, @username, @email, @password, @active)";

            using (var context = _context.Connection())
            {
                var mapper = new { id = entity.Id,
                                   username = entity.UserName,
                                   email = entity.Email,
                                   password = entity.Password,
                                   active = entity.Active
                                  };

                var result = await context.ExecuteAsync(query, mapper);
                if (result > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Usuário criado com sucesso", false);
            }

            return new ResponseDefault("", "Erro ao criar usuário", true);
        }

        public async Task<ResponseDefault> RecoveryAsync(Guid id, string newPasword)
        {
            var query = $"update user set password = '{newPasword}' where id = '{id}'";

            using (var context = _context.Connection())
            {
                var result = await context.ExecuteAsync(query);
                if (result > 0)
                    return new ResponseDefault(id.ToString(), "Usuário criado com sucesso", false);
            }

            return new ResponseDefault("", "Erro ao criar usuário", true);
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            var query = $"select id, username, email, password, active from user where email = '{email}' limit 1";
            using (var context = _context.Connection())
            {
                var result = await context.QueryFirstOrDefaultAsync<UserEntity>(query);
                return result;
            }
        }

        public async Task<UserEntity> GetUserByUserNameAndEmailAsync(string userName, string email)
        {
            var query = $"select id, username, email, password, active from user where username = '{userName}' and email = '{email}' limit 1";
            using (var context = _context.Connection())
            {
                var result = await context.QueryFirstOrDefaultAsync(query);
                return result;
            }
        }

        public async Task<UserEntity> GetUserByUserNameAndPasswordAsync(string username, string password)
        {
            var query = $"select id, username, email, password, active, from user where username = '{username}' and password = '{password}' limit 1";
            using (var context = _context.Connection())
            {
                var result = await context.QueryFirstOrDefaultAsync(query);
                return result;
            }
        }
    }
}