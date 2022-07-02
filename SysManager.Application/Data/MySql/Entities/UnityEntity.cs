using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SysManager.Application.Contracts.Unity.Request;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("unity")]
    public class UnityEntity
    {
        public UnityEntity(UnityPostRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Active = request.Active;
        }

        public UnityEntity(UnityPutRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Active = request.Active;
        }

        public UnityEntity()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}