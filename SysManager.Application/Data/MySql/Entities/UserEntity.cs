using SysManager.Application.Contracts.Users.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("user")]
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(UserPostRequest user)
        {
            Id = Guid.NewGuid();
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            Active = true;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("userName")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}