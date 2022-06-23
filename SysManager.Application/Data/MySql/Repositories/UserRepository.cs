using SysManager.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UserRepository
    {
        public UserRepository()
        {
        }

        public async Task<UserEntity> CreatAsync(UserEntity entity)
        {
            var _query = $@"insert into user (id, username, email, password, active)
                          value(@id, @username, @email, @password, @active)";

            return entity;
        }
    }
}