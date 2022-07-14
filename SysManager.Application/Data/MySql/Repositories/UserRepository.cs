using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(MySqlContext context) : base(context)
        {
        }

        public async Task<ResponseDefault> CreateAsync(UserEntity entity)
        {
            var query = $@"INSERT INTO user (id, username, email, password, active)
                           VALUES(@Id, @Username, @Email, @Password, @Active)";

            //var param = new
            //{
            //    id = entity.Id,
            //    username = entity.UserName,
            //    email = entity.Email,
            //    password = entity.Password,
            //    active = entity.Active
            //};

            var result = await ExecuteAsync(query, entity);

            return result ? new ResponseDefault("Usuário criado com sucesso", false, entity.Id.ToString())
                          : new ResponseDefault("Erro ao tentar criar Usuário", true);
        }

        public async Task<ResponseDefault> RecoveryAsync(Guid id, string newPasword)
        {
            var query = $"UPDATE user SET password = '{newPasword}' WHERE id = '{id}'";

            var result = await ExecuteAsync(query);

            return result ? new ResponseDefault("Senha alterada com sucesso", false, id.ToString())
                          : new ResponseDefault("Erro ao alterar senha", true);
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            var query = $"SELECT id, username, email, password, active FROM USER WHERE email = '{email}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<UserEntity>(query);
        }

        public async Task<UserEntity> GetUserByUserNameAndEmailAsync(string userName, string email)
        {
            var query = $"SELECT id, username, email, password, active FROM user WHERE username = '{userName}' AND email = '{email}' AND active = true LIMIT 1";
            return await QueryFirstOrDefaultAsync<UserEntity>(query);
        }

        public async Task<UserEntity> GetUserByCredentialsAsync(string email, string password)
        {
            var query = $"SELECT id, username, email, password, active FROM user WHERE email = '{email}' AND password = '{password}' LIMIT 1";
            return await QueryFirstOrDefaultAsync<UserEntity>(query);
        }
    }
}