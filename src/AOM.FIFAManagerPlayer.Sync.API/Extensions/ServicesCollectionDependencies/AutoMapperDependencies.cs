using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Dtos;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Dtos;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions.ServicesCollectionDependencies
{
    public static class AutoMapperDependencies
    {
        public static IServiceCollection AddingAutoMapperDependencies(this IServiceCollection services)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceWithoutSyncData, SourceWithoutSyncDto>();

                cfg.CreateMap<SyncData, SyncDto>().
                ForMember(dest => dest.SyncPageDto, src => src.MapFrom(x => x.SyncPages)); 
                
                cfg.CreateMap<SyncPageData, SyncPageDto>().
                ForMember(dest => dest. SourceWithoutSync, src => src.MapFrom(x => x.SourcesWithoutSync));

                
                

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
