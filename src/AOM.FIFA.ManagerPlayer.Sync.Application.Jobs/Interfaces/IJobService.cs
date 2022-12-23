using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface IJobService
    {
        Task SyncPageAsync();
        Task ExecuteAllJosbsAsync();
    }
}
