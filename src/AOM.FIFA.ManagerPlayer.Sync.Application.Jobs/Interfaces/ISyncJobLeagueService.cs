using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobLeagueService
    {
        Task<Pagination> GetPaginationLeagueAsync(int totalItemsPerPage);
        Task<SyncPageData> SyncJobLeaguesAsync(int totalItemsPerPage, SyncPageData syncPageData);
    }
}
