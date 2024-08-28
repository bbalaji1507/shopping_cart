namespace ShopingCart.API.Models.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
