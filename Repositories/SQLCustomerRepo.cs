using Microsoft.EntityFrameworkCore;
using ShopingCart.API.Data;
using ShopingCart.API.Models.Domain;

namespace ShopingCart.API.Repositories
{
    public class SQLCustomerRepo : ICustomerRepo
    {
        private readonly ShopingCartDbContext _dbContext;

        public SQLCustomerRepo(ShopingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }
           

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
