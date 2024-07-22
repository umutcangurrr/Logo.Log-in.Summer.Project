using Application.Logo.RestApi.Request;
using AutoMapper;
using Application.Logo.Business.RequestFolder;

namespace Application.Logo.RestApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SumRestRequest, SumBusinessRequest>();
        }


    }
}
