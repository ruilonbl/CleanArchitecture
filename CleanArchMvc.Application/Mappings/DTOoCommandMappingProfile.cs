using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOoCommandMappingProfile : Profile
    {
        public DTOoCommandMappingProfile()
        {
            CreateMap<ProductCreateCommand, CategoryDTO>().ReverseMap();
            CreateMap<ProductUpdateCommand, ProductDTO>().ReverseMap();
        }
    }
}
