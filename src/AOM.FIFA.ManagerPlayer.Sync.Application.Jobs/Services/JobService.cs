using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Base.Contants;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class JobService : IJobService
    {
        private readonly ISyncRepository _syncRepository;
        private readonly ISyncJobLeagueService _syncJobLeagueService;
        private readonly ISyncJobNationService _syncJobNationService;
        private readonly ISyncJobClubService _syncJobClubService;
        private readonly ISyncJobPlayerService _syncJobPlayerService;

        public JobService(
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

        public async Task ExecuteJobByNameAsync(string name)
        {
            var sync = await _syncRepository.GetSyncByExpressionAsync(s => s.Name == name);
            if (sync != null && !sync.Synchronized)
            {
                await ExecuteJobsAsync(sync);
            }

        }
        public async Task ExecuteAllJosbsAsync()
        {
            var allSyncJobsData = await _syncRepository.GetAllSyncDatawithIncludeAsync();

            foreach (var sync in allSyncJobsData)
            {
                await ExecuteJobsAsync(sync);
            }
        }

        private async Task ExecuteJobsAsync(SyncData sync)
        {

            for (int i = 0, ii = sync.TotalPages; i < ii; i++)
            {
                SyncPageData syncPageData = new SyncPageData()
                {
                    SyncId = sync.Id,
                    SourcesWithoutSync = new System.Collections.Generic.List<SourceWithoutSync.Data.SourceWithoutSyncData>()
                };

                syncPageData.Page = sync.SyncPages.Any() ? (sync.SyncPages.Max(a => a.Page) + 1) : 1;

                switch (sync.Name)
                {
                    case ApplicationContants.League:
                        await _syncJobLeagueService.SyncJobLeaguesAsync(sync.TotalItemsPerPage, syncPageData);
                        break;
                    case ApplicationContants.Nation:
                        await _syncJobNationService.SyncJobNationAsync(sync.TotalItemsPerPage, syncPageData);
                        break;
                    case ApplicationContants.Club:
                        var league = await _syncRepository.GetSyncByExpressionAsync(x => x.Name == ApplicationContants.League);
                        if (!league.Synchronized)
                            continue;
                        await _syncJobClubService.SyncJobClubsAsync(sync.TotalItemsPerPage, syncPageData);
                        break;
                    case ApplicationContants.Player:
                        var nation = await _syncRepository.GetSyncByExpressionAsync(x => x.Name == ApplicationContants.Nation);
                        var club = await _syncRepository.GetSyncByExpressionAsync(x => x.Name == ApplicationContants.Club);
                        if (!(nation.Synchronized && club.Synchronized))
                            continue;
                        await _syncJobPlayerService.SyncJobPlayerAsync(sync.TotalItemsPerPage, syncPageData);
                        break;
                    default:
                        continue;
                }

                syncPageData.SyncPageSuccess = syncPageData.TotalDosNotSynchronized > 0 ? false : true;
                sync.SyncPages.Add(syncPageData);
                sync.Synchronized = (sync.SyncPages.Max(a => a.Page) == sync.TotalPages);
                await _syncRepository.UpdateAsync(sync);
            }

        }

        public async Task SyncPageAsync()
        {
            var allSyncJobsData = await _syncRepository.GetAllSyncDatawithIncludeAsync();

            if (!allSyncJobsData.Any())
            {
                string[] arr = new string[]
                {
                    ApplicationContants.League, ApplicationContants.Nation, ApplicationContants.Club,ApplicationContants.Player
                };

                var pagination = new Pagination();

                for (int i = 0, ii = arr.Length; i < ii; i++)
                {
                    switch (arr[i])
                    {
                        case ApplicationContants.League:
                            pagination = await _syncJobLeagueService.GetPaginationLeagueAsync(20);
                            break;
                        case ApplicationContants.Nation:
                            pagination = await _syncJobNationService.GetPaginationNationAsync(20);
                            break;
                        case ApplicationContants.Club:
                            pagination = await _syncJobClubService.GetPaginationClubAsync(20);
                            break;
                        case ApplicationContants.Player:
                            pagination = await _syncJobPlayerService.GetPaginationPlayerAsync(20);
                            break;
                        default:
                            continue;
                    }

                    var syncData = new SyncData
                    {
                        Name = arr[i],
                        TotalItems = pagination.countTotal,
                        TotalPages = pagination.pageTotal,
                        TotalItemsPerPage = pagination.itemsPerPage,
                        Synchronized = false
                    };

                    await _syncRepository.InsertAsync(syncData);
                }
            }
        }

    }
}



