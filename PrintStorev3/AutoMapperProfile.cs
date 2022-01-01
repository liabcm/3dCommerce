using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrintStorev3.Models;
using PrintStorev3.Dtos;

namespace PrintStorev3
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>();
            CreateMap<AddPerosnDto, Person>();
            CreateMap<UpdatePerson, Person>();
            CreateMap<Order, GetOrderCartDto>();
            CreateMap<AddOrderCartDto, Order>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Product, GetProductDto>();
        }
    }
}
//Mapper.CreateMap<Employee, EmployeeDto>()
// .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));