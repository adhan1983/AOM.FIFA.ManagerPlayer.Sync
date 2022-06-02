using System;
using System.Linq;
using gRPCPlayerClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using p = AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class SyncJobPlayerService : ISyncJobPlayerService
    {
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        private readonly IPlayergRPCServiceClient _playergRPCServiceClient;
        private readonly ISourceWithoutSyncService _sourceWithoutSyncService;

        public SyncJobPlayerService(
            IHttpClientFactoryService httpClientServiceImplementation, 
            IPlayergRPCServiceClient playergRPCServiceClient,
            ISourceWithoutSyncService sourceWithoutSyncService
            )
        {
            this._httpClientServiceImplementation = httpClientServiceImplementation;
            this._playergRPCServiceClient = playergRPCServiceClient;
            this._sourceWithoutSyncService = sourceWithoutSyncService;
        }

        public async Task<SyncPageData> SyncJobPlayerAsync(int totalItemsPerPage, SyncPageData syncPageData)
        {
            var response = await _httpClientServiceImplementation.
                                    GetPlayersAsync(new Request { Page = syncPageData.Page, MaxItemPerPage = totalItemsPerPage });

            await RemoveSourcesWillNotBeSync(response, syncPageData);

            foreach (var player in response.items)
            {
                try
                {
                    var playerRequest = MapToPlayerRequest(player);

                    var playerReply = await _playergRPCServiceClient.InsertPlayerAsync(playerRequest);

                    if (playerReply.Id > 0)
                        syncPageData.TotalSynchronized++;
                }
                catch (Exception ex)
                {
                    syncPageData.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSyncData
                    {
                        SourceId = player.id,
                        SyncPageId = syncPageData.Id
                    };

                    syncPageData.SourcesWithoutSync.Add(sourceWithoutSync);
                }
            }

            return syncPageData;

        }

        private PlayerRequest MapToPlayerRequest(p.Player player)
        {
            var playerRequest = new PlayerRequest();
            
            playerRequest.SourceId = player.id;
            playerRequest.Name = player.name;
            playerRequest.Age = player.age;
            playerRequest.AttackWorkRate = player.attack_work_rate;
            playerRequest.SourceClubId = player.club;
            playerRequest.CommonName = player.common_name;
            playerRequest.Defending = player.defending;
            playerRequest.DefenseWorkRate = player.defense_work_rate;
            playerRequest.Dribbling = player.dribbling;
            playerRequest.Foot = player.foot;
            playerRequest.Height = player.height;
            playerRequest.LastName = player.last_name;
            playerRequest.SourceNationId = player.nation;
            playerRequest.Pace = player.pace;
            playerRequest.Passing = player.passing;
            playerRequest.Physicality = player.physicality;
            playerRequest.Position = player.position;
            playerRequest.Rarity = player.rarity;
            playerRequest.Rating = player.rating;
            playerRequest.Shooting = player.shooting;
            playerRequest.TotalStats = player?.total_stats ?? string.Empty;
            playerRequest.Weight = player.weight;

            return playerRequest;
        }

        private async Task<PlayerListResponse> RemoveSourcesWillNotBeSync(PlayerListResponse response, SyncPageData syncPageData)
        {
            //Player without club and nation can not be sync
            var playerNeedToBeRemoved = response.
                                        items.
                                        Where(x => x.club == null || x.nation == 0).
                                        Select(x => x.id).
                                        ToList();

            //If The Player's club was not synchronized, The Player can not be Synchronized
            var sourceClubIdsWeraNotSync = await _sourceWithoutSyncService.
                                                     GetSourcesWithoutSyncBySourceIdsAsync(response.items.Select(a => a.club.Value).
                                                     ToList());

            playerNeedToBeRemoved.AddRange(response.items.Where(x => sourceClubIdsWeraNotSync.Contains(x.club.Value)).Select(x => x.id).ToList());
            
            SourcesNeedToBeRemoved(response, syncPageData, playerNeedToBeRemoved);

            return response;
        }

        private PlayerListResponse SourcesNeedToBeRemoved(PlayerListResponse response, SyncPageData syncPageData, List<int> sources)
        {
            foreach (var sourceId in sources)
            {
                var sourceWithoutSync = new SourceWithoutSyncData
                {
                    SourceId = sourceId,
                    SyncPageId = syncPageData.Id
                };

                syncPageData.SourcesWithoutSync.Add(sourceWithoutSync);

                syncPageData.TotalDosNotSynchronized++;
            }

            response.items.RemoveAll(x => sources.Contains(x.id));

            return response;
        }

    }
}
