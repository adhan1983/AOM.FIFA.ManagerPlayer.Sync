using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services
{
    public interface ISyncService 
    {
        Task<SyncListResponse> GetSynchronizationsAsync();
        Task<SyncResponse> GetSynchronizationsByIdAsync(int id);
    }
}
