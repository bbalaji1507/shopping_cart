namespace ShopingCart.API.Models.DTO
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string CustName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
