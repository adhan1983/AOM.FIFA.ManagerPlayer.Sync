using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.Base.Contants;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    //BaseSyncJobService
    public class SyncJobService : ISyncJobService
    {
        private readonly ISyncRepository _syncRepository;
        private readonly ISyncJobLeagueService _syncJobLeagueService;
        private readonly ISyncJobNationService _syncJobNationService;
        private readonly ISyncJobClubService _syncJobClubService;
        private readonly ISyncJobPlayerService _syncJobPlayerService;

        public SyncJobService(
            ISyncRepository syncRepository, ISyncJobLeagueService syncJobLeagueService, 
            ISyncJobNationService syncJobNationService, ISyncJobClubService syncJobClubService,
            ISyncJobPlayerService syncJobPlayerService
            )
        {
            this._syncRepository = syncRepository;
            this._syncJobLeagueService = syncJobLeagueService;
            this._syncJobNationService = syncJobNationService;
            this._syncJobClubService = syncJobClubService;
            this._syncJobPlayerService = syncJobPlayerService;
        }
            //base(syncRepository, syncJobLeagueService, syncJobNationService) { }
        public async Task ExecuteJobsAsync()
        {
            var allSyncJobsData = await _syncRepository.GetAllSyncDatawithIncludeAsync();            

            if (allSyncJobsData.Any(a => !a.Synchronized))
            {
                foreach (var syncJob in allSyncJobsData)
                {
                    if (syncJob.Synchronized)
                        continue;
                    
                    SyncPageData syncPageData = new SyncPageData() 
                    { 
                        SyncId = syncJob.Id, 
                        SourcesWithoutSync = new System.Collections.Generic.List<SourceWithoutSync.Data.SourceWithoutSyncData>() 
                    };
                    
                    syncPageData.Page = syncJob.SyncPages.Any() ? (syncJob.SyncPages.Max(a => a.Page) + 1) : 1;

                    switch (syncJob.Name)
                    {
                        case ApplicationContants.League : await _syncJobLeagueService.SyncJobLeaguesAsync(syncJob.TotalItemsPerPage, syncPageData);
                            break;
                        case ApplicationContants.Nation: await _syncJobNationService.SyncJobNationAsync(syncJob.TotalItemsPerPage, syncPageData);
                            break;
                        case ApplicationContants.Club:
                            if (!allSyncJobsData.FirstOrDefault(x => x.Name == ApplicationContants.League).Synchronized)
                                continue;
                            await _syncJobClubService.SyncJobClubsAsync(syncJob.TotalItemsPerPage, syncPageData);                            
                            break;
                        case ApplicationContants.Player:
                            if (!(allSyncJobsData.FirstOrDefault(x => x.Name == ApplicationContants.Nation).Synchronized && allSyncJobsData.FirstOrDefault(x => x.Name == ApplicationContants.Club).Synchronized))
                                continue;
                            await _syncJobPlayerService.SyncJobPlayerAsync(syncJob.TotalItemsPerPage, syncPageData);
                            break;
                        default:
                            continue;                            
                    }

                    //SyncPageData resultSyncPageData = syncJob.Name switch
                    //{
                    //    ApplicationContants.League => await _syncJobLeagueService.SyncJobLeaguesAsync(syncJob.TotalItemsPerPage, syncPageData),

                    //    ApplicationContants.Nation => await _syncJobNationService.SyncJobNationAsync(syncJob.TotalItemsPerPage, syncPageData),

                    //};                   

                    syncPageData.SyncPageSuccess = syncPageData.TotalDosNotSynchronized > 0 ? false : true;
                    syncJob.SyncPages.Add(syncPageData);
                    syncJob.Synchronized = (syncJob.SyncPages.Max(a => a.Page) == syncJob.TotalPages);
                    await _syncRepository.UpdateAsync(syncJob);
                }

                
            }            

        }

    }
}




//private SyncDto MapToSyncDto(SyncData sync)
//{
//    //Sync
//    var syncDto = new SyncDto();
//    syncDto.Id = sync.Id;
//    syncDto.Name = sync.Name;
//    syncDto.TotalItems = sync.TotalItems;
//    syncDto.TotalPages = sync.TotalPages;
//    sync.TotalItemsPerPage = sync.TotalItemsPerPage;
//    syncDto.Synchronized = sync.Synchronized;

//    //SyncPages
//    var syncDataPages = sync.SyncPages;
//    syncDto.SyncPageDto.TotalPageSynchronized = syncDataPages.Where(x => x.Page > 0).Count();
//    syncDto.SyncPageDto.TotalItemsSynchronized = syncDataPages.Sum(a => a.TotalSynchronized);
//    syncDto.SyncPageDto.TotalItensDoNotSynchronized = syncDataPages.Sum(a => a.TotalDosNotSynchronized);
//    syncDto.SyncPageDto.TotalSyncPageSuccess = syncDataPages.Where(a => a.SyncPageSuccess == true).Count();
//    syncDto.SyncPageDto.TotalSyncPageFail = syncDataPages.Where(a => a.SyncPageSuccess == false).Count();

//    return syncDto;
//}      
