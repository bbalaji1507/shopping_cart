namespace ShopingCart.API.Models.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
    }
}
