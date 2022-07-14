using SysManager.Application.Contracts.ProductType.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("productType")]
    public class ProductTypeEntity
    {
        public ProductTypeEntity(ProductTypePostRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Active = request.Active;
        }

        public ProductTypeEntity(ProductTypePutRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Active = request.Active;
        }

        public ProductTypeEntity()
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