using SysManager.Application.Contracts.Category.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("category")]
    public class CategoryEntity
    {
        public CategoryEntity(CategoryPostRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Active = request.Active;
        }

        public CategoryEntity(CategoryPutRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Active = request.Active;
        }

        public CategoryEntity()
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