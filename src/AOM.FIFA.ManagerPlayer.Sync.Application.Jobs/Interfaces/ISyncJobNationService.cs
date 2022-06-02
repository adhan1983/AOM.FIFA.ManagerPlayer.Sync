using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobNationService
    {
        Task<SyncPageData> SyncJobNationAsync(int totalItemsPerPage, SyncPageData syncPageData);
    }
}
