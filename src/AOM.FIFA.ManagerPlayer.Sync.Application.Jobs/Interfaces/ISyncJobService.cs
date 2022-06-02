using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces
{
    public interface ISyncJobService
    {
        Task ExecuteJobsAsync();
    }
}
