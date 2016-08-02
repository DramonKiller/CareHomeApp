using AutoMapper;
using Dramonkiller.CareHomeApp.WebClient.ViewModels;
using Dramonkiller.CareHomeApp.WebServerDTOs.Residents;

namespace Dramonkiller.CareHomeApp.WebClient.App_Start
{
    public static class AutoMapperConfig
    {
        private static IMapper Instance { get; set; }

        public static IMapper Mapper
        {
            get
            {
                if (Instance == null)
                {
                    Initialize();
                }

                return Instance;
            }
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ResidentDTO, ResidentViewModel>()
                    .ForMember(dest => dest.HasNotifications, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Notifications))).ReverseMap();
                    cfg.CreateMap<ResidentLiteDTO, ResidentViewModel>(MemberList.Source)
                        .ForMember(dest => dest.HasNotifications, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Notifications)));
                });

                Instance = config.CreateMapper();

                Instance.ConfigurationProvider.AssertConfigurationIsValid();
            }
        }
    }
}