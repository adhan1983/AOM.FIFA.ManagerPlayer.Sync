using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobPlayerService
    {
        Task<Pagination> GetPaginationPlayerAsync(int totalItemsPerPage);
        Task<SyncPageData> SyncJobPlayerAsync(int totalItemsPerPage, SyncPageData syncPageData);
    }
}
