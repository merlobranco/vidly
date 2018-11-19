using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Customer, CustomerDto>();

            // Dto to Domain
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}