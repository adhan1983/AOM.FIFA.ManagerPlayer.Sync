using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobNationService
    {
        Task<Pagination> GetPaginationNationAsync(int totalItemsPerPage);
        Task<SyncPageData> SyncJobNationAsync(int totalItemsPerPage, SyncPageData syncPageData);
    }
}
