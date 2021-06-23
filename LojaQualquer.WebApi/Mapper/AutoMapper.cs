using AutoMapper;
using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Models.Request;

namespace LojaQualquer.WebApi.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductCreateUpdateRequest, Product>();
        }
    }
}