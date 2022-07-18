using SysManager.Application.Contracts.Product.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("product")]
    public class ProductEntity
    {

        public ProductEntity(ProductPostRequest product)
        {
            Id = Guid.NewGuid();
            Name = product.Name;
            ProductCode = product.ProductCode;
            ProductTypeId = product.ProductTypeId;
            CategoryId = product.CategoryId;
            UnityId = product.UnityId;
            CostPrice = product.CostPrice;
            Percentage = product.Percentage;
            Price = product.Price;
            Active = product.Active;
        }

        public ProductEntity(ProductPutRequest product)
        {
            Id = product.Id;
            Name = product.Name;
            ProductCode = product.ProductCode;
            ProductTypeId = product.ProductTypeId;
            CategoryId = product.CategoryId;
            UnityId = product.UnityId;
            CostPrice = product.CostPrice;
            Percentage = product.Percentage;
            Price = product.Price;
            Active = product.Active;
        }

        public ProductEntity()
        {
        }


        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("productCode")]
        public string ProductCode { get; set; }

        [Column("productTypeId")]
        public string ProductTypeId { get; set; }
        
        [Column("categoryId")]
        public string CategoryId { get; set; }

        [Column("unityId")]
        public string UnityId { get; set; }

        [Column("coastPrice")]
        public decimal CostPrice { get; set; }

        [Column("percentage")]
        public decimal Percentage { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("active")]
        public bool Active { get; set; }

    }
}
