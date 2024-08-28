using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ShopingCart.API.Models.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        //navigation

        public Product Product { get; set; }
        public Customer Customer { get; set; }


    }
}
