using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Base
{
    public class BaseSyncJobService
    {
        protected readonly ISyncRepository _syncRepository;
        protected readonly ISyncJobLeagueService _syncJobLeagueService;
        protected readonly ISyncJobNationService _syncJobNationService;

        public BaseSyncJobService(ISyncRepository syncRepository, ISyncJobLeagueService syncJobLeagueService, ISyncJobNationService syncJobNationService)
        {
            this._syncRepository= syncRepository;
            this._syncJobLeagueService= syncJobLeagueService;
            this._syncJobNationService= syncJobNationService;
        }
    }
}
