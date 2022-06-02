using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncRepository _syncRepository;

        public SyncService(ISyncRepository syncRepository) => this._syncRepository = syncRepository;

        public async Task<SyncListResponse> GetSynchronizationsAsync()
        {
            var models = await _syncRepository.GetAllAsync();
            
            var response = new SyncListResponse() 
            {
                Syncs = models.
                        Select(x => 
                        new Dtos.SyncDto 
                        { 
                            Id = x.Id, 
                            Name = x.Name, 
                            Synchronized = x.Synchronized, 
                            TotalItems = x.TotalItems, 
                            TotalItemsPerPage = x.TotalItemsPerPage, 
                            TotalPages = x.TotalPages  
                        }).
                        ToList()
            };

            return response;
        }

        public async Task<SyncResponse> GetSynchronizationsByIdAsync(int id)
        {
            var model = await _syncRepository.GetByIdAsync(id);

            var response = new SyncResponse() 
            {
                Sync = new Dtos.SyncDto() 
                {
                    Id = model.Id,
                    Name = model.Name,
                    Synchronized = model.Synchronized,
                    TotalItems = model.TotalItems,
                    TotalItemsPerPage = model.TotalItemsPerPage,
                    TotalPages = model.TotalPages
                }
            };

            return response;
        }
    }
}
