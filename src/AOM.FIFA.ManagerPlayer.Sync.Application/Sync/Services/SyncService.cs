using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncRepository _syncRepository;
        private readonly IMapper _mapper;
        public SyncService(ISyncRepository syncRepository, IMapper mapper) 
        {
            _mapper = mapper;
            this._syncRepository = syncRepository; 
        }

        public async Task<SyncListResponse> GetSynchronizationsAsync()
        {
            var models = await _syncRepository.GetAllSyncDatawithIncludeAsync();

            var response = new SyncListResponse();

            response.Syncs = _mapper.Map<List<SyncDto>>(models);

            return response;
        }

        public async Task<SyncResponse> GetSynchronizationsByIdAsync(int id)
        {
            var model = await _syncRepository.GetSyncByIdAsync(id);

            var response = new SyncResponse()
            {
                Sync = _mapper.Map<SyncDto>(model)
            };

            return response;
        }

    }
}
