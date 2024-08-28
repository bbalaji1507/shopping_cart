using AutoMapper;
using ShopingCart.API.Models.Domain;
using ShopingCart.API.Models.DTO;

namespace ShopingCart.API.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
