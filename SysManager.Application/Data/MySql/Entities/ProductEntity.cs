using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SysManager.Application.Contracts.Product.Request;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("product")]
    public class ProductEntity
    {
        public ProductEntity(ProductPostRequest request)
        {
            Id = Guid.NewGuid();
            ProductCode = request.ProductCode;
            Name = request.Name;
            Active = request.Active;
            ProductUnityId = request.ProductUnityId;
            ProductCategoryId = request.ProductCategoryId;
            ProductTypeId = request.ProductTypeId;
            Price = request.Price;
            CostPrice = request.CostPrice;
            Percentage = request.Percentage;
        }

        public ProductEntity(ProductPutRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Active = request.Active;
            Price = request.Price;
            CostPrice = request.CostPrice;
            Percentage = request.Percentage;
        }

        public ProductEntity()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("productCode")]
        public string ProductCode { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("productTypeId")]
        public string ProductTypeId { get; set; }

        [Column("productCategoryId")]
        public string ProductCategoryId { get; set; }

        [Column("productUnityId")]
        public string ProductUnityId { get; set; }

        [Column("costPrice")]
        public decimal CostPrice { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("percentage")]
        public decimal Percentage { get; set; }
    }
}