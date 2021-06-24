using AutoMapper;
using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;

namespace LojaQualquer.WebApi.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductCreateUpdateRequest, Product>();
            CreateMap<Product, ProductResponse>()
                .ForMember(x => x.ProductId, src => src.MapFrom(p => p.Id));
        }
    }
}