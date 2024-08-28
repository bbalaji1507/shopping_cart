using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopingCart.API.Data;
using ShopingCart.API.Models.DTO;
using ShopingCart.API.Repositories;
using System.Collections.Generic;

namespace ShopingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ShopingCartDbContext _dbContext;
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomerController(ShopingCartDbContext dbContext,ICustomerRepo customerRepo,IMapper mapper)
        {
            this._dbContext = dbContext;
            this._customerRepo = customerRepo;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get the data from the database
            var customers = await _customerRepo.GetAllCustomerAsync();

            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }

        [HttpGet("{id}")]
        //Route["{Id}"]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customers =await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);


            if (customers != null)
            {
                var customerdto = new CustomerDto()
                {
                    CustName = customers.CustName,
                    CustomerId = customers.CustomerId,
                    PhoneNumber = customers.PhoneNumber

                };
                return Ok(customerdto);

            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerDto addCustomerDto)
        {
            // Map the DTO to the domain model
            var customerDomain = new Models.Domain.Customer
            {
                CustName = addCustomerDto.CustName,
                PhoneNumber = addCustomerDto.PhoneNumber
            };

            // Save the customer to the database
           await _dbContext.Customers.AddAsync(customerDomain);
           await  _dbContext.SaveChangesAsync();

            //map domain to DTO

            var customerDto = new CustomerDto { CustomerId = customerDomain.CustomerId, CustName = customerDomain.CustName, PhoneNumber = customerDomain.PhoneNumber };

            // Return the result using CreatedAtAction to provide location URI
            return CreatedAtAction(nameof(GetById), new { id = customerDto.CustomerId }, customerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateCustomer(Guid id, [FromBody] CustomerUpdateDto customerUpdateDto)
        {
            var customerDomianModel = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

            if (customerDomianModel == null)
            {
                return NotFound();
            }

            customerDomianModel.CustName = customerUpdateDto.CustName;
            customerDomianModel.PhoneNumber = customerUpdateDto.PhoneNumber;

           await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }

                _dbContext.Remove(customer);
           await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}

