using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
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

                var reuslt = await context.ExecuteAsync(query, mapper);
                if (reuslt > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Usuário criado com sucesso", false);
            }

            return new ResponseDefault("", "Erro ao criar usuário", true);
        }
    }
}