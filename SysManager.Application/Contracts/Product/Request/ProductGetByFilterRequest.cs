namespace SysManager.Application.Contracts.Product.Request
{
    public class ProductGetByFilterRequest
    {
        public string Name { get; set; }
        public string Active { get; set; }
        public string CategoryId { get; set; }
        public string ProductTypeId { get; set; }
        public string UnityId { get; set; }

        /// <summary>
        /// Página da consulta
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Página final da consulta
        /// </summary>
        public int PageSize { get; set; }
    }
}