using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobClubService
    {
        Task<Pagination> GetPaginationClubAsync(int totalItemsPerPage);
        Task<SyncPageData> SyncJobClubsAsync(int totalItemsPerPage, SyncPageData syncPageData);
    }
}
