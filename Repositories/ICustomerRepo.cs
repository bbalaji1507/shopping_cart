using ShopingCart.API.Models.Domain;


namespace ShopingCart.API.Repositories
{
    public interface ICustomerRepo
    {
       Task<List<Customer>> GetAllCustomerAsync();

    }
}
