﻿using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Nation;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces
{
    public interface IHttpClientFactoryService
    {
        Task<LeagueListResponse> GetLeaguesAsync(Request request);

        Task<ClubListResponse> GetClubsAsync(Request request);

        Task<PlayerListResponse> GetPlayersAsync(Request request);

        Task<NationListResponse> GetNationsAsync(Request request);
    }
}
