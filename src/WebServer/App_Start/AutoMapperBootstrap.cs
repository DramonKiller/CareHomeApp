using AutoMapper;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;

namespace Dramonkiller.CareHomeApp.WebServer
{
    public static class AutoMapperBootstrap
    {
        public static IMapper Mapper { get; private set; }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Resident, ResidentDTO>().ReverseMap();
                cfg.CreateMap<Resident, ResidentLiteDTO>().ReverseMap();
            });

            Mapper = config.CreateMapper();

            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}